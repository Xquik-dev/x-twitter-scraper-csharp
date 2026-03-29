using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Monitors;

[JsonConverter(typeof(JsonModelConverter<MonitorCreateResponse, MonitorCreateResponseFromRaw>))]
public sealed record class MonitorCreateResponse : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required IReadOnlyList<ApiEnum<string, MonitorCreateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorCreateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, MonitorCreateResponseEventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required string XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUserId");
        }
        init { this._rawData.Set("xUserId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.Username;
        _ = this.XUserID;
    }

    public MonitorCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorCreateResponse(MonitorCreateResponse monitorCreateResponse)
        : base(monitorCreateResponse) { }
#pragma warning restore CS8618

    public MonitorCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorCreateResponseFromRaw.FromRawUnchecked"/>
    public static MonitorCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorCreateResponseFromRaw : IFromRawJson<MonitorCreateResponse>
{
    /// <inheritdoc/>
    public MonitorCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorCreateResponseEventTypeConverter))]
public enum MonitorCreateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class MonitorCreateResponseEventTypeConverter : JsonConverter<MonitorCreateResponseEventType>
{
    public override MonitorCreateResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorCreateResponseEventType.TweetNew,
            "tweet.reply" => MonitorCreateResponseEventType.TweetReply,
            "tweet.retweet" => MonitorCreateResponseEventType.TweetRetweet,
            "tweet.quote" => MonitorCreateResponseEventType.TweetQuote,
            "follower.gained" => MonitorCreateResponseEventType.FollowerGained,
            "follower.lost" => MonitorCreateResponseEventType.FollowerLost,
            _ => (MonitorCreateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorCreateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorCreateResponseEventType.TweetNew => "tweet.new",
                MonitorCreateResponseEventType.TweetReply => "tweet.reply",
                MonitorCreateResponseEventType.TweetRetweet => "tweet.retweet",
                MonitorCreateResponseEventType.TweetQuote => "tweet.quote",
                MonitorCreateResponseEventType.FollowerGained => "follower.gained",
                MonitorCreateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
