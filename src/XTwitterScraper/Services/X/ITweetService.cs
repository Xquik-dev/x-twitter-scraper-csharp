using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;
using XTwitterScraper.Services.X.Tweets;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITweetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITweetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITweetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILikeService Like { get; }

    IRetweetService Retweet { get; }

    /// <summary>
    /// Create tweet
    /// </summary>
    Task<TweetCreateResponse> Create(
        TweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Look up tweet
    /// </summary>
    Task<TweetRetrieveResponse> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TweetRetrieveParams, CancellationToken)"/>
    Task<TweetRetrieveResponse> Retrieve(
        string tweetID,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get multiple tweets by IDs
    /// </summary>
    Task List(TweetListParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete tweet
    /// </summary>
    Task<TweetDeleteResponse> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TweetDeleteParams, CancellationToken)"/>
    Task<TweetDeleteResponse> Delete(
        string tweetID,
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get users who liked a tweet
    /// </summary>
    Task<PaginatedUsers> GetFavoriters(
        TweetGetFavoritersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetFavoriters(TweetGetFavoritersParams, CancellationToken)"/>
    Task<PaginatedUsers> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get quote tweets of a tweet
    /// </summary>
    Task<PaginatedTweets> GetQuotes(
        TweetGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetQuotes(TweetGetQuotesParams, CancellationToken)"/>
    Task<PaginatedTweets> GetQuotes(
        string id,
        TweetGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get replies to a tweet
    /// </summary>
    Task<PaginatedTweets> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetReplies(TweetGetRepliesParams, CancellationToken)"/>
    Task<PaginatedTweets> GetReplies(
        string id,
        TweetGetRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get users who retweeted a tweet
    /// </summary>
    Task<PaginatedUsers> GetRetweeters(
        TweetGetRetweetersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRetweeters(TweetGetRetweetersParams, CancellationToken)"/>
    Task<PaginatedUsers> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get thread context for a tweet
    /// </summary>
    Task<PaginatedTweets> GetThread(
        TweetGetThreadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetThread(TweetGetThreadParams, CancellationToken)"/>
    Task<PaginatedTweets> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search tweets
    /// </summary>
    Task<PaginatedTweets> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITweetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITweetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITweetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILikeServiceWithRawResponse Like { get; }

    IRetweetServiceWithRawResponse Retweet { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/tweets</c>, but is otherwise the
    /// same as <see cref="ITweetService.Create(TweetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetCreateResponse>> Create(
        TweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{tweetId}</c>, but is otherwise the
    /// same as <see cref="ITweetService.Retrieve(TweetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TweetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        string tweetID,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets</c>, but is otherwise the
    /// same as <see cref="ITweetService.List(TweetListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/tweets/{tweetId}</c>, but is otherwise the
    /// same as <see cref="ITweetService.Delete(TweetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetDeleteResponse>> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TweetDeleteParams, CancellationToken)"/>
    Task<HttpResponse<TweetDeleteResponse>> Delete(
        string tweetID,
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/favoriters</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetFavoriters(TweetGetFavoritersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> GetFavoriters(
        TweetGetFavoritersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetFavoriters(TweetGetFavoritersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> GetFavoriters(
        string id,
        TweetGetFavoritersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/quotes</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetQuotes(TweetGetQuotesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> GetQuotes(
        TweetGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetQuotes(TweetGetQuotesParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> GetQuotes(
        string id,
        TweetGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/replies</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetReplies(TweetGetRepliesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetReplies(TweetGetRepliesParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> GetReplies(
        string id,
        TweetGetRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/retweeters</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetRetweeters(TweetGetRetweetersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> GetRetweeters(
        TweetGetRetweetersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRetweeters(TweetGetRetweetersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> GetRetweeters(
        string id,
        TweetGetRetweetersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/thread</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetThread(TweetGetThreadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> GetThread(
        TweetGetThreadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetThread(TweetGetThreadParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> GetThread(
        string id,
        TweetGetThreadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/search</c>, but is otherwise the
    /// same as <see cref="ITweetService.Search(TweetSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
