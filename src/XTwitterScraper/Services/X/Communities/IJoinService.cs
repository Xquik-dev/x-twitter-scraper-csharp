using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities.Join;

namespace XTwitterScraper.Services.X.Communities;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IJoinService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJoinServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJoinService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Join community
    /// </summary>
    Task<JoinCreateResponse> Create(
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(JoinCreateParams, CancellationToken)"/>
    Task<JoinCreateResponse> Create(
        string id,
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Leave community
    /// </summary>
    Task<JoinDeleteAllResponse> DeleteAll(
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(JoinDeleteAllParams, CancellationToken)"/>
    Task<JoinDeleteAllResponse> DeleteAll(
        string id,
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJoinService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJoinServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJoinServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/communities/{id}/join</c>, but is otherwise the
    /// same as <see cref="IJoinService.Create(JoinCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JoinCreateResponse>> Create(
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(JoinCreateParams, CancellationToken)"/>
    Task<HttpResponse<JoinCreateResponse>> Create(
        string id,
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/communities/{id}/join</c>, but is otherwise the
    /// same as <see cref="IJoinService.DeleteAll(JoinDeleteAllParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JoinDeleteAllResponse>> DeleteAll(
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(JoinDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse<JoinDeleteAllResponse>> DeleteAll(
        string id,
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );
}
