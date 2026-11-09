using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Users;

/// <summary>
/// Returns the user's timeline with replies included by default.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class UserRetrieveRepliesParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Words or quoted phrases where any one can match. Separate with spaces, commas,
    /// or lines.
    /// </summary>
    public string? AnyWords
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("anyWords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("anyWords", value);
        }
    }

    /// <summary>
    /// Cashtags separated by spaces, commas, or lines.
    /// </summary>
    public string? Cashtags
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cashtags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cashtags", value);
        }
    }

    /// <summary>
    /// Conversation ID filter.
    /// </summary>
    public string? ConversationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("conversationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("conversationId", value);
        }
    }

    /// <summary>
    /// Pagination cursor for user replies
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Exact phrase to match.
    /// </summary>
    public string? ExactPhrase
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("exactPhrase");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("exactPhrase", value);
        }
    }

    /// <summary>
    /// Words or quoted phrases to exclude. Separate with spaces, commas, or lines.
    /// </summary>
    public string? ExcludeWords
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("excludeWords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("excludeWords", value);
        }
    }

    /// <summary>
    /// Filter by author username.
    /// </summary>
    public string? FromUser
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fromUser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fromUser", value);
        }
    }

    /// <summary>
    /// Hashtags separated by spaces, commas, or lines.
    /// </summary>
    public string? Hashtags
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("hashtags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hashtags", value);
        }
    }

    /// <summary>
    /// Keep only posts whose photos show this. Send charts, screenshots, product_photos, memes
    /// or people, or describe it in words, such as a rocket. AI-powered analysis checks posts
    /// with photos X doesn't mark sensitive &amp; keeps scores of 0.5 or more. Other posts stay
    /// out at no charge. Each kept post costs 2 credits, the AI analysis price, instead of the
    /// read price, &amp; a post the filter drops costs nothing. imageFilter states the cutoff
    /// &amp; counts.
    /// </summary>
    public string? ImageShows
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("imageShows");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("imageShows", value);
        }
    }

    /// <summary>
    /// Include each reply's parent tweet.
    /// </summary>
    public bool? IncludeParentTweet
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeParentTweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeParentTweet", value);
        }
    }

    /// <summary>
    /// Only replies to this tweet ID.
    /// </summary>
    public string? InReplyToTweetID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("inReplyToTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("inReplyToTweetId", value);
        }
    }

    /// <summary>
    /// Language code filter, e.g. en or tr.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("language", value);
        }
    }

    /// <summary>
    /// Filter by media type.
    /// </summary>
    public ApiEnum<string, UserRetrieveRepliesParamsMediaType>? MediaType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, UserRetrieveRepliesParamsMediaType>
            >("mediaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("mediaType", value);
        }
    }

    /// <summary>
    /// Filter tweets mentioning a username.
    /// </summary>
    public string? Mentioning
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("mentioning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("mentioning", value);
        }
    }

    /// <summary>
    /// Minimum likes threshold.
    /// </summary>
    public long? MinFaves
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minFaves");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minFaves", value);
        }
    }

    /// <summary>
    /// Minimum quote count threshold.
    /// </summary>
    public long? MinQuotes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minQuotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minQuotes", value);
        }
    }

    /// <summary>
    /// Minimum replies threshold.
    /// </summary>
    public long? MinReplies
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minReplies", value);
        }
    }

    /// <summary>
    /// Minimum retweets threshold.
    /// </summary>
    public long? MinRetweets
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minRetweets", value);
        }
    }

    /// <summary>
    /// Maximum page items (1-100, default 20). Source, filters, or credits can reduce
    /// results. Continue while has_next_page is true. Deprecated limit and count
    /// aliases remain accepted.
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("pageSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("pageSize", value);
        }
    }

    /// <summary>
    /// Quote mode.
    /// </summary>
    public ApiEnum<string, UserRetrieveRepliesParamsQuotes>? Quotes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, UserRetrieveRepliesParamsQuotes>
            >("quotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("quotes", value);
        }
    }

    /// <summary>
    /// Only quotes of this tweet ID.
    /// </summary>
    public string? QuotesOfTweetID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("quotesOfTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("quotesOfTweetId", value);
        }
    }

    /// <summary>
    /// Reply mode.
    /// </summary>
    public ApiEnum<string, UserRetrieveRepliesParamsReplies>? Replies
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, UserRetrieveRepliesParamsReplies>
            >("replies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("replies", value);
        }
    }

    /// <summary>
    /// Retweet mode.
    /// </summary>
    public ApiEnum<string, UserRetrieveRepliesParamsRetweets>? Retweets
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, UserRetrieveRepliesParamsRetweets>
            >("retweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("retweets", value);
        }
    }

    /// <summary>
    /// Only retweets of this tweet ID.
    /// </summary>
    public string? RetweetsOfTweetID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("retweetsOfTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("retweetsOfTweetId", value);
        }
    }

    /// <summary>
    /// Start date in YYYY-MM-DD format.
    /// </summary>
    public string? SinceDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sinceDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sinceDate", value);
        }
    }

    /// <summary>
    /// Keep only posts about this topic. AI-powered analysis asks "Is this post about
    /// &lt;topic&gt;?" of each post &amp; keeps scores of 0.5 or more. It reads post text &amp;
    /// safe photos. Each kept post costs 2 credits, the AI analysis price, instead of the read
    /// price, &amp; a post the filter drops costs nothing. limit counts checked posts, &amp;
    /// only kept posts come back. topicFilter states the cutoff &amp; counts.
    /// </summary>
    public string? Topic
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("topic", value);
        }
    }

    /// <summary>
    /// Filter replies sent to a username.
    /// </summary>
    public string? ToUser
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("toUser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("toUser", value);
        }
    }

    /// <summary>
    /// End date in YYYY-MM-DD format.
    /// </summary>
    public string? UntilDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("untilDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("untilDate", value);
        }
    }

    /// <summary>
    /// URL substring or domain filter.
    /// </summary>
    public string? UrlValue
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("url", value);
        }
    }

    /// <summary>
    /// Only return tweets from verified authors.
    /// </summary>
    public bool? VerifiedOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("verifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("verifiedOnly", value);
        }
    }

    /// <summary>
    /// Optional legacy pagination override. Filters such as keywords don't apply with it.
    /// </summary>
    public ApiEnum<string, UserRetrieveRepliesParamsMode>? Mode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, UserRetrieveRepliesParamsMode>
            >("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("mode", value);
        }
    }

    /// <summary>
    /// Inclusive ISO bound for Tweet creation time, such as 2026-09-25T19:20:41Z. Unix seconds also work. A time without an offset is UTC.
    /// </summary>
    public string? SinceTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sinceTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sinceTime", value);
        }
    }

    /// <summary>
    /// Exclusive ISO bound for Tweet creation time. Unix seconds also work. A time without an offset is UTC.
    /// </summary>
    public string? UntilTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("untilTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("untilTime", value);
        }
    }

    /// <summary>
    /// Minimum likes. Its aliases are minFaves, min_likes &amp; min_faves.
    /// </summary>
    public long? MinLikes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minLikes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minLikes", value);
        }
    }

    /// <summary>
    /// Minimum view count threshold.
    /// </summary>
    public long? MinViews
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minViews");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minViews", value);
        }
    }

    /// <summary>
    /// Minimum bookmark count threshold.
    /// </summary>
    public long? MinBookmarks
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minBookmarks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minBookmarks", value);
        }
    }

    /// <summary>
    /// Maximum likes threshold. maxLikes &amp; max_likes also work.
    /// </summary>
    public long? MaxFaves
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxFaves");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxFaves", value);
        }
    }

    /// <summary>
    /// Maximum retweets threshold.
    /// </summary>
    public long? MaxRetweets
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxRetweets", value);
        }
    }

    /// <summary>
    /// Maximum replies threshold.
    /// </summary>
    public long? MaxReplies
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxReplies", value);
        }
    }

    /// <summary>
    /// Maximum quotes threshold.
    /// </summary>
    public long? MaxQuotes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxQuotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxQuotes", value);
        }
    }

    /// <summary>
    /// Only return tweets from Blue-verified authors.
    /// </summary>
    public bool? BlueVerifiedOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("blueVerifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("blueVerifiedOnly", value);
        }
    }

    /// <summary>
    /// Keep only Tweets with this card type, such as poll2choice_text_only. Every returned Tweet has it.
    /// </summary>
    public string? CardName
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cardName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cardName", value);
        }
    }

    /// <summary>
    /// `source` isn't supported. A Tweet search with it answers 424 &amp; charges nothing.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("source", value);
        }
    }

    /// <summary>
    /// `excludeSource` isn't supported. A Tweet search with it answers 424 &amp; charges nothing.
    /// </summary>
    public string? ExcludeSource
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("excludeSource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("excludeSource", value);
        }
    }

    /// <summary>
    /// `geocode` isn't supported. A Tweet search with it answers 424 &amp; charges nothing.
    /// </summary>
    public string? Geocode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("geocode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("geocode", value);
        }
    }

    /// <summary>
    /// Return Tweets whose IDs exceed this ID. Searches accept `since_id` &amp; `max_id` bounds.
    /// </summary>
    public string? SinceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sinceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sinceId", value);
        }
    }

    /// <summary>
    /// Return Tweets at or below this ID.
    /// </summary>
    public string? MaxID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("maxId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxId", value);
        }
    }

    /// <summary>
    /// A place name, such as a city or a country. Matching Tweets are tagged in or about that place.
    /// </summary>
    public string? Near
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("near");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("near", value);
        }
    }

    /// <summary>
    /// `within` isn't supported. A Tweet search with it answers 424 &amp; charges nothing. Use near alone.
    /// </summary>
    public string? Within
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("within", value);
        }
    }

    /// <summary>
    /// Keeps Tweets from a recent window, such as 90m or 7d. Use a whole number &amp; s, m, h or d.
    /// </summary>
    public string? WithinTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("withinTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("withinTime", value);
        }
    }

    /// <summary>
    /// Only return native reposts.
    /// </summary>
    public bool? NativeRetweets
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("nativeRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("nativeRetweets", value);
        }
    }

    /// <summary>
    /// Enable the safe-search filter.
    /// </summary>
    public bool? Safe
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("safe");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("safe", value);
        }
    }

    /// <summary>
    /// `news` isn't supported. A Tweet search with it answers 424 &amp; charges nothing.
    /// </summary>
    public bool? News
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("news");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("news", value);
        }
    }

    /// <summary>
    /// Words the Tweets must match, in X search syntax.
    /// </summary>
    public string? Keywords
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("keywords", value);
        }
    }

    /// <summary>
    /// Search within a list ID.
    /// </summary>
    public string? ListID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("listId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("listId", value);
        }
    }

    /// <summary>
    /// Search within a place ID.
    /// </summary>
    public string? Place
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("place");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("place", value);
        }
    }

    /// <summary>
    /// Search within a country code.
    /// </summary>
    public string? PlaceCountry
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("placeCountry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("placeCountry", value);
        }
    }

    /// <summary>
    /// Geo point radius, such as -73.99 40.73 25mi.
    /// </summary>
    public string? PointRadius
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("pointRadius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("pointRadius", value);
        }
    }

    /// <summary>
    /// Geo bounding box, such as -74.1 40.6 -73.9 40.8.
    /// </summary>
    public string? BoundingBox
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("boundingBox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("boundingBox", value);
        }
    }

    /// <summary>
    /// Raw advanced search query appended as-is.
    /// </summary>
    public string? AdvancedQuery
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("advancedQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("advancedQuery", value);
        }
    }

    /// <summary>
    /// Fields to keep in each row, comma-separated. Use dots for nested fields, such as author.username. A list keeps the field in each item. Case &amp; underscores do not matter. A row that lacks a field leaves it out. Cursors, counts &amp; diagnostics always stay. An unknown name answers 400 unknown_field with the valid names, before any read. The price stays the same. SDK row types then hold only the named fields. A longer URL fails at the edge before Xquik reads it. Pick only the fields you need with `fields` &amp; `omit`.
    /// </summary>
    public string? Fields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fields", value);
        }
    }

    /// <summary>
    /// Fields to drop from each row, comma-separated. It takes the same names as fields. With fields, it drops from the kept fields. A longer URL fails at the edge before Xquik reads it.
    /// </summary>
    public string? Omit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("omit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("omit", value);
        }
    }

    public UserRetrieveRepliesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveRepliesParams(UserRetrieveRepliesParams userRetrieveRepliesParams)
        : base(userRetrieveRepliesParams)
    {
        this.ID = userRetrieveRepliesParams.ID;
    }
#pragma warning restore CS8618

    public UserRetrieveRepliesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveRepliesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserRetrieveRepliesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UserRetrieveRepliesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/x/users/{0}/replies", this.ID)
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Filter by media type.
/// </summary>
[JsonConverter(typeof(UserRetrieveRepliesParamsMediaTypeConverter))]
public enum UserRetrieveRepliesParamsMediaType
{
    Images,
    Videos,
    Gifs,
    Media,
    Links,
    None,
}

sealed class UserRetrieveRepliesParamsMediaTypeConverter
    : JsonConverter<UserRetrieveRepliesParamsMediaType>
{
    public override UserRetrieveRepliesParamsMediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "images" => UserRetrieveRepliesParamsMediaType.Images,
            "videos" => UserRetrieveRepliesParamsMediaType.Videos,
            "gifs" => UserRetrieveRepliesParamsMediaType.Gifs,
            "media" => UserRetrieveRepliesParamsMediaType.Media,
            "links" => UserRetrieveRepliesParamsMediaType.Links,
            "none" => UserRetrieveRepliesParamsMediaType.None,
            _ => (UserRetrieveRepliesParamsMediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveRepliesParamsMediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveRepliesParamsMediaType.Images => "images",
                UserRetrieveRepliesParamsMediaType.Videos => "videos",
                UserRetrieveRepliesParamsMediaType.Gifs => "gifs",
                UserRetrieveRepliesParamsMediaType.Media => "media",
                UserRetrieveRepliesParamsMediaType.Links => "links",
                UserRetrieveRepliesParamsMediaType.None => "none",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Quote mode.
/// </summary>
[JsonConverter(typeof(UserRetrieveRepliesParamsQuotesConverter))]
public enum UserRetrieveRepliesParamsQuotes
{
    Include,
    Exclude,
    Only,
}

sealed class UserRetrieveRepliesParamsQuotesConverter
    : JsonConverter<UserRetrieveRepliesParamsQuotes>
{
    public override UserRetrieveRepliesParamsQuotes Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => UserRetrieveRepliesParamsQuotes.Include,
            "exclude" => UserRetrieveRepliesParamsQuotes.Exclude,
            "only" => UserRetrieveRepliesParamsQuotes.Only,
            _ => (UserRetrieveRepliesParamsQuotes)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveRepliesParamsQuotes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveRepliesParamsQuotes.Include => "include",
                UserRetrieveRepliesParamsQuotes.Exclude => "exclude",
                UserRetrieveRepliesParamsQuotes.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reply mode.
/// </summary>
[JsonConverter(typeof(UserRetrieveRepliesParamsRepliesConverter))]
public enum UserRetrieveRepliesParamsReplies
{
    Include,
    Exclude,
    Only,
}

sealed class UserRetrieveRepliesParamsRepliesConverter
    : JsonConverter<UserRetrieveRepliesParamsReplies>
{
    public override UserRetrieveRepliesParamsReplies Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => UserRetrieveRepliesParamsReplies.Include,
            "exclude" => UserRetrieveRepliesParamsReplies.Exclude,
            "only" => UserRetrieveRepliesParamsReplies.Only,
            _ => (UserRetrieveRepliesParamsReplies)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveRepliesParamsReplies value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveRepliesParamsReplies.Include => "include",
                UserRetrieveRepliesParamsReplies.Exclude => "exclude",
                UserRetrieveRepliesParamsReplies.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Retweet mode.
/// </summary>
[JsonConverter(typeof(UserRetrieveRepliesParamsRetweetsConverter))]
public enum UserRetrieveRepliesParamsRetweets
{
    Include,
    Exclude,
    Only,
}

sealed class UserRetrieveRepliesParamsRetweetsConverter
    : JsonConverter<UserRetrieveRepliesParamsRetweets>
{
    public override UserRetrieveRepliesParamsRetweets Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => UserRetrieveRepliesParamsRetweets.Include,
            "exclude" => UserRetrieveRepliesParamsRetweets.Exclude,
            "only" => UserRetrieveRepliesParamsRetweets.Only,
            _ => (UserRetrieveRepliesParamsRetweets)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveRepliesParamsRetweets value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveRepliesParamsRetweets.Include => "include",
                UserRetrieveRepliesParamsRetweets.Exclude => "exclude",
                UserRetrieveRepliesParamsRetweets.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(UserRetrieveRepliesParamsModeConverter))]
public enum UserRetrieveRepliesParamsMode
{
    Standard,
}

sealed class UserRetrieveRepliesParamsModeConverter : JsonConverter<UserRetrieveRepliesParamsMode>
{
    public override UserRetrieveRepliesParamsMode Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => UserRetrieveRepliesParamsMode.Standard,
            _ => (UserRetrieveRepliesParamsMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserRetrieveRepliesParamsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserRetrieveRepliesParamsMode.Standard => "standard",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
