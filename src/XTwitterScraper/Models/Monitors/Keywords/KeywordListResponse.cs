// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Monitors.Keywords;

[JsonConverter(typeof(JsonModelConverter<KeywordListResponse, KeywordListResponseFromRaw>))]
public sealed record class KeywordListResponse : JsonModel
{
    public required IReadOnlyList<Monitor> Monitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Monitor>>("monitors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Monitor>>(
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

    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasMore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasMore", value);
        }
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
        foreach (var item in this.Monitors)
        {
            item.Validate();
        }
        _ = this.Total;
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public KeywordListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeywordListResponse(KeywordListResponse keywordListResponse)
        : base(keywordListResponse) { }
#pragma warning restore CS8618

    public KeywordListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KeywordListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeywordListResponseFromRaw.FromRawUnchecked"/>
    public static KeywordListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeywordListResponseFromRaw : IFromRawJson<KeywordListResponse>
{
    /// <inheritdoc/>
    public KeywordListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        KeywordListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Keyword monitor that tracks matching public X activity.
/// </summary>
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

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, EventType>>>(
                "eventTypes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, EventType>>>(
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

    /// <summary>
    /// Next hourly credit charge time for this keyword query monitor.
    /// </summary>
    public required DateTimeOffset NextBillingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("nextBillingAt");
        }
        init { this._rawData.Set("nextBillingAt", value); }
    }

    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <summary>
    /// Customer-set label of the keyword monitor, when set.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Why Xquik paused this keyword monitor. The balance could not pay an hour, so add credits &amp; resume. Absent when the monitor is active or you paused it yourself.
    /// </summary>
    public ApiEnum<string, MonitorPausedReason>? PausedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MonitorPausedReason>>(
                "pausedReason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedReason", value);
        }
    }

    /// <summary>
    /// When Xquik paused this keyword monitor.
    /// </summary>
    public DateTimeOffset? PausedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("pausedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedAt", value);
        }
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
        _ = this.NextBillingAt;
        _ = this.Query;
        _ = this.Name;
        this.PausedReason?.Validate();
        _ = this.PausedAt;
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

[JsonConverter(typeof(MonitorPausedReasonConverter))]
public enum MonitorPausedReason
{
    InsufficientCredits,
}

sealed class MonitorPausedReasonConverter : JsonConverter<MonitorPausedReason>
{
    public override MonitorPausedReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_credits" => MonitorPausedReason.InsufficientCredits,
            _ => (MonitorPausedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorPausedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorPausedReason.InsufficientCredits => "insufficient_credits",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
