// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

export const UNKNOWN = Object.freeze({ kind: "unknown" });
export const FREE_FORM = Object.freeze({ kind: "free-form" });

export const leaf = (values = null) => ({ kind: "leaf", values });
export const array = (items) => ({ kind: "array", items });
export const object = (props = new Map(), open = false) => ({ kind: "object", props, open });
export const prop = (node, required, nullable, obsolete = false) => ({ node, required, nullable, obsolete });

const isOpaque = (node) => node.kind === "unknown" || node.kind === "free-form";
const ofKind = (nodes, kind) => nodes.filter((node) => node.kind === kind);
const join = (path, name) => (path ? `${path}.${name}` : name);
const bodyPath = (path) => path || "(body)";

function sameValues(first, second) {
  return first.size === second.size && [...first].every((value) => second.has(value));
}

export function mergeObjects(objects) {
  const props = new Map();
  const names = new Set(objects.flatMap((node) => [...node.props.keys()]));
  for (const name of names) {
    const have = objects.filter((node) => node.props.has(name)).map((node) => node.props.get(name));
    const nullables = have.map((item) => item.nullable);
    props.set(
      name,
      prop(
        merge(have.map((item) => item.node)),
        have.length === objects.length && have.every((item) => item.required),
        nullables.includes(null) ? null : nullables.some(Boolean),
        have.every((item) => item.obsolete),
      ),
    );
  }
  return object(props, objects.some((node) => node.open));
}

export function merge(nodes) {
  if (nodes.length > 0 && nodes.every((node) => node === nodes[0])) {
    return nodes[0];
  }
  if (ofKind(nodes, "free-form").length > 0) {
    return FREE_FORM;
  }
  const objects = ofKind(nodes, "object");
  if (objects.length > 0) {
    return mergeObjects(objects);
  }
  const arrays = ofKind(nodes, "array");
  if (arrays.length > 0) {
    return array(merge(arrays.map((node) => node.items)));
  }
  const leaves = ofKind(nodes, "leaf");
  if (leaves.length > 0) {
    return leaf(
      leaves.some((node) => node.values === null)
        ? null
        : new Set(leaves.flatMap((node) => [...node.values])),
    );
  }
  return UNKNOWN;
}

export function intersect(nodes) {
  const objects = ofKind(nodes, "object");
  const arrays = ofKind(nodes, "array");
  if (objects.length === 0 && arrays.length > 0) {
    return array(intersect(arrays.map((node) => node.items)));
  }
  if (objects.length === 0) {
    return nodes.find((node) => !isOpaque(node)) ?? UNKNOWN;
  }
  const props = new Map();
  for (const node of objects) {
    for (const [name, item] of node.props) {
      const earlier = props.get(name);
      props.set(
        name,
        earlier === undefined
          ? item
          : prop(
              intersect([earlier.node, item.node]),
              earlier.required || item.required,
              Boolean(earlier.nullable && item.nullable),
            ),
      );
    }
  }
  return object(props, objects.some((node) => node.open));
}

function extraFields(sdk, listed) {
  return [...sdk.props]
    .filter(([name, item]) => !listed.has(name) && !item.obsolete)
    .map(([name]) => name);
}

function compareObjects(spec, sdk, path, found) {
  for (const [name, wanted] of spec.props) {
    const here = join(path, name);
    const got = sdk.props.get(name);
    if (got === undefined) {
      found.push(["missing", here]);
      continue;
    }
    if (wanted.required !== got.required) {
      found.push(["required", here]);
    }
    if (wanted.nullable !== null && got.nullable !== null && wanted.nullable !== got.nullable) {
      found.push(["nullable", here]);
    }
    compare(wanted.node, got.node, here, found);
  }
  if (!spec.open) {
    found.push(...extraFields(sdk, spec.props).map((name) => ["extra", join(path, name)]));
  }
}

export function compare(spec, sdk, path, found) {
  if (spec.kind === "object" && sdk.kind === "object") {
    compareObjects(spec, sdk, path, found);
  } else if (spec.kind === "array" && sdk.kind === "array") {
    compare(spec.items, sdk.items, `${path}[]`, found);
  } else if (spec.kind === "leaf" && sdk.kind === "leaf") {
    if (spec.values !== null && sdk.values !== null && !sameValues(spec.values, sdk.values)) {
      found.push(["enum", bodyPath(path)]);
    }
  } else if (!isOpaque(spec) && !isOpaque(sdk)) {
    found.push(["missing", bodyPath(path)]);
  }
}

function requestBodyDifferences(spec, sdk, found) {
  if (spec !== null && sdk !== null) {
    compare(spec, sdk, "", found);
  } else if (spec?.kind === "object") {
    found.push(...[...spec.props.keys()].map((name) => ["missing", name]));
  } else if (sdk?.kind === "object") {
    found.push(...extraFields(sdk, new Map()).map((name) => ["extra", name]));
  }
}

export function differences(spec, sdk) {
  const request = [];
  compare(spec.query, sdk.query, "", request);
  requestBodyDifferences(spec.body, sdk.body, request);
  const response = [];
  if (spec.response !== null) {
    compare(spec.response, sdk.response ?? leaf(), "", response);
  }
  return [
    ...request.map(([kind, path]) => ({ side: "request", kind, path })),
    ...response.map(([kind, path]) => ({ side: "response", kind, path })),
  ];
}
