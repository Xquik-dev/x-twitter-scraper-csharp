# Contributing

Thank you for improving the Xquik C# SDK.

Read [GOVERNANCE.md](GOVERNANCE.md) before proposing major changes.

Follow the shared [Xquik contribution policy][contribution-policy].

## Set Up

Install .NET SDK 10.0.301, the .NET 8 runtime, Node.js, and `unzip`.

Windows also runs the .NET Framework 4.7.2 test target.

Restore pinned tools and locked dependencies:

```sh
./scripts/bootstrap
```

Never commit credentials or runtime environment files.

## Generated Code

Most SDK files come from the public OpenAPI contract.

Preserve generated method names and response contracts.

Avoid generated-file changes when a generator fix exists.

Place stable examples outside generated directories.

## Verify Changes

Run focused tests while editing.

Run every gate before requesting review:

```sh
./scripts/lint
./scripts/test
./scripts/coverage
./scripts/audit
reuse lint
./scripts/check-reproducible
```

Line coverage must remain at least 90%.

Branch coverage must remain at least 80%.

Skipped tests are forbidden.

Add regression tests for every corrected defect.

Service tests accept literal loopback IPv4 only.

This guard prevents tests from mutating remote services.

## Use The Repository From Source

Add a directory reference from another project:

```sh
dotnet add reference /path/to/sdk/src/XTwitterScraper
```

## Submit Changes

Keep pull requests focused.

Explain user-visible behavior and public contract effects.

Link relevant issues and public API contracts.

Use clear Conventional Commit subjects when practical.

Sign every commit with the Developer Certificate of Origin:

```sh
git commit --signoff
```

Another human must review maintainer-authored, nontrivial changes.

Reviewers follow the shared [review policy][review-policy].

Address every review comment before merging.

## Report Security Issues

Never disclose suspected vulnerabilities in public issues.

Follow [SECURITY.md](SECURITY.md) for private reporting.

## Releases

Publish an immutable `v*` release after its commit reaches `main`.

Verify the tag, changelog, audit, licensing, and reproducible package.

[contribution-policy]: https://github.com/Xquik-dev/.github/blob/main/CONTRIBUTING.md
[review-policy]: https://github.com/Xquik-dev/.github/blob/main/REVIEWING.md

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
