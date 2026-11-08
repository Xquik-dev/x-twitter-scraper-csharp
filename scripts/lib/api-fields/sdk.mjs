// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";
import path from "node:path";

import { cleanHeader, members, parseType, readFile } from "./csharp.mjs";
import { FREE_FORM, UNKNOWN, array, leaf, merge, mergeObjects, object, prop } from "./shapes.mjs";
import { operationKey } from "./spec.mjs";

const SOURCE = "src/XTwitterScraper";
const ENVIRONMENT = `${SOURCE}/Core/EnvironmentUrl.cs`;
const SEQUENCES = new Set(["[]", "ImmutableArray", "IReadOnlyList", "IList", "List", "IEnumerable", "ICollection"]);
const DICTIONARIES = new Set(["FrozenDictionary", "IReadOnlyDictionary", "IDictionary", "Dictionary"]);
const LEAVES = new Set([
  "string",
  "bool",
  "byte",
  "short",
  "int",
  "long",
  "float",
  "double",
  "decimal",
  "DateTimeOffset",
  "DateTime",
  "DateOnly",
  "TimeOnly",
  "TimeSpan",
  "Guid",
  "Uri",
  "BinaryContent",
]);
const UNTYPED = new Set(["JsonElement", "object", "Null"]);
const MODEL_BASES = new Set(["JsonModel", "MultipartJsonModel"]);
const VIEWS = new Set(["RawData", "RawQueryData", "RawBodyData", "RawHeaderData"]);

const PROPERTY = /^public\s+((?:required\s+|override\s+|virtual\s+|new\s+)*)([\w:.]+(?:<[\s\S]*>)?(?:\[\])?\??)\s+(\w+)$/;
const ACCESSOR =
  /this\.(_rawData|_rawQueryData|_rawBodyData|_rawHeaderData)\s*\.Get(NotNull|Nullable)(?:Class|Struct)\s*<([\s\S]+?)>\s*\(\s*"([^"]+)"\s*\)/;
const WHOLE_BODY = /WrappedJsonSerializer\s*\.\s*GetNotNullClass\s*<([\s\S]+?)>\s*\(\s*this\.RawBodyData\b/;
const OBSOLETE = /\[\s*(?:System(?:::|\.))?Obsolete\b/;
const AUTO_PROPERTY = /^\s*get\s*;/;
const NULL_GUARD = /if\s*\(\s*value\s*[!=]=\s*null\s*\)/;
const CONSTANT = /^\s*this\.(\w+)\s*=\s*JsonSerializer\.SerializeToElement\(\s*(?:"([^"]*)"|(true|false|-?\d+(?:\.\d+)?))\s*\)\s*;/gm;
const OPERATION_HEADER = /Task<\s*HttpResponse(?:<([\s\S]+)>)?\s*>\s+\w+\s*\(/;
const REQUEST =
  /HttpRequest<([\w:.]+)>\s+request\s*=\s*new\(\)\s*\{\s*Method\s*=\s*([\w.]+)\s*,\s*Params\s*=\s*parameters\s*,?\s*\}/;
const URL_PATH = /TrimEnd\('\/'\)\s*\+\s*(?:string\.Format\(\s*)?"([^"]*)"/;
const BASE_URL = /Production\s*=\s*"([^"]+)"/;
const UNION_VARIANT = /^public\s+\w+\(\s*([\s\S]+?)\s+value\s*,\s*JsonElement\?\s+element\s*=\s*null\s*\)$/;
const SERVICES = `${SOURCE}/Services/`;

function httpMethod(expression) {
  if (expression.endsWith(".PatchMethod")) {
    return "PATCH";
  }
  const match = /^HttpMethod\.([A-Z][a-z]+)$/.exec(expression);
  return match === null ? null : match[1].toUpperCase();
}

function enclosing(namespace) {
  const parts = namespace === "" ? [] : namespace.split(".");
  return parts.map((_, index) => parts.slice(0, parts.length - index).join("."));
}

class SdkReader {
  constructor(root) {
    this.root = root;
    this.files = [];
    this.types = new Map();
    this.shapes = new Map();
    this.problems = new Set();
    const source = path.join(root, SOURCE);
    for (const name of fs.readdirSync(source, { recursive: true })) {
      const relative = `${SOURCE}/${String(name).split(path.sep).join("/")}`;
      if (relative.endsWith(".cs") && !/\/(bin|obj)\//.test(relative)) {
        const file = readFile(relative, fs.readFileSync(path.join(root, relative), "utf8"));
        this.files.push(file);
        for (const type of file.types) {
          this.types.set(file.namespace ? `${file.namespace}.${type.name}` : type.name, type);
        }
      }
    }
  }

  problem(file, offset, reason) {
    this.problems.add(`${file.relative}:${file.lineOf(offset)} ${reason}.`);
  }

  aliased(name, file) {
    const separator = name.indexOf("::");
    const alias = name.slice(0, separator);
    const rest = name.slice(separator + 2);
    return this.types.get(alias === "global" ? rest : `${file.aliases.get(alias)}.${rest}`);
  }

  resolve(name, file) {
    if (name.includes("::")) {
      return this.aliased(name, file);
    }
    for (const namespace of enclosing(file.namespace)) {
      const found = this.types.get(`${namespace}.${name}`);
      if (found !== undefined) {
        return found;
      }
    }
    const aliasTarget = file.aliases.get(name);
    if (aliasTarget !== undefined && this.types.has(aliasTarget)) {
      return this.types.get(aliasTarget);
    }
    for (const namespace of file.usings) {
      const found = this.types.get(`${namespace}.${name}`);
      if (found !== undefined) {
        return found;
      }
    }
    return this.types.get(name);
  }

  node(expression, file, offset, stack) {
    const name = expression.name.split("::").pop();
    if (SEQUENCES.has(name) && expression.args.length === 1) {
      return array(this.node(expression.args[0], file, offset, stack));
    }
    if (DICTIONARIES.has(name)) {
      return FREE_FORM;
    }
    if (name === "ApiEnum" && expression.args.length === 2) {
      return this.node(expression.args[1], file, offset, stack);
    }
    if (name === "Nullable" && expression.args.length === 1) {
      return this.node(expression.args[0], file, offset, stack);
    }
    if (UNTYPED.has(name)) {
      return UNKNOWN;
    }
    const type = expression.args.length === 0 ? this.resolve(expression.name, file) : undefined;
    if (type !== undefined) {
      return this.typeNode(type, stack);
    }
    if (LEAVES.has(name)) {
      return leaf();
    }
    this.problem(file, offset, `uses the type ${expression.name}, which the check cannot read`);
    return UNKNOWN;
  }

  typeNode(type, stack) {
    if (type.kind === "enum") {
      return this.enumNode(type);
    }
    if (stack.includes(type)) {
      return UNKNOWN;
    }
    if (!this.shapes.has(type)) {
      this.shapes.set(type, this.modelNode(type, [...stack, type]));
    }
    return this.shapes.get(type);
  }

  enumNode(type) {
    const { file, name } = type;
    const converter = file.types.find((item) => item.name === `${name}Converter`);
    const source = converter === undefined ? "" : file.code.slice(converter.open, converter.close);
    const entry = new RegExp(`(?:"([^"]+)"|(-?\\d+)L?)\\s*=>\\s*(?:global::[\\w.]*\\.)?${name}\\.\\w+`, "g");
    const values = new Set([...source.matchAll(entry)].map((match) => match[1] ?? match[2]));
    if (values.size === 0) {
      this.problem(file, type.open, `declares the enum ${name}, whose wire values the check cannot read`);
    }
    return leaf(values);
  }

  inheritedProps(type, stack) {
    if (MODEL_BASES.has(type.base)) {
      return [];
    }
    const parent = type.base === "" ? undefined : this.resolve(type.base, type.file);
    if (parent === undefined) {
      this.problem(type.file, type.open, `declares ${type.name}, whose base type the check cannot read`);
      return [];
    }
    const node = this.typeNode(parent, stack);
    return node.kind === "object" ? [...node.props] : [];
  }

  modelNode(type, stack) {
    if (type.base === "ModelBase") {
      return this.unionNode(type, stack);
    }
    const inherited = this.inheritedProps(type, stack);
    return object(new Map([...inherited, ...this.fields(type, "_rawData", stack).node.props]));
  }

  unionNode(type, stack) {
    const variants = [];
    for (const member of members(type)) {
      const match = UNION_VARIANT.exec(cleanHeader(member.header));
      if (match !== null) {
        variants.push(this.node(parseType(match[1]), type.file, member.offset, stack));
      }
    }
    if (variants.length === 0) {
      this.problem(type.file, type.open, `declares ${type.name}, whose variants the check cannot read`);
      return UNKNOWN;
    }
    return merge(variants);
  }

  constantOf(type, property) {
    const source = type.file.code.slice(type.open, type.close);
    for (const match of source.matchAll(CONSTANT)) {
      if (match[1] === property) {
        return match[2] ?? match[3];
      }
    }
    return undefined;
  }

  readProperty(type, member, declaration, accessor, stack) {
    const required = /\brequired\b/.test(declaration.modifiers);
    const parsedType = parseType(accessor.typeText);
    const constant =
      !required && parsedType.name === "JsonElement" ? this.constantOf(type, declaration.name) : undefined;
    if (constant !== undefined) {
      return prop(leaf(new Set([constant])), true, false);
    }
    const nullable = accessor.presence === "Nullable" && (required || !NULL_GUARD.test(member.body));
    const node = this.node(parsedType, type.file, member.offset, stack);
    return prop(node, required, nullable, OBSOLETE.test(member.header));
  }

  fields(type, dictionary, stack) {
    const props = new Map();
    let wholeBody = null;
    for (const member of members(type)) {
      const parsed = member.body === null ? null : PROPERTY.exec(cleanHeader(member.header));
      if (parsed !== null && !VIEWS.has(parsed[3])) {
        const declaration = { modifiers: parsed[1], name: parsed[3] };
        const accessor = ACCESSOR.exec(member.body);
        const whole = WHOLE_BODY.exec(member.body);
        if (accessor !== null && accessor[1] === dictionary) {
          const read = { presence: accessor[2], typeText: accessor[3] };
          props.set(accessor[4], this.readProperty(type, member, declaration, read, stack));
        } else if (whole !== null) {
          wholeBody = this.node(parseType(whole[1]), type.file, member.offset, stack);
        } else if (accessor === null && !AUTO_PROPERTY.test(member.body)) {
          this.problem(type.file, member.offset, `declares the property ${declaration.name}, which the check cannot read`);
        }
      }
    }
    return { node: object(props), wholeBody };
  }

  urlPath(type) {
    for (const member of members(type)) {
      if (member.body !== null && /\bUrl\s*\(/.test(member.header)) {
        const match = URL_PATH.exec(member.body);
        if (match !== null) {
          return match[1];
        }
      }
    }
    this.problem(type.file, type.open, `declares ${type.name}, whose request path the check cannot read`);
    return null;
  }

  requestShape(type) {
    const query = this.fields(type, "_rawQueryData", [type]).node;
    const { node: body, wholeBody } = this.fields(type, "_rawBodyData", [type]);
    const hasBody = type.file.code.slice(type.open, type.close).includes("BodyContent()");
    return { query, body: wholeBody ?? (hasBody ? body : null) };
  }

  operation(service, member, request, basePath) {
    const { file } = service;
    const parameters = this.resolve(request[1], file);
    const method = httpMethod(request[2]);
    const header = OPERATION_HEADER.exec(member.header);
    if (parameters === undefined || method === null || header === null) {
      this.problem(file, member.offset, "builds a request the check cannot read");
      return null;
    }
    const urlPath = this.urlPath(parameters);
    if (urlPath === null) {
      return null;
    }
    const response =
      header[1] === undefined ? null : this.node(parseType(header[1]), file, member.offset, []);
    return {
      key: operationKey(method, basePath + urlPath),
      shape: { ...this.requestShape(parameters), response },
    };
  }

  operations() {
    const environment = BASE_URL.exec(fs.readFileSync(path.join(this.root, ENVIRONMENT), "utf8"));
    const basePath = new URL(environment[1]).pathname.replace(/\/+$/, "");
    const shapes = new Map();
    for (const file of this.files.filter((item) => item.relative.startsWith(SERVICES))) {
      for (const service of file.types) {
        for (const member of members(service)) {
          if (member.body?.includes("HttpRequest<")) {
            const request = REQUEST.exec(member.body);
            const read = request === null ? null : this.operation(service, member, request, basePath);
            if (request === null) {
              this.problem(file, member.offset, "builds a request the check cannot read");
            }
            if (read !== null) {
              shapes.set(read.key, combine(shapes.get(read.key), read.shape));
            }
          }
        }
      }
    }
    return shapes;
  }
}

function combineOptional(first, second) {
  if (first === null || second === null) {
    return first ?? second;
  }
  return merge([first, second]);
}

function combine(previous, shape) {
  if (previous === undefined) {
    return shape;
  }
  return {
    query: mergeObjects([previous.query, shape.query]),
    body: combineOptional(previous.body, shape.body),
    response: combineOptional(previous.response, shape.response),
  };
}

export function sdkShapes(root) {
  const reader = new SdkReader(root);
  const shapes = reader.operations();
  return { shapes, problems: [...reader.problems].sort() };
}
