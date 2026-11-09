// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Jobs = XTwitterScraper.Models.X.Jobs;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class JobService : IJobService
{
    readonly Lazy<IJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobService(this._client.WithOptions(modifier));
    }

    public JobService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JobServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedJobs> Search(
        Jobs::JobSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::JobLocations> ListLocations(
        Jobs::JobListLocationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLocations(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Jobs::JobRetrieveResponse> Retrieve(
        Jobs::JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Jobs::JobRetrieveResponse> Retrieve(
        string id,
        Jobs::JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JobServiceWithRawResponse : IJobServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedJobs>> Search(
        Jobs::JobSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Jobs::JobSearchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::PaginatedJobs>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::JobLocations>> ListLocations(
        Jobs::JobListLocationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Jobs::JobListLocationsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::JobLocations>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Jobs::JobRetrieveResponse>> Retrieve(
        Jobs::JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Jobs::JobRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Jobs::JobRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Jobs::JobRetrieveResponse>> Retrieve(
        string id,
        Jobs::JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
