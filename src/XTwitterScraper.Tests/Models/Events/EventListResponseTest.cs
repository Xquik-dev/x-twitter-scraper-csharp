using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        List<EventListResponseEvent> expectedEvents =
        [
            new()
            {
                ID = "id",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MonitorID = "monitorId",
                OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = EventListResponseEventType.TweetNew,
                Username = "username",
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EventListResponseEvent> expectedEvents =
        [
            new()
            {
                ID = "id",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MonitorID = "monitorId",
                OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = EventListResponseEventType.TweetNew,
                Username = "username",
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventListResponse
        {
            Events =
            [
                new()
                {
                    ID = "id",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MonitorID = "monitorId",
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = EventListResponseEventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        EventListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventListResponseEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventListResponseEvent
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventListResponseEventType.TweetNew,
            Username = "username",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "monitorId";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, EventListResponseEventType> expectedType =
            EventListResponseEventType.TweetNew;
        string expectedUsername = "username";

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventListResponseEvent
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventListResponseEventType.TweetNew,
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListResponseEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventListResponseEvent
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventListResponseEventType.TweetNew,
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListResponseEvent>(
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
        ApiEnum<string, EventListResponseEventType> expectedType =
            EventListResponseEventType.TweetNew;
        string expectedUsername = "username";

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventListResponseEvent
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventListResponseEventType.TweetNew,
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventListResponseEvent
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = EventListResponseEventType.TweetNew,
            Username = "username",
        };

        EventListResponseEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventListResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventListResponseEventType.TweetNew)]
    [InlineData(EventListResponseEventType.TweetReply)]
    [InlineData(EventListResponseEventType.TweetRetweet)]
    [InlineData(EventListResponseEventType.TweetQuote)]
    [InlineData(EventListResponseEventType.FollowerGained)]
    [InlineData(EventListResponseEventType.FollowerLost)]
    public void Validation_Works(EventListResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventListResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventListResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventListResponseEventType.TweetNew)]
    [InlineData(EventListResponseEventType.TweetReply)]
    [InlineData(EventListResponseEventType.TweetRetweet)]
    [InlineData(EventListResponseEventType.TweetQuote)]
    [InlineData(EventListResponseEventType.FollowerGained)]
    [InlineData(EventListResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(EventListResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventListResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventListResponseEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventListResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventListResponseEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
