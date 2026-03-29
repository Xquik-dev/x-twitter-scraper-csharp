using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Trends;

namespace XTwitterScraper.Services;

/// <summary>
/// Trending topics by region
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITrendService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITrendServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrendService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get trending topics
    /// </summary>
    Task<TrendListResponse> List(
        TrendListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITrendService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITrendServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrendServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /trends</c>, but is otherwise the
    /// same as <see cref="ITrendService.List(TrendListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TrendListResponse>> List(
        TrendListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
