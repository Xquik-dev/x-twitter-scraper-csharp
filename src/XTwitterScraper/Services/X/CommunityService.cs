// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Communities;
using Communities = XTwitterScraper.Services.X.Communities;
using Models = XTwitterScraper.Models;
using ModelsCommunities = XTwitterScraper.Models.X.Communities;

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

        _media = new(() => new Communities::MediaService(client));
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
    public async Task<PaginatedUsers> RetrieveMembers(
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
    public Task<PaginatedUsers> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveModerators(
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
    public Task<PaginatedUsers> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveModerators(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveSearch(
        CommunityRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSearch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    readonly Lazy<Communities::IMediaService> _media;
    public Communities::IMediaService Media
    {
        get { return _media.Value; }
    }

    /// <inheritdoc/>
    public async Task<Models::CommunityAnalytics> RetrieveAnalytics(
        ModelsCommunities::CommunityRetrieveAnalyticsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveAnalytics(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::CommunityAnalytics> RetrieveAnalytics(
        string id,
        ModelsCommunities::CommunityRetrieveAnalyticsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAnalytics(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUsers> SearchMembers(
        ModelsCommunities::CommunitySearchMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SearchMembers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUsers> SearchMembers(
        string id,
        ModelsCommunities::CommunitySearchMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SearchMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::CommunityPage> Find(
        ModelsCommunities::CommunityFindParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Find(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::CommunityPage> ListPopular(
        ModelsCommunities::CommunityListPopularParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPopular(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsCommunities::CommunityListTopicsResponse> ListTopics(
        ModelsCommunities::CommunityListTopicsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTopics(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsCommunities::CommunityListSuggestedResponse> ListSuggested(
        ModelsCommunities::CommunityListSuggestedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSuggested(parameters, cancellationToken)
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

        _media = new(() => new Communities::MediaServiceWithRawResponse(client));
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
    public async Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
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
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveModerators(
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
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveModerators(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveSearch(
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
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    readonly Lazy<Communities::IMediaServiceWithRawResponse> _media;
    public Communities::IMediaServiceWithRawResponse Media
    {
        get { return _media.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::CommunityAnalytics>> RetrieveAnalytics(
        ModelsCommunities::CommunityRetrieveAnalyticsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ModelsCommunities::CommunityRetrieveAnalyticsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::CommunityAnalytics>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::CommunityAnalytics>> RetrieveAnalytics(
        string id,
        ModelsCommunities::CommunityRetrieveAnalyticsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAnalytics(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUsers>> SearchMembers(
        ModelsCommunities::CommunitySearchMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ModelsCommunities::CommunitySearchMembersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::PaginatedUsers>> SearchMembers(
        string id,
        ModelsCommunities::CommunitySearchMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SearchMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::CommunityPage>> Find(
        ModelsCommunities::CommunityFindParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ModelsCommunities::CommunityFindParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::CommunityPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::CommunityPage>> ListPopular(
        ModelsCommunities::CommunityListPopularParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsCommunities::CommunityListPopularParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::CommunityPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelsCommunities::CommunityListTopicsResponse>> ListTopics(
        ModelsCommunities::CommunityListTopicsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsCommunities::CommunityListTopicsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<ModelsCommunities::CommunityListTopicsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<ModelsCommunities::CommunityListSuggestedResponse>
    > ListSuggested(
        ModelsCommunities::CommunityListSuggestedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsCommunities::CommunityListSuggestedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<ModelsCommunities::CommunityListSuggestedResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }
}
