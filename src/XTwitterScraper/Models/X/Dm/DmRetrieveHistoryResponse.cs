using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Dm;

[JsonConverter(
    typeof(JsonModelConverter<DmRetrieveHistoryResponse, DmRetrieveHistoryResponseFromRaw>)
)]
public sealed record class DmRetrieveHistoryResponse : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
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

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public DmRetrieveHistoryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DmRetrieveHistoryResponse(DmRetrieveHistoryResponse dmRetrieveHistoryResponse)
        : base(dmRetrieveHistoryResponse) { }
#pragma warning restore CS8618

    public DmRetrieveHistoryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DmRetrieveHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DmRetrieveHistoryResponseFromRaw.FromRawUnchecked"/>
    public static DmRetrieveHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DmRetrieveHistoryResponseFromRaw : IFromRawJson<DmRetrieveHistoryResponse>
{
    /// <inheritdoc/>
    public DmRetrieveHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DmRetrieveHistoryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
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

    public string? ReceiverID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receiverId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("receiverId", value);
        }
    }

    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("senderId", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.ReceiverID;
        _ = this.SenderID;
        _ = this.Text;
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

    [SetsRequiredMembers]
    public Message(string id)
        : this()
    {
        this.ID = id;
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}
