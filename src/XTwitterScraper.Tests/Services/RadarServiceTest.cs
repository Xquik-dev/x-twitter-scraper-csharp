using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class RadarServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTrendingTopics_Works()
    {
        var response = await this.client.Radar.RetrieveTrendingTopics(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
