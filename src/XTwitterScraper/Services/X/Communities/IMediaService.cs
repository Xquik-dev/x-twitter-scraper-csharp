// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Media = XTwitterScraper.Models.X.Communities.Media;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X.Communities;

/// <summary>
/// Media operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IMediaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMediaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the tweets with photos or videos on 1 community's Media tab, newest first. Each tweet costs 1 credit.
    /// </summary>
    Task<Models::PaginatedTweets2> List(
        Media::MediaListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(Media::MediaListParams, CancellationToken)"/>
    Task<Models::PaginatedTweets2> List(
        string id,
        Media::MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMediaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMediaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/{id}/media</c>, but is otherwise the
    /// same as <see cref="IMediaService.List(Media::MediaListParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedTweets2>> List(
        Media::MediaListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(Media::MediaListParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedTweets2>> List(
        string id,
        Media::MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
