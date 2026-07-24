using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Tweets;

public class RetweetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var retweet = await this.client.X.Tweets.Retweet.Create(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(retweet);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var retweet = await this.client.X.Tweets.Retweet.Delete(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(retweet);
    }
}
