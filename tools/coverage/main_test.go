// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

package main

import (
	"encoding/json"
	"os"
	"os/exec"
	"path/filepath"
	"strings"
	"testing"
)

const nativeReport = `{"XTwitterScraper.dll":{"/source/src/XTwitterScraper/Client.cs":{"Client":{"A":{"Lines":{"4":1,"5":0},"Branches":[{"Line":4,"Offset":0,"EndOffset":2,"Path":0,"Ordinal":0,"Hits":1},{"Line":4,"Offset":0,"EndOffset":4,"Path":1,"Ordinal":1,"Hits":0}]},"B":{"Lines":{"5":2},"Branches":[]},"C":{"Lines":{"8":0},"Branches":[]},"NoSequencePoints":{"Lines":{},"Branches":[]}}},"/source/src/XTwitterScraper/Generated.cs":{"Generated":{"get_Value":{"Lines":{"3":0},"Branches":[]}}}}}`

func writeReport(t *testing.T, name, content string) string {
	t.Helper()
	path := filepath.Join(t.TempDir(), name)
	if err := os.WriteFile(path, []byte(content), 0600); err != nil {
		t.Fatal(err)
	}
	return path
}

func invoke(t *testing.T, args ...string) (string, error) {
	t.Helper()
	cmd := exec.Command("go", append([]string{"run", "main.go"}, args...)...)
	data, err := cmd.CombinedOutput()
	return string(data), err
}

func TestSummaryCountsNativeLinesBranchesAndMethods(t *testing.T) {
	raw := writeReport(t, "coverage.json", nativeReport)
	output, err := invoke(t, "summary", raw)
	if err != nil {
		t.Fatalf("%v: %s", err, output)
	}
	var actual struct {
		Lines, Branches, Methods struct{ Covered, Total uint64 }
		Documents                []string
	}
	if err := json.Unmarshal([]byte(output), &actual); err != nil {
		t.Fatal(err)
	}
	if actual.Lines.Covered != 2 || actual.Lines.Total != 5 || actual.Branches.Covered != 1 || actual.Branches.Total != 2 || actual.Methods.Covered != 2 || actual.Methods.Total != 4 {
		t.Fatalf("unexpected raw counts: %s", output)
	}
	if len(actual.Documents) != 2 || !strings.HasSuffix(actual.Documents[1], "Generated.cs") {
		t.Fatalf("generated source disappeared: %s", output)
	}
	var fields map[string]json.RawMessage
	if err := json.Unmarshal([]byte(output), &fields); err != nil {
		t.Fatal(err)
	}
	if _, exists := fields["statements"]; exists {
		t.Fatalf("a native line count was relabeled: %s", output)
	}
}

func TestCompareUsesRatiosOrUncoveredCounts(t *testing.T) {
	parent := writeReport(t, "parent.json", nativeReport)
	for _, tc := range []struct {
		name, report string
		pass         bool
	}{
		{"unchanged", nativeReport, true},
		{"new uncovered line", strings.Replace(nativeReport, `"8":0`, `"8":0,"9":0`, 1), false},
		{"new uncovered method", strings.Replace(strings.Replace(nativeReport, `"4":1,"5":0`, `"4":1`, 1), `"NoSequencePoints":{"Lines":{},"Branches":[]}`, `"NoSequencePoints":{"Lines":{"5":0},"Branches":[]}`, 1), false},
		{"new uncovered branch", strings.Replace(nativeReport, `"Hits":1`, `"Hits":0`, 1), false},
		{"deleted covered method", strings.Replace(nativeReport, `"Lines":{"5":2}`, `"Lines":{}`, 1), true},
		{"improved ratio with more uncovered lines", strings.Replace(nativeReport, `"8":0`, `"8":0,"9":0,"10":1,"11":1`, 1), true},
		{"equal ratio with more uncovered lines", strings.Replace(nativeReport, `"8":0`, `"8":0,"9":0,"10":0,"11":0,"12":1,"13":1`, 1), true},
	} {
		t.Run(tc.name, func(t *testing.T) {
			candidate := writeReport(t, "candidate.json", tc.report)
			output, err := invoke(t, "compare", parent, candidate)
			if (err == nil) != tc.pass {
				t.Fatalf("pass=%t: %v: %s", tc.pass, err, output)
			}
		})
	}
}

func TestSummaryRejectsInvalidNativeReports(t *testing.T) {
	for _, tc := range []struct{ name, raw string }{
		{"empty module", `{}`}, {"wrong module", `{"Other.dll":{}}`},
		{"negative line hits", strings.Replace(nativeReport, `"4":1`, `"4":-1`, 1)},
		{"fractional line hits", strings.Replace(nativeReport, `"4":1`, `"4":1.5`, 1)},
		{"null line hits", strings.Replace(nativeReport, `"4":1`, `"4":null`, 1)},
		{"negative branch hits", strings.Replace(nativeReport, `"Hits":1`, `"Hits":-1`, 1)},
		{"invalid source line", strings.Replace(nativeReport, `"4":1`, `"0":1`, 1)},
		{"unknown branch field", strings.Replace(nativeReport, `"Hits":1`, `"Hits":1,"Unexpected":1`, 1)},
		{"trailing JSON", nativeReport + `{}`},
		{"null line counters", strings.Replace(nativeReport, `"Lines":{"4":1,"5":0}`, `"Lines":null`, 1)},
	} {
		t.Run(tc.name, func(t *testing.T) {
			path := writeReport(t, "invalid.json", tc.raw)
			output, err := invoke(t, "summary", path)
			if err == nil || !strings.Contains(output, "error") {
				t.Fatalf("invalid report passed: %v: %s", err, output)
			}
		})
	}
}
