using System;
using XTwitterScraper.Models.Bot;

namespace XTwitterScraper.Tests.Models.Bot;

public class BotTrackUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BotTrackUsageParams
        {
            InputTokens = 0,
            OutputTokens = 0,
            PlatformUserID = "platformUserId",
        };

        long expectedInputTokens = 0;
        long expectedOutputTokens = 0;
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedInputTokens, parameters.InputTokens);
        Assert.Equal(expectedOutputTokens, parameters.OutputTokens);
        Assert.Equal(expectedPlatformUserID, parameters.PlatformUserID);
    }

    [Fact]
    public void Url_Works()
    {
        BotTrackUsageParams parameters = new()
        {
            InputTokens = 0,
            OutputTokens = 0,
            PlatformUserID = "platformUserId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/bot/usage"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BotTrackUsageParams
        {
            InputTokens = 0,
            OutputTokens = 0,
            PlatformUserID = "platformUserId",
        };

        BotTrackUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
