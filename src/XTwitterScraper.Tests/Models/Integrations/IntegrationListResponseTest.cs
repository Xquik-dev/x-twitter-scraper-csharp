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
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    Name = "name",
                    Type = IntegrationType.Telegram,
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "messageTemplate",
                    ScopeAllMonitors = true,
                    SilentPush = true,
                },
            ],
        };

        List<Integration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [EventType.TweetNew],
                IsActive = true,
                Name = "name",
                Type = IntegrationType.Telegram,
                Filters = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MessageTemplate = "messageTemplate",
                ScopeAllMonitors = true,
                SilentPush = true,
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
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    Name = "name",
                    Type = IntegrationType.Telegram,
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "messageTemplate",
                    ScopeAllMonitors = true,
                    SilentPush = true,
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
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    Name = "name",
                    Type = IntegrationType.Telegram,
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "messageTemplate",
                    ScopeAllMonitors = true,
                    SilentPush = true,
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
                ID = "id",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [EventType.TweetNew],
                IsActive = true,
                Name = "name",
                Type = IntegrationType.Telegram,
                Filters = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MessageTemplate = "messageTemplate",
                ScopeAllMonitors = true,
                SilentPush = true,
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
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    Name = "name",
                    Type = IntegrationType.Telegram,
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "messageTemplate",
                    ScopeAllMonitors = true,
                    SilentPush = true,
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
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    Name = "name",
                    Type = IntegrationType.Telegram,
                    Filters = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MessageTemplate = "messageTemplate",
                    ScopeAllMonitors = true,
                    SilentPush = true,
                },
            ],
        };

        IntegrationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
