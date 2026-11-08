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

[JsonConverter(typeof(JsonModelConverter<UserInsightsSample, UserInsightsSampleFromRaw>))]
public sealed record class UserInsightsSample : JsonModel
{
    /// <summary>
    /// Posts the averages used. Reposts and the pinned post stay out, so this can be lower than `read`.
    /// </summary>
    public required double Posts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("posts");
        }
        init { this._rawData.Set("posts", value); }
    }

    /// <summary>
    /// Posts read, reposts and the pinned post included.
    /// </summary>
    public required double Read
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("read");
        }
        init { this._rawData.Set("read", value); }
    }

    /// <summary>
    /// When the oldest post the averages used went up.
    /// </summary>
    public required DateTimeOffset? OldestAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("oldestAt");
        }
        init { this._rawData.Set("oldestAt", value); }
    }

    /// <summary>
    /// When the newest post the averages used went up.
    /// </summary>
    public required DateTimeOffset? NewestAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("newestAt");
        }
        init { this._rawData.Set("newestAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Posts;
        _ = this.Read;
        _ = this.OldestAt;
        _ = this.NewestAt;
    }

    public UserInsightsSample() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsightsSample(UserInsightsSample userInsightsSample)
        : base(userInsightsSample) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsightsSample(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserInsightsSample(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserInsightsSampleFromRaw.FromRawUnchecked"/>
    public static UserInsightsSample FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserInsightsSampleFromRaw : IFromRawJson<UserInsightsSample>
{
    /// <inheritdoc/>
    public UserInsightsSample FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserInsightsSample.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UserInsightsAverages, UserInsightsAveragesFromRaw>))]
public sealed record class UserInsightsAverages : JsonModel
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

    /// <summary>
    /// Likes, replies, reposts and quotes per post.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Likes;
        _ = this.Replies;
        _ = this.Reposts;
        _ = this.Quotes;
        _ = this.Bookmarks;
        _ = this.Views;
        _ = this.Engagements;
    }

    public UserInsightsAverages() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsightsAverages(UserInsightsAverages userInsightsAverages)
        : base(userInsightsAverages) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsightsAverages(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserInsightsAverages(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserInsightsAveragesFromRaw.FromRawUnchecked"/>
    public static UserInsightsAverages FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserInsightsAveragesFromRaw : IFromRawJson<UserInsightsAverages>
{
    /// <inheritdoc/>
    public UserInsightsAverages FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserInsightsAverages.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UserInsights, UserInsightsFromRaw>))]
public sealed record class UserInsights : JsonModel
{
    /// <summary>
    /// ID of the profile the insights describe.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// Username of that profile.
    /// </summary>
    public required string UserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userName");
        }
        init { this._rawData.Set("userName", value); }
    }

    /// <summary>
    /// Followers.
    /// </summary>
    public required double Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("followers");
        }
        init { this._rawData.Set("followers", value); }
    }

    /// <summary>
    /// Accounts the user follows.
    /// </summary>
    public required double Following
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("following");
        }
        init { this._rawData.Set("following", value); }
    }

    /// <summary>
    /// Posts the user has made.
    /// </summary>
    public required double Posts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("posts");
        }
        init { this._rawData.Set("posts", value); }
    }

    /// <summary>
    /// Whole days since the account joined X.
    /// </summary>
    public required double? AccountAgeDays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("accountAgeDays");
        }
        init { this._rawData.Set("accountAgeDays", value); }
    }

    /// <summary>
    /// True when only the account's followers see its posts. The report then has its counts only.
    /// </summary>
    public required bool PostsPrivate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("postsPrivate");
        }
        init { this._rawData.Set("postsPrivate", value); }
    }

    /// <summary>
    /// The recent posts the read covered.
    /// </summary>
    public required UserInsightsSample Sample
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserInsightsSample>("sample");
        }
        init { this._rawData.Set("sample", value); }
    }

    /// <summary>
    /// Each count per post of the sample. Null without posts.
    /// </summary>
    public required UserInsightsAverages? Averages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserInsightsAverages>("averages");
        }
        init { this._rawData.Set("averages", value); }
    }

    /// <summary>
    /// Middle view count of the sample, so 1 viral post moves it less than the average. Null without posts.
    /// </summary>
    public required double? MedianViews
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("medianViews");
        }
        init { this._rawData.Set("medianViews", value); }
    }

    /// <summary>
    /// Average engagements per post, as a percent of followers.
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
    /// Engagements as a percent of views across the sample.
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
    /// Sampled posts per day, from the oldest one until now.
    /// </summary>
    public required double? PostsPerDay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("postsPerDay");
        }
        init { this._rawData.Set("postsPerDay", value); }
    }

    /// <summary>
    /// The sampled post with the most engagements.
    /// </summary>
    public required string? TopPostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topPostId");
        }
        init { this._rawData.Set("topPostId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
        _ = this.UserName;
        _ = this.Followers;
        _ = this.Following;
        _ = this.Posts;
        _ = this.AccountAgeDays;
        _ = this.PostsPrivate;
        this.Sample.Validate();
        this.Averages?.Validate();
        _ = this.MedianViews;
        _ = this.EngagementRate;
        _ = this.EngagementPerView;
        _ = this.PostsPerDay;
        _ = this.TopPostID;
    }

    public UserInsights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsights(UserInsights userInsights)
        : base(userInsights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInsights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserInsights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserInsightsFromRaw.FromRawUnchecked"/>
    public static UserInsights FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserInsightsFromRaw : IFromRawJson<UserInsights>
{
    /// <inheritdoc/>
    public UserInsights FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserInsights.FromRawUnchecked(rawData);
}
