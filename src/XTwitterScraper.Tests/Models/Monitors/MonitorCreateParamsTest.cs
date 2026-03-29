using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorCreateParams
        {
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        string expectedUsername = "username";

        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        MonitorCreateParams parameters = new()
        {
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/monitors"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorCreateParams
        {
            EventTypes = [EventType.TweetNew],
            Username = "username",
        };

        MonitorCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.TweetNew)]
    [InlineData(EventType.TweetReply)]
    [InlineData(EventType.TweetRetweet)]
    [InlineData(EventType.TweetQuote)]
    [InlineData(EventType.FollowerGained)]
    [InlineData(EventType.FollowerLost)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.TweetNew)]
    [InlineData(EventType.TweetReply)]
    [InlineData(EventType.TweetRetweet)]
    [InlineData(EventType.TweetQuote)]
    [InlineData(EventType.FollowerGained)]
    [InlineData(EventType.FollowerLost)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
