// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using AccountConnectionLinks = XTwitterScraper.Models.X.AccountConnectionLinks;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <summary>
/// AccountConnectionLink operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IAccountConnectionLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountConnectionLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a link to a page Xquik hosts, where a person connects an X account with no Xquik signup. Your backend never receives their password or 2FA secret, and the account belongs to you. Send `accountId` to reconnect 1 of your accounts instead. Connecting is free. Takes a Full access API key or a dashboard session. The link works for 30 minutes, &amp; the response is the only place its token appears.
    /// </summary>
    Task<AccountConnectionLinks::AccountConnectionLinkCreateResponse> Create(
        AccountConnectionLinks::AccountConnectionLinkCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reads what happened on a link. `status` reads `connected` once the person finishes, with `xUserId`, `xUsername` &amp; `health`. It never holds the token. Takes a Full access API key or a dashboard session.
    /// </summary>
    Task<Models::XAccountConnectionLink> Retrieve(
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountConnectionLinks::AccountConnectionLinkRetrieveParams, CancellationToken)"/>
    Task<Models::XAccountConnectionLink> Retrieve(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stops a link working. An account it already connected stays connected. Takes a Full access API key or a dashboard session.
    /// </summary>
    Task<AccountConnectionLinks::AccountConnectionLinkRevokeResponse> Revoke(
        AccountConnectionLinks::AccountConnectionLinkRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(AccountConnectionLinks::AccountConnectionLinkRevokeParams, CancellationToken)"/>
    Task<AccountConnectionLinks::AccountConnectionLinkRevokeResponse> Revoke(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountConnectionLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountConnectionLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/account-connection-links</c>, but is otherwise the
    /// same as <see cref="IAccountConnectionLinkService.Create(AccountConnectionLinks::AccountConnectionLinkCreateParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<AccountConnectionLinks::AccountConnectionLinkCreateResponse>> Create(
        AccountConnectionLinks::AccountConnectionLinkCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/account-connection-links/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountConnectionLinkService.Retrieve(AccountConnectionLinks::AccountConnectionLinkRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XAccountConnectionLink>> Retrieve(
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountConnectionLinks::AccountConnectionLinkRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Models::XAccountConnectionLink>> Retrieve(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/account-connection-links/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountConnectionLinkService.Revoke(AccountConnectionLinks::AccountConnectionLinkRevokeParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<AccountConnectionLinks::AccountConnectionLinkRevokeResponse>> Revoke(
        AccountConnectionLinks::AccountConnectionLinkRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(AccountConnectionLinks::AccountConnectionLinkRevokeParams, CancellationToken)"/>
    Task<HttpResponse<AccountConnectionLinks::AccountConnectionLinkRevokeResponse>> Revoke(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
