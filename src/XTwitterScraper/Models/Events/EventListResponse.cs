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
    public required IReadOnlyList<EventListResponseEvent> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EventListResponseEvent>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EventListResponseEvent>>(
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

[JsonConverter(typeof(JsonModelConverter<EventListResponseEvent, EventListResponseEventFromRaw>))]
public sealed record class EventListResponseEvent : JsonModel
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

    public required ApiEnum<string, EventListResponseEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventListResponseEventType>>(
                "type"
            );
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

    public EventListResponseEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventListResponseEvent(EventListResponseEvent eventListResponseEvent)
        : base(eventListResponseEvent) { }
#pragma warning restore CS8618

    public EventListResponseEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventListResponseEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventListResponseEventFromRaw.FromRawUnchecked"/>
    public static EventListResponseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventListResponseEventFromRaw : IFromRawJson<EventListResponseEvent>
{
    /// <inheritdoc/>
    public EventListResponseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventListResponseEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventListResponseEventTypeConverter))]
public enum EventListResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class EventListResponseEventTypeConverter : JsonConverter<EventListResponseEventType>
{
    public override EventListResponseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => EventListResponseEventType.TweetNew,
            "tweet.reply" => EventListResponseEventType.TweetReply,
            "tweet.retweet" => EventListResponseEventType.TweetRetweet,
            "tweet.quote" => EventListResponseEventType.TweetQuote,
            "follower.gained" => EventListResponseEventType.FollowerGained,
            "follower.lost" => EventListResponseEventType.FollowerLost,
            _ => (EventListResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventListResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventListResponseEventType.TweetNew => "tweet.new",
                EventListResponseEventType.TweetReply => "tweet.reply",
                EventListResponseEventType.TweetRetweet => "tweet.retweet",
                EventListResponseEventType.TweetQuote => "tweet.quote",
                EventListResponseEventType.FollowerGained => "follower.gained",
                EventListResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
