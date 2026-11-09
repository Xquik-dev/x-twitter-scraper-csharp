using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

/// <summary>
/// Quoted or retweeted tweet context. Every object includes id, text, and engagement
/// metrics. A zero metric can mean X did not report the count. Author, media, and
/// conversation fields appear when available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmbeddedTweet, EmbeddedTweetFromRaw>))]
public sealed record class EmbeddedTweet : JsonModel
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
    public EmbeddedTweetQuotedTweetPermalink? QuotedTweetPermalink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetQuotedTweetPermalink>(
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
    public EmbeddedTweetQuotedTweetUnavailable? QuotedTweetUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetQuotedTweetUnavailable>(
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
    public EmbeddedTweetConversationControl? ConversationControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetConversationControl>(
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
    public IReadOnlyList<EmbeddedTweetLimitedActions>? LimitedActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmbeddedTweetLimitedActions>>(
                "limitedActions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmbeddedTweetLimitedActions>?>(
                "limitedActions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where `text` matches the search, on each row a search read. Offsets count code points of `text`, as `displayTextRange` does. Empty when the post holds no marked match. Highlights cover a post's first 280 characters.
    /// </summary>
    public IReadOnlyList<EmbeddedTweetTextHighlights>? TextHighlights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmbeddedTweetTextHighlights>>(
                "textHighlights"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmbeddedTweetTextHighlights>?>(
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
    public IReadOnlyList<EmbeddedTweetCashtagAttachments>? CashtagAttachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmbeddedTweetCashtagAttachments>>(
                "cashtagAttachments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmbeddedTweetCashtagAttachments>?>(
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
    public EmbeddedTweetReactionContext? ReactionContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetReactionContext>("reactionContext");
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
    public EmbeddedTweetSportsContext? SportsContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetSportsContext>("sportsContext");
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
    public EmbeddedTweetLiveEventContext? LiveEventContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetLiveEventContext>(
                "liveEventContext"
            );
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
    public EmbeddedTweetSoftIntervention? SoftIntervention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetSoftIntervention>(
                "softIntervention"
            );
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
    public IReadOnlyList<ApiEnum<string, EmbeddedTweetUnknownFields>>? UnknownFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, EmbeddedTweetUnknownFields>>
            >("unknownFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, EmbeddedTweetUnknownFields>>?>(
                "unknownFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The counts X did not send for this post. Each one reads 0, so treat it as unknown rather than none. Names follow the response's key style, so `xquik-api-contract: 2026-04-29` lists bookmark_count. Posts from before X counted views, &amp; new posts X has not counted views for yet, list viewCount. Left out when X sent every count. Counts X didn't send are listed in `unknownCounts`, never shown as 0.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, EmbeddedTweetUnknownCounts>>? UnknownCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, EmbeddedTweetUnknownCounts>>
            >("unknownCounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, EmbeddedTweetUnknownCounts>>?>(
                "unknownCounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The post this one replies to, with the same fields.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ParentTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "parentTweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "parentTweet",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
        _ = this.ParentTweet;
    }

    public EmbeddedTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweet(EmbeddedTweet embeddedTweet)
        : base(embeddedTweet) { }
#pragma warning restore CS8618

    public EmbeddedTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetFromRaw : IFromRawJson<EmbeddedTweet>
{
    /// <inheritdoc/>
    public EmbeddedTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmbeddedTweet.FromRawUnchecked(rawData);
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

    /// <summary>
    /// Center of the place. Longitude, then latitude.
    /// </summary>
    public IReadOnlyList<double>? Centroid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("centroid");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>?>(
                "centroid",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Extra details X attaches to some places. Often empty.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "attributes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
        _ = this.Centroid;
        _ = this.Attributes;
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
        EmbeddedTweetQuotedTweetPermalink,
        EmbeddedTweetQuotedTweetPermalinkFromRaw
    >)
)]
public sealed record class EmbeddedTweetQuotedTweetPermalink : JsonModel
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

    public EmbeddedTweetQuotedTweetPermalink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetQuotedTweetPermalink(
        EmbeddedTweetQuotedTweetPermalink embeddedTweetQuotedTweetPermalink
    )
        : base(embeddedTweetQuotedTweetPermalink) { }
#pragma warning restore CS8618

    public EmbeddedTweetQuotedTweetPermalink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetQuotedTweetPermalink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetQuotedTweetPermalinkFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetQuotedTweetPermalinkFromRaw : IFromRawJson<EmbeddedTweetQuotedTweetPermalink>
{
    /// <inheritdoc/>
    public EmbeddedTweetQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetQuotedTweetPermalink.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetQuotedTweetUnavailable,
        EmbeddedTweetQuotedTweetUnavailableFromRaw
    >)
)]
public sealed record class EmbeddedTweetQuotedTweetUnavailable : JsonModel
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

    public EmbeddedTweetQuotedTweetUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetQuotedTweetUnavailable(
        EmbeddedTweetQuotedTweetUnavailable embeddedTweetQuotedTweetUnavailable
    )
        : base(embeddedTweetQuotedTweetUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetQuotedTweetUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetQuotedTweetUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetQuotedTweetUnavailableFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetQuotedTweetUnavailableFromRaw : IFromRawJson<EmbeddedTweetQuotedTweetUnavailable>
{
    /// <inheritdoc/>
    public EmbeddedTweetQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetQuotedTweetUnavailable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetConversationControl,
        EmbeddedTweetConversationControlFromRaw
    >)
)]
public sealed record class EmbeddedTweetConversationControl : JsonModel
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

    public EmbeddedTweetConversationControl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetConversationControl(
        EmbeddedTweetConversationControl embeddedTweetConversationControl
    )
        : base(embeddedTweetConversationControl) { }
#pragma warning restore CS8618

    public EmbeddedTweetConversationControl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetConversationControl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetConversationControlFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetConversationControlFromRaw : IFromRawJson<EmbeddedTweetConversationControl>
{
    /// <inheritdoc/>
    public EmbeddedTweetConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetConversationControl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetLimitedActionsPrompt,
        EmbeddedTweetLimitedActionsPromptFromRaw
    >)
)]
public sealed record class EmbeddedTweetLimitedActionsPrompt : JsonModel
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

    public EmbeddedTweetLimitedActionsPrompt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetLimitedActionsPrompt(
        EmbeddedTweetLimitedActionsPrompt embeddedTweetLimitedActionsPrompt
    )
        : base(embeddedTweetLimitedActionsPrompt) { }
#pragma warning restore CS8618

    public EmbeddedTweetLimitedActionsPrompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetLimitedActionsPrompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetLimitedActionsPromptFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetLimitedActionsPromptFromRaw : IFromRawJson<EmbeddedTweetLimitedActionsPrompt>
{
    /// <inheritdoc/>
    public EmbeddedTweetLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetLimitedActionsPrompt.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetLimitedActions, EmbeddedTweetLimitedActionsFromRaw>)
)]
public sealed record class EmbeddedTweetLimitedActions : JsonModel
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

    public EmbeddedTweetLimitedActionsPrompt? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetLimitedActionsPrompt>("prompt");
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

    public EmbeddedTweetLimitedActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetLimitedActions(EmbeddedTweetLimitedActions embeddedTweetLimitedActions)
        : base(embeddedTweetLimitedActions) { }
#pragma warning restore CS8618

    public EmbeddedTweetLimitedActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetLimitedActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetLimitedActionsFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetLimitedActionsFromRaw : IFromRawJson<EmbeddedTweetLimitedActions>
{
    /// <inheritdoc/>
    public EmbeddedTweetLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetLimitedActions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetTextHighlights, EmbeddedTweetTextHighlightsFromRaw>)
)]
public sealed record class EmbeddedTweetTextHighlights : JsonModel
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

    public EmbeddedTweetTextHighlights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetTextHighlights(EmbeddedTweetTextHighlights embeddedTweetTextHighlights)
        : base(embeddedTweetTextHighlights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetTextHighlights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetTextHighlights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetTextHighlightsFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetTextHighlightsFromRaw : IFromRawJson<EmbeddedTweetTextHighlights>
{
    /// <inheritdoc/>
    public EmbeddedTweetTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetTextHighlights.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetCashtagAttachments,
        EmbeddedTweetCashtagAttachmentsFromRaw
    >)
)]
public sealed record class EmbeddedTweetCashtagAttachments : JsonModel
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

    public EmbeddedTweetCashtagAttachments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetCashtagAttachments(
        EmbeddedTweetCashtagAttachments embeddedTweetCashtagAttachments
    )
        : base(embeddedTweetCashtagAttachments) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetCashtagAttachments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetCashtagAttachments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetCashtagAttachmentsFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetCashtagAttachmentsFromRaw : IFromRawJson<EmbeddedTweetCashtagAttachments>
{
    /// <inheritdoc/>
    public EmbeddedTweetCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetCashtagAttachments.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetReactionContext, EmbeddedTweetReactionContextFromRaw>)
)]
public sealed record class EmbeddedTweetReactionContext : JsonModel
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

    public EmbeddedTweetReactionContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetReactionContext(EmbeddedTweetReactionContext embeddedTweetReactionContext)
        : base(embeddedTweetReactionContext) { }
#pragma warning restore CS8618

    public EmbeddedTweetReactionContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetReactionContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetReactionContextFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetReactionContextFromRaw : IFromRawJson<EmbeddedTweetReactionContext>
{
    /// <inheritdoc/>
    public EmbeddedTweetReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetReactionContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetSportsContextCompetitors,
        EmbeddedTweetSportsContextCompetitorsFromRaw
    >)
)]
public sealed record class EmbeddedTweetSportsContextCompetitors : JsonModel
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

    public EmbeddedTweetSportsContextCompetitors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSportsContextCompetitors(
        EmbeddedTweetSportsContextCompetitors embeddedTweetSportsContextCompetitors
    )
        : base(embeddedTweetSportsContextCompetitors) { }
#pragma warning restore CS8618

    public EmbeddedTweetSportsContextCompetitors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSportsContextCompetitors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSportsContextCompetitorsFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSportsContextCompetitorsFromRaw
    : IFromRawJson<EmbeddedTweetSportsContextCompetitors>
{
    /// <inheritdoc/>
    public EmbeddedTweetSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSportsContextCompetitors.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetSportsContext, EmbeddedTweetSportsContextFromRaw>)
)]
public sealed record class EmbeddedTweetSportsContext : JsonModel
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
    public IReadOnlyList<EmbeddedTweetSportsContextCompetitors>? Competitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EmbeddedTweetSportsContextCompetitors>
            >("competitors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmbeddedTweetSportsContextCompetitors>?>(
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

    public EmbeddedTweetSportsContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSportsContext(EmbeddedTweetSportsContext embeddedTweetSportsContext)
        : base(embeddedTweetSportsContext) { }
#pragma warning restore CS8618

    public EmbeddedTweetSportsContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSportsContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSportsContextFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSportsContextFromRaw : IFromRawJson<EmbeddedTweetSportsContext>
{
    /// <inheritdoc/>
    public EmbeddedTweetSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSportsContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetLiveEventContext, EmbeddedTweetLiveEventContextFromRaw>)
)]
public sealed record class EmbeddedTweetLiveEventContext : JsonModel
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

    public EmbeddedTweetLiveEventContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetLiveEventContext(
        EmbeddedTweetLiveEventContext embeddedTweetLiveEventContext
    )
        : base(embeddedTweetLiveEventContext) { }
#pragma warning restore CS8618

    public EmbeddedTweetLiveEventContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetLiveEventContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetLiveEventContextFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetLiveEventContextFromRaw : IFromRawJson<EmbeddedTweetLiveEventContext>
{
    /// <inheritdoc/>
    public EmbeddedTweetLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetLiveEventContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetSoftInterventionTextEntitiesRef,
        EmbeddedTweetSoftInterventionTextEntitiesRefFromRaw
    >)
)]
public sealed record class EmbeddedTweetSoftInterventionTextEntitiesRef : JsonModel
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

    public EmbeddedTweetSoftInterventionTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSoftInterventionTextEntitiesRef(
        EmbeddedTweetSoftInterventionTextEntitiesRef embeddedTweetSoftInterventionTextEntitiesRef
    )
        : base(embeddedTweetSoftInterventionTextEntitiesRef) { }
#pragma warning restore CS8618

    public EmbeddedTweetSoftInterventionTextEntitiesRef(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSoftInterventionTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSoftInterventionTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSoftInterventionTextEntitiesRefFromRaw
    : IFromRawJson<EmbeddedTweetSoftInterventionTextEntitiesRef>
{
    /// <inheritdoc/>
    public EmbeddedTweetSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSoftInterventionTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetSoftInterventionTextEntities,
        EmbeddedTweetSoftInterventionTextEntitiesFromRaw
    >)
)]
public sealed record class EmbeddedTweetSoftInterventionTextEntities : JsonModel
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

    public EmbeddedTweetSoftInterventionTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetSoftInterventionTextEntitiesRef>(
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

    public EmbeddedTweetSoftInterventionTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSoftInterventionTextEntities(
        EmbeddedTweetSoftInterventionTextEntities embeddedTweetSoftInterventionTextEntities
    )
        : base(embeddedTweetSoftInterventionTextEntities) { }
#pragma warning restore CS8618

    public EmbeddedTweetSoftInterventionTextEntities(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSoftInterventionTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSoftInterventionTextEntitiesFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSoftInterventionTextEntitiesFromRaw
    : IFromRawJson<EmbeddedTweetSoftInterventionTextEntities>
{
    /// <inheritdoc/>
    public EmbeddedTweetSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSoftInterventionTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetSoftInterventionText,
        EmbeddedTweetSoftInterventionTextFromRaw
    >)
)]
public sealed record class EmbeddedTweetSoftInterventionText : JsonModel
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
    public IReadOnlyList<EmbeddedTweetSoftInterventionTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EmbeddedTweetSoftInterventionTextEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmbeddedTweetSoftInterventionTextEntities>?>(
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

    public EmbeddedTweetSoftInterventionText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSoftInterventionText(
        EmbeddedTweetSoftInterventionText embeddedTweetSoftInterventionText
    )
        : base(embeddedTweetSoftInterventionText) { }
#pragma warning restore CS8618

    public EmbeddedTweetSoftInterventionText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSoftInterventionText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSoftInterventionTextFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSoftInterventionTextFromRaw : IFromRawJson<EmbeddedTweetSoftInterventionText>
{
    /// <inheritdoc/>
    public EmbeddedTweetSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSoftInterventionText.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmbeddedTweetSoftInterventionUrl,
        EmbeddedTweetSoftInterventionUrlFromRaw
    >)
)]
public sealed record class EmbeddedTweetSoftInterventionUrl : JsonModel
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

    public EmbeddedTweetSoftInterventionUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSoftInterventionUrl(
        EmbeddedTweetSoftInterventionUrl embeddedTweetSoftInterventionUrl
    )
        : base(embeddedTweetSoftInterventionUrl) { }
#pragma warning restore CS8618

    public EmbeddedTweetSoftInterventionUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSoftInterventionUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSoftInterventionUrlFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSoftInterventionUrlFromRaw : IFromRawJson<EmbeddedTweetSoftInterventionUrl>
{
    /// <inheritdoc/>
    public EmbeddedTweetSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSoftInterventionUrl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<EmbeddedTweetSoftIntervention, EmbeddedTweetSoftInterventionFromRaw>)
)]
public sealed record class EmbeddedTweetSoftIntervention : JsonModel
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

    public EmbeddedTweetSoftInterventionText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetSoftInterventionText>("text");
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
    public EmbeddedTweetSoftInterventionUrl? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EmbeddedTweetSoftInterventionUrl>("url");
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

    public EmbeddedTweetSoftIntervention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmbeddedTweetSoftIntervention(
        EmbeddedTweetSoftIntervention embeddedTweetSoftIntervention
    )
        : base(embeddedTweetSoftIntervention) { }
#pragma warning restore CS8618

    public EmbeddedTweetSoftIntervention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmbeddedTweetSoftIntervention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmbeddedTweetSoftInterventionFromRaw.FromRawUnchecked"/>
    public static EmbeddedTweetSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmbeddedTweetSoftInterventionFromRaw : IFromRawJson<EmbeddedTweetSoftIntervention>
{
    /// <inheritdoc/>
    public EmbeddedTweetSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmbeddedTweetSoftIntervention.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EmbeddedTweetUnknownFieldsConverter))]
public enum EmbeddedTweetUnknownFields
{
    Text,
}

sealed class EmbeddedTweetUnknownFieldsConverter : JsonConverter<EmbeddedTweetUnknownFields>
{
    public override EmbeddedTweetUnknownFields Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => EmbeddedTweetUnknownFields.Text,
            _ => (EmbeddedTweetUnknownFields)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbeddedTweetUnknownFields value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmbeddedTweetUnknownFields.Text => "text",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EmbeddedTweetUnknownCountsConverter))]
public enum EmbeddedTweetUnknownCounts
{
    RetweetCount,
    ReplyCount,
    LikeCount,
    QuoteCount,
    ViewCount,
    BookmarkCount,
}

sealed class EmbeddedTweetUnknownCountsConverter : JsonConverter<EmbeddedTweetUnknownCounts>
{
    public override EmbeddedTweetUnknownCounts Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retweetCount" => EmbeddedTweetUnknownCounts.RetweetCount,
            "replyCount" => EmbeddedTweetUnknownCounts.ReplyCount,
            "likeCount" => EmbeddedTweetUnknownCounts.LikeCount,
            "quoteCount" => EmbeddedTweetUnknownCounts.QuoteCount,
            "viewCount" => EmbeddedTweetUnknownCounts.ViewCount,
            "bookmarkCount" => EmbeddedTweetUnknownCounts.BookmarkCount,
            _ => (EmbeddedTweetUnknownCounts)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmbeddedTweetUnknownCounts value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmbeddedTweetUnknownCounts.RetweetCount => "retweetCount",
                EmbeddedTweetUnknownCounts.ReplyCount => "replyCount",
                EmbeddedTweetUnknownCounts.LikeCount => "likeCount",
                EmbeddedTweetUnknownCounts.QuoteCount => "quoteCount",
                EmbeddedTweetUnknownCounts.ViewCount => "viewCount",
                EmbeddedTweetUnknownCounts.BookmarkCount => "bookmarkCount",
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
