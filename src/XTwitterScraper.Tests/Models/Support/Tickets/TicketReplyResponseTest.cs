// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketReplyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketReplyResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketReplyResponseAttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        List<TicketReplyResponseAttachment> expectedAttachments =
        [
            new()
            {
                PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                Status = TicketReplyResponseAttachmentStatus.Pending,
            },
        ];
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";

        Assert.Equal(expectedAttachments.Count, model.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], model.Attachments[i]);
        }
        Assert.Equal(expectedPublicID, model.PublicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketReplyResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketReplyResponseAttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketReplyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketReplyResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketReplyResponseAttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketReplyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TicketReplyResponseAttachment> expectedAttachments =
        [
            new()
            {
                PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                Status = TicketReplyResponseAttachmentStatus.Pending,
            },
        ];
        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";

        Assert.Equal(expectedAttachments.Count, deserialized.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], deserialized.Attachments[i]);
        }
        Assert.Equal(expectedPublicID, deserialized.PublicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketReplyResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketReplyResponseAttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketReplyResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = TicketReplyResponseAttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        TicketReplyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TicketReplyResponseAttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketReplyResponseAttachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketReplyResponseAttachmentStatus.Pending,
        };

        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketReplyResponseAttachmentStatus> expectedStatus =
            TicketReplyResponseAttachmentStatus.Pending;

        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketReplyResponseAttachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketReplyResponseAttachmentStatus.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketReplyResponseAttachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketReplyResponseAttachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketReplyResponseAttachmentStatus.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketReplyResponseAttachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketReplyResponseAttachmentStatus> expectedStatus =
            TicketReplyResponseAttachmentStatus.Pending;

        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketReplyResponseAttachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketReplyResponseAttachmentStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketReplyResponseAttachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketReplyResponseAttachmentStatus.Pending,
        };

        TicketReplyResponseAttachment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TicketReplyResponseAttachmentStatusTest : TestBase
{
    [Theory]
    [InlineData(TicketReplyResponseAttachmentStatus.Pending)]
    [InlineData(TicketReplyResponseAttachmentStatus.Ready)]
    [InlineData(TicketReplyResponseAttachmentStatus.Failed)]
    public void Validation_Works(TicketReplyResponseAttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketReplyResponseAttachmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TicketReplyResponseAttachmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TicketReplyResponseAttachmentStatus.Pending)]
    [InlineData(TicketReplyResponseAttachmentStatus.Ready)]
    [InlineData(TicketReplyResponseAttachmentStatus.Failed)]
    public void SerializationRoundtrip_Works(TicketReplyResponseAttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketReplyResponseAttachmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketReplyResponseAttachmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TicketReplyResponseAttachmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketReplyResponseAttachmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
