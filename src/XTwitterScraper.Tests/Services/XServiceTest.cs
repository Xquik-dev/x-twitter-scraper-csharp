// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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
}
