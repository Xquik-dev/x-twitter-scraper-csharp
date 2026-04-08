using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Users;

/// <summary>
/// Paginated list of tweets with cursor-based navigation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserRetrieveMediaResponse, UserRetrieveMediaResponseFromRaw>)
)]
public sealed record class UserRetrieveMediaResponse : JsonModel
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

    public required IReadOnlyList<UserRetrieveMediaResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserRetrieveMediaResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserRetrieveMediaResponseTweet>>(
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

    public UserRetrieveMediaResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveMediaResponse(UserRetrieveMediaResponse userRetrieveMediaResponse)
        : base(userRetrieveMediaResponse) { }
#pragma warning restore CS8618

    public UserRetrieveMediaResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveMediaResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveMediaResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveMediaResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveMediaResponseFromRaw : IFromRawJson<UserRetrieveMediaResponse>
{
    /// <inheritdoc/>
    public UserRetrieveMediaResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveMediaResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Tweet returned from search results with inline author info.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserRetrieveMediaResponseTweet,
        UserRetrieveMediaResponseTweetFromRaw
    >)
)]
public sealed record class UserRetrieveMediaResponseTweet : JsonModel
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

    public UserRetrieveMediaResponseTweetAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserRetrieveMediaResponseTweetAuthor>("author");
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

    public UserRetrieveMediaResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveMediaResponseTweet(
        UserRetrieveMediaResponseTweet userRetrieveMediaResponseTweet
    )
        : base(userRetrieveMediaResponseTweet) { }
#pragma warning restore CS8618

    public UserRetrieveMediaResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveMediaResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveMediaResponseTweetFromRaw.FromRawUnchecked"/>
    public static UserRetrieveMediaResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveMediaResponseTweetFromRaw : IFromRawJson<UserRetrieveMediaResponseTweet>
{
    /// <inheritdoc/>
    public UserRetrieveMediaResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveMediaResponseTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UserRetrieveMediaResponseTweetAuthor,
        UserRetrieveMediaResponseTweetAuthorFromRaw
    >)
)]
public sealed record class UserRetrieveMediaResponseTweetAuthor : JsonModel
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

    public UserRetrieveMediaResponseTweetAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveMediaResponseTweetAuthor(
        UserRetrieveMediaResponseTweetAuthor userRetrieveMediaResponseTweetAuthor
    )
        : base(userRetrieveMediaResponseTweetAuthor) { }
#pragma warning restore CS8618

    public UserRetrieveMediaResponseTweetAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveMediaResponseTweetAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveMediaResponseTweetAuthorFromRaw.FromRawUnchecked"/>
    public static UserRetrieveMediaResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveMediaResponseTweetAuthorFromRaw
    : IFromRawJson<UserRetrieveMediaResponseTweetAuthor>
{
    /// <inheritdoc/>
    public UserRetrieveMediaResponseTweetAuthor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveMediaResponseTweetAuthor.FromRawUnchecked(rawData);
}
