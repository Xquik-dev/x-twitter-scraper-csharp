using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
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
                    Type = EventType.TweetNew,
                    Username = "username",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        List<Event> expectedEvents =
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
                Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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

        List<Event> expectedEvents =
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
                Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
                    Type = EventType.TweetNew,
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
