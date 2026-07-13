using System.Threading.Tasks;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Services;

public class DrawServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var draw = await this.client.Draws.Retrieve(
            "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345",
            new(),
            TestContext.Current.CancellationToken
        );
        draw.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var draws = await this.client.Draws.List(new(), TestContext.Current.CancellationToken);
        draws.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Export_Works()
    {
        await this.client.Draws.Export(
            "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345",
            new() { Format = Format.Csv },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Run_Works()
    {
        var response = await this.client.Draws.Run(
            new() { TweetUrl = "https://x.com/elonmusk/status/1234567890" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
