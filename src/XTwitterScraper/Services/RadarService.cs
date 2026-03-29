using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class RadarService : IRadarService
{
    readonly Lazy<IRadarServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRadarServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IRadarService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RadarService(this._client.WithOptions(modifier));
    }

    public RadarService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RadarServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RadarRetrieveTrendingTopicsResponse> RetrieveTrendingTopics(
        RadarRetrieveTrendingTopicsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveTrendingTopics(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RadarServiceWithRawResponse : IRadarServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRadarServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RadarServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RadarServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RadarRetrieveTrendingTopicsResponse>> RetrieveTrendingTopics(
        RadarRetrieveTrendingTopicsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RadarRetrieveTrendingTopicsParams> request = new()
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
                    .Deserialize<RadarRetrieveTrendingTopicsResponse>(token)
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
