// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class ListServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Lists.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveMembers_Works()
    {
        var paginatedUsers = await this.client.X.Lists.RetrieveMembers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveTweets_Works()
    {
        var paginatedTweets = await this.client.X.Lists.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }
}
