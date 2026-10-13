#!/usr/bin/env node

// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Fails on every vulnerable package in the shipped library, and on every
// test-only finding unless audit-exceptions.json lists it and no fix exists.
// Severity never excuses a finding. A listed finding blocks again on its
// recheck date, and as soon as a fixed version exists.

import fs from "node:fs";
import path from "node:path";

const [reportPath, exceptionsPath] = process.argv.slice(2);
if (!reportPath || !exceptionsPath) {
  console.error(
    "Run verify-vulnerabilities.mjs <vulnerability-report.json> <audit-exceptions.json>.",
  );
  process.exit(2);
}

const shippedProjects = new Set(["XTwitterScraper"]);
const allowedReasons = new Set([
  "build-time only",
  "peer dependency provided by the host",
]);
const maxRecheckDays = 30;
const dayInMilliseconds = 86_400_000;
const today = Date.parse(`${new Date().toISOString().slice(0, 10)}T00:00:00Z`);
const failures = [];

function parseDay(value) {
  if (typeof value !== "string" || !/^\d{4}-\d{2}-\d{2}$/.test(value)) {
    return Number.NaN;
  }
  const time = Date.parse(`${value}T00:00:00Z`);
  if (Number.isNaN(time) || new Date(time).toISOString().slice(0, 10) !== value) {
    return Number.NaN;
  }
  return time;
}

function readExceptions() {
  const entries = JSON.parse(fs.readFileSync(exceptionsPath, "utf8"));
  if (!Array.isArray(entries)) {
    failures.push(`${exceptionsPath} must hold a JSON array.`);
    return new Map();
  }

  const exceptions = new Map();
  for (const [index, entry] of entries.entries()) {
    const label = `${exceptionsPath} entry ${index + 1}`;
    const recheckTime = parseDay(entry?.recheck);
    if (!/^GHSA-[0-9a-z]{4}-[0-9a-z]{4}-[0-9a-z]{4}$/.test(entry?.advisory ?? "")) {
      failures.push(`${label} needs an "advisory" like GHSA-xxxx-xxxx-xxxx.`);
    } else if (typeof entry.package !== "string" || !entry.package.includes(" > ")) {
      failures.push(`${label} needs a "package" like "<project> > <package id>".`);
    } else if (!allowedReasons.has(entry.reason)) {
      failures.push(`${label} needs a "reason" of "${[...allowedReasons].join('" or "')}".`);
    } else if (
      Number.isNaN(recheckTime) ||
      recheckTime > today + maxRecheckDays * dayInMilliseconds
    ) {
      failures.push(
        `${label} needs a "recheck" date as YYYY-MM-DD, at most ${maxRecheckDays} days out.`,
      );
    } else {
      exceptions.set(`${entry.package}|${entry.advisory}`, { ...entry, recheckTime });
    }
  }
  return exceptions;
}

function readFindings() {
  const report = JSON.parse(fs.readFileSync(reportPath, "utf8"));
  for (const problem of report.problems ?? []) {
    if (problem.level === "error") {
      failures.push(`dotnet list package reported an error. ${problem.text}`);
    }
  }

  const findings = new Map();
  for (const project of report.projects ?? []) {
    const projectName = path.basename(project.path ?? "", ".csproj");
    for (const framework of project.frameworks ?? []) {
      for (const group of ["topLevelPackages", "transitivePackages"]) {
        for (const dependency of framework[group] ?? []) {
          for (const vulnerability of dependency.vulnerabilities ?? []) {
            const advisory = String(vulnerability.advisoryurl ?? "").split("/").pop() || "unknown";
            const packagePath = `${projectName} > ${dependency.id}`;
            findings.set(`${packagePath}|${advisory}`, {
              advisory,
              packageId: dependency.id,
              packagePath,
              projectName,
              summary: `${packagePath} ${dependency.resolvedVersion} ${advisory} (${vulnerability.severity})`,
            });
          }
        }
      }
    }
  }
  return findings;
}

async function fixState(finding) {
  try {
    const response = await fetch(`https://api.github.com/advisories/${finding.advisory}`, {
      headers: { Accept: "application/vnd.github+json" },
      signal: AbortSignal.timeout(30_000),
    });
    if (!response.ok) {
      return "unknown";
    }
    const advisory = await response.json();
    const fixed = (advisory.vulnerabilities ?? []).some(
      (vulnerability) =>
        vulnerability.package?.ecosystem === "nuget" &&
        vulnerability.package?.name?.toLowerCase() === finding.packageId.toLowerCase() &&
        Boolean(vulnerability.first_patched_version),
    );
    return fixed ? "fixed" : "unfixed";
  } catch {
    return "unknown";
  }
}

const exceptions = readExceptions();
const findings = readFindings();
let accepted = 0;

for (const [key, finding] of findings) {
  const exception = exceptions.get(key);
  if (shippedProjects.has(finding.projectName)) {
    failures.push(`${finding.summary} is in the shipped package. Update it.`);
  } else if (!exception) {
    failures.push(
      `${finding.summary} is not listed. Update it, or list it in ${exceptionsPath} if no fix exists.`,
    );
  } else if (today >= exception.recheckTime) {
    failures.push(`${finding.summary} has an exception that expired on ${exception.recheck}. Recheck it.`);
  } else {
    const state = await fixState(finding);
    if (state === "fixed") {
      failures.push(`${finding.summary} has a fixed version. Update it, then remove its exception.`);
    } else if (state === "unknown") {
      failures.push(`${finding.summary} could not be checked, because the GitHub advisory lookup failed. Retry.`);
    } else {
      accepted += 1;
      console.log(
        `Accepted the reviewed exception for ${finding.summary}. It is ${exception.reason}. Recheck by ${exception.recheck}.`,
      );
    }
  }
}

for (const [key, exception] of exceptions) {
  if (!findings.has(key)) {
    console.log(
      `${exceptionsPath} lists ${exception.advisory} for ${exception.package}, which no longer applies. Remove it.`,
    );
  }
}

if (failures.length > 0) {
  for (const failure of failures) {
    console.error(`Blocked. ${failure}`);
  }
  console.error(`Vulnerability audit failed with ${failures.length} blocking finding(s).`);
  process.exit(1);
}

console.log(
  `Vulnerability audit passed with ${accepted} reviewed exception${accepted === 1 ? "" : "s"}.`,
);
