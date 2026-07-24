// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class MediaServiceTest : TestBase
{
    [Fact]
    public async Task Download_Works()
    {
        var response = await this.client.X.Media.Download(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Upload_Works()
    {
        var response = await this.client.X.Media.Upload(
            new()
            {
                Account = "@elonmusk",
                UrlValue = "https://example.com/image.png",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
