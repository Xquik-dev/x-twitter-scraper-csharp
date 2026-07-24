// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services.Monitors;

public class KeywordServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var keyword = await this.client.Monitors.Keywords.Create(
            new() { EventTypes = [EventType.TweetNew], Query = "xquik OR \"x api\"" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(keyword);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var keyword = await this.client.Monitors.Keywords.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(keyword);
    }

    [Fact]
    public async Task Update_Works()
    {
        var keyword = await this.client.Monitors.Keywords.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(keyword);
    }

    [Fact]
    public async Task List_Works()
    {
        var keywords = await this.client.Monitors.Keywords.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(keywords);
    }

    [Fact]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Monitors.Keywords.Deactivate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
