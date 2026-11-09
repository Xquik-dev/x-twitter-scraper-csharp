// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AnalysisServiceTest : TestBase
{
    [Fact]
    public async Task Sentiment_Works()
    {
        var result = await this.client.X.Analysis.Sentiment(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Brand_Works()
    {
        var result = await this.client.X.Analysis.Brand(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task News_Works()
    {
        var result = await this.client.X.Analysis.News(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task MarketSignals_Works()
    {
        var result = await this.client.X.Analysis.MarketSignals(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ViralScore_Works()
    {
        var result = await this.client.X.Analysis.ViralScore(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Classify_Works()
    {
        var result = await this.client.X.Analysis.Classify(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(result);
    }
}
