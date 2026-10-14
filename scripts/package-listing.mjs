#!/usr/bin/env node

// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";

const [nuspecPath, expectedId, expectedVersion] = process.argv.slice(2);
if (!nuspecPath || !expectedId || !expectedVersion) {
  console.error("Run package-listing.mjs <file.nuspec> <package-id> <version>.");
  process.exit(2);
}

const nuspec = fs.readFileSync(nuspecPath, "utf8");
const entities = { amp: "&", apos: "'", gt: ">", lt: "<", quot: '"' };

function decode(text) {
  return text
    .replace(/&#x([0-9a-f]+);/gi, (_, code) => String.fromCodePoint(Number.parseInt(code, 16)))
    .replace(/&#(\d+);/g, (_, code) => String.fromCodePoint(Number(code)))
    .replace(/&(amp|apos|gt|lt|quot);/g, (_, name) => entities[name]);
}

function element(name) {
  const match = nuspec.match(new RegExp(`<${name}(?:\\s[^>]*)?>([\\s\\S]*?)</${name}>`));
  return match ? decode(match[1]).trim() : "";
}

function repositoryUrl() {
  const repository = nuspec.match(/<repository\s[^>]*>/)?.[0] ?? "";
  return decode(repository.match(/\surl="([^"]*)"/)?.[1] ?? "");
}

const id = element("id");
const version = element("version");
const fields = [
  ["Package ID", id],
  ["Version", version],
  ["Authors", element("authors")],
  ["Description", element("description")],
  ["Tags", element("tags")],
  ["Project URL", element("projectUrl")],
  ["Repository URL", repositoryUrl()],
  ["License", element("license") || element("licenseUrl")],
  ["Readme", element("readme")],
  ["Icon", element("icon")],
];

const width = Math.max(...fields.map(([label]) => label.length));
for (const [label, value] of fields) {
  console.log(`${label.padEnd(width)}  ${value || "(not set)"}`);
}

if (id !== expectedId || version !== expectedVersion) {
  console.error(
    `The package is ${id || "(no id)"} ${version || "(no version)"}, not ${expectedId} ${expectedVersion}. Check the build output.`,
  );
  process.exit(1);
}
