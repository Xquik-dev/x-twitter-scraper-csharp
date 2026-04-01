using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonitorListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                    IsActive = true,
                    Username = "username",
                    XUserID = "xUserId",
                },
            ],
            Total = 0,
        };

        List<MonitorListResponseMonitor> expectedMonitors =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                IsActive = true,
                Username = "username",
                XUserID = "xUserId",
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedMonitors.Count, model.Monitors.Count);
        for (int i = 0; i < expectedMonitors.Count; i++)
        {
            Assert.Equal(expectedMonitors[i], model.Monitors[i]);
        }
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonitorListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                    IsActive = true,
                    Username = "username",
                    XUserID = "xUserId",
                },
            ],
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonitorListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                    IsActive = true,
                    Username = "username",
                    XUserID = "xUserId",
                },
            ],
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MonitorListResponseMonitor> expectedMonitors =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                IsActive = true,
                Username = "username",
                XUserID = "xUserId",
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedMonitors.Count, deserialized.Monitors.Count);
        for (int i = 0; i < expectedMonitors.Count; i++)
        {
            Assert.Equal(expectedMonitors[i], deserialized.Monitors[i]);
        }
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonitorListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                    IsActive = true,
                    Username = "username",
                    XUserID = "xUserId",
                },
            ],
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonitorListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
                    IsActive = true,
                    Username = "username",
                    XUserID = "xUserId",
                },
            ],
            Total = 0,
        };

        MonitorListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorListResponseMonitorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonitorListResponseMonitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, MonitorListResponseMonitorEventType>> expectedEventTypes =
        [
            MonitorListResponseMonitorEventType.TweetNew,
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
        var model = new MonitorListResponseMonitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorListResponseMonitor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonitorListResponseMonitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorListResponseMonitor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, MonitorListResponseMonitorEventType>> expectedEventTypes =
        [
            MonitorListResponseMonitorEventType.TweetNew,
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
        var model = new MonitorListResponseMonitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonitorListResponseMonitor
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [MonitorListResponseMonitorEventType.TweetNew],
            IsActive = true,
            Username = "username",
            XUserID = "xUserId",
        };

        MonitorListResponseMonitor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorListResponseMonitorEventTypeTest : TestBase
{
    [Theory]
    [InlineData(MonitorListResponseMonitorEventType.TweetNew)]
    [InlineData(MonitorListResponseMonitorEventType.TweetReply)]
    [InlineData(MonitorListResponseMonitorEventType.TweetRetweet)]
    [InlineData(MonitorListResponseMonitorEventType.TweetQuote)]
    [InlineData(MonitorListResponseMonitorEventType.FollowerGained)]
    [InlineData(MonitorListResponseMonitorEventType.FollowerLost)]
    public void Validation_Works(MonitorListResponseMonitorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorListResponseMonitorEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorListResponseMonitorEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonitorListResponseMonitorEventType.TweetNew)]
    [InlineData(MonitorListResponseMonitorEventType.TweetReply)]
    [InlineData(MonitorListResponseMonitorEventType.TweetRetweet)]
    [InlineData(MonitorListResponseMonitorEventType.TweetQuote)]
    [InlineData(MonitorListResponseMonitorEventType.FollowerGained)]
    [InlineData(MonitorListResponseMonitorEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(MonitorListResponseMonitorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonitorListResponseMonitorEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorListResponseMonitorEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorListResponseMonitorEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonitorListResponseMonitorEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
