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

namespace XTwitterScraper.Models.X;

[JsonConverter(typeof(JsonModelConverter<XGetTrendsResponse, XGetTrendsResponseFromRaw>))]
public sealed record class XGetTrendsResponse : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required IReadOnlyList<Trend> Trends
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Trend>>("trends");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Trend>>(
                "trends",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long Woeid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("woeid");
        }
        init { this._rawData.Set("woeid", value); }
    }

    /// <summary>
    /// The place country or location named. Absent when woeid picked the place or the request named none.
    /// </summary>
    public global::XTwitterScraper.Models.TrendLocation? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TrendLocation>(
                "location"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// When Xquik read this list from X. It comes from the stored list and is never estimated.
    /// </summary>
    public DateTimeOffset? CapturedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("capturedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("capturedAt", value);
        }
    }

    /// <summary>
    /// The time the at parameter asked for, as Xquik read it. A span such as 24h shows here as the time it counted back to. Present only with at.
    /// </summary>
    public DateTimeOffset? RequestedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("requestedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requestedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Trends)
        {
            item.Validate();
        }
        _ = this.Woeid;
        this.Location?.Validate();
        _ = this.CapturedAt;
        _ = this.RequestedAt;
    }

    public XGetTrendsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsResponse(XGetTrendsResponse xGetTrendsResponse)
        : base(xGetTrendsResponse) { }
#pragma warning restore CS8618

    public XGetTrendsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendsResponseFromRaw.FromRawUnchecked"/>
    public static XGetTrendsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendsResponseFromRaw : IFromRawJson<XGetTrendsResponse>
{
    /// <inheritdoc/>
    public XGetTrendsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XGetTrendsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Trend, TrendFromRaw>))]
public sealed record class Trend : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Promotion identifier from X. Null for organic trends.
    /// </summary>
    public string? PromotedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("promotedContent");
        }
        init { this._rawData.Set("promotedContent", value); }
    }

    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    public long? Rank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rank");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rank", value);
        }
    }

    /// <summary>
    /// Approximate public post volume when X supplies it.
    /// </summary>
    public long? TweetVolume
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("tweetVolume");
        }
        init { this._rawData.Set("tweetVolume", value); }
    }

    /// <summary>
    /// X search URL for the trend.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.PromotedContent;
        _ = this.Query;
        _ = this.Rank;
        _ = this.TweetVolume;
        _ = this.Url;
    }

    public Trend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trend(Trend trend)
        : base(trend) { }
#pragma warning restore CS8618

    public Trend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrendFromRaw.FromRawUnchecked"/>
    public static Trend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Trend(string name)
        : this()
    {
        this.Name = name;
    }
}

class TrendFromRaw : IFromRawJson<Trend>
{
    /// <inheritdoc/>
    public Trend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trend.FromRawUnchecked(rawData);
}
