// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var userProfile = await this.client.X.Users.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(userProfile);
    }

    [Fact]
    public async Task RemoveFollower_Works()
    {
        var response = await this.client.X.Users.RemoveFollower(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveBatch_Works()
    {
        var response = await this.client.X.Users.RetrieveBatch(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveFollowersYouKnow_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowersYouKnow(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveFollowing_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowing(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveLikes_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveLikes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveMedia_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMedia(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveMentions_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMentions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveReplies_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveReplies(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveSearch_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveSearch(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveTweets_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveVerifiedFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveVerifiedFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveBatchTweets_Works()
    {
        var result = await this.client.X.Users.RetrieveBatchTweets(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Block_Works()
    {
        var result = await this.client.X.Users.Block(
            "id",
            new() { Account = "Account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Unblock_Works()
    {
        var result = await this.client.X.Users.Unblock(
            "id",
            new() { Account = "Account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Mute_Works()
    {
        var result = await this.client.X.Users.Mute(
            "id",
            new() { Account = "Account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Unmute_Works()
    {
        var result = await this.client.X.Users.Unmute(
            "id",
            new() { Account = "Account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveAffiliates_Works()
    {
        var result = await this.client.X.Users.RetrieveAffiliates(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveSubscriptions_Works()
    {
        var result = await this.client.X.Users.RetrieveSubscriptions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveLists_Works()
    {
        var result = await this.client.X.Users.RetrieveLists(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveListMemberships_Works()
    {
        var result = await this.client.X.Users.RetrieveListMemberships(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveArticles_Works()
    {
        var result = await this.client.X.Users.RetrieveArticles(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveHighlights_Works()
    {
        var result = await this.client.X.Users.RetrieveHighlights(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveSimilar_Works()
    {
        var result = await this.client.X.Users.RetrieveSimilar(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task TranslateBio_Works()
    {
        var result = await this.client.X.Users.TranslateBio(
            "id",
            new() { Language = "Language" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveFollowerAudit_Works()
    {
        var result = await this.client.X.Users.RetrieveFollowerAudit(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveInsights_Works()
    {
        var result = await this.client.X.Users.RetrieveInsights(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveLive_Works()
    {
        var result = await this.client.X.Users.RetrieveLive(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveShadowban_Works()
    {
        var result = await this.client.X.Users.RetrieveShadowban(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveFollowerIds_Works()
    {
        var result = await this.client.X.Users.RetrieveFollowerIds(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveFollowingIds_Works()
    {
        var result = await this.client.X.Users.RetrieveFollowingIds(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
