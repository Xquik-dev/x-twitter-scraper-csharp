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

[JsonConverter(typeof(JsonModelConverter<TicketCreateResponse, TicketCreateResponseFromRaw>))]
public sealed record class TicketCreateResponse : JsonModel
{
    public IReadOnlyList<Attachment>? Attachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Attachment>>("attachments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Attachment>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publicId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("publicId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attachments ?? [])
        {
            item.Validate();
        }
        _ = this.PublicID;
    }

    public TicketCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketCreateResponse(TicketCreateResponse ticketCreateResponse)
        : base(ticketCreateResponse) { }
#pragma warning restore CS8618

    public TicketCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketCreateResponseFromRaw.FromRawUnchecked"/>
    public static TicketCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketCreateResponseFromRaw : IFromRawJson<TicketCreateResponse>
{
    /// <inheritdoc/>
    public TicketCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TicketCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attachment, AttachmentFromRaw>))]
public sealed record class Attachment : JsonModel
{
    public required string PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("publicId");
        }
        init { this._rawData.Set("publicId", value); }
    }

    public required ApiEnum<string, AttachmentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AttachmentStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicID;
        this.Status.Validate();
    }

    public Attachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attachment(Attachment attachment)
        : base(attachment) { }
#pragma warning restore CS8618

    public Attachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentFromRaw.FromRawUnchecked"/>
    public static Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachmentFromRaw : IFromRawJson<Attachment>
{
    /// <inheritdoc/>
    public Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attachment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AttachmentStatusConverter))]
public enum AttachmentStatus
{
    Pending,
    Ready,
    Failed,
}

sealed class AttachmentStatusConverter : JsonConverter<AttachmentStatus>
{
    public override AttachmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => AttachmentStatus.Pending,
            "ready" => AttachmentStatus.Ready,
            "failed" => AttachmentStatus.Failed,
            _ => (AttachmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttachmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AttachmentStatus.Pending => "pending",
                AttachmentStatus.Ready => "ready",
                AttachmentStatus.Failed => "failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
