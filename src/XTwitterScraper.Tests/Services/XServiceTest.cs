using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class XServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetArticle_Works()
    {
        var response = await this.client.X.GetArticle(
            "tweetId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetHomeTimeline_Works()
    {
        var response = await this.client.X.GetHomeTimeline(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetNotifications_Works()
    {
        var response = await this.client.X.GetNotifications(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetTrends_Works()
    {
        var response = await this.client.X.GetTrends(new(), TestContext.Current.CancellationToken);
        response.Validate();
    }
}
