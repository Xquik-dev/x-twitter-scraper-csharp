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

[JsonConverter(typeof(JsonModelConverter<TweetEntities, TweetEntitiesFromRaw>))]
public sealed record class TweetEntities : JsonModel
{
    public IReadOnlyList<global::XTwitterScraper.Models.TweetHashtag>? Hashtags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetHashtag>
            >("hashtags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetHashtag>?>(
                "hashtags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.TweetSymbol>? Smarttags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>
            >("smarttags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>?>(
                "smarttags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.TweetSymbol>? Symbols
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>
            >("symbols");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>?>(
                "symbols",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.TweetSymbol>? Timestamps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>
            >("timestamps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetSymbol>?>(
                "timestamps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.TweetUrlEntity>? Urls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetUrlEntity>
            >("urls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetUrlEntity>?>(
                "urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.TweetUserMention>? UserMentions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetUserMention>
            >("user_mentions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetUserMention>?>(
                "user_mentions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Hashtags ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Smarttags ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Symbols ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Timestamps ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Urls ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UserMentions ?? [])
        {
            item.Validate();
        }
    }

    public TweetEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEntities(TweetEntities tweetEntities)
        : base(tweetEntities) { }
#pragma warning restore CS8618

    public TweetEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetEntitiesFromRaw.FromRawUnchecked"/>
    public static TweetEntities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetEntitiesFromRaw : IFromRawJson<TweetEntities>
{
    /// <inheritdoc/>
    public TweetEntities FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetEntities.FromRawUnchecked(rawData);
}
