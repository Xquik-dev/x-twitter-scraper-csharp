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
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        string expectedUsername = "username";

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
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/monitors"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorCreateParams
        {
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        MonitorCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
