// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Tests.Models.Monitors.Keywords;

public class KeywordListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new KeywordListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "21",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Query = "xquik OR \"x api\"",
                },
            ],
            Total = 0,
        };

        List<Monitor> expectedMonitors =
        [
            new()
            {
                ID = "21",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew],
                IsActive = true,
                NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Query = "xquik OR \"x api\"",
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
        var model = new KeywordListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "21",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Query = "xquik OR \"x api\"",
                },
            ],
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KeywordListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new KeywordListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "21",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Query = "xquik OR \"x api\"",
                },
            ],
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KeywordListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Monitor> expectedMonitors =
        [
            new()
            {
                ID = "21",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes = [EventType.TweetNew],
                IsActive = true,
                NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Query = "xquik OR \"x api\"",
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
        var model = new KeywordListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "21",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Query = "xquik OR \"x api\"",
                },
            ],
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new KeywordListResponse
        {
            Monitors =
            [
                new()
                {
                    ID = "21",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes = [EventType.TweetNew],
                    IsActive = true,
                    NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Query = "xquik OR \"x api\"",
                },
            ],
            Total = 0,
        };

        KeywordListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Monitor
        {
            ID = "21",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Query = "xquik OR \"x api\"",
        };

        string expectedID = "21";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        DateTimeOffset expectedNextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedQuery = "xquik OR \"x api\"";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedNextBillingAt, model.NextBillingAt);
        Assert.Equal(expectedQuery, model.Query);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Monitor
        {
            ID = "21",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Query = "xquik OR \"x api\"",
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
            ID = "21",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Query = "xquik OR \"x api\"",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Monitor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "21";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;
        DateTimeOffset expectedNextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedQuery = "xquik OR \"x api\"";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedNextBillingAt, deserialized.NextBillingAt);
        Assert.Equal(expectedQuery, deserialized.Query);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Monitor
        {
            ID = "21",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Query = "xquik OR \"x api\"",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Monitor
        {
            ID = "21",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes = [EventType.TweetNew],
            IsActive = true,
            NextBillingAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Query = "xquik OR \"x api\"",
        };

        Monitor copied = new(model);

        Assert.Equal(model, copied);
    }
}
