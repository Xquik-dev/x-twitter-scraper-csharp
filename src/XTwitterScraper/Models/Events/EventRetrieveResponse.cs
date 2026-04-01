using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventRetrieveResponse, EventRetrieveResponseFromRaw>))]
public sealed record class EventRetrieveResponse : JsonModel
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

    public required ApiEnum<string, EventRetrieveResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventRetrieveResponseType>>(
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

    public EventRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventRetrieveResponse(EventRetrieveResponse eventRetrieveResponse)
        : base(eventRetrieveResponse) { }
#pragma warning restore CS8618

    public EventRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EventRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventRetrieveResponseFromRaw : IFromRawJson<EventRetrieveResponse>
{
    /// <inheritdoc/>
    public EventRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventRetrieveResponseTypeConverter))]
public enum EventRetrieveResponseType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class EventRetrieveResponseTypeConverter : JsonConverter<EventRetrieveResponseType>
{
    public override EventRetrieveResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => EventRetrieveResponseType.TweetNew,
            "tweet.reply" => EventRetrieveResponseType.TweetReply,
            "tweet.retweet" => EventRetrieveResponseType.TweetRetweet,
            "tweet.quote" => EventRetrieveResponseType.TweetQuote,
            "follower.gained" => EventRetrieveResponseType.FollowerGained,
            "follower.lost" => EventRetrieveResponseType.FollowerLost,
            _ => (EventRetrieveResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventRetrieveResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventRetrieveResponseType.TweetNew => "tweet.new",
                EventRetrieveResponseType.TweetReply => "tweet.reply",
                EventRetrieveResponseType.TweetRetweet => "tweet.retweet",
                EventRetrieveResponseType.TweetQuote => "tweet.quote",
                EventRetrieveResponseType.FollowerGained => "follower.gained",
                EventRetrieveResponseType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
