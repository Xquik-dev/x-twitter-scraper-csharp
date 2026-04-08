using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Tweets.Retweet;

namespace XTwitterScraper.Services.X.Tweets;

/// <inheritdoc/>
public sealed class RetweetService : IRetweetService
{
    readonly Lazy<IRetweetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRetweetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IRetweetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetweetService(this._client.WithOptions(modifier));
    }

    public RetweetService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RetweetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RetweetCreateResponse> Create(
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RetweetCreateResponse> Create(
        string id,
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RetweetDeleteResponse> Delete(
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RetweetDeleteResponse> Delete(
        string id,
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RetweetServiceWithRawResponse : IRetweetServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRetweetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetweetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RetweetServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetweetCreateResponse>> Create(
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RetweetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retweet = await response
                    .Deserialize<RetweetCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retweet.Validate();
                }
                return retweet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RetweetCreateResponse>> Create(
        string id,
        RetweetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetweetDeleteResponse>> Delete(
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RetweetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retweet = await response
                    .Deserialize<RetweetDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retweet.Validate();
                }
                return retweet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RetweetDeleteResponse>> Delete(
        string id,
        RetweetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
