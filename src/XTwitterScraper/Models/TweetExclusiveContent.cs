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

[JsonConverter(typeof(JsonModelConverter<TweetExclusiveContent, TweetExclusiveContentFromRaw>))]
public sealed record class TweetExclusiveContent : JsonModel
{
    /// <summary>
    /// Username of the creator whose subscription unlocks the post.
    /// </summary>
    public required string CreatorUserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creatorUserName");
        }
        init { this._rawData.Set("creatorUserName", value); }
    }

    /// <summary>
    /// Subscribe link X shows non-subscribers. Omitted when X serves the full post.
    /// </summary>
    public string? SubscribeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscribeUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscribeUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatorUserName;
        _ = this.SubscribeUrl;
    }

    public TweetExclusiveContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetExclusiveContent(TweetExclusiveContent tweetExclusiveContent)
        : base(tweetExclusiveContent) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetExclusiveContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetExclusiveContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetExclusiveContentFromRaw.FromRawUnchecked"/>
    public static TweetExclusiveContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetExclusiveContentFromRaw : IFromRawJson<TweetExclusiveContent>
{
    /// <inheritdoc/>
    public TweetExclusiveContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetExclusiveContent.FromRawUnchecked(rawData);
}
