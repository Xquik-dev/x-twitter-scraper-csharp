// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";
import path from "node:path";

export class CheckFailure extends Error {
  constructor(...lines) {
    super(lines.join("\n"));
    this.lines = lines;
  }
}

const isObject = (value) => typeof value === "object" && value !== null && !Array.isArray(value);

export class ReviewedList {
  constructor({ file, entry, section, pattern, example }) {
    Object.assign(this, { file, entry, section, pattern, example });
  }

  invalid(problem) {
    return new CheckFailure(
      `${this.file} is not valid. ${problem}`,
      `Fix ${this.file} in the format CONTRIBUTING.md shows under ${this.section}.`,
    );
  }

  parse(root) {
    let text;
    try {
      text = fs.readFileSync(path.join(root, this.file), "utf8");
    } catch {
      throw this.invalid("The file cannot be read.");
    }
    try {
      return JSON.parse(text);
    } catch (error) {
      throw this.invalid(`Its text breaks the JSON syntax. ${error.message}`);
    }
  }

  read(root) {
    const groups = this.parse(root);
    if (!Array.isArray(groups)) {
      throw this.invalid(`It must be a list of groups, each with a reason and ${this.entry}s.`);
    }
    const listKey = `${this.entry}s`;
    const entries = new Set();
    groups.forEach((group, index) => {
      const number = index + 1;
      const fields = isObject(group) ? Object.keys(group) : [];
      if (fields.length !== 2 || !fields.includes(listKey) || !fields.includes("reason")) {
        throw this.invalid(`Group ${number} must hold a reason and ${listKey}, and nothing else.`);
      }
      if (typeof group.reason !== "string" || group.reason.trim() === "") {
        throw this.invalid(`Group ${number} needs a non-empty reason.`);
      }
      const listed = group[listKey];
      if (!Array.isArray(listed) || listed.length === 0) {
        throw this.invalid(`Group ${number} needs at least 1 ${this.entry}.`);
      }
      for (const item of listed) {
        if (typeof item !== "string" || !this.pattern.test(item)) {
          throw this.invalid(`Group ${number} lists ${JSON.stringify(item)}. ${this.example}`);
        }
        if (entries.has(item)) {
          throw this.invalid(`${item} appears more than once.`);
        }
        entries.add(item);
      }
    });
    return entries;
  }
}
