using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationDeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
            SourceID = "sourceId",
            SourceType = "sourceType",
        };

        string expectedID = "id";
        long expectedAttempts = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "eventType";
        string expectedStatus = "status";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        long expectedLastStatusCode = 0;
        string expectedSourceID = "sourceId";
        string expectedSourceType = "sourceType";

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
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
            SourceID = "sourceId",
            SourceType = "sourceType",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationDelivery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
            SourceID = "sourceId",
            SourceType = "sourceType",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationDelivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAttempts = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "eventType";
        string expectedStatus = "status";
        DateTimeOffset expectedDeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        long expectedLastStatusCode = 0;
        string expectedSourceID = "sourceId";
        string expectedSourceType = "sourceType";

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
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
            SourceID = "sourceId",
            SourceType = "sourceType",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
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
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",

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
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",

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
        var model = new IntegrationDelivery
        {
            ID = "id",
            Attempts = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            Status = "status",
            DeliveredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatusCode = 0,
            SourceID = "sourceId",
            SourceType = "sourceType",
        };

        IntegrationDelivery copied = new(model);

        Assert.Equal(model, copied);
    }
}
