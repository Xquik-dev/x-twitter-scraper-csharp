// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Services.Monitors;
using Monitors = XTwitterScraper.Models.Monitors;
using ServicesMonitors = XTwitterScraper.Services.Monitors;

namespace XTwitterScraper.Services;

/// <summary>
/// X account monitoring with 1-second checks
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
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

    IKeywordService Keywords { get; }

    /// <summary>
    /// Creates an account monitor. Monitors are unlimited. Active monitors check every
    /// 1 second and cost 30 credits per hour. Events and webhook deliveries are
    /// included. Creation requires available credits for the first hourly charge and
    /// username lookup.
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
    /// Delete monitor
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

    ServicesMonitors::IPostService Posts { get; }

    /// <summary>
    /// Creates the monitor if it does not exist, or updates it if it does. Send the same call twice &amp; you still have 1 monitor. A new monitor answers 201 &amp; an update answers 200. Both carry `created`, so you know which one ran. Creating needs the credits of the first hour, then costs 30 credits an hour. A stopped monitor turns back on &amp; counts as created. Updating is free &amp; replaces the event types. It changes the name only when you send one.
    /// </summary>
    Task<Monitors::MonitorUpsertByUsernameResponse> UpsertByUsername(
        Monitors::MonitorUpsertByUsernameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpsertByUsername(Monitors::MonitorUpsertByUsernameParams, CancellationToken)"/>
    Task<Monitors::MonitorUpsertByUsernameResponse> UpsertByUsername(
        string username,
        Monitors::MonitorUpsertByUsernameParams parameters,
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

    IKeywordServiceWithRawResponse Keywords { get; }

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

    ServicesMonitors::IPostServiceWithRawResponse Posts { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>put /monitors/username/{username}</c>, but is otherwise the
    /// same as <see cref="IMonitorService.UpsertByUsername(Monitors::MonitorUpsertByUsernameParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Monitors::MonitorUpsertByUsernameResponse>> UpsertByUsername(
        Monitors::MonitorUpsertByUsernameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpsertByUsername(Monitors::MonitorUpsertByUsernameParams, CancellationToken)"/>
    Task<HttpResponse<Monitors::MonitorUpsertByUsernameResponse>> UpsertByUsername(
        string username,
        Monitors::MonitorUpsertByUsernameParams parameters,
        CancellationToken cancellationToken = default
    );
}
