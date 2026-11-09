// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class ActivityServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        using var response = await this.client.WithRawResponse.Activity.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var result = await this.client.Activity.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
