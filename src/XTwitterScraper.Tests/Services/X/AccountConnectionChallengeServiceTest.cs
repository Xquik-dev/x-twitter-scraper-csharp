// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionChallengeServiceTest : TestBase
{
    [Fact]
    public async Task Submit_Works()
    {
        var response = await this.client.X.AccountConnectionChallenges.Submit(
            "id",
            new() { EmailCode = "<EMAIL_VERIFICATION_CODE>" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
