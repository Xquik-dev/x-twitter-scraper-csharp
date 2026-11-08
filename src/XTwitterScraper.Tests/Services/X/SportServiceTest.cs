// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class SportServiceTest : TestBase
{
    [Fact]
    public async Task ListGames_Works()
    {
        var result = await this.client.X.Sports.ListGames(
            "league",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveScoreboard_Works()
    {
        var result = await this.client.X.Sports.RetrieveScoreboard(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveAudience_Works()
    {
        var result = await this.client.X.Sports.RetrieveAudience(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveBoxScore_Works()
    {
        var result = await this.client.X.Sports.RetrieveBoxScore(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrievePlays_Works()
    {
        var result = await this.client.X.Sports.RetrievePlays(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveRoster_Works()
    {
        var result = await this.client.X.Sports.RetrieveRoster(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrievePlayerProps_Works()
    {
        var result = await this.client.X.Sports.RetrievePlayerProps(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListPosts_Works()
    {
        var result = await this.client.X.Sports.ListPosts(
            "id",
            new() { League = "league" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
