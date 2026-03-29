using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonitorUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorUpdateResponseEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, MonitorUpdateResponseEventType>> expectedEventTypes =
        [
            MonitorUpdateResponseEventType.TweetNew,
        ];
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
        var model = new MonitorUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorUpdateResponseEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonitorUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorUpdateResponseEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, MonitorUpdateResponseEventType>> expectedEventTypes =
        [
            MonitorUpdateResponseEventType.TweetNew,
        ];
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
        var model = new MonitorUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorUpdateResponseEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonitorUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorUpdateResponseEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        MonitorUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorUpdateResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(MonitorUpdateResponseEventType.TweetNew)]
    [InlineData(MonitorUpdateResponseEventType.TweetReply)]
    [InlineData(MonitorUpdateResponseEventType.TweetRetweet)]
    [InlineData(MonitorUpdateResponseEventType.TweetQuote)]
    [InlineData(MonitorUpdateResponseEventType.FollowerGained)]
    [InlineData(MonitorUpdateResponseEventType.FollowerLost)]
    public void Validation_Works(MonitorUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorUpdateResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonitorUpdateResponseEventType.TweetNew)]
    [InlineData(MonitorUpdateResponseEventType.TweetReply)]
    [InlineData(MonitorUpdateResponseEventType.TweetRetweet)]
    [InlineData(MonitorUpdateResponseEventType.TweetQuote)]
    [InlineData(MonitorUpdateResponseEventType.FollowerGained)]
    [InlineData(MonitorUpdateResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(MonitorUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorUpdateResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
