using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class ProfileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var profile = await this.client.X.Profile.Update(
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        profile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateAvatar_Works()
    {
        var response = await this.client.X.Profile.UpdateAvatar(
            new()
            {
                Account = "@elonmusk",
                UrlValue = "https://example.com/avatar.png",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateBanner_Works()
    {
        var response = await this.client.X.Profile.UpdateBanner(
            new()
            {
                Account = "@elonmusk",
                UrlValue = "https://example.com/banner.png",
                IdempotencyKey = "Idempotency-Key",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
