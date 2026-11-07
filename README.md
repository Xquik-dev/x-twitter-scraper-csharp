# Twitter Scraper & X API C# SDK by Xquik

Use this X (Twitter) scraper C# SDK by Xquik to search tweets & posts.
Async methods return typed models in .NET apps.
Public reads need no X developer account.

Xquik is the world's fastest and cheapest X (Twitter) scraper service with the most complete X (Twitter) data.
Most other Apify Actors charge before filtering or deduplication.
Xquik charges only for delivered, unique, filter-matching results and never pads rows.
Xquik is independent and not affiliated with X Corp.

<!-- trust:win:start -->
The Xquik REST API read 45 tweets per second at $0.15 per 1,000 on 2026-10-15. The fastest of 4 rival Actors read 12.5 per second. The cheapest cost $0.173 per 1,000. [Compare each run](https://xquik.com/benchmarks#benchmark-x-tweet-scraper).
<!-- trust:win:end -->

## Install the Twitter API C# & .NET SDK

The SDK requires .NET Standard 2.0 or later.

Install the latest package from [NuGet](https://www.nuget.org/packages/XTwitterScraper).

```bash
dotnet add package XTwitterScraper
```

## Scrape tweets with the C# Twitter API

Create an API key in the [Xquik dashboard](https://dashboard.xquik.com) and export it.

```bash
export X_TWITTER_SCRAPER_API_KEY="your-api-key"
```

This program prints 10 recent X (Twitter) posts from 1 account.

```csharp
using System;
using XTwitterScraper;
using XTwitterScraper.Models.X.Tweets;

XTwitterScraperClient client = new();

TweetSearchParams parameters = new()
{
    Q = "from:elonmusk",
    Limit = 10,
};

var paginatedTweets = await client.X.Tweets.Search(parameters);

Console.WriteLine(paginatedTweets);
```

Next, read the [C# SDK guide](https://docs.xquik.com/sdks/csharp-x-api-sdk) or the [REST API reference](https://docs.xquik.com/api-reference/overview).

<!-- trust:start -->

## Benchmarks & usage

[![XTwitterScraper downloads on NuGet](https://img.shields.io/endpoint?url=https%3A%2F%2Fxquik.com%2Fbadges%2Fnuget-xtwitterscraper.json)](https://www.nuget.org/packages/XTwitterScraper)
[![Twitter API p99 server read time](https://img.shields.io/endpoint?url=https%3A%2F%2Fxquik.com%2Fbadges%2Frest-p99.json)](https://xquik.com/benchmarks#speed)
[![OpenSSF Best Practices](https://www.bestpractices.dev/projects/13733/badge)](https://www.bestpractices.dev/projects/13733)

- 2,000+ downloads of XTwitterScraper on NuGet ([source](https://www.nuget.org/packages/XTwitterScraper)) <!-- trust:nuget-xtwitterscraper 2053 -->
- 6.4 s p99 REST API server read time over 7 days, failed reads included ([source](https://xquik.com/benchmarks#speed)) <!-- trust:rest-p99 6317 -->
- This repo meets the OpenSSF Best Practices passing criteria ([source](https://www.bestpractices.dev/projects/13733)) <!-- trust:openssf-x-twitter-scraper-csharp 1 -->

Checked on 2026-11-07. See each number with its date & source on [xquik.com/benchmarks](https://xquik.com/benchmarks) or as [JSON](https://xquik.com/trust.json).

<!-- trust:end -->

## Common X (Twitter) tasks

| Task | REST route | Workflow note |
| --- | --- | --- |
| Search tweets without the X API | `GET /x/tweets/search` | Use keywords or advanced Twitter search operators. |
| Read an X (Twitter) profile timeline | `GET /x/users/{id}/tweets` | Paginate bounded timeline results. |
| Scrape Twitter followers | `GET /x/users/{id}/followers` | Use an extraction for complete datasets. |
| Scrape following accounts | `GET /x/users/{id}/following` | Use an extraction for complete datasets. |
| Read a home timeline | `GET /x/timeline` | Approve this private read. |
| Read lists or communities | `/x/lists/*`, `/x/communities/*` | Use the typed nested services. |
| Export large X (Twitter) datasets | `POST /extractions` | Poll status, then download results. |
| Monitor an account | `POST /monitors` | Deliver events through HMAC webhooks. |
| Post a tweet or reply | `POST /x/tweets` | Confirm the account and payload. |

## Verify a release

[NuGet.org adds a repository signature](https://learn.microsoft.com/en-us/nuget/api/repository-signatures-resource) to every package.
Check that signature on a package downloaded from NuGet.org.

```bash
dotnet nuget verify --all xtwitterscraper.VERSION.nupkg
```

## Client configuration

`new()` reads the environment variables in the table below.
Set credentials directly when environment variables do not fit.

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new()
{
    ApiKey = "My API Key",
    BearerToken = "My Bearer Token",
};
```

You can combine environment variables and explicit properties.

| Property      | Environment variable             | Required | Default value                |
| ------------- | -------------------------------- | -------- | ---------------------------- |
| `ApiKey`      | `X_TWITTER_SCRAPER_API_KEY`      | false    | -                            |
| `BearerToken` | `X_TWITTER_SCRAPER_BEARER_TOKEN` | false    | -                            |
| `BaseUrl`     | `X_TWITTER_SCRAPER_BASE_URL`     | true     | `"https://xquik.com/api/v1"` |

### Modify configuration

Call `WithOptions` to reuse connections with temporary settings.

```csharp
using System;

var account = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Account.Retrieve(parameters);

Console.WriteLine(account);
```

The [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) builds the modified options.
`WithOptions` leaves the original client or service unchanged.

## Requests & responses

`client.X.Tweets.Search` accepts `TweetSearchParams` and returns `Task<PaginatedTweets>`.

## Binary responses

Binary endpoints return `HttpResponse` instead of parsing the body.

```csharp
using System;
using XTwitterScraper.Models.Extractions;

ExtractionExportResultsParams parameters = new()
{
    ID = "id",
    Format = Format.Csv,
};

var response = await client.Extractions.ExportResults(parameters);

Console.WriteLine(response);
```

Use [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) to save content to any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0).

```csharp
using System.IO;

using var response = await client.Extractions.ExportResults(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.Create);
await contentStream.CopyToAsync(fileStream); // Accepts any Stream.
```

## Raw responses

Typed methods hide headers, status codes, and raw bodies.
Prefix any HTTP call with `WithRawResponse` to access them.

```csharp
var response = await client.WithRawResponse.Account.Retrieve();
var statusCode = response.StatusCode;
var headers = response.Headers;
```

Access the raw `HttpResponseMessage` through `RawMessage`.
Deserialize non-streaming responses when you need a typed model.

```csharp
using System;
using XTwitterScraper.Models.Account;

var response = await client.WithRawResponse.Account.Retrieve();
AccountRetrieveResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

API errors inherit from `XTwitterScraperApiException`.

| Status | Exception                                      |
| ------ | ---------------------------------------------- |
| 400    | `XTwitterScraperBadRequestException`           |
| 401    | `XTwitterScraperUnauthorizedException`         |
| 403    | `XTwitterScraperForbiddenException`            |
| 404    | `XTwitterScraperNotFoundException`             |
| 422    | `XTwitterScraperUnprocessableEntityException`  |
| 429    | `XTwitterScraperRateLimitException`            |
| 5xx    | `XTwitterScraper5xxException`                  |
| others | `XTwitterScraperUnexpectedStatusCodeException` |

All 4xx errors inherit from `XTwitterScraper4xxException`.
Networking errors use `XTwitterScraperIOException`.
Invalid response data uses `XTwitterScraperInvalidDataException`.
Every SDK exception inherits from `XTwitterScraperException`.

## Retries

The SDK retries these errors twice with exponential backoff.

- Connection errors
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx server errors

The API may override retry behavior.

Set `MaxRetries` on the client.

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { MaxRetries = 3 };
```

Override retries for one call with [`WithOptions`](#modify-configuration).

```csharp
using System;

var account = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Account.Retrieve(parameters);

Console.WriteLine(account);
```

## Timeouts

Requests time out after 1 minute by default.

Set `Timeout` on the client.

```csharp
using System;
using XTwitterScraper;

XTwitterScraperClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Override the timeout for one call with [`WithOptions`](#modify-configuration).

```csharp
using System;

var account = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Account.Retrieve(parameters);

Console.WriteLine(account);
```

## Proxies

Route requests through a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0).

```csharp
using System.Net;
using System.Net.Http;
using XTwitterScraper;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

XTwitterScraperClient client = new() { HttpClient = httpClient };
```

## Custom API fields

The SDK accepts API fields missing from its generated types.

### Request fields

Pass dictionaries for extra header, query, and body values.
Methods without request bodies accept only header and query dictionaries.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Models.X.Tweets;

TweetSearchParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented values override matching custom parameters.
    Limit = 10
};
```

Access raw values through `RawHeaderData`, `RawQueryData`, and `RawBodyData`.
Use `FromRawUnchecked` for unsupported values in required parameters.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Models.X.Tweets;

var parameters = TweetSearchParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>
    {
        {
            "q",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Response properties

Read undocumented response properties through `RawData`.

```csharp
using System.Text.Json;

var response = await client.X.Tweets.Search(parameters);
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Process value.
}
```

`RawData` contains the complete response as `IReadOnlyDictionary<string, JsonElement>`.

### Response validation

The SDK throws on unexpected response values only when you access their properties.
Call `Validate` to check the complete response immediately.

```csharp
var paginatedTweets = await client.X.Tweets.Search(parameters);
paginatedTweets.Validate();
```

Set `ResponseValidation` to validate every response.

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { ResponseValidation = true };
```

Validate one call with [`WithOptions`](#modify-configuration).

```csharp
using System;

var paginatedTweets = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .X.Tweets.Search(parameters);

Console.WriteLine(paginatedTweets);
```

## Questions

### Do I need an X developer account?

No. Public reads need only an Xquik API key.
Private reads & account actions need a connected X (Twitter) account.

### Is this the official X API?

No. Xquik runs its own REST API. This SDK calls that API, not the official X API.

## More Xquik tools

- [X (Twitter) scraper API & Twitter MCP server](https://github.com/Xquik-dev/x-twitter-scraper) with REST, MCP & Skill setup.
- Twitter API SDKs for [TypeScript](https://github.com/Xquik-dev/x-twitter-scraper-typescript), [Python](https://github.com/Xquik-dev/x-twitter-scraper-python), [Go](https://github.com/Xquik-dev/x-twitter-scraper-go) & [Java](https://github.com/Xquik-dev/x-twitter-scraper-java).
- Twitter API SDKs for [Ruby](https://github.com/Xquik-dev/x-twitter-scraper-ruby), [Kotlin](https://github.com/Xquik-dev/x-twitter-scraper-kotlin) & [PHP](https://github.com/Xquik-dev/x-twitter-scraper-php).
- [Twitter CLI & X CLI](https://github.com/Xquik-dev/x-twitter-scraper-cli) for terminal workflows.
- [Twitter advanced search operators](https://github.com/Xquik-dev/x-twitter-advanced-search) with tested examples.
- X (Twitter) agent plugins for [OpenClaw](https://github.com/Xquik-dev/tweetclaw) & [Hermes Agent](https://github.com/Xquik-dev/hermes-tweet).
- X (Twitter) integrations for [n8n](https://github.com/Xquik-dev/n8n-nodes-xquik), [Prefect](https://github.com/Xquik-dev/prefect-xquik), [Haystack](https://github.com/Xquik-dev/xquik-haystack) & [Paperclip](https://github.com/Xquik-dev/paperclip-plugin-xquik).
- X (Twitter) integrations for [Terraform](https://github.com/Xquik-dev/terraform-provider-x-twitter-scraper), [Convex](https://github.com/Xquik-dev/xquik-convex), [Supabase](https://github.com/Xquik-dev/xquik-supabase) & [Strapi](https://github.com/Xquik-dev/strapi-plugin-xquik).
- Twitter MCP for [AI agents](https://github.com/Xquik-dev/xquik-mcp), [VS Code](https://github.com/Xquik-dev/xquik-vscode) & [Raycast](https://github.com/Xquik-dev/xquik-raycast).
- [Xquik X API & Twitter scraper](https://xquik.com).
- [Twitter API documentation](https://docs.xquik.com/api-reference/overview) and its [source](https://github.com/Xquik-dev/xquik-docs).

## Semantic versioning

The package follows [SemVer](https://semver.org/spec/v2.0.0.html).
Before v1.0, minor releases may change undocumented behavior.
Review the release notes before you upgrade between minor versions.

## Project policies

Read [Contributing](CONTRIBUTING.md), [Governance](GOVERNANCE.md) & [Security](SECURITY.md).
See [OpenSSF evidence](OPENSSF.md) for verified controls and remaining blockers.
Open an [issue](https://github.com/Xquik-dev/x-twitter-scraper-csharp/issues) for questions, bugs or suggestions.

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
