using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class ApiKeyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiKey = await this.client.ApiKeys.Create(new(), TestContext.Current.CancellationToken);
        apiKey.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiKeys = await this.client.ApiKeys.List(new(), TestContext.Current.CancellationToken);
        apiKeys.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Revoke_Works()
    {
        var response = await this.client.ApiKeys.Revoke(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
