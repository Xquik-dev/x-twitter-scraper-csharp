// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Users;
using XTwitterScraper.Services.X.Users;
using Models = XTwitterScraper.Models;
using Users = XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions.
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
    /// Get user profile with follower counts and verification
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
    /// Remove follower
    /// </summary>
    Task<UserRemoveFollowerResponse> RemoveFollower(
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveFollower(UserRemoveFollowerParams, CancellationToken)"/>
    Task<UserRemoveFollowerResponse> RemoveFollower(
        string id,
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Look up multiple users by IDs in one call
    /// </summary>
    Task<UserRetrieveBatchResponse> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List followers of a user
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
    /// List mutual followers between you and a user
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
    /// List accounts a user follows
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
    /// List tweets liked by a user
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
    /// List media tweets posted by a user
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
    /// List tweets mentioning a user
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
    /// Returns the user's timeline with replies included by default.
    /// </summary>
    Task<PaginatedTweets> RetrieveReplies(
        UserRetrieveRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveReplies(UserRetrieveRepliesParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveReplies(
        string id,
        UserRetrieveRepliesParams? parameters = null,
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
    /// List recent tweets posted by a user
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
    /// List verified followers of a user
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

    /// <summary>
    /// Returns the newest posts of users named by user ID, username or profile link, in the order named. Send ids or usernames, not both. Each post costs 1 credit. A user in unavailable_ids or unprocessed_ids costs nothing.
    /// </summary>
    Task<Models::BatchUserTweets> RetrieveBatchTweets(
        Users::UserRetrieveBatchTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Blocks a user through a connected X account. X removes follows both ways, and unblocking doesn't restore them.
    /// </summary>
    Task<Models::XWriteAction> Block(
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Block(Users::UserBlockParams, CancellationToken)"/>
    Task<Models::XWriteAction> Block(
        string id,
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unblocks a user through a connected X account.
    /// </summary>
    Task<Models::XWriteAction> Unblock(
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unblock(Users::UserUnblockParams, CancellationToken)"/>
    Task<Models::XWriteAction> Unblock(
        string id,
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mutes a user through a connected X account. The user's posts leave that account's timelines, and X doesn't tell the user.
    /// </summary>
    Task<Models::XWriteAction> Mute(
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mute(Users::UserMuteParams, CancellationToken)"/>
    Task<Models::XWriteAction> Mute(
        string id,
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unmutes a user through a connected X account.
    /// </summary>
    Task<Models::XWriteAction> Unmute(
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unmute(Users::UserUnmuteParams, CancellationToken)"/>
    Task<Models::XWriteAction> Unmute(
        string id,
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the accounts an organization lists as its affiliates, in X's order. An account without affiliates returns an empty list.
    /// </summary>
    Task<Models::PaginatedUsers> RetrieveAffiliates(
        Users::UserRetrieveAffiliatesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAffiliates(Users::UserRetrieveAffiliatesParams, CancellationToken)"/>
    Task<Models::PaginatedUsers> RetrieveAffiliates(
        string id,
        Users::UserRetrieveAffiliatesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the creators the selected user subscribes to, in X's order. An account that hides its subscriptions returns an empty list.
    /// </summary>
    Task<Models::PaginatedUsers> RetrieveSubscriptions(
        Users::UserRetrieveSubscriptionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSubscriptions(Users::UserRetrieveSubscriptionsParams, CancellationToken)"/>
    Task<Models::PaginatedUsers> RetrieveSubscriptions(
        string id,
        Users::UserRetrieveSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the public X Lists the selected user created, in X's order, as the profile's Lists tab shows them. Each List costs 1 credit. A protected account answers 403.
    /// </summary>
    Task<Models::PaginatedLists> RetrieveLists(
        Users::UserRetrieveListsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLists(Users::UserRetrieveListsParams, CancellationToken)"/>
    Task<Models::PaginatedLists> RetrieveLists(
        string id,
        Users::UserRetrieveListsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the public X Lists that include the selected user, as the profile's List memberships page shows them. Each List costs 1 credit. A protected account answers 403.
    /// </summary>
    Task<Models::PaginatedLists> RetrieveListMemberships(
        Users::UserRetrieveListMembershipsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveListMemberships(Users::UserRetrieveListMembershipsParams, CancellationToken)"/>
    Task<Models::PaginatedLists> RetrieveListMemberships(
        string id,
        Users::UserRetrieveListMembershipsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the posts on the user's Articles tab, newest first. Each post's `article` holds the Article's ID, title, preview, cover &amp; dates. Read the full text with GET /x/articles/{tweetId}.
    /// </summary>
    Task<Models::PaginatedTweets2> RetrieveArticles(
        Users::UserRetrieveArticlesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveArticles(Users::UserRetrieveArticlesParams, CancellationToken)"/>
    Task<Models::PaginatedTweets2> RetrieveArticles(
        string id,
        Users::UserRetrieveArticlesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the posts on the user's Highlights tab, in X's order. An account without highlights returns an empty list.
    /// </summary>
    Task<Models::PaginatedTweets2> RetrieveHighlights(
        Users::UserRetrieveHighlightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveHighlights(Users::UserRetrieveHighlightsParams, CancellationToken)"/>
    Task<Models::PaginatedTweets2> RetrieveHighlights(
        string id,
        Users::UserRetrieveHighlightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the public accounts X lists as similar to the selected user, in X's order. Each account costs 1 credit.
    ///
    /// Similar-account lists come back fuller.
    /// </summary>
    Task<Models::PaginatedUsers> RetrieveSimilar(
        Users::UserRetrieveSimilarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSimilar(Users::UserRetrieveSimilarParams, CancellationToken)"/>
    Task<Models::PaginatedUsers> RetrieveSimilar(
        string id,
        Users::UserRetrieveSimilarParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns X's own translation of 1 profile's bio into the language you pick, with the links, mentions, and tags X places in the translated text. A profile without a bio returns translation null &amp; a message, free of charge.
    ///
    /// Posts &amp; bios can be translated into your language.
    /// </summary>
    Task<Users::UserTranslateBioResponse> TranslateBio(
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TranslateBio(Users::UserTranslateBioParams, CancellationToken)"/>
    Task<Users::UserTranslateBioResponse> TranslateBio(
        string id,
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reads the newest followers of a public account &amp; returns a follower audit. It gives each follower 1 class with its score &amp; signals, then adds coverage, a quality score, signal counts, arrival bands, join cohorts, countries, top followers &amp; the account's engagement. Each follower read costs 1 credit, and the engagement adds 1 credit. Signals come from public profiles, so a real person can match. Older followers may differ from the newest ones.
    /// </summary>
    Task<Users::UserRetrieveFollowerAuditResponse> RetrieveFollowerAudit(
        Users::UserRetrieveFollowerAuditParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowerAudit(Users::UserRetrieveFollowerAuditParams, CancellationToken)"/>
    Task<Users::UserRetrieveFollowerAuditResponse> RetrieveFollowerAudit(
        string id,
        Users::UserRetrieveFollowerAuditParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns engagement insights for 1 profile. They are engagement rate, averages per post and posting rate, from its counts and its most recent posts. It reads 20 posts unless limit names another number. Reposts and the pinned post stay out of the averages. Each report costs 1 credit, whatever it reads.
    /// </summary>
    Task<Users::UserRetrieveInsightsResponse> RetrieveInsights(
        Users::UserRetrieveInsightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveInsights(Users::UserRetrieveInsightsParams, CancellationToken)"/>
    Task<Users::UserRetrieveInsightsResponse> RetrieveInsights(
        string id,
        Users::UserRetrieveInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Says whether 1 user is broadcasting live video on X right now, with their latest broadcast, live or ended. Each check costs 1 credit.
    /// </summary>
    Task<Models::UserLiveStatus> RetrieveLive(
        Users::UserRetrieveLiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLive(Users::UserRetrieveLiveParams, CancellationToken)"/>
    Task<Models::UserLiveStatus> RetrieveLive(
        string id,
        Users::UserRetrieveLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks 1 X account for a search ban, a search suggestion ban, reply deboosting &amp; a reply lock. It also tests timeline visibility &amp; early engagement, reads the sensitive flag &amp; the countries that withhold the account, and says if the account is active, protected or suspended.
    ///
    /// Each check answers pass, fail or unknown, with its reason &amp; what it read. `overall` sums up the checks, and `checkedAt` holds the time of the check. The reply checks and the engagement check answer pass or unknown, since X ranks replies for each viewer and a drop alone proves nothing. A protected account skips the checks that need public posts, and a suspended account gets the account check only. Each profile, post, suggestion &amp; reply in the answer costs 1 credit.
    ///
    /// The timeline, engagement &amp; reply checks read the account's 20 most recent posts unless `limit` names another number.
    ///
    /// Shadowban checks show if X search lists an account, with each post they read.
    /// </summary>
    Task<Models::ShadowbanReport> RetrieveShadowban(
        Users::UserRetrieveShadowbanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveShadowban(Users::UserRetrieveShadowbanParams, CancellationToken)"/>
    Task<Models::ShadowbanReport> RetrieveShadowban(
        string id,
        Users::UserRetrieveShadowbanParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the user IDs of the selected user's followers, newest first, up to 5,000 a page. Use it when you need IDs only. Each ID costs 1 credit.
    /// </summary>
    Task<Models::PaginatedUserIDs> RetrieveFollowerIds(
        Users::UserRetrieveFollowerIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowerIds(Users::UserRetrieveFollowerIdsParams, CancellationToken)"/>
    Task<Models::PaginatedUserIDs> RetrieveFollowerIds(
        string id,
        Users::UserRetrieveFollowerIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the user IDs of the accounts the selected user follows, newest first, up to 5,000 a page. Use it when you need IDs only. Each ID costs 1 credit.
    /// </summary>
    Task<Models::PaginatedUserIDs> RetrieveFollowingIds(
        Users::UserRetrieveFollowingIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowingIds(Users::UserRetrieveFollowingIdsParams, CancellationToken)"/>
    Task<Models::PaginatedUserIDs> RetrieveFollowingIds(
        string id,
        Users::UserRetrieveFollowingIdsParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /x/users/{id}/remove-follower</c>, but is otherwise the
    /// same as <see cref="IUserService.RemoveFollower(UserRemoveFollowerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRemoveFollowerResponse>> RemoveFollower(
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveFollower(UserRemoveFollowerParams, CancellationToken)"/>
    Task<HttpResponse<UserRemoveFollowerResponse>> RemoveFollower(
        string id,
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/batch</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveBatch(UserRetrieveBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveBatchResponse>> RetrieveBatch(
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
    /// Returns a raw HTTP response for <c>get /x/users/{id}/replies</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveReplies(UserRetrieveRepliesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveReplies(
        UserRetrieveRepliesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveReplies(UserRetrieveRepliesParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveReplies(
        string id,
        UserRetrieveRepliesParams? parameters = null,
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/batch/tweets</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveBatchTweets(Users::UserRetrieveBatchTweetsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::BatchUserTweets>> RetrieveBatchTweets(
        Users::UserRetrieveBatchTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/users/{id}/block</c>, but is otherwise the
    /// same as <see cref="IUserService.Block(Users::UserBlockParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Block(
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Block(Users::UserBlockParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Block(
        string id,
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/users/{id}/block</c>, but is otherwise the
    /// same as <see cref="IUserService.Unblock(Users::UserUnblockParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Unblock(
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unblock(Users::UserUnblockParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Unblock(
        string id,
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/users/{id}/mute</c>, but is otherwise the
    /// same as <see cref="IUserService.Mute(Users::UserMuteParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Mute(
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Mute(Users::UserMuteParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Mute(
        string id,
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/users/{id}/mute</c>, but is otherwise the
    /// same as <see cref="IUserService.Unmute(Users::UserUnmuteParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::XWriteAction>> Unmute(
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unmute(Users::UserUnmuteParams, CancellationToken)"/>
    Task<HttpResponse<Models::XWriteAction>> Unmute(
        string id,
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/affiliates</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveAffiliates(Users::UserRetrieveAffiliatesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveAffiliates(
        Users::UserRetrieveAffiliatesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAffiliates(Users::UserRetrieveAffiliatesParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveAffiliates(
        string id,
        Users::UserRetrieveAffiliatesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/subscriptions</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveSubscriptions(Users::UserRetrieveSubscriptionsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveSubscriptions(
        Users::UserRetrieveSubscriptionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSubscriptions(Users::UserRetrieveSubscriptionsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveSubscriptions(
        string id,
        Users::UserRetrieveSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/lists</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveLists(Users::UserRetrieveListsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedLists>> RetrieveLists(
        Users::UserRetrieveListsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLists(Users::UserRetrieveListsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedLists>> RetrieveLists(
        string id,
        Users::UserRetrieveListsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/list-memberships</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveListMemberships(Users::UserRetrieveListMembershipsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedLists>> RetrieveListMemberships(
        Users::UserRetrieveListMembershipsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveListMemberships(Users::UserRetrieveListMembershipsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedLists>> RetrieveListMemberships(
        string id,
        Users::UserRetrieveListMembershipsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/articles</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveArticles(Users::UserRetrieveArticlesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedTweets2>> RetrieveArticles(
        Users::UserRetrieveArticlesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveArticles(Users::UserRetrieveArticlesParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedTweets2>> RetrieveArticles(
        string id,
        Users::UserRetrieveArticlesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/highlights</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveHighlights(Users::UserRetrieveHighlightsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedTweets2>> RetrieveHighlights(
        Users::UserRetrieveHighlightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveHighlights(Users::UserRetrieveHighlightsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedTweets2>> RetrieveHighlights(
        string id,
        Users::UserRetrieveHighlightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/similar</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveSimilar(Users::UserRetrieveSimilarParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveSimilar(
        Users::UserRetrieveSimilarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveSimilar(Users::UserRetrieveSimilarParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUsers>> RetrieveSimilar(
        string id,
        Users::UserRetrieveSimilarParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/translation</c>, but is otherwise the
    /// same as <see cref="IUserService.TranslateBio(Users::UserTranslateBioParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Users::UserTranslateBioResponse>> TranslateBio(
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TranslateBio(Users::UserTranslateBioParams, CancellationToken)"/>
    Task<HttpResponse<Users::UserTranslateBioResponse>> TranslateBio(
        string id,
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/follower-audit</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowerAudit(Users::UserRetrieveFollowerAuditParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Users::UserRetrieveFollowerAuditResponse>> RetrieveFollowerAudit(
        Users::UserRetrieveFollowerAuditParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowerAudit(Users::UserRetrieveFollowerAuditParams, CancellationToken)"/>
    Task<HttpResponse<Users::UserRetrieveFollowerAuditResponse>> RetrieveFollowerAudit(
        string id,
        Users::UserRetrieveFollowerAuditParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/insights</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveInsights(Users::UserRetrieveInsightsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Users::UserRetrieveInsightsResponse>> RetrieveInsights(
        Users::UserRetrieveInsightsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveInsights(Users::UserRetrieveInsightsParams, CancellationToken)"/>
    Task<HttpResponse<Users::UserRetrieveInsightsResponse>> RetrieveInsights(
        string id,
        Users::UserRetrieveInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/live</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveLive(Users::UserRetrieveLiveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::UserLiveStatus>> RetrieveLive(
        Users::UserRetrieveLiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveLive(Users::UserRetrieveLiveParams, CancellationToken)"/>
    Task<HttpResponse<Models::UserLiveStatus>> RetrieveLive(
        string id,
        Users::UserRetrieveLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/shadowban</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveShadowban(Users::UserRetrieveShadowbanParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::ShadowbanReport>> RetrieveShadowban(
        Users::UserRetrieveShadowbanParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveShadowban(Users::UserRetrieveShadowbanParams, CancellationToken)"/>
    Task<HttpResponse<Models::ShadowbanReport>> RetrieveShadowban(
        string id,
        Users::UserRetrieveShadowbanParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/follower-ids</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowerIds(Users::UserRetrieveFollowerIdsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowerIds(
        Users::UserRetrieveFollowerIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowerIds(Users::UserRetrieveFollowerIdsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowerIds(
        string id,
        Users::UserRetrieveFollowerIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/users/{id}/following-ids</c>, but is otherwise the
    /// same as <see cref="IUserService.RetrieveFollowingIds(Users::UserRetrieveFollowingIdsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowingIds(
        Users::UserRetrieveFollowingIdsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowingIds(Users::UserRetrieveFollowingIdsParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowingIds(
        string id,
        Users::UserRetrieveFollowingIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
