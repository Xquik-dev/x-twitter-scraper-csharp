using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventListResponse, EventListResponseFromRaw>))]
public sealed record class EventListResponse : JsonModel
{
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public EventListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventListResponse(EventListResponse eventListResponse)
        : base(eventListResponse) { }
#pragma warning restore CS8618

    public EventListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventListResponseFromRaw.FromRawUnchecked"/>
    public static EventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventListResponseFromRaw : IFromRawJson<EventListResponse>
{
    /// <inheritdoc/>
    public EventListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
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

    public required IReadOnlyDictionary<string, JsonElement> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "data",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string MonitorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("monitorId");
        }
        init { this._rawData.Set("monitorId", value); }
    }

    public required System::DateTimeOffset OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("occurredAt");
        }
        init { this._rawData.Set("occurredAt", value); }
    }

    public required ApiEnum<string, TypeModel> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TypeModel>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Data;
        _ = this.MonitorID;
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.Username;
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => TypeModel.TweetNew,
            "tweet.reply" => TypeModel.TweetReply,
            "tweet.retweet" => TypeModel.TweetRetweet,
            "tweet.quote" => TypeModel.TweetQuote,
            "follower.gained" => TypeModel.FollowerGained,
            "follower.lost" => TypeModel.FollowerLost,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.TweetNew => "tweet.new",
                TypeModel.TweetReply => "tweet.reply",
                TypeModel.TweetRetweet => "tweet.retweet",
                TypeModel.TweetQuote => "tweet.quote",
                TypeModel.FollowerGained => "follower.gained",
                TypeModel.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
