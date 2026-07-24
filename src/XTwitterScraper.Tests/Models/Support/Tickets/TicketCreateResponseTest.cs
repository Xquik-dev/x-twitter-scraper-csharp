// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketCreateResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = AttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        List<Attachment> expectedAttachments =
        [
            new() { PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6", Status = AttachmentStatus.Pending },
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
        var model = new TicketCreateResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = AttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketCreateResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = AttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Attachment> expectedAttachments =
        [
            new() { PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6", Status = AttachmentStatus.Pending },
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
        var model = new TicketCreateResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = AttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketCreateResponse
        {
            Attachments =
            [
                new()
                {
                    PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
                    Status = AttachmentStatus.Pending,
                },
            ],
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
        };

        TicketCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = AttachmentStatus.Pending,
        };

        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, AttachmentStatus> expectedStatus = AttachmentStatus.Pending;

        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = AttachmentStatus.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = AttachmentStatus.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, AttachmentStatus> expectedStatus = AttachmentStatus.Pending;

        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = AttachmentStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attachment
        {
            PublicID = "att_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = AttachmentStatus.Pending,
        };

        Attachment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttachmentStatusTest : TestBase
{
    [Theory]
    [InlineData(AttachmentStatus.Pending)]
    [InlineData(AttachmentStatus.Ready)]
    [InlineData(AttachmentStatus.Failed)]
    public void Validation_Works(AttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AttachmentStatus.Pending)]
    [InlineData(AttachmentStatus.Ready)]
    [InlineData(AttachmentStatus.Failed)]
    public void SerializationRoundtrip_Works(AttachmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
