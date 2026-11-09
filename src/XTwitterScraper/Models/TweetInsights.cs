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

[JsonConverter(typeof(JsonModelConverter<TweetInsights, TweetInsightsFromRaw>))]
public sealed record class TweetInsights : JsonModel
{
    /// <summary>
    /// ID of the tweet the insights describe.
    /// </summary>
    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    /// <summary>
    /// ID of the author.
    /// </summary>
    public required string? AuthorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorId");
        }
        init { this._rawData.Set("authorId", value); }
    }

    /// <summary>
    /// Username of the author.
    /// </summary>
    public required string? AuthorUserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorUserName");
        }
        init { this._rawData.Set("authorUserName", value); }
    }

    /// <summary>
    /// When the tweet went up.
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Hours since the tweet went up.
    /// </summary>
    public required double? AgeHours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ageHours");
        }
        init { this._rawData.Set("ageHours", value); }
    }

    /// <summary>
    /// The public counts of 1 tweet.
    /// </summary>
    public required global::XTwitterScraper.Models.PostEngagementMetrics Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostEngagementMetrics>(
                "metrics"
            );
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <summary>
    /// Likes, replies, reposts and quotes.
    /// </summary>
    public required double Engagements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("engagements");
        }
        init { this._rawData.Set("engagements", value); }
    }

    /// <summary>
    /// Engagements per hour since the tweet went up.
    /// </summary>
    public required double? EngagementsPerHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("engagementsPerHour");
        }
        init { this._rawData.Set("engagementsPerHour", value); }
    }

    /// <summary>
    /// Engagements as a percent of views.
    /// </summary>
    public required double? EngagementPerView
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("engagementPerView");
        }
        init { this._rawData.Set("engagementPerView", value); }
    }

    /// <summary>
    /// Engagements as a percent of the author's followers.
    /// </summary>
    public required double? EngagementRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("engagementRate");
        }
        init { this._rawData.Set("engagementRate", value); }
    }

    /// <summary>
    /// Reposts and quotes per like.
    /// </summary>
    public required double? Amplification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amplification");
        }
        init { this._rawData.Set("amplification", value); }
    }

    /// <summary>
    /// Replies per like.
    /// </summary>
    public required double? Conversation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversation");
        }
        init { this._rawData.Set("conversation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetID;
        _ = this.AuthorID;
        _ = this.AuthorUserName;
        _ = this.CreatedAt;
        _ = this.AgeHours;
        this.Metrics.Validate();
        _ = this.Engagements;
        _ = this.EngagementsPerHour;
        _ = this.EngagementPerView;
        _ = this.EngagementRate;
        _ = this.Amplification;
        _ = this.Conversation;
    }

    public TweetInsights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInsights(TweetInsights tweetInsights)
        : base(tweetInsights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInsights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetInsights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetInsightsFromRaw.FromRawUnchecked"/>
    public static TweetInsights FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetInsightsFromRaw : IFromRawJson<TweetInsights>
{
    /// <inheritdoc/>
    public TweetInsights FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetInsights.FromRawUnchecked(rawData);
}
