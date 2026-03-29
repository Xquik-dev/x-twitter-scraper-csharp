using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Radar;

/// <summary>
/// Get trending topics from curated sources
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RadarRetrieveTrendingTopicsParams : ParamsBase
{
    /// <summary>
    /// Filter by category (general, tech, dev, etc.)
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    /// <summary>
    /// Number of items to return
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
    /// Lookback window in hours
    /// </summary>
    public long? Hours
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("hours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hours", value);
        }
    }

    /// <summary>
    /// Region filter (us, global, etc.)
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    /// <summary>
    /// Source filter. One of: github, google_trends, hacker_news, polymarket, reddit,
    /// trustmrr, wikipedia
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("source", value);
        }
    }

    public RadarRetrieveTrendingTopicsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RadarRetrieveTrendingTopicsParams(
        RadarRetrieveTrendingTopicsParams radarRetrieveTrendingTopicsParams
    )
        : base(radarRetrieveTrendingTopicsParams) { }
#pragma warning restore CS8618

    public RadarRetrieveTrendingTopicsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RadarRetrieveTrendingTopicsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RadarRetrieveTrendingTopicsParams FromRawUnchecked(
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

    public virtual bool Equals(RadarRetrieveTrendingTopicsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/radar")
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
