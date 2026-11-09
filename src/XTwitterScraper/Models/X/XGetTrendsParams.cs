// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X;

/// <summary>
/// Get trending hashtags and topics from X by region
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class XGetTrendsParams : ParamsBase
{
    /// <summary>
    /// Number of trending topics to return (1-50, default 30)
    /// </summary>
    public long? Count
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("count", value);
        }
    }

    /// <summary>
    /// Region WOEID (1=Worldwide, 23424977=US, 23424975=UK, 23424969=Turkey)
    /// </summary>
    public long? Woeid
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("woeid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("woeid", value);
        }
    }

    /// <summary>
    /// Country to read trends for, by name or 2-letter code, such as Turkey or TR. Case insensitive. X can add places, so Xquik takes up to 280 characters, the most a post holds.
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
    /// Town or country to read trends for, by name, such as Istanbul. Case insensitive. Add country when 2 towns share a name. /x/trends/locations lists every name. X can add places, so Xquik takes up to 280 characters, the most a post holds.
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("location", value);
        }
    }

    /// <summary>
    /// A past time, to read what was trending on Twitter then. Takes an ISO 8601 time, a date such as 2026-10-13, or Unix seconds. A time without a zone reads as UTC. It also takes a span back from now, as a number &amp; s, m, h or d. So at=24h reads what was trending on Twitter yesterday at this hour, on every run of a schedule. The answer is the stored list nearest that time, with its own time in capturedAt. History starts 2026-10-13 02:20 UTC. A time over 24 hours from every stored list answers 400 at no charge.
    /// </summary>
    public string? At
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("at", value);
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

    public XGetTrendsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsParams(XGetTrendsParams xGetTrendsParams)
        : base(xGetTrendsParams) { }
#pragma warning restore CS8618

    public XGetTrendsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static XGetTrendsParams FromRawUnchecked(
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

    public virtual bool Equals(XGetTrendsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/trends")
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
