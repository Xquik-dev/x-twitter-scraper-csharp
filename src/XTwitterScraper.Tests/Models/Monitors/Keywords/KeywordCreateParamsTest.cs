using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Tests.Models.Monitors.Keywords;

public class KeywordCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KeywordCreateParams
        {
            EventTypes = [EventType.TweetNew],
            Query = "xquik OR \"x api\"",
        };

        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        string expectedQuery = "xquik OR \"x api\"";

        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedQuery, parameters.Query);
    }

    [Fact]
    public void Url_Works()
    {
        KeywordCreateParams parameters = new()
        {
            EventTypes = [EventType.TweetNew],
            Query = "xquik OR \"x api\"",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/monitors/keywords"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KeywordCreateParams
        {
            EventTypes = [EventType.TweetNew],
            Query = "xquik OR \"x api\"",
        };

        KeywordCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
