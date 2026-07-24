// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class WriteActionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var writeAction = await this.client.X.WriteActions.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(writeAction);
    }
}
