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

[JsonConverter(typeof(JsonModelConverter<PostEngagementMetrics, PostEngagementMetricsFromRaw>))]
public sealed record class PostEngagementMetrics : JsonModel
{
    /// <summary>
    /// Likes.
    /// </summary>
    public required double Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("likes");
        }
        init { this._rawData.Set("likes", value); }
    }

    /// <summary>
    /// Replies.
    /// </summary>
    public required double Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("replies");
        }
        init { this._rawData.Set("replies", value); }
    }

    /// <summary>
    /// Reposts.
    /// </summary>
    public required double Reposts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("reposts");
        }
        init { this._rawData.Set("reposts", value); }
    }

    /// <summary>
    /// Quotes.
    /// </summary>
    public required double Quotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quotes");
        }
        init { this._rawData.Set("quotes", value); }
    }

    /// <summary>
    /// Bookmarks.
    /// </summary>
    public required double Bookmarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("bookmarks");
        }
        init { this._rawData.Set("bookmarks", value); }
    }

    /// <summary>
    /// Views.
    /// </summary>
    public required double Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("views");
        }
        init { this._rawData.Set("views", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Likes;
        _ = this.Replies;
        _ = this.Reposts;
        _ = this.Quotes;
        _ = this.Bookmarks;
        _ = this.Views;
    }

    public PostEngagementMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostEngagementMetrics(PostEngagementMetrics postEngagementMetrics)
        : base(postEngagementMetrics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostEngagementMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostEngagementMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostEngagementMetricsFromRaw.FromRawUnchecked"/>
    public static PostEngagementMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostEngagementMetricsFromRaw : IFromRawJson<PostEngagementMetrics>
{
    /// <inheritdoc/>
    public PostEngagementMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostEngagementMetrics.FromRawUnchecked(rawData);
}
