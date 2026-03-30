using System.Text;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class ProfileServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var profile = await this.client.X.Profile.Update(
            new() { Account = "account" },
            TestContext.Current.CancellationToken
        );
        profile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateAvatar_Works()
    {
        var response = await this.client.X.Profile.UpdateAvatar(
            new() { Account = "account", File = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateBanner_Works()
    {
        var response = await this.client.X.Profile.UpdateBanner(
            new() { Account = "account", File = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
