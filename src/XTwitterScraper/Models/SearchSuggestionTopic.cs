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

[JsonConverter(typeof(JsonModelConverter<SearchSuggestionTopic, SearchSuggestionTopicFromRaw>))]
public sealed record class SearchSuggestionTopic : JsonModel
{
    /// <summary>
    /// Suggested search phrase.
    /// </summary>
    public required string Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic");
        }
        init { this._rawData.Set("topic", value); }
    }

    /// <summary>
    /// X's rounded relevance score for the phrase.
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
    /// Normalized text tokens X matches the phrase by.
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
    /// X's inline flag for the phrase.
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
        _ = this.Topic;
        _ = this.Score;
        _ = this.Tokens;
        _ = this.Inline;
    }

    public SearchSuggestionTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionTopic(SearchSuggestionTopic searchSuggestionTopic)
        : base(searchSuggestionTopic) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestionTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionTopicFromRaw.FromRawUnchecked"/>
    public static SearchSuggestionTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionTopicFromRaw : IFromRawJson<SearchSuggestionTopic>
{
    /// <inheritdoc/>
    public SearchSuggestionTopic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchSuggestionTopic.FromRawUnchecked(rawData);
}
