// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "webhook-test-id",
            CreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Secret = "test-webhook-secret",
            Url = "https://example.com/webhook",
        };

        string expectedID = "webhook-test-id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z");
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.TweetReply,
        ];
        string expectedSecret = "test-webhook-secret";
        string expectedUrl = "https://example.com/webhook";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "webhook-test-id",
            CreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Secret = "test-webhook-secret",
            Url = "https://example.com/webhook",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "webhook-test-id",
            CreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Secret = "test-webhook-secret",
            Url = "https://example.com/webhook",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "webhook-test-id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z");
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.TweetReply,
        ];
        string expectedSecret = "test-webhook-secret";
        string expectedUrl = "https://example.com/webhook";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "webhook-test-id",
            CreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Secret = "test-webhook-secret",
            Url = "https://example.com/webhook",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "webhook-test-id",
            CreatedAt = DateTimeOffset.Parse("2026-01-01T00:00:00Z"),
            EventTypes = [EventType.TweetNew, EventType.TweetReply],
            Secret = "test-webhook-secret",
            Url = "https://example.com/webhook",
        };

        WebhookCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
