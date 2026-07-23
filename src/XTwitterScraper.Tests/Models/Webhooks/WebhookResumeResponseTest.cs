using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookResumeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookResumeResponse
        {
            StatusCode = 200,
            Success = true,
            Webhook = new()
            {
                ID = "42",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                DeliveryStatus = DeliveryStatus.Active,
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                FailureHardCap = 200,
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        };

        long expectedStatusCode = 200;
        bool expectedSuccess = true;
        Webhook expectedWebhook = new()
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

        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedWebhook, model.Webhook);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookResumeResponse
        {
            StatusCode = 200,
            Success = true,
            Webhook = new()
            {
                ID = "42",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                DeliveryStatus = DeliveryStatus.Active,
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                FailureHardCap = 200,
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResumeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookResumeResponse
        {
            StatusCode = 200,
            Success = true,
            Webhook = new()
            {
                ID = "42",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                DeliveryStatus = DeliveryStatus.Active,
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                FailureHardCap = 200,
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookResumeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedStatusCode = 200;
        bool expectedSuccess = true;
        Webhook expectedWebhook = new()
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

        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedWebhook, deserialized.Webhook);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookResumeResponse
        {
            StatusCode = 200,
            Success = true,
            Webhook = new()
            {
                ID = "42",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                DeliveryStatus = DeliveryStatus.Active,
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                FailureHardCap = 200,
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookResumeResponse
        {
            StatusCode = 200,
            Success = true,
            Webhook = new()
            {
                ID = "42",
                ConsecutiveFailures = 0,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                DeliveryStatus = DeliveryStatus.Active,
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                FailureHardCap = 200,
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        };

        WebhookResumeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
