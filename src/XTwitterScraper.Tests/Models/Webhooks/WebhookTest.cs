using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
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
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            DeliveryStatus = DeliveryStatus.Active,
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            FailureHardCap = 200,
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string expectedID = "42";
        long expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, DeliveryStatus> expectedDeliveryStatus = DeliveryStatus.Active;
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.TweetReply,
        ];
        long expectedFailureHardCap = 200;
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConsecutiveFailures, model.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeliveryStatus, model.DeliveryStatus);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedFailureHardCap, model.FailureHardCap);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            DeliveryStatus = DeliveryStatus.Active,
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            FailureHardCap = 200,
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
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            DeliveryStatus = DeliveryStatus.Active,
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            FailureHardCap = 200,
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
        long expectedConsecutiveFailures = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, DeliveryStatus> expectedDeliveryStatus = DeliveryStatus.Active;
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.TweetReply,
        ];
        long expectedFailureHardCap = 200;
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConsecutiveFailures, deserialized.ConsecutiveFailures);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeliveryStatus, deserialized.DeliveryStatus);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedFailureHardCap, deserialized.FailureHardCap);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhook
        {
            ID = "42",
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            DeliveryStatus = DeliveryStatus.Active,
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            FailureHardCap = 200,
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
            ConsecutiveFailures = 0,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            DeliveryStatus = DeliveryStatus.Active,
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            FailureHardCap = 200,
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        Webhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveryStatusTest : TestBase
{
    [Theory]
    [InlineData(DeliveryStatus.Active)]
    [InlineData(DeliveryStatus.Paused)]
    [InlineData(DeliveryStatus.NeedsAttention)]
    public void Validation_Works(DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeliveryStatus.Active)]
    [InlineData(DeliveryStatus.Paused)]
    [InlineData(DeliveryStatus.NeedsAttention)]
    public void SerializationRoundtrip_Works(DeliveryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeliveryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeliveryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
