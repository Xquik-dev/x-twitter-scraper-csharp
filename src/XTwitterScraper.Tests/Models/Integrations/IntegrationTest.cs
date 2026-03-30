using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Integration
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
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        string expectedName = "name";
        ApiEnum<string, IntegrationType> expectedType = IntegrationType.Telegram;
        Dictionary<string, JsonElement> expectedFilters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMessageTemplate = "messageTemplate";
        bool expectedScopeAllMonitors = true;
        bool expectedSilentPush = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfig.Count, model.Config.Count);
        foreach (var item in expectedConfig)
        {
            Assert.True(model.Config.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Config[item.Key]));
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        foreach (var item in expectedFilters)
        {
            Assert.True(model.Filters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Filters[item.Key]));
        }
        Assert.Equal(expectedMessageTemplate, model.MessageTemplate);
        Assert.Equal(expectedScopeAllMonitors, model.ScopeAllMonitors);
        Assert.Equal(expectedSilentPush, model.SilentPush);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Integration
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Integration
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        string expectedName = "name";
        ApiEnum<string, IntegrationType> expectedType = IntegrationType.Telegram;
        Dictionary<string, JsonElement> expectedFilters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMessageTemplate = "messageTemplate";
        bool expectedScopeAllMonitors = true;
        bool expectedSilentPush = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfig.Count, deserialized.Config.Count);
        foreach (var item in expectedConfig)
        {
            Assert.True(deserialized.Config.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Config[item.Key]));
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        foreach (var item in expectedFilters)
        {
            Assert.True(deserialized.Filters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Filters[item.Key]));
        }
        Assert.Equal(expectedMessageTemplate, deserialized.MessageTemplate);
        Assert.Equal(expectedScopeAllMonitors, deserialized.ScopeAllMonitors);
        Assert.Equal(expectedSilentPush, deserialized.SilentPush);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Integration
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Integration
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
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.MessageTemplate);
        Assert.False(model.RawData.ContainsKey("messageTemplate"));
        Assert.Null(model.ScopeAllMonitors);
        Assert.False(model.RawData.ContainsKey("scopeAllMonitors"));
        Assert.Null(model.SilentPush);
        Assert.False(model.RawData.ContainsKey("silentPush"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Integration
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Integration
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

            // Null should be interpreted as omitted for these properties
            Filters = null,
            MessageTemplate = null,
            ScopeAllMonitors = null,
            SilentPush = null,
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.MessageTemplate);
        Assert.False(model.RawData.ContainsKey("messageTemplate"));
        Assert.Null(model.ScopeAllMonitors);
        Assert.False(model.RawData.ContainsKey("scopeAllMonitors"));
        Assert.Null(model.SilentPush);
        Assert.False(model.RawData.ContainsKey("silentPush"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Integration
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

            // Null should be interpreted as omitted for these properties
            Filters = null,
            MessageTemplate = null,
            ScopeAllMonitors = null,
            SilentPush = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Integration
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
        };

        Integration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationTypeTest : TestBase
{
    [Theory]
    [InlineData(IntegrationType.Telegram)]
    public void Validation_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationType.Telegram)]
    public void SerializationRoundtrip_Works(IntegrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntegrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
