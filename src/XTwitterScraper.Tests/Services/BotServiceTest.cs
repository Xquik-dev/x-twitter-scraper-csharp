using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class BotServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TrackUsage_Works()
    {
        var response = await this.client.Bot.TrackUsage(
            new()
            {
                InputTokens = 0,
                OutputTokens = 0,
                PlatformUserID = "platformUserId",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
