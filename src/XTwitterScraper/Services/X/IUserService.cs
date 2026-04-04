using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
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
    /// Get multiple users by IDs
    /// </summary>
    Task RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get user followers
    /// </summary>
    Task RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>
    Task RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get followers you know for a user
    /// </summary>
    Task<UserRetrieveFollowersYouKnowResponse> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>
    Task<UserRetrieveFollowersYouKnowResponse> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get users this user follows
    /// </summary>
    Task RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>
    Task RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get tweets liked by a user
    /// </summary>
    Task<UserRetrieveLikesResponse> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>
    Task<UserRetrieveLikesResponse> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get media tweets by a user
    /// </summary>
    Task<UserRetrieveMediaResponse> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>
    Task<UserRetrieveMediaResponse> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get tweets mentioning a user
    /// </summary>
    Task RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>
    Task RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search users by name or username
    /// </summary>
    Task RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get recent tweets by a user
    /// </summary>
    Task<UserRetrieveTweetsResponse> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>
    Task<UserRetrieveTweetsResponse> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get verified followers
    /// </summary>
    Task RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>
    Task RetrieveVerifiedFollowers(
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
    /// Returns a raw HTTP response for <c>get /x/users/batch</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveBatch(UserRetrieveBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/followers</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(UserRetrieveFollowersParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/followers-you-know</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveFollowersYouKnowResponse>> RetrieveFollowersYouKnow(
        UserRetrieveFollowersYouKnowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowersYouKnow(UserRetrieveFollowersYouKnowParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveFollowersYouKnowResponse>> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/following</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowing(UserRetrieveFollowingParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/likes</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveLikesResponse>> RetrieveLikes(
        UserRetrieveLikesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLikes(UserRetrieveLikesParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveLikesResponse>> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/media</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveMediaResponse>> RetrieveMedia(
        UserRetrieveMediaParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMedia(UserRetrieveMediaParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveMediaResponse>> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/mentions</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMentions(UserRetrieveMentionsParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/search</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveSearch(UserRetrieveSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/tweets</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveTweetsResponse>> RetrieveTweets(
        UserRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(UserRetrieveTweetsParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveTweetsResponse>> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/verified-followers</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveVerifiedFollowers(UserRetrieveVerifiedFollowersParams, CancellationToken)"/>
    Task<HttpResponse> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
