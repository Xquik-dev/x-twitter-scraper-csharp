// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class CommunityNoteServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveContributor_Works()
    {
        var result = await this.client.X.CommunityNotes.RetrieveContributor(
            "alias",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListContributorNotes_Works()
    {
        var result = await this.client.X.CommunityNotes.ListContributorNotes(
            "alias",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ListContributorDeletedNotes_Works()
    {
        var result = await this.client.X.CommunityNotes.ListContributorDeletedNotes(
            "alias",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
