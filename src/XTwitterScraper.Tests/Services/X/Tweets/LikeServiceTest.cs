using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Tweets;

public class LikeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var like = await this.client.X.Tweets.Like.Create(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        like.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var like = await this.client.X.Tweets.Like.Delete(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        like.Validate();
    }
}
