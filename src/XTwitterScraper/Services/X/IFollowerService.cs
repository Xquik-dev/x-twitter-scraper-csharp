using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Followers;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X data lookups (subscription required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFollowerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFollowerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Check follow relationship
    /// </summary>
    Task<FollowerRetrieveCheckResponse> RetrieveCheck(
        FollowerRetrieveCheckParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFollowerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFollowerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/followers/check</c>, but is otherwise the
    /// same as <see cref="IFollowerService.RetrieveCheck(FollowerRetrieveCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FollowerRetrieveCheckResponse>> RetrieveCheck(
        FollowerRetrieveCheckParams parameters,
        CancellationToken cancellationToken = default
    );
}
