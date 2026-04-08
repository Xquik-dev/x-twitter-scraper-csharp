using System.Threading.Tasks;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Services;

public class ExtractionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var extraction = await this.client.Extractions.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        extraction.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var extractions = await this.client.Extractions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        extractions.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task EstimateCost_Works()
    {
        var response = await this.client.Extractions.EstimateCost(
            new() { ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ExportResults_Works()
    {
        await this.client.Extractions.ExportResults(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Extractions.Run(
            new() { ToolType = ExtractionRunParamsToolType.FollowerExplorer },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
