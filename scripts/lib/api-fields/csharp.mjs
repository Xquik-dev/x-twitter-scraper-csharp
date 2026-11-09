// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

const DECLARATION =
  /^[ \t]*(?:(?:public|internal|private|protected|sealed|abstract|static|partial)\s+)*(record\s+class|record\s+struct|record|class|struct|enum|interface)\s+(\w+)(?:<[^>{]*>)?\s*(?::\s*([^{]*?))?\s*\{/gm;
const USING = /^\s*using\s+(?:(\w+)\s*=\s*)?([\w.]+)\s*;/gm;
const NAMESPACE = /^\s*namespace\s+([\w.]+)\s*;/m;
const PREPROCESSOR_LINE = /^\s*#.*$/gm;
const ATTRIBUTE_LINE = /^\s*\[.*\]\s*$/gm;

function blankRange(chars, start, end) {
  for (let index = start; index < end; index += 1) {
    if (chars[index] !== "\n" && chars[index] !== "\r") {
      chars[index] = " ";
    }
  }
}

function endOfQuoted(text, start, quote, verbatim) {
  let index = start + 1;
  while (index < text.length) {
    if (verbatim && text[index] === quote && text[index + 1] === quote) {
      index += 2;
    } else if (!verbatim && text[index] === "\\") {
      index += 2;
    } else if (text[index] === quote) {
      return index + 1;
    } else {
      index += 1;
    }
  }
  return text.length;
}

export function blank(text) {
  const code = text.split("");
  const structure = text.split("");
  let index = 0;
  while (index < text.length) {
    const pair = text.slice(index, index + 2);
    let end = index + 1;
    if (pair === "//" || pair === "/*") {
      const closing = pair === "//" ? text.indexOf("\n", index) : text.indexOf("*/", index + 2);
      end = closing === -1 ? text.length : closing + (pair === "//" ? 0 : 2);
      blankRange(code, index, end);
      blankRange(structure, index, end);
    } else if (text[index] === '"' || text[index] === "'") {
      const verbatim = text[index] === '"' && text.slice(Math.max(0, index - 2), index).includes("@");
      end = endOfQuoted(text, index, text[index], verbatim);
      blankRange(structure, index + 1, end - 1);
    }
    index = end;
  }
  return { code: code.join(""), structure: structure.join("") };
}

function closingBrace(structure, open) {
  let depth = 0;
  for (let index = open; index < structure.length; index += 1) {
    if (structure[index] === "{") {
      depth += 1;
    } else if (structure[index] === "}") {
      depth -= 1;
      if (depth === 0) {
        return index;
      }
    }
  }
  return structure.length;
}

export function* members(type) {
  const { code, structure } = type.file;
  let depth = 0;
  let start = type.open + 1;
  let headerEnd = start;
  for (let index = type.open + 1; index < type.close; index += 1) {
    const character = structure[index];
    if (character === "{") {
      if (depth === 0) {
        headerEnd = index;
      }
      depth += 1;
    } else if (character === "}") {
      depth -= 1;
      if (depth === 0) {
        yield { header: code.slice(start, headerEnd), body: code.slice(headerEnd + 1, index), offset: headerEnd };
        start = index + 1;
      }
    } else if (character === ";" && depth === 0) {
      yield { header: code.slice(start, index), body: null, offset: index };
      start = index + 1;
    }
  }
}

export function cleanHeader(header) {
  return header.replaceAll(PREPROCESSOR_LINE, "").replaceAll(ATTRIBUTE_LINE, "").trim();
}

export function readFile(relative, text) {
  const { code, structure } = blank(text);
  const file = {
    relative,
    text,
    code,
    structure,
    namespace: NAMESPACE.exec(structure)?.[1] ?? "",
    usings: [],
    aliases: new Map(),
    types: [],
    lineOf: (offset) => text.slice(0, offset).split("\n").length,
  };
  for (const match of structure.matchAll(USING)) {
    if (match[1] === undefined) {
      file.usings.push(match[2]);
    } else {
      file.aliases.set(match[1], match[2]);
    }
  }
  let previousClose = -1;
  for (const match of structure.matchAll(DECLARATION)) {
    const open = match.index + match[0].length - 1;
    if (open > previousClose) {
      const close = closingBrace(structure, open);
      file.types.push({
        kind: match[1].replaceAll(/\s+/g, " "),
        name: match[2],
        base: match[3]?.trim() ?? "",
        file,
        open,
        close,
      });
      previousClose = close;
    }
  }
  return file;
}

function splitArguments(text) {
  const parts = [];
  let depth = 0;
  let start = 0;
  for (let index = 0; index < text.length; index += 1) {
    if (text[index] === "<") {
      depth += 1;
    } else if (text[index] === ">") {
      depth -= 1;
    } else if (text[index] === "," && depth === 0) {
      parts.push(text.slice(start, index));
      start = index + 1;
    }
  }
  parts.push(text.slice(start));
  return parts.map((part) => parseType(part));
}

export function parseType(source) {
  let text = source.trim();
  const optional = text.endsWith("?");
  if (optional) {
    text = text.slice(0, -1).trim();
  }
  if (text.endsWith("[]")) {
    return { name: "[]", args: [parseType(text.slice(0, -2))], optional };
  }
  const open = text.indexOf("<");
  if (open === -1 || !text.endsWith(">")) {
    return { name: text, args: [], optional };
  }
  return { name: text.slice(0, open).trim(), args: splitArguments(text.slice(open + 1, -1)), optional };
}
