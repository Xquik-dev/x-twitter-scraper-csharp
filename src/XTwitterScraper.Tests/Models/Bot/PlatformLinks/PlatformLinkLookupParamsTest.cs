using System;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkLookupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlatformLinkLookupParams
        {
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        string expectedPlatform = "platform";
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedPlatform, parameters.Platform);
        Assert.Equal(expectedPlatformUserID, parameters.PlatformUserID);
    }

    [Fact]
    public void Url_Works()
    {
        PlatformLinkLookupParams parameters = new()
        {
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/bot/platform-links/lookup?platform=platform&platformUserId=platformUserId"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlatformLinkLookupParams
        {
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        PlatformLinkLookupParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
