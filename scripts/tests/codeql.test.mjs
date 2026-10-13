// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Runs scripts/codeql in a throwaway repository with a fake CodeQL CLI.

import assert from "node:assert/strict";
import fs from "node:fs";
import path from "node:path";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const fakeCodeql = `#!/bin/sh
# Stands in for the CodeQL CLI. Like the real traced build, "database create" writes build output
# into the folder it scans, and it records how it was asked to build. "database analyze" writes the
# SARIF report the test names, with COPY standing for the scanned folder.
for argument in "$@"; do
  case "$argument" in
    --source-root=*) source_root="\${argument#--source-root=}" ;;
    --output=*) output="\${argument#--output=}" ;;
    --build-mode=*|--command=*) echo "$argument" >>"$FAKE_LOGS/build" ;;
  esac
done
if [ "$2" = "create" ]; then
  (cd "$source_root" && find . -type f | sort) >"$FAKE_LOGS/scanned"
  echo "$source_root" >"$FAKE_LOGS/source-root"
  echo "DOTNET_ROLL_FORWARD=$DOTNET_ROLL_FORWARD" >>"$FAKE_LOGS/build"
  mkdir -p "$source_root/src/XTwitterScraper/obj"
  echo "written by CodeQL" >"$source_root/src/XTwitterScraper/obj/project.assets.json"
else
  printf '%s' "$FAKE_CODEQL_REPORT" | sed "s|COPY/|$(cat "$FAKE_LOGS/source-root")/|g" >"$output"
fi
`;

// Stands in for the .NET CLI. It records the folder and the arguments of each call.
const fakeDotnet = `#!/bin/sh
echo "$(pwd -P) $*" >>"$FAKE_LOGS/dotnet"
`;

const diagnostics = ["cs/diagnostics/extraction-errors", "cs/compilation-error", "cs/extraction-error"];

// A compiler error as CodeQL 2.27 reports it in its SARIF report.
function compilerError(file, line, text) {
  return {
    locations: [{ physicalLocation: { artifactLocation: { uri: file }, region: { startLine: line } } }],
    message: { text },
    level: "none",
    descriptor: { id: "cs/compilation-error" },
  };
}

// A SARIF report in the shape CodeQL 2.27 writes. "ran" names the diagnostic queries that ran,
// "notifications" holds what they reported, and "results" the results.
function report({ ran = diagnostics, notifications = [], results = [] } = {}) {
  return JSON.stringify({
    runs: [
      {
        tool: { driver: { name: "CodeQL", notifications: ran.map((id) => ({ id })) } },
        invocations: [{ toolExecutionNotifications: notifications, executionSuccessful: true }],
        results,
      },
    ],
  });
}

const restoreOutput = "src/XTwitterScraper/obj/project.assets.json";

function codeql(t, sarif) {
  const sandbox = createSandbox(t);
  sandbox.copy("scripts/codeql");
  sandbox.write(".gitignore", "obj/\n");
  sandbox.write("src/XTwitterScraper/Client.cs", "class Client {}\n");
  sandbox.write(restoreOutput, "written by dotnet restore\n");
  sandbox.fake("codeql", fakeCodeql);
  sandbox.fake("dotnet", fakeDotnet);
  sandbox.commit();
  const result = sandbox.run("scripts/codeql", [], { FAKE_CODEQL_REPORT: sarif });
  return { ...result, sandbox };
}

test("CodeQL scans a copy of the source files and leaves the restore output of the working tree alone", (t) => {
  const result = codeql(t, report());

  assert.equal(result.stderr, "");
  assert.equal(result.status, 0);
  assert.equal(result.stdout.endsWith("CodeQL found no results.\n"), true);
  const copy = result.sandbox.log("source-root")[0];
  assert.deepEqual(result.sandbox.log("dotnet"), [`${copy} restore --locked-mode`]);
  assert.deepEqual(result.sandbox.log("build"), [
    "--build-mode=manual",
    "--command=dotnet build XTwitterScraper.sln --no-restore -p:UseSharedCompilation=false",
    "DOTNET_ROLL_FORWARD=Major",
  ]);
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
  const result = codeql(
    t,
    report({
      results: [
        {
          ruleId: "cs/hardcoded-credentials",
          message: { text: "A credential is in the source." },
          locations: [
            { physicalLocation: { artifactLocation: { uri: "src/XTwitterScraper/Client.cs" }, region: { startLine: 9 } } },
          ],
        },
      ],
    }),
  );

  assert.equal(result.stderr, "CodeQL found the results above. Fix each one.\n");
  assert.equal(
    result.stdout.endsWith("cs/hardcoded-credentials at src/XTwitterScraper/Client.cs:9. A credential is in the source.\n"),
    true,
  );
  assert.equal(result.status, 1);
});

test("a file that CodeQL could not read fails the run and is named", (t) => {
  const result = codeql(
    t,
    report({
      notifications: [
        compilerError("src/XTwitterScraper/Client.cs", 5, "Error CS1001 Identifier expected"),
        compilerError("src/XTwitterScraper/Client.cs", 5, "Error CS1026 ) expected"),
        {
          message: { text: "Compiler error in COPY/src/XTwitterScraper/Client.cs: " },
          level: "error",
          descriptor: { id: "cs/diagnostics/extraction-errors" },
        },
      ],
    }),
  );

  assert.equal(
    result.stderr,
    "src/XTwitterScraper/Client.cs at line 5. Error CS1001 Identifier expected\n" +
      "src/XTwitterScraper/Client.cs at line 5. Error CS1026 ) expected\n" +
      "Compiler error in src/XTwitterScraper/Client.cs: \n" +
      "CodeQL could not read the C# code above, so the scan is incomplete. Fix that code so it compiles, then rerun.\n",
  );
  assert.equal(result.status, 1);
});

test("a reference error that a traced build would resolve also fails the run", (t) => {
  const result = codeql(
    t,
    report({
      notifications: [
        compilerError("src/XTwitterScraper/Core/ApiEnum.cs", 109, "Error CS0117 'JsonElement' does not contain a definition for 'DeepEquals'"),
      ],
    }),
  );

  assert.equal(
    result.stderr,
    "src/XTwitterScraper/Core/ApiEnum.cs at line 109. Error CS0117 'JsonElement' does not contain a definition for 'DeepEquals'\n" +
      "CodeQL could not read the C# code above, so the scan is incomplete. Fix that code so it compiles, then rerun.\n",
  );
  assert.equal(result.status, 1);
});

test("a scan without the extraction diagnostics fails the run", (t) => {
  const result = codeql(t, report({ ran: ["cs/diagnostics/successfully-extracted-files"] }));

  assert.equal(
    result.stderr,
    "The CodeQL scan lacks cs/diagnostics/extraction-errors and cs/compilation-error and cs/extraction-error, so it cannot show that it read every file. Make the suite in scripts/codeql run each missing diagnostic query.\n",
  );
  assert.equal(result.status, 1);
});
