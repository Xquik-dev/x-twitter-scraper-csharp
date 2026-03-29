using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Services.X.Tweets;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILikeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILikeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILikeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Like tweet
    /// </summary>
    Task<LikeCreateResponse> Create(
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LikeCreateParams, CancellationToken)"/>
    Task<LikeCreateResponse> Create(
        string tweetID,
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unlike tweet
    /// </summary>
    Task<LikeDeleteResponse> Delete(
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(LikeDeleteParams, CancellationToken)"/>
    Task<LikeDeleteResponse> Delete(
        string tweetID,
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILikeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILikeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILikeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/tweets/{tweetId}/like</c>, but is otherwise the
    /// same as <see cref="ILikeService.Create(LikeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LikeCreateResponse>> Create(
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LikeCreateParams, CancellationToken)"/>
    Task<HttpResponse<LikeCreateResponse>> Create(
        string tweetID,
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/tweets/{tweetId}/like</c>, but is otherwise the
    /// same as <see cref="ILikeService.Delete(LikeDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LikeDeleteResponse>> Delete(
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(LikeDeleteParams, CancellationToken)"/>
    Task<HttpResponse<LikeDeleteResponse>> Delete(
        string tweetID,
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
