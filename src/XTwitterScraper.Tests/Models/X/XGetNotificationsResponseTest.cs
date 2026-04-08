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
            NextCursor = "DAACCgACGRElMJcAAA",
            Notifications =
            [
                new()
                {
                    ID = "1234567890",
                    Message = "elonmusk liked your tweet",
                    Timestamp = "2025-01-15T12:00:00Z",
                    Type = "like",
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<Notification> expectedNotifications =
        [
            new()
            {
                ID = "1234567890",
                Message = "elonmusk liked your tweet",
                Timestamp = "2025-01-15T12:00:00Z",
                Type = "like",
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
            NextCursor = "DAACCgACGRElMJcAAA",
            Notifications =
            [
                new()
                {
                    ID = "1234567890",
                    Message = "elonmusk liked your tweet",
                    Timestamp = "2025-01-15T12:00:00Z",
                    Type = "like",
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
            NextCursor = "DAACCgACGRElMJcAAA",
            Notifications =
            [
                new()
                {
                    ID = "1234567890",
                    Message = "elonmusk liked your tweet",
                    Timestamp = "2025-01-15T12:00:00Z",
                    Type = "like",
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
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<Notification> expectedNotifications =
        [
            new()
            {
                ID = "1234567890",
                Message = "elonmusk liked your tweet",
                Timestamp = "2025-01-15T12:00:00Z",
                Type = "like",
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
            NextCursor = "DAACCgACGRElMJcAAA",
            Notifications =
            [
                new()
                {
                    ID = "1234567890",
                    Message = "elonmusk liked your tweet",
                    Timestamp = "2025-01-15T12:00:00Z",
                    Type = "like",
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
            NextCursor = "DAACCgACGRElMJcAAA",
            Notifications =
            [
                new()
                {
                    ID = "1234567890",
                    Message = "elonmusk liked your tweet",
                    Timestamp = "2025-01-15T12:00:00Z",
                    Type = "like",
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
            ID = "1234567890",
            Message = "elonmusk liked your tweet",
            Timestamp = "2025-01-15T12:00:00Z",
            Type = "like",
        };

        string expectedID = "1234567890";
        string expectedMessage = "elonmusk liked your tweet";
        string expectedTimestamp = "2025-01-15T12:00:00Z";
        string expectedType = "like";

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
            ID = "1234567890",
            Message = "elonmusk liked your tweet",
            Timestamp = "2025-01-15T12:00:00Z",
            Type = "like",
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
            ID = "1234567890",
            Message = "elonmusk liked your tweet",
            Timestamp = "2025-01-15T12:00:00Z",
            Type = "like",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "1234567890";
        string expectedMessage = "elonmusk liked your tweet";
        string expectedTimestamp = "2025-01-15T12:00:00Z";
        string expectedType = "like";

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
            ID = "1234567890",
            Message = "elonmusk liked your tweet",
            Timestamp = "2025-01-15T12:00:00Z",
            Type = "like",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notification { ID = "1234567890" };

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
        var model = new Notification { ID = "1234567890" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notification
        {
            ID = "1234567890",

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
            ID = "1234567890",

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
            ID = "1234567890",
            Message = "elonmusk liked your tweet",
            Timestamp = "2025-01-15T12:00:00Z",
            Type = "like",
        };

        Notification copied = new(model);

        Assert.Equal(model, copied);
    }
}
