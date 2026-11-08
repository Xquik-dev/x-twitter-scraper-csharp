// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Events;
using Events = XTwitterScraper.Models.Events;

namespace XTwitterScraper.Services;

/// <summary>
/// Activity events from monitored accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
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
    Task<EventDetail> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<EventDetail> Retrieve(
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

    /// <summary>
    /// Streams the account's monitor events as server-sent events, each named by its event type and numbered by its event ID. A reconnect that sends Last-Event-ID first gets every event after that one from the last 30 days, then each new event. Set lookBack to also get events saved late. A connection lasts up to 30 minutes and sends a comment every 15 seconds while idle. Keep up to 200 streams open per account. Events and streams cost no credits. Add include=post_metrics to also get post.metrics frames. The first poll sends 1 for each post monitor with a check or a pause. After that, a frame comes when a monitor's saved numbers or status change. These frames carry no ID, so Last-Event-ID never moves.
    /// </summary>
    Task<HttpResponse> Stream(
        Events::EventStreamParams? parameters = null,
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
    Task<HttpResponse<EventDetail>> Retrieve(
        EventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EventDetail>> Retrieve(
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /events/stream</c>, but is otherwise the
    /// same as <see cref="IEventService.Stream(Events::EventStreamParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse> Stream(
        Events::EventStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
