using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationListDeliveriesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "42",
                    Attempts = 1,
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventType = "tweet.new",
                    Status = "delivered",
                    DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                    LastError = "",
                    LastStatusCode = 200,
                    SourceID = "100",
                    SourceType = "monitor",
                },
            ],
        };

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                ID = "42",
                Attempts = 1,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventType = "tweet.new",
                Status = "delivered",
                DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                LastError = "",
                LastStatusCode = 200,
                SourceID = "100",
                SourceType = "monitor",
            },
        ];

        Assert.Equal(expectedDeliveries.Count, model.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], model.Deliveries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "42",
                    Attempts = 1,
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventType = "tweet.new",
                    Status = "delivered",
                    DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                    LastError = "",
                    LastStatusCode = 200,
                    SourceID = "100",
                    SourceType = "monitor",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListDeliveriesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "42",
                    Attempts = 1,
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventType = "tweet.new",
                    Status = "delivered",
                    DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                    LastError = "",
                    LastStatusCode = 200,
                    SourceID = "100",
                    SourceType = "monitor",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListDeliveriesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                ID = "42",
                Attempts = 1,
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventType = "tweet.new",
                Status = "delivered",
                DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                LastError = "",
                LastStatusCode = 200,
                SourceID = "100",
                SourceType = "monitor",
            },
        ];

        Assert.Equal(expectedDeliveries.Count, deserialized.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], deserialized.Deliveries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntegrationListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "42",
                    Attempts = 1,
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventType = "tweet.new",
                    Status = "delivered",
                    DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                    LastError = "",
                    LastStatusCode = 200,
                    SourceID = "100",
                    SourceType = "monitor",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "42",
                    Attempts = 1,
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventType = "tweet.new",
                    Status = "delivered",
                    DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
                    LastError = "",
                    LastStatusCode = 200,
                    SourceID = "100",
                    SourceType = "monitor",
                },
            ],
        };

        IntegrationListDeliveriesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
            DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
            LastError = "",
            LastStatusCode = 200,
            SourceID = "100",
            SourceType = "monitor",
        };

        string expectedID = "42";
        long expectedAttempts = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedEventType = "tweet.new";
        string expectedStatus = "delivered";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z");
        string expectedLastError = "";
        long expectedLastStatusCode = 200;
        string expectedSourceID = "100";
        string expectedSourceType = "monitor";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttempts, model.Attempts);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedDeliveredAt, model.DeliveredAt);
        Assert.Equal(expectedLastError, model.LastError);
        Assert.Equal(expectedLastStatusCode, model.LastStatusCode);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedSourceType, model.SourceType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
            DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
            LastError = "",
            LastStatusCode = 200,
            SourceID = "100",
            SourceType = "monitor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delivery>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
            DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
            LastError = "",
            LastStatusCode = 200,
            SourceID = "100",
            SourceType = "monitor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        long expectedAttempts = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedEventType = "tweet.new";
        string expectedStatus = "delivered";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z");
        string expectedLastError = "";
        long expectedLastStatusCode = 200;
        string expectedSourceID = "100";
        string expectedSourceType = "monitor";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttempts, deserialized.Attempts);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedDeliveredAt, deserialized.DeliveredAt);
        Assert.Equal(expectedLastError, deserialized.LastError);
        Assert.Equal(expectedLastStatusCode, deserialized.LastStatusCode);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
            DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
            LastError = "",
            LastStatusCode = 200,
            SourceID = "100",
            SourceType = "monitor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("deliveredAt"));
        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatusCode);
        Assert.False(model.RawData.ContainsKey("lastStatusCode"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("sourceId"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("sourceType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",

            // Null should be interpreted as omitted for these properties
            DeliveredAt = null,
            LastError = null,
            LastStatusCode = null,
            SourceID = null,
            SourceType = null,
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("deliveredAt"));
        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatusCode);
        Assert.False(model.RawData.ContainsKey("lastStatusCode"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("sourceId"));
        Assert.Null(model.SourceType);
        Assert.False(model.RawData.ContainsKey("sourceType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",

            // Null should be interpreted as omitted for these properties
            DeliveredAt = null,
            LastError = null,
            LastStatusCode = null,
            SourceID = null,
            SourceType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Delivery
        {
            ID = "42",
            Attempts = 1,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventType = "tweet.new",
            Status = "delivered",
            DeliveredAt = DateTimeOffset.Parse("2025-01-15T12:00:01Z"),
            LastError = "",
            LastStatusCode = 200,
            SourceID = "100",
            SourceType = "monitor",
        };

        Delivery copied = new(model);

        Assert.Equal(model, copied);
    }
}
