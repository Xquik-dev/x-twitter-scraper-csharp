# OpenSSF Best Practices evidence

This register tracks the Gold assessment for this repository.

The official entry is [bestpractices.dev project 13733][badge].

Assessment date: 2026-07-23.

## Eligibility

This active, released C# SDK meets the OpenSSF eligibility rules.

## Verified technical controls

| Area | Evidence |
| --- | --- |
| License | Apache-2.0 and REUSE 3.3 metadata |
| Contribution process | DCO sign-off and independent review rules |
| Governance | Public roles, decisions, releases, and continuity policy |
| Security reporting | Private reporting, response targets, boundaries, and threat model |
| Runtime compatibility | .NET 8 and .NET Framework 4.7.2 tests |
| Functional tests | 7,103 tests with no skips |
| Line coverage | `./scripts/coverage` enforces 90% |
| Branch coverage | `./scripts/coverage` enforces 80% |
| Static analysis | Compiler analyzers, formatting checks, and CodeQL |
| Dependency review | Dependabot, locked restores, vulnerability audit, and license policy |
| Licensing gate | Pinned REUSE action checks every repository file |
| Reproducibility | 2 normalized NuGet builds must have identical bytes |
| CI | Pull requests and pushes run pinned, least-privilege workflows |
| Two-factor authentication | The Xquik-dev organization requires 2FA |

The current suite covers 49,965 of 52,555 executable lines.

That result is 95.07% line coverage.

It covers 11,262 of 12,475 branches, or 90.27%.

Coverage includes generated models, services, and the runtime core.

Loopback service tests cannot contact remote hosts.

The default transport blocks redirects that could forward credentials.

Multipart request bodies are not retried after consumption.

## Verified release provenance

Release `v0.6.1` points to commit `96c7c4bced1bc217cf8e89a4786338725866028a`.
Its GitHub-hosted publish workflow attested `XTwitterScraper.0.6.1.nupkg`.
The asset, SLSA subject, and local SHA-256 match `207c6c76eb240e9c64def34cd51d5973998327e76892aa391fbf44b32b4f39d0`.
The documented verification command succeeds for the exact tag and workflow.

## Outstanding Gold blockers

Human and organizational evidence remains incomplete.

Do not claim Gold while any mandatory criterion remains unmet.

| Gold requirement | Current evidence | Required action |
| --- | --- | --- |
| Access continuity | Public evidence does not prove 2 release-capable maintainers | Grant and verify another maintainer's access |
| Bus factor | Git history shows one significant contributor | Add another significant contributor |
| Unassociated contributors | Fewer than 2 qualifying contributors are independent | Accept qualifying external contributions |
| Independent review | History does not prove 50% qualifying review coverage | Require and record independent reviews |
| Human security review | No completed review exists within 5 years | Commission and publish a scoped review |

Gold eligibility still requires review by a different human.

## Maintenance

Run these evidence commands before releases:

```sh
./scripts/lint
./scripts/test
./scripts/coverage
./scripts/audit
uvx --from reuse==5.1.1 reuse lint
./scripts/check-reproducible
gh attestation verify PACKAGE \
  --repo Xquik-dev/x-twitter-scraper-csharp \
  --signer-workflow Xquik-dev/x-twitter-scraper-csharp/.github/workflows/publish-nuget.yml \
  --source-ref refs/tags/vVERSION \
  --deny-self-hosted-runners
```

Reassess the register before every major release.

Update bestpractices.dev only with public evidence.

[badge]: https://www.bestpractices.dev/projects/13733

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
