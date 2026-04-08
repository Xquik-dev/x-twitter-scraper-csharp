using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Users.Follow;

namespace XTwitterScraper.Services.X.Users;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFollowService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFollowServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Follow user
    /// </summary>
    Task<FollowCreateResponse> Create(
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FollowCreateParams, CancellationToken)"/>
    Task<FollowCreateResponse> Create(
        string id,
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unfollow user
    /// </summary>
    Task<FollowDeleteAllResponse> DeleteAll(
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(FollowDeleteAllParams, CancellationToken)"/>
    Task<FollowDeleteAllResponse> DeleteAll(
        string id,
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFollowService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFollowServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/users/{id}/follow</c>, but is otherwise the
    /// same as <see cref="IFollowService.Create(FollowCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FollowCreateResponse>> Create(
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FollowCreateParams, CancellationToken)"/>
    Task<HttpResponse<FollowCreateResponse>> Create(
        string id,
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/users/{id}/follow</c>, but is otherwise the
    /// same as <see cref="IFollowService.DeleteAll(FollowDeleteAllParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FollowDeleteAllResponse>> DeleteAll(
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(FollowDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse<FollowDeleteAllResponse>> DeleteAll(
        string id,
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );
}
