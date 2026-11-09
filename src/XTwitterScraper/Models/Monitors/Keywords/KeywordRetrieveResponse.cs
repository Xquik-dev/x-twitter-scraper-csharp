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

/// <summary>
/// Keyword monitor that tracks matching public X activity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<KeywordRetrieveResponse, KeywordRetrieveResponseFromRaw>))]
public sealed record class KeywordRetrieveResponse : JsonModel
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
    public ApiEnum<string, KeywordRetrieveResponsePausedReason>? PausedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, KeywordRetrieveResponsePausedReason>
            >("pausedReason");
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

    public KeywordRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeywordRetrieveResponse(KeywordRetrieveResponse keywordRetrieveResponse)
        : base(keywordRetrieveResponse) { }
#pragma warning restore CS8618

    public KeywordRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KeywordRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeywordRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static KeywordRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeywordRetrieveResponseFromRaw : IFromRawJson<KeywordRetrieveResponse>
{
    /// <inheritdoc/>
    public KeywordRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KeywordRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KeywordRetrieveResponsePausedReasonConverter))]
public enum KeywordRetrieveResponsePausedReason
{
    InsufficientCredits,
}

sealed class KeywordRetrieveResponsePausedReasonConverter
    : JsonConverter<KeywordRetrieveResponsePausedReason>
{
    public override KeywordRetrieveResponsePausedReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_credits" => KeywordRetrieveResponsePausedReason.InsufficientCredits,
            _ => (KeywordRetrieveResponsePausedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        KeywordRetrieveResponsePausedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                KeywordRetrieveResponsePausedReason.InsufficientCredits => "insufficient_credits",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
