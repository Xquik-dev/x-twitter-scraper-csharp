// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Broadcasts = XTwitterScraper.Models.X.Broadcasts;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class BroadcastService : IBroadcastService
{
    readonly Lazy<IBroadcastServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastService(this._client.WithOptions(modifier));
    }

    public BroadcastService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BroadcastServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Broadcasts::BroadcastRetrieveResponse> Retrieve(
        Broadcasts::BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcasts::BroadcastRetrieveResponse> Retrieve(
        string id,
        Broadcasts::BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BroadcastServiceWithRawResponse : IBroadcastServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BroadcastServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcasts::BroadcastRetrieveResponse>> Retrieve(
        Broadcasts::BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Broadcasts::BroadcastRetrieveParams> request = new()
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
                    .Deserialize<Broadcasts::BroadcastRetrieveResponse>(token)
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
    public Task<HttpResponse<Broadcasts::BroadcastRetrieveResponse>> Retrieve(
        string id,
        Broadcasts::BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
