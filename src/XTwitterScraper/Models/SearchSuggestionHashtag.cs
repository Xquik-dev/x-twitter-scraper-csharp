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

[JsonConverter(typeof(JsonModelConverter<SearchSuggestionHashtag, SearchSuggestionHashtagFromRaw>))]
public sealed record class SearchSuggestionHashtag : JsonModel
{
    /// <summary>
    /// Suggested hashtag, with its leading #.
    /// </summary>
    public required string Hashtag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("hashtag");
        }
        init { this._rawData.Set("hashtag", value); }
    }

    /// <summary>
    /// X's rounded relevance score for the hashtag.
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Normalized text tokens X matches the hashtag by.
    /// </summary>
    public IReadOnlyList<string>? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tokens",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X's inline flag for the hashtag.
    /// </summary>
    public bool? Inline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inline", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hashtag;
        _ = this.Score;
        _ = this.Tokens;
        _ = this.Inline;
    }

    public SearchSuggestionHashtag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionHashtag(SearchSuggestionHashtag searchSuggestionHashtag)
        : base(searchSuggestionHashtag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionHashtag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestionHashtag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionHashtagFromRaw.FromRawUnchecked"/>
    public static SearchSuggestionHashtag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionHashtagFromRaw : IFromRawJson<SearchSuggestionHashtag>
{
    /// <inheritdoc/>
    public SearchSuggestionHashtag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchSuggestionHashtag.FromRawUnchecked(rawData);
}
