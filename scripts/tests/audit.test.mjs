// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Runs scripts/audit in a throwaway folder. A fake dotnet prints the
// vulnerability report, and a fake advisory API says whether a fix exists.

import assert from "node:assert/strict";
import fs from "node:fs";
import path from "node:path";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const fakeDotnet = `#!/bin/sh
# Stands in for "dotnet list package". It records each call and prints the report the test names.
printf '%s\\n' "$*" >>"$FAKE_LOGS/dotnet"
case " $* " in
  *" --vulnerable "*) cat "$FAKE_VULNERABILITY_REPORT" ;;
  *) echo '{"version":1,"projects":[]}' ;;
esac
`;

const advisory = "GHSA-aaaa-bbbb-cccc";
const severities = ["Low", "Moderate", "High", "Critical"];
const noFix = { vulnerabilities: [{ package: { ecosystem: "nuget", name: "Example.Package" }, first_patched_version: null }] };
const hasFix = { vulnerabilities: [{ package: { ecosystem: "nuget", name: "Example.Package" }, first_patched_version: "1.2.4" }] };

function day(offset) {
  return new Date(Date.now() + offset * 86_400_000).toISOString().slice(0, 10);
}

// A report in the shape of "dotnet list package --vulnerable --format json".
function report(project, severity) {
  return {
    version: 1,
    projects: [
      {
        path: `/work/src/${project}/${project}.csproj`,
        frameworks: [
          {
            framework: "net8.0",
            transitivePackages: [
              {
                id: "Example.Package",
                resolvedVersion: "1.2.3",
                vulnerabilities: [{ severity, advisoryurl: `https://github.com/advisories/${advisory}` }],
              },
            ],
          },
        ],
      },
    ],
  };
}

function exception(project, recheck, reason = "build-time only") {
  return { advisory, package: `${project} > Example.Package`, reason, recheck };
}

function audit(t, { findings = { version: 1, projects: [] }, exceptions = [], advisories = {} }) {
  const sandbox = createSandbox(t);
  for (const file of ["scripts/audit", "scripts/verify-vulnerabilities.mjs", "scripts/verify-package-licenses.mjs"]) {
    sandbox.copy(file);
  }
  sandbox.write("audit-exceptions.json", JSON.stringify(exceptions));
  sandbox.fake("dotnet", fakeDotnet);
  const reportFile = path.join(sandbox.base, "report.json");
  const advisoryApi = path.join(sandbox.base, "fake-advisory-api.mjs");
  fs.writeFileSync(reportFile, JSON.stringify(findings));
  fs.copyFileSync(path.join(import.meta.dirname, "fake-advisory-api.mjs"), advisoryApi);
  const result = sandbox.run("scripts/audit", [], {
    FAKE_ADVISORIES: JSON.stringify(advisories),
    FAKE_VULNERABILITY_REPORT: reportFile,
    NODE_OPTIONS: `--import=${advisoryApi}`,
  });
  return { ...result, dotnet: sandbox.log("dotnet"), lookups: sandbox.log("advisories") };
}

for (const severity of severities) {
  test(`a ${severity} finding in the shipped package blocks, even when it is listed and has no fix`, (t) => {
    const result = audit(t, {
      findings: report("XTwitterScraper", severity),
      exceptions: [exception("XTwitterScraper", day(10))],
      advisories: { [advisory]: noFix },
    });

    assert.equal(
      result.stderr,
      `Blocked. XTwitterScraper > Example.Package 1.2.3 ${advisory} (${severity}) is in the shipped package. Update it.\n` +
        "Vulnerability audit failed with 1 blocking finding(s).\n",
    );
    assert.equal(result.status, 1);
  });

  test(`a ${severity} test-only finding blocks when no exception lists it`, (t) => {
    const result = audit(t, { findings: report("XTwitterScraper.Tests", severity) });

    assert.equal(
      result.stderr,
      `Blocked. XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (${severity}) is not listed. Update it, or list it in audit-exceptions.json if no fix exists.\n` +
        "Vulnerability audit failed with 1 blocking finding(s).\n",
    );
    assert.equal(result.status, 1);
  });
}

test("a listed test-only finding without a fix passes until its recheck date", (t) => {
  const recheck = day(10);
  const result = audit(t, {
    findings: report("XTwitterScraper.Tests", "Low"),
    exceptions: [exception("XTwitterScraper.Tests", recheck)],
    advisories: { [advisory]: noFix },
  });

  assert.equal(result.stderr, "");
  assert.equal(
    result.stdout,
    "==> Auditing locked dependencies\n" +
      `Accepted the reviewed exception for XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (Low). It is build-time only. Recheck by ${recheck}.\n` +
      "Vulnerability audit passed with 1 reviewed exception.\n" +
      "==> Checking dependency license policy\n" +
      "Dependency license policy passed for 0 packages.\n" +
      "Dependency audit passed.\n",
  );
  assert.equal(result.status, 0);
  assert.deepEqual(result.lookups, [`https://api.github.com/advisories/${advisory}`]);
  assert.equal(
    result.dotnet[0],
    "list XTwitterScraper.sln package --vulnerable --include-transitive --format json --output-version 1",
  );
});

test("a listed test-only finding blocks as soon as a fixed version exists", (t) => {
  const result = audit(t, {
    findings: report("XTwitterScraper.Tests", "Low"),
    exceptions: [exception("XTwitterScraper.Tests", day(10))],
    advisories: { [advisory]: hasFix },
  });

  assert.equal(
    result.stderr,
    `Blocked. XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (Low) has a fixed version. Update it, then remove its exception.\n` +
      "Vulnerability audit failed with 1 blocking finding(s).\n",
  );
  assert.equal(result.status, 1);
});

test("a listed test-only finding blocks again on its recheck date", (t) => {
  const today = day(0);
  const result = audit(t, {
    findings: report("XTwitterScraper.Tests", "Low"),
    exceptions: [exception("XTwitterScraper.Tests", today)],
    advisories: { [advisory]: noFix },
  });

  assert.equal(
    result.stderr,
    `Blocked. XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (Low) has an exception that expired on ${today}. Recheck it.\n` +
      "Vulnerability audit failed with 1 blocking finding(s).\n",
  );
  assert.equal(result.status, 1);
});

test("a listed test-only finding blocks when the advisory lookup fails", (t) => {
  const result = audit(t, {
    findings: report("XTwitterScraper.Tests", "Low"),
    exceptions: [exception("XTwitterScraper.Tests", day(10))],
  });

  assert.equal(
    result.stderr,
    `Blocked. XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (Low) could not be checked, because the GitHub advisory lookup failed. Retry.\n` +
      "Vulnerability audit failed with 1 blocking finding(s).\n",
  );
  assert.equal(result.status, 1);
});

const badEntries = [
  ["a recheck date more than 30 days out", exception("XTwitterScraper.Tests", day(31)), 'needs a "recheck" date as YYYY-MM-DD, at most 30 days out.'],
  ["a recheck date that is no calendar day", exception("XTwitterScraper.Tests", "2026-02-30"), 'needs a "recheck" date as YYYY-MM-DD, at most 30 days out.'],
  ["an unknown reason", exception("XTwitterScraper.Tests", day(10), "low severity"), 'needs a "reason" of "build-time only" or "peer dependency provided by the host".'],
];

for (const [name, entry, message] of badEntries) {
  test(`an exception with ${name} excuses nothing`, (t) => {
    const result = audit(t, {
      findings: report("XTwitterScraper.Tests", "Low"),
      exceptions: [entry],
      advisories: { [advisory]: noFix },
    });

    assert.equal(
      result.stderr,
      `Blocked. audit-exceptions.json entry 1 ${message}\n` +
        `Blocked. XTwitterScraper.Tests > Example.Package 1.2.3 ${advisory} (Low) is not listed. Update it, or list it in audit-exceptions.json if no fix exists.\n` +
        "Vulnerability audit failed with 2 blocking finding(s).\n",
    );
    assert.equal(result.status, 1);
  });
}

test("a report without findings passes with an empty exceptions list", (t) => {
  const result = audit(t, {});

  assert.equal(result.stderr, "");
  assert.equal(
    result.stdout,
    "==> Auditing locked dependencies\n" +
      "Vulnerability audit passed with 0 reviewed exceptions.\n" +
      "==> Checking dependency license policy\n" +
      "Dependency license policy passed for 0 packages.\n" +
      "Dependency audit passed.\n",
  );
  assert.equal(result.status, 0);
});

test("an error from dotnet list package blocks", (t) => {
  const result = audit(t, {
    findings: { version: 1, problems: [{ level: "error", text: "The source did not answer." }], projects: [] },
  });

  assert.equal(
    result.stderr,
    "Blocked. dotnet list package reported an error. The source did not answer.\n" +
      "Vulnerability audit failed with 1 blocking finding(s).\n",
  );
  assert.equal(result.status, 1);
});
