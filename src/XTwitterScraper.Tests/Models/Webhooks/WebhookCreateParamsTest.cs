using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            UrlValue = "https://example.com/webhook",
        };

        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.FollowerGained,
        ];
        string expectedUrlValue = "https://example.com/webhook";

        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new()
        {
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            UrlValue = "https://example.com/webhook",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/webhooks"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            UrlValue = "https://example.com/webhook",
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
