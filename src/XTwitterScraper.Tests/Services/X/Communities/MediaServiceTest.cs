// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class MediaServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var result = await this.client.X.Communities.Media.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
