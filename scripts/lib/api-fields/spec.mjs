// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import fs from "node:fs";

import { CheckFailure } from "./reviewed-list.mjs";
import { FREE_FORM, UNKNOWN, array, intersect, leaf, merge, object, prop } from "./shapes.mjs";

export const DEFAULT_SPEC = "https://xquik.com/openapi.json";
export const HTTP_METHODS = ["get", "put", "post", "delete", "options", "head", "patch", "trace"];

const BODY_TYPES = ["application/json", "multipart/form-data", "application/x-www-form-urlencoded"];
const RESPONSE_TYPES = ["application/json"];
const DOWNLOAD_TIMEOUT_MS = 60_000;

export const operationKey = (method, path) => `${method} ${path.replaceAll(/\{[^{}/]*\}/g, "{}")}`;

const isObject = (value) => typeof value === "object" && value !== null && !Array.isArray(value);

function asObject(value) {
  if (!isObject(value)) {
    throw new TypeError(`Expected an object, not ${JSON.stringify(value)}`);
  }
  return value;
}

function asList(value) {
  if (!Array.isArray(value)) {
    throw new TypeError(`Expected a list, not ${JSON.stringify(value)}`);
  }
  return value;
}

const own = (schema, key) => (Object.hasOwn(schema, key) ? schema[key] : undefined);

function serverPath(...levels) {
  for (const servers of levels) {
    if (servers !== undefined && asList(servers).length > 0) {
      const { url } = asObject(servers[0]);
      if (typeof url !== "string") {
        throw new TypeError(`Expected a server URL, not ${JSON.stringify(url)}`);
      }
      return new URL(url, "https://xquik.com").pathname.replace(/\/+$/, "");
    }
  }
  return "";
}

class SpecReader {
  constructor(document) {
    this.document = document;
  }

  resolve(reference) {
    let value = this.document;
    for (const token of reference.replace(/^#\//, "").split("/")) {
      value = own(asObject(value), token.replaceAll("~1", "/").replaceAll("~0", "~"));
    }
    return value;
  }

  allOf(schema, nullable, stack) {
    const parts = asList(schema.allOf).map(asObject);
    const rest = Object.fromEntries(Object.entries(schema).filter(([key]) => key !== "allOf"));
    const nodes = parts.map((part) => this.node(part, stack).node);
    if (Object.hasOwn(rest, "properties")) {
      nodes.push(this.node(rest, stack).node);
    }
    const merged = intersect(nodes);
    const required = new Set(
      [...parts, rest]
        .filter((part) => !Object.hasOwn(part, "properties"))
        .flatMap((part) => part.required ?? []),
    );
    if (merged.kind !== "object" || required.size === 0) {
      return { node: merged, nullable };
    }
    const props = new Map(
      [...merged.props].map(([name, item]) => [
        name,
        prop(item.node, item.required || required.has(name), item.nullable),
      ]),
    );
    return { node: object(props, merged.open), nullable };
  }

  choices(schema, key, startingNullable, stack) {
    let nullable = startingNullable;
    let variants = [];
    for (const part of asList(schema[key])) {
      const branch = asObject(part);
      if (branch.type === "null") {
        nullable = true;
      } else {
        const read = this.node(branch, stack);
        nullable = nullable || read.nullable;
        variants.push(read.node);
      }
    }
    if (Object.hasOwn(schema, "properties")) {
      const rest = Object.fromEntries(Object.entries(schema).filter(([name]) => name !== key));
      const base = this.node(rest, stack).node;
      variants = variants.map((variant) => intersect([base, variant]));
    }
    return { node: merge(variants), nullable };
  }

  properties(schema, nullable, stack) {
    const required = new Set(schema.required ?? []);
    const props = new Map();
    for (const [name, value] of Object.entries(asObject(schema.properties))) {
      const read = this.node(value, stack);
      props.set(name, prop(read.node, required.has(name), read.nullable));
    }
    const extra = own(schema, "additionalProperties");
    return { node: object(props, extra !== undefined && extra !== null && extra !== false), nullable };
  }

  node(value, stack = []) {
    const schema = asObject(value);
    const declared = own(schema, "type");
    const listsNull = Array.isArray(declared) && declared.includes("null");
    const reference = own(schema, "$ref");
    if (typeof reference === "string") {
      if (stack.includes(reference)) {
        return { node: UNKNOWN, nullable: false };
      }
      const target = this.node(this.resolve(reference), [...stack, reference]);
      return { node: target.node, nullable: target.nullable || listsNull || schema.nullable === true };
    }
    if (declared === "null") {
      return { node: UNKNOWN, nullable: true };
    }
    const nullable = schema.nullable === true || listsNull;
    const types = [declared].flat().filter((name) => name !== undefined && name !== "null");
    if (Object.hasOwn(schema, "allOf")) {
      return this.allOf(schema, nullable, stack);
    }
    for (const key of ["oneOf", "anyOf"]) {
      if (Object.hasOwn(schema, key)) {
        return this.choices(schema, key, nullable, stack);
      }
    }
    if (Object.hasOwn(schema, "const")) {
      return { node: leaf(new Set([String(schema.const)])), nullable };
    }
    if (Object.hasOwn(schema, "enum")) {
      const values = asList(schema.enum);
      return {
        node: leaf(new Set(values.filter((item) => item !== null).map(String))),
        nullable: nullable || values.includes(null),
      };
    }
    if (isObject(own(schema, "properties"))) {
      return this.properties(schema, nullable, stack);
    }
    if (types.includes("object")) {
      return { node: FREE_FORM, nullable };
    }
    if (types.includes("array") && Object.hasOwn(schema, "items")) {
      return { node: array(this.node(schema.items, stack).node), nullable };
    }
    return { node: leaf(), nullable };
  }

  parameter(value) {
    const parameter = asObject(value);
    const reference = own(parameter, "$ref");
    return typeof reference === "string" ? asObject(this.resolve(reference)) : parameter;
  }

  content(value, accepted) {
    let container = asObject(value);
    const reference = own(container, "$ref");
    if (typeof reference === "string") {
      container = asObject(this.resolve(reference));
    }
    const nodes = Object.entries(asObject(container.content ?? {}))
      .filter(
        ([type, media]) =>
          accepted.includes(type.split(";")[0].trim()) && Object.hasOwn(asObject(media), "schema"),
      )
      .map(([, media]) => this.node(media.schema).node);
    return nodes.length > 0 ? merge(nodes) : null;
  }

  shape(item, operation) {
    const parameters = [...(item.parameters ?? []), ...(operation.parameters ?? [])].map((value) =>
      this.parameter(value),
    );
    const query = new Map();
    for (const parameter of parameters.filter((value) => value.in === "query")) {
      query.set(
        parameter.name,
        prop(this.node(parameter.schema ?? {}).node, parameter.required === true, null),
      );
    }
    const responses = Object.entries(asObject(operation.responses ?? {}))
      .filter(([code]) => code.startsWith("2"))
      .map(([, response]) => this.content(response, RESPONSE_TYPES))
      .filter((node) => node !== null);
    return {
      query: object(query),
      body: Object.hasOwn(operation, "requestBody") ? this.content(operation.requestBody, BODY_TYPES) : null,
      response: responses.length > 0 ? merge(responses) : null,
    };
  }
}

export function specShapes(document) {
  const reader = new SpecReader(document);
  const shapes = new Map();
  for (const [path, value] of Object.entries(asObject(document.paths))) {
    const item = asObject(value);
    if (Object.hasOwn(item, "$ref")) {
      throw new TypeError(`The path item of ${path} is a reference`);
    }
    for (const method of HTTP_METHODS.filter((name) => Object.hasOwn(item, name))) {
      const operation = asObject(item[method]);
      const absolute = serverPath(operation.servers, item.servers, document.servers) + path;
      const upper = method.toUpperCase();
      shapes.set(operationKey(upper, absolute), {
        label: `${upper} ${absolute}`,
        shape: reader.shape(item, operation),
      });
    }
  }
  return shapes;
}

export const specSource = () => process.env.XQUIK_OPENAPI_SPEC || DEFAULT_SPEC;

export function unexpectedSpec(source) {
  return new CheckFailure(
    `The API spec from ${source} has a part the check cannot read. ` +
      `Fix the spec, or set XQUIK_OPENAPI_SPEC to a valid copy of ${DEFAULT_SPEC}.`,
  );
}

async function download(url) {
  const response = await fetch(url, { signal: AbortSignal.timeout(DOWNLOAD_TIMEOUT_MS) });
  if (!response.ok) {
    throw new Error(`HTTP ${response.status}`);
  }
  return response.text();
}

export async function loadSpec(source) {
  let document;
  try {
    const remote = source.startsWith("https://") || source.startsWith("http://");
    document = JSON.parse(remote ? await download(source) : fs.readFileSync(source, "utf8"));
  } catch {
    throw new CheckFailure(
      `Could not read the API spec from ${source}. ` +
        `Check network access, or set XQUIK_OPENAPI_SPEC to a local copy of ${DEFAULT_SPEC}.`,
    );
  }
  if (!isObject(document)) {
    throw unexpectedSpec(source);
  }
  return document;
}
