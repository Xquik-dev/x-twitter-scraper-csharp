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
    Task List(TweetListParams parameters, CancellationToken cancellationToken = default);
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
    Task<HttpResponse> List(
        TweetListParams parameters,
        CancellationToken cancellationToken = default
    );
}
