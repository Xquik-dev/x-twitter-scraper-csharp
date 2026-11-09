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

[JsonConverter(typeof(JsonModelConverter<XSearchPlacesResponse, XSearchPlacesResponseFromRaw>))]
public sealed record class XSearchPlacesResponse : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.PlaceSearchResult> Places
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.PlaceSearchResult>
            >("places");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.PlaceSearchResult>>(
                "places",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Places returned &amp; charged.
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
    /// Places X found, before limit.
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
    /// What to send instead. Present only when X finds no place.
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
        foreach (var item in this.Places)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Total;
        _ = this.Message;
    }

    public XSearchPlacesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XSearchPlacesResponse(XSearchPlacesResponse xSearchPlacesResponse)
        : base(xSearchPlacesResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XSearchPlacesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XSearchPlacesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XSearchPlacesResponseFromRaw.FromRawUnchecked"/>
    public static XSearchPlacesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XSearchPlacesResponseFromRaw : IFromRawJson<XSearchPlacesResponse>
{
    /// <inheritdoc/>
    public XSearchPlacesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XSearchPlacesResponse.FromRawUnchecked(rawData);
}
