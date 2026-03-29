using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot;
using XTwitterScraper.Services.Bot;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class BotService : IBotService
{
    readonly Lazy<IBotServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBotServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IBotService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BotService(this._client.WithOptions(modifier));
    }

    public BotService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BotServiceWithRawResponse(client.WithRawResponse));
        _platformLinks = new(() => new PlatformLinkService(client));
    }

    readonly Lazy<IPlatformLinkService> _platformLinks;
    public IPlatformLinkService PlatformLinks
    {
        get { return _platformLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<BotTrackUsageResponse> TrackUsage(
        BotTrackUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TrackUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BotServiceWithRawResponse : IBotServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBotServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BotServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BotServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;

        _platformLinks = new(() => new PlatformLinkServiceWithRawResponse(client));
    }

    readonly Lazy<IPlatformLinkServiceWithRawResponse> _platformLinks;
    public IPlatformLinkServiceWithRawResponse PlatformLinks
    {
        get { return _platformLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BotTrackUsageResponse>> TrackUsage(
        BotTrackUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BotTrackUsageParams> request = new()
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
                    .Deserialize<BotTrackUsageResponse>(token)
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
