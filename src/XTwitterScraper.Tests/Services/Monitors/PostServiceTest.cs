// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.Monitors;

public class PostServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var result = await this.client.Monitors.Posts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Create_Works()
    {
        var result = await this.client.Monitors.Posts.Create(
            new() { Post = "Post" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var result = await this.client.Monitors.Posts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var result = await this.client.Monitors.Posts.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Update_Works()
    {
        var result = await this.client.Monitors.Posts.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveMetrics_Works()
    {
        var result = await this.client.Monitors.Posts.RetrieveMetrics(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
