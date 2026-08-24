# Contributing

Read [GOVERNANCE.md](GOVERNANCE.md) before proposing major changes.

Follow the shared [Xquik contribution policy][contribution-policy].

## Set up

Install .NET SDK 10.0.400, the .NET 8 runtime, Node.js, and `unzip`.

Windows also runs the .NET Framework 4.7.2 test target.

Restore pinned tools and locked dependencies:

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

Run every gate before requesting review:

```sh
./scripts/lint
./scripts/test
./scripts/coverage
./scripts/audit
uvx --from reuse==5.1.1 reuse lint
./scripts/check-reproducible
```

Coverage must remain at least 90% for lines and 80% for branches.

Skipped tests are forbidden.

Add regression tests for every corrected defect.

Service tests accept literal loopback IPv4 only.

This guard prevents tests from mutating remote services.

## Use the repository from source

Add a directory reference from another project:

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

Publish an immutable `v*` release after its commit reaches `main`.

Verify the tag, changelog, audit, licensing, and reproducible package.

[contribution-policy]: https://github.com/Xquik-dev/.github/blob/main/CONTRIBUTING.md
[review-policy]: https://github.com/Xquik-dev/.github/blob/main/REVIEWING.md

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
