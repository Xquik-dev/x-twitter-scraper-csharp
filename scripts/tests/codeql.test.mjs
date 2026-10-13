// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Runs scripts/codeql in a throwaway repository with a fake CodeQL CLI.

import assert from "node:assert/strict";
import fs from "node:fs";
import path from "node:path";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const fakeCodeql = `#!/bin/sh
# Stands in for the CodeQL CLI. Like the real C# extractor, "database create" writes restore output
# into the folder it scans. "database analyze" writes the results the test names.
for argument in "$@"; do
  case "$argument" in
    --source-root=*) source_root="\${argument#--source-root=}" ;;
    --output=*) output="\${argument#--output=}" ;;
  esac
done
if [ "$2" = "create" ]; then
  (cd "$source_root" && find . -type f | sort) >"$FAKE_LOGS/scanned"
  mkdir -p "$source_root/src/XTwitterScraper/obj"
  echo "written by CodeQL" >"$source_root/src/XTwitterScraper/obj/project.assets.json"
else
  printf '%s' "$FAKE_CODEQL_RESULTS" >"$output"
fi
`;

const restoreOutput = "src/XTwitterScraper/obj/project.assets.json";

function codeql(t, results) {
  const sandbox = createSandbox(t);
  sandbox.copy("scripts/codeql");
  sandbox.write(".gitignore", "obj/\n");
  sandbox.write("src/XTwitterScraper/Client.cs", "class Client {}\n");
  sandbox.write(restoreOutput, "written by dotnet restore\n");
  sandbox.fake("codeql", fakeCodeql);
  sandbox.commit();
  const result = sandbox.run("scripts/codeql", [], { FAKE_CODEQL_RESULTS: results });
  return { ...result, sandbox };
}

test("CodeQL scans a copy of the source files and leaves the restore output of the working tree alone", (t) => {
  const result = codeql(t, "");

  assert.equal(result.stderr, "");
  assert.equal(result.status, 0);
  assert.deepEqual(result.sandbox.log("scanned"), [
    "./.gitignore",
    "./scripts/codeql",
    "./src/XTwitterScraper/Client.cs",
  ]);
  assert.equal(
    fs.readFileSync(path.join(result.sandbox.repo, restoreOutput), "utf8"),
    "written by dotnet restore\n",
  );
});

test("a CodeQL result fails the run and is printed", (t) => {
  const row = '"Hard-coded credential","A credential is in the source.","error","Fix it.","/src/XTwitterScraper/Client.cs","1","1","1","9"\n';
  const result = codeql(t, row);

  assert.equal(result.stderr, "CodeQL found the results above. Fix each one.\n");
  assert.equal(result.stdout.endsWith(row), true);
  assert.equal(result.status, 1);
});
