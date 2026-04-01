using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetRetrieveResponse, TweetRetrieveResponseFromRaw>))]
public sealed record class TweetRetrieveResponse : JsonModel
{
    public required Tweet Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Tweet>("tweet");
        }
        init { this._rawData.Set("tweet", value); }
    }

    public TweetRetrieveResponseAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetRetrieveResponseAuthor>("author");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Tweet.Validate();
        this.Author?.Validate();
    }

    public TweetRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetRetrieveResponse(TweetRetrieveResponse tweetRetrieveResponse)
        : base(tweetRetrieveResponse) { }
#pragma warning restore CS8618

    public TweetRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TweetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TweetRetrieveResponse(Tweet tweet)
        : this()
    {
        this.Tweet = tweet;
    }
}

class TweetRetrieveResponseFromRaw : IFromRawJson<TweetRetrieveResponse>
{
    /// <inheritdoc/>
    public TweetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Tweet, TweetFromRaw>))]
public sealed record class Tweet : JsonModel
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

    public required long BookmarkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bookmarkCount");
        }
        init { this._rawData.Set("bookmarkCount", value); }
    }

    public required long LikeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("likeCount");
        }
        init { this._rawData.Set("likeCount", value); }
    }

    public required long QuoteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quoteCount");
        }
        init { this._rawData.Set("quoteCount", value); }
    }

    public required long ReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("replyCount");
        }
        init { this._rawData.Set("replyCount", value); }
    }

    public required long RetweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("retweetCount");
        }
        init { this._rawData.Set("retweetCount", value); }
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

    public required long ViewCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("viewCount");
        }
        init { this._rawData.Set("viewCount", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BookmarkCount;
        _ = this.LikeCount;
        _ = this.QuoteCount;
        _ = this.ReplyCount;
        _ = this.RetweetCount;
        _ = this.Text;
        _ = this.ViewCount;
        _ = this.CreatedAt;
    }

    public Tweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tweet(Tweet tweet)
        : base(tweet) { }
#pragma warning restore CS8618

    public Tweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetFromRaw.FromRawUnchecked"/>
    public static Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetFromRaw : IFromRawJson<Tweet>
{
    /// <inheritdoc/>
    public Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetRetrieveResponseAuthor, TweetRetrieveResponseAuthorFromRaw>)
)]
public sealed record class TweetRetrieveResponseAuthor : JsonModel
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

    public required long Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("followers");
        }
        init { this._rawData.Set("followers", value); }
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

    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Followers;
        _ = this.Username;
        _ = this.Verified;
        _ = this.ProfilePicture;
    }

    public TweetRetrieveResponseAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetRetrieveResponseAuthor(TweetRetrieveResponseAuthor tweetRetrieveResponseAuthor)
        : base(tweetRetrieveResponseAuthor) { }
#pragma warning restore CS8618

    public TweetRetrieveResponseAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetRetrieveResponseAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetRetrieveResponseAuthorFromRaw.FromRawUnchecked"/>
    public static TweetRetrieveResponseAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetRetrieveResponseAuthorFromRaw : IFromRawJson<TweetRetrieveResponseAuthor>
{
    /// <inheritdoc/>
    public TweetRetrieveResponseAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetRetrieveResponseAuthor.FromRawUnchecked(rawData);
}
