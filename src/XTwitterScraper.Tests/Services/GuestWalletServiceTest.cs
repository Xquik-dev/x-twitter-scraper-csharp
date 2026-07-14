using System.Text.Json;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class GuestWalletServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var guestWallet = await this.client.GuestWallets.Create(
            new()
            {
                AmountMinor = 1000,
                Currency = JsonSerializer.SerializeToElement("usd"),
                IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
            },
            TestContext.Current.CancellationToken
        );
        guestWallet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveStatus_Works()
    {
        var response = await this.client.GuestWallets.RetrieveStatus(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Topup_Works()
    {
        var response = await this.client.GuestWallets.Topup(
            new()
            {
                AmountMinor = 1000,
                Currency = JsonSerializer.SerializeToElement("usd"),
                IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
