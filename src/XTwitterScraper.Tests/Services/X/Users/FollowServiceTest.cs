using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Users;

public class FollowServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var follow = await this.client.X.Users.Follow.Create(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(follow);
    }

    [Fact]
    public async Task DeleteAll_Works()
    {
        var response = await this.client.X.Users.Follow.DeleteAll(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
