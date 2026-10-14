// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

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
