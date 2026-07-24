// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class BookmarkServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var paginatedTweets = await this.client.X.Bookmarks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveFolders_Works()
    {
        var response = await this.client.X.Bookmarks.RetrieveFolders(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
