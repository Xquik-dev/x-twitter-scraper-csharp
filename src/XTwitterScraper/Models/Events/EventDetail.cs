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
/// Full monitor event including payload data and optional X event ID.
/// </summary>
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

    /// <summary>
    /// Event payload - shape varies by event type (JSON)
    /// </summary>
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
    /// Monitor ID associated with this detailed event payload.
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
    /// Source monitor type for this detailed event.
    /// </summary>
    public required ApiEnum<string, EventDetailMonitorType> MonitorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventDetailMonitorType>>(
                "monitorType"
            );
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
    public required ApiEnum<string, EventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Keyword monitor ID included on detailed keyword events.
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
    /// Keyword query for this detailed monitor event.
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
    /// Account username for this detailed monitor event.
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
        this.MonitorType.Validate();
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.KeywordMonitorID;
        _ = this.Query;
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

/// <summary>
/// Source monitor type for this detailed event.
/// </summary>
[JsonConverter(typeof(EventDetailMonitorTypeConverter))]
public enum EventDetailMonitorType
{
    Account,
    Keyword,
}

sealed class EventDetailMonitorTypeConverter : JsonConverter<EventDetailMonitorType>
{
    public override EventDetailMonitorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account" => EventDetailMonitorType.Account,
            "keyword" => EventDetailMonitorType.Keyword,
            _ => (EventDetailMonitorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventDetailMonitorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventDetailMonitorType.Account => "account",
                EventDetailMonitorType.Keyword => "keyword",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
