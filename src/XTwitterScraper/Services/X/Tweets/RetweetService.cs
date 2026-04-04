using System;
using XTwitterScraper.Core;

namespace XTwitterScraper.Services.X.Tweets;

/// <inheritdoc/>
public sealed class RetweetService : IRetweetService
{
    readonly Lazy<IRetweetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRetweetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IRetweetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetweetService(this._client.WithOptions(modifier));
    }

    public RetweetService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RetweetServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class RetweetServiceWithRawResponse : IRetweetServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRetweetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetweetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RetweetServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }
}
