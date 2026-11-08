// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using AccountConnectionLinks = XTwitterScraper.Models.X.AccountConnectionLinks;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class AccountConnectionLinkService : IAccountConnectionLinkService
{
    readonly Lazy<IAccountConnectionLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountConnectionLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAccountConnectionLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountConnectionLinkService(this._client.WithOptions(modifier));
    }

    public AccountConnectionLinkService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountConnectionLinkServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountConnectionLinks::AccountConnectionLinkCreateResponse> Create(
        AccountConnectionLinks::AccountConnectionLinkCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::XAccountConnectionLink> Retrieve(
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XAccountConnectionLink> Retrieve(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountConnectionLinks::AccountConnectionLinkRevokeResponse> Revoke(
        AccountConnectionLinks::AccountConnectionLinkRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountConnectionLinks::AccountConnectionLinkRevokeResponse> Revoke(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revoke(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountConnectionLinkServiceWithRawResponse
    : IAccountConnectionLinkServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountConnectionLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountConnectionLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountConnectionLinkServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<AccountConnectionLinks::AccountConnectionLinkCreateResponse>
    > Create(
        AccountConnectionLinks::AccountConnectionLinkCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountConnectionLinks::AccountConnectionLinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<AccountConnectionLinks::AccountConnectionLinkCreateResponse>(token)
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
    public async Task<HttpResponse<Models::XAccountConnectionLink>> Retrieve(
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountConnectionLinks::AccountConnectionLinkRetrieveParams> request = new()
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
                    .Deserialize<Models::XAccountConnectionLink>(token)
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
    public Task<HttpResponse<Models::XAccountConnectionLink>> Retrieve(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<AccountConnectionLinks::AccountConnectionLinkRevokeResponse>
    > Revoke(
        AccountConnectionLinks::AccountConnectionLinkRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountConnectionLinks::AccountConnectionLinkRevokeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<AccountConnectionLinks::AccountConnectionLinkRevokeResponse>(token)
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
    public Task<HttpResponse<AccountConnectionLinks::AccountConnectionLinkRevokeResponse>> Revoke(
        string id,
        AccountConnectionLinks::AccountConnectionLinkRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revoke(parameters with { ID = id }, cancellationToken);
    }
}
