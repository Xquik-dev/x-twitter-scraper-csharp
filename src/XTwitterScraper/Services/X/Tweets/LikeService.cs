using System;
using XTwitterScraper.Core;

namespace XTwitterScraper.Services.X.Tweets;

/// <inheritdoc/>
public sealed class LikeService : ILikeService
{
    readonly Lazy<ILikeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILikeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ILikeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LikeService(this._client.WithOptions(modifier));
    }

    public LikeService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LikeServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class LikeServiceWithRawResponse : ILikeServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILikeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LikeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LikeServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }
}
