using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Tweets;
using XTwitterScraper.Services.X.Tweets;

namespace XTwitterScraper.Services.X;

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
        _like = new(() => new LikeService(client));
        _retweet = new(() => new RetweetService(client));
    }

    readonly Lazy<ILikeService> _like;
    public ILikeService Like
    {
        get { return _like.Value; }
    }

    readonly Lazy<IRetweetService> _retweet;
    public IRetweetService Retweet
    {
        get { return _retweet.Value; }
    }

    /// <inheritdoc/>
    public async Task<TweetCreateResponse> Create(
        TweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TweetListResponse> List(
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
    public async Task<TweetGetFavoritersResponse> GetFavoriters(
        TweetGetFavoritersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetFavoriters(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetGetFavoritersResponse> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFavoriters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TweetGetQuotesResponse> GetQuotes(
        TweetGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetQuotes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetGetQuotesResponse> GetQuotes(
        string id,
        TweetGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetQuotes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TweetGetRepliesResponse> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetReplies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetGetRepliesResponse> GetReplies(
        string id,
        TweetGetRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TweetGetRetweetersResponse> GetRetweeters(
        TweetGetRetweetersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetRetweeters(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetGetRetweetersResponse> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TweetGetThreadResponse> GetThread(
        TweetGetThreadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetThread(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetGetThreadResponse> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetThread(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TweetSearchResponse> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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

        _like = new(() => new LikeServiceWithRawResponse(client));
        _retweet = new(() => new RetweetServiceWithRawResponse(client));
    }

    readonly Lazy<ILikeServiceWithRawResponse> _like;
    public ILikeServiceWithRawResponse Like
    {
        get { return _like.Value; }
    }

    readonly Lazy<IRetweetServiceWithRawResponse> _retweet;
    public IRetweetServiceWithRawResponse Retweet
    {
        get { return _retweet.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetCreateResponse>> Create(
        TweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TweetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tweet = await response
                    .Deserialize<TweetCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tweet.Validate();
                }
                return tweet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetListResponse>> List(
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
                var tweets = await response
                    .Deserialize<TweetListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tweets.Validate();
                }
                return tweets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetGetFavoritersResponse>> GetFavoriters(
        TweetGetFavoritersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetGetFavoritersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetGetFavoritersResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetGetFavoritersResponse>> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFavoriters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetGetQuotesResponse>> GetQuotes(
        TweetGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetGetQuotesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetGetQuotesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetGetQuotesResponse>> GetQuotes(
        string id,
        TweetGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetQuotes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetGetRepliesResponse>> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetGetRepliesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetGetRepliesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetGetRepliesResponse>> GetReplies(
        string id,
        TweetGetRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetGetRetweetersResponse>> GetRetweeters(
        TweetGetRetweetersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetGetRetweetersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetGetRetweetersResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetGetRetweetersResponse>> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetGetThreadResponse>> GetThread(
        TweetGetThreadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetGetThreadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetGetThreadResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TweetGetThreadResponse>> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetThread(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetSearchResponse>> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TweetSearchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TweetSearchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
