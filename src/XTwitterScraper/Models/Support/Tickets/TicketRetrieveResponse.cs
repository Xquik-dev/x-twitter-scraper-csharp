using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketRetrieveResponse, TicketRetrieveResponseFromRaw>))]
public sealed record class TicketRetrieveResponse : JsonModel
{
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required IReadOnlyList<Message> Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Message>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("publicId");
        }
        init { this._rawData.Set("publicId", value); }
    }

    public required ApiEnum<string, TicketRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TicketRetrieveResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
        _ = this.PublicID;
        this.Status.Validate();
        _ = this.Subject;
        _ = this.UpdatedAt;
    }

    public TicketRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketRetrieveResponse(TicketRetrieveResponse ticketRetrieveResponse)
        : base(ticketRetrieveResponse) { }
#pragma warning restore CS8618

    public TicketRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TicketRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketRetrieveResponseFromRaw : IFromRawJson<TicketRetrieveResponse>
{
    /// <inheritdoc/>
    public TicketRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TicketRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public required IReadOnlyList<MessageAttachment> Attachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageAttachment>>("attachments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageAttachment>>(
                "attachments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required ApiEnum<string, Sender> Sender
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Sender>>("sender");
        }
        init { this._rawData.Set("sender", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attachments)
        {
            item.Validate();
        }
        _ = this.Body;
        _ = this.CreatedAt;
        this.Sender.Validate();
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// Downloadable image or video attached to a support message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageAttachment, MessageAttachmentFromRaw>))]
public sealed record class MessageAttachment : JsonModel
{
    /// <summary>
    /// Validated media type.
    /// </summary>
    public required ApiEnum<string, ContentType> ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContentType>>("contentType");
        }
        init { this._rawData.Set("contentType", value); }
    }

    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// Attachment media class.
    /// </summary>
    public required ApiEnum<string, Kind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Kind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    public required string PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("publicId");
        }
        init { this._rawData.Set("publicId", value); }
    }

    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sizeBytes");
        }
        init { this._rawData.Set("sizeBytes", value); }
    }

    /// <summary>
    /// Storage processing state.
    /// </summary>
    public required ApiEnum<string, MessageAttachmentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageAttachmentStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentType.Validate();
        _ = this.Filename;
        this.Kind.Validate();
        _ = this.PublicID;
        _ = this.SizeBytes;
        this.Status.Validate();
        _ = this.Url;
    }

    public MessageAttachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageAttachment(MessageAttachment messageAttachment)
        : base(messageAttachment) { }
#pragma warning restore CS8618

    public MessageAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageAttachmentFromRaw.FromRawUnchecked"/>
    public static MessageAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageAttachmentFromRaw : IFromRawJson<MessageAttachment>
{
    /// <inheritdoc/>
    public MessageAttachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageAttachment.FromRawUnchecked(rawData);
}

/// <summary>
/// Validated media type.
/// </summary>
[JsonConverter(typeof(ContentTypeConverter))]
public enum ContentType
{
    ImageJpeg,
    ImagePng,
    ImageGif,
    ImageWebp,
    VideoMp4,
    VideoQuicktime,
    VideoWebm,
}

sealed class ContentTypeConverter : JsonConverter<ContentType>
{
    public override ContentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image/jpeg" => ContentType.ImageJpeg,
            "image/png" => ContentType.ImagePng,
            "image/gif" => ContentType.ImageGif,
            "image/webp" => ContentType.ImageWebp,
            "video/mp4" => ContentType.VideoMp4,
            "video/quicktime" => ContentType.VideoQuicktime,
            "video/webm" => ContentType.VideoWebm,
            _ => (ContentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContentType.ImageJpeg => "image/jpeg",
                ContentType.ImagePng => "image/png",
                ContentType.ImageGif => "image/gif",
                ContentType.ImageWebp => "image/webp",
                ContentType.VideoMp4 => "video/mp4",
                ContentType.VideoQuicktime => "video/quicktime",
                ContentType.VideoWebm => "video/webm",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Attachment media class.
/// </summary>
[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    Image,
    Video,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image" => Kind.Image,
            "video" => Kind.Video,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.Image => "image",
                Kind.Video => "video",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Storage processing state.
/// </summary>
[JsonConverter(typeof(MessageAttachmentStatusConverter))]
public enum MessageAttachmentStatus
{
    Pending,
    Ready,
    Failed,
}

sealed class MessageAttachmentStatusConverter : JsonConverter<MessageAttachmentStatus>
{
    public override MessageAttachmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => MessageAttachmentStatus.Pending,
            "ready" => MessageAttachmentStatus.Ready,
            "failed" => MessageAttachmentStatus.Failed,
            _ => (MessageAttachmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageAttachmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageAttachmentStatus.Pending => "pending",
                MessageAttachmentStatus.Ready => "ready",
                MessageAttachmentStatus.Failed => "failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SenderConverter))]
public enum Sender
{
    User,
    Support,
    System,
}

sealed class SenderConverter : JsonConverter<Sender>
{
    public override Sender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Sender.User,
            "support" => Sender.Support,
            "system" => Sender.System,
            _ => (Sender)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sender value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sender.User => "user",
                Sender.Support => "support",
                Sender.System => "system",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TicketRetrieveResponseStatusConverter))]
public enum TicketRetrieveResponseStatus
{
    Open,
    InProgress,
    Resolved,
    Closed,
}

sealed class TicketRetrieveResponseStatusConverter : JsonConverter<TicketRetrieveResponseStatus>
{
    public override TicketRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => TicketRetrieveResponseStatus.Open,
            "in_progress" => TicketRetrieveResponseStatus.InProgress,
            "resolved" => TicketRetrieveResponseStatus.Resolved,
            "closed" => TicketRetrieveResponseStatus.Closed,
            _ => (TicketRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TicketRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TicketRetrieveResponseStatus.Open => "open",
                TicketRetrieveResponseStatus.InProgress => "in_progress",
                TicketRetrieveResponseStatus.Resolved => "resolved",
                TicketRetrieveResponseStatus.Closed => "closed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
