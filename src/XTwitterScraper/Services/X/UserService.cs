using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Users;
using XTwitterScraper.Services.X.Users;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
        _follow = new(() => new FollowService(client));
    }

    readonly Lazy<IFollowService> _follow;
    public IFollowService Follow
    {
        get { return _follow.Value; }
    }

    /// <inheritdoc/>
    public Task RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveBatch(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveFollowers(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveFollowers(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveFollowersYouKnowResponse> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowersYouKnow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRetrieveFollowersYouKnowResponse> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowersYouKnow(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveFollowing(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveFollowing(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveLikesResponse> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveLikes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRetrieveLikesResponse> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLikes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveMediaResponse> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveMedia(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRetrieveMediaResponse> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMedia(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveMentions(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveMentions(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveSearch(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveTweetsResponse> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveTweets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRetrieveTweetsResponse> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveVerifiedFollowers(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveVerifiedFollowers(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;

        _follow = new(() => new FollowServiceWithRawResponse(client));
    }

    readonly Lazy<IFollowServiceWithRawResponse> _follow;
    public IFollowServiceWithRawResponse Follow
    {
        get { return _follow.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserRetrieveBatchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveFollowersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveFollowersYouKnowResponse>> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveFollowersYouKnowParams> request = new()
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
                    .Deserialize<UserRetrieveFollowersYouKnowResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserRetrieveFollowersYouKnowResponse>> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowersYouKnow(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveFollowingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowing(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveLikesResponse>> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveLikesParams> request = new()
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
                    .Deserialize<UserRetrieveLikesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserRetrieveLikesResponse>> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLikes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveMediaResponse>> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveMediaParams> request = new()
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
                    .Deserialize<UserRetrieveMediaResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserRetrieveMediaResponse>> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMedia(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveMentionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMentions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserRetrieveSearchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveTweetsResponse>> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveTweetsParams> request = new()
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
                    .Deserialize<UserRetrieveTweetsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserRetrieveTweetsResponse>> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveVerifiedFollowersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveVerifiedFollowers(parameters with { ID = id }, cancellationToken);
    }
}
