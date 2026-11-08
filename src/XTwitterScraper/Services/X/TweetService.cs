// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;
using XTwitterScraper.Services.X.Tweets;
using Models = XTwitterScraper.Models;
using Tweets = XTwitterScraper.Models.X.Tweets;

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
    public async Task<TweetRetrieveResponse> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetRetrieveResponse> Retrieve(
        string id,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> List(
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
    public async Task<TweetDeleteResponse> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TweetDeleteResponse> Delete(
        string id,
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> GetFavoriters(
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
    public Task<PaginatedUsers> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFavoriters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> GetQuotes(
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
    public Task<PaginatedTweets> GetQuotes(
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
    public async Task<PaginatedUsers> GetRetweeters(
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
    public Task<PaginatedUsers> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> GetThread(
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
    public Task<PaginatedTweets> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetThread(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedTweets2> ListTop(
        Tweets::TweetListTopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTop(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Bookmark(
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Bookmark(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Bookmark(
        string id,
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Bookmark(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Unbookmark(
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unbookmark(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Unbookmark(
        string id,
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unbookmark(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetCheckRepostResponse> CheckRepost(
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CheckRepost(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tweets::TweetCheckRepostResponse> CheckRepost(
        string id,
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CheckRepost(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUserIDs> GetRetweeterIds(
        Tweets::TweetGetRetweeterIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetRetweeterIds(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUserIDs> GetRetweeterIds(
        string id,
        Tweets::TweetGetRetweeterIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeterIds(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedTweets2> GetHiddenReplies(
        Tweets::TweetGetHiddenRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetHiddenReplies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedTweets2> GetHiddenReplies(
        string id,
        Tweets::TweetGetHiddenRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetHiddenReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetTranslateResponse> Translate(
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Translate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tweets::TweetTranslateResponse> Translate(
        string id,
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Translate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetGetInsightsResponse> GetInsights(
        Tweets::TweetGetInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetInsights(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tweets::TweetGetInsightsResponse> GetInsights(
        string id,
        Tweets::TweetGetInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetInsights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetEmbedResponse> Embed(
        Tweets::TweetEmbedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Embed(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tweets::TweetEmbedResponse> Embed(
        string id,
        Tweets::TweetEmbedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Embed(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetGetSubtitlesResponse> GetSubtitles(
        Tweets::TweetGetSubtitlesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetSubtitles(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tweets::TweetGetSubtitlesResponse> GetSubtitles(
        string id,
        Tweets::TweetGetSubtitlesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSubtitles(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tweets::TweetResolveLinksResponse> ResolveLinks(
        Tweets::TweetResolveLinksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ResolveLinks(parameters, cancellationToken)
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
    public async Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tweet = await response
                    .Deserialize<TweetRetrieveResponse>(token)
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
    public Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        string id,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> List(
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
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TweetDeleteResponse>> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TweetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tweet = await response
                    .Deserialize<TweetDeleteResponse>(token)
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
    public Task<HttpResponse<TweetDeleteResponse>> Delete(
        string id,
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> GetFavoriters(
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
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFavoriters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> GetQuotes(
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
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedTweets>> GetQuotes(
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
                var paginatedTweets = await response
                    .Deserialize<TweetGetRepliesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
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
    public async Task<HttpResponse<PaginatedUsers>> GetRetweeters(
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
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeters(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> GetThread(
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
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedTweets>> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetThread(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> Search(
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
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedTweets2>> ListTop(
        Tweets::TweetListTopParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Tweets::TweetListTopParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::PaginatedTweets2>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::XWriteAction>> Bookmark(
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetBookmarkParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::XWriteAction>> Bookmark(
        string id,
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Bookmark(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::XWriteAction>> Unbookmark(
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetUnbookmarkParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::XWriteAction>> Unbookmark(
        string id,
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unbookmark(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetCheckRepostResponse>> CheckRepost(
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetCheckRepostParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetCheckRepostResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tweets::TweetCheckRepostResponse>> CheckRepost(
        string id,
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CheckRepost(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUserIDs>> GetRetweeterIds(
        Tweets::TweetGetRetweeterIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetGetRetweeterIdsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::PaginatedUserIDs>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::PaginatedUserIDs>> GetRetweeterIds(
        string id,
        Tweets::TweetGetRetweeterIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRetweeterIds(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedTweets2>> GetHiddenReplies(
        Tweets::TweetGetHiddenRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetGetHiddenRepliesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::PaginatedTweets2>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::PaginatedTweets2>> GetHiddenReplies(
        string id,
        Tweets::TweetGetHiddenRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetHiddenReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetTranslateResponse>> Translate(
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetTranslateParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetTranslateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tweets::TweetTranslateResponse>> Translate(
        string id,
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Translate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetGetInsightsResponse>> GetInsights(
        Tweets::TweetGetInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetGetInsightsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetGetInsightsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tweets::TweetGetInsightsResponse>> GetInsights(
        string id,
        Tweets::TweetGetInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetInsights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetEmbedResponse>> Embed(
        Tweets::TweetEmbedParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetEmbedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetEmbedResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tweets::TweetEmbedResponse>> Embed(
        string id,
        Tweets::TweetEmbedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Embed(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetGetSubtitlesResponse>> GetSubtitles(
        Tweets::TweetGetSubtitlesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Tweets::TweetGetSubtitlesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetGetSubtitlesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tweets::TweetGetSubtitlesResponse>> GetSubtitles(
        string id,
        Tweets::TweetGetSubtitlesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSubtitles(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tweets::TweetResolveLinksResponse>> ResolveLinks(
        Tweets::TweetResolveLinksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tweets::TweetResolveLinksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Tweets::TweetResolveLinksResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }
}
