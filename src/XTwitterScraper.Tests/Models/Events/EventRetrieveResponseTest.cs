using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
            XEventID = "xEventId",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "monitorId";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventRetrieveResponseType> expectedType =
            EventRetrieveResponseType.TweetNew;
        string expectedUsername = "username";
        string expectedXEventID = "xEventId";

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
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
            XEventID = "xEventId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
            XEventID = "xEventId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "monitorId";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventRetrieveResponseType> expectedType =
            EventRetrieveResponseType.TweetNew;
        string expectedUsername = "username";
        string expectedXEventID = "xEventId";

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
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
            XEventID = "xEventId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
        };

        Assert.Null(model.XEventID);
        Assert.False(model.RawData.ContainsKey("xEventId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",

            // Null should be interpreted as omitted for these properties
            XEventID = null,
        };

        Assert.Null(model.XEventID);
        Assert.False(model.RawData.ContainsKey("xEventId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",

            // Null should be interpreted as omitted for these properties
            XEventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventRetrieveResponse
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventRetrieveResponseType.TweetNew,
            Username = "username",
            XEventID = "xEventId",
        };

        EventRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventRetrieveResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(EventRetrieveResponseType.TweetNew)]
    [InlineData(EventRetrieveResponseType.TweetReply)]
    [InlineData(EventRetrieveResponseType.TweetRetweet)]
    [InlineData(EventRetrieveResponseType.TweetQuote)]
    [InlineData(EventRetrieveResponseType.FollowerGained)]
    [InlineData(EventRetrieveResponseType.FollowerLost)]
    public void Validation_Works(EventRetrieveResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventRetrieveResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventRetrieveResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventRetrieveResponseType.TweetNew)]
    [InlineData(EventRetrieveResponseType.TweetReply)]
    [InlineData(EventRetrieveResponseType.TweetRetweet)]
    [InlineData(EventRetrieveResponseType.TweetQuote)]
    [InlineData(EventRetrieveResponseType.FollowerGained)]
    [InlineData(EventRetrieveResponseType.FollowerLost)]
    public void SerializationRoundtrip_Works(EventRetrieveResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventRetrieveResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventRetrieveResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventRetrieveResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventRetrieveResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
