using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Subscribe;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class SubscribeService : ISubscribeService
{
    readonly Lazy<ISubscribeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscribeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ISubscribeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscribeService(this._client.WithOptions(modifier));
    }

    public SubscribeService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SubscribeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SubscribeCreateResponse> Create(
        SubscribeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SubscribeServiceWithRawResponse : ISubscribeServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscribeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscribeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscribeServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscribeCreateResponse>> Create(
        SubscribeCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscribeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscribe = await response
                    .Deserialize<SubscribeCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscribe.Validate();
                }
                return subscribe;
            }
        );
    }
}
