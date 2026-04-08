using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Models;

/// <summary>
/// Paginated list of tweets with cursor-based navigation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginatedTweets, PaginatedTweetsFromRaw>))]
public sealed record class PaginatedTweets : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    public required IReadOnlyList<SearchTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SearchTweet>>("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SearchTweet>>(
                "tweets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        foreach (var item in this.Tweets)
        {
            item.Validate();
        }
    }

    public PaginatedTweets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets(PaginatedTweets paginatedTweets)
        : base(paginatedTweets) { }
#pragma warning restore CS8618

    public PaginatedTweets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweetsFromRaw.FromRawUnchecked"/>
    public static PaginatedTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweetsFromRaw : IFromRawJson<PaginatedTweets>
{
    /// <inheritdoc/>
    public PaginatedTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedTweets.FromRawUnchecked(rawData);
}
