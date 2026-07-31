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

[JsonConverter(typeof(JsonModelConverter<TicketListResponse, TicketListResponseFromRaw>))]
public sealed record class TicketListResponse : JsonModel
{
    public required IReadOnlyList<Ticket> Tickets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Ticket>>("tickets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Ticket>>(
                "tickets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tickets)
        {
            item.Validate();
        }
    }

    public TicketListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketListResponse(TicketListResponse ticketListResponse)
        : base(ticketListResponse) { }
#pragma warning restore CS8618

    public TicketListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketListResponseFromRaw.FromRawUnchecked"/>
    public static TicketListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TicketListResponse(IReadOnlyList<Ticket> tickets)
        : this()
    {
        this.Tickets = tickets;
    }
}

class TicketListResponseFromRaw : IFromRawJson<TicketListResponse>
{
    /// <inheritdoc/>
    public TicketListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TicketListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Ticket, TicketFromRaw>))]
public sealed record class Ticket : JsonModel
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

    public required long MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("messageCount");
        }
        init { this._rawData.Set("messageCount", value); }
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

    public required ApiEnum<string, TicketStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TicketStatus>>("status");
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
        _ = this.MessageCount;
        _ = this.PublicID;
        this.Status.Validate();
        _ = this.Subject;
        _ = this.UpdatedAt;
    }

    public Ticket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ticket(Ticket ticket)
        : base(ticket) { }
#pragma warning restore CS8618

    public Ticket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ticket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketFromRaw.FromRawUnchecked"/>
    public static Ticket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketFromRaw : IFromRawJson<Ticket>
{
    /// <inheritdoc/>
    public Ticket FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ticket.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TicketStatusConverter))]
public enum TicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed,
}

sealed class TicketStatusConverter : JsonConverter<TicketStatus>
{
    public override TicketStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => TicketStatus.Open,
            "in_progress" => TicketStatus.InProgress,
            "resolved" => TicketStatus.Resolved,
            "closed" => TicketStatus.Closed,
            _ => (TicketStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TicketStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TicketStatus.Open => "open",
                TicketStatus.InProgress => "in_progress",
                TicketStatus.Resolved => "resolved",
                TicketStatus.Closed => "closed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
