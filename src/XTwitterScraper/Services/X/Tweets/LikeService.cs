using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Services.X.Tweets;

/// <inheritdoc/>
public sealed class LikeService : ILikeService
{
    readonly Lazy<ILikeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILikeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ILikeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LikeService(this._client.WithOptions(modifier));
    }

    public LikeService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LikeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LikeCreateResponse> Create(
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LikeCreateResponse> Create(
        string tweetID,
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TweetID = tweetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LikeDeleteResponse> Delete(
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LikeDeleteResponse> Delete(
        string tweetID,
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TweetID = tweetID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LikeServiceWithRawResponse : ILikeServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILikeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LikeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LikeServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LikeCreateResponse>> Create(
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TweetID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.TweetID' cannot be null");
        }

        HttpRequest<LikeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var like = await response
                    .Deserialize<LikeCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    like.Validate();
                }
                return like;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LikeCreateResponse>> Create(
        string tweetID,
        LikeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TweetID = tweetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LikeDeleteResponse>> Delete(
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TweetID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.TweetID' cannot be null");
        }

        HttpRequest<LikeDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var like = await response
                    .Deserialize<LikeDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    like.Validate();
                }
                return like;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LikeDeleteResponse>> Delete(
        string tweetID,
        LikeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TweetID = tweetID }, cancellationToken);
    }
}
