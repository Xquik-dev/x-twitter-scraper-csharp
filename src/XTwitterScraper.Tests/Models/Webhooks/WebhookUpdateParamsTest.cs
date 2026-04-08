using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
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
            EventTypes =
            [
                WebhookUpdateParamsEventType.TweetNew,
                WebhookUpdateParamsEventType.FollowerGained,
            ],
            IsActive = true,
            UrlValue = "https://example.com/webhook",
        };

        string expectedID = "id";
        List<ApiEnum<string, WebhookUpdateParamsEventType>> expectedEventTypes =
        [
            WebhookUpdateParamsEventType.TweetNew,
            WebhookUpdateParamsEventType.FollowerGained,
        ];
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

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/webhooks/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "id",
            EventTypes =
            [
                WebhookUpdateParamsEventType.TweetNew,
                WebhookUpdateParamsEventType.FollowerGained,
            ],
            IsActive = true,
            UrlValue = "https://example.com/webhook",
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookUpdateParamsEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookUpdateParamsEventType.TweetNew)]
    [InlineData(WebhookUpdateParamsEventType.TweetReply)]
    [InlineData(WebhookUpdateParamsEventType.TweetRetweet)]
    [InlineData(WebhookUpdateParamsEventType.TweetQuote)]
    [InlineData(WebhookUpdateParamsEventType.FollowerGained)]
    [InlineData(WebhookUpdateParamsEventType.FollowerLost)]
    public void Validation_Works(WebhookUpdateParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateParamsEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookUpdateParamsEventType.TweetNew)]
    [InlineData(WebhookUpdateParamsEventType.TweetReply)]
    [InlineData(WebhookUpdateParamsEventType.TweetRetweet)]
    [InlineData(WebhookUpdateParamsEventType.TweetQuote)]
    [InlineData(WebhookUpdateParamsEventType.FollowerGained)]
    [InlineData(WebhookUpdateParamsEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookUpdateParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateParamsEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
