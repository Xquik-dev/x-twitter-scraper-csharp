using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationCreateParams
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
        };

        Config expectedConfig = new("-1001234567890");
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.TweetNew,
            EventType.FollowerGained,
        ];
        string expectedName = "My Telegram Bot";
        JsonElement expectedType = JsonSerializer.SerializeToElement("telegram");

        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, parameters.Type));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationCreateParams parameters = new()
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
            Type = JsonSerializer.SerializeToElement("telegram"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/integrations"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationCreateParams
        {
            Config = new("-1001234567890"),
            EventTypes = [EventType.TweetNew, EventType.FollowerGained],
            Name = "My Telegram Bot",
        };

        IntegrationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config { ChatID = "-1001234567890" };

        string expectedChatID = "-1001234567890";

        Assert.Equal(expectedChatID, model.ChatID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Config { ChatID = "-1001234567890" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Config { ChatID = "-1001234567890" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedChatID = "-1001234567890";

        Assert.Equal(expectedChatID, deserialized.ChatID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Config { ChatID = "-1001234567890" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Config { ChatID = "-1001234567890" };

        Config copied = new(model);

        Assert.Equal(model, copied);
    }
}
