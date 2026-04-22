using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            UrlValue = "https://example.com/webhook",
        };

        string expectedID = "id";
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        string expectedUrlValue = "https://example.com/webhook";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { ID = "id" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            IsActive = null,
            UrlValue = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/webhooks/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            UrlValue = "https://example.com/webhook",
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
