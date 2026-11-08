// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class CommunityServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var community = await this.client.X.Communities.Create(
            new()
            {
                Account = "@elonmusk",
                Name = "Example Name",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(community);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var community = await this.client.X.Communities.Delete(
            "id",
            new()
            {
                Account = "@elonmusk",
                CommunityName = "Tesla Fans",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(community);
    }

    [Fact]
    public async Task RetrieveInfo_Works()
    {
        var response = await this.client.X.Communities.RetrieveInfo(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveMembers_Works()
    {
        var paginatedUsers = await this.client.X.Communities.RetrieveMembers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveModerators_Works()
    {
        var paginatedUsers = await this.client.X.Communities.RetrieveModerators(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveSearch_Works()
    {
        var paginatedTweets = await this.client.X.Communities.RetrieveSearch(
            new() { CommunityID = "321669910225", Q = "q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveAnalytics_Works()
    {
        var result = await this.client.X.Communities.RetrieveAnalytics(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SearchMembers_Works()
    {
        var result = await this.client.X.Communities.SearchMembers(
            "id",
            new() { Q = "Q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Find_Works()
    {
        var result = await this.client.X.Communities.Find(
            new() { Q = "Q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListPopular_Works()
    {
        var result = await this.client.X.Communities.ListPopular(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListTopics_Works()
    {
        var result = await this.client.X.Communities.ListTopics(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListSuggested_Works()
    {
        var result = await this.client.X.Communities.ListSuggested(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
