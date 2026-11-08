// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Models = XTwitterScraper.Models;
using Posts = XTwitterScraper.Models.Monitors.Posts;

namespace XTwitterScraper.Services.Monitors;

/// <summary>
/// Post operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPostServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPostService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns post monitors with each post's 6 metrics, their current values &amp; gains since tracking began.
    /// </summary>
    Task<Posts::PostListResponse> List(
        Posts::PostListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a monitor for 1 X post. It tracks replies, quotes, edits, deletion &amp; 6 metrics, for 30 credits an hour with events &amp; webhook deliveries included. That hourly price is a monitor's only charge. Creation needs the credits of the first hour &amp; reads the post once.
    /// </summary>
    Task<Models::PostMonitor> Create(
        Posts::PostCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 1 post monitor with its post &amp; the 6 metrics, each with its current value &amp; gain since tracking began.
    /// </summary>
    Task<Models::PostMonitor> Retrieve(
        Posts::PostRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Posts::PostRetrieveParams, CancellationToken)"/>
    Task<Models::PostMonitor> Retrieve(
        string id,
        Posts::PostRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stops 1 post monitor, then removes its stored events &amp; metric history in bounded batches. Poll statusUrl until the monitor returns 404.
    /// </summary>
    Task<Posts::PostDeleteResponse> Delete(
        Posts::PostDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(Posts::PostDeleteParams, CancellationToken)"/>
    Task<Posts::PostDeleteResponse> Delete(
        string id,
        Posts::PostDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a post monitor's label, event types or active state. Turning a paused monitor on reads the post first, &amp; answers 409 while X hides it.
    /// </summary>
    Task<Models::PostMonitor> Update(
        Posts::PostUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(Posts::PostUpdateParams, CancellationToken)"/>
    Task<Models::PostMonitor> Update(
        string id,
        Posts::PostUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 1 bucket per hour with each metric's value at the hour's end &amp; its gain over that hour. The last bucket is the current hour. Hours before tracking began carry the starting values with a gain of 0.
    /// </summary>
    Task<Models::PostMonitorMetrics> RetrieveMetrics(
        Posts::PostRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMetrics(Posts::PostRetrieveMetricsParams, CancellationToken)"/>
    Task<Models::PostMonitorMetrics> RetrieveMetrics(
        string id,
        Posts::PostRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPostService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPostServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPostServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/posts</c>, but is otherwise the
    /// same as <see cref="IPostService.List(Posts::PostListParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Posts::PostListResponse>> List(
        Posts::PostListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /monitors/posts</c>, but is otherwise the
    /// same as <see cref="IPostService.Create(Posts::PostCreateParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PostMonitor>> Create(
        Posts::PostCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/posts/{id}</c>, but is otherwise the
    /// same as <see cref="IPostService.Retrieve(Posts::PostRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PostMonitor>> Retrieve(
        Posts::PostRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Posts::PostRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Models::PostMonitor>> Retrieve(
        string id,
        Posts::PostRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /monitors/posts/{id}</c>, but is otherwise the
    /// same as <see cref="IPostService.Delete(Posts::PostDeleteParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Posts::PostDeleteResponse>> Delete(
        Posts::PostDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(Posts::PostDeleteParams, CancellationToken)"/>
    Task<HttpResponse<Posts::PostDeleteResponse>> Delete(
        string id,
        Posts::PostDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /monitors/posts/{id}</c>, but is otherwise the
    /// same as <see cref="IPostService.Update(Posts::PostUpdateParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PostMonitor>> Update(
        Posts::PostUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(Posts::PostUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Models::PostMonitor>> Update(
        string id,
        Posts::PostUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/posts/{id}/metrics</c>, but is otherwise the
    /// same as <see cref="IPostService.RetrieveMetrics(Posts::PostRetrieveMetricsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PostMonitorMetrics>> RetrieveMetrics(
        Posts::PostRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMetrics(Posts::PostRetrieveMetricsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PostMonitorMetrics>> RetrieveMetrics(
        string id,
        Posts::PostRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
