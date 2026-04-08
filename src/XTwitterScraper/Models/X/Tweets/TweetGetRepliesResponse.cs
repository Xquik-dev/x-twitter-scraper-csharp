using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Paginated list of tweets with cursor-based navigation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetGetRepliesResponse, TweetGetRepliesResponseFromRaw>))]
public sealed record class TweetGetRepliesResponse : JsonModel
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

    public required IReadOnlyList<TweetGetRepliesResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TweetGetRepliesResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetGetRepliesResponseTweet>>(
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

    public TweetGetRepliesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRepliesResponse(TweetGetRepliesResponse tweetGetRepliesResponse)
        : base(tweetGetRepliesResponse) { }
#pragma warning restore CS8618

    public TweetGetRepliesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetRepliesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetRepliesResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetRepliesResponseFromRaw : IFromRawJson<TweetGetRepliesResponse>
{
    /// <inheritdoc/>
    public TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Tweet returned from search results with inline author info.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetGetRepliesResponseTweet, TweetGetRepliesResponseTweetFromRaw>)
)]
public sealed record class TweetGetRepliesResponseTweet : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public TweetGetRepliesResponseTweetAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetGetRepliesResponseTweetAuthor>("author");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author", value);
        }
    }

    public long? BookmarkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bookmarkCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bookmarkCount", value);
        }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// True for Note Tweets (long-form content, up to 25,000 characters)
    /// </summary>
    public bool? IsNoteTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isNoteTweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isNoteTweet", value);
        }
    }

    public long? LikeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("likeCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("likeCount", value);
        }
    }

    public long? QuoteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quoteCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quoteCount", value);
        }
    }

    public long? ReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("replyCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyCount", value);
        }
    }

    public long? RetweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retweetCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retweetCount", value);
        }
    }

    public long? ViewCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("viewCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Text;
        this.Author?.Validate();
        _ = this.BookmarkCount;
        _ = this.CreatedAt;
        _ = this.IsNoteTweet;
        _ = this.LikeCount;
        _ = this.QuoteCount;
        _ = this.ReplyCount;
        _ = this.RetweetCount;
        _ = this.ViewCount;
    }

    public TweetGetRepliesResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRepliesResponseTweet(TweetGetRepliesResponseTweet tweetGetRepliesResponseTweet)
        : base(tweetGetRepliesResponseTweet) { }
#pragma warning restore CS8618

    public TweetGetRepliesResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetRepliesResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetRepliesResponseTweetFromRaw.FromRawUnchecked"/>
    public static TweetGetRepliesResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetRepliesResponseTweetFromRaw : IFromRawJson<TweetGetRepliesResponseTweet>
{
    /// <inheritdoc/>
    public TweetGetRepliesResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponseTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetGetRepliesResponseTweetAuthor,
        TweetGetRepliesResponseTweetAuthorFromRaw
    >)
)]
public sealed record class TweetGetRepliesResponseTweetAuthor : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public bool? Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Username;
        _ = this.Verified;
    }

    public TweetGetRepliesResponseTweetAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRepliesResponseTweetAuthor(
        TweetGetRepliesResponseTweetAuthor tweetGetRepliesResponseTweetAuthor
    )
        : base(tweetGetRepliesResponseTweetAuthor) { }
#pragma warning restore CS8618

    public TweetGetRepliesResponseTweetAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetRepliesResponseTweetAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetRepliesResponseTweetAuthorFromRaw.FromRawUnchecked"/>
    public static TweetGetRepliesResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetRepliesResponseTweetAuthorFromRaw : IFromRawJson<TweetGetRepliesResponseTweetAuthor>
{
    /// <inheritdoc/>
    public TweetGetRepliesResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponseTweetAuthor.FromRawUnchecked(rawData);
}
