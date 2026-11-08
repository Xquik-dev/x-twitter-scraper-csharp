// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";
import path from "node:path";

globalThis.fetch = async (url) => {
  fs.appendFileSync(path.join(process.env.FAKE_LOGS, "spec-requests"), `${url}\n`);
  return new Response(process.env.FAKE_SPEC_BODY, { status: Number(process.env.FAKE_SPEC_STATUS) });
};
