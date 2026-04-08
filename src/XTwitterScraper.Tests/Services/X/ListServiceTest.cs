using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class ListServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowers_Works()
    {
        var response = await this.client.X.Lists.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMembers_Works()
    {
        var response = await this.client.X.Lists.RetrieveMembers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTweets_Works()
    {
        var response = await this.client.X.Lists.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
