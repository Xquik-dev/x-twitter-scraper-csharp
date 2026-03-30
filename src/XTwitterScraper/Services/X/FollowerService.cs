using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Followers;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class FollowerService : IFollowerService
{
    readonly Lazy<IFollowerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFollowerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowerService(this._client.WithOptions(modifier));
    }

    public FollowerService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FollowerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FollowerCheckResponse> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FollowerServiceWithRawResponse : IFollowerServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFollowerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FollowerServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FollowerCheckResponse>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FollowerCheckParams> request = new()
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
                    .Deserialize<FollowerCheckResponse>(token)
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
