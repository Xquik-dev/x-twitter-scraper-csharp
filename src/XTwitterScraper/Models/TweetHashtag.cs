// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<TweetHashtag, TweetHashtagFromRaw>))]
public sealed record class TweetHashtag : JsonModel
{
    public IReadOnlyList<long>? Indices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("indices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "indices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X's SmartTag for a cashtag, smarttag or hashtag.
    /// </summary>
    public global::XTwitterScraper.Models.TweetSmartTag? Tag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetSmartTag>(
                "tag"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tag", value);
        }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Indices;
        this.Tag?.Validate();
        _ = this.Text;
    }

    public TweetHashtag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetHashtag(TweetHashtag tweetHashtag)
        : base(tweetHashtag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetHashtag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetHashtag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetHashtagFromRaw.FromRawUnchecked"/>
    public static TweetHashtag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetHashtagFromRaw : IFromRawJson<TweetHashtag>
{
    /// <inheritdoc/>
    public TweetHashtag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetHashtag.FromRawUnchecked(rawData);
}
