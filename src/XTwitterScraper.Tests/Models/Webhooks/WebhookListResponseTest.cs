using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        List<Webhook> expectedWebhooks =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        ];

        Assert.Equal(expectedWebhooks.Count, model.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], model.Webhooks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Webhook> expectedWebhooks =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
            },
        ];

        Assert.Equal(expectedWebhooks.Count, deserialized.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], deserialized.Webhooks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        WebhookListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
