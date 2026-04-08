using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using Integrations = XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Integrations::IntegrationCreateParams
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
            Type = Integrations::Type.Telegram,
        };

        Integrations::Config expectedConfig = new("-1001234567890");
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.FollowerGained,
        ];
        string expectedName = "My Telegram Bot";
        ApiEnum<string, Integrations::Type> expectedType = Integrations::Type.Telegram;

        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void Url_Works()
    {
        Integrations::IntegrationCreateParams parameters = new()
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
            Type = Integrations::Type.Telegram,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/integrations"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Integrations::IntegrationCreateParams
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
            Type = Integrations::Type.Telegram,
        };

        Integrations::IntegrationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Integrations::Config { ChatID = "-1001234567890" };

        string expectedChatID = "-1001234567890";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Integrations::Config { ChatID = "-1001234567890" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integrations::Config>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Integrations::Config { ChatID = "-1001234567890" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integrations::Config>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChatID = "-1001234567890";

        Assert.Equal(expectedChatID, deserialized.ChatID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Integrations::Config { ChatID = "-1001234567890" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Integrations::Config { ChatID = "-1001234567890" };

        Integrations::Config copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Integrations::Type.Telegram)]
    public void Validation_Works(Integrations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Integrations::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Integrations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Integrations::Type.Telegram)]
    public void SerializationRoundtrip_Works(Integrations::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Integrations::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Integrations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Integrations::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Integrations::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
