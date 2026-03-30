using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Services;

/// <summary>
/// Push notification integrations (Telegram)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIntegrationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntegrationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create integration
    /// </summary>
    Task<Integration> Create(
        IntegrationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get integration details
    /// </summary>
    Task<Integration> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<Integration> Retrieve(
        string id,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update integration
    /// </summary>
    Task<Integration> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IntegrationUpdateParams, CancellationToken)"/>
    Task<Integration> Update(
        string id,
        IntegrationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List integrations
    /// </summary>
    Task<IntegrationListResponse> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete integration
    /// </summary>
    Task<IntegrationDeleteResponse> Delete(
        IntegrationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(IntegrationDeleteParams, CancellationToken)"/>
    Task<IntegrationDeleteResponse> Delete(
        string id,
        IntegrationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List integration delivery history
    /// </summary>
    Task<IntegrationListDeliveriesResponse> ListDeliveries(
        IntegrationListDeliveriesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeliveries(IntegrationListDeliveriesParams, CancellationToken)"/>
    Task<IntegrationListDeliveriesResponse> ListDeliveries(
        string id,
        IntegrationListDeliveriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send test delivery
    /// </summary>
    Task<IntegrationSendTestResponse> SendTest(
        IntegrationSendTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SendTest(IntegrationSendTestParams, CancellationToken)"/>
    Task<IntegrationSendTestResponse> SendTest(
        string id,
        IntegrationSendTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntegrationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntegrationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /integrations</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Create(IntegrationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Integration>> Create(
        IntegrationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /integrations/{id}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Retrieve(IntegrationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Integration>> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Integration>> Retrieve(
        string id,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /integrations/{id}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Update(IntegrationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Integration>> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IntegrationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Integration>> Update(
        string id,
        IntegrationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /integrations</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.List(IntegrationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationListResponse>> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /integrations/{id}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Delete(IntegrationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationDeleteResponse>> Delete(
        IntegrationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(IntegrationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationDeleteResponse>> Delete(
        string id,
        IntegrationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /integrations/{id}/deliveries</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.ListDeliveries(IntegrationListDeliveriesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationListDeliveriesResponse>> ListDeliveries(
        IntegrationListDeliveriesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeliveries(IntegrationListDeliveriesParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationListDeliveriesResponse>> ListDeliveries(
        string id,
        IntegrationListDeliveriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /integrations/{id}/test</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.SendTest(IntegrationSendTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationSendTestResponse>> SendTest(
        IntegrationSendTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SendTest(IntegrationSendTestParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationSendTestResponse>> SendTest(
        string id,
        IntegrationSendTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
