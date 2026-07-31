using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// Tweet returned from search results with inline author info. A zero metric can
/// mean X did not report the count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweet, SearchTweetFromRaw>))]
public sealed record class SearchTweet : JsonModel
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
    public SearchTweetArticle? Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetArticle>("article");
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
    /// X user profile with bio, follower counts, and verification status.
    /// </summary>
    public UserProfile? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfile>("author");
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
    public SearchTweetCard? Card
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetCard>("card");
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
    public SearchTweetCommunityNote? CommunityNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetCommunityNote>("communityNote");
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
    /// Root tweet ID for the search result conversation
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
    /// Rendered text's start and end offsets.
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
    public SearchTweetEdit? Edit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetEdit>("edit");
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
    /// Parsed search-result entities including URLs, mentions, hashtags, and media markers
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
    /// ID of the tweet this result replies to.
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
    /// ID of the user this result replies to.
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
    /// Username this result replies to.
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
    /// Whether the tweet has limited reply permissions
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

    /// <summary>
    /// True when this search result quotes another tweet
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
    /// True when this search result is a reply
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
    /// Search result language code.
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
    /// Search-result media attachments, omitted when no media is present
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
    public SearchTweetNoteTweet? NoteTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetNoteTweet>("noteTweet");
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
    public SearchTweetPlace? Place
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetPlace>("place");
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
    public SearchTweetPreviousCounts? PreviousCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetPreviousCounts>("previousCounts");
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
    /// Client application used to post the tweet
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
    /// Search result permalink.
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

    public SearchTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet(SearchTweet searchTweet)
        : base(searchTweet) { }
#pragma warning restore CS8618

    public SearchTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetFromRaw.FromRawUnchecked"/>
    public static SearchTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetFromRaw : IFromRawJson<SearchTweet>
{
    /// <inheritdoc/>
    public SearchTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweet.FromRawUnchecked(rawData);
}

/// <summary>
/// Article metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweetArticle, SearchTweetArticleFromRaw>))]
public sealed record class SearchTweetArticle : JsonModel
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

    public SearchTweetArticle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetArticle(SearchTweetArticle searchTweetArticle)
        : base(searchTweetArticle) { }
#pragma warning restore CS8618

    public SearchTweetArticle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetArticle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetArticleFromRaw.FromRawUnchecked"/>
    public static SearchTweetArticle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetArticleFromRaw : IFromRawJson<SearchTweetArticle>
{
    /// <inheritdoc/>
    public SearchTweetArticle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweetArticle.FromRawUnchecked(rawData);
}

/// <summary>
/// Public card metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweetCard, SearchTweetCardFromRaw>))]
public sealed record class SearchTweetCard : JsonModel
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

    public SearchTweetCard() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetCard(SearchTweetCard searchTweetCard)
        : base(searchTweetCard) { }
#pragma warning restore CS8618

    public SearchTweetCard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetCard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetCardFromRaw.FromRawUnchecked"/>
    public static SearchTweetCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetCardFromRaw : IFromRawJson<SearchTweetCard>
{
    /// <inheritdoc/>
    public SearchTweetCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweetCard.FromRawUnchecked(rawData);
}

/// <summary>
/// Community Note presentation metadata returned by X.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SearchTweetCommunityNote, SearchTweetCommunityNoteFromRaw>)
)]
public sealed record class SearchTweetCommunityNote : JsonModel
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

    public SearchTweetCommunityNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetCommunityNote(SearchTweetCommunityNote searchTweetCommunityNote)
        : base(searchTweetCommunityNote) { }
#pragma warning restore CS8618

    public SearchTweetCommunityNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetCommunityNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetCommunityNoteFromRaw.FromRawUnchecked"/>
    public static SearchTweetCommunityNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetCommunityNoteFromRaw : IFromRawJson<SearchTweetCommunityNote>
{
    /// <inheritdoc/>
    public SearchTweetCommunityNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetCommunityNote.FromRawUnchecked(rawData);
}

/// <summary>
/// Edit history metadata returned by X.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweetEdit, SearchTweetEditFromRaw>))]
public sealed record class SearchTweetEdit : JsonModel
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

    public SearchTweetEdit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetEdit(SearchTweetEdit searchTweetEdit)
        : base(searchTweetEdit) { }
#pragma warning restore CS8618

    public SearchTweetEdit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetEdit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetEditFromRaw.FromRawUnchecked"/>
    public static SearchTweetEdit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetEditFromRaw : IFromRawJson<SearchTweetEdit>
{
    /// <inheritdoc/>
    public SearchTweetEdit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweetEdit.FromRawUnchecked(rawData);
}

/// <summary>
/// Complete Note Tweet content and rich-text metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweetNoteTweet, SearchTweetNoteTweetFromRaw>))]
public sealed record class SearchTweetNoteTweet : JsonModel
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

    public IReadOnlyList<SearchTweetNoteTweetRichtextTag>? RichtextTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweetNoteTweetRichtextTag>>(
                "richtextTags"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetNoteTweetRichtextTag>?>(
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

    public SearchTweetNoteTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetNoteTweet(SearchTweetNoteTweet searchTweetNoteTweet)
        : base(searchTweetNoteTweet) { }
#pragma warning restore CS8618

    public SearchTweetNoteTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetNoteTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetNoteTweetFromRaw.FromRawUnchecked"/>
    public static SearchTweetNoteTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SearchTweetNoteTweet(string text)
        : this()
    {
        this.Text = text;
    }
}

class SearchTweetNoteTweetFromRaw : IFromRawJson<SearchTweetNoteTweet>
{
    /// <inheritdoc/>
    public SearchTweetNoteTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetNoteTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetNoteTweetRichtextTag,
        SearchTweetNoteTweetRichtextTagFromRaw
    >)
)]
public sealed record class SearchTweetNoteTweetRichtextTag : JsonModel
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

    public SearchTweetNoteTweetRichtextTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetNoteTweetRichtextTag(
        SearchTweetNoteTweetRichtextTag searchTweetNoteTweetRichtextTag
    )
        : base(searchTweetNoteTweetRichtextTag) { }
#pragma warning restore CS8618

    public SearchTweetNoteTweetRichtextTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetNoteTweetRichtextTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetNoteTweetRichtextTagFromRaw.FromRawUnchecked"/>
    public static SearchTweetNoteTweetRichtextTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetNoteTweetRichtextTagFromRaw : IFromRawJson<SearchTweetNoteTweetRichtextTag>
{
    /// <inheritdoc/>
    public SearchTweetNoteTweetRichtextTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetNoteTweetRichtextTag.FromRawUnchecked(rawData);
}

/// <summary>
/// Public place metadata attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SearchTweetPlace, SearchTweetPlaceFromRaw>))]
public sealed record class SearchTweetPlace : JsonModel
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

    public SearchTweetPlace() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetPlace(SearchTweetPlace searchTweetPlace)
        : base(searchTweetPlace) { }
#pragma warning restore CS8618

    public SearchTweetPlace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetPlace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetPlaceFromRaw.FromRawUnchecked"/>
    public static SearchTweetPlace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetPlaceFromRaw : IFromRawJson<SearchTweetPlace>
{
    /// <inheritdoc/>
    public SearchTweetPlace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweetPlace.FromRawUnchecked(rawData);
}

/// <summary>
/// Engagement counts retained from a prior tweet edit.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SearchTweetPreviousCounts, SearchTweetPreviousCountsFromRaw>)
)]
public sealed record class SearchTweetPreviousCounts : JsonModel
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

    public SearchTweetPreviousCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetPreviousCounts(SearchTweetPreviousCounts searchTweetPreviousCounts)
        : base(searchTweetPreviousCounts) { }
#pragma warning restore CS8618

    public SearchTweetPreviousCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetPreviousCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetPreviousCountsFromRaw.FromRawUnchecked"/>
    public static SearchTweetPreviousCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetPreviousCountsFromRaw : IFromRawJson<SearchTweetPreviousCounts>
{
    /// <inheritdoc/>
    public SearchTweetPreviousCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetPreviousCounts.FromRawUnchecked(rawData);
}
