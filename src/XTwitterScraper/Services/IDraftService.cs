using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Services;

/// <summary>
/// AI tweet composition, drafts, writing styles, and radar
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDraftService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDraftServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Save a tweet draft
    /// </summary>
    Task<DraftDetail> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get draft by ID
    /// </summary>
    Task<DraftDetail> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DraftRetrieveParams, CancellationToken)"/>
    Task<DraftDetail> Retrieve(
        string id,
        DraftRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List saved drafts
    /// </summary>
    Task<DraftListResponse> List(
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a draft
    /// </summary>
    Task Delete(DraftDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DraftDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        DraftDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDraftService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDraftServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /drafts</c>, but is otherwise the
    /// same as <see cref="IDraftService.Create(DraftCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftDetail>> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /drafts/{id}</c>, but is otherwise the
    /// same as <see cref="IDraftService.Retrieve(DraftRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftDetail>> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DraftRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DraftDetail>> Retrieve(
        string id,
        DraftRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /drafts</c>, but is otherwise the
    /// same as <see cref="IDraftService.List(DraftListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftListResponse>> List(
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /drafts/{id}</c>, but is otherwise the
    /// same as <see cref="IDraftService.Delete(DraftDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DraftDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        DraftDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
