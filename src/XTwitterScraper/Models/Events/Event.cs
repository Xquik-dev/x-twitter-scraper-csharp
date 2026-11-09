// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Events;

/// <summary>
/// Monitor event summary with source metadata and occurrence time.
/// </summary>
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

    /// <summary>
    /// Account monitor ID for account events, or keyword monitor ID for keyword events.
    /// </summary>
    public required string MonitorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("monitorId");
        }
        init { this._rawData.Set("monitorId", value); }
    }

    /// <summary>
    /// Source monitor type.
    /// </summary>
    public required ApiEnum<string, MonitorType> MonitorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MonitorType>>("monitorType");
        }
        init { this._rawData.Set("monitorType", value); }
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

    /// <summary>
    /// Type of monitor event fired when account activity occurs.
    /// </summary>
    public required WebhookEventType Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebhookEventType>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Keyword monitor ID, present for keyword monitor events.
    /// </summary>
    public string? KeywordMonitorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("keywordMonitorId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("keywordMonitorId", value);
        }
    }

    /// <summary>
    /// Keyword query, present for keyword monitor events.
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <summary>
    /// Account username, present for account monitor events.
    /// </summary>
    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <summary>
    /// Permanent X user ID of the monitored account, present for account monitor events. It stays the same after a username change.
    /// </summary>
    public string? XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xUserId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("xUserId", value);
        }
    }

    /// <summary>
    /// Your monitor label when Xquik created the event, present when set. A rename leaves the event's label unchanged.
    /// </summary>
    public string? MonitorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("monitorName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monitorName", value);
        }
    }

    /// <summary>
    /// ID of the monitored post, present for post events.
    /// </summary>
    public string? PostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postId", value);
        }
    }

    /// <summary>
    /// Link to the monitored post, present for post events.
    /// </summary>
    public string? PostUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postUrl", value);
        }
    }

    /// <summary>
    /// Permanent X user ID of the monitored post's author, present for post events.
    /// </summary>
    public string? AuthorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorId", value);
        }
    }

    /// <summary>
    /// Username of the monitored post's author, present for post events.
    /// </summary>
    public string? AuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorUsername", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Data;
        _ = this.MonitorID;
        this.MonitorType.Validate();
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.KeywordMonitorID;
        _ = this.Query;
        _ = this.Username;
        _ = this.XUserID;
        _ = this.MonitorName;
        _ = this.PostID;
        _ = this.PostUrl;
        _ = this.AuthorID;
        _ = this.AuthorUsername;
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

/// <summary>
/// Source monitor type.
/// </summary>
[JsonConverter(typeof(MonitorTypeConverter))]
public enum MonitorType
{
    Account,
    Keyword,
    Post,
}

sealed class MonitorTypeConverter : JsonConverter<MonitorType>
{
    public override MonitorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => MonitorType.Account,
            "keyword" => MonitorType.Keyword,
            "post" => MonitorType.Post,
            _ => (MonitorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorType.Account => "account",
                MonitorType.Keyword => "keyword",
                MonitorType.Post => "post",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
