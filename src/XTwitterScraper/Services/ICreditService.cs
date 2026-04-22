using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Services;

/// <summary>
/// Subscription, billing, and credits
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICreditService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICreditServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get credits balance
    /// </summary>
    Task<CreditRetrieveBalanceResponse> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Top up credits balance
    /// </summary>
    Task<CreditTopupBalanceResponse> TopupBalance(
        CreditTopupBalanceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICreditService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICreditServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /credits</c>, but is otherwise the
    /// same as <see cref="ICreditService.RetrieveBalance(CreditRetrieveBalanceParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditRetrieveBalanceResponse>> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /credits/topup</c>, but is otherwise the
    /// same as <see cref="ICreditService.TopupBalance(CreditTopupBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditTopupBalanceResponse>> TopupBalance(
        CreditTopupBalanceParams parameters,
        CancellationToken cancellationToken = default
    );
}
