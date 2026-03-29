using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets.Retweet;

namespace XTwitterScraper.Services.X.Tweets;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRetweetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRetweetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetweetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retweet
    /// </summary>
    Task<RetweetCreateResponse> Create(
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(RetweetCreateParams, CancellationToken)"/>
    Task<RetweetCreateResponse> Create(
        string tweetID,
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unretweet
    /// </summary>
    Task<RetweetDeleteResponse> Delete(
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RetweetDeleteParams, CancellationToken)"/>
    Task<RetweetDeleteResponse> Delete(
        string tweetID,
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRetweetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRetweetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetweetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/tweets/{tweetId}/retweet</c>, but is otherwise the
    /// same as <see cref="IRetweetService.Create(RetweetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetweetCreateResponse>> Create(
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(RetweetCreateParams, CancellationToken)"/>
    Task<HttpResponse<RetweetCreateResponse>> Create(
        string tweetID,
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/tweets/{tweetId}/retweet</c>, but is otherwise the
    /// same as <see cref="IRetweetService.Delete(RetweetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetweetDeleteResponse>> Delete(
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RetweetDeleteParams, CancellationToken)"/>
    Task<HttpResponse<RetweetDeleteResponse>> Delete(
        string tweetID,
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
