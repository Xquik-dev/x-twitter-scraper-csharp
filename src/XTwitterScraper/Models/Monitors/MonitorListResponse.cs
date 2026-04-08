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

[JsonConverter(typeof(JsonModelConverter<MonitorListResponse, MonitorListResponseFromRaw>))]
public sealed record class MonitorListResponse : JsonModel
{
    public required IReadOnlyList<MonitorListResponseMonitor> Monitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MonitorListResponseMonitor>>(
                "monitors"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MonitorListResponseMonitor>>(
                "monitors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Monitors)
        {
            item.Validate();
        }
        _ = this.Total;
    }

    public MonitorListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorListResponse(MonitorListResponse monitorListResponse)
        : base(monitorListResponse) { }
#pragma warning restore CS8618

    public MonitorListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorListResponseFromRaw.FromRawUnchecked"/>
    public static MonitorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorListResponseFromRaw : IFromRawJson<MonitorListResponse>
{
    /// <inheritdoc/>
    public MonitorListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MonitorListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Account monitor that tracks activity for a given X user.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MonitorListResponseMonitor, MonitorListResponseMonitorFromRaw>)
)]
public sealed record class MonitorListResponseMonitor : JsonModel
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

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, MonitorListResponseMonitorEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorListResponseMonitorEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, MonitorListResponseMonitorEventType>>>(
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

    public MonitorListResponseMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorListResponseMonitor(MonitorListResponseMonitor monitorListResponseMonitor)
        : base(monitorListResponseMonitor) { }
#pragma warning restore CS8618

    public MonitorListResponseMonitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorListResponseMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorListResponseMonitorFromRaw.FromRawUnchecked"/>
    public static MonitorListResponseMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorListResponseMonitorFromRaw : IFromRawJson<MonitorListResponseMonitor>
{
    /// <inheritdoc/>
    public MonitorListResponseMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorListResponseMonitor.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of monitor event fired when account activity occurs.
/// </summary>
[JsonConverter(typeof(MonitorListResponseMonitorEventTypeConverter))]
public enum MonitorListResponseMonitorEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class MonitorListResponseMonitorEventTypeConverter
    : JsonConverter<MonitorListResponseMonitorEventType>
{
    public override MonitorListResponseMonitorEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorListResponseMonitorEventType.TweetNew,
            "tweet.reply" => MonitorListResponseMonitorEventType.TweetReply,
            "tweet.retweet" => MonitorListResponseMonitorEventType.TweetRetweet,
            "tweet.quote" => MonitorListResponseMonitorEventType.TweetQuote,
            "follower.gained" => MonitorListResponseMonitorEventType.FollowerGained,
            "follower.lost" => MonitorListResponseMonitorEventType.FollowerLost,
            _ => (MonitorListResponseMonitorEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorListResponseMonitorEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorListResponseMonitorEventType.TweetNew => "tweet.new",
                MonitorListResponseMonitorEventType.TweetReply => "tweet.reply",
                MonitorListResponseMonitorEventType.TweetRetweet => "tweet.retweet",
                MonitorListResponseMonitorEventType.TweetQuote => "tweet.quote",
                MonitorListResponseMonitorEventType.FollowerGained => "follower.gained",
                MonitorListResponseMonitorEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
