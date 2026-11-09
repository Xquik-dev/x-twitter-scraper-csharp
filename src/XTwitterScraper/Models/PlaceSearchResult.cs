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

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<PlaceSearchResultBoundingBox, PlaceSearchResultBoundingBoxFromRaw>)
)]
public sealed record class PlaceSearchResultBoundingBox : JsonModel
{
    /// <summary>
    /// GeoJSON shape of the outline.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Rings of points that draw the outline.
    /// </summary>
    public required IReadOnlyList<JsonElement> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("coordinates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "coordinates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Coordinates;
    }

    public PlaceSearchResultBoundingBox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceSearchResultBoundingBox(PlaceSearchResultBoundingBox placeSearchResultBoundingBox)
        : base(placeSearchResultBoundingBox) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceSearchResultBoundingBox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaceSearchResultBoundingBox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceSearchResultBoundingBoxFromRaw.FromRawUnchecked"/>
    public static PlaceSearchResultBoundingBox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceSearchResultBoundingBoxFromRaw : IFromRawJson<PlaceSearchResultBoundingBox>
{
    /// <inheritdoc/>
    public PlaceSearchResultBoundingBox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaceSearchResultBoundingBox.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PlaceSearchResult, PlaceSearchResultFromRaw>))]
public sealed record class PlaceSearchResult : JsonModel
{
    /// <summary>
    /// Place ID. Pass it as place to /x/tweets/search.
    /// </summary>
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
    /// Short name of the place.
    /// </summary>
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
    /// Name with the region or country around the place.
    /// </summary>
    public required string? FullName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fullName");
        }
        init { this._rawData.Set("fullName", value); }
    }

    /// <summary>
    /// Country the place lies in.
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
    /// 2-letter code of the country the place lies in.
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
    /// X's kind of place, such as city, admin, neighborhood, poi or country.
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
    /// X's own reference URL for the place.
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

    /// <summary>
    /// Center of the place. Longitude, then latitude.
    /// </summary>
    public required IReadOnlyList<double>? Centroid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("centroid");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>?>(
                "centroid",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Outline of the place as GeoJSON. Each point holds longitude, then latitude.
    /// </summary>
    public required PlaceSearchResultBoundingBox? BoundingBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlaceSearchResultBoundingBox>("boundingBox");
        }
        init { this._rawData.Set("boundingBox", value); }
    }

    /// <summary>
    /// Extra details X attaches to some places. Often empty.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "attributes"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "attributes",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Larger places this place lies in. Often 1.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.Place> ContainedWithin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.Place>
            >("containedWithin");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.Place>>(
                "containedWithin",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.FullName;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.PlaceType;
        _ = this.UrlValue;
        _ = this.Centroid;
        this.BoundingBox?.Validate();
        _ = this.Attributes;
        foreach (var item in this.ContainedWithin)
        {
            item.Validate();
        }
    }

    public PlaceSearchResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceSearchResult(PlaceSearchResult placeSearchResult)
        : base(placeSearchResult) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceSearchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaceSearchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceSearchResultFromRaw.FromRawUnchecked"/>
    public static PlaceSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceSearchResultFromRaw : IFromRawJson<PlaceSearchResult>
{
    /// <inheritdoc/>
    public PlaceSearchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlaceSearchResult.FromRawUnchecked(rawData);
}
