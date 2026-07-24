#!/usr/bin/env node

// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";
import os from "node:os";
import path from "node:path";

const reportPath = process.argv[2];
if (!reportPath) {
  throw new Error("Usage: verify-package-licenses.mjs <package-report.json>");
}

const allowedExpressions = new Set(["Apache-2.0", "BSD-3-Clause", "MIT"]);
const allowedLegacyUrls = new Set([
  "https://github.com/Microsoft/dotnet/blob/master/LICENSE",
  "https://github.com/dotnet/standard/blob/master/LICENSE.TXT",
]);
const report = JSON.parse(fs.readFileSync(reportPath, "utf8"));
const packages = new Map();

for (const project of report.projects ?? []) {
  for (const framework of project.frameworks ?? []) {
    for (const group of ["topLevelPackages", "transitivePackages"]) {
      for (const dependency of framework[group] ?? []) {
        packages.set(dependency.id.toLowerCase(), dependency);
      }
    }
  }
}

const packageRoot =
  process.env.NUGET_PACKAGES ?? path.join(os.homedir(), ".nuget", "packages");
const failures = [];

for (const [lowerId, dependency] of [...packages].sort(([left], [right]) =>
  left.localeCompare(right),
)) {
  const version = dependency.resolvedVersion;
  const nuspecPath = path.join(
    packageRoot,
    lowerId,
    version,
    `${lowerId}.nuspec`,
  );
  const nuspec = fs.readFileSync(nuspecPath, "utf8");
  const expression = nuspec.match(
    /<license\s+type="expression">([^<]+)<\/license>/i,
  )?.[1];
  const legacyUrl = nuspec.match(/<licenseUrl>([^<]+)<\/licenseUrl>/i)?.[1];

  if (expression && allowedExpressions.has(expression)) {
    continue;
  }
  if (legacyUrl && allowedLegacyUrls.has(legacyUrl)) {
    continue;
  }

  failures.push(
    `${dependency.id}@${version}: ${expression ?? legacyUrl ?? "missing license"}`,
  );
}

if (failures.length > 0) {
  throw new Error(`Disallowed dependency licenses:\n${failures.join("\n")}`);
}

console.log(`Dependency license policy passed for ${packages.size} packages.`);
