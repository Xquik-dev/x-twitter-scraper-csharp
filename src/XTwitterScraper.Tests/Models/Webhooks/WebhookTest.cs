using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [WebhookEventType.TweetNew, WebhookEventType.FollowerGained],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, WebhookEventType>> expectedEventTypes =
        [
            WebhookEventType.TweetNew,
            WebhookEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [WebhookEventType.TweetNew, WebhookEventType.FollowerGained],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [WebhookEventType.TweetNew, WebhookEventType.FollowerGained],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, WebhookEventType>> expectedEventTypes =
        [
            WebhookEventType.TweetNew,
            WebhookEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [WebhookEventType.TweetNew, WebhookEventType.FollowerGained],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [WebhookEventType.TweetNew, WebhookEventType.FollowerGained],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        Webhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookEventType.TweetNew)]
    [InlineData(WebhookEventType.TweetReply)]
    [InlineData(WebhookEventType.TweetRetweet)]
    [InlineData(WebhookEventType.TweetQuote)]
    [InlineData(WebhookEventType.FollowerGained)]
    [InlineData(WebhookEventType.FollowerLost)]
    public void Validation_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEventType.TweetNew)]
    [InlineData(WebhookEventType.TweetReply)]
    [InlineData(WebhookEventType.TweetRetweet)]
    [InlineData(WebhookEventType.TweetQuote)]
    [InlineData(WebhookEventType.FollowerGained)]
    [InlineData(WebhookEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
