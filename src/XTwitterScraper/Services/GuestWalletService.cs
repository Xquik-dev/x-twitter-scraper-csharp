// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class GuestWalletService : IGuestWalletService
{
    readonly Lazy<IGuestWalletServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGuestWalletServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IGuestWalletService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GuestWalletService(this._client.WithOptions(modifier));
    }

    public GuestWalletService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GuestWalletServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GuestWalletCreateResponse> Create(
        GuestWalletCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GuestWalletRetrieveStatusResponse> RetrieveStatus(
        GuestWalletRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GuestWalletTopupResponse> Topup(
        GuestWalletTopupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Topup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GuestWalletServiceWithRawResponse : IGuestWalletServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGuestWalletServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GuestWalletServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GuestWalletServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GuestWalletCreateResponse>> Create(
        GuestWalletCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GuestWalletCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var guestWallet = await response
                    .Deserialize<GuestWalletCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    guestWallet.Validate();
                }
                return guestWallet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GuestWalletRetrieveStatusResponse>> RetrieveStatus(
        GuestWalletRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GuestWalletRetrieveStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<GuestWalletRetrieveStatusResponse>(token)
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
    public async Task<HttpResponse<GuestWalletTopupResponse>> Topup(
        GuestWalletTopupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GuestWalletTopupParams> request = new()
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
                    .Deserialize<GuestWalletTopupResponse>(token)
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
