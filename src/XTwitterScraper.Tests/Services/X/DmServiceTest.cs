// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class DmServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveHistory_Works()
    {
        var response = await this.client.X.Dm.RetrieveHistory(
            "userId",
            new() { Account = "account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Send_Works()
    {
        var response = await this.client.X.Dm.Send(
            "userId",
            new()
            {
                Account = "@elonmusk",
                Text = "Example text content",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task DeleteMessage_Works()
    {
        var result = await this.client.X.Dm.DeleteMessage(
            "messageID",
            new() { UserID = "userID", Account = "Account" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
