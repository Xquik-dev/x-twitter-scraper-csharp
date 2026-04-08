using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonitorRetrieveResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorRetrieveResponseEventType.TweetNew,
                MonitorRetrieveResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, MonitorRetrieveResponseEventType>> expectedEventTypes =
        [
            MonitorRetrieveResponseEventType.TweetNew,
            MonitorRetrieveResponseEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUsername = "elonmusk";
        string expectedXUserID = "9876543210";

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
        var model = new MonitorRetrieveResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorRetrieveResponseEventType.TweetNew,
                MonitorRetrieveResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonitorRetrieveResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorRetrieveResponseEventType.TweetNew,
                MonitorRetrieveResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, MonitorRetrieveResponseEventType>> expectedEventTypes =
        [
            MonitorRetrieveResponseEventType.TweetNew,
            MonitorRetrieveResponseEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUsername = "elonmusk";
        string expectedXUserID = "9876543210";

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
        var model = new MonitorRetrieveResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorRetrieveResponseEventType.TweetNew,
                MonitorRetrieveResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonitorRetrieveResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorRetrieveResponseEventType.TweetNew,
                MonitorRetrieveResponseEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        MonitorRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorRetrieveResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(MonitorRetrieveResponseEventType.TweetNew)]
    [InlineData(MonitorRetrieveResponseEventType.TweetReply)]
    [InlineData(MonitorRetrieveResponseEventType.TweetRetweet)]
    [InlineData(MonitorRetrieveResponseEventType.TweetQuote)]
    [InlineData(MonitorRetrieveResponseEventType.FollowerGained)]
    [InlineData(MonitorRetrieveResponseEventType.FollowerLost)]
    public void Validation_Works(MonitorRetrieveResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorRetrieveResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorRetrieveResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonitorRetrieveResponseEventType.TweetNew)]
    [InlineData(MonitorRetrieveResponseEventType.TweetReply)]
    [InlineData(MonitorRetrieveResponseEventType.TweetRetweet)]
    [InlineData(MonitorRetrieveResponseEventType.TweetQuote)]
    [InlineData(MonitorRetrieveResponseEventType.FollowerGained)]
    [InlineData(MonitorRetrieveResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(MonitorRetrieveResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorRetrieveResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorRetrieveResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MonitorRetrieveResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorRetrieveResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
