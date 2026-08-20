# Xquik C# SDK: Twitter Search, Followers & X Automation

[![OpenSSF Best Practices](https://www.bestpractices.dev/projects/13733/badge)](https://www.bestpractices.dev/projects/13733)
[![CI](https://github.com/Xquik-dev/x-twitter-scraper-csharp/actions/workflows/ci.yml/badge.svg)](https://github.com/Xquik-dev/x-twitter-scraper-csharp/actions/workflows/ci.yml)

Use the Xquik C# SDK for Twitter search, timelines, profiles, and followers.
Download media, manage webhooks, and run X automation from .NET.

## C# Client or REST

The typed NuGet package calls the documented Xquik REST API.
It does not call or emulate the official X API.
Use the SDK for asynchronous, typed requests from .NET services.
Reuse the configurable `HttpClient` for shared transport settings.
Call REST directly when a NuGet dependency does not fit.

Read the [C# SDK guide](https://docs.xquik.com/sdks/csharp) or [API guide](https://docs.xquik.com/api-reference/overview).

## Common X Data Tasks

| Task | REST Route | Workflow Note |
| --- | --- | --- |
| Search tweets | `GET /x/tweets/search` | Use keywords or advanced Twitter search operators. |
| Extract profile tweets | `GET /x/users/{id}/tweets` | Paginate bounded timeline results. |
| Export followers | `GET /x/users/{id}/followers` | Use an extraction for complete datasets. |
| Export following accounts | `GET /x/users/{id}/following` | Use an extraction for complete datasets. |
| Read a home timeline | `GET /x/timeline` | Approve this private read. |
| Read lists or communities | `/x/lists/*`, `/x/communities/*` | Use the typed nested services. |
| Export large datasets | `POST /extractions` | Poll status, then download results. |
| Monitor an account | `POST /monitors` | Deliver events through HMAC webhooks. |
| Post or reply | `POST /x/tweets` | Confirm the account and payload. |

The [API reference](https://docs.xquik.com/api-reference/overview) maps routes to typed services and models.

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/XTwitterScraper):

```bash
dotnet add package XTwitterScraper --version 0.6.1
```

## Verify a Release

Verify a GitHub release package before using it:

```bash
release_tag=vVERSION
package_version="${release_tag#v}"

gh release download "$release_tag" \
  --repo Xquik-dev/x-twitter-scraper-csharp \
  --pattern "XTwitterScraper.$package_version.nupkg"

gh attestation verify "XTwitterScraper.$package_version.nupkg" \
  --repo Xquik-dev/x-twitter-scraper-csharp \
  --signer-workflow Xquik-dev/x-twitter-scraper-csharp/.github/workflows/publish-nuget.yml \
  --source-ref "refs/tags/$release_tag" \
  --deny-self-hosted-runners
```

Require the Xquik-dev repository and expected release workflow.

GitHub verifies the artifact digest, signer identity, and transparency proof.

[NuGet.org applies repository signatures][nuget-signatures] to registry packages.

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

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

## Client Configuration

Configure the client using environment variables:

```csharp
using XTwitterScraper;

// Reads API key, bearer token, and base URL environment variables.
XTwitterScraperClient client = new();
```

Set credentials directly when environment variables do not fit:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new()
{
    ApiKey = "My API Key",
    BearerToken = "My Bearer Token",
};
```

Environment variables and explicit properties can be combined.

| Property      | Environment variable             | Required | Default value                |
| ------------- | -------------------------------- | -------- | ---------------------------- |
| `ApiKey`      | `X_TWITTER_SCRAPER_API_KEY`      | false    | -                            |
| `BearerToken` | `X_TWITTER_SCRAPER_BEARER_TOKEN` | false    | -                            |
| `BaseUrl`     | `X_TWITTER_SCRAPER_BASE_URL`     | true     | `"https://xquik.com/api/v1"` |

### Modify Configuration

Call `WithOptions` to reuse connections with temporary settings:

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

## Requests & Responses

Pass a `Params` instance to its client method.
The SDK returns a typed C# model.
`client.X.Tweets.Search` accepts `TweetSearchParams` and returns `Task<PaginatedTweets>`.

## Binary Responses

Binary endpoints return `HttpResponse` instead of parsing the body:

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

Use [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) to save content to any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0):

```csharp
using System.IO;

using var response = await client.Extractions.ExportResults(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.Create);
await contentStream.CopyToAsync(fileStream); // Accepts any Stream.
```

## Raw Responses

Typed methods hide headers, status codes, and raw bodies.
Prefix any HTTP call with `WithRawResponse` to access them:

```csharp
var response = await client.WithRawResponse.Account.Retrieve();
var statusCode = response.StatusCode;
var headers = response.Headers;
```

Access the raw `HttpResponseMessage` through `RawMessage`.
Deserialize non-streaming responses when you need a typed model:

```csharp
using System;
using XTwitterScraper.Models.Account;

var response = await client.WithRawResponse.Account.Retrieve();
AccountRetrieveResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error Handling

API errors inherit from `XTwitterScraperApiException`:

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

## Network Options

### Retries

The SDK retries these errors twice with exponential backoff:

- Connection errors
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx server errors

The API may override retry behavior.

Set `MaxRetries` on the client:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { MaxRetries = 3 };
```

Override retries for one call with [`WithOptions`](#modify-configuration):

```csharp
using System;

var account = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Account.Retrieve(parameters);

Console.WriteLine(account);
```

### Timeouts

Requests time out after 1 minute by default.

Set `Timeout` on the client:

```csharp
using System;
using XTwitterScraper;

XTwitterScraperClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Override the timeout for one call with [`WithOptions`](#modify-configuration):

```csharp
using System;

var account = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Account.Retrieve(parameters);

Console.WriteLine(account);
```

### Proxies

Route requests through a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

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

## Additional API Fields

The SDK accepts API fields missing from its generated types.

### Parameters

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
    Limit = 200
};
```

Access raw values through `RawHeaderData`, `RawQueryData`, and `RawBodyData`.
Use `FromRawUnchecked` for unsupported values in required parameters:

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

### Response Properties

Read undocumented response properties through `RawData`:

```csharp
using System.Text.Json;

var response = await client.X.Tweets.Search(parameters);
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Process value.
}
```

`RawData` contains the complete response as `IReadOnlyDictionary<string, JsonElement>`.

### Response Validation

Unexpected response values throw only when you access their properties.
Call `Validate` to check the complete response immediately:

```csharp
var paginatedTweets = await client.X.Tweets.Search(parameters);
paginatedTweets.Validate();
```

Set `ResponseValidation` to validate every response:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { ResponseValidation = true };
```

Validate one call with [`WithOptions`](#modify-configuration):

```csharp
using System;

var paginatedTweets = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .X.Tweets.Search(parameters);

Console.WriteLine(paginatedTweets);
```

## Project Policies

Read [Contributing](CONTRIBUTING.md), [Governance](GOVERNANCE.md), and [Security](SECURITY.md).

See [OpenSSF evidence](OPENSSF.md) for verified controls and remaining blockers.

## Semantic Versioning

The package follows [SemVer](https://semver.org/spec/v2.0.0.html).
Before v1.0, minor releases may change undocumented internals or behavior unlikely to affect most users.

Review release notes before upgrading between minor versions.

Open an [issue](https://github.com/Xquik-dev/x-twitter-scraper-csharp/issues) for questions, bugs, or suggestions.

[nuget-signatures]: https://learn.microsoft.com/en-us/nuget/api/repository-signatures-resource

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
