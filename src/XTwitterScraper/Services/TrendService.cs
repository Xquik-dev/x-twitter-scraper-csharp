using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Trends;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class TrendService : ITrendService
{
    readonly Lazy<ITrendServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITrendServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ITrendService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TrendService(this._client.WithOptions(modifier));
    }

    public TrendService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TrendServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TrendListResponse> List(
        TrendListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TrendServiceWithRawResponse : ITrendServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITrendServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TrendServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TrendServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrendListResponse>> List(
        TrendListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TrendListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var trends = await response
                    .Deserialize<TrendListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    trends.Validate();
                }
                return trends;
            }
        );
    }
}
