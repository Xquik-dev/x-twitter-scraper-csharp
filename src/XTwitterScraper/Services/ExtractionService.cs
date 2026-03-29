using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class ExtractionService : IExtractionService
{
    readonly Lazy<IExtractionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExtractionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IExtractionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExtractionService(this._client.WithOptions(modifier));
    }

    public ExtractionService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExtractionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ExtractionRetrieveResponse> Retrieve(
        ExtractionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractionRetrieveResponse> Retrieve(
        string id,
        ExtractionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractionListResponse> List(
        ExtractionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExtractionEstimateCostResponse> EstimateCost(
        ExtractionEstimateCostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.EstimateCost(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportResults(
        ExtractionExportResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportResults(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportResults(
        string id,
        ExtractionExportResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ExportResults(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractionRunResponse> Run(
        ExtractionRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExtractionServiceWithRawResponse : IExtractionServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExtractionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExtractionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExtractionServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractionRetrieveResponse>> Retrieve(
        ExtractionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ExtractionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extraction = await response
                    .Deserialize<ExtractionRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extraction.Validate();
                }
                return extraction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractionRetrieveResponse>> Retrieve(
        string id,
        ExtractionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractionListResponse>> List(
        ExtractionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExtractionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractions = await response
                    .Deserialize<ExtractionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractions.Validate();
                }
                return extractions;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractionEstimateCostResponse>> EstimateCost(
        ExtractionEstimateCostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExtractionEstimateCostParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ExtractionEstimateCostResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportResults(
        ExtractionExportResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ExtractionExportResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportResults(
        string id,
        ExtractionExportResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ExportResults(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractionRunResponse>> Run(
        ExtractionRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExtractionRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ExtractionRunResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
