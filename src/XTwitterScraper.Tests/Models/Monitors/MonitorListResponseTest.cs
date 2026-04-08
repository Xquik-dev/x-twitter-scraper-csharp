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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        MonitorListResponseMonitorEventType.TweetNew,
                        MonitorListResponseMonitorEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
                },
            ],
            Total = 0,
        };

        List<MonitorListResponseMonitor> expectedMonitors =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes =
                [
                    MonitorListResponseMonitorEventType.TweetNew,
                    MonitorListResponseMonitorEventType.FollowerGained,
                ],
                IsActive = true,
                Username = "elonmusk",
                XUserID = "9876543210",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        MonitorListResponseMonitorEventType.TweetNew,
                        MonitorListResponseMonitorEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        MonitorListResponseMonitorEventType.TweetNew,
                        MonitorListResponseMonitorEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
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
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes =
                [
                    MonitorListResponseMonitorEventType.TweetNew,
                    MonitorListResponseMonitorEventType.FollowerGained,
                ],
                IsActive = true,
                Username = "elonmusk",
                XUserID = "9876543210",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        MonitorListResponseMonitorEventType.TweetNew,
                        MonitorListResponseMonitorEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        MonitorListResponseMonitorEventType.TweetNew,
                        MonitorListResponseMonitorEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
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
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorListResponseMonitorEventType.TweetNew,
                MonitorListResponseMonitorEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, MonitorListResponseMonitorEventType>> expectedEventTypes =
        [
            MonitorListResponseMonitorEventType.TweetNew,
            MonitorListResponseMonitorEventType.FollowerGained,
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
        var model = new MonitorListResponseMonitor
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorListResponseMonitorEventType.TweetNew,
                MonitorListResponseMonitorEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
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
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorListResponseMonitorEventType.TweetNew,
                MonitorListResponseMonitorEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorListResponseMonitor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, MonitorListResponseMonitorEventType>> expectedEventTypes =
        [
            MonitorListResponseMonitorEventType.TweetNew,
            MonitorListResponseMonitorEventType.FollowerGained,
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
        var model = new MonitorListResponseMonitor
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorListResponseMonitorEventType.TweetNew,
                MonitorListResponseMonitorEventType.FollowerGained,
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
        var model = new MonitorListResponseMonitor
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                MonitorListResponseMonitorEventType.TweetNew,
                MonitorListResponseMonitorEventType.FollowerGained,
            ],
            IsActive = true,
            Username = "elonmusk",
            XUserID = "9876543210",
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
