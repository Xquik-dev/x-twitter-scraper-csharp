// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Dm;
using Dm = XTwitterScraper.Models.X.Dm;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions.
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
    /// Get DM conversation history
    /// </summary>
    Task<DmRetrieveHistoryResponse> RetrieveHistory(
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveHistory(DmRetrieveHistoryParams, CancellationToken)"/>
    Task<DmRetrieveHistoryResponse> RetrieveHistory(
        string userID,
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send direct message
    /// </summary>
    Task<DmSendResponse> Send(
        DmSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(DmSendParams, CancellationToken)"/>
    Task<DmSendResponse> Send(
        string userID,
        DmSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes 1 DM from the account's side. The other person keeps it. Success means the DM is gone from the account's conversation. A DM that stays gets 422 `x_dm_not_deleted`, and Xquik charges nothing.
    /// </summary>
    Task<Models::XWriteAction> DeleteMessage(
        Dm::DmDeleteMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteMessage(Dm::DmDeleteMessageParams, CancellationToken)"/>
    Task<Models::XWriteAction> DeleteMessage(
        string messageID,
        Dm::DmDeleteMessageParams parameters,
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
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/dm/{userId}</c>, but is otherwise the
    /// same as <see cref="IDmService.Send(DmSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DmSendResponse>> Send(
        DmSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(DmSendParams, CancellationToken)"/>
    Task<HttpResponse<DmSendResponse>> Send(
        string userID,
        DmSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/dm/{userId}/messages/{messageId}</c>, but is otherwise the
    /// same as <see cref="IDmService.DeleteMessage(Dm::DmDeleteMessageParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> DeleteMessage(
        Dm::DmDeleteMessageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteMessage(Dm::DmDeleteMessageParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> DeleteMessage(
        string messageID,
        Dm::DmDeleteMessageParams parameters,
        CancellationToken cancellationToken = default
    );
}
