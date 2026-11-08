// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class SpaceServiceTest : TestBase
{
    [Fact]
    public async Task Search_Works()
    {
        var result = await this.client.X.Spaces.Search(
            new() { Q = "Q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var result = await this.client.X.Spaces.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task RetrieveReplay_Works()
    {
        var result = await this.client.X.Spaces.RetrieveReplay(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
