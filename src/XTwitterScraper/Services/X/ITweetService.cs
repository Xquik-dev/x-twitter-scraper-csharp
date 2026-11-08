using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;
using XTwitterScraper.Services.X.Tweets;
using Models = XTwitterScraper.Models;
using Tweets = XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions.
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
    /// Get tweet with full text, author, metrics and media
    /// </summary>
    Task<TweetRetrieveResponse> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TweetRetrieveParams, CancellationToken)"/>
    Task<TweetRetrieveResponse> Retrieve(
        string id,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get multiple tweets by IDs
    /// </summary>
    Task<PaginatedTweets> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete tweet
    /// </summary>
    Task<TweetDeleteResponse> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TweetDeleteParams, CancellationToken)"/>
    Task<TweetDeleteResponse> Delete(
        string id,
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns liker profiles that X makes visible for the post. X can withhold liker
    /// identities even when the post reports likes. In that case this endpoint returns
    /// 424 `favoriters_unavailable` instead of a misleading empty success.
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
    /// List quote tweets of a tweet
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
    /// Returns direct replies. Complete mode merges available timeline views, supported
    /// rankings, every forward cursor module, labeled hidden-content branches, time
    /// partitions, and search. It separates nested replies and returns 424 below 80%
    /// coverage.
    /// </summary>
    Task<TweetGetRepliesResponse> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetReplies(TweetGetRepliesParams, CancellationToken)"/>
    Task<TweetGetRepliesResponse> GetReplies(
        string id,
        TweetGetRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List users who retweeted a tweet
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
    /// Get full conversation thread for a tweet
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
    /// Search tweets by query, Tweet ID, X status URL, or account date window
    /// </summary>
    Task<PaginatedTweets> Search(
        TweetSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the tweets X ranks highest by 1 metric over the last day, week or month. Covers all of X unless you pick a country or a language. Pages hold up to 20 tweets, and the list ends at 100. Each tweet costs 1 credit.
    ///
    /// Top tweet lists come back reliably.
    /// </summary>
    Task<Models::PaginatedTweets2> ListTop(
        Tweets::TweetListTopParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bookmarks a post through a connected X account. Only that account sees its bookmarks, and GET /x/bookmarks lists them.
    /// </summary>
    Task<Models::XWriteAction> Bookmark(
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Bookmark(Tweets::TweetBookmarkParams, CancellationToken)"/>
    Task<Models::XWriteAction> Bookmark(
        string id,
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a bookmark through a connected X account.
    /// </summary>
    Task<Models::XWriteAction> Unbookmark(
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unbookmark(Tweets::TweetUnbookmarkParams, CancellationToken)"/>
    Task<Models::XWriteAction> Unbookmark(
        string id,
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns whether 1 account reposted the post. It finds recent reposts. An older repost can return false, with complete false. Each check costs 1 credit.
    /// </summary>
    Task<Tweets::TweetCheckRepostResponse> CheckRepost(
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckRepost(Tweets::TweetCheckRepostParams, CancellationToken)"/>
    Task<Tweets::TweetCheckRepostResponse> CheckRepost(
        string id,
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the user IDs of a post's reposters, in the order &amp; pages of /x/tweets/{id}/retweeters. Use it when you need IDs only. Each ID costs 1 credit. A post nobody reposted returns an empty list for free.
    /// </summary>
    Task<Models::PaginatedUserIDs> GetRetweeterIds(
        Tweets::TweetGetRetweeterIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRetweeterIds(Tweets::TweetGetRetweeterIdsParams, CancellationToken)"/>
    Task<Models::PaginatedUserIDs> GetRetweeterIds(
        string id,
        Tweets::TweetGetRetweeterIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the replies the post's author hid, oldest first, with the replies to them. A post without hidden replies returns an empty list.
    /// </summary>
    Task<Models::PaginatedTweets2> GetHiddenReplies(
        Tweets::TweetGetHiddenRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetHiddenReplies(Tweets::TweetGetHiddenRepliesParams, CancellationToken)"/>
    Task<Models::PaginatedTweets2> GetHiddenReplies(
        string id,
        Tweets::TweetGetHiddenRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns X's own translation of 1 public tweet into the language you pick, with the links, mentions, and tags X places in the translated text.
    ///
    /// Posts &amp; bios can be translated into your language.
    /// </summary>
    Task<Tweets::TweetTranslateResponse> Translate(
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Translate(Tweets::TweetTranslateParams, CancellationToken)"/>
    Task<Tweets::TweetTranslateResponse> Translate(
        string id,
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns engagement insights for 1 tweet. They are engagements per hour since it went up, per view and per follower of its author, and how far it spread. Each report costs 1 credit, whatever it reads.
    /// </summary>
    Task<Tweets::TweetGetInsightsResponse> GetInsights(
        Tweets::TweetGetInsightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetInsights(Tweets::TweetGetInsightsParams, CancellationToken)"/>
    Task<Tweets::TweetGetInsightsResponse> GetInsights(
        string id,
        Tweets::TweetGetInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the HTML that X gives websites to embed 1 public tweet, with the tweet's link and author.
    /// </summary>
    Task<Tweets::TweetEmbedResponse> Embed(
        Tweets::TweetEmbedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Embed(Tweets::TweetEmbedParams, CancellationToken)"/>
    Task<Tweets::TweetEmbedResponse> Embed(
        string id,
        Tweets::TweetEmbedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the caption tracks of 1 public tweet's videos. Each track has its language, name, timed cues, and full text. A tweet without video, or a video without captions, returns no track and costs nothing.
    ///
    /// Video subtitles come with timed cues.
    /// </summary>
    Task<Tweets::TweetGetSubtitlesResponse> GetSubtitles(
        Tweets::TweetGetSubtitlesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubtitles(Tweets::TweetGetSubtitlesParams, CancellationToken)"/>
    Task<Tweets::TweetGetSubtitlesResponse> GetSubtitles(
        string id,
        Tweets::TweetGetSubtitlesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns where each t.co link leads, as X's own redirect says. Xquik reads the redirect and never visits the target site. A link t.co does not have comes back without `resolvedUrl` and costs nothing. A link X does not answer for in time comes back in `unprocessedUrls`, free. Each resolved link costs 1 credit.
    /// </summary>
    Task<Tweets::TweetResolveLinksResponse> ResolveLinks(
        Tweets::TweetResolveLinksParams parameters,
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
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}</c>, but is otherwise the
    /// same as <see cref="ITweetService.Retrieve(TweetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        TweetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TweetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TweetRetrieveResponse>> Retrieve(
        string id,
        TweetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets</c>, but is otherwise the
    /// same as <see cref="ITweetService.List(TweetListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/tweets/{id}</c>, but is otherwise the
    /// same as <see cref="ITweetService.Delete(TweetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetDeleteResponse>> Delete(
        TweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TweetDeleteParams, CancellationToken)"/>
    Task<HttpResponse<TweetDeleteResponse>> Delete(
        string id,
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
    Task<HttpResponse<TweetGetRepliesResponse>> GetReplies(
        TweetGetRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetReplies(TweetGetRepliesParams, CancellationToken)"/>
    Task<HttpResponse<TweetGetRepliesResponse>> GetReplies(
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/top</c>, but is otherwise the
    /// same as <see cref="ITweetService.ListTop(Tweets::TweetListTopParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedTweets2>> ListTop(
        Tweets::TweetListTopParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/tweets/{id}/bookmark</c>, but is otherwise the
    /// same as <see cref="ITweetService.Bookmark(Tweets::TweetBookmarkParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Bookmark(
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Bookmark(Tweets::TweetBookmarkParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Bookmark(
        string id,
        Tweets::TweetBookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/tweets/{id}/bookmark</c>, but is otherwise the
    /// same as <see cref="ITweetService.Unbookmark(Tweets::TweetUnbookmarkParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Unbookmark(
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unbookmark(Tweets::TweetUnbookmarkParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Unbookmark(
        string id,
        Tweets::TweetUnbookmarkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/retweeters/check</c>, but is otherwise the
    /// same as <see cref="ITweetService.CheckRepost(Tweets::TweetCheckRepostParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetCheckRepostResponse>> CheckRepost(
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckRepost(Tweets::TweetCheckRepostParams, CancellationToken)"/>
    Task<HttpResponse<Tweets::TweetCheckRepostResponse>> CheckRepost(
        string id,
        Tweets::TweetCheckRepostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/retweeter-ids</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetRetweeterIds(Tweets::TweetGetRetweeterIdsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUserIDs>> GetRetweeterIds(
        Tweets::TweetGetRetweeterIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetRetweeterIds(Tweets::TweetGetRetweeterIdsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUserIDs>> GetRetweeterIds(
        string id,
        Tweets::TweetGetRetweeterIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/hidden-replies</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetHiddenReplies(Tweets::TweetGetHiddenRepliesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedTweets2>> GetHiddenReplies(
        Tweets::TweetGetHiddenRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetHiddenReplies(Tweets::TweetGetHiddenRepliesParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedTweets2>> GetHiddenReplies(
        string id,
        Tweets::TweetGetHiddenRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/translation</c>, but is otherwise the
    /// same as <see cref="ITweetService.Translate(Tweets::TweetTranslateParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetTranslateResponse>> Translate(
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Translate(Tweets::TweetTranslateParams, CancellationToken)"/>
    Task<HttpResponse<Tweets::TweetTranslateResponse>> Translate(
        string id,
        Tweets::TweetTranslateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/insights</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetInsights(Tweets::TweetGetInsightsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetGetInsightsResponse>> GetInsights(
        Tweets::TweetGetInsightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetInsights(Tweets::TweetGetInsightsParams, CancellationToken)"/>
    Task<HttpResponse<Tweets::TweetGetInsightsResponse>> GetInsights(
        string id,
        Tweets::TweetGetInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/embed</c>, but is otherwise the
    /// same as <see cref="ITweetService.Embed(Tweets::TweetEmbedParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetEmbedResponse>> Embed(
        Tweets::TweetEmbedParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Embed(Tweets::TweetEmbedParams, CancellationToken)"/>
    Task<HttpResponse<Tweets::TweetEmbedResponse>> Embed(
        string id,
        Tweets::TweetEmbedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/tweets/{id}/subtitles</c>, but is otherwise the
    /// same as <see cref="ITweetService.GetSubtitles(Tweets::TweetGetSubtitlesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetGetSubtitlesResponse>> GetSubtitles(
        Tweets::TweetGetSubtitlesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSubtitles(Tweets::TweetGetSubtitlesParams, CancellationToken)"/>
    Task<HttpResponse<Tweets::TweetGetSubtitlesResponse>> GetSubtitles(
        string id,
        Tweets::TweetGetSubtitlesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/links/resolve</c>, but is otherwise the
    /// same as <see cref="ITweetService.ResolveLinks(Tweets::TweetResolveLinksParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Tweets::TweetResolveLinksResponse>> ResolveLinks(
        Tweets::TweetResolveLinksParams parameters,
        CancellationToken cancellationToken = default
    );
}
