using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X;
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

        _withRawResponse = new(() => new XServiceWithRawResponse(client.WithRawResponse));
        _tweets = new(() => new X::TweetService(client));
        _users = new(() => new X::UserService(client));
        _followers = new(() => new X::FollowerService(client));
        _dm = new(() => new X::DmService(client));
        _media = new(() => new X::MediaService(client));
        _profile = new(() => new X::ProfileService(client));
        _communities = new(() => new X::CommunityService(client));
        _accounts = new(() => new X::AccountService(client));
        _bookmarks = new(() => new X::BookmarkService(client));
        _lists = new(() => new X::ListService(client));
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
    public async Task<XGetHomeTimelineResponse> GetHomeTimeline(
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
    public Task GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetTrends(parameters, cancellationToken);
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

        _tweets = new(() => new X::TweetServiceWithRawResponse(client));
        _users = new(() => new X::UserServiceWithRawResponse(client));
        _followers = new(() => new X::FollowerServiceWithRawResponse(client));
        _dm = new(() => new X::DmServiceWithRawResponse(client));
        _media = new(() => new X::MediaServiceWithRawResponse(client));
        _profile = new(() => new X::ProfileServiceWithRawResponse(client));
        _communities = new(() => new X::CommunityServiceWithRawResponse(client));
        _accounts = new(() => new X::AccountServiceWithRawResponse(client));
        _bookmarks = new(() => new X::BookmarkServiceWithRawResponse(client));
        _lists = new(() => new X::ListServiceWithRawResponse(client));
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
    public async Task<HttpResponse<XGetHomeTimelineResponse>> GetHomeTimeline(
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
                var deserializedResponse = await response
                    .Deserialize<XGetHomeTimelineResponse>(token)
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
    public Task<HttpResponse> GetTrends(
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
        return this._client.Execute(request, cancellationToken);
    }
}
