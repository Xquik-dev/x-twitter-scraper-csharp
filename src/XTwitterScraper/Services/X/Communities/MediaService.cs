// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Media = XTwitterScraper.Models.X.Communities.Media;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X.Communities;

/// <inheritdoc/>
public sealed class MediaService : IMediaService
{
    readonly Lazy<IMediaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMediaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IMediaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MediaService(this._client.WithOptions(modifier));
    }

    public MediaService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MediaServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedTweets2> List(
        Media::MediaListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedTweets2> List(
        string id,
        Media::MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MediaServiceWithRawResponse : IMediaServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMediaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MediaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MediaServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedTweets2>> List(
        Media::MediaListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Media::MediaListParams> request = new()
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
                    .Deserialize<Models::PaginatedTweets2>(token)
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
    public Task<HttpResponse<Models::PaginatedTweets2>> List(
        string id,
        Media::MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}
