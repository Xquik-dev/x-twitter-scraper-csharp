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

[JsonConverter(typeof(JsonModelConverter<TweetUrlEntity, TweetUrlEntityFromRaw>))]
public sealed record class TweetUrlEntity : JsonModel
{
    public string? DisplayUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("display_url", value);
        }
    }

    public string? ExpandedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expanded_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expanded_url", value);
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

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayUrl;
        _ = this.ExpandedUrl;
        _ = this.Indices;
        _ = this.UrlValue;
    }

    public TweetUrlEntity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetUrlEntity(TweetUrlEntity tweetUrlEntity)
        : base(tweetUrlEntity) { }
#pragma warning restore CS8618

    public TweetUrlEntity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetUrlEntity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetUrlEntityFromRaw.FromRawUnchecked"/>
    public static TweetUrlEntity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetUrlEntityFromRaw : IFromRawJson<TweetUrlEntity>
{
    /// <inheritdoc/>
    public TweetUrlEntity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetUrlEntity.FromRawUnchecked(rawData);
}
