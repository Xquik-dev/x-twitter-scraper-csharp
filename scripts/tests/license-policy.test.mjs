// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Runs scripts/verify-package-licenses.mjs in a throwaway folder. The report
// has the shape of "dotnet list package --format json", and a throwaway
// package folder holds the nuspec of each package the report names.

import assert from "node:assert/strict";
import path from "node:path";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const mit = '<license type="expression">MIT</license>';
const otherTerms = "<licenseUrl>https://example.com/terms</licenseUrl>";

// A report where the library resolves one version of a package and the tests resolve another.
function report(libraryVersion, testsVersion) {
  return {
    version: 1,
    projects: [
      {
        path: "/work/src/XTwitterScraper/XTwitterScraper.csproj",
        frameworks: [
          {
            framework: "netstandard2.0",
            transitivePackages: [{ id: "Example.Package", resolvedVersion: libraryVersion }],
          },
        ],
      },
      {
        path: "/work/src/XTwitterScraper.Tests/XTwitterScraper.Tests.csproj",
        frameworks: [
          {
            framework: "net8.0",
            transitivePackages: [{ id: "Example.Package", resolvedVersion: testsVersion }],
          },
        ],
      },
    ],
  };
}

function checkLicenses(t, findings, licenses) {
  const sandbox = createSandbox(t);
  sandbox.copy("scripts/verify-package-licenses.mjs");
  sandbox.write("report.json", JSON.stringify(findings));
  for (const [version, license] of Object.entries(licenses)) {
    sandbox.write(
      `packages/example.package/${version}/example.package.nuspec`,
      `<package><metadata><id>Example.Package</id>${license}</metadata></package>\n`,
    );
  }
  return sandbox.run("node", ["scripts/verify-package-licenses.mjs", "report.json"], {
    NUGET_PACKAGES: path.join(sandbox.repo, "packages"),
  });
}

test("2 versions of a package under an approved license pass as 2 packages", (t) => {
  const result = checkLicenses(t, report("1.1.0", "5.0.0"), { "1.1.0": mit, "5.0.0": mit });

  assert.equal(result.stderr, "");
  assert.equal(result.stdout, "Dependency license policy passed for 2 packages.\n");
  assert.equal(result.status, 0);
});

test("an older version under other terms blocks, even when a newer version is approved", (t) => {
  const result = checkLicenses(t, report("1.1.0", "5.0.0"), { "1.1.0": otherTerms, "5.0.0": mit });

  assert.match(
    result.stderr,
    /Dependency licenses failed policy\. Use approved licenses\.\nExample\.Package@1\.1\.0 has https:\/\/example\.com\/terms\n/,
  );
  assert.equal(result.stdout, "");
  assert.equal(result.status, 1);
});
