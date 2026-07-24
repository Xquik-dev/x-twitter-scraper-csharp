// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class CreditService : ICreditService
{
    readonly Lazy<ICreditServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditService(this._client.WithOptions(modifier));
    }

    public CreditService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CreditServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task RedirectTopupCheckout(
        CreditRedirectTopupCheckoutParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RedirectTopupCheckout(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CreditRetrieveBalanceResponse> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditRetrieveTopupStatusResponse> RetrieveTopupStatus(
        CreditRetrieveTopupStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveTopupStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditTopupBalanceResponse> TopupBalance(
        CreditTopupBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TopupBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CreditServiceWithRawResponse : ICreditServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RedirectTopupCheckout(
        CreditRedirectTopupCheckoutParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditRedirectTopupCheckoutParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditRetrieveBalanceResponse>> RetrieveBalance(
        CreditRetrieveBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CreditRetrieveBalanceParams> request = new()
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
                    .Deserialize<CreditRetrieveBalanceResponse>(token)
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
    public async Task<HttpResponse<CreditRetrieveTopupStatusResponse>> RetrieveTopupStatus(
        CreditRetrieveTopupStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditRetrieveTopupStatusParams> request = new()
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
                    .Deserialize<CreditRetrieveTopupStatusResponse>(token)
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
    public async Task<HttpResponse<CreditTopupBalanceResponse>> TopupBalance(
        CreditTopupBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditTopupBalanceParams> request = new()
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
                    .Deserialize<CreditTopupBalanceResponse>(token)
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
