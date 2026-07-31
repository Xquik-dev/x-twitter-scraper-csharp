using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
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
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    MessageCount = 2,
                    PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketStatus.Open,
                    Subject = "Cannot connect X account",
                    UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
                },
            ],
        };

        List<Ticket> expectedTickets =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                MessageCount = 2,
                PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                Status = TicketStatus.Open,
                Subject = "Cannot connect X account",
                UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
            },
        ];

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
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    MessageCount = 2,
                    PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketStatus.Open,
                    Subject = "Cannot connect X account",
                    UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
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
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    MessageCount = 2,
                    PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketStatus.Open,
                    Subject = "Cannot connect X account",
                    UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
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
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                MessageCount = 2,
                PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                Status = TicketStatus.Open,
                Subject = "Cannot connect X account",
                UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
            },
        ];

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
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    MessageCount = 2,
                    PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketStatus.Open,
                    Subject = "Cannot connect X account",
                    UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
                },
            ],
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
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    MessageCount = 2,
                    PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketStatus.Open,
                    Subject = "Cannot connect X account",
                    UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
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
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            MessageCount = 2,
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        long expectedMessageCount = 2;
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketStatus> expectedStatus = TicketStatus.Open;
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

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
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            MessageCount = 2,
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
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
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            MessageCount = 2,
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ticket>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        long expectedMessageCount = 2;
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketStatus> expectedStatus = TicketStatus.Open;
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

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
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            MessageCount = 2,
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Ticket
        {
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            MessageCount = 2,
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        Ticket copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TicketStatusTest : TestBase
{
    [Theory]
    [InlineData(TicketStatus.Open)]
    [InlineData(TicketStatus.InProgress)]
    [InlineData(TicketStatus.Resolved)]
    [InlineData(TicketStatus.Closed)]
    public void Validation_Works(TicketStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TicketStatus.Open)]
    [InlineData(TicketStatus.InProgress)]
    [InlineData(TicketStatus.Resolved)]
    [InlineData(TicketStatus.Closed)]
    public void SerializationRoundtrip_Works(TicketStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TicketStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TicketStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
