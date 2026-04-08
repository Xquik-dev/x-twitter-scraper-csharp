using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationListResponse
        {
            Integrations =
            [
                new()
                {
                    ID = "42",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "chatId", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Name = "My Telegram Bot",
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "New event: {{event.type}}",
                    ScopeAllMonitors = true,
                    SilentPush = false,
                },
            ],
        };

        List<Integration> expectedIntegrations =
        [
            new()
            {
                ID = "42",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "chatId", JsonSerializer.SerializeToElement("bar") },
                },
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                IsActive = true,
                Name = "My Telegram Bot",
                Filters = new Dictionary<string, JsonElement>()
                {
                    { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                },
                MessageTemplate = "New event: {{event.type}}",
                ScopeAllMonitors = true,
                SilentPush = false,
            },
        ];

        Assert.Equal(expectedIntegrations.Count, model.Integrations.Count);
        for (int i = 0; i < expectedIntegrations.Count; i++)
        {
            Assert.Equal(expectedIntegrations[i], model.Integrations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationListResponse
        {
            Integrations =
            [
                new()
                {
                    ID = "42",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "chatId", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Name = "My Telegram Bot",
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "New event: {{event.type}}",
                    ScopeAllMonitors = true,
                    SilentPush = false,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationListResponse
        {
            Integrations =
            [
                new()
                {
                    ID = "42",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "chatId", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Name = "My Telegram Bot",
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "New event: {{event.type}}",
                    ScopeAllMonitors = true,
                    SilentPush = false,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Integration> expectedIntegrations =
        [
            new()
            {
                ID = "42",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "chatId", JsonSerializer.SerializeToElement("bar") },
                },
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                IsActive = true,
                Name = "My Telegram Bot",
                Filters = new Dictionary<string, JsonElement>()
                {
                    { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                },
                MessageTemplate = "New event: {{event.type}}",
                ScopeAllMonitors = true,
                SilentPush = false,
            },
        ];

        Assert.Equal(expectedIntegrations.Count, deserialized.Integrations.Count);
        for (int i = 0; i < expectedIntegrations.Count; i++)
        {
            Assert.Equal(expectedIntegrations[i], deserialized.Integrations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntegrationListResponse
        {
            Integrations =
            [
                new()
                {
                    ID = "42",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "chatId", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Name = "My Telegram Bot",
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "New event: {{event.type}}",
                    ScopeAllMonitors = true,
                    SilentPush = false,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationListResponse
        {
            Integrations =
            [
                new()
                {
                    ID = "42",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "chatId", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Name = "My Telegram Bot",
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "minFollowers", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "New event: {{event.type}}",
                    ScopeAllMonitors = true,
                    SilentPush = false,
                },
            ],
        };

        IntegrationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
