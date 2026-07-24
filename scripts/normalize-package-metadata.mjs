#!/usr/bin/env node

// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";
import path from "node:path";

const contentRoot = process.argv[2];
if (!contentRoot) {
  throw new Error("Usage: normalize-package-metadata.mjs <content-directory>");
}

const corePropertiesDirectory = path.join(
  contentRoot,
  "package",
  "services",
  "metadata",
  "core-properties",
);
const coreProperties = fs
  .readdirSync(corePropertiesDirectory)
  .filter((name) => name.endsWith(".psmdcp"));

if (coreProperties.length !== 1) {
  throw new Error(`Expected 1 core properties file, found ${coreProperties.length}.`);
}

const stableName = "core-properties.psmdcp";
fs.renameSync(
  path.join(corePropertiesDirectory, coreProperties[0]),
  path.join(corePropertiesDirectory, stableName),
);

const relationshipsPath = path.join(contentRoot, "_rels", ".rels");
const relationships = fs.readFileSync(relationshipsPath, "utf8");
const normalizedRelationships = relationships.replace(
  /(<Relationship Type="http:\/\/schemas\.openxmlformats\.org\/package\/2006\/relationships\/metadata\/core-properties" Target=")[^"]+(" Id=")[^"]+(" \/>)/,
  `$1/package/services/metadata/core-properties/${stableName}$2RCOREPROPERTIES$3`,
);

if (normalizedRelationships === relationships) {
  throw new Error("Core properties relationship was not normalized.");
}

fs.writeFileSync(relationshipsPath, normalizedRelationships);
