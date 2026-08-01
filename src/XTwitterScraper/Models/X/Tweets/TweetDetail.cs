using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Full tweet with text, engagement metrics, media, and metadata. A zero metric
/// can mean X did not report the count.
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
    /// Article metadata attached to a tweet.
    /// </summary>
    public Article? Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Article>("article");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("article", value);
        }
    }

    /// <summary>
    /// Tweet author profile. The lookup route always includes follower count and
    /// verification state. Other profile fields appear when available.
    /// </summary>
    public TweetAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAuthor>("author");
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

    /// <summary>
    /// Public card metadata attached to a tweet.
    /// </summary>
    public Card? Card
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Card>("card");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("card", value);
        }
    }

    /// <summary>
    /// Community Note presentation metadata returned by X.
    /// </summary>
    public CommunityNote? CommunityNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityNote>("communityNote");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityNote", value);
        }
    }

    /// <summary>
    /// Content disclosure metadata shown by X when a tweet is labeled as paid partnership
    /// content or AI-generated media.
    /// </summary>
    public ContentDisclosure? ContentDisclosure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContentDisclosure>("contentDisclosure");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentDisclosure", value);
        }
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
    /// Start and end offsets for rendered tweet text
    /// </summary>
    public IReadOnlyList<long>? DisplayTextRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("displayTextRange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "displayTextRange",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Edit history metadata returned by X.
    /// </summary>
    public Edit? Edit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Edit>("edit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edit", value);
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
    /// Tweet ID being replied to
    /// </summary>
    public string? InReplyToID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToId", value);
        }
    }

    /// <summary>
    /// User ID being replied to
    /// </summary>
    public string? InReplyToUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToUserId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToUserId", value);
        }
    }

    /// <summary>
    /// Username being replied to
    /// </summary>
    public string? InReplyToUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToUsername", value);
        }
    }

    /// <summary>
    /// Whether replies are limited for this tweet
    /// </summary>
    public bool? IsLimitedReply
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isLimitedReply");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isLimitedReply", value);
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

    public bool? IsTranslatable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslatable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslatable", value);
        }
    }

    /// <summary>
    /// Tweet language code
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lang");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lang", value);
        }
    }

    /// <summary>
    /// Attached media items, omitted when the tweet has no media
    /// </summary>
    public IReadOnlyList<TweetMedia>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetMedia>>("media");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetMedia>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Complete Note Tweet content and rich-text metadata.
    /// </summary>
    public NoteTweet? NoteTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NoteTweet>("noteTweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("noteTweet", value);
        }
    }

    /// <summary>
    /// Public place metadata attached to a tweet.
    /// </summary>
    public Place? Place
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Place>("place");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("place", value);
        }
    }

    public bool? PossiblySensitive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("possiblySensitive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("possiblySensitive", value);
        }
    }

    /// <summary>
    /// Engagement counts retained from a prior tweet edit.
    /// </summary>
    public PreviousCounts? PreviousCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PreviousCounts>("previousCounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previousCounts", value);
        }
    }

    /// <summary>
    /// Quoted or retweeted tweet context. Every object includes id, text, and engagement
    /// metrics. A zero metric can mean X did not report the count. Author, media,
    /// and conversation fields appear when available.
    /// </summary>
    public EmbeddedTweet? QuotedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweet>("quoted_tweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quoted_tweet", value);
        }
    }

    /// <summary>
    /// Quoted or retweeted tweet context. Every object includes id, text, and engagement
    /// metrics. A zero metric can mean X did not report the count. Author, media,
    /// and conversation fields appear when available.
    /// </summary>
    public EmbeddedTweet? RetweetedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweet>("retweeted_tweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retweeted_tweet", value);
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

    /// <summary>
    /// Tweet result type
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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

    /// <summary>
    /// Tweet permalink URL
    /// </summary>
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

    public string? ViewState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("viewState");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewState", value);
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
        this.Article?.Validate();
        this.Author?.Validate();
        this.Card?.Validate();
        this.CommunityNote?.Validate();
        this.ContentDisclosure?.Validate();
        _ = this.ConversationID;
        _ = this.CreatedAt;
        _ = this.DisplayTextRange;
        this.Edit?.Validate();
        _ = this.Entities;
        _ = this.InReplyToID;
        _ = this.InReplyToUserID;
        _ = this.InReplyToUsername;
        _ = this.IsLimitedReply;
        _ = this.IsNoteTweet;
        _ = this.IsQuoteStatus;
        _ = this.IsReply;
        _ = this.IsTranslatable;
        _ = this.Lang;
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        this.NoteTweet?.Validate();
        this.Place?.Validate();
        _ = this.PossiblySensitive;
        this.PreviousCounts?.Validate();
        this.QuotedTweet?.Validate();
        this.RetweetedTweet?.Validate();
        _ = this.Source;
        _ = this.Type;
        _ = this.Url;
        _ = this.ViewState;
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

/// <summary>
/// Article metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Article, ArticleFromRaw>))]
public sealed record class Article : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? CoverMediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("coverMediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coverMediaUrl", value);
        }
    }

    public string? PreviewText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previewText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previewText", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CoverMediaUrl;
        _ = this.PreviewText;
        _ = this.Title;
    }

    public Article() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Article(Article article)
        : base(article) { }
#pragma warning restore CS8618

    public Article(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Article(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArticleFromRaw.FromRawUnchecked"/>
    public static Article FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArticleFromRaw : IFromRawJson<Article>
{
    /// <inheritdoc/>
    public Article FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Article.FromRawUnchecked(rawData);
}

/// <summary>
/// Public card metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Card, CardFromRaw>))]
public sealed record class Card : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? BindingValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "bindingValues"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "bindingValues",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        _ = this.ID;
        _ = this.BindingValues;
        _ = this.Name;
        _ = this.Url;
    }

    public Card() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Card(Card card)
        : base(card) { }
#pragma warning restore CS8618

    public Card(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Card(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardFromRaw.FromRawUnchecked"/>
    public static Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardFromRaw : IFromRawJson<Card>
{
    /// <inheritdoc/>
    public Card FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Card.FromRawUnchecked(rawData);
}

/// <summary>
/// Community Note presentation metadata returned by X.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CommunityNote, CommunityNoteFromRaw>))]
public sealed record class CommunityNote : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? DestinationUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destinationUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationUrl", value);
        }
    }

    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footer", value);
        }
    }

    public string? ShortTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortTitle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shortTitle", value);
        }
    }

    public string? Subtitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subtitle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subtitle", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    public string? VisualStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("visualStyle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("visualStyle", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DestinationUrl;
        _ = this.Footer;
        _ = this.ShortTitle;
        _ = this.Subtitle;
        _ = this.Title;
        _ = this.VisualStyle;
    }

    public CommunityNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNote(CommunityNote communityNote)
        : base(communityNote) { }
#pragma warning restore CS8618

    public CommunityNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNoteFromRaw.FromRawUnchecked"/>
    public static CommunityNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNoteFromRaw : IFromRawJson<CommunityNote>
{
    /// <inheritdoc/>
    public CommunityNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityNote.FromRawUnchecked(rawData);
}

/// <summary>
/// Edit history metadata returned by X.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Edit, EditFromRaw>))]
public sealed record class Edit : JsonModel
{
    public string? EditableUntilMsecs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("editableUntilMsecs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("editableUntilMsecs", value);
        }
    }

    public IReadOnlyList<string>? EditTweetIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("editTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "editTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EditableUntilMsecs;
        _ = this.EditTweetIds;
    }

    public Edit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Edit(Edit edit)
        : base(edit) { }
#pragma warning restore CS8618

    public Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EditFromRaw.FromRawUnchecked"/>
    public static Edit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EditFromRaw : IFromRawJson<Edit>
{
    /// <inheritdoc/>
    public Edit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Edit.FromRawUnchecked(rawData);
}

/// <summary>
/// Complete Note Tweet content and rich-text metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NoteTweet, NoteTweetFromRaw>))]
public sealed record class NoteTweet : JsonModel
{
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

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

    public bool? IsExpandable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isExpandable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isExpandable", value);
        }
    }

    public IReadOnlyList<RichtextTag>? RichtextTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RichtextTag>>("richtextTags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RichtextTag>?>(
                "richtextTags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.ID;
        _ = this.Entities;
        _ = this.IsExpandable;
        foreach (var item in this.RichtextTags ?? [])
        {
            item.Validate();
        }
    }

    public NoteTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoteTweet(NoteTweet noteTweet)
        : base(noteTweet) { }
#pragma warning restore CS8618

    public NoteTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoteTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoteTweetFromRaw.FromRawUnchecked"/>
    public static NoteTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NoteTweet(string text)
        : this()
    {
        this.Text = text;
    }
}

class NoteTweetFromRaw : IFromRawJson<NoteTweet>
{
    /// <inheritdoc/>
    public NoteTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NoteTweet.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RichtextTag, RichtextTagFromRaw>))]
public sealed record class RichtextTag : JsonModel
{
    public required long FromIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fromIndex");
        }
        init { this._rawData.Set("fromIndex", value); }
    }

    public required long ToIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("toIndex");
        }
        init { this._rawData.Set("toIndex", value); }
    }

    public required IReadOnlyList<string> Types
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromIndex;
        _ = this.ToIndex;
        _ = this.Types;
    }

    public RichtextTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RichtextTag(RichtextTag richtextTag)
        : base(richtextTag) { }
#pragma warning restore CS8618

    public RichtextTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RichtextTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RichtextTagFromRaw.FromRawUnchecked"/>
    public static RichtextTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RichtextTagFromRaw : IFromRawJson<RichtextTag>
{
    /// <inheritdoc/>
    public RichtextTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RichtextTag.FromRawUnchecked(rawData);
}

/// <summary>
/// Public place metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Place, PlaceFromRaw>))]
public sealed record class Place : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? BoundingBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "boundingBox"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "boundingBox",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    public string? FullName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fullName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fullName", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? PlaceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("placeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("placeType", value);
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
        _ = this.ID;
        _ = this.BoundingBox;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.FullName;
        _ = this.Name;
        _ = this.PlaceType;
        _ = this.Url;
    }

    public Place() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Place(Place place)
        : base(place) { }
#pragma warning restore CS8618

    public Place(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Place(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceFromRaw.FromRawUnchecked"/>
    public static Place FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceFromRaw : IFromRawJson<Place>
{
    /// <inheritdoc/>
    public Place FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Place.FromRawUnchecked(rawData);
}

/// <summary>
/// Engagement counts retained from a prior tweet edit.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviousCounts, PreviousCountsFromRaw>))]
public sealed record class PreviousCounts : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BookmarkCount;
        _ = this.LikeCount;
        _ = this.QuoteCount;
        _ = this.ReplyCount;
        _ = this.RetweetCount;
    }

    public PreviousCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviousCounts(PreviousCounts previousCounts)
        : base(previousCounts) { }
#pragma warning restore CS8618

    public PreviousCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviousCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviousCountsFromRaw.FromRawUnchecked"/>
    public static PreviousCounts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviousCountsFromRaw : IFromRawJson<PreviousCounts>
{
    /// <inheritdoc/>
    public PreviousCounts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviousCounts.FromRawUnchecked(rawData);
}
