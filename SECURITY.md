# Security Policy

## Supported Versions

Security fixes target the latest published release.

Upgrade before reporting behavior from an older release.

## Report A Vulnerability

Use [GitHub private vulnerability reporting][private-report].

Email [support@xquik.com](mailto:support@xquik.com) when GitHub is unavailable.

Do not open a public issue.

Include affected versions, impact, reproduction steps, and suggested mitigations.

Remove credentials, personal data, and private service details.

We aim to acknowledge reports within 3 business days.

We aim to provide a status update within 7 business days.

We coordinate disclosure after confirming and fixing the issue.

## Security Boundaries

This SDK builds requests and parses documented API responses.

Applications control credentials, base URLs, transports, retries, and middleware.

Only send credentials to trusted HTTPS endpoints.

Custom HTTP clients must disable unsafe cross-origin redirects.

Treat response data and webhook payloads as untrusted input.

The hosted Xquik service has a separate operational boundary.

This repository excludes private infrastructure and service implementation details.

## Threat Model

Relevant threats include:

- Credential leakage through logs, URLs, middleware, or debug output.
- Redirects or custom base URLs sending credentials to untrusted hosts.
- Malformed responses causing unsafe parsing or resource exhaustion.
- Retrying consumed streams and producing incomplete uploads.
- Dependency, generator, workflow, and release supply-chain compromise.

Controls include loopback-only tests, strict parsing, CodeQL, and analyzers.

CI also verifies dependencies, licenses, coverage, and reproducible packages.

## Response Process

Maintainers triage reports privately.

Confirmed fixes use private coordination when an embargo is needed.

Maintainers add regression tests and run every required gate.

Releases document impact without exposing exploit details prematurely.

Maintainers publish an advisory when coordinated disclosure permits.

[private-report]: https://github.com/Xquik-dev/x-twitter-scraper-csharp/security/advisories/new

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
