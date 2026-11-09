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

[JsonConverter(typeof(JsonModelConverter<SearchSuggestions, SearchSuggestionsFromRaw>))]
public sealed record class SearchSuggestions : JsonModel
{
    /// <summary>
    /// The query you sent, trimmed.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <summary>
    /// Suggested accounts.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SearchSuggestionUser> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionUser>
            >("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionUser>>(
                "users",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Suggested search phrases that are not hashtags.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SearchSuggestionTopic> Topics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionTopic>
            >("topics");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionTopic>>(
                "topics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Suggested hashtags.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SearchSuggestionHashtag> Hashtags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionHashtag>
            >("hashtags");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionHashtag>
            >("hashtags", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Suggested stocks &amp; crypto tokens.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SearchSuggestionCashtag> Cashtags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionCashtag>
            >("cashtags");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.SearchSuggestionCashtag>
            >("cashtags", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Suggestions returned across all 4 lists. Each costs 1 credit.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Query;
        foreach (var item in this.Users)
        {
            item.Validate();
        }
        foreach (var item in this.Topics)
        {
            item.Validate();
        }
        foreach (var item in this.Hashtags)
        {
            item.Validate();
        }
        foreach (var item in this.Cashtags)
        {
            item.Validate();
        }
        _ = this.Count;
    }

    public SearchSuggestions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestions(SearchSuggestions searchSuggestions)
        : base(searchSuggestions) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionsFromRaw.FromRawUnchecked"/>
    public static SearchSuggestions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionsFromRaw : IFromRawJson<SearchSuggestions>
{
    /// <inheritdoc/>
    public SearchSuggestions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchSuggestions.FromRawUnchecked(rawData);
}
