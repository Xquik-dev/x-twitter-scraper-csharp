using System;
using XTwitterScraper.Core;

namespace XTwitterScraper.Services.X.Tweets;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
}
