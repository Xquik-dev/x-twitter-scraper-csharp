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

        List<IntegrationDelivery> expectedDeliveries =
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

        List<IntegrationDelivery> expectedDeliveries =
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
