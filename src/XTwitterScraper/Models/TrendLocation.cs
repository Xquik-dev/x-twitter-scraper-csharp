// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<TrendLocation, TrendLocationFromRaw>))]
public sealed record class TrendLocation : JsonModel
{
    /// <summary>
    /// Location ID. Pass it as woeid to /x/trends.
    /// </summary>
    public required long Woeid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("woeid");
        }
        init { this._rawData.Set("woeid", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Country name. Null for Worldwide.
    /// </summary>
    public required string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// 2-letter country code. Null for Worldwide.
    /// </summary>
    public required string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
    }

    /// <summary>
    /// X's kind of place. Town, Country, Supername for Worldwide, or Unknown.
    /// </summary>
    public required string? PlaceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("placeType");
        }
        init { this._rawData.Set("placeType", value); }
    }

    /// <summary>
    /// X's numeric code for the kind of place.
    /// </summary>
    public required long? PlaceTypeCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("placeTypeCode");
        }
        init { this._rawData.Set("placeTypeCode", value); }
    }

    /// <summary>
    /// WOEID of the country or region above it. Null for Worldwide.
    /// </summary>
    public required long? ParentWoeid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("parentWoeid");
        }
        init { this._rawData.Set("parentWoeid", value); }
    }

    /// <summary>
    /// X's legacy Yahoo GeoPlanet reference. It may not resolve.
    /// </summary>
    public required string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Woeid;
        _ = this.Name;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.PlaceType;
        _ = this.PlaceTypeCode;
        _ = this.ParentWoeid;
        _ = this.UrlValue;
    }

    public TrendLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrendLocation(TrendLocation trendLocation)
        : base(trendLocation) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrendLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrendLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrendLocationFromRaw.FromRawUnchecked"/>
    public static TrendLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrendLocationFromRaw : IFromRawJson<TrendLocation>
{
    /// <inheritdoc/>
    public TrendLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrendLocation.FromRawUnchecked(rawData);
}
