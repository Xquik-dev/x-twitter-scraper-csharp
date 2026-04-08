using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Communities;
using Communities = XTwitterScraper.Services.X.Communities;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class CommunityService : ICommunityService
{
    readonly Lazy<ICommunityServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICommunityServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ICommunityService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CommunityService(this._client.WithOptions(modifier));
    }

    public CommunityService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CommunityServiceWithRawResponse(client.WithRawResponse));
        _join = new(() => new Communities::JoinService(client));
        _tweets = new(() => new Communities::TweetService(client));
    }

    readonly Lazy<Communities::IJoinService> _join;
    public Communities::IJoinService Join
    {
        get { return _join.Value; }
    }

    readonly Lazy<Communities::ITweetService> _tweets;
    public Communities::ITweetService Tweets
    {
        get { return _tweets.Value; }
    }

    /// <inheritdoc/>
    public async Task<CommunityCreateResponse> Create(
        CommunityCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CommunityDeleteResponse> Delete(
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CommunityDeleteResponse> Delete(
        string id,
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommunityRetrieveInfoResponse> RetrieveInfo(
        CommunityRetrieveInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveInfo(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CommunityRetrieveInfoResponse> RetrieveInfo(
        string id,
        CommunityRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveInfo(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommunityRetrieveMembersResponse> RetrieveMembers(
        CommunityRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveMembers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CommunityRetrieveMembersResponse> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommunityRetrieveModeratorsResponse> RetrieveModerators(
        CommunityRetrieveModeratorsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveModerators(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CommunityRetrieveModeratorsResponse> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveModerators(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CommunityRetrieveSearchResponse> RetrieveSearch(
        CommunityRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSearch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CommunityServiceWithRawResponse : ICommunityServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICommunityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CommunityServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CommunityServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;

        _join = new(() => new Communities::JoinServiceWithRawResponse(client));
        _tweets = new(() => new Communities::TweetServiceWithRawResponse(client));
    }

    readonly Lazy<Communities::IJoinServiceWithRawResponse> _join;
    public Communities::IJoinServiceWithRawResponse Join
    {
        get { return _join.Value; }
    }

    readonly Lazy<Communities::ITweetServiceWithRawResponse> _tweets;
    public Communities::ITweetServiceWithRawResponse Tweets
    {
        get { return _tweets.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityCreateResponse>> Create(
        CommunityCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CommunityCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var community = await response
                    .Deserialize<CommunityCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    community.Validate();
                }
                return community;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityDeleteResponse>> Delete(
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CommunityDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var community = await response
                    .Deserialize<CommunityDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    community.Validate();
                }
                return community;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CommunityDeleteResponse>> Delete(
        string id,
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityRetrieveInfoResponse>> RetrieveInfo(
        CommunityRetrieveInfoParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CommunityRetrieveInfoParams> request = new()
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
                    .Deserialize<CommunityRetrieveInfoResponse>(token)
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
    public Task<HttpResponse<CommunityRetrieveInfoResponse>> RetrieveInfo(
        string id,
        CommunityRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveInfo(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityRetrieveMembersResponse>> RetrieveMembers(
        CommunityRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CommunityRetrieveMembersParams> request = new()
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
                    .Deserialize<CommunityRetrieveMembersResponse>(token)
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
    public Task<HttpResponse<CommunityRetrieveMembersResponse>> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityRetrieveModeratorsResponse>> RetrieveModerators(
        CommunityRetrieveModeratorsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CommunityRetrieveModeratorsParams> request = new()
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
                    .Deserialize<CommunityRetrieveModeratorsResponse>(token)
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
    public Task<HttpResponse<CommunityRetrieveModeratorsResponse>> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveModerators(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CommunityRetrieveSearchResponse>> RetrieveSearch(
        CommunityRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CommunityRetrieveSearchParams> request = new()
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
                    .Deserialize<CommunityRetrieveSearchResponse>(token)
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
