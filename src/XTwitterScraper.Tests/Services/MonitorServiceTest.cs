// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services;

public class MonitorServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var monitor = await this.client.Monitors.Create(
            new()
            {
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                Username = "elonmusk",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(monitor);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var monitor = await this.client.Monitors.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(monitor);
    }

    [Fact]
    public async Task Update_Works()
    {
        var monitor = await this.client.Monitors.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(monitor);
    }

    [Fact]
    public async Task List_Works()
    {
        var monitors = await this.client.Monitors.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(monitors);
    }

    [Fact]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Monitors.Deactivate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
