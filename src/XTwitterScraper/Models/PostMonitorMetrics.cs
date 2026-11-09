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

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        PostMonitorMetricsBucketsMetrics,
        PostMonitorMetricsBucketsMetricsFromRaw
    >)
)]
public sealed record class PostMonitorMetricsBucketsMetrics : JsonModel
{
    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "views"
            );
        }
        init { this._rawData.Set("views", value); }
    }

    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "likes"
            );
        }
        init { this._rawData.Set("likes", value); }
    }

    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Retweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "retweets"
            );
        }
        init { this._rawData.Set("retweets", value); }
    }

    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "replies"
            );
        }
        init { this._rawData.Set("replies", value); }
    }

    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Quotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "quotes"
            );
        }
        init { this._rawData.Set("quotes", value); }
    }

    /// <summary>
    /// A metric's value at the hour's end &amp; its gain over that hour. Both are null when X shows no count.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricPoint Bookmarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricPoint>(
                "bookmarks"
            );
        }
        init { this._rawData.Set("bookmarks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Views.Validate();
        this.Likes.Validate();
        this.Retweets.Validate();
        this.Replies.Validate();
        this.Quotes.Validate();
        this.Bookmarks.Validate();
    }

    public PostMonitorMetricsBucketsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetricsBucketsMetrics(
        PostMonitorMetricsBucketsMetrics postMonitorMetricsBucketsMetrics
    )
        : base(postMonitorMetricsBucketsMetrics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetricsBucketsMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorMetricsBucketsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorMetricsBucketsMetricsFromRaw.FromRawUnchecked"/>
    public static PostMonitorMetricsBucketsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorMetricsBucketsMetricsFromRaw : IFromRawJson<PostMonitorMetricsBucketsMetrics>
{
    /// <inheritdoc/>
    public PostMonitorMetricsBucketsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostMonitorMetricsBucketsMetrics.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PostMonitorMetricsBuckets, PostMonitorMetricsBucketsFromRaw>)
)]
public sealed record class PostMonitorMetricsBuckets : JsonModel
{
    /// <summary>
    /// Start of the hour.
    /// </summary>
    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
    }

    public required PostMonitorMetricsBucketsMetrics Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PostMonitorMetricsBucketsMetrics>("metrics");
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.At;
        this.Metrics.Validate();
    }

    public PostMonitorMetricsBuckets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetricsBuckets(PostMonitorMetricsBuckets postMonitorMetricsBuckets)
        : base(postMonitorMetricsBuckets) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetricsBuckets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorMetricsBuckets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorMetricsBucketsFromRaw.FromRawUnchecked"/>
    public static PostMonitorMetricsBuckets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorMetricsBucketsFromRaw : IFromRawJson<PostMonitorMetricsBuckets>
{
    /// <inheritdoc/>
    public PostMonitorMetricsBuckets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostMonitorMetricsBuckets.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PostMonitorMetrics, PostMonitorMetricsFromRaw>))]
public sealed record class PostMonitorMetrics : JsonModel
{
    public required long Hours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("hours");
        }
        init { this._rawData.Set("hours", value); }
    }

    public required IReadOnlyList<PostMonitorMetricsBuckets> Buckets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PostMonitorMetricsBuckets>>(
                "buckets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PostMonitorMetricsBuckets>>(
                "buckets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hours;
        foreach (var item in this.Buckets)
        {
            item.Validate();
        }
    }

    public PostMonitorMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetrics(PostMonitorMetrics postMonitorMetrics)
        : base(postMonitorMetrics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorMetricsFromRaw.FromRawUnchecked"/>
    public static PostMonitorMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorMetricsFromRaw : IFromRawJson<PostMonitorMetrics>
{
    /// <inheritdoc/>
    public PostMonitorMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMonitorMetrics.FromRawUnchecked(rawData);
}
