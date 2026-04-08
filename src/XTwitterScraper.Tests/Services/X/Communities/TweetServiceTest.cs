using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class TweetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.X.Communities.Tweets.List(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListByCommunity_Works()
    {
        var page = await this.client.X.Communities.Tweets.ListByCommunity(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
