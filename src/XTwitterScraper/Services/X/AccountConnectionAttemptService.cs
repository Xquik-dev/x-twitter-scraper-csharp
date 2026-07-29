// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.AccountConnectionAttempts;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class AccountConnectionAttemptService : IAccountConnectionAttemptService
{
    readonly Lazy<IAccountConnectionAttemptServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountConnectionAttemptServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAccountConnectionAttemptService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountConnectionAttemptService(this._client.WithOptions(modifier));
    }

    public AccountConnectionAttemptService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountConnectionAttemptServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountConnectionAttemptRetrieveResponse> Retrieve(
        AccountConnectionAttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountConnectionAttemptRetrieveResponse> Retrieve(
        string id,
        AccountConnectionAttemptRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountConnectionAttemptServiceWithRawResponse
    : IAccountConnectionAttemptServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountConnectionAttemptServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountConnectionAttemptServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public AccountConnectionAttemptServiceWithRawResponse(
        IXTwitterScraperClientWithRawResponse client
    )
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountConnectionAttemptRetrieveResponse>> Retrieve(
        AccountConnectionAttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountConnectionAttemptRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountConnectionAttempt = await response
                    .Deserialize<AccountConnectionAttemptRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountConnectionAttempt.Validate();
                }
                return accountConnectionAttempt;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountConnectionAttemptRetrieveResponse>> Retrieve(
        string id,
        AccountConnectionAttemptRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
