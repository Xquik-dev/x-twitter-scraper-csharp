// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

package main

import (
	"bytes"
	"crypto/sha256"
	"encoding/hex"
	"encoding/json"
	"errors"
	"fmt"
	"io"
	"math/big"
	"os"
	"sort"
	"strconv"
)

type count struct {
	Covered uint64 `json:"covered"`
	Total   uint64 `json:"total"`
}

type summary struct {
	Lines     count    `json:"lines"`
	Branches  count    `json:"branches"`
	Methods   count    `json:"methods"`
	Documents []string `json:"documents"`
	SHA256    string   `json:"sha256"`
}

type branch struct {
	Line      *int32
	Offset    *int32
	EndOffset *int32
	Path      *int32
	Ordinal   *int32
	Hits      *int32
}

type method struct {
	Lines    map[string]*int32
	Branches []branch
}

type modules map[string]map[string]map[string]map[string]method

func main() {
	if err := run(os.Args[1:]); err != nil {
		if writeErr := json.NewEncoder(os.Stderr).Encode(map[string]string{"error": err.Error()}); writeErr != nil {
			fmt.Fprintln(os.Stderr, writeErr)
		}
		os.Exit(1)
	}
}

func run(args []string) error {
	if len(args) == 2 && args[0] == "summary" {
		result, err := readSummary(args[1])
		if err != nil {
			return err
		}
		return json.NewEncoder(os.Stdout).Encode(result)
	}
	if len(args) == 3 && args[0] == "compare" {
		parent, err := readSummary(args[1])
		if err != nil {
			return err
		}
		candidate, err := readSummary(args[2])
		if err != nil {
			return err
		}
		for _, metric := range []struct {
			name              string
			parent, candidate count
		}{
			{"lines", parent.Lines, candidate.Lines},
			{"branches", parent.Branches, candidate.Branches},
			{"methods", parent.Methods, candidate.Methods},
		} {
			if !preserved(metric.parent, metric.candidate) {
				return fmt.Errorf("%s regressed from %d/%d to %d/%d", metric.name, metric.parent.Covered, metric.parent.Total, metric.candidate.Covered, metric.candidate.Total)
			}
		}
		return json.NewEncoder(os.Stdout).Encode(struct {
			Parent    summary `json:"parent"`
			Candidate summary `json:"candidate"`
		}{parent, candidate})
	}
	return errors.New("use summary <raw-coverlet.json> or compare <parent.json> <candidate.json>")
}

func readSummary(path string) (summary, error) {
	data, err := os.ReadFile(path)
	if err != nil {
		return summary{}, err
	}
	decoder := json.NewDecoder(bytes.NewReader(data))
	decoder.DisallowUnknownFields()
	var report modules
	if err := decoder.Decode(&report); err != nil {
		return summary{}, err
	}
	if _, err := decoder.Token(); err != io.EOF {
		return summary{}, errors.New("coverage must contain exactly one JSON object")
	}
	if len(report) != 1 || len(report["XTwitterScraper.dll"]) == 0 {
		return summary{}, errors.New("coverage must contain the complete XTwitterScraper.dll module")
	}
	hash := sha256.Sum256(data)
	result := summary{SHA256: hex.EncodeToString(hash[:])}
	for document, classes := range report["XTwitterScraper.dll"] {
		if document == "" || len(classes) == 0 {
			return summary{}, errors.New("coverage source document is empty")
		}
		result.Documents = append(result.Documents, document)
		for class, methods := range classes {
			if class == "" || len(methods) == 0 {
				return summary{}, errors.New("coverage class is empty")
			}
			for name, method := range methods {
				if name == "" || method.Lines == nil || method.Branches == nil {
					return summary{}, errors.New("coverage method must contain line and branch counters")
				}
				coveredMethod := false
				for line, hits := range method.Lines {
					number, err := strconv.ParseUint(line, 10, 32)
					if err != nil || number == 0 || hits == nil || *hits < 0 {
						return summary{}, errors.New("coverage line counters must be nonnegative integers on positive line numbers")
					}
					result.Lines.Total++
					if *hits > 0 {
						result.Lines.Covered++
						coveredMethod = true
					}
				}
				if len(method.Lines) > 0 {
					result.Methods.Total++
					if coveredMethod {
						result.Methods.Covered++
					}
				}
				for _, branch := range method.Branches {
					if branch.Line == nil || branch.Offset == nil || branch.EndOffset == nil || branch.Path == nil || branch.Ordinal == nil || branch.Hits == nil || *branch.Line <= 0 || *branch.Offset < 0 || *branch.EndOffset < 0 || *branch.Path < 0 || *branch.Ordinal < 0 || *branch.Hits < 0 {
						return summary{}, errors.New("coverage branch counters are missing or invalid")
					}
					result.Branches.Total++
					if *branch.Hits > 0 {
						result.Branches.Covered++
					}
				}
			}
		}
	}
	if result.Lines.Total == 0 {
		return summary{}, errors.New("coverage has no executable lines")
	}
	sort.Strings(result.Documents)
	return result, nil
}

func preserved(parent, candidate count) bool {
	if candidate.Total-candidate.Covered <= parent.Total-parent.Covered {
		return true
	}
	if parent.Total == 0 {
		return candidate.Covered == candidate.Total
	}
	if candidate.Total == 0 {
		return true
	}
	left := new(big.Int).Mul(new(big.Int).SetUint64(candidate.Covered), new(big.Int).SetUint64(parent.Total))
	right := new(big.Int).Mul(new(big.Int).SetUint64(parent.Covered), new(big.Int).SetUint64(candidate.Total))
	return left.Cmp(right) >= 0
}
