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

[JsonConverter(typeof(JsonModelConverter<MonitorRetrieveResponse, MonitorRetrieveResponseFromRaw>))]
public sealed record class MonitorRetrieveResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, MonitorRetrieveResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorRetrieveResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, MonitorRetrieveResponseEventType>>>(
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

    public MonitorRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorRetrieveResponse(MonitorRetrieveResponse monitorRetrieveResponse)
        : base(monitorRetrieveResponse) { }
#pragma warning restore CS8618

    public MonitorRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MonitorRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorRetrieveResponseFromRaw : IFromRawJson<MonitorRetrieveResponse>
{
    /// <inheritdoc/>
    public MonitorRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorRetrieveResponseEventTypeConverter))]
public enum MonitorRetrieveResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class MonitorRetrieveResponseEventTypeConverter
    : JsonConverter<MonitorRetrieveResponseEventType>
{
    public override MonitorRetrieveResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorRetrieveResponseEventType.TweetNew,
            "tweet.reply" => MonitorRetrieveResponseEventType.TweetReply,
            "tweet.retweet" => MonitorRetrieveResponseEventType.TweetRetweet,
            "tweet.quote" => MonitorRetrieveResponseEventType.TweetQuote,
            "follower.gained" => MonitorRetrieveResponseEventType.FollowerGained,
            "follower.lost" => MonitorRetrieveResponseEventType.FollowerLost,
            _ => (MonitorRetrieveResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorRetrieveResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorRetrieveResponseEventType.TweetNew => "tweet.new",
                MonitorRetrieveResponseEventType.TweetReply => "tweet.reply",
                MonitorRetrieveResponseEventType.TweetRetweet => "tweet.retweet",
                MonitorRetrieveResponseEventType.TweetQuote => "tweet.quote",
                MonitorRetrieveResponseEventType.FollowerGained => "follower.gained",
                MonitorRetrieveResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
