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
    /// How likely a photo shows what you asked for. Present on pages the image filter kept.
    /// </summary>
    public double? ImageScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("imageScore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageScore", value);
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

    /// <summary>
    /// How likely the post is about the topic. Present on pages the topic filter kept.
    /// </summary>
    public double? TopicScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("topicScore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topicScore", value);
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
    public SearchTweetQuotedTweetPermalink? QuotedTweetPermalink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetQuotedTweetPermalink>(
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
    public SearchTweetQuotedTweetUnavailable? QuotedTweetUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetQuotedTweetUnavailable>(
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
    public SearchTweetConversationControl? ConversationControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetConversationControl>(
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
    public IReadOnlyList<SearchTweetLimitedActions>? LimitedActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweetLimitedActions>>(
                "limitedActions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetLimitedActions>?>(
                "limitedActions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where `text` matches the search, on each row a search read. Offsets count code points of `text`, as `displayTextRange` does. Empty when the post holds no marked match. Highlights cover a post's first 280 characters.
    /// </summary>
    public IReadOnlyList<SearchTweetTextHighlights>? TextHighlights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweetTextHighlights>>(
                "textHighlights"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetTextHighlights>?>(
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
    public IReadOnlyList<SearchTweetCashtagAttachments>? CashtagAttachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweetCashtagAttachments>>(
                "cashtagAttachments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetCashtagAttachments>?>(
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
    public SearchTweetReactionContext? ReactionContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetReactionContext>("reactionContext");
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
    public SearchTweetSportsContext? SportsContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetSportsContext>("sportsContext");
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
    public SearchTweetLiveEventContext? LiveEventContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetLiveEventContext>("liveEventContext");
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
    public SearchTweetSoftIntervention? SoftIntervention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetSoftIntervention>("softIntervention");
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
    public IReadOnlyList<ApiEnum<string, SearchTweetUnknownFields>>? UnknownFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, SearchTweetUnknownFields>>
            >("unknownFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, SearchTweetUnknownFields>>?>(
                "unknownFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The counts X did not send for this post. Each one reads 0, so treat it as unknown rather than none. Names follow the response's key style, so `xquik-api-contract: 2026-04-29` lists bookmark_count. Posts from before X counted views, &amp; new posts X has not counted views for yet, list viewCount. Left out when X sent every count. Counts X didn't send are listed in `unknownCounts`, never shown as 0.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, SearchTweetUnknownCounts>>? UnknownCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, SearchTweetUnknownCounts>>
            >("unknownCounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, SearchTweetUnknownCounts>>?>(
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

    /// <summary>
    /// Present on a reply the post's author hid. Complete-mode replies carry it when includeHidden asks for them.
    /// </summary>
    public bool? HiddenByAuthor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hiddenByAuthor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hiddenByAuthor", value);
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
        _ = this.ImageScore;
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
        _ = this.TopicScore;
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
        _ = this.HiddenByAuthor;
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
    public IReadOnlyList<SearchTweetCardUserReferenceErrors>? UserReferenceErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SearchTweetCardUserReferenceErrors>
            >("userReferenceErrors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetCardUserReferenceErrors>?>(
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
    public IReadOnlyList<SearchTweetNoteTweetInlineMedia>? InlineMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweetNoteTweetInlineMedia>>(
                "inlineMedia"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetNoteTweetInlineMedia>?>(
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

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetQuotedTweetPermalink,
        SearchTweetQuotedTweetPermalinkFromRaw
    >)
)]
public sealed record class SearchTweetQuotedTweetPermalink : JsonModel
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

    public SearchTweetQuotedTweetPermalink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetQuotedTweetPermalink(
        SearchTweetQuotedTweetPermalink searchTweetQuotedTweetPermalink
    )
        : base(searchTweetQuotedTweetPermalink) { }
#pragma warning restore CS8618

    public SearchTweetQuotedTweetPermalink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetQuotedTweetPermalink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetQuotedTweetPermalinkFromRaw.FromRawUnchecked"/>
    public static SearchTweetQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetQuotedTweetPermalinkFromRaw : IFromRawJson<SearchTweetQuotedTweetPermalink>
{
    /// <inheritdoc/>
    public SearchTweetQuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetQuotedTweetPermalink.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetQuotedTweetUnavailable,
        SearchTweetQuotedTweetUnavailableFromRaw
    >)
)]
public sealed record class SearchTweetQuotedTweetUnavailable : JsonModel
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

    public SearchTweetQuotedTweetUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetQuotedTweetUnavailable(
        SearchTweetQuotedTweetUnavailable searchTweetQuotedTweetUnavailable
    )
        : base(searchTweetQuotedTweetUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetQuotedTweetUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetQuotedTweetUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetQuotedTweetUnavailableFromRaw.FromRawUnchecked"/>
    public static SearchTweetQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetQuotedTweetUnavailableFromRaw : IFromRawJson<SearchTweetQuotedTweetUnavailable>
{
    /// <inheritdoc/>
    public SearchTweetQuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetQuotedTweetUnavailable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetConversationControl,
        SearchTweetConversationControlFromRaw
    >)
)]
public sealed record class SearchTweetConversationControl : JsonModel
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

    public SearchTweetConversationControl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetConversationControl(
        SearchTweetConversationControl searchTweetConversationControl
    )
        : base(searchTweetConversationControl) { }
#pragma warning restore CS8618

    public SearchTweetConversationControl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetConversationControl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetConversationControlFromRaw.FromRawUnchecked"/>
    public static SearchTweetConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetConversationControlFromRaw : IFromRawJson<SearchTweetConversationControl>
{
    /// <inheritdoc/>
    public SearchTweetConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetConversationControl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetLimitedActionsPrompt,
        SearchTweetLimitedActionsPromptFromRaw
    >)
)]
public sealed record class SearchTweetLimitedActionsPrompt : JsonModel
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

    public SearchTweetLimitedActionsPrompt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetLimitedActionsPrompt(
        SearchTweetLimitedActionsPrompt searchTweetLimitedActionsPrompt
    )
        : base(searchTweetLimitedActionsPrompt) { }
#pragma warning restore CS8618

    public SearchTweetLimitedActionsPrompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetLimitedActionsPrompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetLimitedActionsPromptFromRaw.FromRawUnchecked"/>
    public static SearchTweetLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetLimitedActionsPromptFromRaw : IFromRawJson<SearchTweetLimitedActionsPrompt>
{
    /// <inheritdoc/>
    public SearchTweetLimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetLimitedActionsPrompt.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetLimitedActions, SearchTweetLimitedActionsFromRaw>)
)]
public sealed record class SearchTweetLimitedActions : JsonModel
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

    public SearchTweetLimitedActionsPrompt? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetLimitedActionsPrompt>("prompt");
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

    public SearchTweetLimitedActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetLimitedActions(SearchTweetLimitedActions searchTweetLimitedActions)
        : base(searchTweetLimitedActions) { }
#pragma warning restore CS8618

    public SearchTweetLimitedActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetLimitedActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetLimitedActionsFromRaw.FromRawUnchecked"/>
    public static SearchTweetLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetLimitedActionsFromRaw : IFromRawJson<SearchTweetLimitedActions>
{
    /// <inheritdoc/>
    public SearchTweetLimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetLimitedActions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetTextHighlights, SearchTweetTextHighlightsFromRaw>)
)]
public sealed record class SearchTweetTextHighlights : JsonModel
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

    public SearchTweetTextHighlights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetTextHighlights(SearchTweetTextHighlights searchTweetTextHighlights)
        : base(searchTweetTextHighlights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetTextHighlights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetTextHighlights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetTextHighlightsFromRaw.FromRawUnchecked"/>
    public static SearchTweetTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetTextHighlightsFromRaw : IFromRawJson<SearchTweetTextHighlights>
{
    /// <inheritdoc/>
    public SearchTweetTextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetTextHighlights.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetCashtagAttachments, SearchTweetCashtagAttachmentsFromRaw>)
)]
public sealed record class SearchTweetCashtagAttachments : JsonModel
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

    public SearchTweetCashtagAttachments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetCashtagAttachments(
        SearchTweetCashtagAttachments searchTweetCashtagAttachments
    )
        : base(searchTweetCashtagAttachments) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetCashtagAttachments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetCashtagAttachments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetCashtagAttachmentsFromRaw.FromRawUnchecked"/>
    public static SearchTweetCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetCashtagAttachmentsFromRaw : IFromRawJson<SearchTweetCashtagAttachments>
{
    /// <inheritdoc/>
    public SearchTweetCashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetCashtagAttachments.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetReactionContext, SearchTweetReactionContextFromRaw>)
)]
public sealed record class SearchTweetReactionContext : JsonModel
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

    public SearchTweetReactionContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetReactionContext(SearchTweetReactionContext searchTweetReactionContext)
        : base(searchTweetReactionContext) { }
#pragma warning restore CS8618

    public SearchTweetReactionContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetReactionContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetReactionContextFromRaw.FromRawUnchecked"/>
    public static SearchTweetReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetReactionContextFromRaw : IFromRawJson<SearchTweetReactionContext>
{
    /// <inheritdoc/>
    public SearchTweetReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetReactionContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetSportsContextCompetitors,
        SearchTweetSportsContextCompetitorsFromRaw
    >)
)]
public sealed record class SearchTweetSportsContextCompetitors : JsonModel
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

    public SearchTweetSportsContextCompetitors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSportsContextCompetitors(
        SearchTweetSportsContextCompetitors searchTweetSportsContextCompetitors
    )
        : base(searchTweetSportsContextCompetitors) { }
#pragma warning restore CS8618

    public SearchTweetSportsContextCompetitors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSportsContextCompetitors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSportsContextCompetitorsFromRaw.FromRawUnchecked"/>
    public static SearchTweetSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSportsContextCompetitorsFromRaw : IFromRawJson<SearchTweetSportsContextCompetitors>
{
    /// <inheritdoc/>
    public SearchTweetSportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSportsContextCompetitors.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetSportsContext, SearchTweetSportsContextFromRaw>)
)]
public sealed record class SearchTweetSportsContext : JsonModel
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
    public IReadOnlyList<SearchTweetSportsContextCompetitors>? Competitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SearchTweetSportsContextCompetitors>
            >("competitors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetSportsContextCompetitors>?>(
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

    public SearchTweetSportsContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSportsContext(SearchTweetSportsContext searchTweetSportsContext)
        : base(searchTweetSportsContext) { }
#pragma warning restore CS8618

    public SearchTweetSportsContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSportsContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSportsContextFromRaw.FromRawUnchecked"/>
    public static SearchTweetSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSportsContextFromRaw : IFromRawJson<SearchTweetSportsContext>
{
    /// <inheritdoc/>
    public SearchTweetSportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSportsContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetLiveEventContext, SearchTweetLiveEventContextFromRaw>)
)]
public sealed record class SearchTweetLiveEventContext : JsonModel
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

    public SearchTweetLiveEventContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetLiveEventContext(SearchTweetLiveEventContext searchTweetLiveEventContext)
        : base(searchTweetLiveEventContext) { }
#pragma warning restore CS8618

    public SearchTweetLiveEventContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetLiveEventContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetLiveEventContextFromRaw.FromRawUnchecked"/>
    public static SearchTweetLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetLiveEventContextFromRaw : IFromRawJson<SearchTweetLiveEventContext>
{
    /// <inheritdoc/>
    public SearchTweetLiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetLiveEventContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetSoftInterventionTextEntitiesRef,
        SearchTweetSoftInterventionTextEntitiesRefFromRaw
    >)
)]
public sealed record class SearchTweetSoftInterventionTextEntitiesRef : JsonModel
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

    public SearchTweetSoftInterventionTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSoftInterventionTextEntitiesRef(
        SearchTweetSoftInterventionTextEntitiesRef searchTweetSoftInterventionTextEntitiesRef
    )
        : base(searchTweetSoftInterventionTextEntitiesRef) { }
#pragma warning restore CS8618

    public SearchTweetSoftInterventionTextEntitiesRef(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSoftInterventionTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSoftInterventionTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static SearchTweetSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSoftInterventionTextEntitiesRefFromRaw
    : IFromRawJson<SearchTweetSoftInterventionTextEntitiesRef>
{
    /// <inheritdoc/>
    public SearchTweetSoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSoftInterventionTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetSoftInterventionTextEntities,
        SearchTweetSoftInterventionTextEntitiesFromRaw
    >)
)]
public sealed record class SearchTweetSoftInterventionTextEntities : JsonModel
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

    public SearchTweetSoftInterventionTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetSoftInterventionTextEntitiesRef>(
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

    public SearchTweetSoftInterventionTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSoftInterventionTextEntities(
        SearchTweetSoftInterventionTextEntities searchTweetSoftInterventionTextEntities
    )
        : base(searchTweetSoftInterventionTextEntities) { }
#pragma warning restore CS8618

    public SearchTweetSoftInterventionTextEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSoftInterventionTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSoftInterventionTextEntitiesFromRaw.FromRawUnchecked"/>
    public static SearchTweetSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSoftInterventionTextEntitiesFromRaw
    : IFromRawJson<SearchTweetSoftInterventionTextEntities>
{
    /// <inheritdoc/>
    public SearchTweetSoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSoftInterventionTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetSoftInterventionText,
        SearchTweetSoftInterventionTextFromRaw
    >)
)]
public sealed record class SearchTweetSoftInterventionText : JsonModel
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
    public IReadOnlyList<SearchTweetSoftInterventionTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SearchTweetSoftInterventionTextEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweetSoftInterventionTextEntities>?>(
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

    public SearchTweetSoftInterventionText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSoftInterventionText(
        SearchTweetSoftInterventionText searchTweetSoftInterventionText
    )
        : base(searchTweetSoftInterventionText) { }
#pragma warning restore CS8618

    public SearchTweetSoftInterventionText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSoftInterventionText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSoftInterventionTextFromRaw.FromRawUnchecked"/>
    public static SearchTweetSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSoftInterventionTextFromRaw : IFromRawJson<SearchTweetSoftInterventionText>
{
    /// <inheritdoc/>
    public SearchTweetSoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSoftInterventionText.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetSoftInterventionUrl,
        SearchTweetSoftInterventionUrlFromRaw
    >)
)]
public sealed record class SearchTweetSoftInterventionUrl : JsonModel
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

    public SearchTweetSoftInterventionUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSoftInterventionUrl(
        SearchTweetSoftInterventionUrl searchTweetSoftInterventionUrl
    )
        : base(searchTweetSoftInterventionUrl) { }
#pragma warning restore CS8618

    public SearchTweetSoftInterventionUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSoftInterventionUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSoftInterventionUrlFromRaw.FromRawUnchecked"/>
    public static SearchTweetSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSoftInterventionUrlFromRaw : IFromRawJson<SearchTweetSoftInterventionUrl>
{
    /// <inheritdoc/>
    public SearchTweetSoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSoftInterventionUrl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweetSoftIntervention, SearchTweetSoftInterventionFromRaw>)
)]
public sealed record class SearchTweetSoftIntervention : JsonModel
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

    public SearchTweetSoftInterventionText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetSoftInterventionText>("text");
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
    public SearchTweetSoftInterventionUrl? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweetSoftInterventionUrl>("url");
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

    public SearchTweetSoftIntervention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetSoftIntervention(SearchTweetSoftIntervention searchTweetSoftIntervention)
        : base(searchTweetSoftIntervention) { }
#pragma warning restore CS8618

    public SearchTweetSoftIntervention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetSoftIntervention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetSoftInterventionFromRaw.FromRawUnchecked"/>
    public static SearchTweetSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetSoftInterventionFromRaw : IFromRawJson<SearchTweetSoftIntervention>
{
    /// <inheritdoc/>
    public SearchTweetSoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetSoftIntervention.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SearchTweetUnknownFieldsConverter))]
public enum SearchTweetUnknownFields
{
    Text,
}

sealed class SearchTweetUnknownFieldsConverter : JsonConverter<SearchTweetUnknownFields>
{
    public override SearchTweetUnknownFields Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => SearchTweetUnknownFields.Text,
            _ => (SearchTweetUnknownFields)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchTweetUnknownFields value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchTweetUnknownFields.Text => "text",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SearchTweetUnknownCountsConverter))]
public enum SearchTweetUnknownCounts
{
    RetweetCount,
    ReplyCount,
    LikeCount,
    QuoteCount,
    ViewCount,
    BookmarkCount,
}

sealed class SearchTweetUnknownCountsConverter : JsonConverter<SearchTweetUnknownCounts>
{
    public override SearchTweetUnknownCounts Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retweetCount" => SearchTweetUnknownCounts.RetweetCount,
            "replyCount" => SearchTweetUnknownCounts.ReplyCount,
            "likeCount" => SearchTweetUnknownCounts.LikeCount,
            "quoteCount" => SearchTweetUnknownCounts.QuoteCount,
            "viewCount" => SearchTweetUnknownCounts.ViewCount,
            "bookmarkCount" => SearchTweetUnknownCounts.BookmarkCount,
            _ => (SearchTweetUnknownCounts)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchTweetUnknownCounts value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchTweetUnknownCounts.RetweetCount => "retweetCount",
                SearchTweetUnknownCounts.ReplyCount => "replyCount",
                SearchTweetUnknownCounts.LikeCount => "likeCount",
                SearchTweetUnknownCounts.QuoteCount => "quoteCount",
                SearchTweetUnknownCounts.ViewCount => "viewCount",
                SearchTweetUnknownCounts.BookmarkCount => "bookmarkCount",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetCardUserReferenceErrors,
        SearchTweetCardUserReferenceErrorsFromRaw
    >)
)]
public sealed record class SearchTweetCardUserReferenceErrors : JsonModel
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

    public SearchTweetCardUserReferenceErrors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetCardUserReferenceErrors(
        SearchTweetCardUserReferenceErrors searchTweetCardUserReferenceErrors
    )
        : base(searchTweetCardUserReferenceErrors) { }
#pragma warning restore CS8618

    public SearchTweetCardUserReferenceErrors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetCardUserReferenceErrors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetCardUserReferenceErrorsFromRaw.FromRawUnchecked"/>
    public static SearchTweetCardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetCardUserReferenceErrorsFromRaw : IFromRawJson<SearchTweetCardUserReferenceErrors>
{
    /// <inheritdoc/>
    public SearchTweetCardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetCardUserReferenceErrors.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweetNoteTweetInlineMedia,
        SearchTweetNoteTweetInlineMediaFromRaw
    >)
)]
public sealed record class SearchTweetNoteTweetInlineMedia : JsonModel
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

    public SearchTweetNoteTweetInlineMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetNoteTweetInlineMedia(
        SearchTweetNoteTweetInlineMedia searchTweetNoteTweetInlineMedia
    )
        : base(searchTweetNoteTweetInlineMedia) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweetNoteTweetInlineMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweetNoteTweetInlineMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweetNoteTweetInlineMediaFromRaw.FromRawUnchecked"/>
    public static SearchTweetNoteTweetInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweetNoteTweetInlineMediaFromRaw : IFromRawJson<SearchTweetNoteTweetInlineMedia>
{
    /// <inheritdoc/>
    public SearchTweetNoteTweetInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweetNoteTweetInlineMedia.FromRawUnchecked(rawData);
}
