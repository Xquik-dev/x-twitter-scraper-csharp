using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities.Tweets;

namespace XTwitterScraper.Services.X.Communities;

/// <inheritdoc/>
public sealed class TweetService : ITweetService
{
    readonly Lazy<ITweetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITweetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ITweetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TweetService(this._client.WithOptions(modifier));
    }

    public TweetService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TweetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task List(TweetListParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TweetServiceWithRawResponse : ITweetServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITweetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TweetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TweetServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TweetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
