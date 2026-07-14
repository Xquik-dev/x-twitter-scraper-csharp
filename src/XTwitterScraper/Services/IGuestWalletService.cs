using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Services;

/// <summary>
/// Accountless prepaid access for paid read endpoints
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGuestWalletService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGuestWalletServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGuestWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a one-use Stripe-hosted checkout after the user explicitly confirms a
    /// $10-$250 USD amount. This request creates no charge by itself. The user opens
    /// checkout_url on Stripe. This endpoint returns the paid-read API key without
    /// requiring an Xquik account, email, dashboard, or Xquik web page. An idempotent
    /// replay returns the same key.
    /// </summary>
    Task<GuestWalletCreateResponse> Create(
        GuestWalletCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Poll after Stripe payment. Use usable to decide whether paid reads can run. An
    /// active wallet can remain usable while a top-up is pending. A new wallet becomes
    /// usable only after verified webhook fulfillment. Send the guest key as
    /// Authorization: Bearer.
    /// </summary>
    Task<GuestWalletRetrieveStatusResponse> RetrieveStatus(
        GuestWalletRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a one-use Stripe-hosted checkout for an existing paid-read guest key
    /// after the user explicitly confirms a $10-$250 USD amount. The key remains the
    /// same. This request creates no charge by itself and never redirects through an
    /// Xquik web page.
    /// </summary>
    Task<GuestWalletTopupResponse> Topup(
        GuestWalletTopupParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGuestWalletService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGuestWalletServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGuestWalletServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /guest-wallets</c>, but is otherwise the
    /// same as <see cref="IGuestWalletService.Create(GuestWalletCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GuestWalletCreateResponse>> Create(
        GuestWalletCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /guest-wallets/status</c>, but is otherwise the
    /// same as <see cref="IGuestWalletService.RetrieveStatus(GuestWalletRetrieveStatusParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GuestWalletRetrieveStatusResponse>> RetrieveStatus(
        GuestWalletRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /guest-wallets/topups</c>, but is otherwise the
    /// same as <see cref="IGuestWalletService.Topup(GuestWalletTopupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GuestWalletTopupResponse>> Topup(
        GuestWalletTopupParams parameters,
        CancellationToken cancellationToken = default
    );
}
