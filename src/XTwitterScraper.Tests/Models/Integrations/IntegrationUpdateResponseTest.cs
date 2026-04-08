using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
            Filters = new Dictionary<string, JsonElement>()
            {
                { "minFollowers", JsonSerializer.SerializeToElement("bar") },
            },
            MessageTemplate = "New event: {{event.type}}",
            ScopeAllMonitors = true,
            SilentPush = false,
        };

        string expectedID = "42";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "chatId", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, IntegrationUpdateResponseEventType>> expectedEventTypes =
        [
            IntegrationUpdateResponseEventType.TweetNew,
            IntegrationUpdateResponseEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedName = "My Telegram Bot";
        ApiEnum<string, IntegrationUpdateResponseType> expectedType =
            IntegrationUpdateResponseType.Telegram;
        Dictionary<string, JsonElement> expectedFilters = new()
        {
            { "minFollowers", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMessageTemplate = "New event: {{event.type}}";
        bool expectedScopeAllMonitors = true;
        bool expectedSilentPush = false;

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
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
            Filters = new Dictionary<string, JsonElement>()
            {
                { "minFollowers", JsonSerializer.SerializeToElement("bar") },
            },
            MessageTemplate = "New event: {{event.type}}",
            ScopeAllMonitors = true,
            SilentPush = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
            Filters = new Dictionary<string, JsonElement>()
            {
                { "minFollowers", JsonSerializer.SerializeToElement("bar") },
            },
            MessageTemplate = "New event: {{event.type}}",
            ScopeAllMonitors = true,
            SilentPush = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "chatId", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, IntegrationUpdateResponseEventType>> expectedEventTypes =
        [
            IntegrationUpdateResponseEventType.TweetNew,
            IntegrationUpdateResponseEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedName = "My Telegram Bot";
        ApiEnum<string, IntegrationUpdateResponseType> expectedType =
            IntegrationUpdateResponseType.Telegram;
        Dictionary<string, JsonElement> expectedFilters = new()
        {
            { "minFollowers", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMessageTemplate = "New event: {{event.type}}";
        bool expectedScopeAllMonitors = true;
        bool expectedSilentPush = false;

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
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
            Filters = new Dictionary<string, JsonElement>()
            {
                { "minFollowers", JsonSerializer.SerializeToElement("bar") },
            },
            MessageTemplate = "New event: {{event.type}}",
            ScopeAllMonitors = true,
            SilentPush = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
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
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,

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
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,

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
        var model = new IntegrationUpdateResponse
        {
            ID = "42",
            Config = new Dictionary<string, JsonElement>()
            {
                { "chatId", JsonSerializer.SerializeToElement("bar") },
            },
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                IntegrationUpdateResponseEventType.TweetNew,
                IntegrationUpdateResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Name = "My Telegram Bot",
            Type = IntegrationUpdateResponseType.Telegram,
            Filters = new Dictionary<string, JsonElement>()
            {
                { "minFollowers", JsonSerializer.SerializeToElement("bar") },
            },
            MessageTemplate = "New event: {{event.type}}",
            ScopeAllMonitors = true,
            SilentPush = false,
        };

        IntegrationUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUpdateResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(IntegrationUpdateResponseEventType.TweetNew)]
    [InlineData(IntegrationUpdateResponseEventType.TweetReply)]
    [InlineData(IntegrationUpdateResponseEventType.TweetRetweet)]
    [InlineData(IntegrationUpdateResponseEventType.TweetQuote)]
    [InlineData(IntegrationUpdateResponseEventType.FollowerGained)]
    [InlineData(IntegrationUpdateResponseEventType.FollowerLost)]
    public void Validation_Works(IntegrationUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationUpdateResponseEventType.TweetNew)]
    [InlineData(IntegrationUpdateResponseEventType.TweetReply)]
    [InlineData(IntegrationUpdateResponseEventType.TweetRetweet)]
    [InlineData(IntegrationUpdateResponseEventType.TweetQuote)]
    [InlineData(IntegrationUpdateResponseEventType.FollowerGained)]
    [InlineData(IntegrationUpdateResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(IntegrationUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationUpdateResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(IntegrationUpdateResponseType.Telegram)]
    public void Validation_Works(IntegrationUpdateResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationUpdateResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationUpdateResponseType.Telegram)]
    public void SerializationRoundtrip_Works(IntegrationUpdateResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntegrationUpdateResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
