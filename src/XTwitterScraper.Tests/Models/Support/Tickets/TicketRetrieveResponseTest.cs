using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
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
                    Attachments =
                    [
                        new()
                        {
                            ContentType = ContentType.ImageJpeg,
                            Filename = "screen.png",
                            Kind = Kind.Image,
                            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                            SizeBytes = 204800,
                            Status = MessageAttachmentStatus.Ready,
                            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        },
                    ],
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = Sender.User,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketRetrieveResponseStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<Message> expectedMessages =
        [
            new()
            {
                Attachments =
                [
                    new()
                    {
                        ContentType = ContentType.ImageJpeg,
                        Filename = "screen.png",
                        Kind = Kind.Image,
                        PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        SizeBytes = 204800,
                        Status = MessageAttachmentStatus.Ready,
                        Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    },
                ],
                Body = "I am unable to connect my X account.",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Sender = Sender.User,
            },
        ];
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketRetrieveResponseStatus> expectedStatus =
            TicketRetrieveResponseStatus.Open;
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
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
                    Attachments =
                    [
                        new()
                        {
                            ContentType = ContentType.ImageJpeg,
                            Filename = "screen.png",
                            Kind = Kind.Image,
                            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                            SizeBytes = 204800,
                            Status = MessageAttachmentStatus.Ready,
                            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        },
                    ],
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = Sender.User,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketRetrieveResponseStatus.Open,
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
                    Attachments =
                    [
                        new()
                        {
                            ContentType = ContentType.ImageJpeg,
                            Filename = "screen.png",
                            Kind = Kind.Image,
                            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                            SizeBytes = 204800,
                            Status = MessageAttachmentStatus.Ready,
                            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        },
                    ],
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = Sender.User,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketRetrieveResponseStatus.Open,
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
                Attachments =
                [
                    new()
                    {
                        ContentType = ContentType.ImageJpeg,
                        Filename = "screen.png",
                        Kind = Kind.Image,
                        PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        SizeBytes = 204800,
                        Status = MessageAttachmentStatus.Ready,
                        Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    },
                ],
                Body = "I am unable to connect my X account.",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Sender = Sender.User,
            },
        ];
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketRetrieveResponseStatus> expectedStatus =
            TicketRetrieveResponseStatus.Open;
        string expectedSubject = "Cannot connect X account";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
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
                    Attachments =
                    [
                        new()
                        {
                            ContentType = ContentType.ImageJpeg,
                            Filename = "screen.png",
                            Kind = Kind.Image,
                            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                            SizeBytes = 204800,
                            Status = MessageAttachmentStatus.Ready,
                            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        },
                    ],
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = Sender.User,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketRetrieveResponseStatus.Open,
            Subject = "Cannot connect X account",
            UpdatedAt = DateTimeOffset.Parse("2025-01-16T09:30:00Z"),
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
                    Attachments =
                    [
                        new()
                        {
                            ContentType = ContentType.ImageJpeg,
                            Filename = "screen.png",
                            Kind = Kind.Image,
                            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                            SizeBytes = 204800,
                            Status = MessageAttachmentStatus.Ready,
                            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                        },
                    ],
                    Body = "I am unable to connect my X account.",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Sender = Sender.User,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketRetrieveResponseStatus.Open,
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
            Attachments =
            [
                new()
                {
                    ContentType = ContentType.ImageJpeg,
                    Filename = "screen.png",
                    Kind = Kind.Image,
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    SizeBytes = 204800,
                    Status = MessageAttachmentStatus.Ready,
                    Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                },
            ],
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = Sender.User,
        };

        List<MessageAttachment> expectedAttachments =
        [
            new()
            {
                ContentType = ContentType.ImageJpeg,
                Filename = "screen.png",
                Kind = Kind.Image,
                PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                SizeBytes = 204800,
                Status = MessageAttachmentStatus.Ready,
                Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
            },
        ];
        string expectedBody = "I am unable to connect my X account.";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, Sender> expectedSender = Sender.User;

        Assert.Equal(expectedAttachments.Count, model.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], model.Attachments[i]);
        }
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSender, model.Sender);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            Attachments =
            [
                new()
                {
                    ContentType = ContentType.ImageJpeg,
                    Filename = "screen.png",
                    Kind = Kind.Image,
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    SizeBytes = 204800,
                    Status = MessageAttachmentStatus.Ready,
                    Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                },
            ],
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = Sender.User,
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
            Attachments =
            [
                new()
                {
                    ContentType = ContentType.ImageJpeg,
                    Filename = "screen.png",
                    Kind = Kind.Image,
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    SizeBytes = 204800,
                    Status = MessageAttachmentStatus.Ready,
                    Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                },
            ],
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = Sender.User,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MessageAttachment> expectedAttachments =
        [
            new()
            {
                ContentType = ContentType.ImageJpeg,
                Filename = "screen.png",
                Kind = Kind.Image,
                PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                SizeBytes = 204800,
                Status = MessageAttachmentStatus.Ready,
                Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
            },
        ];
        string expectedBody = "I am unable to connect my X account.";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, Sender> expectedSender = Sender.User;

        Assert.Equal(expectedAttachments.Count, deserialized.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], deserialized.Attachments[i]);
        }
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSender, deserialized.Sender);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            Attachments =
            [
                new()
                {
                    ContentType = ContentType.ImageJpeg,
                    Filename = "screen.png",
                    Kind = Kind.Image,
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    SizeBytes = 204800,
                    Status = MessageAttachmentStatus.Ready,
                    Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                },
            ],
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = Sender.User,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            Attachments =
            [
                new()
                {
                    ContentType = ContentType.ImageJpeg,
                    Filename = "screen.png",
                    Kind = Kind.Image,
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    SizeBytes = 204800,
                    Status = MessageAttachmentStatus.Ready,
                    Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
                },
            ],
            Body = "I am unable to connect my X account.",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Sender = Sender.User,
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageAttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageAttachment
        {
            ContentType = ContentType.ImageJpeg,
            Filename = "screen.png",
            Kind = Kind.Image,
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            SizeBytes = 204800,
            Status = MessageAttachmentStatus.Ready,
            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        ApiEnum<string, ContentType> expectedContentType = ContentType.ImageJpeg;
        string expectedFilename = "screen.png";
        ApiEnum<string, Kind> expectedKind = Kind.Image;
        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        long expectedSizeBytes = 204800;
        ApiEnum<string, MessageAttachmentStatus> expectedStatus = MessageAttachmentStatus.Ready;
        string expectedUrl = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6";

        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageAttachment
        {
            ContentType = ContentType.ImageJpeg,
            Filename = "screen.png",
            Kind = Kind.Image,
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            SizeBytes = 204800,
            Status = MessageAttachmentStatus.Ready,
            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageAttachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageAttachment
        {
            ContentType = ContentType.ImageJpeg,
            Filename = "screen.png",
            Kind = Kind.Image,
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            SizeBytes = 204800,
            Status = MessageAttachmentStatus.Ready,
            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageAttachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ContentType> expectedContentType = ContentType.ImageJpeg;
        string expectedFilename = "screen.png";
        ApiEnum<string, Kind> expectedKind = Kind.Image;
        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        long expectedSizeBytes = 204800;
        ApiEnum<string, MessageAttachmentStatus> expectedStatus = MessageAttachmentStatus.Ready;
        string expectedUrl = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6";

        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageAttachment
        {
            ContentType = ContentType.ImageJpeg,
            Filename = "screen.png",
            Kind = Kind.Image,
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            SizeBytes = 204800,
            Status = MessageAttachmentStatus.Ready,
            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageAttachment
        {
            ContentType = ContentType.ImageJpeg,
            Filename = "screen.png",
            Kind = Kind.Image,
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            SizeBytes = 204800,
            Status = MessageAttachmentStatus.Ready,
            Url = "/api/v1/support/attachments/att_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        MessageAttachment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTypeTest : TestBase
{
    [Theory]
    [InlineData(ContentType.ImageJpeg)]
    [InlineData(ContentType.ImagePng)]
    [InlineData(ContentType.ImageGif)]
    [InlineData(ContentType.ImageWebp)]
    [InlineData(ContentType.VideoMp4)]
    [InlineData(ContentType.VideoQuicktime)]
    [InlineData(ContentType.VideoWebm)]
    public void Validation_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentType.ImageJpeg)]
    [InlineData(ContentType.ImagePng)]
    [InlineData(ContentType.ImageGif)]
    [InlineData(ContentType.ImageWebp)]
    [InlineData(ContentType.VideoMp4)]
    [InlineData(ContentType.VideoQuicktime)]
    [InlineData(ContentType.VideoWebm)]
    public void SerializationRoundtrip_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Kind.Image)]
    [InlineData(Kind.Video)]
    public void Validation_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Kind.Image)]
    [InlineData(Kind.Video)]
    public void SerializationRoundtrip_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MessageAttachmentStatusTest : TestBase
{
    [Theory]
    [InlineData(MessageAttachmentStatus.Pending)]
    [InlineData(MessageAttachmentStatus.Ready)]
    [InlineData(MessageAttachmentStatus.Failed)]
    public void Validation_Works(MessageAttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageAttachmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageAttachmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageAttachmentStatus.Pending)]
    [InlineData(MessageAttachmentStatus.Ready)]
    [InlineData(MessageAttachmentStatus.Failed)]
    public void SerializationRoundtrip_Works(MessageAttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageAttachmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageAttachmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageAttachmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageAttachmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SenderTest : TestBase
{
    [Theory]
    [InlineData(Sender.User)]
    [InlineData(Sender.Support)]
    [InlineData(Sender.System)]
    public void Validation_Works(Sender rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sender> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sender>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sender.User)]
    [InlineData(Sender.Support)]
    [InlineData(Sender.System)]
    public void SerializationRoundtrip_Works(Sender rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sender> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sender>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sender>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sender>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TicketRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(TicketRetrieveResponseStatus.Open)]
    [InlineData(TicketRetrieveResponseStatus.InProgress)]
    [InlineData(TicketRetrieveResponseStatus.Resolved)]
    [InlineData(TicketRetrieveResponseStatus.Closed)]
    public void Validation_Works(TicketRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketRetrieveResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TicketRetrieveResponseStatus.Open)]
    [InlineData(TicketRetrieveResponseStatus.InProgress)]
    [InlineData(TicketRetrieveResponseStatus.Resolved)]
    [InlineData(TicketRetrieveResponseStatus.Closed)]
    public void SerializationRoundtrip_Works(TicketRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketRetrieveResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
