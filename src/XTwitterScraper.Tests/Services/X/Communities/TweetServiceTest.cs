using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class TweetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var tweets = await this.client.X.Communities.Tweets.List(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        tweets.Validate();
    }
}
