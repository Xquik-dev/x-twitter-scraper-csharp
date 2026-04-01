using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Services;

/// <summary>
/// Real-time X account monitoring
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMonitorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMonitorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMonitorService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create monitor
    /// </summary>
    Task<MonitorCreateResponse> Create(
        MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get monitor
    /// </summary>
    Task<MonitorRetrieveResponse> Retrieve(
        MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MonitorRetrieveParams, CancellationToken)"/>
    Task<MonitorRetrieveResponse> Retrieve(
        string id,
        MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update monitor
    /// </summary>
    Task<MonitorUpdateResponse> Update(
        MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MonitorUpdateParams, CancellationToken)"/>
    Task<MonitorUpdateResponse> Update(
        string id,
        MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List monitors
    /// </summary>
    Task<MonitorListResponse> List(
        MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivate monitor
    /// </summary>
    Task<MonitorDeactivateResponse> Deactivate(
        MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(MonitorDeactivateParams, CancellationToken)"/>
    Task<MonitorDeactivateResponse> Deactivate(
        string id,
        MonitorDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMonitorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMonitorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMonitorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /monitors</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Create(MonitorCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MonitorCreateResponse>> Create(
        MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Retrieve(MonitorRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MonitorRetrieveResponse>> Retrieve(
        MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MonitorRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MonitorRetrieveResponse>> Retrieve(
        string id,
        MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Update(MonitorUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MonitorUpdateResponse>> Update(
        MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MonitorUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MonitorUpdateResponse>> Update(
        string id,
        MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors</c>, but is otherwise the
    /// same as <see cref="IMonitorService.List(MonitorListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MonitorListResponse>> List(
        MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Deactivate(MonitorDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MonitorDeactivateResponse>> Deactivate(
        MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(MonitorDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<MonitorDeactivateResponse>> Deactivate(
        string id,
        MonitorDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
