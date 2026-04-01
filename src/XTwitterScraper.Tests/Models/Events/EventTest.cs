using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Events = XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Events::Event
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Events::Type.TweetNew,
            Username = "username",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMonitorID = "monitorId";
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Events::Type> expectedType = Events::Type.TweetNew;
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
        var model = new Events::Event
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Events::Type.TweetNew,
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::Event>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Events::Event
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Events::Type.TweetNew,
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Events::Event>(
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
        ApiEnum<string, Events::Type> expectedType = Events::Type.TweetNew;
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
        var model = new Events::Event
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Events::Type.TweetNew,
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Events::Event
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MonitorID = "monitorId",
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Events::Type.TweetNew,
            Username = "username",
        };

        Events::Event copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Events::Type.TweetNew)]
    [InlineData(Events::Type.TweetReply)]
    [InlineData(Events::Type.TweetRetweet)]
    [InlineData(Events::Type.TweetQuote)]
    [InlineData(Events::Type.FollowerGained)]
    [InlineData(Events::Type.FollowerLost)]
    public void Validation_Works(Events::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Events::Type.TweetNew)]
    [InlineData(Events::Type.TweetReply)]
    [InlineData(Events::Type.TweetRetweet)]
    [InlineData(Events::Type.TweetQuote)]
    [InlineData(Events::Type.FollowerGained)]
    [InlineData(Events::Type.FollowerLost)]
    public void SerializationRoundtrip_Works(Events::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Events::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Events::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
