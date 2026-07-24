// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class JoinServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var join = await this.client.X.Communities.Join.Create(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(join);
    }

    [Fact]
    public async Task DeleteAll_Works()
    {
        var response = await this.client.X.Communities.Join.DeleteAll(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
