// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import { check } from "./check.mjs";
import { CheckFailure } from "./reviewed-list.mjs";
import { specSource } from "./spec.mjs";

try {
  console.log(await check(process.cwd(), specSource()));
} catch (error) {
  if (!(error instanceof CheckFailure)) {
    throw error;
  }
  console.error(error.lines.join("\n"));
  process.exitCode = 1;
}
