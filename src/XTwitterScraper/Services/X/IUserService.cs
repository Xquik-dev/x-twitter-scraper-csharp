using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Users;
using XTwitterScraper.Services.X.Users;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X data lookups (subscription required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFollowService Follow { get; }

    /// <summary>
    /// Look up X user
    /// </summary>
    Task<UserProfile> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<UserProfile> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get multiple users by IDs
    /// </summary>
    Task<PaginatedUsers> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get user followers
    /// </summary>
    Task<PaginatedUsers> RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get followers you know for a user
    /// </summary>
    Task<PaginatedUsers> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get users this user follows
    /// </summary>
    Task<PaginatedUsers> RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get tweets liked by a user
    /// </summary>
    Task<PaginatedTweets> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get media tweets by a user
    /// </summary>
    Task<PaginatedTweets> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get tweets mentioning a user
    /// </summary>
    Task<PaginatedTweets> RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search users by name or username
    /// </summary>
    Task<PaginatedUsers> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get recent tweets by a user
    /// </summary>
    Task<PaginatedTweets> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get verified followers
    /// </summary>
    Task<PaginatedUsers> RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFollowServiceWithRawResponse Follow { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfile>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserProfile>> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/batch</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveBatch(UserRetrieveBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/followers</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/followers-you-know</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/following</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/likes</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/media</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/mentions</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/search</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveSearch(UserRetrieveSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/tweets</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/verified-followers</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
