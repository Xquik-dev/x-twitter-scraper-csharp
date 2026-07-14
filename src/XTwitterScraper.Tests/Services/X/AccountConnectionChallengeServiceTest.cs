using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionChallengeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        var response = await this.client.X.AccountConnectionChallenges.Submit(
            "id",
            new() { EmailCode = "123456" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
