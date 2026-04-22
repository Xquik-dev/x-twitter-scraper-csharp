using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorCreateParams
        {
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Username = "elonmusk",
        };

        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.TweetReply,
        ];
        string expectedUsername = "elonmusk";

        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        MonitorCreateParams parameters = new()
        {
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Username = "elonmusk",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/monitors"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorCreateParams
        {
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Username = "elonmusk",
        };

        MonitorCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
