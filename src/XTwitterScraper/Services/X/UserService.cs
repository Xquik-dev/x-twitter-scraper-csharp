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
using XTwitterScraper.Models.X.Users;
using XTwitterScraper.Services.X.Users;
using Models = XTwitterScraper.Models;
using Users = XTwitterScraper.Models.X.Users;

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
    public async Task<UserProfile> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserProfile> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserRemoveFollowerResponse> RemoveFollower(
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveFollower(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRemoveFollowerResponse> RemoveFollower(
        string id,
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RemoveFollower(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveBatchResponse> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBatch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveFollowers(
        UserRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedUsers> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveFollowersYouKnow(
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
    public Task<PaginatedUsers> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowersYouKnow(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveFollowing(
        UserRetrieveFollowingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowing(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedUsers> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowing(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveLikes(
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
    public Task<PaginatedTweets> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLikes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveMedia(
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
    public Task<PaginatedTweets> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMedia(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveMentions(
        UserRetrieveMentionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveMentions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedTweets> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMentions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveReplies(
        UserRetrieveRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveReplies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedTweets> RetrieveReplies(
        string id,
        UserRetrieveRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSearch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveTweets(
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
    public Task<PaginatedTweets> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveVerifiedFollowers(
        UserRetrieveVerifiedFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveVerifiedFollowers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedUsers> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveVerifiedFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::BatchUserTweets> RetrieveBatchTweets(
        Users::UserRetrieveBatchTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBatchTweets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Block(
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Block(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Block(
        string id,
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Block(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Unblock(
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unblock(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Unblock(
        string id,
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unblock(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Mute(
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Mute(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Mute(
        string id,
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Mute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::XWriteAction> Unmute(
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unmute(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::XWriteAction> Unmute(
        string id,
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unmute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUsers> RetrieveAffiliates(
        Users::UserRetrieveAffiliatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveAffiliates(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUsers> RetrieveAffiliates(
        string id,
        Users::UserRetrieveAffiliatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAffiliates(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUsers> RetrieveSubscriptions(
        Users::UserRetrieveSubscriptionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSubscriptions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUsers> RetrieveSubscriptions(
        string id,
        Users::UserRetrieveSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSubscriptions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedLists> RetrieveLists(
        Users::UserRetrieveListsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveLists(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedLists> RetrieveLists(
        string id,
        Users::UserRetrieveListsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLists(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedLists> RetrieveListMemberships(
        Users::UserRetrieveListMembershipsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveListMemberships(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedLists> RetrieveListMemberships(
        string id,
        Users::UserRetrieveListMembershipsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveListMemberships(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedTweets2> RetrieveArticles(
        Users::UserRetrieveArticlesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveArticles(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedTweets2> RetrieveArticles(
        string id,
        Users::UserRetrieveArticlesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveArticles(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedTweets2> RetrieveHighlights(
        Users::UserRetrieveHighlightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveHighlights(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedTweets2> RetrieveHighlights(
        string id,
        Users::UserRetrieveHighlightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHighlights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUsers> RetrieveSimilar(
        Users::UserRetrieveSimilarParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveSimilar(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUsers> RetrieveSimilar(
        string id,
        Users::UserRetrieveSimilarParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSimilar(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Users::UserTranslateBioResponse> TranslateBio(
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TranslateBio(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Users::UserTranslateBioResponse> TranslateBio(
        string id,
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TranslateBio(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Users::UserRetrieveFollowerAuditResponse> RetrieveFollowerAudit(
        Users::UserRetrieveFollowerAuditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowerAudit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Users::UserRetrieveFollowerAuditResponse> RetrieveFollowerAudit(
        string id,
        Users::UserRetrieveFollowerAuditParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowerAudit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Users::UserRetrieveInsightsResponse> RetrieveInsights(
        Users::UserRetrieveInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveInsights(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Users::UserRetrieveInsightsResponse> RetrieveInsights(
        string id,
        Users::UserRetrieveInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveInsights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::UserLiveStatus> RetrieveLive(
        Users::UserRetrieveLiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveLive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::UserLiveStatus> RetrieveLive(
        string id,
        Users::UserRetrieveLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::ShadowbanReport> RetrieveShadowban(
        Users::UserRetrieveShadowbanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveShadowban(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::ShadowbanReport> RetrieveShadowban(
        string id,
        Users::UserRetrieveShadowbanParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveShadowban(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUserIDs> RetrieveFollowerIds(
        Users::UserRetrieveFollowerIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowerIds(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUserIDs> RetrieveFollowerIds(
        string id,
        Users::UserRetrieveFollowerIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowerIds(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedUserIDs> RetrieveFollowingIds(
        Users::UserRetrieveFollowingIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowingIds(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedUserIDs> RetrieveFollowingIds(
        string id,
        Users::UserRetrieveFollowingIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowingIds(parameters with { ID = id }, cancellationToken);
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
    public async Task<HttpResponse<UserProfile>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userProfile = await response
                    .Deserialize<UserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userProfile.Validate();
                }
                return userProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserProfile>> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRemoveFollowerResponse>> RemoveFollower(
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRemoveFollowerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<UserRemoveFollowerResponse>(token)
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
    public Task<HttpResponse<UserRemoveFollowerResponse>> RemoveFollower(
        string id,
        UserRemoveFollowerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RemoveFollower(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveBatchResponse>> RetrieveBatch(
        UserRetrieveBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserRetrieveBatchParams> request = new()
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
                    .Deserialize<UserRetrieveBatchResponse>(token)
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
    public async Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
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
    public Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        string id,
        UserRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveFollowersYouKnow(
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
    public Task<HttpResponse<PaginatedUsers>> RetrieveFollowersYouKnow(
        string id,
        UserRetrieveFollowersYouKnowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowersYouKnow(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveFollowing(
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
    public Task<HttpResponse<PaginatedUsers>> RetrieveFollowing(
        string id,
        UserRetrieveFollowingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowing(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveLikes(
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
    public Task<HttpResponse<PaginatedTweets>> RetrieveLikes(
        string id,
        UserRetrieveLikesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLikes(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveMedia(
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
    public Task<HttpResponse<PaginatedTweets>> RetrieveMedia(
        string id,
        UserRetrieveMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMedia(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveMentions(
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
    public Task<HttpResponse<PaginatedTweets>> RetrieveMentions(
        string id,
        UserRetrieveMentionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMentions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveReplies(
        UserRetrieveRepliesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserRetrieveRepliesParams> request = new()
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
    public Task<HttpResponse<PaginatedTweets>> RetrieveReplies(
        string id,
        UserRetrieveRepliesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveReplies(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveSearch(
        UserRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserRetrieveSearchParams> request = new()
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
    public async Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
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
    public Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        string id,
        UserRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveVerifiedFollowers(
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
    public Task<HttpResponse<PaginatedUsers>> RetrieveVerifiedFollowers(
        string id,
        UserRetrieveVerifiedFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveVerifiedFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::BatchUserTweets>> RetrieveBatchTweets(
        Users::UserRetrieveBatchTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Users::UserRetrieveBatchTweetsParams> request = new()
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
                    .Deserialize<Models::BatchUserTweets>(token)
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
    public async Task<HttpResponse<Models::XWriteAction>> Block(
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserBlockParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
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
    public Task<HttpResponse<Models::XWriteAction>> Block(
        string id,
        Users::UserBlockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Block(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::XWriteAction>> Unblock(
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserUnblockParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
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
    public Task<HttpResponse<Models::XWriteAction>> Unblock(
        string id,
        Users::UserUnblockParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unblock(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::XWriteAction>> Mute(
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserMuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
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
    public Task<HttpResponse<Models::XWriteAction>> Mute(
        string id,
        Users::UserMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Mute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::XWriteAction>> Unmute(
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserUnmuteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::XWriteAction>(token)
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
    public Task<HttpResponse<Models::XWriteAction>> Unmute(
        string id,
        Users::UserUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unmute(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUsers>> RetrieveAffiliates(
        Users::UserRetrieveAffiliatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveAffiliatesParams> request = new()
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
    public Task<HttpResponse<Models::PaginatedUsers>> RetrieveAffiliates(
        string id,
        Users::UserRetrieveAffiliatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAffiliates(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUsers>> RetrieveSubscriptions(
        Users::UserRetrieveSubscriptionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveSubscriptionsParams> request = new()
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
    public Task<HttpResponse<Models::PaginatedUsers>> RetrieveSubscriptions(
        string id,
        Users::UserRetrieveSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSubscriptions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedLists>> RetrieveLists(
        Users::UserRetrieveListsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveListsParams> request = new()
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
                    .Deserialize<Models::PaginatedLists>(token)
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
    public Task<HttpResponse<Models::PaginatedLists>> RetrieveLists(
        string id,
        Users::UserRetrieveListsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLists(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedLists>> RetrieveListMemberships(
        Users::UserRetrieveListMembershipsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveListMembershipsParams> request = new()
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
                    .Deserialize<Models::PaginatedLists>(token)
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
    public Task<HttpResponse<Models::PaginatedLists>> RetrieveListMemberships(
        string id,
        Users::UserRetrieveListMembershipsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveListMemberships(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedTweets2>> RetrieveArticles(
        Users::UserRetrieveArticlesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveArticlesParams> request = new()
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
                    .Deserialize<Models::PaginatedTweets2>(token)
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
    public Task<HttpResponse<Models::PaginatedTweets2>> RetrieveArticles(
        string id,
        Users::UserRetrieveArticlesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveArticles(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedTweets2>> RetrieveHighlights(
        Users::UserRetrieveHighlightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveHighlightsParams> request = new()
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
                    .Deserialize<Models::PaginatedTweets2>(token)
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
    public Task<HttpResponse<Models::PaginatedTweets2>> RetrieveHighlights(
        string id,
        Users::UserRetrieveHighlightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHighlights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUsers>> RetrieveSimilar(
        Users::UserRetrieveSimilarParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveSimilarParams> request = new()
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
    public Task<HttpResponse<Models::PaginatedUsers>> RetrieveSimilar(
        string id,
        Users::UserRetrieveSimilarParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSimilar(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Users::UserTranslateBioResponse>> TranslateBio(
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserTranslateBioParams> request = new()
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
                    .Deserialize<Users::UserTranslateBioResponse>(token)
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
    public Task<HttpResponse<Users::UserTranslateBioResponse>> TranslateBio(
        string id,
        Users::UserTranslateBioParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TranslateBio(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Users::UserRetrieveFollowerAuditResponse>> RetrieveFollowerAudit(
        Users::UserRetrieveFollowerAuditParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveFollowerAuditParams> request = new()
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
                    .Deserialize<Users::UserRetrieveFollowerAuditResponse>(token)
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
    public Task<HttpResponse<Users::UserRetrieveFollowerAuditResponse>> RetrieveFollowerAudit(
        string id,
        Users::UserRetrieveFollowerAuditParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowerAudit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Users::UserRetrieveInsightsResponse>> RetrieveInsights(
        Users::UserRetrieveInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveInsightsParams> request = new()
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
                    .Deserialize<Users::UserRetrieveInsightsResponse>(token)
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
    public Task<HttpResponse<Users::UserRetrieveInsightsResponse>> RetrieveInsights(
        string id,
        Users::UserRetrieveInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveInsights(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::UserLiveStatus>> RetrieveLive(
        Users::UserRetrieveLiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveLiveParams> request = new()
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
                    .Deserialize<Models::UserLiveStatus>(token)
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
    public Task<HttpResponse<Models::UserLiveStatus>> RetrieveLive(
        string id,
        Users::UserRetrieveLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::ShadowbanReport>> RetrieveShadowban(
        Users::UserRetrieveShadowbanParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveShadowbanParams> request = new()
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
                    .Deserialize<Models::ShadowbanReport>(token)
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
    public Task<HttpResponse<Models::ShadowbanReport>> RetrieveShadowban(
        string id,
        Users::UserRetrieveShadowbanParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveShadowban(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowerIds(
        Users::UserRetrieveFollowerIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveFollowerIdsParams> request = new()
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
                    .Deserialize<Models::PaginatedUserIDs>(token)
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
    public Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowerIds(
        string id,
        Users::UserRetrieveFollowerIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowerIds(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowingIds(
        Users::UserRetrieveFollowingIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Users::UserRetrieveFollowingIdsParams> request = new()
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
                    .Deserialize<Models::PaginatedUserIDs>(token)
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
    public Task<HttpResponse<Models::PaginatedUserIDs>> RetrieveFollowingIds(
        string id,
        Users::UserRetrieveFollowingIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowingIds(parameters with { ID = id }, cancellationToken);
    }
}
