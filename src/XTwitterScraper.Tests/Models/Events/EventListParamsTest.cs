using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventListParams
        {
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        string expectedAfter = "after";
        ApiEnum<string, EventType> expectedEventType = EventType.TweetNew;
        long expectedLimit = 1;
        string expectedMonitorID = "monitorId";

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMonitorID, parameters.MonitorID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MonitorID);
        Assert.False(parameters.RawQueryData.ContainsKey("monitorId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            EventType = null,
            Limit = null,
            MonitorID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MonitorID);
        Assert.False(parameters.RawQueryData.ContainsKey("monitorId"));
    }

    [Fact]
    public void Url_Works()
    {
        EventListParams parameters = new()
        {
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/events?after=after&eventType=tweet.new&limit=1&monitorId=monitorId"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventListParams
        {
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        EventListParams copied = new(parameters);

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
