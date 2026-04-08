using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookListDeliveriesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "id",
                    Attempts = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    StreamEventID = "streamEventId",
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastError = "lastError",
                    LastStatusCode = 0,
                },
            ],
        };

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                ID = "id",
                Attempts = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                StreamEventID = "streamEventId",
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatusCode = 0,
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
        var model = new WebhookListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "id",
                    Attempts = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    StreamEventID = "streamEventId",
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastError = "lastError",
                    LastStatusCode = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListDeliveriesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "id",
                    Attempts = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    StreamEventID = "streamEventId",
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastError = "lastError",
                    LastStatusCode = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListDeliveriesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                ID = "id",
                Attempts = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                StreamEventID = "streamEventId",
                DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatusCode = 0,
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
        var model = new WebhookListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "id",
                    Attempts = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    StreamEventID = "streamEventId",
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastError = "lastError",
                    LastStatusCode = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListDeliveriesResponse
        {
            Deliveries =
            [
                new()
                {
                    ID = "id",
                    Attempts = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    StreamEventID = "streamEventId",
                    DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastError = "lastError",
                    LastStatusCode = 0,
                },
            ],
        };

        WebhookListDeliveriesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
