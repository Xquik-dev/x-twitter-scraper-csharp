// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<CommunityAnalyticsMetrics, CommunityAnalyticsMetricsFromRaw>)
)]
public sealed record class CommunityAnalyticsMetrics : JsonModel
{
    /// <summary>
    /// A community metric for X's latest period &amp; its percent change.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityAnalyticsMetric Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityAnalyticsMetric>(
                "likes"
            );
        }
        init { this._rawData.Set("likes", value); }
    }

    /// <summary>
    /// A community metric for X's latest period &amp; its percent change.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityAnalyticsMetric NewMembers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityAnalyticsMetric>(
                "newMembers"
            );
        }
        init { this._rawData.Set("newMembers", value); }
    }

    /// <summary>
    /// A community metric for X's latest period &amp; its percent change.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityAnalyticsMetric Posts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityAnalyticsMetric>(
                "posts"
            );
        }
        init { this._rawData.Set("posts", value); }
    }

    /// <summary>
    /// A community metric for X's latest period &amp; its percent change.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityAnalyticsMetric Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityAnalyticsMetric>(
                "replies"
            );
        }
        init { this._rawData.Set("replies", value); }
    }

    /// <summary>
    /// A community metric for X's latest period &amp; its percent change.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityAnalyticsMetric UniquePosters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityAnalyticsMetric>(
                "uniquePosters"
            );
        }
        init { this._rawData.Set("uniquePosters", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Likes.Validate();
        this.NewMembers.Validate();
        this.Posts.Validate();
        this.Replies.Validate();
        this.UniquePosters.Validate();
    }

    public CommunityAnalyticsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalyticsMetrics(CommunityAnalyticsMetrics communityAnalyticsMetrics)
        : base(communityAnalyticsMetrics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalyticsMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityAnalyticsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityAnalyticsMetricsFromRaw.FromRawUnchecked"/>
    public static CommunityAnalyticsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityAnalyticsMetricsFromRaw : IFromRawJson<CommunityAnalyticsMetrics>
{
    /// <inheritdoc/>
    public CommunityAnalyticsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityAnalyticsMetrics.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityAnalytics, CommunityAnalyticsFromRaw>))]
public sealed record class CommunityAnalytics : JsonModel
{
    /// <summary>
    /// The community ID from your request.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The end of X's latest period, in UTC.
    /// </summary>
    public required DateTimeOffset PeriodEndsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("periodEndsAt");
        }
        init { this._rawData.Set("periodEndsAt", value); }
    }

    /// <summary>
    /// The period's activity, each metric with its count and changePercent. likes counts likes on community posts and newMembers the accounts that joined. posts counts the community posts and replies the replies to them. uniquePosters counts the distinct accounts that posted.
    /// </summary>
    public required CommunityAnalyticsMetrics Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CommunityAnalyticsMetrics>("metrics");
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PeriodEndsAt;
        this.Metrics.Validate();
    }

    public CommunityAnalytics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalytics(CommunityAnalytics communityAnalytics)
        : base(communityAnalytics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalytics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityAnalytics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityAnalyticsFromRaw.FromRawUnchecked"/>
    public static CommunityAnalytics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityAnalyticsFromRaw : IFromRawJson<CommunityAnalytics>
{
    /// <inheritdoc/>
    public CommunityAnalytics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityAnalytics.FromRawUnchecked(rawData);
}
