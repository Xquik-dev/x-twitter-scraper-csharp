using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Tweets;

public class RetweetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var retweet = await this.client.X.Tweets.Retweet.Create(
            "tweetId",
            new() { Account = "account" },
            TestContext.Current.CancellationToken
        );
        retweet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var retweet = await this.client.X.Tweets.Retweet.Delete(
            "tweetId",
            new() { Account = "account" },
            TestContext.Current.CancellationToken
        );
        retweet.Validate();
    }
}
