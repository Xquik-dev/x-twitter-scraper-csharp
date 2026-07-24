using System.Threading.Tasks;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var account = await this.client.Account.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(account);
    }

    [Fact]
    public async Task SetXUsername_Works()
    {
        var response = await this.client.Account.SetXUsername(
            new() { Username = "elonmusk" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task UpdateLocale_Works()
    {
        var response = await this.client.Account.UpdateLocale(
            new() { Locale = Locale.En },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
