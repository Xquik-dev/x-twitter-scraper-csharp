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

[JsonConverter(typeof(JsonModelConverter<BatchUserTweets, BatchUserTweetsFromRaw>))]
public sealed record class BatchUserTweets : JsonModel
{
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

    /// <summary>
    /// Always false. The answer holds every post in 1 page.
    /// </summary>
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
    /// Always empty. The answer holds every post in 1 page.
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
    /// Users with no account on X or with protected posts, in first-seen request order. They cost nothing.
    /// </summary>
    public required IReadOnlyList<string> UnavailableIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("unavailable_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "unavailable_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Users the call did not read, in first-seen request order. Their read failed, the call ran out of time or credits ran out. They cost nothing. Send them again.
    /// </summary>
    public required IReadOnlyList<string> UnprocessedIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("unprocessed_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "unprocessed_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tweets)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
        _ = this.UnavailableIDs;
        _ = this.UnprocessedIDs;
    }

    public BatchUserTweets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchUserTweets(BatchUserTweets batchUserTweets)
        : base(batchUserTweets) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchUserTweets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchUserTweets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchUserTweetsFromRaw.FromRawUnchecked"/>
    public static BatchUserTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchUserTweetsFromRaw : IFromRawJson<BatchUserTweets>
{
    /// <inheritdoc/>
    public BatchUserTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchUserTweets.FromRawUnchecked(rawData);
}
