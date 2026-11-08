// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class XServiceTest : TestBase
{
    [Fact]
    public async Task GetArticle_Works()
    {
        var response = await this.client.X.GetArticle(
            "tweetId",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetHomeTimeline_Works()
    {
        var paginatedTweets = await this.client.X.GetHomeTimeline(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task GetNotifications_Works()
    {
        var response = await this.client.X.GetNotifications(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetTrends_Works()
    {
        var response = await this.client.X.GetTrends(new(), TestContext.Current.CancellationToken);
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetTrendsHistory_Works()
    {
        var result = await this.client.X.GetTrendsHistory(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTrendLocations_Works()
    {
        var result = await this.client.X.GetTrendLocations(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetNewsStoryVersions_Works()
    {
        var result = await this.client.X.GetNewsStoryVersions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetHashflags_Works()
    {
        var result = await this.client.X.GetHashflags(new(), TestContext.Current.CancellationToken);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SearchPlaces_Works()
    {
        var result = await this.client.X.SearchPlaces(
            new() { Q = "Q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task AutocompleteSearch_Works()
    {
        var result = await this.client.X.AutocompleteSearch(
            new() { Q = "Q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
