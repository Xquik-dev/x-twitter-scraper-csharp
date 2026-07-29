using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionAttemptServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var accountConnectionAttempt = await this.client.X.AccountConnectionAttempts.Retrieve(
            "xatt_0123456789abcdef0123456789abcdef",
            new(),
            TestContext.Current.CancellationToken
        );
        accountConnectionAttempt.Validate();
    }
}
