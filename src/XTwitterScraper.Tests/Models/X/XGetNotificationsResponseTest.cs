using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetNotificationsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XGetNotificationsResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Notifications =
            [
                new()
                {
                    ID = "id",
                    Message = "message",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<Notification> expectedNotifications =
        [
            new()
            {
                ID = "id",
                Message = "message",
                Timestamp = "timestamp",
                Type = "type",
            },
        ];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedNotifications.Count, model.Notifications.Count);
        for (int i = 0; i < expectedNotifications.Count; i++)
        {
            Assert.Equal(expectedNotifications[i], model.Notifications[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new XGetNotificationsResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Notifications =
            [
                new()
                {
                    ID = "id",
                    Message = "message",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetNotificationsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XGetNotificationsResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Notifications =
            [
                new()
                {
                    ID = "id",
                    Message = "message",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetNotificationsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<Notification> expectedNotifications =
        [
            new()
            {
                ID = "id",
                Message = "message",
                Timestamp = "timestamp",
                Type = "type",
            },
        ];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedNotifications.Count, deserialized.Notifications.Count);
        for (int i = 0; i < expectedNotifications.Count; i++)
        {
            Assert.Equal(expectedNotifications[i], deserialized.Notifications[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new XGetNotificationsResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Notifications =
            [
                new()
                {
                    ID = "id",
                    Message = "message",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XGetNotificationsResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Notifications =
            [
                new()
                {
                    ID = "id",
                    Message = "message",
                    Timestamp = "timestamp",
                    Type = "type",
                },
            ],
        };

        XGetNotificationsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notification
        {
            ID = "id",
            Message = "message",
            Timestamp = "timestamp",
            Type = "type",
        };

        string expectedID = "id";
        string expectedMessage = "message";
        string expectedTimestamp = "timestamp";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notification
        {
            ID = "id",
            Message = "message",
            Timestamp = "timestamp",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notification
        {
            ID = "id",
            Message = "message",
            Timestamp = "timestamp",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMessage = "message";
        string expectedTimestamp = "timestamp";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            Message = "message",
            Timestamp = "timestamp",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notification { ID = "id" };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notification { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notification
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Timestamp = null,
            Type = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notification
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Timestamp = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notification
        {
            ID = "id",
            Message = "message",
            Timestamp = "timestamp",
            Type = "type",
        };

        Notification copied = new(model);

        Assert.Equal(model, copied);
    }
}
