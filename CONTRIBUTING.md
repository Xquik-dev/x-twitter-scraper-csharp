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

It restores locked dependencies, then runs lint, shellcheck, the script tests, REUSE, build, tests, coverage, the dependency audit, the reproducible package check, and CodeQL security-extended queries.
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
