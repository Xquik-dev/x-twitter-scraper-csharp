using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Subscribe;

namespace XTwitterScraper.Services;

/// <summary>
/// Subscription &amp; billing
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISubscribeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscribeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscribeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get checkout or billing URL
    /// </summary>
    Task<SubscribeCreateResponse> Create(
        SubscribeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscribeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscribeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscribeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /subscribe</c>, but is otherwise the
    /// same as <see cref="ISubscribeService.Create(SubscribeCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscribeCreateResponse>> Create(
        SubscribeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
