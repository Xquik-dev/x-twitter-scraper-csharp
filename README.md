# X (Twitter) Scraper C# SDK: Tweet Search, Timelines, Followers & Posting

[![OpenSSF Best Practices](https://www.bestpractices.dev/projects/13733/badge)](https://www.bestpractices.dev/projects/13733)
[![CI](https://github.com/Xquik-dev/x-twitter-scraper-csharp/actions/workflows/ci.yml/badge.svg)](https://github.com/Xquik-dev/x-twitter-scraper-csharp/actions/workflows/ci.yml)

Use Xquik's typed NuGet SDK as an X API alternative.

Search tweets, read timelines, export followers, and deliver webhooks.

Confirmed methods also support posting and other account actions.

## Is This A Twitter API Alternative?

This package calls Xquik's documented REST API.

It does not call or emulate the official X API.

Use it for supported X data and automation workflows from .NET.

## Documentation

Read the [C# SDK guide](https://docs.xquik.com/sdks/csharp) or [API guide](https://docs.xquik.com/api-reference/overview).

## Common X Data Tasks

Use the linked SDK guide for typed method names.

| Customer Question | REST Route | Workflow Note |
| --- | --- | --- |
| How do I search tweets? | `GET /x/tweets/search` | Use keyword or advanced operator queries. |
| How do I extract a profile timeline? | `GET /x/users/{id}/tweets` | Paginate bounded X timeline results. |
| How do I scrape X followers? | `GET /x/users/{id}/followers` | Use an extraction for complete datasets. |
| How do I scrape X following accounts? | `GET /x/users/{id}/following` | Use an extraction for complete datasets. |
| How do I read my home timeline? | `GET /x/timeline` | Approve this private read. |
| How do I read lists or communities? | `/x/lists/*`, `/x/communities/*` | Use the typed nested services. |
| How do I export large X datasets? | `POST /extractions` | Poll status, then download results. |
| How do I monitor an account? | `POST /monitors` | Deliver events through HMAC webhooks. |
| How do I post or reply? | `POST /x/tweets` | Confirm the account and payload. |

The [API reference](https://docs.xquik.com/api-reference/overview) lists every route.

The SDK exposes matching typed services and request models.

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/XTwitterScraper):

```bash
dotnet add package XTwitterScraper
```

## Verify a Release

Verify project provenance before using a GitHub release package.

Select a release containing `.nupkg` assets:

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

See the [`examples`](examples) directory for complete and runnable examples.

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

## Client configuration

Configure the client using environment variables:

```csharp
using XTwitterScraper;

// Configured using the X_TWITTER_SCRAPER_API_KEY, X_TWITTER_SCRAPER_BEARER_TOKEN and X_TWITTER_SCRAPER_BASE_URL environment variables
XTwitterScraperClient client = new();
```

Or manually:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new()
{
    ApiKey = "My API Key",
    BearerToken = "My Bearer Token",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property      | Environment variable             | Required | Default value                |
| ------------- | -------------------------------- | -------- | ---------------------------- |
| `ApiKey`      | `X_TWITTER_SCRAPER_API_KEY`      | false    | -                            |
| `BearerToken` | `X_TWITTER_SCRAPER_BEARER_TOKEN` | false    | -                            |
| `BaseUrl`     | `X_TWITTER_SCRAPER_BASE_URL`     | true     | `"https://xquik.com/api/v1"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

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

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

Build a `Params` instance and pass it to its client method. The SDK returns a typed C# model.

For example, `client.X.Tweets.Search` should be called with an instance of `TweetSearchParams`, and it will return an instance of `Task<PaginatedTweets>`.

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

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

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Extractions.ExportResults(parameters);
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Account.Retrieve();
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using XTwitterScraper.Models.Account;

var response = await client.WithRawResponse.Account.Retrieve();
AccountRetrieveResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `XTwitterScraperApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

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

Additionally, all 4xx errors inherit from `XTwitterScraper4xxException`.

- `XTwitterScraperIOException`: I/O networking errors.

- `XTwitterScraperInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `XTwitterScraperException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

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

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using XTwitterScraper;

XTwitterScraperClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

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

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

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

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

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
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    Limit = 200
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

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

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.X.Tweets.Search(parameters)
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `XTwitterScraperInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var paginatedTweets = client.X.Tweets.Search(parameters);
paginatedTweets.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using XTwitterScraper;

XTwitterScraperClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

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

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

Open an [issue](https://github.com/Xquik-dev/x-twitter-scraper-csharp/issues) for questions, bugs, or suggestions.

[nuget-signatures]: https://learn.microsoft.com/en-us/nuget/api/repository-signatures-resource

Xquik is an independent third-party service. Not affiliated with X Corp. "Twitter" and "X" are trademarks of X Corp.
