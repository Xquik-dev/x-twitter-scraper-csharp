using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.AccountConnectionChallenges;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Connected X account management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountConnectionChallengeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountConnectionChallengeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionChallengeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Submit X account email verification code
    /// </summary>
    Task<AccountConnectionChallengeSubmitResponse> Submit(
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(AccountConnectionChallengeSubmitParams, CancellationToken)"/>
    Task<AccountConnectionChallengeSubmitResponse> Submit(
        string id,
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountConnectionChallengeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountConnectionChallengeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountConnectionChallengeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/account-connection-challenges/{id}/submit</c>, but is otherwise the
    /// same as <see cref="IAccountConnectionChallengeService.Submit(AccountConnectionChallengeSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountConnectionChallengeSubmitResponse>> Submit(
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(AccountConnectionChallengeSubmitParams, CancellationToken)"/>
    Task<HttpResponse<AccountConnectionChallengeSubmitResponse>> Submit(
        string id,
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    );
}
