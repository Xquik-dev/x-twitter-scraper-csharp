// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Spaces = XTwitterScraper.Models.X.Spaces;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class SpaceService : ISpaceService
{
    readonly Lazy<ISpaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ISpaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpaceService(this._client.WithOptions(modifier));
    }

    public SpaceService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpaceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Spaces::SpaceSearchResponse> Search(
        Spaces::SpaceSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Spaces::SpaceRetrieveResponse> Retrieve(
        Spaces::SpaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Spaces::SpaceRetrieveResponse> Retrieve(
        string id,
        Spaces::SpaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Spaces::SpaceRetrieveReplayResponse> RetrieveReplay(
        Spaces::SpaceRetrieveReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveReplay(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Spaces::SpaceRetrieveReplayResponse> RetrieveReplay(
        string id,
        Spaces::SpaceRetrieveReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveReplay(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpaceServiceWithRawResponse : ISpaceServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpaceServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Spaces::SpaceSearchResponse>> Search(
        Spaces::SpaceSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Spaces::SpaceSearchParams> request = new()
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
                    .Deserialize<Spaces::SpaceSearchResponse>(token)
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
    public async Task<HttpResponse<Spaces::SpaceRetrieveResponse>> Retrieve(
        Spaces::SpaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Spaces::SpaceRetrieveParams> request = new()
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
                    .Deserialize<Spaces::SpaceRetrieveResponse>(token)
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
    public Task<HttpResponse<Spaces::SpaceRetrieveResponse>> Retrieve(
        string id,
        Spaces::SpaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Spaces::SpaceRetrieveReplayResponse>> RetrieveReplay(
        Spaces::SpaceRetrieveReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Spaces::SpaceRetrieveReplayParams> request = new()
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
                    .Deserialize<Spaces::SpaceRetrieveReplayResponse>(token)
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
    public Task<HttpResponse<Spaces::SpaceRetrieveReplayResponse>> RetrieveReplay(
        string id,
        Spaces::SpaceRetrieveReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveReplay(parameters with { ID = id }, cancellationToken);
    }
}
