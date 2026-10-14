// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import assert from "node:assert/strict";
import { test } from "node:test";

import { createSandbox } from "./support.mjs";

const checkScripts = [
  "bootstrap",
  "lint",
  "test-scripts",
  "build",
  "test",
  "coverage",
  "audit",
  "check-reproducible",
  "codeql",
];

function stub(name) {
  const output = name === "test" ? 'echo "  succeeded: 12"\n' : "";
  return `#!/usr/bin/env bash\n${output}[[ "\${FAKE_FAILING_SCRIPT:-}" != "${name}" ]]\n`;
}

const recordingFake = (name) => `#!/bin/sh
printf '%s\\n' "$*" >>"$FAKE_LOGS/${name}"
`;

const passedLine =
  "Passed restore, lint, shellcheck, script tests, REUSE, build, 12 .NET 8 tests, coverage, audit, reproducible packages and CodeQL.";
const statuses = "api --method POST repos/Xquik-dev/x-twitter-scraper-csharp/statuses";

function checkLocal(t, { args = [], env = {}, withoutTools = [], dirty = false } = {}) {
  const sandbox = createSandbox(t);
  sandbox.copy("bin/check-local");
  for (const name of checkScripts) {
    sandbox.write(`scripts/${name}`, stub(name), 0o755);
  }
  for (const name of ["codeql", "dotnet", "gh", "reuse", "shellcheck", "uvx"]) {
    if (!withoutTools.includes(name)) {
      sandbox.fake(name, recordingFake(name));
    }
  }
  sandbox.commit();
  if (dirty) {
    sandbox.write("notes.txt", "An uncommitted file.\n");
  }
  const result = sandbox.run("bin/check-local", args, env);
  return { ...result, sandbox, head: sandbox.git("rev-parse", "HEAD") };
}

test("a passing run lists the checks that ran and runs REUSE 6.2.0 through uvx", (t) => {
  const result = checkLocal(t, { args: ["--no-status"] });

  assert.equal(result.stderr, "");
  assert.equal(result.stdout.split("\n").at(-2), passedLine);
  assert.equal(result.stdout.includes("Commit status not posted because --no-status was passed.\n"), true);
  assert.equal(result.status, 0);
  assert.deepEqual(result.sandbox.log("uvx"), ["--from reuse==6.2.0 reuse lint"]);
  assert.deepEqual(result.sandbox.log("reuse"), []);
  assert.deepEqual(result.sandbox.log("gh"), []);
});

test("a clean pushed HEAD gets a pending status, then a success status with the same list", (t) => {
  const result = checkLocal(t);

  assert.equal(result.status, 0);
  assert.deepEqual(result.sandbox.log("gh"), [
    `api repos/Xquik-dev/x-twitter-scraper-csharp/commits/${result.head}`,
    `${statuses}/${result.head} -f state=pending -f context=xquik-local-checks -f description=Local checks are running.`,
    `${statuses}/${result.head} -f state=success -f context=xquik-local-checks -f description=${passedLine}`,
  ]);
});

test("a working tree with changes gets no status", (t) => {
  const result = checkLocal(t, { dirty: true });

  assert.equal(result.stdout.includes("Commit status not posted because the working tree has changes.\n"), true);
  assert.equal(result.status, 0);
  assert.deepEqual(result.sandbox.log("gh"), []);
});

test("a run without uv stops, even when another reuse is installed", (t) => {
  const result = checkLocal(t, { withoutTools: ["uvx"] });

  assert.equal(result.stderr, "Check failed at Required tools. Install uv with brew install uv, then rerun.\n");
  assert.equal(result.status, 1);
  assert.deepEqual(result.sandbox.log("reuse"), []);
  assert.equal(
    result.sandbox.log("gh").at(-1),
    `${statuses}/${result.head} -f state=failure -f context=xquik-local-checks -f description=Failed at Required tools.`,
  );
});

test("a run without the CodeQL CLI stops with the install command", (t) => {
  const result = checkLocal(t, { args: ["--no-status"], withoutTools: ["codeql"] });

  assert.equal(
    result.stderr,
    "Check failed at Required tools. Install the CodeQL CLI with brew install --cask codeql, then rerun.\n",
  );
  assert.equal(result.status, 1);
});

test("a failing check stops the run and posts a failure status that names it", (t) => {
  const result = checkLocal(t, { env: { FAKE_FAILING_SCRIPT: "coverage" } });

  assert.equal(
    result.stderr,
    "Check failed at Coverage. Fix failing or skipped tests, or add tests to meet coverage, then rerun.\n",
  );
  assert.equal(result.stdout.includes("==> Dependency audit\n"), false);
  assert.equal(result.status, 1);
  assert.equal(
    result.sandbox.log("gh").at(-1),
    `${statuses}/${result.head} -f state=failure -f context=xquik-local-checks -f description=Failed at Coverage.`,
  );
});
