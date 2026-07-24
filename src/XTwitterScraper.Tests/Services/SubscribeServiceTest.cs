// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class SubscribeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var subscribe = await this.client.Subscribe.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(subscribe);
    }
}
