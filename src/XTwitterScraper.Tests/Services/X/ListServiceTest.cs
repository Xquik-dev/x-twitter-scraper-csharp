using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowers_Works()
    {
        await this.client.X.Lists.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMembers_Works()
    {
        await this.client.X.Lists.RetrieveMembers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTweets_Works()
    {
        await this.client.X.Lists.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
