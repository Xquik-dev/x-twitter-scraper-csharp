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

public class DeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
        };

        string expectedID = "id";
        long expectedAttempts = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedStreamEventID = "streamEventId";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        long expectedLastStatusCode = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttempts, model.Attempts);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStreamEventID, model.StreamEventID);
        Assert.Equal(expectedDeliveredAt, model.DeliveredAt);
        Assert.Equal(expectedLastError, model.LastError);
        Assert.Equal(expectedLastStatusCode, model.LastStatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
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
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAttempts = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedStreamEventID = "streamEventId";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        long expectedLastStatusCode = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttempts, deserialized.Attempts);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStreamEventID, deserialized.StreamEventID);
        Assert.Equal(expectedDeliveredAt, deserialized.DeliveredAt);
        Assert.Equal(expectedLastError, deserialized.LastError);
        Assert.Equal(expectedLastStatusCode, deserialized.LastStatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("deliveredAt"));
        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatusCode);
        Assert.False(model.RawData.ContainsKey("lastStatusCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",

            // Null should be interpreted as omitted for these properties
            DeliveredAt = null,
            LastError = null,
            LastStatusCode = null,
        };

        Assert.Null(model.DeliveredAt);
        Assert.False(model.RawData.ContainsKey("deliveredAt"));
        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatusCode);
        Assert.False(model.RawData.ContainsKey("lastStatusCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",

            // Null should be interpreted as omitted for these properties
            DeliveredAt = null,
            LastError = null,
            LastStatusCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Delivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            StreamEventID = "streamEventId",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
        };

        Delivery copied = new(model);

        Assert.Equal(model, copied);
    }
}
