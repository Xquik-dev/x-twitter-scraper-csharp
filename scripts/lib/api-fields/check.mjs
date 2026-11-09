// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import { CheckFailure, ReviewedList } from "./reviewed-list.mjs";
import { sdkShapes } from "./sdk.mjs";
import { differences } from "./shapes.mjs";
import { HTTP_METHODS, loadSpec, operationKey, specShapes, unexpectedSpec } from "./spec.mjs";

const METHOD = HTTP_METHODS.map((method) => method.toUpperCase()).join("|");
const ACCEPTED_FILE = "accepted-field-differences.json";
const EXCLUDED_FILE = "excluded-operations.json";

export const ACCEPTED = new ReviewedList({
  file: ACCEPTED_FILE,
  entry: "difference",
  section: "API fields",
  pattern: new RegExp(`^(${METHOD}) /\\S* (request|response) (missing|extra|enum|required|nullable) \\S+$`),
  example:
    "Write a method, a path, request or response, a kind and a field, such as " +
    "GET /api/v1/monitors response enum monitors[].eventTypes[].",
});
export const EXCLUDED = new ReviewedList({
  file: EXCLUDED_FILE,
  entry: "operation",
  section: "API fields",
  pattern: new RegExp(`^(${METHOD}) /\\S*$`),
  example: "Write a method and a path, such as GET /api/v1/api-keys.",
});

const count = (number, noun) => `${number} ${noun}${number === 1 ? "" : "s"}`;

function readSpec(document, source) {
  try {
    return specShapes(document);
  } catch (error) {
    if (error instanceof TypeError) {
      throw unexpectedSpec(source);
    }
    throw error;
  }
}

function readSdk(root) {
  const { shapes, problems } = sdkShapes(root);
  if (problems.length > 0) {
    throw new CheckFailure(
      ...problems,
      "Write each line above in the style of the generated code, or teach scripts/lib/api-fields/sdk.mjs the new form.",
    );
  }
  return shapes;
}

function staleExclusions(excluded, spec) {
  return [...excluded]
    .filter((entry) => !spec.has(operationKey(...splitOperation(entry))))
    .map((entry) => `${EXCLUDED_FILE} lists ${entry}, which the API no longer has. Remove it.`);
}

function splitOperation(entry) {
  const separator = entry.indexOf(" ");
  return [entry.slice(0, separator), entry.slice(separator + 1)];
}

export async function check(root, source) {
  const accepted = ACCEPTED.read(root);
  const excluded = EXCLUDED.read(root);
  const spec = readSpec(await loadSpec(source), source);
  const sdk = readSdk(root);
  const skipped = new Set([...excluded].map((entry) => operationKey(...splitOperation(entry))));
  const compared = [...spec.keys()].filter((key) => sdk.has(key) && !skipped.has(key));
  const found = new Set(
    compared.flatMap((key) =>
      differences(spec.get(key).shape, sdk.get(key)).map(
        ({ side, kind, path }) => `${spec.get(key).label} ${side} ${kind} ${path}`,
      ),
    ),
  );
  const unaccepted = [...found].filter((line) => !accepted.has(line)).sort();
  const stale = [
    ...[...accepted]
      .filter((line) => !found.has(line))
      .map((line) => `${ACCEPTED_FILE} lists ${line}, which the check no longer finds. Remove it.`),
    ...staleExclusions(excluded, spec),
  ];
  if (unaccepted.length > 0) {
    throw new CheckFailure(
      ...unaccepted,
      ...stale,
      `Fix each field above in the SDK, or list it in ${ACCEPTED_FILE} with a reason.`,
    );
  }
  if (stale.length > 0) {
    throw new CheckFailure(...stale, "Remove each entry above from its file.");
  }
  return (
    `The SDK's fields match the API for ${count(compared.length, "operation")}, ` +
    `and ${ACCEPTED_FILE} lists ${count(accepted.size, "accepted difference")}.`
  );
}
