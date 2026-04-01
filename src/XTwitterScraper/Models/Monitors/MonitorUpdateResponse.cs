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

[JsonConverter(typeof(JsonModelConverter<MonitorUpdateResponse, MonitorUpdateResponseFromRaw>))]
public sealed record class MonitorUpdateResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, MonitorUpdateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorUpdateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, MonitorUpdateResponseEventType>>>(
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

    public MonitorUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorUpdateResponse(MonitorUpdateResponse monitorUpdateResponse)
        : base(monitorUpdateResponse) { }
#pragma warning restore CS8618

    public MonitorUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MonitorUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorUpdateResponseFromRaw : IFromRawJson<MonitorUpdateResponse>
{
    /// <inheritdoc/>
    public MonitorUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorUpdateResponseEventTypeConverter))]
public enum MonitorUpdateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class MonitorUpdateResponseEventTypeConverter : JsonConverter<MonitorUpdateResponseEventType>
{
    public override MonitorUpdateResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorUpdateResponseEventType.TweetNew,
            "tweet.reply" => MonitorUpdateResponseEventType.TweetReply,
            "tweet.retweet" => MonitorUpdateResponseEventType.TweetRetweet,
            "tweet.quote" => MonitorUpdateResponseEventType.TweetQuote,
            "follower.gained" => MonitorUpdateResponseEventType.FollowerGained,
            "follower.lost" => MonitorUpdateResponseEventType.FollowerLost,
            _ => (MonitorUpdateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorUpdateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorUpdateResponseEventType.TweetNew => "tweet.new",
                MonitorUpdateResponseEventType.TweetReply => "tweet.reply",
                MonitorUpdateResponseEventType.TweetRetweet => "tweet.retweet",
                MonitorUpdateResponseEventType.TweetQuote => "tweet.quote",
                MonitorUpdateResponseEventType.FollowerGained => "follower.gained",
                MonitorUpdateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
