using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Tweets;

public class LikeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var like = await this.client.X.Tweets.Like.Create(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(like);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var like = await this.client.X.Tweets.Like.Delete(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(like);
    }
}
