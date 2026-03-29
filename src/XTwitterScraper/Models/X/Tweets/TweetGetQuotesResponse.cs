using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetGetQuotesResponse, TweetGetQuotesResponseFromRaw>))]
public sealed record class TweetGetQuotesResponse : JsonModel
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

    public required IReadOnlyList<TweetGetQuotesResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TweetGetQuotesResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetGetQuotesResponseTweet>>(
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

    public TweetGetQuotesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetQuotesResponse(TweetGetQuotesResponse tweetGetQuotesResponse)
        : base(tweetGetQuotesResponse) { }
#pragma warning restore CS8618

    public TweetGetQuotesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetQuotesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetQuotesResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetQuotesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetQuotesResponseFromRaw : IFromRawJson<TweetGetQuotesResponse>
{
    /// <inheritdoc/>
    public TweetGetQuotesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetQuotesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetGetQuotesResponseTweet, TweetGetQuotesResponseTweetFromRaw>)
)]
public sealed record class TweetGetQuotesResponseTweet : JsonModel
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

    public TweetGetQuotesResponseTweetAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetGetQuotesResponseTweetAuthor>("author");
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
        _ = this.LikeCount;
        _ = this.QuoteCount;
        _ = this.ReplyCount;
        _ = this.RetweetCount;
        _ = this.ViewCount;
    }

    public TweetGetQuotesResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetQuotesResponseTweet(TweetGetQuotesResponseTweet tweetGetQuotesResponseTweet)
        : base(tweetGetQuotesResponseTweet) { }
#pragma warning restore CS8618

    public TweetGetQuotesResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetQuotesResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetQuotesResponseTweetFromRaw.FromRawUnchecked"/>
    public static TweetGetQuotesResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetQuotesResponseTweetFromRaw : IFromRawJson<TweetGetQuotesResponseTweet>
{
    /// <inheritdoc/>
    public TweetGetQuotesResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetQuotesResponseTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetGetQuotesResponseTweetAuthor,
        TweetGetQuotesResponseTweetAuthorFromRaw
    >)
)]
public sealed record class TweetGetQuotesResponseTweetAuthor : JsonModel
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

    public TweetGetQuotesResponseTweetAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetQuotesResponseTweetAuthor(
        TweetGetQuotesResponseTweetAuthor tweetGetQuotesResponseTweetAuthor
    )
        : base(tweetGetQuotesResponseTweetAuthor) { }
#pragma warning restore CS8618

    public TweetGetQuotesResponseTweetAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetQuotesResponseTweetAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetQuotesResponseTweetAuthorFromRaw.FromRawUnchecked"/>
    public static TweetGetQuotesResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetQuotesResponseTweetAuthorFromRaw : IFromRawJson<TweetGetQuotesResponseTweetAuthor>
{
    /// <inheritdoc/>
    public TweetGetQuotesResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetQuotesResponseTweetAuthor.FromRawUnchecked(rawData);
}
