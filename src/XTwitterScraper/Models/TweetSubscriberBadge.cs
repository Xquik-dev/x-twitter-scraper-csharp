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

[JsonConverter(typeof(JsonModelConverter<TweetSubscriberBadge, TweetSubscriberBadgeFromRaw>))]
public sealed record class TweetSubscriberBadge : JsonModel
{
    /// <summary>
    /// Account ID of the creator the author subscribes to.
    /// </summary>
    public required string CreatorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creatorId");
        }
        init { this._rawData.Set("creatorId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatorID;
    }

    public TweetSubscriberBadge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSubscriberBadge(TweetSubscriberBadge tweetSubscriberBadge)
        : base(tweetSubscriberBadge) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSubscriberBadge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSubscriberBadge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSubscriberBadgeFromRaw.FromRawUnchecked"/>
    public static TweetSubscriberBadge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSubscriberBadgeFromRaw : IFromRawJson<TweetSubscriberBadge>
{
    /// <inheritdoc/>
    public TweetSubscriberBadge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetSubscriberBadge.FromRawUnchecked(rawData);
}
