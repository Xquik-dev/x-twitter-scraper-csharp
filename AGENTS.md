# X Twitter Scraper C# SDK maintainer instructions

This repository is public. Treat every committed file as public.

## Rules

- Apply `/unslop` to every output: messages, PRs, docs, comments, and commit
  messages. Use short plain sentences, active voice, and sentence case
  headings. Never use em dashes.
- Never commit secrets, tokens, cookies, private screenshots, or private
  implementation details. Never name nonpublic services, pricing units, or
  vendor architecture.
- Never use GitHub Actions and never use GitHub trusted publishing. Do not add
  or extend workflow files. Publish the NuGet package from a local or authorized
  release runner with the registry credential read from the macOS Keychain
  inside the publish command; remove the existing workflows once that path
  works.
- Keep changes to what the task asks for. Report unrelated findings in the PR
  instead of fixing them in the same change.
- Run `scripts/format`, `scripts/lint`, `scripts/test`, `scripts/coverage`, and `scripts/check-reproducible` before committing. Do not
  weaken, suppress, or bypass any check.
- Work autonomously through the whole task: proceed on reversible steps the
  request implies, stop only for destructive actions or genuine scope changes,
  and finish rather than announce the next step.
- Deliver through a short-lived `claude/<topic>` or `codex/<topic>` branch and
  a PR merged right away. Direct pushes to the default branch are rejected.
- Include the legal line in READMEs and product guides:
  `Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.`
