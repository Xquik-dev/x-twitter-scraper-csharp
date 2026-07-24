// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class TweetServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var paginatedTweets = await this.client.X.Communities.Tweets.List(
            new() { CommunityID = "321669910225", Q = "q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task ListByCommunity_Works()
    {
        var paginatedTweets = await this.client.X.Communities.Tweets.ListByCommunity(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }
}
