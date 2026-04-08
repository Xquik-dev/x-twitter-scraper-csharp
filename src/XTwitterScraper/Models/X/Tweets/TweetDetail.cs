using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Full tweet with text, engagement metrics, media, and metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetDetail, TweetDetailFromRaw>))]
public sealed record class TweetDetail : JsonModel
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

    /// <summary>
    /// ID of the root tweet in the conversation thread
    /// </summary>
    public string? ConversationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("conversationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationId", value);
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
    /// Parsed entities from the tweet text (URLs, mentions, hashtags, media)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "entities"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "entities",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether this is a Note Tweet (long-form post, up to 25,000 characters)
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

    /// <summary>
    /// Whether this tweet quotes another tweet
    /// </summary>
    public bool? IsQuoteStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isQuoteStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isQuoteStatus", value);
        }
    }

    /// <summary>
    /// Whether this tweet is a reply to another tweet
    /// </summary>
    public bool? IsReply
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isReply");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isReply", value);
        }
    }

    /// <summary>
    /// Attached media items, omitted when the tweet has no media
    /// </summary>
    public IReadOnlyList<TweetDetailMedia>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetDetailMedia>>("media");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailMedia>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The quoted tweet object, present when isQuoteStatus is true
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? QuotedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "quoted_tweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "quoted_tweet",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Client application used to post this tweet
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
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
        _ = this.ConversationID;
        _ = this.CreatedAt;
        _ = this.Entities;
        _ = this.IsNoteTweet;
        _ = this.IsQuoteStatus;
        _ = this.IsReply;
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.QuotedTweet;
        _ = this.Source;
    }

    public TweetDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetail(TweetDetail tweetDetail)
        : base(tweetDetail) { }
#pragma warning restore CS8618

    public TweetDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailFromRaw.FromRawUnchecked"/>
    public static TweetDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailFromRaw : IFromRawJson<TweetDetail>
{
    /// <inheritdoc/>
    public TweetDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetDetail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetDetailMedia, TweetDetailMediaFromRaw>))]
public sealed record class TweetDetailMedia : JsonModel
{
    public string? MediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaUrl", value);
        }
    }

    public ApiEnum<string, global::XTwitterScraper.Models.X.Tweets.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::XTwitterScraper.Models.X.Tweets.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaUrl;
        this.Type?.Validate();
        _ = this.Url;
    }

    public TweetDetailMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailMedia(TweetDetailMedia tweetDetailMedia)
        : base(tweetDetailMedia) { }
#pragma warning restore CS8618

    public TweetDetailMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailMediaFromRaw.FromRawUnchecked"/>
    public static TweetDetailMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailMediaFromRaw : IFromRawJson<TweetDetailMedia>
{
    /// <inheritdoc/>
    public TweetDetailMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetDetailMedia.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Photo,
    Video,
    AnimatedGif,
}

sealed class TypeConverter : JsonConverter<global::XTwitterScraper.Models.X.Tweets.Type>
{
    public override global::XTwitterScraper.Models.X.Tweets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "photo" => global::XTwitterScraper.Models.X.Tweets.Type.Photo,
            "video" => global::XTwitterScraper.Models.X.Tweets.Type.Video,
            "animated_gif" => global::XTwitterScraper.Models.X.Tweets.Type.AnimatedGif,
            _ => (global::XTwitterScraper.Models.X.Tweets.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::XTwitterScraper.Models.X.Tweets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::XTwitterScraper.Models.X.Tweets.Type.Photo => "photo",
                global::XTwitterScraper.Models.X.Tweets.Type.Video => "video",
                global::XTwitterScraper.Models.X.Tweets.Type.AnimatedGif => "animated_gif",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
