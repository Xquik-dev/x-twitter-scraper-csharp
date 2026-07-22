using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class CreditServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RedirectTopupCheckout_Works()
    {
        await this.client.Credits.RedirectTopupCheckout(
            new() { SessionID = "session_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveBalance_Works()
    {
        var response = await this.client.Credits.RetrieveBalance(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTopupStatus_Works()
    {
        var response = await this.client.Credits.RetrieveTopupStatus(
            new() { SessionID = "session_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TopupBalance_Works()
    {
        var response = await this.client.Credits.TopupBalance(
            new() { Dollars = 10 },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
