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
        PaginatedTweets2SearchContextSmartTag,
        PaginatedTweets2SearchContextSmartTagFromRaw
    >)
)]
public sealed record class PaginatedTweets2SearchContextSmartTag : JsonModel
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

    public PaginatedTweets2SearchContextSmartTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2SearchContextSmartTag(
        PaginatedTweets2SearchContextSmartTag paginatedTweets2SearchContextSmartTag
    )
        : base(paginatedTweets2SearchContextSmartTag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2SearchContextSmartTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweets2SearchContextSmartTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweets2SearchContextSmartTagFromRaw.FromRawUnchecked"/>
    public static PaginatedTweets2SearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweets2SearchContextSmartTagFromRaw
    : IFromRawJson<PaginatedTweets2SearchContextSmartTag>
{
    /// <inheritdoc/>
    public PaginatedTweets2SearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedTweets2SearchContextSmartTag.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PaginatedTweets2SearchContext, PaginatedTweets2SearchContextFromRaw>)
)]
public sealed record class PaginatedTweets2SearchContext : JsonModel
{
    /// <summary>
    /// X's card for the cashtag the search names.
    /// </summary>
    public required PaginatedTweets2SearchContextSmartTag SmartTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginatedTweets2SearchContextSmartTag>("smartTag");
        }
        init { this._rawData.Set("smartTag", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SmartTag.Validate();
    }

    public PaginatedTweets2SearchContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2SearchContext(
        PaginatedTweets2SearchContext paginatedTweets2SearchContext
    )
        : base(paginatedTweets2SearchContext) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2SearchContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweets2SearchContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweets2SearchContextFromRaw.FromRawUnchecked"/>
    public static PaginatedTweets2SearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweets2SearchContextFromRaw : IFromRawJson<PaginatedTweets2SearchContext>
{
    /// <inheritdoc/>
    public PaginatedTweets2SearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedTweets2SearchContext.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PaginatedTweets2, PaginatedTweets2FromRaw>))]
public sealed record class PaginatedTweets2 : JsonModel
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
    public PaginatedTweets2SearchContext? SearchContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginatedTweets2SearchContext>("searchContext");
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
    }

    public PaginatedTweets2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2(PaginatedTweets2 paginatedTweets2)
        : base(paginatedTweets2) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweets2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweets2FromRaw.FromRawUnchecked"/>
    public static PaginatedTweets2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweets2FromRaw : IFromRawJson<PaginatedTweets2>
{
    /// <inheritdoc/>
    public PaginatedTweets2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedTweets2.FromRawUnchecked(rawData);
}
