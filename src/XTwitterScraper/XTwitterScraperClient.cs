using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Services;

namespace XTwitterScraper;

/// <inheritdoc/>
public sealed class XTwitterScraperClient : IXTwitterScraperClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? BearerToken
    {
        get { return this._options.BearerToken; }
        init { this._options.BearerToken = value; }
    }

    readonly Lazy<IXTwitterScraperClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IXTwitterScraperClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IXTwitterScraperClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new XTwitterScraperClient(modifier(this._options));
    }

    readonly Lazy<IAccountService> _account;
    public IAccountService Account
    {
        get { return _account.Value; }
    }

    readonly Lazy<IApiKeyService> _apiKeys;
    public IApiKeyService ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<ISubscribeService> _subscribe;
    public ISubscribeService Subscribe
    {
        get { return _subscribe.Value; }
    }

    readonly Lazy<IComposeService> _compose;
    public IComposeService Compose
    {
        get { return _compose.Value; }
    }

    readonly Lazy<IDraftService> _drafts;
    public IDraftService Drafts
    {
        get { return _drafts.Value; }
    }

    readonly Lazy<IStyleService> _styles;
    public IStyleService Styles
    {
        get { return _styles.Value; }
    }

    readonly Lazy<IRadarService> _radar;
    public IRadarService Radar
    {
        get { return _radar.Value; }
    }

    readonly Lazy<IMonitorService> _monitors;
    public IMonitorService Monitors
    {
        get { return _monitors.Value; }
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IExtractionService> _extractions;
    public IExtractionService Extractions
    {
        get { return _extractions.Value; }
    }

    readonly Lazy<IDrawService> _draws;
    public IDrawService Draws
    {
        get { return _draws.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<IIntegrationService> _integrations;
    public IIntegrationService Integrations
    {
        get { return _integrations.Value; }
    }

    readonly Lazy<IXService> _x;
    public IXService X
    {
        get { return _x.Value; }
    }

    readonly Lazy<ITrendService> _trends;
    public ITrendService Trends
    {
        get { return _trends.Value; }
    }

    readonly Lazy<IBotService> _bot;
    public IBotService Bot
    {
        get { return _bot.Value; }
    }

    readonly Lazy<ISupportService> _support;
    public ISupportService Support
    {
        get { return _support.Value; }
    }

    readonly Lazy<ICreditService> _credits;
    public ICreditService Credits
    {
        get { return _credits.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public XTwitterScraperClient()
    {
        _options = new();

        _withRawResponse = new(() => new XTwitterScraperClientWithRawResponse(this._options));
        _account = new(() => new AccountService(this));
        _apiKeys = new(() => new ApiKeyService(this));
        _subscribe = new(() => new SubscribeService(this));
        _compose = new(() => new ComposeService(this));
        _drafts = new(() => new DraftService(this));
        _styles = new(() => new StyleService(this));
        _radar = new(() => new RadarService(this));
        _monitors = new(() => new MonitorService(this));
        _events = new(() => new EventService(this));
        _extractions = new(() => new ExtractionService(this));
        _draws = new(() => new DrawService(this));
        _webhooks = new(() => new WebhookService(this));
        _integrations = new(() => new IntegrationService(this));
        _x = new(() => new XService(this));
        _trends = new(() => new TrendService(this));
        _bot = new(() => new BotService(this));
        _support = new(() => new SupportService(this));
        _credits = new(() => new CreditService(this));
    }

    public XTwitterScraperClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class XTwitterScraperClientWithRawResponse : IXTwitterScraperClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? BearerToken
    {
        get { return this._options.BearerToken; }
        init { this._options.BearerToken = value; }
    }

    /// <inheritdoc/>
    public IXTwitterScraperClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new XTwitterScraperClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IAccountServiceWithRawResponse> _account;
    public IAccountServiceWithRawResponse Account
    {
        get { return _account.Value; }
    }

    readonly Lazy<IApiKeyServiceWithRawResponse> _apiKeys;
    public IApiKeyServiceWithRawResponse ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<ISubscribeServiceWithRawResponse> _subscribe;
    public ISubscribeServiceWithRawResponse Subscribe
    {
        get { return _subscribe.Value; }
    }

    readonly Lazy<IComposeServiceWithRawResponse> _compose;
    public IComposeServiceWithRawResponse Compose
    {
        get { return _compose.Value; }
    }

    readonly Lazy<IDraftServiceWithRawResponse> _drafts;
    public IDraftServiceWithRawResponse Drafts
    {
        get { return _drafts.Value; }
    }

    readonly Lazy<IStyleServiceWithRawResponse> _styles;
    public IStyleServiceWithRawResponse Styles
    {
        get { return _styles.Value; }
    }

    readonly Lazy<IRadarServiceWithRawResponse> _radar;
    public IRadarServiceWithRawResponse Radar
    {
        get { return _radar.Value; }
    }

    readonly Lazy<IMonitorServiceWithRawResponse> _monitors;
    public IMonitorServiceWithRawResponse Monitors
    {
        get { return _monitors.Value; }
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IExtractionServiceWithRawResponse> _extractions;
    public IExtractionServiceWithRawResponse Extractions
    {
        get { return _extractions.Value; }
    }

    readonly Lazy<IDrawServiceWithRawResponse> _draws;
    public IDrawServiceWithRawResponse Draws
    {
        get { return _draws.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<IIntegrationServiceWithRawResponse> _integrations;
    public IIntegrationServiceWithRawResponse Integrations
    {
        get { return _integrations.Value; }
    }

    readonly Lazy<IXServiceWithRawResponse> _x;
    public IXServiceWithRawResponse X
    {
        get { return _x.Value; }
    }

    readonly Lazy<ITrendServiceWithRawResponse> _trends;
    public ITrendServiceWithRawResponse Trends
    {
        get { return _trends.Value; }
    }

    readonly Lazy<IBotServiceWithRawResponse> _bot;
    public IBotServiceWithRawResponse Bot
    {
        get { return _bot.Value; }
    }

    readonly Lazy<ISupportServiceWithRawResponse> _support;
    public ISupportServiceWithRawResponse Support
    {
        get { return _support.Value; }
    }

    readonly Lazy<ICreditServiceWithRawResponse> _credits;
    public ICreditServiceWithRawResponse Credits
    {
        get { return _credits.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw XTwitterScraperExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new XTwitterScraperIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new XTwitterScraperIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is XTwitterScraperIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public XTwitterScraperClientWithRawResponse()
    {
        _options = new();

        _account = new(() => new AccountServiceWithRawResponse(this));
        _apiKeys = new(() => new ApiKeyServiceWithRawResponse(this));
        _subscribe = new(() => new SubscribeServiceWithRawResponse(this));
        _compose = new(() => new ComposeServiceWithRawResponse(this));
        _drafts = new(() => new DraftServiceWithRawResponse(this));
        _styles = new(() => new StyleServiceWithRawResponse(this));
        _radar = new(() => new RadarServiceWithRawResponse(this));
        _monitors = new(() => new MonitorServiceWithRawResponse(this));
        _events = new(() => new EventServiceWithRawResponse(this));
        _extractions = new(() => new ExtractionServiceWithRawResponse(this));
        _draws = new(() => new DrawServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
        _integrations = new(() => new IntegrationServiceWithRawResponse(this));
        _x = new(() => new XServiceWithRawResponse(this));
        _trends = new(() => new TrendServiceWithRawResponse(this));
        _bot = new(() => new BotServiceWithRawResponse(this));
        _support = new(() => new SupportServiceWithRawResponse(this));
        _credits = new(() => new CreditServiceWithRawResponse(this));
    }

    public XTwitterScraperClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
