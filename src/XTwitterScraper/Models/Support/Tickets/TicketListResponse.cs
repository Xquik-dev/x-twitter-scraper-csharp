using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketListResponse, TicketListResponseFromRaw>))]
public sealed record class TicketListResponse : JsonModel
{
    public IReadOnlyList<Ticket>? Tickets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Ticket>>("tickets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Ticket>?>(
                "tickets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tickets ?? [])
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
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public long? MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("messageCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messageCount", value);
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

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subject", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.MessageCount;
        _ = this.PublicID;
        _ = this.Status;
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
