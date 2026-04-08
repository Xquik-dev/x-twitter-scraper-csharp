using System.Threading.Tasks;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var account = await this.client.Account.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SetXUsername_Works()
    {
        var response = await this.client.Account.SetXUsername(
            new() { Username = "elonmusk" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateLocale_Works()
    {
        var response = await this.client.Account.UpdateLocale(
            new() { Locale = Locale.En },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
