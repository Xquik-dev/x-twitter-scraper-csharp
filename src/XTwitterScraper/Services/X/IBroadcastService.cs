// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Broadcasts = XTwitterScraper.Models.X.Broadcasts;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Broadcast operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IBroadcastService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBroadcastServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns 1 X broadcast, the live video X hosts at x.com/i/broadcasts, live or ended. Accepts the broadcast ID or the URL-encoded broadcast URL. Reading a broadcast adds no view to it.
    /// </summary>
    Task<Broadcasts::BroadcastRetrieveResponse> Retrieve(
        Broadcasts::BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Broadcasts::BroadcastRetrieveParams, CancellationToken)"/>
    Task<Broadcasts::BroadcastRetrieveResponse> Retrieve(
        string id,
        Broadcasts::BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBroadcastService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBroadcastServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/broadcasts/{id}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Retrieve(Broadcasts::BroadcastRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Broadcasts::BroadcastRetrieveResponse>> Retrieve(
        Broadcasts::BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Broadcasts::BroadcastRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Broadcasts::BroadcastRetrieveResponse>> Retrieve(
        string id,
        Broadcasts::BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
