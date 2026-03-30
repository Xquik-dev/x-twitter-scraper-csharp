using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Monitors = XTwitterScraper.Models.Monitors;

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
    Task<Monitors::MonitorCreateResponse> Create(
        Monitors::MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get monitor
    /// </summary>
    Task<Monitors::Monitor> Retrieve(
        Monitors::MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Monitors::MonitorRetrieveParams, CancellationToken)"/>
    Task<Monitors::Monitor> Retrieve(
        string id,
        Monitors::MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update monitor
    /// </summary>
    Task<Monitors::Monitor> Update(
        Monitors::MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(Monitors::MonitorUpdateParams, CancellationToken)"/>
    Task<Monitors::Monitor> Update(
        string id,
        Monitors::MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List monitors
    /// </summary>
    Task<Monitors::MonitorListResponse> List(
        Monitors::MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivate monitor
    /// </summary>
    Task<Monitors::MonitorDeactivateResponse> Deactivate(
        Monitors::MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(Monitors::MonitorDeactivateParams, CancellationToken)"/>
    Task<Monitors::MonitorDeactivateResponse> Deactivate(
        string id,
        Monitors::MonitorDeactivateParams? parameters = null,
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
    /// same as <see cref="IMonitorService.Create(Monitors::MonitorCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Monitors::MonitorCreateResponse>> Create(
        Monitors::MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Retrieve(Monitors::MonitorRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Monitors::Monitor>> Retrieve(
        Monitors::MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Monitors::MonitorRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Monitors::Monitor>> Retrieve(
        string id,
        Monitors::MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Update(Monitors::MonitorUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Monitors::Monitor>> Update(
        Monitors::MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(Monitors::MonitorUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Monitors::Monitor>> Update(
        string id,
        Monitors::MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors</c>, but is otherwise the
    /// same as <see cref="IMonitorService.List(Monitors::MonitorListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Monitors::MonitorListResponse>> List(
        Monitors::MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /monitors/{id}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.Deactivate(Monitors::MonitorDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Monitors::MonitorDeactivateResponse>> Deactivate(
        Monitors::MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(Monitors::MonitorDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<Monitors::MonitorDeactivateResponse>> Deactivate(
        string id,
        Monitors::MonitorDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
