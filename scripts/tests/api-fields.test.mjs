// SPDX-FileCopyrightText: 2026 Xquik contributors
// SPDX-License-Identifier: Apache-2.0

import assert from "node:assert/strict";
import fs from "node:fs";
import path from "node:path";
import { test } from "node:test";

import { ACCEPTED, EXCLUDED } from "../lib/api-fields/check.mjs";
import { sdkShapes } from "../lib/api-fields/sdk.mjs";
import { createSandbox, root } from "./support.mjs";

const SOURCE = "src/XTwitterScraper";
const LIBRARY = ["check", "csharp", "main", "reviewed-list", "sdk", "shapes", "spec"];
const MONITOR_FILES = [
  `${SOURCE}/Core/EnvironmentUrl.cs`,
  `${SOURCE}/Services/MonitorService.cs`,
  `${SOURCE}/Models/EventType.cs`,
  ...fs
    .readdirSync(path.join(root, SOURCE, "Models/Monitors"))
    .filter((name) => name.endsWith(".cs"))
    .map((name) => `${SOURCE}/Models/Monitors/${name}`),
];
const NEXT_STEP = "Fix each field above in the SDK, or list it in accepted-field-differences.json with a reason.";
const SDK_FORM_STEP =
  "Write each line above in the style of the generated code, or teach scripts/lib/api-fields/sdk.mjs the new form.";
const UNREADABLE_TAIL =
  "Check network access, or set XQUIK_OPENAPI_SPEC to a local copy of https://xquik.com/openapi.json.";
const UNEXPECTED_TAIL = "Fix the spec, or set XQUIK_OPENAPI_SPEC to a valid copy of https://xquik.com/openapi.json.";
const MONITOR = "GET /api/v1/monitors/{id}";
const PASS_ONE = "accepted-field-differences.json lists 0 accepted differences.\n";

const readSource = (file) => fs.readFileSync(path.join(root, file), "utf8");

const eventTypes = () =>
  [...readSource(`${SOURCE}/Models/EventType.cs`).matchAll(/"([^"]+)" => EventType\./g)].map((match) => match[1]);

function monitorSchema() {
  const time = { type: "string", format: "date-time" };
  return {
    type: "object",
    required: ["id", "createdAt", "eventTypes", "isActive", "nextBillingAt", "username", "xUserId"],
    properties: {
      id: { type: "string" },
      createdAt: time,
      eventTypes: { type: "array", items: { type: "string", enum: eventTypes() } },
      isActive: { type: "boolean" },
      nextBillingAt: time,
      username: { type: "string" },
      xUserId: { type: "string" },
    },
  };
}

function monitorOperation(schema, extra = {}) {
  return {
    responses: { 200: { description: "A monitor", content: { "application/json": { schema } } } },
    ...extra,
  };
}

function specOf(paths, extra = {}) {
  return { openapi: "3.1.0", servers: [{ url: "https://xquik.com" }], paths, ...extra };
}

const monitorSpec = (schema = monitorSchema(), extra = {}) =>
  specOf({ "/api/v1/monitors/{id}": { get: monitorOperation(schema, extra) } });

function prepare(t, { files = MONITOR_FILES, edits = {}, accepted = [], excluded = [], wholeSdk = false } = {}) {
  const sandbox = createSandbox(t);
  sandbox.copy("scripts/api-fields");
  for (const name of LIBRARY) {
    sandbox.copy(`scripts/lib/api-fields/${name}.mjs`);
  }
  if (wholeSdk) {
    fs.symlinkSync(path.join(root, "src"), path.join(sandbox.repo, "src"));
  } else {
    for (const file of files) {
      const edit = edits[file];
      sandbox.write(file, edit === undefined ? readSource(file) : edit(readSource(file)));
    }
  }
  sandbox.write("accepted-field-differences.json", JSON.stringify(accepted));
  sandbox.write("excluded-operations.json", JSON.stringify(excluded));
  return sandbox;
}

function runCheck(t, spec, options = {}) {
  const sandbox = prepare(t, options);
  sandbox.write("spec.json", JSON.stringify(spec));
  return sandbox.run("scripts/api-fields", [], { XQUIK_OPENAPI_SPEC: "spec.json" });
}

function assertFails(result, ...lines) {
  assert.equal(result.stderr, `${lines.join("\n")}\n`);
  assert.equal(result.stdout, "");
  assert.equal(result.status, 1);
}

function assertPasses(result, operations = "1 operation") {
  assert.equal(result.stderr, "");
  assert.equal(result.stdout, `The SDK's fields match the API for ${operations}, and ${PASS_ONE}`);
  assert.equal(result.status, 0);
}

test("a spec that matches the SDK passes and counts the operation", (t) => {
  assertPasses(runCheck(t, monitorSpec()));
});

const responseCases = [
  {
    name: "a field only the spec has is missing",
    edit: (schema) => {
      schema.properties.plan = { type: "string" };
    },
    line: "missing plan",
  },
  {
    name: "a field only the SDK has is extra",
    edit: (schema) => {
      delete schema.properties.username;
      schema.required = schema.required.filter((name) => name !== "username");
    },
    line: "extra username",
  },
  {
    name: "a differing required flag prints required",
    edit: (schema) => {
      schema.required = schema.required.filter((name) => name !== "username");
    },
    line: "required username",
  },
  {
    name: "a differing null flag prints nullable",
    edit: (schema) => {
      schema.properties.username.type = ["string", "null"];
    },
    line: "nullable username",
  },
  {
    name: "differing enum values print enum at the array item",
    edit: (schema) => {
      schema.properties.eventTypes.items.enum = ["tweet.new"];
    },
    line: "enum eventTypes[]",
  },
  {
    name: "an object where the SDK has text prints missing at that field",
    edit: (schema) => {
      schema.properties.username = { type: "object", properties: { first: { type: "string" } } };
    },
    line: "missing username",
  },
  {
    name: "a nested field reports its whole wire path",
    edit: (schema) => {
      schema.properties.eventTypes.items = { type: "object", properties: { first: { type: "string" } } };
    },
    line: "missing eventTypes[]",
  },
];

for (const { name, edit, line } of responseCases) {
  test(name, (t) => {
    const schema = monitorSchema();
    edit(schema);

    assertFails(runCheck(t, monitorSpec(schema)), `${MONITOR} response ${line}`, NEXT_STEP);
  });
}

test("a response of another shape prints missing at the body", (t) => {
  const result = runCheck(t, monitorSpec({ type: "array", items: { type: "string" } }));

  assertFails(result, `${MONITOR} response missing (body)`, NEXT_STEP);
});

test("a query parameter only the spec has is missing, and a path parameter stays out", (t) => {
  const parameters = [
    { name: "limit", in: "query", schema: { type: "integer" } },
    { name: "id", in: "path", required: true, schema: { type: "string" } },
  ];

  assertFails(
    runCheck(t, monitorSpec(monitorSchema(), { parameters })),
    `${MONITOR} request missing limit`,
    NEXT_STEP,
  );
});

test("request body fields compare in both directions and against the required list", (t) => {
  const body = {
    type: "object",
    required: ["username"],
    properties: { eventTypes: { type: "array", items: { type: "string" } }, note: { type: "string" } },
  };
  const requestBody = { content: { "application/json; charset=utf-8": { schema: body } } };

  assertFails(
    runCheck(t, specOf({ "/api/v1/monitors": { post: { requestBody, responses: {} } } })),
    "POST /api/v1/monitors request extra username",
    "POST /api/v1/monitors request missing note",
    "POST /api/v1/monitors request required eventTypes",
    NEXT_STEP,
  );
});

test("a body only the SDK sends prints each field as extra", (t) => {
  assertFails(
    runCheck(t, specOf({ "/api/v1/monitors": { post: { responses: {} } } })),
    "POST /api/v1/monitors request extra eventTypes",
    "POST /api/v1/monitors request extra username",
    NEXT_STEP,
  );
});

test("a body only the spec has prints each field as missing", (t) => {
  const requestBody = {
    content: { "application/json": { schema: { type: "object", properties: { note: { type: "string" } } } } },
  };

  assertFails(
    runCheck(t, specOf({ "/api/v1/monitors/{id}": { get: { requestBody, responses: {} } } })),
    `${MONITOR} request missing note`,
    NEXT_STEP,
  );
});

test("the spec's fields read through $ref, allOf, oneOf and anyOf", (t) => {
  const monitor = monitorSchema();
  const { username, ...rest } = monitor.properties;
  const schemas = {
    Names: { type: "object", required: ["username"], properties: { username } },
    Rest: { type: "object", required: monitor.required.filter((name) => name !== "username"), properties: rest },
    Whole: { allOf: [{ $ref: "#/components/schemas/Names" }, { $ref: "#/components/schemas/Rest" }] },
  };
  const paths = {
    "/api/v1/monitors/{id}": {
      get: monitorOperation({
        oneOf: [{ $ref: "#/components/schemas/Whole" }, { anyOf: [{ $ref: "#/components/schemas/Whole" }, { type: "null" }] }],
      }),
    },
  };

  assertPasses(runCheck(t, specOf(paths, { components: { schemas } })));
});

test("variants of a spec union make a field optional when only some list it", (t) => {
  const other = { type: "object", properties: { username: { type: "string" } } };

  assertFails(
    runCheck(t, monitorSpec({ oneOf: [monitorSchema(), other] })),
    `${MONITOR} response required createdAt`,
    `${MONITOR} response required eventTypes`,
    `${MONITOR} response required id`,
    `${MONITOR} response required isActive`,
    `${MONITOR} response required nextBillingAt`,
    `${MONITOR} response required username`,
    `${MONITOR} response required xUserId`,
    NEXT_STEP,
  );
});

test("each 2xx response counts and error responses stay out", (t) => {
  const operation = monitorOperation(monitorSchema());
  operation.responses[404] = {
    description: "No monitor",
    content: { "application/json": { schema: { type: "object", properties: { error: { type: "string" } } } } },
  };
  operation.responses[202] = {
    description: "Queued",
    content: { "application/json": { schema: { ...monitorSchema(), required: [] } } },
  };
  const result = runCheck(t, specOf({ "/api/v1/monitors/{id}": { get: operation } }));

  assert.equal(result.stderr.split("\n").at(0), `${MONITOR} response required createdAt`);
  assert.equal(result.stderr.includes("error"), false);
  assert.equal(result.status, 1);
});

test("an object that allows extra properties hides SDK fields, and a free-form field hides its contents", (t) => {
  const schema = monitorSchema();
  schema.additionalProperties = true;
  delete schema.properties.username;
  schema.required = schema.required.filter((name) => name !== "username");
  schema.properties.id = { type: "object" };

  assertPasses(runCheck(t, monitorSpec(schema)));
});

test("path parameter names do not matter, and the line prints the spec's name", (t) => {
  const schema = monitorSchema();
  schema.properties.plan = { type: "string" };

  assertFails(
    runCheck(t, specOf({ "/api/v1/monitors/{monitorId}": { get: monitorOperation(schema) } })),
    "GET /api/v1/monitors/{monitorId} response missing plan",
    NEXT_STEP,
  );
});

test("the server path joins the spec path, at the document, path or operation level", (t) => {
  const schema = monitorSchema();
  schema.properties.plan = { type: "string" };
  const operation = monitorOperation(schema);
  const levels = [
    specOf({ "/monitors/{id}": { get: operation } }, { servers: [{ url: "https://xquik.com/api/v1/" }] }),
    specOf({ "/monitors/{id}": { servers: [{ url: "https://xquik.com/api/v1" }], get: operation } }),
    specOf({ "/monitors/{id}": { get: { ...operation, servers: [{ url: "/api/v1" }] } } }),
  ];

  for (const spec of levels) {
    assertFails(runCheck(t, spec), `${MONITOR} response missing plan`, NEXT_STEP);
  }
});

test("operations only the spec or only the SDK has are not compared", (t) => {
  const paths = {
    "/api/v1/monitors/{id}": { get: monitorOperation(monitorSchema()) },
    "/api/v1/something-new": { get: monitorOperation({ type: "object", properties: { a: { type: "string" } } }) },
  };

  assertPasses(runCheck(t, specOf(paths)));
});

test("an accepted difference passes and counts, with 1 in the singular", (t) => {
  const line = `${MONITOR} response missing plan`;
  const schema = monitorSchema();
  schema.properties.plan = { type: "string" };
  const result = runCheck(t, monitorSpec(schema), { accepted: [{ reason: "Not yet typed.", differences: [line] }] });

  assert.equal(result.stderr, "");
  assert.equal(
    result.stdout,
    "The SDK's fields match the API for 1 operation, and accepted-field-differences.json lists 1 accepted difference.\n",
  );
  assert.equal(result.status, 0);
});

test("a stale acceptance fails and names the file", (t) => {
  const line = `${MONITOR} response missing plan`;

  assertFails(
    runCheck(t, monitorSpec(), { accepted: [{ reason: "Not yet typed.", differences: [line] }] }),
    `accepted-field-differences.json lists ${line}, which the check no longer finds. Remove it.`,
    "Remove each entry above from its file.",
  );
});

test("new and stale differences show together, new ones first", (t) => {
  const stale = `${MONITOR} response missing gone`;
  const schema = monitorSchema();
  schema.properties.plan = { type: "string" };

  assertFails(
    runCheck(t, monitorSpec(schema), { accepted: [{ reason: "Not yet typed.", differences: [stale] }] }),
    `${MONITOR} response missing plan`,
    `accepted-field-differences.json lists ${stale}, which the check no longer finds. Remove it.`,
    NEXT_STEP,
  );
});

const INVALID_STEP = "Fix accepted-field-differences.json in the format CONTRIBUTING.md shows under API fields.";
const EXAMPLE =
  "Write a method, a path, request or response, a kind and a field, such as GET /api/v1/monitors response enum monitors[].eventTypes[].";
const line = `${MONITOR} response missing plan`;
const invalidLists = [
  ["a list of groups is required", {}, "It must be a list of groups, each with a reason and differences."],
  ["a group holds only a reason and differences", [{ reason: "A reason." }], "Group 1 must hold a reason and differences, and nothing else."],
  ["a reason cannot be blank", [{ reason: " ", differences: [line] }], "Group 1 needs a non-empty reason."],
  ["a group needs a difference", [{ reason: "A reason.", differences: [] }], "Group 1 needs at least 1 difference."],
  ["a difference has the line form", [{ reason: "A reason.", differences: ["GET /a response gone b"] }], `Group 1 lists "GET /a response gone b". ${EXAMPLE}`],
  ["a difference appears once", [{ reason: "A reason.", differences: [line, line] }], `${line} appears more than once.`],
];

for (const [name, accepted, problem] of invalidLists) {
  test(`an invalid accepted file fails, since ${name}`, (t) => {
    assertFails(
      runCheck(t, monitorSpec(), { accepted }),
      `accepted-field-differences.json is not valid. ${problem}`,
      INVALID_STEP,
    );
  });
}

test("a missing accepted file fails, and so does broken JSON", (t) => {
  const sandbox = prepare(t);
  sandbox.write("spec.json", JSON.stringify(monitorSpec()));
  fs.rmSync(path.join(sandbox.repo, "accepted-field-differences.json"));
  const env = { XQUIK_OPENAPI_SPEC: "spec.json" };

  assertFails(
    sandbox.run("scripts/api-fields", [], env),
    "accepted-field-differences.json is not valid. The file cannot be read.",
    INVALID_STEP,
  );

  sandbox.write("accepted-field-differences.json", "[");
  const broken = sandbox.run("scripts/api-fields", [], env);

  assert.match(broken.stderr, /^accepted-field-differences\.json is not valid\. Its text breaks the JSON syntax\./);
  assert.equal(broken.status, 1);
});

test("an excluded operation is not compared", (t) => {
  const schema = monitorSchema();
  schema.properties.plan = { type: "string" };
  const excluded = [{ reason: "Needs a dashboard sign-in.", operations: ["GET /api/v1/monitors/{monitorId}"] }];

  assertPasses(runCheck(t, monitorSpec(schema), { excluded }), "0 operations");
});

test("an excluded operation the API no longer has fails as stale", (t) => {
  const excluded = [{ reason: "Needs a dashboard sign-in.", operations: ["GET /api/v1/gone"] }];

  assertFails(
    runCheck(t, monitorSpec(), { excluded }),
    "excluded-operations.json lists GET /api/v1/gone, which the API no longer has. Remove it.",
    "Remove each entry above from its file.",
  );
});

test("an invalid excluded file fails and names its format", (t) => {
  assertFails(
    runCheck(t, monitorSpec(), { excluded: [{ reason: "A reason.", operations: ["/no-method"] }] }),
    'excluded-operations.json is not valid. Group 1 lists "/no-method". Write a method and a path, such as GET /api/v1/api-keys.',
    "Fix excluded-operations.json in the format CONTRIBUTING.md shows under API fields.",
  );
});

test("a spec file that is absent or not JSON cannot be read", (t) => {
  const sandbox = prepare(t);
  const env = { XQUIK_OPENAPI_SPEC: "spec.json" };

  assertFails(sandbox.run("scripts/api-fields", [], env), `Could not read the API spec from spec.json. ${UNREADABLE_TAIL}`);

  sandbox.write("spec.json", "not json");

  assertFails(sandbox.run("scripts/api-fields", [], env), `Could not read the API spec from spec.json. ${UNREADABLE_TAIL}`);
});

const unexpectedSpecs = [
  ["a document that is not an object", []],
  ["no paths", { openapi: "3.1.0" }],
  ["a path item that is a reference", { paths: { "/a": { $ref: "#/x" } } }],
  ["a reference with no target", monitorSpec({ $ref: "#/components/schemas/Gone" })],
  ["a schema that is not an object", monitorSpec("text")],
  ["servers that are not a list", specOf({ "/a": { get: {} } }, { servers: "https://xquik.com" })],
];

for (const [name, spec] of unexpectedSpecs) {
  test(`a spec the check cannot read fails, with ${name}`, (t) => {
    assertFails(runCheck(t, spec), `The API spec from spec.json has a part the check cannot read. ${UNEXPECTED_TAIL}`);
  });
}

function runWithFetch(t, env) {
  const sandbox = prepare(t);
  const fake = path.join(root, "scripts/tests/fake-spec-fetch.mjs");
  const result = sandbox.run("scripts/api-fields", [], { NODE_OPTIONS: `--import=${fake}`, ...env });
  return { result, requests: sandbox.log("spec-requests") };
}

test("the public spec is the default source, and an empty variable means the default", (t) => {
  const body = JSON.stringify(monitorSpec());
  const { result, requests } = runWithFetch(t, {
    XQUIK_OPENAPI_SPEC: "",
    FAKE_SPEC_BODY: body,
    FAKE_SPEC_STATUS: "200",
  });

  assertPasses(result);
  assert.deepEqual(requests, ["https://xquik.com/openapi.json"]);
});

test("a URL in the variable is downloaded, and a failed download cannot be read", (t) => {
  const url = "http://127.0.0.1:9/openapi.json";
  const { result, requests } = runWithFetch(t, {
    XQUIK_OPENAPI_SPEC: url,
    FAKE_SPEC_BODY: "Server error",
    FAKE_SPEC_STATUS: "500",
  });

  assertFails(result, `Could not read the API spec from ${url}. ${UNREADABLE_TAIL}`);
  assert.deepEqual(requests, [url]);
});

const MONITOR_MODEL = `${SOURCE}/Models/Monitors/Monitor.cs`;
const USERNAME_READ = 'this._rawData.GetNotNullClass<string>("username")';

function lineAfter(text, needle) {
  return text.slice(0, text.indexOf(needle)).split("\n").length + 1;
}

test("a property the check cannot read names its file and line", (t) => {
  const expected = lineAfter(readSource(MONITOR_MODEL), "public required string Username");
  const result = runCheck(t, monitorSpec(), {
    edits: { [MONITOR_MODEL]: (text) => text.replace(USERNAME_READ, "this._rawData.GetNotNullClass<string>(Key)") },
  });

  assertFails(
    result,
    `${MONITOR_MODEL}:${expected} declares the property Username, which the check cannot read.`,
    SDK_FORM_STEP,
  );
});

test("a type the check cannot read names its file and line", (t) => {
  const expected = lineAfter(readSource(MONITOR_MODEL), "public required string Username");
  const result = runCheck(t, monitorSpec(), {
    edits: {
      [MONITOR_MODEL]: (text) => text.replace(USERNAME_READ, 'this._rawData.GetNotNullClass<Mystery>("username")'),
    },
  });

  assertFails(result, `${MONITOR_MODEL}:${expected} uses the type Mystery, which the check cannot read.`, SDK_FORM_STEP);
});

test("a request the check cannot read names its file", (t) => {
  const service = `${SOURCE}/Services/MonitorService.cs`;
  const result = runCheck(t, monitorSpec(), {
    edits: { [service]: (text) => text.replace("Method = HttpMethod.Get,", "Method = PickMethod(),") },
  });

  assert.match(result.stderr, /^src\/XTwitterScraper\/Services\/MonitorService\.cs:\d+ builds a request the check cannot read\.\n/);
  assert.equal(result.status, 1);
});

test("an enum with no readable wire values names its file", (t) => {
  const file = `${SOURCE}/Models/EventType.cs`;
  const result = runCheck(t, monitorSpec(), {
    edits: { [file]: (text) => text.replaceAll(/"[^"]+" => EventType\.\w+,/g, "") },
  });

  assert.match(result.stderr, /^src\/XTwitterScraper\/Models\/EventType\.cs:\d+ declares the enum EventType, whose wire values the check cannot read\.\n/);
  assert.equal(result.status, 1);
});

test("a comment or a brace in a string does not change what the check reads", (t) => {
  const result = runCheck(t, monitorSpec(), {
    edits: {
      [MONITOR_MODEL]: (text) =>
        text
          .replace(
            "public required string ID",
            'const string Brace = "{";\n    const char Open = \'{\';\n    // public required string Ghost { get { return this._rawData.GetNotNullClass<string>("ghost"); } }\n    /* } */\n    public required string ID',
          ),
    },
  });

  assertPasses(result);
});

test("an obsolete property stays out of extra, in a response and in a body, and still compares when listed", (t) => {
  const obsolete = (text, property) =>
    text.replace(`public required ${property}`, `[System::Obsolete("Use another.")]\n    public required ${property}`);
  const edits = {
    [MONITOR_MODEL]: (text) => obsolete(text, "string Username"),
    [`${SOURCE}/Models/Monitors/MonitorCreateParams.cs`]: (text) => obsolete(text, "string Username"),
  };
  const dropped = monitorSchema();
  delete dropped.properties.username;
  dropped.required = dropped.required.filter((name) => name !== "username");
  const listed = monitorSchema();
  listed.properties.username.type = ["string", "null"];

  assertPasses(runCheck(t, monitorSpec(dropped), { edits }));
  assertFails(runCheck(t, monitorSpec(listed), { edits }), `${MONITOR} response nullable username`, NEXT_STEP);
  assertFails(
    runCheck(t, specOf({ "/api/v1/monitors": { post: { responses: {} } } }), { edits }),
    "POST /api/v1/monitors request extra eventTypes",
    NEXT_STEP,
  );
});

test("the real SDK reads through unions, multipart bodies, inherited fields, constants and numeric enums", (t) => {
  const object = (properties) => ({ type: "object", properties });
  const body = (properties) => ({ requestBody: { content: { "application/json": { schema: object(properties) } } } });
  const response = (schema) => ({ responses: { 200: { content: { "application/json": { schema } } } } });
  const spec = specOf({
    "/api/v1/compose": { post: { ...body({ step: { type: "string" } }), responses: {} } },
    "/api/v1/support/tickets": {
      post: {
        requestBody: { content: { "multipart/form-data": { schema: object({ subject: { type: "string" } }) } } },
        responses: {},
      },
    },
    "/api/v1/x/tweets/{id}/replies": { get: response(object({})) },
    "/api/v1/draws/{id}/export": {
      get: { parameters: [{ name: "type", in: "query", schema: { type: "string", enum: ["other"] } }], responses: {} },
    },
    "/api/v1/guest-wallets/status": { get: response(object({ poll_after_seconds: { type: "integer", enum: [5] } })) },
    "/api/v1/x/communities": { post: response(object({ object: { const: "other" } })) },
  });
  const { stderr, status } = runCheck(t, spec, { wholeSdk: true });
  const lines = stderr.split("\n");

  assert.equal(status, 1);
  for (const expected of [
    "POST /api/v1/compose request extra topic",
    "POST /api/v1/support/tickets request extra body",
    "GET /api/v1/x/tweets/{id}/replies response extra diagnostic",
    "GET /api/v1/x/tweets/{id}/replies response extra tweets",
    "GET /api/v1/draws/{id}/export request enum type",
    "POST /api/v1/x/communities response enum object",
    "GET /api/v1/guest-wallets/status response enum poll_after_seconds",
  ]) {
    assert.equal(lines.includes(expected), true, `${expected} in\n${stderr}`);
  }
  assert.equal(lines.some((text) => text.startsWith("src/")), false, stderr);
});

test("the check reads every request in the repository's services, with no unread code", () => {
  const { shapes, problems } = sdkShapes(root);
  const services = path.join(root, SOURCE, "Services");
  const requests = fs
    .readdirSync(services, { recursive: true })
    .filter((name) => String(name).endsWith(".cs"))
    .flatMap((name) => [...fs.readFileSync(path.join(services, String(name)), "utf8").matchAll(/HttpRequest</g)]);

  assert.deepEqual(problems, []);
  assert.equal(shapes.size, requests.length);
  assert.equal(shapes.get("GET /api/v1/monitors/{}").response.props.get("username").required, true);
  assert.equal(shapes.get("POST /api/v1/monitors").body.props.get("username").required, true);
});

test("the repository's reviewed lists are valid and name real kinds", () => {
  const accepted = ACCEPTED.read(root);
  const excluded = EXCLUDED.read(root);

  assert.equal([...accepted].every((entry) => entry.split(" ").length === 5), true);
  assert.equal(excluded.size > 0, true);
});
