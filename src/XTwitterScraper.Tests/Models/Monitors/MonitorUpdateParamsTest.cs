using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",
            EventTypes = [MonitorUpdateParamsEventType.TweetNew],
            IsActive = true,
        };

        string expectedID = "id";
        List<ApiEnum<string, MonitorUpdateParamsEventType>> expectedEventTypes =
        [
            MonitorUpdateParamsEventType.TweetNew,
        ];
        bool expectedIsActive = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MonitorUpdateParams { ID = "id" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            IsActive = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
    }

    [Fact]
    public void Url_Works()
    {
        MonitorUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/monitors/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",
            EventTypes = [MonitorUpdateParamsEventType.TweetNew],
            IsActive = true,
        };

        MonitorUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MonitorUpdateParamsEventTypeTest : TestBase
{
    [Theory]
    [InlineData(MonitorUpdateParamsEventType.TweetNew)]
    [InlineData(MonitorUpdateParamsEventType.TweetReply)]
    [InlineData(MonitorUpdateParamsEventType.TweetRetweet)]
    [InlineData(MonitorUpdateParamsEventType.TweetQuote)]
    [InlineData(MonitorUpdateParamsEventType.FollowerGained)]
    [InlineData(MonitorUpdateParamsEventType.FollowerLost)]
    public void Validation_Works(MonitorUpdateParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorUpdateParamsEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorUpdateParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonitorUpdateParamsEventType.TweetNew)]
    [InlineData(MonitorUpdateParamsEventType.TweetReply)]
    [InlineData(MonitorUpdateParamsEventType.TweetRetweet)]
    [InlineData(MonitorUpdateParamsEventType.TweetQuote)]
    [InlineData(MonitorUpdateParamsEventType.FollowerGained)]
    [InlineData(MonitorUpdateParamsEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(MonitorUpdateParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorUpdateParamsEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorUpdateParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorUpdateParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorUpdateParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
