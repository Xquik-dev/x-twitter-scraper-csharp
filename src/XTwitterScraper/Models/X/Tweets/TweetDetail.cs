using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

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

    public bool? IsPinned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPinned");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPinned", value);
        }
    }

    public bool? IsRetweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isRetweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isRetweet", value);
        }
    }

    public string? QuotedTweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("quotedTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetId", value);
        }
    }

    /// <summary>
    /// The quoted post's link, kept when X withholds that post.
    /// </summary>
    public TweetDetailQuotedTweetPermalink? QuotedTweetPermalink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailQuotedTweetPermalink>(
                "quotedTweetPermalink"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetPermalink", value);
        }
    }

    /// <summary>
    /// Why X shows no quoted post. Omitted when X names no reason.
    /// </summary>
    public TweetDetailQuotedTweetUnavailable? QuotedTweetUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailQuotedTweetUnavailable>(
                "quotedTweetUnavailable"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetUnavailable", value);
        }
    }

    /// <summary>
    /// Repost event time in UTC. Null when unavailable. Omitted for other posts.
    /// </summary>
    public DateTimeOffset? RetweetedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("retweetedAt");
        }
        init { this._rawData.Set("retweetedAt", value); }
    }

    /// <summary>
    /// Reply policy &amp; conversation owner.
    /// </summary>
    public TweetDetailConversationControl? ConversationControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailConversationControl>(
                "conversationControl"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationControl", value);
        }
    }

    /// <summary>
    /// Public restrictions &amp; prompts.
    /// </summary>
    public IReadOnlyList<TweetDetailLimitedActions>? LimitedActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetDetailLimitedActions>>(
                "limitedActions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailLimitedActions>?>(
                "limitedActions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where `text` matches the search, on each row a search read. Offsets count code points of `text`, as `displayTextRange` does. Empty when the post holds no marked match. Highlights cover a post's first 280 characters.
    /// </summary>
    public IReadOnlyList<TweetDetailTextHighlights>? TextHighlights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetDetailTextHighlights>>(
                "textHighlights"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailTextHighlights>?>(
                "textHighlights",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Why the tweet has no author. X serves a suspended or deleted account as an unavailable user with a reason such as Suspended or NotFound. Omitted when the author is available.
    /// </summary>
    public global::XTwitterScraper.Models.TweetAuthorUnavailable? AuthorUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetAuthorUnavailable>(
                "authorUnavailable"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorUnavailable", value);
        }
    }

    /// <summary>
    /// The author's ID when X withholds the author's profile.
    /// </summary>
    public string? UnavailableAuthorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unavailableAuthorId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailableAuthorId", value);
        }
    }

    /// <summary>
    /// Price charts the author attached under the post, 1 per cashtag. Absent when the post has none. X may send a cashtag without a chart window.
    /// </summary>
    public IReadOnlyList<TweetDetailCashtagAttachments>? CashtagAttachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetDetailCashtagAttachments>>(
                "cashtagAttachments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailCashtagAttachments>?>(
                "cashtagAttachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Community ID.
    /// </summary>
    public string? CommunityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityId", value);
        }
    }

    /// <summary>
    /// Community name. Present when X sends it with the post.
    /// </summary>
    public string? CommunityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityName", value);
        }
    }

    /// <summary>
    /// Whether X holds Community Notes on the post, shown or not.
    /// </summary>
    public bool? HasCommunityNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasCommunityNotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasCommunityNotes", value);
        }
    }

    /// <summary>
    /// Marks a subscriber-only post with the creator whose subscription unlocks it. Non-subscribers get the preview text &amp; the subscribe link. Omitted on public posts.
    /// </summary>
    public global::XTwitterScraper.Models.TweetExclusiveContent? ExclusiveContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetExclusiveContent>(
                "exclusiveContent"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exclusiveContent", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokShareAttachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokShareAttachment"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokShareAttachment",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Grok's translation of the post, as X shows it.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokTranslatedPost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokTranslatedPost"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokTranslatedPost",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? JetfuelAttachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "jetfuelAttachment"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "jetfuelAttachment",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Author-published point, with longitude before latitude.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPoint? Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPoint>(
                "coordinates"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coordinates", value);
        }
    }

    /// <summary>
    /// Author-published point, with latitude before longitude.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPoint? Geo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPoint>("geo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geo", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? PostCta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("postCta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "postCta",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public post &amp; user this reaction references.
    /// </summary>
    public TweetDetailReactionContext? ReactionContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailReactionContext>("reactionContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactionContext", value);
        }
    }

    /// <summary>
    /// Game metadata attached to this post.
    /// </summary>
    public TweetDetailSportsContext? SportsContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailSportsContext>("sportsContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sportsContext", value);
        }
    }

    /// <summary>
    /// The live event the post belongs to, such as an election.
    /// </summary>
    public TweetDetailLiveEventContext? LiveEventContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailLiveEventContext>("liveEventContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("liveEventContext", value);
        }
    }

    /// <summary>
    /// The Subscriber badge X shows on a reply. The reply's author subscribes to the creator who started the conversation. Omitted on a post without the badge.
    /// </summary>
    public global::XTwitterScraper.Models.TweetSubscriberBadge? SubscriberBadge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetSubscriberBadge>(
                "subscriberBadge"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscriberBadge", value);
        }
    }

    /// <summary>
    /// Public visibility notice attached to an available tweet.
    /// </summary>
    public global::XTwitterScraper.Models.TweetTombstone? Tombstone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetTombstone>(
                "tombstone"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tombstone", value);
        }
    }

    /// <summary>
    /// The notice x.com covers the post with until someone chooses to view it, such as X's public interest notice on a post that broke its rules but stays up.
    /// </summary>
    public global::XTwitterScraper.Models.TweetInterstitial? Interstitial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetInterstitial>(
                "interstitial"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("interstitial", value);
        }
    }

    /// <summary>
    /// The label X shows under a post whose reach it limits. It links to the page that explains it.
    /// </summary>
    public TweetDetailSoftIntervention? SoftIntervention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailSoftIntervention>("softIntervention");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("softIntervention", value);
        }
    }

    /// <summary>
    /// User IDs that left this conversation.
    /// </summary>
    public IReadOnlyList<string>? UnmentionedUserIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("unmentionedUserIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "unmentionedUserIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("scopes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "scopes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The fields X did not send for this post. text reads empty, so treat it as unknown rather than empty. Left out when X sent the text.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, TweetDetailUnknownFields>>? UnknownFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, TweetDetailUnknownFields>>
            >("unknownFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, TweetDetailUnknownFields>>?>(
                "unknownFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The counts X did not send for this post. Each one reads 0, so treat it as unknown rather than none. Names follow the response's key style, so `xquik-api-contract: 2026-04-29` lists bookmark_count. Posts from before X counted views, &amp; new posts X has not counted views for yet, list viewCount. Left out when X sent every count. Counts X didn't send are listed in `unknownCounts`, never shown as 0.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, TweetDetailUnknownCounts>>? UnknownCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, TweetDetailUnknownCounts>>
            >("unknownCounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, TweetDetailUnknownCounts>>?>(
                "unknownCounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A parent, quoted or retweeted tweet. It has the TweetPublicData fields and an author. Nesting stops after 4 levels.
    /// </summary>
    public global::XTwitterScraper.Models.EmbeddedTweet? ParentTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.EmbeddedTweet>(
                "parentTweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parentTweet", value);
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
        _ = this.IsPinned;
        _ = this.IsRetweet;
        _ = this.QuotedTweetID;
        this.QuotedTweetPermalink?.Validate();
        this.QuotedTweetUnavailable?.Validate();
        _ = this.RetweetedAt;
        this.ConversationControl?.Validate();
        foreach (var item in this.LimitedActions ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.TextHighlights ?? [])
        {
            item.Validate();
        }
        this.AuthorUnavailable?.Validate();
        _ = this.UnavailableAuthorID;
        foreach (var item in this.CashtagAttachments ?? [])
        {
            item.Validate();
        }
        _ = this.CommunityID;
        _ = this.CommunityName;
        _ = this.HasCommunityNotes;
        this.ExclusiveContent?.Validate();
        _ = this.GrokShareAttachment;
        _ = this.GrokTranslatedPost;
        _ = this.JetfuelAttachment;
        this.Coordinates?.Validate();
        this.Geo?.Validate();
        _ = this.PostCta;
        this.ReactionContext?.Validate();
        this.SportsContext?.Validate();
        this.LiveEventContext?.Validate();
        this.SubscriberBadge?.Validate();
        this.Tombstone?.Validate();
        this.Interstitial?.Validate();
        this.SoftIntervention?.Validate();
        _ = this.UnmentionedUserIDs;
        _ = this.Scopes;
        foreach (var item in this.UnknownFields ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UnknownCounts ?? [])
        {
            item.Validate();
        }
        this.ParentTweet?.Validate();
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

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CoverMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "coverMedia"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "coverMedia",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LifecycleState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "lifecycleState"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "lifecycleState",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CoverMediaUrl;
        _ = this.PreviewText;
        _ = this.Title;
        _ = this.CoverMedia;
        _ = this.LifecycleState;
        _ = this.Metadata;
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

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "platform"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "platform",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Unresolved card user references.
    /// </summary>
    public IReadOnlyList<CardUserReferenceErrors>? UserReferenceErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CardUserReferenceErrors>>(
                "userReferenceErrors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CardUserReferenceErrors>?>(
                "userReferenceErrors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.UserProfile>? UserReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.UserProfile>
            >("userReferences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.UserProfile>?>(
                "userReferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BindingValues;
        _ = this.Name;
        _ = this.Url;
        _ = this.Platform;
        foreach (var item in this.UserReferenceErrors ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UserReferences ?? [])
        {
            item.Validate();
        }
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

    public string? FooterIconType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footerIconType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footerIconType", value);
        }
    }

    public string? IconType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("iconType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("iconType", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
        _ = this.FooterIconType;
        _ = this.IconType;
        _ = this.Metadata;
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

    public string? InitialTweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("initialTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("initialTweetId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EditableUntilMsecs;
        _ = this.EditTweetIds;
        _ = this.InitialTweetID;
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

    /// <summary>
    /// The Note's own ID, apart from the post's.
    /// </summary>
    public string? NoteID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("noteId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("noteId", value);
        }
    }

    /// <summary>
    /// Inline media positions in the Note Tweet text.
    /// </summary>
    public IReadOnlyList<NoteTweetInlineMedia>? InlineMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NoteTweetInlineMedia>>(
                "inlineMedia"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<NoteTweetInlineMedia>?>(
                "inlineMedia",
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
        _ = this.NoteID;
        foreach (var item in this.InlineMedia ?? [])
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

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailQuotedTweetPermalink,
        TweetDetailQuotedTweetPermalinkFromRaw
    >)
)]
public sealed record class TweetDetailQuotedTweetPermalink : JsonModel
{
    public string? DisplayUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayUrl", value);
        }
    }

    public string? ExpandedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expandedUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expandedUrl", value);
        }
    }

    public string? UrlValue
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
        _ = this.DisplayUrl;
        _ = this.ExpandedUrl;
        _ = this.UrlValue;
    }

    public TweetDetailQuotedTweetPermalink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailQuotedTweetPermalink(
        TweetDetailQuotedTweetPermalink tweetDetailQuotedTweetPermalink
    )
        : base(tweetDetailQuotedTweetPermalink) { }
#pragma warning restore CS8618

    public TweetDetailQuotedTweetPermalink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailQuotedTweetPermalink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailQuotedTweetPermalinkFromRaw.FromRawUnchecked"/>
    public static TweetDetailQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailQuotedTweetPermalinkFromRaw : IFromRawJson<TweetDetailQuotedTweetPermalink>
{
    /// <inheritdoc/>
    public TweetDetailQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailQuotedTweetPermalink.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailQuotedTweetUnavailable,
        TweetDetailQuotedTweetUnavailableFromRaw
    >)
)]
public sealed record class TweetDetailQuotedTweetUnavailable : JsonModel
{
    /// <summary>
    /// X's reason, such as `Suspended` for a suspended author or `Protected` for an author who protects their posts.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public TweetDetailQuotedTweetUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailQuotedTweetUnavailable(
        TweetDetailQuotedTweetUnavailable tweetDetailQuotedTweetUnavailable
    )
        : base(tweetDetailQuotedTweetUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailQuotedTweetUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailQuotedTweetUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailQuotedTweetUnavailableFromRaw.FromRawUnchecked"/>
    public static TweetDetailQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailQuotedTweetUnavailableFromRaw : IFromRawJson<TweetDetailQuotedTweetUnavailable>
{
    /// <inheritdoc/>
    public TweetDetailQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailQuotedTweetUnavailable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailConversationControl,
        TweetDetailConversationControlFromRaw
    >)
)]
public sealed record class TweetDetailConversationControl : JsonModel
{
    /// <summary>
    /// Regions whose accounts may reply, as country codes. Sent with the `country_of_origin` mode.
    /// </summary>
    public IReadOnlyList<string>? AllowedCountryCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowedCountryCodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowedCountryCodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? InviteViaMention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inviteViaMention");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inviteViaMention", value);
        }
    }

    /// <summary>
    /// Reply policy from X's newer field, such as `my_network`, `premium` or `country_of_origin`. Omitted when X sends none.
    /// </summary>
    public string? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// The conversation owner's account ID.
    /// </summary>
    public string? OwnerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ownerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownerId", value);
        }
    }

    public string? OwnerUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ownerUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownerUsername", value);
        }
    }

    public string? Policy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("policy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("policy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedCountryCodes;
        _ = this.InviteViaMention;
        _ = this.Mode;
        _ = this.OwnerID;
        _ = this.OwnerUsername;
        _ = this.Policy;
    }

    public TweetDetailConversationControl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailConversationControl(
        TweetDetailConversationControl tweetDetailConversationControl
    )
        : base(tweetDetailConversationControl) { }
#pragma warning restore CS8618

    public TweetDetailConversationControl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailConversationControl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailConversationControlFromRaw.FromRawUnchecked"/>
    public static TweetDetailConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailConversationControlFromRaw : IFromRawJson<TweetDetailConversationControl>
{
    /// <inheritdoc/>
    public TweetDetailConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailConversationControl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailLimitedActionsPrompt,
        TweetDetailLimitedActionsPromptFromRaw
    >)
)]
public sealed record class TweetDetailLimitedActionsPrompt : JsonModel
{
    public string? CtaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaType", value);
        }
    }

    public string? Headline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("headline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headline", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Subtext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subtext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subtext", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CtaType;
        _ = this.Headline;
        _ = this.Metadata;
        _ = this.Subtext;
    }

    public TweetDetailLimitedActionsPrompt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailLimitedActionsPrompt(
        TweetDetailLimitedActionsPrompt tweetDetailLimitedActionsPrompt
    )
        : base(tweetDetailLimitedActionsPrompt) { }
#pragma warning restore CS8618

    public TweetDetailLimitedActionsPrompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailLimitedActionsPrompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailLimitedActionsPromptFromRaw.FromRawUnchecked"/>
    public static TweetDetailLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailLimitedActionsPromptFromRaw : IFromRawJson<TweetDetailLimitedActionsPrompt>
{
    /// <inheritdoc/>
    public TweetDetailLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailLimitedActionsPrompt.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailLimitedActions, TweetDetailLimitedActionsFromRaw>)
)]
public sealed record class TweetDetailLimitedActions : JsonModel
{
    public string? Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("action");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public TweetDetailLimitedActionsPrompt? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailLimitedActionsPrompt>("prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        this.Prompt?.Validate();
    }

    public TweetDetailLimitedActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailLimitedActions(TweetDetailLimitedActions tweetDetailLimitedActions)
        : base(tweetDetailLimitedActions) { }
#pragma warning restore CS8618

    public TweetDetailLimitedActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailLimitedActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailLimitedActionsFromRaw.FromRawUnchecked"/>
    public static TweetDetailLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailLimitedActionsFromRaw : IFromRawJson<TweetDetailLimitedActions>
{
    /// <inheritdoc/>
    public TweetDetailLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailLimitedActions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailTextHighlights, TweetDetailTextHighlightsFromRaw>)
)]
public sealed record class TweetDetailTextHighlights : JsonModel
{
    /// <summary>
    /// The first code point of the match.
    /// </summary>
    public required long StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("startIndex");
        }
        init { this._rawData.Set("startIndex", value); }
    }

    /// <summary>
    /// The first code point after the match.
    /// </summary>
    public required long EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("endIndex");
        }
        init { this._rawData.Set("endIndex", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StartIndex;
        _ = this.EndIndex;
    }

    public TweetDetailTextHighlights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailTextHighlights(TweetDetailTextHighlights tweetDetailTextHighlights)
        : base(tweetDetailTextHighlights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailTextHighlights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailTextHighlights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailTextHighlightsFromRaw.FromRawUnchecked"/>
    public static TweetDetailTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailTextHighlightsFromRaw : IFromRawJson<TweetDetailTextHighlights>
{
    /// <inheritdoc/>
    public TweetDetailTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailTextHighlights.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailCashtagAttachments, TweetDetailCashtagAttachmentsFromRaw>)
)]
public sealed record class TweetDetailCashtagAttachments : JsonModel
{
    /// <summary>
    /// The cashtag with its `$`.
    /// </summary>
    public required string Cashtag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cashtag");
        }
        init { this._rawData.Set("cashtag", value); }
    }

    /// <summary>
    /// Span of each candle.
    /// </summary>
    public string? CandleSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("candleSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("candleSize", value);
        }
    }

    /// <summary>
    /// Span the chart covers.
    /// </summary>
    public string? Timeframe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timeframe");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeframe", value);
        }
    }

    /// <summary>
    /// Time of the chart's first candle.
    /// </summary>
    public DateTimeOffset? StartTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startTime", value);
        }
    }

    /// <summary>
    /// Time of the chart's last price.
    /// </summary>
    public DateTimeOffset? EndTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("endTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endTime", value);
        }
    }

    /// <summary>
    /// X's size for the chart.
    /// </summary>
    public long? SizeVariant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeVariant");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeVariant", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cashtag;
        _ = this.CandleSize;
        _ = this.Timeframe;
        _ = this.StartTime;
        _ = this.EndTime;
        _ = this.SizeVariant;
    }

    public TweetDetailCashtagAttachments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailCashtagAttachments(
        TweetDetailCashtagAttachments tweetDetailCashtagAttachments
    )
        : base(tweetDetailCashtagAttachments) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailCashtagAttachments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailCashtagAttachments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailCashtagAttachmentsFromRaw.FromRawUnchecked"/>
    public static TweetDetailCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailCashtagAttachmentsFromRaw : IFromRawJson<TweetDetailCashtagAttachments>
{
    /// <inheritdoc/>
    public TweetDetailCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailCashtagAttachments.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailReactionContext, TweetDetailReactionContextFromRaw>)
)]
public sealed record class TweetDetailReactionContext : JsonModel
{
    /// <summary>
    /// The post this one reacts to, with the same fields. X often sends only its ID, author &amp; edit history. Then unknownFields lists text, and the flags X did not send are left out.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ReactedToPost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "reactedToPost"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "reactedToPost",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Referenced post ID.
    /// </summary>
    public string? ReactedToPostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reactedToPostId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactedToPostId", value);
        }
    }

    /// <summary>
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? ReactedToUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "reactedToUser"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactedToUser", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReactedToPost;
        _ = this.ReactedToPostID;
        this.ReactedToUser?.Validate();
    }

    public TweetDetailReactionContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailReactionContext(TweetDetailReactionContext tweetDetailReactionContext)
        : base(tweetDetailReactionContext) { }
#pragma warning restore CS8618

    public TweetDetailReactionContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailReactionContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailReactionContextFromRaw.FromRawUnchecked"/>
    public static TweetDetailReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailReactionContextFromRaw : IFromRawJson<TweetDetailReactionContext>
{
    /// <inheritdoc/>
    public TweetDetailReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailReactionContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailSportsContextCompetitors,
        TweetDetailSportsContextCompetitorsFromRaw
    >)
)]
public sealed record class TweetDetailSportsContextCompetitors : JsonModel
{
    /// <summary>
    /// Team ID.
    /// </summary>
    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("teamId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("teamId", value);
        }
    }

    /// <summary>
    /// Team display color.
    /// </summary>
    public string? Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("color", value);
        }
    }

    /// <summary>
    /// Active competitor.
    /// </summary>
    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isActive", value);
        }
    }

    /// <summary>
    /// Winning competitor.
    /// </summary>
    public bool? IsWinner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isWinner");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isWinner", value);
        }
    }

    /// <summary>
    /// Team abbreviation.
    /// </summary>
    public string? Abbreviation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("abbreviation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("abbreviation", value);
        }
    }

    /// <summary>
    /// Team name.
    /// </summary>
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

    /// <summary>
    /// Score display text.
    /// </summary>
    public string? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Logo for light backgrounds.
    /// </summary>
    public string? LogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logoUrl", value);
        }
    }

    /// <summary>
    /// Logo for dark backgrounds.
    /// </summary>
    public string? DarkLogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("darkLogoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("darkLogoUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.Color;
        _ = this.IsActive;
        _ = this.IsWinner;
        _ = this.Abbreviation;
        _ = this.Name;
        _ = this.Score;
        _ = this.LogoUrl;
        _ = this.DarkLogoUrl;
    }

    public TweetDetailSportsContextCompetitors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSportsContextCompetitors(
        TweetDetailSportsContextCompetitors tweetDetailSportsContextCompetitors
    )
        : base(tweetDetailSportsContextCompetitors) { }
#pragma warning restore CS8618

    public TweetDetailSportsContextCompetitors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSportsContextCompetitors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSportsContextCompetitorsFromRaw.FromRawUnchecked"/>
    public static TweetDetailSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSportsContextCompetitorsFromRaw : IFromRawJson<TweetDetailSportsContextCompetitors>
{
    /// <inheritdoc/>
    public TweetDetailSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSportsContextCompetitors.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailSportsContext, TweetDetailSportsContextFromRaw>)
)]
public sealed record class TweetDetailSportsContext : JsonModel
{
    /// <summary>
    /// Game ID.
    /// </summary>
    public string? GameID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gameId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gameId", value);
        }
    }

    /// <summary>
    /// League ID.
    /// </summary>
    public string? League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("league");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("league", value);
        }
    }

    /// <summary>
    /// Game title.
    /// </summary>
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

    /// <summary>
    /// Game link.
    /// </summary>
    public string? UrlValue
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

    /// <summary>
    /// Reported game state.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Game progress text.
    /// </summary>
    public string? StatusText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("statusText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusText", value);
        }
    }

    /// <summary>
    /// Scheduled Unix milliseconds, retaining the source type.
    /// </summary>
    public JsonElement? ScheduledAtMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("scheduledAtMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduledAtMs", value);
        }
    }

    /// <summary>
    /// Teams &amp; reported scores.
    /// </summary>
    public IReadOnlyList<TweetDetailSportsContextCompetitors>? Competitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TweetDetailSportsContextCompetitors>
            >("competitors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailSportsContextCompetitors>?>(
                "competitors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GameID;
        _ = this.League;
        _ = this.Title;
        _ = this.UrlValue;
        _ = this.State;
        _ = this.StatusText;
        _ = this.ScheduledAtMs;
        foreach (var item in this.Competitors ?? [])
        {
            item.Validate();
        }
    }

    public TweetDetailSportsContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSportsContext(TweetDetailSportsContext tweetDetailSportsContext)
        : base(tweetDetailSportsContext) { }
#pragma warning restore CS8618

    public TweetDetailSportsContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSportsContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSportsContextFromRaw.FromRawUnchecked"/>
    public static TweetDetailSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSportsContextFromRaw : IFromRawJson<TweetDetailSportsContext>
{
    /// <inheritdoc/>
    public TweetDetailSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSportsContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailLiveEventContext, TweetDetailLiveEventContextFromRaw>)
)]
public sealed record class TweetDetailLiveEventContext : JsonModel
{
    /// <summary>
    /// Event name.
    /// </summary>
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

    /// <summary>
    /// The event's page on X.
    /// </summary>
    public string? UrlValue
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

    /// <summary>
    /// The event's image.
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Title;
        _ = this.UrlValue;
        _ = this.ImageUrl;
    }

    public TweetDetailLiveEventContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailLiveEventContext(TweetDetailLiveEventContext tweetDetailLiveEventContext)
        : base(tweetDetailLiveEventContext) { }
#pragma warning restore CS8618

    public TweetDetailLiveEventContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailLiveEventContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailLiveEventContextFromRaw.FromRawUnchecked"/>
    public static TweetDetailLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailLiveEventContextFromRaw : IFromRawJson<TweetDetailLiveEventContext>
{
    /// <inheritdoc/>
    public TweetDetailLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailLiveEventContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailSoftInterventionTextEntitiesRef,
        TweetDetailSoftInterventionTextEntitiesRefFromRaw
    >)
)]
public sealed record class TweetDetailSoftInterventionTextEntitiesRef : JsonModel
{
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

    public string? UrlValue
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

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlType", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public string? ScreenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("screenName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("screenName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.UrlValue;
        _ = this.UrlType;
        _ = this.Text;
        _ = this.ScreenName;
    }

    public TweetDetailSoftInterventionTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSoftInterventionTextEntitiesRef(
        TweetDetailSoftInterventionTextEntitiesRef tweetDetailSoftInterventionTextEntitiesRef
    )
        : base(tweetDetailSoftInterventionTextEntitiesRef) { }
#pragma warning restore CS8618

    public TweetDetailSoftInterventionTextEntitiesRef(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSoftInterventionTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSoftInterventionTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static TweetDetailSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSoftInterventionTextEntitiesRefFromRaw
    : IFromRawJson<TweetDetailSoftInterventionTextEntitiesRef>
{
    /// <inheritdoc/>
    public TweetDetailSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSoftInterventionTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailSoftInterventionTextEntities,
        TweetDetailSoftInterventionTextEntitiesFromRaw
    >)
)]
public sealed record class TweetDetailSoftInterventionTextEntities : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? FromIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fromIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fromIndex", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? ToIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("toIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toIndex", value);
        }
    }

    public TweetDetailSoftInterventionTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailSoftInterventionTextEntitiesRef>(
                "ref"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ref", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromIndex;
        _ = this.ToIndex;
        this.Ref?.Validate();
    }

    public TweetDetailSoftInterventionTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSoftInterventionTextEntities(
        TweetDetailSoftInterventionTextEntities tweetDetailSoftInterventionTextEntities
    )
        : base(tweetDetailSoftInterventionTextEntities) { }
#pragma warning restore CS8618

    public TweetDetailSoftInterventionTextEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSoftInterventionTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSoftInterventionTextEntitiesFromRaw.FromRawUnchecked"/>
    public static TweetDetailSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSoftInterventionTextEntitiesFromRaw
    : IFromRawJson<TweetDetailSoftInterventionTextEntities>
{
    /// <inheritdoc/>
    public TweetDetailSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSoftInterventionTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailSoftInterventionText,
        TweetDetailSoftInterventionTextFromRaw
    >)
)]
public sealed record class TweetDetailSoftInterventionText : JsonModel
{
    /// <summary>
    /// The label's text.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Whether the label reads right to left.
    /// </summary>
    public bool? Rtl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("rtl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rtl", value);
        }
    }

    /// <summary>
    /// Links inside the label, by character range.
    /// </summary>
    public IReadOnlyList<TweetDetailSoftInterventionTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TweetDetailSoftInterventionTextEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetDetailSoftInterventionTextEntities>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Rtl;
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
    }

    public TweetDetailSoftInterventionText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSoftInterventionText(
        TweetDetailSoftInterventionText tweetDetailSoftInterventionText
    )
        : base(tweetDetailSoftInterventionText) { }
#pragma warning restore CS8618

    public TweetDetailSoftInterventionText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSoftInterventionText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSoftInterventionTextFromRaw.FromRawUnchecked"/>
    public static TweetDetailSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSoftInterventionTextFromRaw : IFromRawJson<TweetDetailSoftInterventionText>
{
    /// <inheritdoc/>
    public TweetDetailSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSoftInterventionText.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetDetailSoftInterventionUrl,
        TweetDetailSoftInterventionUrlFromRaw
    >)
)]
public sealed record class TweetDetailSoftInterventionUrl : JsonModel
{
    public string? UrlValue
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

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.UrlType;
    }

    public TweetDetailSoftInterventionUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSoftInterventionUrl(
        TweetDetailSoftInterventionUrl tweetDetailSoftInterventionUrl
    )
        : base(tweetDetailSoftInterventionUrl) { }
#pragma warning restore CS8618

    public TweetDetailSoftInterventionUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSoftInterventionUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSoftInterventionUrlFromRaw.FromRawUnchecked"/>
    public static TweetDetailSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSoftInterventionUrlFromRaw : IFromRawJson<TweetDetailSoftInterventionUrl>
{
    /// <inheritdoc/>
    public TweetDetailSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSoftInterventionUrl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetDetailSoftIntervention, TweetDetailSoftInterventionFromRaw>)
)]
public sealed record class TweetDetailSoftIntervention : JsonModel
{
    /// <summary>
    /// The label's kind. `Fosnr` marks a post X keeps up but shows to fewer people.
    /// </summary>
    public string? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayType", value);
        }
    }

    /// <summary>
    /// Whether X prompts people before they engage with the post.
    /// </summary>
    public bool? EngagementNudge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("engagementNudge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("engagementNudge", value);
        }
    }

    public TweetDetailSoftInterventionText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailSoftInterventionText>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// The page that explains the label.
    /// </summary>
    public TweetDetailSoftInterventionUrl? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDetailSoftInterventionUrl>("url");
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
        _ = this.DisplayType;
        _ = this.EngagementNudge;
        this.Text?.Validate();
        this.UrlValue?.Validate();
    }

    public TweetDetailSoftIntervention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDetailSoftIntervention(TweetDetailSoftIntervention tweetDetailSoftIntervention)
        : base(tweetDetailSoftIntervention) { }
#pragma warning restore CS8618

    public TweetDetailSoftIntervention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDetailSoftIntervention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDetailSoftInterventionFromRaw.FromRawUnchecked"/>
    public static TweetDetailSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDetailSoftInterventionFromRaw : IFromRawJson<TweetDetailSoftIntervention>
{
    /// <inheritdoc/>
    public TweetDetailSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDetailSoftIntervention.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDetailUnknownFieldsConverter))]
public enum TweetDetailUnknownFields
{
    Text,
}

sealed class TweetDetailUnknownFieldsConverter : JsonConverter<TweetDetailUnknownFields>
{
    public override TweetDetailUnknownFields Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => TweetDetailUnknownFields.Text,
            _ => (TweetDetailUnknownFields)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDetailUnknownFields value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDetailUnknownFields.Text => "text",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetDetailUnknownCountsConverter))]
public enum TweetDetailUnknownCounts
{
    RetweetCount,
    ReplyCount,
    LikeCount,
    QuoteCount,
    ViewCount,
    BookmarkCount,
}

sealed class TweetDetailUnknownCountsConverter : JsonConverter<TweetDetailUnknownCounts>
{
    public override TweetDetailUnknownCounts Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retweetCount" => TweetDetailUnknownCounts.RetweetCount,
            "replyCount" => TweetDetailUnknownCounts.ReplyCount,
            "likeCount" => TweetDetailUnknownCounts.LikeCount,
            "quoteCount" => TweetDetailUnknownCounts.QuoteCount,
            "viewCount" => TweetDetailUnknownCounts.ViewCount,
            "bookmarkCount" => TweetDetailUnknownCounts.BookmarkCount,
            _ => (TweetDetailUnknownCounts)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDetailUnknownCounts value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDetailUnknownCounts.RetweetCount => "retweetCount",
                TweetDetailUnknownCounts.ReplyCount => "replyCount",
                TweetDetailUnknownCounts.LikeCount => "likeCount",
                TweetDetailUnknownCounts.QuoteCount => "quoteCount",
                TweetDetailUnknownCounts.ViewCount => "viewCount",
                TweetDetailUnknownCounts.BookmarkCount => "bookmarkCount",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CardUserReferenceErrors, CardUserReferenceErrorsFromRaw>))]
public sealed record class CardUserReferenceErrors : JsonModel
{
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Reason;
    }

    public CardUserReferenceErrors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardUserReferenceErrors(CardUserReferenceErrors cardUserReferenceErrors)
        : base(cardUserReferenceErrors) { }
#pragma warning restore CS8618

    public CardUserReferenceErrors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardUserReferenceErrors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardUserReferenceErrorsFromRaw.FromRawUnchecked"/>
    public static CardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardUserReferenceErrorsFromRaw : IFromRawJson<CardUserReferenceErrors>
{
    /// <inheritdoc/>
    public CardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardUserReferenceErrors.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NoteTweetInlineMedia, NoteTweetInlineMediaFromRaw>))]
public sealed record class NoteTweetInlineMedia : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    public required string MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mediaId");
        }
        init { this._rawData.Set("mediaId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Index;
        _ = this.MediaID;
    }

    public NoteTweetInlineMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoteTweetInlineMedia(NoteTweetInlineMedia noteTweetInlineMedia)
        : base(noteTweetInlineMedia) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoteTweetInlineMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoteTweetInlineMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoteTweetInlineMediaFromRaw.FromRawUnchecked"/>
    public static NoteTweetInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NoteTweetInlineMediaFromRaw : IFromRawJson<NoteTweetInlineMedia>
{
    /// <inheritdoc/>
    public NoteTweetInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NoteTweetInlineMedia.FromRawUnchecked(rawData);
}
