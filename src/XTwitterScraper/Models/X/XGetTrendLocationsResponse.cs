// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X;

[JsonConverter(
    typeof(JsonModelConverter<XGetTrendLocationsResponse, XGetTrendLocationsResponseFromRaw>)
)]
public sealed record class XGetTrendLocationsResponse : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.TrendLocation> Locations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.TrendLocation>
            >("locations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TrendLocation>>(
                "locations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Locations returned &amp; charged.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Locations that match the filters, before limit.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// What to send instead. Present only when no location matches.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Locations)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Total;
        _ = this.Message;
    }

    public XGetTrendLocationsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendLocationsResponse(XGetTrendLocationsResponse xGetTrendLocationsResponse)
        : base(xGetTrendLocationsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendLocationsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendLocationsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendLocationsResponseFromRaw.FromRawUnchecked"/>
    public static XGetTrendLocationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendLocationsResponseFromRaw : IFromRawJson<XGetTrendLocationsResponse>
{
    /// <inheritdoc/>
    public XGetTrendLocationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetTrendLocationsResponse.FromRawUnchecked(rawData);
}
