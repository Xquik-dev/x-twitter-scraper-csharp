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

namespace XTwitterScraper.Models.Monitors.Keywords;

/// <summary>
/// Keyword monitor that tracks matching public X activity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<KeywordUpdateResponse, KeywordUpdateResponseFromRaw>))]
public sealed record class KeywordUpdateResponse : JsonModel
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
    }

    public KeywordUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeywordUpdateResponse(KeywordUpdateResponse keywordUpdateResponse)
        : base(keywordUpdateResponse) { }
#pragma warning restore CS8618

    public KeywordUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KeywordUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeywordUpdateResponseFromRaw.FromRawUnchecked"/>
    public static KeywordUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeywordUpdateResponseFromRaw : IFromRawJson<KeywordUpdateResponse>
{
    /// <inheritdoc/>
    public KeywordUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KeywordUpdateResponse.FromRawUnchecked(rawData);
}
