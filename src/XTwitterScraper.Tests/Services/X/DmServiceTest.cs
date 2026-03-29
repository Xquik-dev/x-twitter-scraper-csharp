using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class DmServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var dm = await this.client.X.Dm.Update(
            "userId",
            new() { Account = "account", Text = "text" },
            TestContext.Current.CancellationToken
        );
        dm.Validate();
    }

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
}
