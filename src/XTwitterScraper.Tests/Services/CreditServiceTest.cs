// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class CreditServiceTest : TestBase
{
    [Fact]
    public async Task RedirectTopupCheckout_Works()
    {
        await this.client.Credits.RedirectTopupCheckout(
            new() { SessionID = "session_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RetrieveBalance_Works()
    {
        var response = await this.client.Credits.RetrieveBalance(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveTopupStatus_Works()
    {
        var response = await this.client.Credits.RetrieveTopupStatus(
            new() { SessionID = "session_id" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task TopupBalance_Works()
    {
        var response = await this.client.Credits.TopupBalance(
            new() { Dollars = 10 },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
