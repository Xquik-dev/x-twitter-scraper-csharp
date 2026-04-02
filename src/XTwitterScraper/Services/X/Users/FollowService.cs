using System;
using XTwitterScraper.Core;

namespace XTwitterScraper.Services.X.Users;

/// <inheritdoc/>
public sealed class FollowService : IFollowService
{
    readonly Lazy<IFollowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFollowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IFollowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowService(this._client.WithOptions(modifier));
    }

    public FollowService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FollowServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class FollowServiceWithRawResponse : IFollowServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFollowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FollowServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }
}
