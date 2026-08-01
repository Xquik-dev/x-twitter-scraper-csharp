// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionAttemptServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var accountConnectionAttempt = await this.client.X.AccountConnectionAttempts.Retrieve(
            "xatt_0123456789abcdef0123456789abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(accountConnectionAttempt);
    }
}
