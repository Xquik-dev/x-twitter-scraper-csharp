// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

// Stands in for GitHub's advisory API in the audit tests. Node loads it before
// the audit script. It records each lookup and answers from FAKE_ADVISORIES,
// a JSON object keyed by advisory ID. An advisory it does not hold gets a 404.

import fs from "node:fs";
import path from "node:path";

const advisories = JSON.parse(process.env.FAKE_ADVISORIES ?? "{}");

globalThis.fetch = async (url) => {
  fs.appendFileSync(path.join(process.env.FAKE_LOGS, "advisories"), `${url}\n`);
  const advisory = advisories[String(url).split("/").pop()];
  return advisory
    ? new Response(JSON.stringify(advisory), { status: 200 })
    : new Response("{}", { status: 404 });
};
