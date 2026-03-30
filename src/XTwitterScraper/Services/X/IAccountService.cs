using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Connected X account management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Connect X account
    /// </summary>
    Task<AccountCreateResponse> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get X account details
    /// </summary>
    Task<XAccountDetail> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<XAccountDetail> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List connected X accounts
    /// </summary>
    Task<AccountListResponse> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disconnect X account
    /// </summary>
    Task<AccountDeleteResponse> Delete(
        AccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AccountDeleteParams, CancellationToken)"/>
    Task<AccountDeleteResponse> Delete(
        string id,
        AccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Re-authenticate X account
    /// </summary>
    Task<AccountReauthResponse> Reauth(
        AccountReauthParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reauth(AccountReauthParams, CancellationToken)"/>
    Task<AccountReauthResponse> Reauth(
        string id,
        AccountReauthParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountCreateResponse>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/accounts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XAccountDetail>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<XAccountDetail>> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountListResponse>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/accounts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Delete(AccountDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountDeleteResponse>> Delete(
        AccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AccountDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AccountDeleteResponse>> Delete(
        string id,
        AccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/accounts/{id}/reauth</c>, but is otherwise the
    /// same as <see cref="IAccountService.Reauth(AccountReauthParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountReauthResponse>> Reauth(
        AccountReauthParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reauth(AccountReauthParams, CancellationToken)"/>
    Task<HttpResponse<AccountReauthResponse>> Reauth(
        string id,
        AccountReauthParams parameters,
        CancellationToken cancellationToken = default
    );
}
