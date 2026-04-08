using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Users;

public class FollowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var follow = await this.client.X.Users.Follow.Create(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        follow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteAll_Works()
    {
        var response = await this.client.X.Users.Follow.DeleteAll(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
