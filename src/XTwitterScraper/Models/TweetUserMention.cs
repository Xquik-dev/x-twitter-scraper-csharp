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

[JsonConverter(typeof(JsonModelConverter<TweetUserMention, TweetUserMentionFromRaw>))]
public sealed record class TweetUserMention : JsonModel
{
    public string? IDStr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id_str");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id_str", value);
        }
    }

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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public required string ScreenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("screen_name");
        }
        init { this._rawData.Set("screen_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IDStr;
        _ = this.Indices;
        _ = this.Name;
        _ = this.ScreenName;
    }

    public TweetUserMention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetUserMention(TweetUserMention tweetUserMention)
        : base(tweetUserMention) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetUserMention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetUserMention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetUserMentionFromRaw.FromRawUnchecked"/>
    public static TweetUserMention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetUserMentionFromRaw : IFromRawJson<TweetUserMention>
{
    /// <inheritdoc/>
    public TweetUserMention FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetUserMention.FromRawUnchecked(rawData);
}
