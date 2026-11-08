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
using XTwitterScraper.Models.X;
using Models = XTwitterScraper.Models;
using ModelsX = XTwitterScraper.Models.X;
using X = XTwitterScraper.Services.X;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class XService : IXService
{
    readonly Lazy<IXServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IXServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IXService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new XService(this._client.WithOptions(modifier));
    }

    public XService(IXTwitterScraperClient client)
    {
        _client = client;

        _accountConnectionLinks = new(() => new X::AccountConnectionLinkService(client));
        _communityNotes = new(() => new X::CommunityNoteService(client));
        _broadcasts = new(() => new X::BroadcastService(client));
        _analysis = new(() => new X::AnalysisService(client));
        _sports = new(() => new X::SportService(client));
        _spaces = new(() => new X::SpaceService(client));
        _jobs = new(() => new X::JobService(client));
        _withRawResponse = new(() => new XServiceWithRawResponse(client.WithRawResponse));
        _writeActions = new(() => new X::WriteActionService(client));
        _tweets = new(() => new X::TweetService(client));
        _users = new(() => new X::UserService(client));
        _followers = new(() => new X::FollowerService(client));
        _dm = new(() => new X::DmService(client));
        _media = new(() => new X::MediaService(client));
        _profile = new(() => new X::ProfileService(client));
        _communities = new(() => new X::CommunityService(client));
        _accounts = new(() => new X::AccountService(client));
        _accountConnectionChallenges = new(() => new X::AccountConnectionChallengeService(client));
        _accountConnectionAttempts = new(() => new X::AccountConnectionAttemptService(client));
        _bookmarks = new(() => new X::BookmarkService(client));
        _lists = new(() => new X::ListService(client));
    }

    readonly Lazy<X::IWriteActionService> _writeActions;
    public X::IWriteActionService WriteActions
    {
        get { return _writeActions.Value; }
    }

    readonly Lazy<X::ITweetService> _tweets;
    public X::ITweetService Tweets
    {
        get { return _tweets.Value; }
    }

    readonly Lazy<X::IUserService> _users;
    public X::IUserService Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<X::IFollowerService> _followers;
    public X::IFollowerService Followers
    {
        get { return _followers.Value; }
    }

    readonly Lazy<X::IDmService> _dm;
    public X::IDmService Dm
    {
        get { return _dm.Value; }
    }

    readonly Lazy<X::IMediaService> _media;
    public X::IMediaService Media
    {
        get { return _media.Value; }
    }

    readonly Lazy<X::IProfileService> _profile;
    public X::IProfileService Profile
    {
        get { return _profile.Value; }
    }

    readonly Lazy<X::ICommunityService> _communities;
    public X::ICommunityService Communities
    {
        get { return _communities.Value; }
    }

    readonly Lazy<X::IAccountService> _accounts;
    public X::IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<X::IAccountConnectionChallengeService> _accountConnectionChallenges;
    public X::IAccountConnectionChallengeService AccountConnectionChallenges
    {
        get { return _accountConnectionChallenges.Value; }
    }

    readonly Lazy<X::IAccountConnectionAttemptService> _accountConnectionAttempts;
    public X::IAccountConnectionAttemptService AccountConnectionAttempts
    {
        get { return _accountConnectionAttempts.Value; }
    }

    readonly Lazy<X::IBookmarkService> _bookmarks;
    public X::IBookmarkService Bookmarks
    {
        get { return _bookmarks.Value; }
    }

    readonly Lazy<X::IListService> _lists;
    public X::IListService Lists
    {
        get { return _lists.Value; }
    }

    /// <inheritdoc/>
    public async Task<XGetArticleResponse> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetArticle(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<XGetArticleResponse> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetArticle(parameters with { TweetID = tweetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetHomeTimeline(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<XGetNotificationsResponse> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetNotifications(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<XGetTrendsResponse> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetTrends(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    readonly Lazy<X::IJobService> _jobs;
    public X::IJobService Jobs
    {
        get { return _jobs.Value; }
    }

    readonly Lazy<X::ISpaceService> _spaces;
    public X::ISpaceService Spaces
    {
        get { return _spaces.Value; }
    }

    readonly Lazy<X::ISportService> _sports;
    public X::ISportService Sports
    {
        get { return _sports.Value; }
    }

    readonly Lazy<X::IAnalysisService> _analysis;
    public X::IAnalysisService Analysis
    {
        get { return _analysis.Value; }
    }

    readonly Lazy<X::IBroadcastService> _broadcasts;
    public X::IBroadcastService Broadcasts
    {
        get { return _broadcasts.Value; }
    }

    readonly Lazy<X::ICommunityNoteService> _communityNotes;
    public X::ICommunityNoteService CommunityNotes
    {
        get { return _communityNotes.Value; }
    }

    readonly Lazy<X::IAccountConnectionLinkService> _accountConnectionLinks;
    public X::IAccountConnectionLinkService AccountConnectionLinks
    {
        get { return _accountConnectionLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<ModelsX::XGetTrendsHistoryResponse> GetTrendsHistory(
        ModelsX::XGetTrendsHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetTrendsHistory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsX::XGetTrendLocationsResponse> GetTrendLocations(
        ModelsX::XGetTrendLocationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetTrendLocations(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsX::XGetNewsStoryVersionsResponse> GetNewsStoryVersions(
        ModelsX::XGetNewsStoryVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetNewsStoryVersions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ModelsX::XGetNewsStoryVersionsResponse> GetNewsStoryVersions(
        string id,
        ModelsX::XGetNewsStoryVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetNewsStoryVersions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ModelsX::XGetHashflagsResponse> GetHashflags(
        ModelsX::XGetHashflagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetHashflags(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsX::XSearchPlacesResponse> SearchPlaces(
        ModelsX::XSearchPlacesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SearchPlaces(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::SearchSuggestions> AutocompleteSearch(
        ModelsX::XAutocompleteSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AutocompleteSearch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class XServiceWithRawResponse : IXServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IXServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new XServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public XServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;

        _accountConnectionLinks = new(() =>
            new X::AccountConnectionLinkServiceWithRawResponse(client)
        );
        _communityNotes = new(() => new X::CommunityNoteServiceWithRawResponse(client));
        _broadcasts = new(() => new X::BroadcastServiceWithRawResponse(client));
        _analysis = new(() => new X::AnalysisServiceWithRawResponse(client));
        _sports = new(() => new X::SportServiceWithRawResponse(client));
        _spaces = new(() => new X::SpaceServiceWithRawResponse(client));
        _jobs = new(() => new X::JobServiceWithRawResponse(client));
        _writeActions = new(() => new X::WriteActionServiceWithRawResponse(client));
        _tweets = new(() => new X::TweetServiceWithRawResponse(client));
        _users = new(() => new X::UserServiceWithRawResponse(client));
        _followers = new(() => new X::FollowerServiceWithRawResponse(client));
        _dm = new(() => new X::DmServiceWithRawResponse(client));
        _media = new(() => new X::MediaServiceWithRawResponse(client));
        _profile = new(() => new X::ProfileServiceWithRawResponse(client));
        _communities = new(() => new X::CommunityServiceWithRawResponse(client));
        _accounts = new(() => new X::AccountServiceWithRawResponse(client));
        _accountConnectionChallenges = new(() =>
            new X::AccountConnectionChallengeServiceWithRawResponse(client)
        );
        _accountConnectionAttempts = new(() =>
            new X::AccountConnectionAttemptServiceWithRawResponse(client)
        );
        _bookmarks = new(() => new X::BookmarkServiceWithRawResponse(client));
        _lists = new(() => new X::ListServiceWithRawResponse(client));
    }

    readonly Lazy<X::IWriteActionServiceWithRawResponse> _writeActions;
    public X::IWriteActionServiceWithRawResponse WriteActions
    {
        get { return _writeActions.Value; }
    }

    readonly Lazy<X::ITweetServiceWithRawResponse> _tweets;
    public X::ITweetServiceWithRawResponse Tweets
    {
        get { return _tweets.Value; }
    }

    readonly Lazy<X::IUserServiceWithRawResponse> _users;
    public X::IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<X::IFollowerServiceWithRawResponse> _followers;
    public X::IFollowerServiceWithRawResponse Followers
    {
        get { return _followers.Value; }
    }

    readonly Lazy<X::IDmServiceWithRawResponse> _dm;
    public X::IDmServiceWithRawResponse Dm
    {
        get { return _dm.Value; }
    }

    readonly Lazy<X::IMediaServiceWithRawResponse> _media;
    public X::IMediaServiceWithRawResponse Media
    {
        get { return _media.Value; }
    }

    readonly Lazy<X::IProfileServiceWithRawResponse> _profile;
    public X::IProfileServiceWithRawResponse Profile
    {
        get { return _profile.Value; }
    }

    readonly Lazy<X::ICommunityServiceWithRawResponse> _communities;
    public X::ICommunityServiceWithRawResponse Communities
    {
        get { return _communities.Value; }
    }

    readonly Lazy<X::IAccountServiceWithRawResponse> _accounts;
    public X::IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<X::IAccountConnectionChallengeServiceWithRawResponse> _accountConnectionChallenges;
    public X::IAccountConnectionChallengeServiceWithRawResponse AccountConnectionChallenges
    {
        get { return _accountConnectionChallenges.Value; }
    }

    readonly Lazy<X::IAccountConnectionAttemptServiceWithRawResponse> _accountConnectionAttempts;
    public X::IAccountConnectionAttemptServiceWithRawResponse AccountConnectionAttempts
    {
        get { return _accountConnectionAttempts.Value; }
    }

    readonly Lazy<X::IBookmarkServiceWithRawResponse> _bookmarks;
    public X::IBookmarkServiceWithRawResponse Bookmarks
    {
        get { return _bookmarks.Value; }
    }

    readonly Lazy<X::IListServiceWithRawResponse> _lists;
    public X::IListServiceWithRawResponse Lists
    {
        get { return _lists.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<XGetArticleResponse>> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TweetID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.TweetID' cannot be null");
        }

        HttpRequest<XGetArticleParams> request = new()
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
                    .Deserialize<XGetArticleResponse>(token)
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
    public Task<HttpResponse<XGetArticleResponse>> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetArticle(parameters with { TweetID = tweetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<XGetHomeTimelineParams> request = new()
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

    /// <inheritdoc/>
    public async Task<HttpResponse<XGetNotificationsResponse>> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<XGetNotificationsParams> request = new()
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
                    .Deserialize<XGetNotificationsResponse>(token)
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
    public async Task<HttpResponse<XGetTrendsResponse>> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<XGetTrendsParams> request = new()
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
                    .Deserialize<XGetTrendsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    readonly Lazy<X::IJobServiceWithRawResponse> _jobs;
    public X::IJobServiceWithRawResponse Jobs
    {
        get { return _jobs.Value; }
    }

    readonly Lazy<X::ISpaceServiceWithRawResponse> _spaces;
    public X::ISpaceServiceWithRawResponse Spaces
    {
        get { return _spaces.Value; }
    }

    readonly Lazy<X::ISportServiceWithRawResponse> _sports;
    public X::ISportServiceWithRawResponse Sports
    {
        get { return _sports.Value; }
    }

    readonly Lazy<X::IAnalysisServiceWithRawResponse> _analysis;
    public X::IAnalysisServiceWithRawResponse Analysis
    {
        get { return _analysis.Value; }
    }

    readonly Lazy<X::IBroadcastServiceWithRawResponse> _broadcasts;
    public X::IBroadcastServiceWithRawResponse Broadcasts
    {
        get { return _broadcasts.Value; }
    }

    readonly Lazy<X::ICommunityNoteServiceWithRawResponse> _communityNotes;
    public X::ICommunityNoteServiceWithRawResponse CommunityNotes
    {
        get { return _communityNotes.Value; }
    }

    readonly Lazy<X::IAccountConnectionLinkServiceWithRawResponse> _accountConnectionLinks;
    public X::IAccountConnectionLinkServiceWithRawResponse AccountConnectionLinks
    {
        get { return _accountConnectionLinks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelsX::XGetTrendsHistoryResponse>> GetTrendsHistory(
        ModelsX::XGetTrendsHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsX::XGetTrendsHistoryParams> request = new()
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
                    .Deserialize<ModelsX::XGetTrendsHistoryResponse>(token)
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
    public async Task<HttpResponse<ModelsX::XGetTrendLocationsResponse>> GetTrendLocations(
        ModelsX::XGetTrendLocationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsX::XGetTrendLocationsParams> request = new()
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
                    .Deserialize<ModelsX::XGetTrendLocationsResponse>(token)
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
    public async Task<HttpResponse<ModelsX::XGetNewsStoryVersionsResponse>> GetNewsStoryVersions(
        ModelsX::XGetNewsStoryVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ModelsX::XGetNewsStoryVersionsParams> request = new()
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
                    .Deserialize<ModelsX::XGetNewsStoryVersionsResponse>(token)
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
    public Task<HttpResponse<ModelsX::XGetNewsStoryVersionsResponse>> GetNewsStoryVersions(
        string id,
        ModelsX::XGetNewsStoryVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetNewsStoryVersions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelsX::XGetHashflagsResponse>> GetHashflags(
        ModelsX::XGetHashflagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelsX::XGetHashflagsParams> request = new()
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
                    .Deserialize<ModelsX::XGetHashflagsResponse>(token)
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
    public async Task<HttpResponse<ModelsX::XSearchPlacesResponse>> SearchPlaces(
        ModelsX::XSearchPlacesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ModelsX::XSearchPlacesParams> request = new()
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
                    .Deserialize<ModelsX::XSearchPlacesResponse>(token)
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
    public async Task<HttpResponse<Models::SearchSuggestions>> AutocompleteSearch(
        ModelsX::XAutocompleteSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ModelsX::XAutocompleteSearchParams> request = new()
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
                    .Deserialize<Models::SearchSuggestions>(token)
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
