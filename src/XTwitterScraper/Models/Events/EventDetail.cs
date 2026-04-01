using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventDetail, EventDetailFromRaw>))]
public sealed record class EventDetail : JsonModel
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

    public required ApiEnum<string, EventDetailType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventDetailType>>("type");
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

    public string? XEventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xEventId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("xEventId", value);
        }
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
        _ = this.XEventID;
    }

    public EventDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventDetail(EventDetail eventDetail)
        : base(eventDetail) { }
#pragma warning restore CS8618

    public EventDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventDetailFromRaw.FromRawUnchecked"/>
    public static EventDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventDetailFromRaw : IFromRawJson<EventDetail>
{
    /// <inheritdoc/>
    public EventDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventDetail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventDetailTypeConverter))]
public enum EventDetailType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class EventDetailTypeConverter : JsonConverter<EventDetailType>
{
    public override EventDetailType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => EventDetailType.TweetNew,
            "tweet.reply" => EventDetailType.TweetReply,
            "tweet.retweet" => EventDetailType.TweetRetweet,
            "tweet.quote" => EventDetailType.TweetQuote,
            "follower.gained" => EventDetailType.FollowerGained,
            "follower.lost" => EventDetailType.FollowerLost,
            _ => (EventDetailType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventDetailType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventDetailType.TweetNew => "tweet.new",
                EventDetailType.TweetReply => "tweet.reply",
                EventDetailType.TweetRetweet => "tweet.retweet",
                EventDetailType.TweetQuote => "tweet.quote",
                EventDetailType.FollowerGained => "follower.gained",
                EventDetailType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
