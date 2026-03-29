using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketListResponse
        {
            Tickets =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageCount = 0,
                    PublicID = "publicId",
                    Status = "status",
                    Subject = "subject",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Ticket> expectedTickets =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MessageCount = 0,
                PublicID = "publicId",
                Status = "status",
                Subject = "subject",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(model.Tickets);
        Assert.Equal(expectedTickets.Count, model.Tickets.Count);
        for (int i = 0; i < expectedTickets.Count; i++)
        {
            Assert.Equal(expectedTickets[i], model.Tickets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketListResponse
        {
            Tickets =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageCount = 0,
                    PublicID = "publicId",
                    Status = "status",
                    Subject = "subject",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketListResponse
        {
            Tickets =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageCount = 0,
                    PublicID = "publicId",
                    Status = "status",
                    Subject = "subject",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Ticket> expectedTickets =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MessageCount = 0,
                PublicID = "publicId",
                Status = "status",
                Subject = "subject",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.NotNull(deserialized.Tickets);
        Assert.Equal(expectedTickets.Count, deserialized.Tickets.Count);
        for (int i = 0; i < expectedTickets.Count; i++)
        {
            Assert.Equal(expectedTickets[i], deserialized.Tickets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketListResponse
        {
            Tickets =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageCount = 0,
                    PublicID = "publicId",
                    Status = "status",
                    Subject = "subject",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TicketListResponse { };

        Assert.Null(model.Tickets);
        Assert.False(model.RawData.ContainsKey("tickets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TicketListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TicketListResponse
        {
            // Null should be interpreted as omitted for these properties
            Tickets = null,
        };

        Assert.Null(model.Tickets);
        Assert.False(model.RawData.ContainsKey("tickets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TicketListResponse
        {
            // Null should be interpreted as omitted for these properties
            Tickets = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketListResponse
        {
            Tickets =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageCount = 0,
                    PublicID = "publicId",
                    Status = "status",
                    Subject = "subject",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        TicketListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TicketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
            PublicID = "publicId",
            Status = "status",
            Subject = "subject",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedMessageCount = 0;
        string expectedPublicID = "publicId";
        string expectedStatus = "status";
        string expectedSubject = "subject";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
            PublicID = "publicId",
            Status = "status",
            Subject = "subject",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ticket>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
            PublicID = "publicId",
            Status = "status",
            Subject = "subject",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ticket>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedMessageCount = 0;
        string expectedPublicID = "publicId";
        string expectedStatus = "status";
        string expectedSubject = "subject";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
            PublicID = "publicId",
            Status = "status",
            Subject = "subject",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ticket { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.MessageCount);
        Assert.False(model.RawData.ContainsKey("messageCount"));
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
        var model = new Ticket { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Ticket
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            MessageCount = null,
            PublicID = null,
            Status = null,
            Subject = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.MessageCount);
        Assert.False(model.RawData.ContainsKey("messageCount"));
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
        var model = new Ticket
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            MessageCount = null,
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
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageCount = 0,
            PublicID = "publicId",
            Status = "status",
            Subject = "subject",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Ticket copied = new(model);

        Assert.Equal(model, copied);
    }
}
