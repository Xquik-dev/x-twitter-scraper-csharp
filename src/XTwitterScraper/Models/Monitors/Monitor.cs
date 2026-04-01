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

[JsonConverter(typeof(JsonModelConverter<Monitor, MonitorFromRaw>))]
public sealed record class Monitor : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, MonitorEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, MonitorEventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
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
        _ = this.IsActive;
        _ = this.Username;
        _ = this.XUserID;
    }

    public Monitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Monitor(Monitor monitor)
        : base(monitor) { }
#pragma warning restore CS8618

    public Monitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Monitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorFromRaw.FromRawUnchecked"/>
    public static Monitor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorFromRaw : IFromRawJson<Monitor>
{
    /// <inheritdoc/>
    public Monitor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Monitor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorEventTypeConverter))]
public enum MonitorEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class MonitorEventTypeConverter : JsonConverter<MonitorEventType>
{
    public override MonitorEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorEventType.TweetNew,
            "tweet.reply" => MonitorEventType.TweetReply,
            "tweet.retweet" => MonitorEventType.TweetRetweet,
            "tweet.quote" => MonitorEventType.TweetQuote,
            "follower.gained" => MonitorEventType.FollowerGained,
            "follower.lost" => MonitorEventType.FollowerLost,
            _ => (MonitorEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorEventType.TweetNew => "tweet.new",
                MonitorEventType.TweetReply => "tweet.reply",
                MonitorEventType.TweetRetweet => "tweet.retweet",
                MonitorEventType.TweetQuote => "tweet.quote",
                MonitorEventType.FollowerGained => "follower.gained",
                MonitorEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
