using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Services.Bot;

/// <inheritdoc/>
public sealed class PlatformLinkService : IPlatformLinkService
{
    readonly Lazy<IPlatformLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlatformLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IPlatformLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlatformLinkService(this._client.WithOptions(modifier));
    }

    public PlatformLinkService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PlatformLinkServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PlatformLinkCreateResponse> Create(
        PlatformLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlatformLinkDeleteResponse> Delete(
        PlatformLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlatformLinkLookupResponse> Lookup(
        PlatformLinkLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Lookup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PlatformLinkServiceWithRawResponse : IPlatformLinkServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlatformLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PlatformLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlatformLinkServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlatformLinkCreateResponse>> Create(
        PlatformLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlatformLinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var platformLink = await response
                    .Deserialize<PlatformLinkCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    platformLink.Validate();
                }
                return platformLink;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlatformLinkDeleteResponse>> Delete(
        PlatformLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlatformLinkDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var platformLink = await response
                    .Deserialize<PlatformLinkDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    platformLink.Validate();
                }
                return platformLink;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlatformLinkLookupResponse>> Lookup(
        PlatformLinkLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlatformLinkLookupParams> request = new()
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
                    .Deserialize<PlatformLinkLookupResponse>(token)
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
