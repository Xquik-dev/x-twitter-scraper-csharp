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

[JsonConverter(
    typeof(JsonModelConverter<XGetTrendsHistoryResponse, XGetTrendsHistoryResponseFromRaw>)
)]
public sealed record class XGetTrendsHistoryResponse : JsonModel
{
    /// <summary>
    /// Start of the range as Xquik read it. A span such as 7d shows here as the time it counted back to.
    /// </summary>
    public required DateTimeOffset FromTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("fromTime");
        }
        init { this._rawData.Set("fromTime", value); }
    }

    /// <summary>
    /// End of the range as Xquik read it, which the range leaves out. Without to, it is the time of the first request.
    /// </summary>
    public required DateTimeOffset ToTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("toTime");
        }
        init { this._rawData.Set("toTime", value); }
    }

    /// <summary>
    /// 1 stored list per step, oldest first. A step with no stored list is left out.
    /// </summary>
    public required IReadOnlyList<XGetTrendsHistoryResponseSnapshots> Snapshots
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<XGetTrendsHistoryResponseSnapshots>
            >("snapshots");
        }
        init
        {
            this._rawData.Set<ImmutableArray<XGetTrendsHistoryResponseSnapshots>>(
                "snapshots",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Lists returned &amp; charged.
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
    /// The place the request named by country or location. Absent when it sent a woeid or named no place.
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
    /// Whether the range holds more lists.
    /// </summary>
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Send it as cursor for the next lists. Empty on the last page.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromTime;
        _ = this.ToTime;
        foreach (var item in this.Snapshots)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Woeid;
        this.Location?.Validate();
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public XGetTrendsHistoryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponse(XGetTrendsHistoryResponse xGetTrendsHistoryResponse)
        : base(xGetTrendsHistoryResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendsHistoryResponseFromRaw.FromRawUnchecked"/>
    public static XGetTrendsHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendsHistoryResponseFromRaw : IFromRawJson<XGetTrendsHistoryResponse>
{
    /// <inheritdoc/>
    public XGetTrendsHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetTrendsHistoryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        XGetTrendsHistoryResponseSnapshotsTrends,
        XGetTrendsHistoryResponseSnapshotsTrendsFromRaw
    >)
)]
public sealed record class XGetTrendsHistoryResponseSnapshotsTrends : JsonModel
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

    /// <summary>
    /// X's promotion ID of a promoted trend. Null for the others.
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

    /// <summary>
    /// The trend's place in X's list at that time.
    /// </summary>
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
    /// X's post count for the trend at that time, when X showed one.
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
    /// The trend's search link on X.
    /// </summary>
    public string? UrlValue
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
        _ = this.Query;
        _ = this.PromotedContent;
        _ = this.Rank;
        _ = this.TweetVolume;
        _ = this.UrlValue;
    }

    public XGetTrendsHistoryResponseSnapshotsTrends() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponseSnapshotsTrends(
        XGetTrendsHistoryResponseSnapshotsTrends xGetTrendsHistoryResponseSnapshotsTrends
    )
        : base(xGetTrendsHistoryResponseSnapshotsTrends) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponseSnapshotsTrends(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsHistoryResponseSnapshotsTrends(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendsHistoryResponseSnapshotsTrendsFromRaw.FromRawUnchecked"/>
    public static XGetTrendsHistoryResponseSnapshotsTrends FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendsHistoryResponseSnapshotsTrendsFromRaw
    : IFromRawJson<XGetTrendsHistoryResponseSnapshotsTrends>
{
    /// <inheritdoc/>
    public XGetTrendsHistoryResponseSnapshotsTrends FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetTrendsHistoryResponseSnapshotsTrends.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        XGetTrendsHistoryResponseSnapshots,
        XGetTrendsHistoryResponseSnapshotsFromRaw
    >)
)]
public sealed record class XGetTrendsHistoryResponseSnapshots : JsonModel
{
    /// <summary>
    /// When Xquik read this stored list from X. Xquik never estimates it.
    /// </summary>
    public required DateTimeOffset CapturedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("capturedAt");
        }
        init { this._rawData.Set("capturedAt", value); }
    }

    /// <summary>
    /// Trends in this list.
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

    public required IReadOnlyList<XGetTrendsHistoryResponseSnapshotsTrends> Trends
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<XGetTrendsHistoryResponseSnapshotsTrends>
            >("trends");
        }
        init
        {
            this._rawData.Set<ImmutableArray<XGetTrendsHistoryResponseSnapshotsTrends>>(
                "trends",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CapturedAt;
        _ = this.Count;
        foreach (var item in this.Trends)
        {
            item.Validate();
        }
    }

    public XGetTrendsHistoryResponseSnapshots() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponseSnapshots(
        XGetTrendsHistoryResponseSnapshots xGetTrendsHistoryResponseSnapshots
    )
        : base(xGetTrendsHistoryResponseSnapshots) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsHistoryResponseSnapshots(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsHistoryResponseSnapshots(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendsHistoryResponseSnapshotsFromRaw.FromRawUnchecked"/>
    public static XGetTrendsHistoryResponseSnapshots FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendsHistoryResponseSnapshotsFromRaw : IFromRawJson<XGetTrendsHistoryResponseSnapshots>
{
    /// <inheritdoc/>
    public XGetTrendsHistoryResponseSnapshots FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetTrendsHistoryResponseSnapshots.FromRawUnchecked(rawData);
}
