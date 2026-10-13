// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Runs bin/release-local in a throwaway repository whose origin is a local
// bare repository. Stubs stand in for the checks and the package build. Fake
// commands stand in for curl, dotnet, the GitHub CLI and the macOS Keychain,
// so no test can reach NuGet.org, GitHub or a real Keychain item.

import assert from "node:assert/strict";
import fs from "node:fs";
import path from "node:path";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const fakes = {
  curl: `#!/bin/sh
# Stands in for curl. It answers the NuGet.org version lookup with the versions the test names.
for argument in "$@"; do url="$argument"; done
printf '%s\\n' "$url" >>"$FAKE_LOGS/curl"
printf '{"versions":[%s]}' "$FAKE_NUGET_VERSIONS"
`,
  dotnet: `#!/bin/sh
# Stands in for "dotnet nuget push". It records the call, with the package path cut to its file name.
line=""
for argument in "$@"; do
  case "$argument" in */*.nupkg) argument="\${argument##*/}" ;; esac
  line="$line $argument"
done
printf '%s\\n' "\${line# }" >>"$FAKE_LOGS/dotnet"
`,
  gh: `#!/bin/sh
# Stands in for the GitHub CLI. It is signed in and has no draft release. It records each other
# release call, with the package path cut to its file name, and keeps a copy of the notes.
[ "$1" = "release" ] || exit 0
[ "$2" = "list" ] && exit 0
line=""
previous=""
for argument in "$@"; do
  case "$argument" in */*.nupkg) argument="\${argument##*/}" ;; esac
  if [ "$previous" = "--notes-file" ]; then
    cp "$argument" "$FAKE_LOGS/notes"
    argument="NOTES"
  fi
  line="$line $argument"
  previous="$argument"
done
printf '%s\\n' "\${line# }" >>"$FAKE_LOGS/gh"
`,
  security: `#!/bin/sh
# Stands in for the macOS Keychain. It holds 1 item, under the service "example-service".
printf '%s\\n' "$*" >>"$FAKE_LOGS/security"
case "$*" in
  "find-generic-password -s example-service") exit 0 ;;
  "find-generic-password -s example-service -w") echo "not-a-real-api-key" ;;
  *) exit 44 ;;
esac
`,
};

const stubs = {
  "bin/check-local": '#!/bin/sh\n# Stands in for bin/check-local.\necho ran >>"$FAKE_LOGS/check-local"\n',
  "scripts/audit": '#!/bin/sh\n# Stands in for scripts/audit.\necho ran >>"$FAKE_LOGS/audit"\n',
  "scripts/build-package": `#!/bin/sh
# Stands in for the package build. It zips the fixture package content into both packages.
mkdir -p "$1"
output="$(cd "$1" && pwd)"
(cd "$FAKE_PACKAGE_CONTENT" && zip -q -r -D "$output/XTwitterScraper.$2.nupkg" .) || exit 1
cp "$output/XTwitterScraper.$2.nupkg" "$output/XTwitterScraper.$2.symbols.nupkg"
`,
};

const nuspec = `<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata>
    <id>XTwitterScraper</id>
    <version>9.9.9</version>
    <authors>Example Author</authors>
    <license type="expression">Apache-2.0</license>
    <licenseUrl>https://licenses.nuget.org/Apache-2.0</licenseUrl>
    <readme>README.md</readme>
    <projectUrl>https://example.com/</projectUrl>
    <description>Search &amp; export &lt;tweets&gt;.</description>
    <tags>first-tag second-tag</tags>
    <repository type="git" url="https://example.com/source" commit="abc" />
  </metadata>
</package>
`;

const keychainLine =
  "NUGET_KEYCHAIN_SERVICE is unset or empty. Set it to the Keychain service that holds the NuGet API key, then run bin/release-local again.\n";
const listing = `==> Reading the listing from XTwitterScraper.9.9.9.nupkg
Package ID      XTwitterScraper
Version         9.9.9
Authors         Example Author
Description     Search & export <tweets>.
Tags            first-tag second-tag
Project URL     https://example.com/
Repository URL  https://example.com/source
License         Apache-2.0
Readme          README.md
Icon            (not set)
`;
const dryRunEnd = `${listing}==> Listing the files that XTwitterScraper 9.9.9 would publish
XTwitterScraper.9.9.9.nupkg holds 3 files.
README.md
XTwitterScraper.nuspec
lib/net8.0/XTwitterScraper.dll
XTwitterScraper.9.9.9.symbols.nupkg holds 3 files.
README.md
XTwitterScraper.nuspec
lib/net8.0/XTwitterScraper.dll
Dry run finished. Nothing was published, tagged or released.
`;
const push =
  "nuget push XTwitterScraper.9.9.9.nupkg --api-key not-a-real-api-key --skip-duplicate --source https://api.nuget.org/v3/index.json";
const release =
  "release create v9.9.9 XTwitterScraper.9.9.9.nupkg --repo Xquik-dev/x-twitter-scraper-csharp --title v9.9.9 --notes-file NOTES --verify-tag --latest";

function releaseLocal(t, { args = [], env = {}, published = '"9.9.8"' } = {}) {
  const sandbox = createSandbox(t);
  sandbox.copy("bin/release-local");
  sandbox.copy("scripts/package-listing.mjs");
  for (const [file, source] of Object.entries(stubs)) {
    sandbox.write(file, source, 0o755);
  }
  for (const [name, source] of Object.entries(fakes)) {
    sandbox.fake(name, source);
  }
  sandbox.write(
    "src/XTwitterScraper/XTwitterScraper.csproj",
    "<Project>\n  <PropertyGroup>\n    <VersionPrefix>9.9.9</VersionPrefix>\n  </PropertyGroup>\n</Project>\n",
  );
  sandbox.write(".release-please-manifest.json", '{ ".": "9.9.9" }\n');
  sandbox.write("CHANGELOG.md", "# Changelog\n\n## 9.9.9 (2026-01-01)\n\n* Add the first note.\n\n## 9.9.8 (2025-12-01)\n\n* Older note.\n");

  const content = path.join(sandbox.base, "package-content");
  fs.mkdirSync(path.join(content, "lib", "net8.0"), { recursive: true });
  fs.writeFileSync(path.join(content, "XTwitterScraper.nuspec"), nuspec);
  fs.writeFileSync(path.join(content, "README.md"), "# Example\n");
  fs.writeFileSync(path.join(content, "lib", "net8.0", "XTwitterScraper.dll"), "not a real assembly\n");

  const origin = path.join(sandbox.base, "origin.git");
  sandbox.commit();
  sandbox.git("init", "--quiet", "--bare", origin);
  sandbox.git("remote", "add", "origin", origin);
  sandbox.git("push", "--quiet", "origin", "main");

  const result = sandbox.run("bin/release-local", args, {
    FAKE_NUGET_VERSIONS: published,
    FAKE_PACKAGE_CONTENT: content,
    ...env,
  });
  const tags = sandbox.git("ls-remote", "--tags", "origin");
  return {
    ...result,
    sandbox,
    tags: tags === "" ? [] : tags.split("\n").map((line) => line.split("\t")[1]),
  };
}

function assertNothingReleased(result) {
  assert.deepEqual(result.tags, []);
  assert.deepEqual(result.sandbox.log("dotnet"), []);
  assert.deepEqual(result.sandbox.log("gh"), []);
}

for (const [name, env] of [
  ["unset", {}],
  ["empty", { NUGET_KEYCHAIN_SERVICE: "" }],
]) {
  test(`a release stops at once with 1 line when NUGET_KEYCHAIN_SERVICE is ${name}`, (t) => {
    const result = releaseLocal(t, { env });

    assert.deepEqual(
      { status: result.status, stdout: result.stdout, stderr: result.stderr },
      { status: 1, stdout: "", stderr: keychainLine },
    );
    assert.deepEqual(result.sandbox.log("check-local"), []);
    assertNothingReleased(result);
  });
}

test("a dry run needs no Keychain variable, prints the listing and the files, and releases nothing", (t) => {
  const result = releaseLocal(t, { args: ["--dry-run"] });

  assert.equal(result.stderr, "");
  assert.equal(result.stdout.endsWith(dryRunEnd), true, result.stdout);
  assert.equal(result.stdout.includes("NuGet.org does not have XTwitterScraper 9.9.9 yet. A release uploads it.\n"), true);
  assert.equal(result.status, 0);
  assert.deepEqual(result.sandbox.log("check-local"), ["ran"]);
  assert.deepEqual(result.sandbox.log("audit"), ["ran"]);
  assert.deepEqual(result.sandbox.log("security"), []);
  assertNothingReleased(result);
});

test("a release uploads the package with the Keychain key, then tags and releases it", (t) => {
  const result = releaseLocal(t, { env: { NUGET_KEYCHAIN_SERVICE: "example-service" } });

  assert.equal(result.status, 0);
  assert.equal(result.stdout.includes(listing), true, result.stdout);
  assert.equal(result.stdout.endsWith("Released XTwitterScraper 9.9.9.\n"), true);
  assert.equal(`${result.stdout}${result.stderr}`.includes("not-a-real-api-key"), false);
  assert.deepEqual(result.sandbox.log("check-local"), ["ran"]);
  assert.deepEqual(result.sandbox.log("dotnet"), [push]);
  assert.deepEqual(result.tags, ["refs/tags/v9.9.9", "refs/tags/v9.9.9^{}"]);
  assert.deepEqual(result.sandbox.log("gh"), [release]);
  assert.deepEqual(result.sandbox.log("notes"), ["", "* Add the first note.", ""]);
  assert.deepEqual(result.sandbox.log("curl"), ["https://api.nuget.org/v3-flatcontainer/xtwitterscraper/index.json"]);
});

test("a release skips the upload when NuGet.org already has the version", (t) => {
  const result = releaseLocal(t, {
    env: { NUGET_KEYCHAIN_SERVICE: "example-service" },
    published: '"9.9.8","9.9.9"',
  });

  assert.equal(result.status, 0);
  assert.equal(
    result.stdout.includes("==> Skipping the NuGet upload because NuGet.org already has XTwitterScraper 9.9.9\n"),
    true,
  );
  assert.deepEqual(result.sandbox.log("dotnet"), []);
  assert.deepEqual(result.sandbox.log("security"), []);
  assert.deepEqual(result.tags, ["refs/tags/v9.9.9", "refs/tags/v9.9.9^{}"]);
  assert.deepEqual(result.sandbox.log("gh"), [release]);
});

test("a release stops before the checks when the Keychain has no item under the named service", (t) => {
  const result = releaseLocal(t, { env: { NUGET_KEYCHAIN_SERVICE: "another-service" } });

  assert.equal(
    result.stderr,
    'The Keychain has no item under the service that NUGET_KEYCHAIN_SERVICE names. Add the NuGet API key with security add-generic-password -s "$NUGET_KEYCHAIN_SERVICE" -a "$USER" -w, then rerun.\n',
  );
  assert.equal(result.status, 1);
  assert.deepEqual(result.sandbox.log("check-local"), []);
  assertNothingReleased(result);
});
