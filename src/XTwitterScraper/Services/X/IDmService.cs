using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDmService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDmServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDmService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Send direct message
    /// </summary>
    Task<DmUpdateResponse> Update(
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DmUpdateParams, CancellationToken)"/>
    Task<DmUpdateResponse> Update(
        string userID,
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get DM conversation history
    /// </summary>
    Task<DmRetrieveHistoryResponse> RetrieveHistory(
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveHistory(DmRetrieveHistoryParams, CancellationToken)"/>
    Task<DmRetrieveHistoryResponse> RetrieveHistory(
        string userID,
        DmRetrieveHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDmService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDmServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/dm/{userId}</c>, but is otherwise the
    /// same as <see cref="IDmService.Update(DmUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DmUpdateResponse>> Update(
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DmUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DmUpdateResponse>> Update(
        string userID,
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/dm/{userId}/history</c>, but is otherwise the
    /// same as <see cref="IDmService.RetrieveHistory(DmRetrieveHistoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DmRetrieveHistoryResponse>> RetrieveHistory(
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveHistory(DmRetrieveHistoryParams, CancellationToken)"/>
    Task<HttpResponse<DmRetrieveHistoryResponse>> RetrieveHistory(
        string userID,
        DmRetrieveHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
