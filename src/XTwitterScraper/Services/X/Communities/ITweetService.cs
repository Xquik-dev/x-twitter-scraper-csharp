using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities.Tweets;

namespace XTwitterScraper.Services.X.Communities;

/// <summary>
/// X data lookups (subscription required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    /// <summary>
    /// Search tweets across all communities
    /// </summary>
    Task<TweetListPage> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get community tweets
    /// </summary>
    Task<TweetListByCommunityPage> ListByCommunity(
        TweetListByCommunityParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCommunity(TweetListByCommunityParams, CancellationToken)"/>
    Task<TweetListByCommunityPage> ListByCommunity(
        string id,
        TweetListByCommunityParams? parameters = null,
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/tweets</c>, but is otherwise the
    /// same as <see cref="ITweetService.List(TweetListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetListPage>> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/{id}/tweets</c>, but is otherwise the
    /// same as <see cref="ITweetService.ListByCommunity(TweetListByCommunityParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TweetListByCommunityPage>> ListByCommunity(
        TweetListByCommunityParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCommunity(TweetListByCommunityParams, CancellationToken)"/>
    Task<HttpResponse<TweetListByCommunityPage>> ListByCommunity(
        string id,
        TweetListByCommunityParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
