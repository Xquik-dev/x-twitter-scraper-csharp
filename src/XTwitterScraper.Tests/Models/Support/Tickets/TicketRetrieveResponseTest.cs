using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Messages =
            [
                new()
                {
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = "user",
                },
            ],
            PublicID = "tk_abc123",
            Status = "open",
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<Message> expectedMessages =
        [
            new()
            {
                Body = "I am unable to connect my X account.",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Sender = "user",
            },
        ];
        string expectedPublicID = "tk_abc123";
        string expectedStatus = "open";
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Messages);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Messages =
            [
                new()
                {
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = "user",
                },
            ],
            PublicID = "tk_abc123",
            Status = "open",
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Messages =
            [
                new()
                {
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = "user",
                },
            ],
            PublicID = "tk_abc123",
            Status = "open",
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<Message> expectedMessages =
        [
            new()
            {
                Body = "I am unable to connect my X account.",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Sender = "user",
            },
        ];
        string expectedPublicID = "tk_abc123";
        string expectedStatus = "open";
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Messages);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Messages =
            [
                new()
                {
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = "user",
                },
            ],
            PublicID = "tk_abc123",
            Status = "open",
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TicketRetrieveResponse { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TicketRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TicketRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Messages = null,
            PublicID = null,
            Status = null,
            Subject = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Messages);
        Assert.False(model.RawData.ContainsKey("messages"));
        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TicketRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Messages = null,
            PublicID = null,
            Status = null,
            Subject = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketRetrieveResponse
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Messages =
            [
                new()
                {
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = "user",
                },
            ],
            PublicID = "tk_abc123",
            Status = "open",
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        TicketRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = "user",
        };

        string expectedBody = "I am unable to connect my X account.";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedSender = "user";

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSender, model.Sender);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = "user",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = "user",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBody = "I am unable to connect my X account.";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedSender = "user";

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSender, deserialized.Sender);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = "user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message { };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Sender);
        Assert.False(model.RawData.ContainsKey("sender"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            CreatedAt = null,
            Sender = null,
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Sender);
        Assert.False(model.RawData.ContainsKey("sender"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            CreatedAt = null,
            Sender = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = "user",
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}
