// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Helpers for the tests that run this repository's scripts as a maintainer
// would. Each script runs in a throwaway folder. Its PATH holds fake commands
// in place of the tools that reach other systems, so no test can reach
// NuGet.org, GitHub or the Keychain.

import { spawnSync } from "node:child_process";
import fs from "node:fs";
import os from "node:os";
import path from "node:path";

export const root = path.resolve(import.meta.dirname, "..", "..");

// Tools that only read and write local files. Each gets a wrapper in the
// throwaway bin folder, wherever this machine installed it.
const localTools = ["bash", "git", "jq", "node", "tar", "unzip", "zip"];

function which(tool) {
  for (const directory of (process.env.PATH ?? "").split(path.delimiter)) {
    const candidate = path.join(directory, tool);
    if (fs.existsSync(candidate) && fs.statSync(candidate).isFile()) {
      return candidate;
    }
  }
  throw new Error(`${tool} is not on PATH. Install it first.`);
}

function writeFile(file, content, mode = 0o644) {
  fs.mkdirSync(path.dirname(file), { recursive: true });
  fs.writeFileSync(file, content);
  fs.chmodSync(file, mode);
}

// Builds a throwaway folder with an empty repository folder, a bin folder for
// fake commands and a logs folder that the fakes write to. The test removes
// it when it ends.
export function createSandbox(t) {
  const base = fs.mkdtempSync(path.join(fs.realpathSync(os.tmpdir()), "xquik-csharp-script-test."));
  t.after(() => fs.rmSync(base, { recursive: true, force: true }));

  const repo = path.join(base, "repo");
  const bin = path.join(base, "bin");
  const logs = path.join(base, "logs");
  for (const directory of [repo, bin, logs, path.join(base, "tmp"), path.join(base, "home")]) {
    fs.mkdirSync(directory);
  }
  for (const tool of localTools) {
    writeFile(path.join(bin, tool), `#!/bin/sh\nexec "${which(tool)}" "$@"\n`, 0o755);
  }

  const env = {
    FAKE_LOGS: logs,
    GIT_AUTHOR_EMAIL: "tester@example.com",
    GIT_AUTHOR_NAME: "Script Tester",
    GIT_COMMITTER_EMAIL: "tester@example.com",
    GIT_COMMITTER_NAME: "Script Tester",
    GIT_CONFIG_GLOBAL: "/dev/null",
    GIT_CONFIG_NOSYSTEM: "1",
    HOME: path.join(base, "home"),
    PATH: `${bin}:/usr/bin:/bin`,
    TMPDIR: path.join(base, "tmp"),
  };

  function run(command, args = [], extraEnv = {}) {
    const result = spawnSync(command, args, {
      cwd: repo,
      encoding: "utf8",
      env: { ...env, ...extraEnv },
      input: "",
    });
    if (result.error) {
      throw result.error;
    }
    return { status: result.status, stdout: result.stdout, stderr: result.stderr };
  }

  function git(...args) {
    const result = run("git", args);
    if (result.status !== 0) {
      throw new Error(`git ${args.join(" ")} failed. ${result.stderr}`);
    }
    return result.stdout.trim();
  }

  return {
    base,
    repo,
    run,
    git,
    // Writes a file into the throwaway repository.
    write: (file, content, mode) => writeFile(path.join(repo, file), content, mode),
    // Copies a file of this repository into the throwaway repository, with its mode.
    copy: (file) =>
      writeFile(
        path.join(repo, file),
        fs.readFileSync(path.join(root, file)),
        fs.statSync(path.join(root, file)).mode,
      ),
    // Puts a fake command on PATH.
    fake: (name, source) => writeFile(path.join(bin, name), source, 0o755),
    // Returns the lines a fake wrote to its log, or no lines when it never ran.
    log: (name) => {
      const file = path.join(logs, name);
      return fs.existsSync(file) ? fs.readFileSync(file, "utf8").split("\n").slice(0, -1) : [];
    },
    // Commits every file of the throwaway repository on main.
    commit: () => {
      git("init", "--quiet", "--initial-branch=main");
      git("add", "--all");
      git("commit", "--quiet", "--message", "Test commit");
    },
  };
}
