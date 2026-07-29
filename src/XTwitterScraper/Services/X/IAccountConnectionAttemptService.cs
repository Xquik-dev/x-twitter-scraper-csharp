using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.AccountConnectionAttempts;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Connected X account management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountConnectionAttemptService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountConnectionAttemptServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionAttemptService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get X account connection status
    /// </summary>
    Task<AccountConnectionAttemptRetrieveResponse> Retrieve(
        AccountConnectionAttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountConnectionAttemptRetrieveParams, CancellationToken)"/>
    Task<AccountConnectionAttemptRetrieveResponse> Retrieve(
        string id,
        AccountConnectionAttemptRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountConnectionAttemptService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountConnectionAttemptServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionAttemptServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/account-connection-attempts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountConnectionAttemptService.Retrieve(AccountConnectionAttemptRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountConnectionAttemptRetrieveResponse>> Retrieve(
        AccountConnectionAttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountConnectionAttemptRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountConnectionAttemptRetrieveResponse>> Retrieve(
        string id,
        AccountConnectionAttemptRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
