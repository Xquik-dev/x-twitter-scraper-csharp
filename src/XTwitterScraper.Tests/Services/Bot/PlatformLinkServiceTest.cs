using System.Threading.Tasks;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Services.Bot;

public class PlatformLinkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var platformLink = await this.client.Bot.PlatformLinks.Create(
            new() { Platform = Platform.Telegram, PlatformUserID = "platformUserId" },
            TestContext.Current.CancellationToken
        );
        platformLink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var platformLink = await this.client.Bot.PlatformLinks.Delete(
            new()
            {
                Platform = PlatformLinkDeleteParamsPlatform.Telegram,
                PlatformUserID = "platformUserId",
            },
            TestContext.Current.CancellationToken
        );
        platformLink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Lookup_Works()
    {
        var response = await this.client.Bot.PlatformLinks.Lookup(
            new() { Platform = "platform", PlatformUserID = "platformUserId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
