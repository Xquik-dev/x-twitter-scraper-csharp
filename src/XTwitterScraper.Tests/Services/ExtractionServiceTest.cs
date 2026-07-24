// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Services;

public class ExtractionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var extraction = await this.client.Extractions.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(extraction);
    }

    [Fact]
    public async Task List_Works()
    {
        var extractions = await this.client.Extractions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(extractions);
    }

    [Fact]
    public async Task EstimateCost_Works()
    {
        var response = await this.client.Extractions.EstimateCost(
            new() { ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task ExportResults_Works()
    {
        await this.client.Extractions.ExportResults(
            "id",
            new() { Format = Format.Csv },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Run_Works()
    {
        var response = await this.client.Extractions.Run(
            new() { ToolType = ExtractionRunParamsToolType.FollowerExplorer },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
