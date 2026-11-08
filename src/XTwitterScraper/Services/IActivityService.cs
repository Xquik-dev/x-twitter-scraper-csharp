// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Activity = XTwitterScraper.Models.Activity;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services;

/// <summary>
/// Activity operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActivityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActivityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the account's activity log, newest first, with the Activity page's filters. It covers write actions, extractions, monitor changes and events, webhooks, giveaways, media, support, API keys, X account connections and billing. Pick a file format to get the same rows as a CSV, Excel, Markdown, PDF or text file.
    /// </summary>
    Task<IReadOnlyList<Models::ActivityLogRow>> List(
        Activity::ActivityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 1 activity of the account with its full technical record. It covers every kind of activity the Activity log shows. The record holds the request, the caller, the charge, every timestamp in UTC and related activity. It never holds an API key value, a webhook secret or another account's data. Only a signed-in dashboard session sees an `api_key` record, so an API key or an OAuth app gets 404 for its ID.
    /// </summary>
    Task<Models::ActivityRecord> Retrieve(
        Activity::ActivityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Activity::ActivityRetrieveParams, CancellationToken)"/>
    Task<Models::ActivityRecord> Retrieve(
        string id,
        Activity::ActivityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IActivityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActivityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActivityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /activity</c>, but is otherwise the
    /// same as <see cref="IActivityService.List(Activity::ActivityListParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<IReadOnlyList<Models::ActivityLogRow>>> List(
        Activity::ActivityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /activity/{id}</c>, but is otherwise the
    /// same as <see cref="IActivityService.Retrieve(Activity::ActivityRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::ActivityRecord>> Retrieve(
        Activity::ActivityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Activity::ActivityRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Models::ActivityRecord>> Retrieve(
        string id,
        Activity::ActivityRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
