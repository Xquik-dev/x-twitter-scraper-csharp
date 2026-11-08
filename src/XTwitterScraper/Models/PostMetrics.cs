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

[JsonConverter(typeof(JsonModelConverter<PostMetrics, PostMetricsFromRaw>))]
public sealed record class PostMetrics : JsonModel
{
    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
                "views"
            );
        }
        init { this._rawData.Set("views", value); }
    }

    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
                "likes"
            );
        }
        init { this._rawData.Set("likes", value); }
    }

    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Retweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
                "retweets"
            );
        }
        init { this._rawData.Set("retweets", value); }
    }

    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
                "replies"
            );
        }
        init { this._rawData.Set("replies", value); }
    }

    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Quotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
                "quotes"
            );
        }
        init { this._rawData.Set("quotes", value); }
    }

    /// <summary>
    /// A metric's current value &amp; its gain since tracking began. Both are null when X shows no count, as for views on old posts.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetricReading Bookmarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetricReading>(
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

    public PostMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetrics(PostMetrics postMetrics)
        : base(postMetrics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMetricsFromRaw.FromRawUnchecked"/>
    public static PostMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMetricsFromRaw : IFromRawJson<PostMetrics>
{
    /// <inheritdoc/>
    public PostMetrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMetrics.FromRawUnchecked(rawData);
}
