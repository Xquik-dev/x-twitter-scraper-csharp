using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class ApiKeyService : IApiKeyService
{
    readonly Lazy<IApiKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyService(this._client.WithOptions(modifier));
    }

    public ApiKeyService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ApiKeyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiKeyCreateResponse> Create(
        ApiKeyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiKeyListResponse> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ApiKeyRevokeResponse> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiKeyRevokeResponse> Revoke(
        string id,
        ApiKeyRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revoke(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ApiKeyServiceWithRawResponse : IApiKeyServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ApiKeyServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyCreateResponse>> Create(
        ApiKeyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ApiKeyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiKey = await response
                    .Deserialize<ApiKeyCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiKey.Validate();
                }
                return apiKey;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyListResponse>> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ApiKeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiKeys = await response
                    .Deserialize<ApiKeyListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiKeys.Validate();
                }
                return apiKeys;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyRevokeResponse>> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ApiKeyRevokeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ApiKeyRevokeResponse>(token)
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
    public Task<HttpResponse<ApiKeyRevokeResponse>> Revoke(
        string id,
        ApiKeyRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revoke(parameters with { ID = id }, cancellationToken);
    }
}
