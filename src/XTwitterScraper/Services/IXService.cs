// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X;
using Models = XTwitterScraper.Models;
using ModelsX = XTwitterScraper.Models.X;
using X = XTwitterScraper.Services.X;

namespace XTwitterScraper.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions.
/// </summary>
public interface IXService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IXServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    X::IWriteActionService WriteActions { get; }

    X::ITweetService Tweets { get; }

    X::IUserService Users { get; }

    X::IFollowerService Followers { get; }

    X::IDmService Dm { get; }

    X::IMediaService Media { get; }

    X::IProfileService Profile { get; }

    X::ICommunityService Communities { get; }

    X::IAccountService Accounts { get; }

    X::IAccountConnectionChallengeService AccountConnectionChallenges { get; }

    X::IAccountConnectionAttemptService AccountConnectionAttempts { get; }

    X::IBookmarkService Bookmarks { get; }

    X::IListService Lists { get; }

    /// <summary>
    /// Retrieve the full content of an X Article (long-form post) by numeric tweet ID.
    /// Returns article_not_found when the tweet is valid but is not an X Article.
    /// </summary>
    Task<XGetArticleResponse> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetArticle(XGetArticleParams, CancellationToken)"/>
    Task<XGetArticleResponse> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get home timeline
    /// </summary>
    Task<PaginatedTweets> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get notifications
    /// </summary>
    Task<XGetNotificationsResponse> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get trending hashtags and topics from X by region
    /// </summary>
    Task<XGetTrendsResponse> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    X::IJobService Jobs { get; }

    X::ISpaceService Spaces { get; }

    X::ISportService Sports { get; }

    X::IAnalysisService Analysis { get; }

    X::IBroadcastService Broadcasts { get; }

    X::ICommunityNoteService CommunityNotes { get; }

    X::IAccountConnectionLinkService AccountConnectionLinks { get; }

    /// <summary>
    /// Returns the Twitter trends archive of a place, as the lists X showed there over a range of time. Use it for trending on Twitter yesterday, last week or any day since 2026-10-13 02:20 UTC. Xquik stores 1 list per place every 5 minutes and keeps it for 25 months. Pick the place by woeid, country or location name, the range with from &amp; to, and the step with every. from &amp; to take a time or a span back from now, such as 7d, so a schedule can read the last day on every run. Each step returns the first list stored in it, with its own time. Each returned list costs 1 credit, so 24 lists cost 24 credits. A step with no stored list returns none. Empty trend history steps are free. 1 request returns 24 lists, or up to 100 with limit.
    ///
    /// Trends can be read for any past moment since the archive began.
    /// </summary>
    Task<ModelsX::XGetTrendsHistoryResponse> GetTrendsHistory(
        ModelsX::XGetTrendsHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the places X offers trends for. Pass a location's woeid to /x/trends. Each returned location costs 1 credit.
    /// </summary>
    Task<ModelsX::XGetTrendLocationsResponse> GetTrendLocations(
        ModelsX::XGetTrendLocationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns each version X wrote of 1 AI news story. Each version has its time, headline &amp; text, oldest first, so you can see how the story changed. Each request costs 1 credit.
    /// </summary>
    Task<ModelsX::XGetNewsStoryVersionsResponse> GetNewsStoryVersions(
        ModelsX::XGetNewsStoryVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetNewsStoryVersions(ModelsX::XGetNewsStoryVersionsParams, CancellationToken)"/>
    Task<ModelsX::XGetNewsStoryVersionsResponse> GetNewsStoryVersions(
        string id,
        ModelsX::XGetNewsStoryVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns X's hashflags, the custom emoji X shows after some hashtags. Lists the ones running now unless activeOnly is false. Each returned hashflag costs 1 credit.
    /// </summary>
    Task<ModelsX::XGetHashflagsResponse> GetHashflags(
        ModelsX::XGetHashflagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Finds places on X by name. Pass a place's id as place to /x/tweets/search to read posts tagged there. X ranks the places, so their order can differ between requests. Each returned place costs 1 credit.
    ///
    /// Place searches work with names in 6 languages.
    /// </summary>
    Task<ModelsX::XSearchPlacesResponse> SearchPlaces(
        ModelsX::XSearchPlacesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the accounts, topics, hashtags &amp; cashtags X suggests while someone types a search. X may rank them differently per request. Costs 1 credit per suggestion.
    /// </summary>
    Task<Models::SearchSuggestions> AutocompleteSearch(
        ModelsX::XAutocompleteSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IXService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IXServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IXServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    X::IWriteActionServiceWithRawResponse WriteActions { get; }

    X::ITweetServiceWithRawResponse Tweets { get; }

    X::IUserServiceWithRawResponse Users { get; }

    X::IFollowerServiceWithRawResponse Followers { get; }

    X::IDmServiceWithRawResponse Dm { get; }

    X::IMediaServiceWithRawResponse Media { get; }

    X::IProfileServiceWithRawResponse Profile { get; }

    X::ICommunityServiceWithRawResponse Communities { get; }

    X::IAccountServiceWithRawResponse Accounts { get; }

    X::IAccountConnectionChallengeServiceWithRawResponse AccountConnectionChallenges { get; }

    X::IAccountConnectionAttemptServiceWithRawResponse AccountConnectionAttempts { get; }

    X::IBookmarkServiceWithRawResponse Bookmarks { get; }

    X::IListServiceWithRawResponse Lists { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/articles/{tweetId}</c>, but is otherwise the
    /// same as <see cref="IXService.GetArticle(XGetArticleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetArticleResponse>> GetArticle(
        XGetArticleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetArticle(XGetArticleParams, CancellationToken)"/>
    Task<HttpResponse<XGetArticleResponse>> GetArticle(
        string tweetID,
        XGetArticleParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/timeline</c>, but is otherwise the
    /// same as <see cref="IXService.GetHomeTimeline(XGetHomeTimelineParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> GetHomeTimeline(
        XGetHomeTimelineParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/notifications</c>, but is otherwise the
    /// same as <see cref="IXService.GetNotifications(XGetNotificationsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetNotificationsResponse>> GetNotifications(
        XGetNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/trends</c>, but is otherwise the
    /// same as <see cref="IXService.GetTrends(XGetTrendsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<XGetTrendsResponse>> GetTrends(
        XGetTrendsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    X::IJobServiceWithRawResponse Jobs { get; }

    X::ISpaceServiceWithRawResponse Spaces { get; }

    X::ISportServiceWithRawResponse Sports { get; }

    X::IAnalysisServiceWithRawResponse Analysis { get; }

    X::IBroadcastServiceWithRawResponse Broadcasts { get; }

    X::ICommunityNoteServiceWithRawResponse CommunityNotes { get; }

    X::IAccountConnectionLinkServiceWithRawResponse AccountConnectionLinks { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/trends/history</c>, but is otherwise the
    /// same as <see cref="IXService.GetTrendsHistory(ModelsX::XGetTrendsHistoryParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<ModelsX::XGetTrendsHistoryResponse>> GetTrendsHistory(
        ModelsX::XGetTrendsHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/trends/locations</c>, but is otherwise the
    /// same as <see cref="IXService.GetTrendLocations(ModelsX::XGetTrendLocationsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<ModelsX::XGetTrendLocationsResponse>> GetTrendLocations(
        ModelsX::XGetTrendLocationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/news/{id}/versions</c>, but is otherwise the
    /// same as <see cref="IXService.GetNewsStoryVersions(ModelsX::XGetNewsStoryVersionsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<ModelsX::XGetNewsStoryVersionsResponse>> GetNewsStoryVersions(
        ModelsX::XGetNewsStoryVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetNewsStoryVersions(ModelsX::XGetNewsStoryVersionsParams, CancellationToken)"/>
    Task<HttpResponse<ModelsX::XGetNewsStoryVersionsResponse>> GetNewsStoryVersions(
        string id,
        ModelsX::XGetNewsStoryVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/hashflags</c>, but is otherwise the
    /// same as <see cref="IXService.GetHashflags(ModelsX::XGetHashflagsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<ModelsX::XGetHashflagsResponse>> GetHashflags(
        ModelsX::XGetHashflagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/places/search</c>, but is otherwise the
    /// same as <see cref="IXService.SearchPlaces(ModelsX::XSearchPlacesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<ModelsX::XSearchPlacesResponse>> SearchPlaces(
        ModelsX::XSearchPlacesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/search/autocomplete</c>, but is otherwise the
    /// same as <see cref="IXService.AutocompleteSearch(ModelsX::XAutocompleteSearchParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::SearchSuggestions>> AutocompleteSearch(
        ModelsX::XAutocompleteSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
