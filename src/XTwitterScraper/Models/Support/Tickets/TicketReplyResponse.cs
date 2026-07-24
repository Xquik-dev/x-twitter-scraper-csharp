// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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

[JsonConverter(typeof(JsonModelConverter<TicketReplyResponse, TicketReplyResponseFromRaw>))]
public sealed record class TicketReplyResponse : JsonModel
{
    public required IReadOnlyList<TicketReplyResponseAttachment> Attachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TicketReplyResponseAttachment>>(
                "attachments"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TicketReplyResponseAttachment>>(
                "attachments",
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attachments)
        {
            item.Validate();
        }
        _ = this.PublicID;
    }

    public TicketReplyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketReplyResponse(TicketReplyResponse ticketReplyResponse)
        : base(ticketReplyResponse) { }
#pragma warning restore CS8618

    public TicketReplyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketReplyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketReplyResponseFromRaw.FromRawUnchecked"/>
    public static TicketReplyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketReplyResponseFromRaw : IFromRawJson<TicketReplyResponse>
{
    /// <inheritdoc/>
    public TicketReplyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TicketReplyResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Attachment identifier and initial processing state.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TicketReplyResponseAttachment, TicketReplyResponseAttachmentFromRaw>)
)]
public sealed record class TicketReplyResponseAttachment : JsonModel
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

    public required ApiEnum<string, TicketReplyResponseAttachmentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TicketReplyResponseAttachmentStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicID;
        this.Status.Validate();
    }

    public TicketReplyResponseAttachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketReplyResponseAttachment(
        TicketReplyResponseAttachment ticketReplyResponseAttachment
    )
        : base(ticketReplyResponseAttachment) { }
#pragma warning restore CS8618

    public TicketReplyResponseAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketReplyResponseAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketReplyResponseAttachmentFromRaw.FromRawUnchecked"/>
    public static TicketReplyResponseAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketReplyResponseAttachmentFromRaw : IFromRawJson<TicketReplyResponseAttachment>
{
    /// <inheritdoc/>
    public TicketReplyResponseAttachment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TicketReplyResponseAttachment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TicketReplyResponseAttachmentStatusConverter))]
public enum TicketReplyResponseAttachmentStatus
{
    Pending,
    Ready,
    Failed,
}

sealed class TicketReplyResponseAttachmentStatusConverter
    : JsonConverter<TicketReplyResponseAttachmentStatus>
{
    public override TicketReplyResponseAttachmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => TicketReplyResponseAttachmentStatus.Pending,
            "ready" => TicketReplyResponseAttachmentStatus.Ready,
            "failed" => TicketReplyResponseAttachmentStatus.Failed,
            _ => (TicketReplyResponseAttachmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TicketReplyResponseAttachmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TicketReplyResponseAttachmentStatus.Pending => "pending",
                TicketReplyResponseAttachmentStatus.Ready => "ready",
                TicketReplyResponseAttachmentStatus.Failed => "failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
