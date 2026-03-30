using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Monitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        string expectedUsername = "username";
        string expectedXUserID = "xUserId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedXUserID, model.XUserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Monitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Monitor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Monitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Monitor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        string expectedUsername = "username";
        string expectedXUserID = "xUserId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Monitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Monitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        Monitor copied = new(model);

        Assert.Equal(model, copied);
    }
}
