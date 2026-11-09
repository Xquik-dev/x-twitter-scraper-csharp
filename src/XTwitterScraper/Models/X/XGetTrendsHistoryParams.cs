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
/// Returns the Twitter trends archive of a place, as the lists X showed there over a range of time. Use it for trending on Twitter yesterday, last week or any day since 2026-10-13 02:20 UTC. Xquik stores 1 list per place every 5 minutes and keeps it for 25 months. Pick the place by woeid, country or location name, the range with from &amp; to, and the step with every. from &amp; to take a time or a span back from now, such as 7d, so a schedule can read the last day on every run. Each step returns the first list stored in it, with its own time. Each returned list costs 1 credit, so 24 lists cost 24 credits. A step with no stored list returns none. Empty trend history steps are free. 1 request returns 24 lists, or up to 100 with limit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class XGetTrendsHistoryParams : ParamsBase
{
    /// <summary>
    /// WOEID of the place, such as 1 for Worldwide or 23424969 for Turkey. It wins over country &amp; location. /x/trends/locations lists every WOEID.
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
    /// Country to read trends history for, by name or 2-letter code, such as Turkey or TR. Case insensitive. X can add places, so Xquik takes up to 280 characters, the most a post holds.
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
    /// Town or country to read trends history for, by name, such as Istanbul. Case insensitive. Add country when 2 towns share a name. /x/trends/locations lists every name. X can add places, so Xquik takes up to 280 characters, the most a post holds.
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
    /// Start of the range. Takes an ISO 8601 time, a date such as 2026-10-13, or Unix seconds. A time without a zone reads as UTC. It also takes a span back from now, as a number &amp; s, m, h or d, so from=7d reads the last 7 days. Defaults to 24 hours before to. History starts 2026-10-13 02:20 UTC, and a range that begins earlier returns the stored part. Alias sinceTime.
    /// </summary>
    public string? From
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("from", value);
        }
    }

    /// <summary>
    /// End of the range, which it leaves out. Takes the forms of from, so from=2d with to=1d reads the day before the last 24 hours. Defaults to now. Alias untilTime.
    /// </summary>
    public string? To
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("to", value);
        }
    }

    /// <summary>
    /// Step between 2 returned lists, as a number &amp; m, h or d, such as 15m, 1h or 1d. A step under 5m returns every stored list.
    /// </summary>
    public string? Every
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("every");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("every", value);
        }
    }

    /// <summary>
    /// Trends to return in each list.
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
    /// Maximum lists 1 request returns &amp; charges. A wider range gives a next_cursor for the next lists. A low credit balance can return fewer.
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
    /// The next_cursor of the page before, for the next lists. It keeps the time of the first request, so a range of spans stays the same on every page.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
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

    public XGetTrendsHistoryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryParams(XGetTrendsHistoryParams xGetTrendsHistoryParams)
        : base(xGetTrendsHistoryParams) { }
#pragma warning restore CS8618

    public XGetTrendsHistoryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsHistoryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static XGetTrendsHistoryParams FromRawUnchecked(
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

    public virtual bool Equals(XGetTrendsHistoryParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/trends/history")
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
