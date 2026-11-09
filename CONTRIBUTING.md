# Contributing

Read [GOVERNANCE.md](GOVERNANCE.md) before proposing major changes.

Follow the shared [Xquik contribution policy][contribution-policy].

## Set up

Install .NET SDK 10.0.400, the .NET 8 runtime, Node.js, the CodeQL CLI, `uv`, `shellcheck`, `unzip`, and `zip`.

Windows also runs the .NET Framework 4.7.2 test target.

Restore pinned tools and locked dependencies.

```sh
./scripts/bootstrap
```

Never commit credentials or runtime environment files.

## Generated code

Most SDK files come from the public OpenAPI contract.

Preserve generated method names and response contracts.

Avoid generated-file changes when a generator fix exists.

Place stable examples outside generated directories.

## Verify changes

Run focused tests while editing.

Run every gate before requesting review.

```sh
bin/check-local
```

It runs the [API fields](#api-fields) check, restores locked dependencies, then runs lint, shellcheck, the script tests, REUSE, build, tests, coverage, the dependency audit, the reproducible package check, and CodeQL security-extended queries.
It stops at the first failure and says what to fix.
REUSE 6.2.0 runs through `uvx` on every run.
CodeQL and REUSE are required, and any finding fails the run.
A file that CodeQL can read only in part, such as one with a syntax error, fails it too.
CodeQL restores and builds a copy of the source files, so the restore output in your working tree stays usable.

The dependency audit fails on any vulnerable package in the shipped library.
It also fails on a test-only finding unless `audit-exceptions.json` lists it and no fix exists.
Severity never excuses a finding.
Each entry names the advisory, the package path, the reason, and a recheck date at most 30 days out.
A listed finding blocks again on its recheck date, and as soon as a fixed version exists.

The script tests in `scripts/tests` run each script in a throwaway folder with fake commands.
Run them alone with `./scripts/test-scripts`.

With push access, it posts the `xquik-local-checks` commit status for a clean, pushed `HEAD`.
Pass `--no-status` to skip the status.

Run a single gate with its script in `scripts/`.

Coverage must remain at least 90% for lines and 80% for branches.

Skipped tests are forbidden.

Add regression tests for every corrected defect.

Service tests accept literal loopback IPv4 only.

This guard prevents tests from mutating remote services.

## API fields

The first check in `bin/check-local` fails when the SDK's fields differ from the API spec.
Run it alone with `./scripts/api-fields`. It needs Node.js and no build.

For each operation that both the API spec and the SDK have, it compares the query parameters and the JSON, multipart or form body fields of the request, and the JSON body of each 2xx response, at every depth.
It reads the spec's fields through `$ref`, `allOf`, `oneOf` and `anyOf`.
It reads the SDK's operations from the request each class in `src/XTwitterScraper/Services` builds, and the fields from the params and response types that request names in `src/XTwitterScraper/Models`.
Path parameters, header parameters, free-form objects and fields under an object that allows extra properties stay out.
A field missing on 1 side counts once, at its top position.
Operations that only the spec or only the SDK has are not compared.

Each difference prints as 1 line with the method, the full path, `request` or `response`, a kind and the field's JSON path.

```text
GET /api/v1/monitors response enum monitors[].eventTypes[]
```

- `missing` means the spec has the field and the SDK does not. Add it to the SDK.
- `extra` means the SDK has a field the spec does not list. Keep it when callers may use it, and accept it. A property marked `[Obsolete]` stays out of `extra`, since it is kept only for old code.
- `enum` means both sides list values and the values differ. Add the missing values, and accept values the SDK keeps.
- `required` means the spec's required list and the C# `required` modifier differ. Fix it only when the change keeps old calls and old responses working.
- `nullable` means the spec and the property's null handling differ. A `required` property reads null only when its type ends in `?`. An optional property reads null only when its setter has no null guard. Fix it under the same rule.

Fixes stay additive. Never remove or rename a public field or parameter to satisfy the check. Accept it instead.

A line that starts with a file and a line number means the check cannot read that C# code. Write it in the style of the generated code around it, or teach `scripts/lib/api-fields/sdk.mjs` the new form.

`accepted-field-differences.json` holds the reviewed differences the SDK keeps, in groups with a non-empty `reason`.
A difference appears at most once.
An accepted line the check no longer finds fails as stale, so remove it in the change that fixes it.
The file started as the list of differences on the day the check landed, and each catch-up shrinks it.

```json
[
  {
    "reason": "Deprecated alias of minLikes, which the API still reads. The SDK keeps it so existing calls still compile.",
    "differences": ["GET /api/v1/x/tweets/search request extra minFaves"]
  }
]
```

`excluded-operations.json` lists operations the SDK leaves out on purpose, in groups with a `reason` and `operations`.
The check does not compare them, and it fails on an entry the API no longer has.

The check reads the spec from https://xquik.com/openapi.json.
Set `XQUIK_OPENAPI_SPEC` to a local file path or another URL to check against another copy.

## Use the repository from source

Add a directory reference from another project.

```sh
dotnet add reference /path/to/sdk/src/XTwitterScraper
```

## Submit changes

Use clear Conventional Commit subjects and sign commits with `git commit --signoff`.
Follow the shared [review policy][review-policy].

## Report security issues

Never disclose suspected vulnerabilities in public issues.

Follow [SECURITY.md](SECURITY.md) for private reporting.

## Releases

Maintainers release from a local machine with `bin/release-local` after the release commit reaches `main`.

The script refuses unless `main` is clean and matches `origin/main`.
It reads the version from the project file and refuses when its `v*` tag already exists.
It runs `bin/check-local` and the dependency audit, then builds the package.
It uploads the package to NuGet.org, or skips the upload when NuGet.org already has that version.
Last, it pushes the tag and creates the GitHub release from the matching CHANGELOG section.

Run `bin/release-local --dry-run` first.
It runs every check, builds the packages, and prints the listing fields and the file lists.
It uploads, tags, and releases nothing.

The NuGet API key comes from a macOS Keychain item.
Set `NUGET_KEYCHAIN_SERVICE` on the release machine to that item's service name.
A release stops at once when the variable is unset or empty.
A dry run does not need it.

[contribution-policy]: https://github.com/Xquik-dev/.github/blob/main/CONTRIBUTING.md
[review-policy]: https://github.com/Xquik-dev/.github/blob/main/REVIEWING.md

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
