// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.Support;

public class AttachmentServiceTest : TestBase
{
    [Fact]
    public async Task Download_Works()
    {
        using var response = await this.client.Support.Attachments.Download(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
