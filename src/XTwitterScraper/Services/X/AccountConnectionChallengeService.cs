// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.AccountConnectionChallenges;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class AccountConnectionChallengeService : IAccountConnectionChallengeService
{
    readonly Lazy<IAccountConnectionChallengeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountConnectionChallengeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAccountConnectionChallengeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountConnectionChallengeService(this._client.WithOptions(modifier));
    }

    public AccountConnectionChallengeService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AccountConnectionChallengeServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AccountConnectionChallengeSubmitResponse> Submit(
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountConnectionChallengeSubmitResponse> Submit(
        string id,
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Submit(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountConnectionChallengeServiceWithRawResponse
    : IAccountConnectionChallengeServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountConnectionChallengeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountConnectionChallengeServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public AccountConnectionChallengeServiceWithRawResponse(
        IXTwitterScraperClientWithRawResponse client
    )
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountConnectionChallengeSubmitResponse>> Submit(
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountConnectionChallengeSubmitParams> request = new()
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
                    .Deserialize<AccountConnectionChallengeSubmitResponse>(token)
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
    public Task<HttpResponse<AccountConnectionChallengeSubmitResponse>> Submit(
        string id,
        AccountConnectionChallengeSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Submit(parameters with { ID = id }, cancellationToken);
    }
}
