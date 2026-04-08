using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
            XEventID = "1234567890",
        };

        string expectedID = "42";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "tweetId", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "10";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, EventDetailType> expectedType = EventDetailType.TweetNew;
        string expectedUsername = "elonmusk";
        string expectedXEventID = "1234567890";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedMonitorID, model.MonitorID);
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedXEventID, model.XEventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
            XEventID = "1234567890",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
            XEventID = "1234567890",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "tweetId", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "10";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, EventDetailType> expectedType = EventDetailType.TweetNew;
        string expectedUsername = "elonmusk";
        string expectedXEventID = "1234567890";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedMonitorID, deserialized.MonitorID);
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedXEventID, deserialized.XEventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
            XEventID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
        };

        Assert.Null(model.XEventID);
        Assert.False(model.RawData.ContainsKey("xEventId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            XEventID = null,
        };

        Assert.Null(model.XEventID);
        Assert.False(model.RawData.ContainsKey("xEventId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            XEventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventDetail
        {
            ID = "42",
            Data = new Dictionary<string, JsonElement>()
            {
                { "tweetId", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "10",
            OccurredAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Type = EventDetailType.TweetNew,
            Username = "elonmusk",
            XEventID = "1234567890",
        };

        EventDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventDetailTypeTest : TestBase
{
    [Theory]
    [InlineData(EventDetailType.TweetNew)]
    [InlineData(EventDetailType.TweetReply)]
    [InlineData(EventDetailType.TweetRetweet)]
    [InlineData(EventDetailType.TweetQuote)]
    [InlineData(EventDetailType.FollowerGained)]
    [InlineData(EventDetailType.FollowerLost)]
    public void Validation_Works(EventDetailType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventDetailType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventDetailType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventDetailType.TweetNew)]
    [InlineData(EventDetailType.TweetReply)]
    [InlineData(EventDetailType.TweetRetweet)]
    [InlineData(EventDetailType.TweetQuote)]
    [InlineData(EventDetailType.FollowerGained)]
    [InlineData(EventDetailType.FollowerLost)]
    public void SerializationRoundtrip_Works(EventDetailType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventDetailType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventDetailType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventDetailType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventDetailType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
