using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Services;

/// <summary>
/// Giveaway draws from tweet replies
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDrawService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDrawServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDrawService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get draw details
    /// </summary>
    Task<DrawRetrieveResponse> Retrieve(
        DrawRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DrawRetrieveParams, CancellationToken)"/>
    Task<DrawRetrieveResponse> Retrieve(
        string id,
        DrawRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List draws
    /// </summary>
    Task<DrawListResponse> List(
        DrawListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export draw data
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Export(
        DrawExportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Export(DrawExportParams, CancellationToken)"/>
    Task<HttpResponse> Export(
        string id,
        DrawExportParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run giveaway draw
    /// </summary>
    Task<DrawRunResponse> Run(
        DrawRunParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDrawService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDrawServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDrawServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /draws/{id}</c>, but is otherwise the
    /// same as <see cref="IDrawService.Retrieve(DrawRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DrawRetrieveResponse>> Retrieve(
        DrawRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DrawRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DrawRetrieveResponse>> Retrieve(
        string id,
        DrawRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /draws</c>, but is otherwise the
    /// same as <see cref="IDrawService.List(DrawListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DrawListResponse>> List(
        DrawListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /draws/{id}/export</c>, but is otherwise the
    /// same as <see cref="IDrawService.Export(DrawExportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Export(
        DrawExportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Export(DrawExportParams, CancellationToken)"/>
    Task<HttpResponse> Export(
        string id,
        DrawExportParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /draws</c>, but is otherwise the
    /// same as <see cref="IDrawService.Run(DrawRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DrawRunResponse>> Run(
        DrawRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
