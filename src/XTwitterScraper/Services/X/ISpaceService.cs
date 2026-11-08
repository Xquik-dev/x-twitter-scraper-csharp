// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Spaces = XTwitterScraper.Models.X.Spaces;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Space operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface ISpaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns public Spaces, each once, with the fields of GET /x/spaces/{id}. Latest &amp; Top find live, scheduled or ended Spaces &amp; accept X search operators. Live &amp; Upcoming find live or scheduled Spaces by title words. Costs 1 credit per Space.
    /// </summary>
    Task<Spaces::SpaceSearchResponse> Search(
        Spaces::SpaceSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 1 X Space as X shows it, live, scheduled or ended. Accepts the Space ID or the URL-encoded Space URL. A Space X limits to subscribers or a community answers 404.
    /// </summary>
    Task<Spaces::SpaceRetrieveResponse> Retrieve(
        Spaces::SpaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Spaces::SpaceRetrieveParams, CancellationToken)"/>
    Task<Spaces::SpaceRetrieveResponse> Retrieve(
        string id,
        Spaces::SpaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the recording X plays back once a Space is over, in state Ended or TimedOut. Accepts the Space ID or the URL-encoded Space URL. Check state and isAvailableForReplay with the Space lookup first. A live or scheduled Space answers 409, and a cancelled one 404.
    /// </summary>
    Task<Spaces::SpaceRetrieveReplayResponse> RetrieveReplay(
        Spaces::SpaceRetrieveReplayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveReplay(Spaces::SpaceRetrieveReplayParams, CancellationToken)"/>
    Task<Spaces::SpaceRetrieveReplayResponse> RetrieveReplay(
        string id,
        Spaces::SpaceRetrieveReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/spaces/search</c>, but is otherwise the
    /// same as <see cref="ISpaceService.Search(Spaces::SpaceSearchParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Spaces::SpaceSearchResponse>> Search(
        Spaces::SpaceSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/spaces/{id}</c>, but is otherwise the
    /// same as <see cref="ISpaceService.Retrieve(Spaces::SpaceRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Spaces::SpaceRetrieveResponse>> Retrieve(
        Spaces::SpaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Spaces::SpaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Spaces::SpaceRetrieveResponse>> Retrieve(
        string id,
        Spaces::SpaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/spaces/{id}/replay</c>, but is otherwise the
    /// same as <see cref="ISpaceService.RetrieveReplay(Spaces::SpaceRetrieveReplayParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Spaces::SpaceRetrieveReplayResponse>> RetrieveReplay(
        Spaces::SpaceRetrieveReplayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveReplay(Spaces::SpaceRetrieveReplayParams, CancellationToken)"/>
    Task<HttpResponse<Spaces::SpaceRetrieveReplayResponse>> RetrieveReplay(
        string id,
        Spaces::SpaceRetrieveReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
