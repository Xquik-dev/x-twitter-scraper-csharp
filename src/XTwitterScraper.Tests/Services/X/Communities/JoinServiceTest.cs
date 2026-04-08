using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X.Communities;

public class JoinServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var communityActionResult = await this.client.X.Communities.Join.Create(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        communityActionResult.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeleteAll_Works()
    {
        var communityActionResult = await this.client.X.Communities.Join.DeleteAll(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        communityActionResult.Validate();
    }
}
