using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketRetrieveResponse, TicketRetrieveResponseFromRaw>))]
public sealed record class TicketRetrieveResponse : JsonModel
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

    public IReadOnlyList<Message>? Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Message>>("messages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Message>?>(
                "messages",
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
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        _ = this.PublicID;
        _ = this.Status;
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
    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

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

    public string? Sender
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sender");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sender", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.CreatedAt;
        _ = this.Sender;
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
