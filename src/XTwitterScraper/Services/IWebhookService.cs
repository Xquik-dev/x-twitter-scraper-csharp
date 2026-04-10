using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Services;

/// <summary>
/// Webhook endpoint management and delivery
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create webhook
    /// </summary>
    Task<WebhookCreateResponse> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update webhook
    /// </summary>
    Task<Webhook> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<Webhook> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List webhooks
    /// </summary>
    Task<WebhookListResponse> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivate webhook
    /// </summary>
    Task<WebhookDeactivateResponse> Deactivate(
        WebhookDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(WebhookDeactivateParams, CancellationToken)"/>
    Task<WebhookDeactivateResponse> Deactivate(
        string id,
        WebhookDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List webhook deliveries
    /// </summary>
    Task<WebhookListDeliveriesResponse> ListDeliveries(
        WebhookListDeliveriesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeliveries(WebhookListDeliveriesParams, CancellationToken)"/>
    Task<WebhookListDeliveriesResponse> ListDeliveries(
        string id,
        WebhookListDeliveriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Test webhook endpoint
    /// </summary>
    Task<WebhookTestResponse> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(WebhookTestParams, CancellationToken)"/>
    Task<WebhookTestResponse> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookCreateResponse>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Webhook>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Webhook>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListResponse>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Deactivate(WebhookDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookDeactivateResponse>> Deactivate(
        WebhookDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(WebhookDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<WebhookDeactivateResponse>> Deactivate(
        string id,
        WebhookDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/{id}/deliveries</c>, but is otherwise the
    /// same as <see cref="IWebhookService.ListDeliveries(WebhookListDeliveriesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListDeliveriesResponse>> ListDeliveries(
        WebhookListDeliveriesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeliveries(WebhookListDeliveriesParams, CancellationToken)"/>
    Task<HttpResponse<WebhookListDeliveriesResponse>> ListDeliveries(
        string id,
        WebhookListDeliveriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/{id}/test</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Test(WebhookTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookTestResponse>> Test(
        WebhookTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(WebhookTestParams, CancellationToken)"/>
    Task<HttpResponse<WebhookTestResponse>> Test(
        string id,
        WebhookTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
