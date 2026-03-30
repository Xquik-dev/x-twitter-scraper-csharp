using System;
using XTwitterScraper.Core;

namespace XTwitterScraper.Services.Bot;

/// <inheritdoc/>
public sealed class PlatformLinkService : IPlatformLinkService
{
    readonly Lazy<IPlatformLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlatformLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IPlatformLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlatformLinkService(this._client.WithOptions(modifier));
    }

    public PlatformLinkService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PlatformLinkServiceWithRawResponse(client.WithRawResponse)
        );
    }
}

/// <inheritdoc/>
public sealed class PlatformLinkServiceWithRawResponse : IPlatformLinkServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlatformLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PlatformLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlatformLinkServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }
}
