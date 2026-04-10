using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Services;

/// <summary>
/// Account info and settings
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
    /// Get account info
    /// </summary>
    Task<AccountRetrieveResponse> Retrieve(
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set linked X username
    /// </summary>
    Task<AccountSetXUsernameResponse> SetXUsername(
        AccountSetXUsernameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update account locale
    /// </summary>
    Task<AccountUpdateLocaleResponse> UpdateLocale(
        AccountUpdateLocaleParams parameters,
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
    /// Returns a raw HTTP response for <c>get /account</c>, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountRetrieveResponse>> Retrieve(
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /account/x-identity</c>, but is otherwise the
    /// same as <see cref="IAccountService.SetXUsername(AccountSetXUsernameParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountSetXUsernameResponse>> SetXUsername(
        AccountSetXUsernameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /account</c>, but is otherwise the
    /// same as <see cref="IAccountService.UpdateLocale(AccountUpdateLocaleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountUpdateLocaleResponse>> UpdateLocale(
        AccountUpdateLocaleParams parameters,
        CancellationToken cancellationToken = default
    );
}
