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

[JsonConverter(typeof(JsonModelConverter<TweetSymbol, TweetSymbolFromRaw>))]
public sealed record class TweetSymbol : JsonModel
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

    public double? Seconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("seconds", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Indices;
        _ = this.Seconds;
        _ = this.Text;
        this.Tag?.Validate();
    }

    public TweetSymbol() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSymbol(TweetSymbol tweetSymbol)
        : base(tweetSymbol) { }
#pragma warning restore CS8618

    public TweetSymbol(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSymbol(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSymbolFromRaw.FromRawUnchecked"/>
    public static TweetSymbol FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSymbolFromRaw : IFromRawJson<TweetSymbol>
{
    /// <inheritdoc/>
    public TweetSymbol FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetSymbol.FromRawUnchecked(rawData);
}
