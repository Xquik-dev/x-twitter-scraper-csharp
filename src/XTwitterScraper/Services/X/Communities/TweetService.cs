using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
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
    public async Task<TweetListPage> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TweetListByCommunityPage> ListByCommunity(
        TweetListByCommunityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCommunity(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetListByCommunityPage> ListByCommunity(
        string id,
        TweetListByCommunityParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByCommunity(parameters with { ID = id }, cancellationToken);
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
    public async Task<HttpResponse<TweetListPage>> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TweetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<PaginatedTweets>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TweetListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetListByCommunityPage>> ListByCommunity(
        TweetListByCommunityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetListByCommunityParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<PaginatedTweets>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TweetListByCommunityPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetListByCommunityPage>> ListByCommunity(
        string id,
        TweetListByCommunityParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByCommunity(parameters with { ID = id }, cancellationToken);
    }
}
