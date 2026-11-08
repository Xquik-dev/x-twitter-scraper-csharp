// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionLinkServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var result = await this.client.X.AccountConnectionLinks.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var result = await this.client.X.AccountConnectionLinks.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Revoke_Works()
    {
        var result = await this.client.X.AccountConnectionLinks.Revoke(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
