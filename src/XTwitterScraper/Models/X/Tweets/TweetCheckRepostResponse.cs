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

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(
    typeof(JsonModelConverter<TweetCheckRepostResponse, TweetCheckRepostResponseFromRaw>)
)]
public sealed record class TweetCheckRepostResponse : JsonModel
{
    /// <summary>
    /// Whether the account reposted the post.
    /// </summary>
    public required bool IsRetweeted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isRetweeted");
        }
        init { this._rawData.Set("isRetweeted", value); }
    }

    /// <summary>
    /// When the account reposted it, else null.
    /// </summary>
    public required DateTimeOffset? RetweetedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("retweetedAt");
        }
        init { this._rawData.Set("retweetedAt", value); }
    }

    /// <summary>
    /// The ID of the account's repost, else null.
    /// </summary>
    public required string? RetweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("retweetId");
        }
        init { this._rawData.Set("retweetId", value); }
    }

    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

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
    /// How many of the account's newest posts the check read.
    /// </summary>
    public required long CheckedPosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("checkedPosts");
        }
        init { this._rawData.Set("checkedPosts", value); }
    }

    /// <summary>
    /// Whether the check read the account's whole timeline.
    /// </summary>
    public required bool Complete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("complete");
        }
        init { this._rawData.Set("complete", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsRetweeted;
        _ = this.RetweetedAt;
        _ = this.RetweetID;
        _ = this.TweetID;
        _ = this.UserID;
        _ = this.CheckedPosts;
        _ = this.Complete;
    }

    public TweetCheckRepostResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCheckRepostResponse(TweetCheckRepostResponse tweetCheckRepostResponse)
        : base(tweetCheckRepostResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCheckRepostResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCheckRepostResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCheckRepostResponseFromRaw.FromRawUnchecked"/>
    public static TweetCheckRepostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCheckRepostResponseFromRaw : IFromRawJson<TweetCheckRepostResponse>
{
    /// <inheritdoc/>
    public TweetCheckRepostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetCheckRepostResponse.FromRawUnchecked(rawData);
}
