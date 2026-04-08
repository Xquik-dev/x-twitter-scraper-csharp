using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X;
using X = XTwitterScraper.Services.X;

namespace XTwitterScraper.Services;

/// <summary>
/// X data lookups (subscription required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IXService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IXServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    X::ITweetService Tweets { get; }

    X::IUserService Users { get; }

    X::IFollowerService Followers { get; }

    X::IDmService Dm { get; }

    X::IMediaService Media { get; }

    X::IProfileService Profile { get; }

    X::ICommunityService Communities { get; }

    X::IAccountService Accounts { get; }

    X::IBookmarkService Bookmarks { get; }

    X::IListService Lists { get; }

    /// <summary>
    /// Retrieve the full content of an X Article (long-form post) by tweet ID.
    /// </summary>
    Task<XGetArticleResponse> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetArticle(XGetArticleParams, CancellationToken)"/>
    Task<XGetArticleResponse> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get home timeline
    /// </summary>
    Task<XGetHomeTimelineResponse> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get notifications
    /// </summary>
    Task<XGetNotificationsResponse> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get trending topics
    /// </summary>
    Task<XGetTrendsResponse> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IXService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IXServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    X::ITweetServiceWithRawResponse Tweets { get; }

    X::IUserServiceWithRawResponse Users { get; }

    X::IFollowerServiceWithRawResponse Followers { get; }

    X::IDmServiceWithRawResponse Dm { get; }

    X::IMediaServiceWithRawResponse Media { get; }

    X::IProfileServiceWithRawResponse Profile { get; }

    X::ICommunityServiceWithRawResponse Communities { get; }

    X::IAccountServiceWithRawResponse Accounts { get; }

    X::IBookmarkServiceWithRawResponse Bookmarks { get; }

    X::IListServiceWithRawResponse Lists { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/articles/{tweetId}</c>, but is otherwise the
    /// same as <see cref="IXService.GetArticle(XGetArticleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetArticleResponse>> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetArticle(XGetArticleParams, CancellationToken)"/>
    Task<HttpResponse<XGetArticleResponse>> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/timeline</c>, but is otherwise the
    /// same as <see cref="IXService.GetHomeTimeline(XGetHomeTimelineParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetHomeTimelineResponse>> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/notifications</c>, but is otherwise the
    /// same as <see cref="IXService.GetNotifications(XGetNotificationsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetNotificationsResponse>> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/trends</c>, but is otherwise the
    /// same as <see cref="IXService.GetTrends(XGetTrendsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetTrendsResponse>> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
