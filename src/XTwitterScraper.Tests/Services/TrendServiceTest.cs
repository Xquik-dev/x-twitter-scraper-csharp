using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class TrendServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var trends = await this.client.Trends.List(new(), TestContext.Current.CancellationToken);
        Assert.NotNull(trends);
    }
}
