using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Services;

namespace XTwitterScraper;

/// <summary>
/// A client for interacting with the X Twitter Scraper REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IXTwitterScraperClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// OAuth 2.1 access token
    /// </summary>
    string? BearerToken { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IXTwitterScraperClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXTwitterScraperClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountService Account { get; }

    IApiKeyService ApiKeys { get; }

    ISubscribeService Subscribe { get; }

    IComposeService Compose { get; }

    IDraftService Drafts { get; }

    IStyleService Styles { get; }

    IRadarService Radar { get; }

    IMonitorService Monitors { get; }

    IEventService Events { get; }

    IExtractionService Extractions { get; }

    IDrawService Draws { get; }

    IWebhookService Webhooks { get; }

    IXService X { get; }

    ITrendService Trends { get; }

    ISupportService Support { get; }

    ICreditService Credits { get; }
}

/// <summary>
/// A view of <see cref="IXTwitterScraperClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IXTwitterScraperClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// OAuth 2.1 access token
    /// </summary>
    string? BearerToken { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXTwitterScraperClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAccountServiceWithRawResponse Account { get; }

    IApiKeyServiceWithRawResponse ApiKeys { get; }

    ISubscribeServiceWithRawResponse Subscribe { get; }

    IComposeServiceWithRawResponse Compose { get; }

    IDraftServiceWithRawResponse Drafts { get; }

    IStyleServiceWithRawResponse Styles { get; }

    IRadarServiceWithRawResponse Radar { get; }

    IMonitorServiceWithRawResponse Monitors { get; }

    IEventServiceWithRawResponse Events { get; }

    IExtractionServiceWithRawResponse Extractions { get; }

    IDrawServiceWithRawResponse Draws { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    IXServiceWithRawResponse X { get; }

    ITrendServiceWithRawResponse Trends { get; }

    ISupportServiceWithRawResponse Support { get; }

    ICreditServiceWithRawResponse Credits { get; }

    /// <summary>
    /// Sends a request to the X Twitter Scraper REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
