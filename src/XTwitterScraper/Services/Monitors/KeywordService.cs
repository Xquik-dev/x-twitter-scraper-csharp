// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Services.Monitors;

/// <inheritdoc/>
public sealed class KeywordService : IKeywordService
{
    readonly Lazy<IKeywordServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKeywordServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IKeywordService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KeywordService(this._client.WithOptions(modifier));
    }

    public KeywordService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new KeywordServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<KeywordCreateResponse> Create(
        KeywordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<KeywordRetrieveResponse> Retrieve(
        KeywordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KeywordRetrieveResponse> Retrieve(
        string id,
        KeywordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KeywordUpdateResponse> Update(
        KeywordUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KeywordUpdateResponse> Update(
        string id,
        KeywordUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KeywordListResponse> List(
        KeywordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<KeywordDeactivateResponse> Deactivate(
        KeywordDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KeywordDeactivateResponse> Deactivate(
        string id,
        KeywordDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class KeywordServiceWithRawResponse : IKeywordServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKeywordServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KeywordServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KeywordServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeywordCreateResponse>> Create(
        KeywordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<KeywordCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var keyword = await response
                    .Deserialize<KeywordCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    keyword.Validate();
                }
                return keyword;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeywordRetrieveResponse>> Retrieve(
        KeywordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<KeywordRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var keyword = await response
                    .Deserialize<KeywordRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    keyword.Validate();
                }
                return keyword;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KeywordRetrieveResponse>> Retrieve(
        string id,
        KeywordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeywordUpdateResponse>> Update(
        KeywordUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<KeywordUpdateParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var keyword = await response
                    .Deserialize<KeywordUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    keyword.Validate();
                }
                return keyword;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KeywordUpdateResponse>> Update(
        string id,
        KeywordUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeywordListResponse>> List(
        KeywordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<KeywordListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var keywords = await response
                    .Deserialize<KeywordListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    keywords.Validate();
                }
                return keywords;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeywordDeactivateResponse>> Deactivate(
        KeywordDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<KeywordDeactivateParams> request = new()
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
                    .Deserialize<KeywordDeactivateResponse>(token)
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
    public Task<HttpResponse<KeywordDeactivateResponse>> Deactivate(
        string id,
        KeywordDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }
}
