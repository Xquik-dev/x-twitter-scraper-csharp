// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X;

/// <summary>
/// Returns the places X offers trends for. Pass a location's woeid to /x/trends. Each returned location costs 1 credit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class XGetTrendLocationsParams : ParamsBase
{
    /// <summary>
    /// Country name or 2-letter code, such as Turkey or TR. Case insensitive. Returns the country &amp; its towns. X can add places, so Xquik takes up to 280 characters, the most a post holds.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("country", value);
        }
    }

    /// <summary>
    /// Kind of place. Case insensitive. X labels a few towns unknown.
    /// </summary>
    public ApiEnum<string, XGetTrendLocationsParamsPlaceType>? PlaceType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, XGetTrendLocationsParamsPlaceType>
            >("placeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("placeType", value);
        }
    }

    /// <summary>
    /// Text the location name contains, such as york. Case insensitive. Alias query. X can add places, so Xquik takes up to 280 characters, the most a post holds.
    /// </summary>
    public string? Q
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("q");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("q", value);
        }
    }

    /// <summary>
    /// Maximum locations to return. Omit it for every match. A low credit balance can return fewer. Aliases pageSize, count, max_results, maxItems, max_items &amp; per_page.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Fields to keep in each row, comma-separated. Use dots for nested fields, such as author.username. A list keeps the field in each item. Case &amp; underscores do not matter. A row that lacks a field leaves it out. Cursors, counts &amp; diagnostics always stay. An unknown name answers 400 unknown_field with the valid names, before any read. The price stays the same. SDK row types then hold only the named fields. A longer URL fails at the edge before Xquik reads it. Pick only the fields you need with `fields` &amp; `omit`.
    /// </summary>
    public string? Fields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fields", value);
        }
    }

    /// <summary>
    /// Fields to drop from each row, comma-separated. It takes the same names as fields. With fields, it drops from the kept fields. A longer URL fails at the edge before Xquik reads it.
    /// </summary>
    public string? Omit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("omit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("omit", value);
        }
    }

    public XGetTrendLocationsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendLocationsParams(XGetTrendLocationsParams xGetTrendLocationsParams)
        : base(xGetTrendLocationsParams) { }
#pragma warning restore CS8618

    public XGetTrendLocationsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendLocationsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static XGetTrendLocationsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(XGetTrendLocationsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/trends/locations")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(XGetTrendLocationsParamsPlaceTypeConverter))]
public enum XGetTrendLocationsParamsPlaceType
{
    Country,
    Town,
    Worldwide,
    Unknown,
}

sealed class XGetTrendLocationsParamsPlaceTypeConverter
    : JsonConverter<XGetTrendLocationsParamsPlaceType>
{
    public override XGetTrendLocationsParamsPlaceType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country" => XGetTrendLocationsParamsPlaceType.Country,
            "town" => XGetTrendLocationsParamsPlaceType.Town,
            "worldwide" => XGetTrendLocationsParamsPlaceType.Worldwide,
            "unknown" => XGetTrendLocationsParamsPlaceType.Unknown,
            _ => (XGetTrendLocationsParamsPlaceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XGetTrendLocationsParamsPlaceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XGetTrendLocationsParamsPlaceType.Country => "country",
                XGetTrendLocationsParamsPlaceType.Town => "town",
                XGetTrendLocationsParamsPlaceType.Worldwide => "worldwide",
                XGetTrendLocationsParamsPlaceType.Unknown => "unknown",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
