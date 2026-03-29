using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Services;

/// <summary>
/// Activity events from monitored accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get event
    /// </summary>
    Task<EventRetrieveResponse> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<EventRetrieveResponse> Retrieve(
        string id,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List events
    /// </summary>
    Task<EventListResponse> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /events/{id}</c>, but is otherwise the
    /// same as <see cref="IEventService.Retrieve(EventRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventRetrieveResponse>> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EventRetrieveResponse>> Retrieve(
        string id,
        EventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /events</c>, but is otherwise the
    /// same as <see cref="IEventService.List(EventListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventListResponse>> List(
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
