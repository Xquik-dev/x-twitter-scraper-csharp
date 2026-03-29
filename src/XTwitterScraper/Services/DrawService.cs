using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class DrawService : IDrawService
{
    readonly Lazy<IDrawServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDrawServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IDrawService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DrawService(this._client.WithOptions(modifier));
    }

    public DrawService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DrawServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DrawRetrieveResponse> Retrieve(
        DrawRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DrawRetrieveResponse> Retrieve(
        string id,
        DrawRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DrawListResponse> List(
        DrawListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Export(
        DrawExportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Export(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Export(
        string id,
        DrawExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Export(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DrawRunResponse> Run(
        DrawRunParams parameters,
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
public sealed class DrawServiceWithRawResponse : IDrawServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDrawServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DrawServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DrawServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DrawRetrieveResponse>> Retrieve(
        DrawRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DrawRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var draw = await response
                    .Deserialize<DrawRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    draw.Validate();
                }
                return draw;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DrawRetrieveResponse>> Retrieve(
        string id,
        DrawRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DrawListResponse>> List(
        DrawListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DrawListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var draws = await response
                    .Deserialize<DrawListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    draws.Validate();
                }
                return draws;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Export(
        DrawExportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DrawExportParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Export(
        string id,
        DrawExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Export(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DrawRunResponse>> Run(
        DrawRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DrawRunParams> request = new()
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
                    .Deserialize<DrawRunResponse>(token)
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
