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
    /// Redirect to an active top-up payment page
    /// </summary>
    Task RedirectTopupCheckout(
        CreditRedirectTopupCheckoutParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get credits balance
    /// </summary>
    Task<CreditRetrieveBalanceResponse> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get top-up billing status
    /// </summary>
    Task<CreditRetrieveTopupStatusResponse> RetrieveTopupStatus(
        CreditRetrieveTopupStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a Stripe Checkout session only after the user confirms. The request never
    /// completes payment or adds credits by itself.
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
    /// Returns a raw HTTP response for <c>get /credits/topup/redirect</c>, but is otherwise the
    /// same as <see cref="ICreditService.RedirectTopupCheckout(CreditRedirectTopupCheckoutParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RedirectTopupCheckout(
        CreditRedirectTopupCheckoutParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /credits</c>, but is otherwise the
    /// same as <see cref="ICreditService.RetrieveBalance(CreditRetrieveBalanceParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditRetrieveBalanceResponse>> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /credits/topup/status</c>, but is otherwise the
    /// same as <see cref="ICreditService.RetrieveTopupStatus(CreditRetrieveTopupStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditRetrieveTopupStatusResponse>> RetrieveTopupStatus(
        CreditRetrieveTopupStatusParams parameters,
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
