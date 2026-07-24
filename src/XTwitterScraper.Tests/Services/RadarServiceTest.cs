using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class RadarServiceTest : TestBase
{
    [Fact]
    public async Task RetrieveTrendingTopics_Works()
    {
        var response = await this.client.Radar.RetrieveTrendingTopics(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
