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
/// Returns X's hashflags, the custom emoji X shows after some hashtags. Lists the ones running now unless activeOnly is false. Each returned hashflag costs 1 credit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class XGetHashflagsParams : ParamsBase
{
    /// <summary>
    /// Text the hashtag contains, such as football. Case insensitive. A leading hash sign is ignored. Alias query. A post holds at most 280 characters.
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
    /// Keeps hashflags that run now. Send false to add ended &amp; upcoming ones.
    /// </summary>
    public bool? ActiveOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("activeOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("activeOnly", value);
        }
    }

    /// <summary>
    /// Maximum hashflags to return. Omit it for every match. A low credit balance can return fewer. Aliases pageSize, count, max_results, maxItems, max_items &amp; per_page.
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

    public XGetHashflagsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetHashflagsParams(XGetHashflagsParams xGetHashflagsParams)
        : base(xGetHashflagsParams) { }
#pragma warning restore CS8618

    public XGetHashflagsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetHashflagsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static XGetHashflagsParams FromRawUnchecked(
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

    public virtual bool Equals(XGetHashflagsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/hashflags")
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
