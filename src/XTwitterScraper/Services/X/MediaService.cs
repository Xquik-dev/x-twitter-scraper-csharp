using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Services.X;

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
    public async Task<MediaCreateResponse> Create(
        MediaCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MediaDownloadResponse> Download(
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Download(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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
    public async Task<HttpResponse<MediaCreateResponse>> Create(
        MediaCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MediaCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var media = await response
                    .Deserialize<MediaCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    media.Validate();
                }
                return media;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MediaDownloadResponse>> Download(
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MediaDownloadParams> request = new()
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
                    .Deserialize<MediaDownloadResponse>(token)
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
