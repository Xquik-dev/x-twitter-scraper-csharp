// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        SportsGamePostsSearchContextSmartTag,
        SportsGamePostsSearchContextSmartTagFromRaw
    >)
)]
public sealed record class SportsGamePostsSearchContextSmartTag : JsonModel
{
    /// <summary>
    /// The ticker X matched.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Whether X lists the ticker as active.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// Whether X charts the ticker with open, high, low &amp; close prices.
    /// </summary>
    public bool? SupportsOhlc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supportsOhlc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supportsOhlc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        _ = this.SupportsOhlc;
    }

    public SportsGamePostsSearchContextSmartTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePostsSearchContextSmartTag(
        SportsGamePostsSearchContextSmartTag sportsGamePostsSearchContextSmartTag
    )
        : base(sportsGamePostsSearchContextSmartTag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePostsSearchContextSmartTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGamePostsSearchContextSmartTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGamePostsSearchContextSmartTagFromRaw.FromRawUnchecked"/>
    public static SportsGamePostsSearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGamePostsSearchContextSmartTagFromRaw
    : IFromRawJson<SportsGamePostsSearchContextSmartTag>
{
    /// <inheritdoc/>
    public SportsGamePostsSearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGamePostsSearchContextSmartTag.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SportsGamePostsSearchContext, SportsGamePostsSearchContextFromRaw>)
)]
public sealed record class SportsGamePostsSearchContext : JsonModel
{
    /// <summary>
    /// X's card for the cashtag the search names.
    /// </summary>
    public required SportsGamePostsSearchContextSmartTag SmartTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SportsGamePostsSearchContextSmartTag>("smartTag");
        }
        init { this._rawData.Set("smartTag", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SmartTag.Validate();
    }

    public SportsGamePostsSearchContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePostsSearchContext(SportsGamePostsSearchContext sportsGamePostsSearchContext)
        : base(sportsGamePostsSearchContext) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePostsSearchContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGamePostsSearchContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGamePostsSearchContextFromRaw.FromRawUnchecked"/>
    public static SportsGamePostsSearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGamePostsSearchContextFromRaw : IFromRawJson<SportsGamePostsSearchContext>
{
    /// <inheritdoc/>
    public SportsGamePostsSearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGamePostsSearchContext.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SportsGamePosts, SportsGamePostsFromRaw>))]
public sealed record class SportsGamePosts : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? FilteredCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("filtered_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtered_count", value);
        }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.SearchTweet2> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SearchTweet2>
            >("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SearchTweet2>>(
                "tweets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Cursor for the next page. Send it unchanged. Each next page arrives fast.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <summary>
    /// The UTC time this filtered search has reached.
    /// </summary>
    public DateTimeOffset? ReadBackTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("readBackTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("readBackTo", value);
        }
    }

    /// <summary>
    /// Present on a last page whose sources all read past its start time.
    /// </summary>
    public bool? WindowComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("windowComplete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("windowComplete", value);
        }
    }

    /// <summary>
    /// The query that ran, when it differs from your q.
    /// </summary>
    public string? SearchedQuery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("searchedQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchedQuery", value);
        }
    }

    /// <summary>
    /// What X shows beside a search's posts, the same for everyone. Present on a search for a cashtag X has a card for, such as $BTC. Cashtag searches add X's ticker card in `searchContext`.
    /// </summary>
    public SportsGamePostsSearchContext? SearchContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SportsGamePostsSearchContext>("searchContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchContext", value);
        }
    }

    /// <summary>
    /// An X search for this game's posts, in the order asked. Send it to GET /x/tweets/search for more filters. Null when no search is available.
    /// </summary>
    public required string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FilteredCount;
        foreach (var item in this.Tweets)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
        _ = this.ReadBackTo;
        _ = this.WindowComplete;
        _ = this.SearchedQuery;
        this.SearchContext?.Validate();
        _ = this.Query;
    }

    public SportsGamePosts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePosts(SportsGamePosts sportsGamePosts)
        : base(sportsGamePosts) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGamePosts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGamePosts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGamePostsFromRaw.FromRawUnchecked"/>
    public static SportsGamePosts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGamePostsFromRaw : IFromRawJson<SportsGamePosts>
{
    /// <inheritdoc/>
    public SportsGamePosts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SportsGamePosts.FromRawUnchecked(rawData);
}
