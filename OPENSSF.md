# OpenSSF Best Practices Evidence

This register tracks the Gold assessment for this repository.

The official entry is [bestpractices.dev project 13733][badge].

Assessment date: 2026-07-23.

## Eligibility

This public C# SDK is active and released.

It is eligible for the OpenSSF Best Practices badge.

No OpenSSF-defined ineligibility applies.

## Verified Technical Controls

| Area | Evidence |
| --- | --- |
| License | Apache-2.0 and REUSE 3.3 metadata |
| Contribution process | DCO sign-off and independent review rules |
| Governance | Public roles, decisions, releases, and continuity policy |
| Security reporting | Private reporting, response targets, boundaries, and threat model |
| Runtime compatibility | .NET 8 and .NET Framework 4.7.2 tests |
| Functional tests | 6,605 tests with no skips |
| Line coverage | `./scripts/coverage` enforces 90% |
| Branch coverage | `./scripts/coverage` enforces 80% |
| Static analysis | Compiler analyzers, formatting checks, and CodeQL |
| Dependency review | Dependabot, locked restores, vulnerability audit, and license policy |
| Licensing gate | Pinned REUSE action checks every repository file |
| Reproducibility | 2 normalized NuGet builds must have identical bytes |
| CI | Pull requests and pushes run pinned, least-privilege workflows |
| Two-factor authentication | The Xquik-dev organization requires 2FA |

The current suite covers 45,606 of 48,372 executable lines.

That result is 94.28% line coverage.

It covers 10,711 of 12,007 branches, or 89.20%.

Coverage includes generated models, services, and the runtime core.

Loopback service tests cannot contact remote hosts.

The default transport blocks redirects that could forward credentials.

Multipart request bodies are not retried after consumption.

## Outstanding Gold Blockers

Human and organizational evidence remains incomplete.

Do not claim Gold while any mandatory criterion remains unmet.

| Gold Requirement | Current Evidence | Required Action |
| --- | --- | --- |
| Access continuity | Public evidence does not prove 2 release-capable maintainers | Grant and verify another maintainer's access |
| Bus factor | Git history shows one significant contributor | Add another significant contributor |
| Unassociated contributors | Fewer than 2 qualifying contributors are independent | Accept qualifying external contributions |
| Independent review | History does not prove 50% qualifying review coverage | Require and record independent reviews |
| Human security review | No completed review exists within 5 years | Commission and publish a scoped review |

This remediation pull request needs a different human reviewer.

## Maintenance

Run these evidence commands before releases:

```sh
./scripts/lint
./scripts/test
./scripts/coverage
./scripts/audit
reuse lint
./scripts/check-reproducible
```

Reassess the register before every major release.

Update bestpractices.dev only with public evidence.

[badge]: https://www.bestpractices.dev/projects/13733

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
