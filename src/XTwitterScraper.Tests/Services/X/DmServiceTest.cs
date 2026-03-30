using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class DmServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveHistory_Works()
    {
        var response = await this.client.X.Dm.RetrieveHistory(
            "userId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Send_Works()
    {
        var response = await this.client.X.Dm.Send(
            "userId",
            new() { Account = "account", Text = "text" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
