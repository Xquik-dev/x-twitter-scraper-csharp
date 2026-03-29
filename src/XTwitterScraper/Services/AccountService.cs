using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AccountRetrieveResponse> Retrieve(
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountSetXUsernameResponse> SetXUsername(
        AccountSetXUsernameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetXUsername(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccountUpdateLocaleResponse> UpdateLocale(
        AccountUpdateLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateLocale(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountRetrieveResponse>> Retrieve(
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response
                    .Deserialize<AccountRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountSetXUsernameResponse>> SetXUsername(
        AccountSetXUsernameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountSetXUsernameParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AccountSetXUsernameResponse>(token)
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
    public async Task<HttpResponse<AccountUpdateLocaleResponse>> UpdateLocale(
        AccountUpdateLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountUpdateLocaleParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AccountUpdateLocaleResponse>(token)
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
