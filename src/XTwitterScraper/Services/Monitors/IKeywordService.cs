// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Services.Monitors;

/// <summary>
/// X account monitoring with 1-second checks
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IKeywordService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKeywordServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKeywordService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a keyword monitor. Keyword monitors are unlimited. Active monitors check
    /// every 1 second and cost 21 credits per hour. Events and webhook deliveries are
    /// included. Creation requires available credits for the first hourly charge.
    /// </summary>
    Task<KeywordCreateResponse> Create(
        KeywordCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get keyword monitor
    /// </summary>
    Task<KeywordRetrieveResponse> Retrieve(
        KeywordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(KeywordRetrieveParams, CancellationToken)"/>
    Task<KeywordRetrieveResponse> Retrieve(
        string id,
        KeywordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update keyword monitor
    /// </summary>
    Task<KeywordUpdateResponse> Update(
        KeywordUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(KeywordUpdateParams, CancellationToken)"/>
    Task<KeywordUpdateResponse> Update(
        string id,
        KeywordUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List keyword monitors
    /// </summary>
    Task<KeywordListResponse> List(
        KeywordListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete keyword monitor
    /// </summary>
    Task<KeywordDeactivateResponse> Deactivate(
        KeywordDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(KeywordDeactivateParams, CancellationToken)"/>
    Task<KeywordDeactivateResponse> Deactivate(
        string id,
        KeywordDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IKeywordService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKeywordServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKeywordServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /monitors/keywords</c>, but is otherwise the
    /// same as <see cref="IKeywordService.Create(KeywordCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KeywordCreateResponse>> Create(
        KeywordCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/keywords/{id}</c>, but is otherwise the
    /// same as <see cref="IKeywordService.Retrieve(KeywordRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KeywordRetrieveResponse>> Retrieve(
        KeywordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(KeywordRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<KeywordRetrieveResponse>> Retrieve(
        string id,
        KeywordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /monitors/keywords/{id}</c>, but is otherwise the
    /// same as <see cref="IKeywordService.Update(KeywordUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KeywordUpdateResponse>> Update(
        KeywordUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(KeywordUpdateParams, CancellationToken)"/>
    Task<HttpResponse<KeywordUpdateResponse>> Update(
        string id,
        KeywordUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /monitors/keywords</c>, but is otherwise the
    /// same as <see cref="IKeywordService.List(KeywordListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KeywordListResponse>> List(
        KeywordListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /monitors/keywords/{id}</c>, but is otherwise the
    /// same as <see cref="IKeywordService.Deactivate(KeywordDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KeywordDeactivateResponse>> Deactivate(
        KeywordDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(KeywordDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<KeywordDeactivateResponse>> Deactivate(
        string id,
        KeywordDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
