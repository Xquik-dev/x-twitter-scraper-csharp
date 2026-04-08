using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
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
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                    IsActive = true,
                    Username = "elonmusk",
                    XUserID = "9876543210",
                },
            ],
            Total = 0,
        };

        List<Monitor> expectedMonitors =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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

        List<Monitor> expectedMonitors =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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
                    EventTypes = [EventType.TweetNew, EventType.FollowerGained],
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
