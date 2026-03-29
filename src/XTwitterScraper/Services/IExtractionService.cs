using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Services;

/// <summary>
/// Bulk data extraction (20 tool types)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExtractionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExtractionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get extraction results
    /// </summary>
    Task<ExtractionRetrieveResponse> Retrieve(
        ExtractionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExtractionRetrieveParams, CancellationToken)"/>
    Task<ExtractionRetrieveResponse> Retrieve(
        string id,
        ExtractionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List extraction jobs
    /// </summary>
    Task<ExtractionListResponse> List(
        ExtractionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Estimate extraction cost
    /// </summary>
    Task<ExtractionEstimateCostResponse> EstimateCost(
        ExtractionEstimateCostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export extraction results
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportResults(
        ExtractionExportResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExportResults(ExtractionExportResultsParams, CancellationToken)"/>
    Task<HttpResponse> ExportResults(
        string id,
        ExtractionExportResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run extraction
    /// </summary>
    Task<ExtractionRunResponse> Run(
        ExtractionRunParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExtractionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExtractionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /extractions/{id}</c>, but is otherwise the
    /// same as <see cref="IExtractionService.Retrieve(ExtractionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractionRetrieveResponse>> Retrieve(
        ExtractionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExtractionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ExtractionRetrieveResponse>> Retrieve(
        string id,
        ExtractionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /extractions</c>, but is otherwise the
    /// same as <see cref="IExtractionService.List(ExtractionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractionListResponse>> List(
        ExtractionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /extractions/estimate</c>, but is otherwise the
    /// same as <see cref="IExtractionService.EstimateCost(ExtractionEstimateCostParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractionEstimateCostResponse>> EstimateCost(
        ExtractionEstimateCostParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /extractions/{id}/export</c>, but is otherwise the
    /// same as <see cref="IExtractionService.ExportResults(ExtractionExportResultsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportResults(
        ExtractionExportResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ExportResults(ExtractionExportResultsParams, CancellationToken)"/>
    Task<HttpResponse> ExportResults(
        string id,
        ExtractionExportResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /extractions</c>, but is otherwise the
    /// same as <see cref="IExtractionService.Run(ExtractionRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractionRunResponse>> Run(
        ExtractionRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
