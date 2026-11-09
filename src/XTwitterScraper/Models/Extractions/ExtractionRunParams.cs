// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// Run extraction
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class ExtractionRunParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionRunParamsToolType> ToolType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ExtractionRunParamsToolType>>(
                "toolType"
            );
        }
        init { this._rawBodyData.Set("toolType", value); }
    }

    /// <summary>
    /// Raw advanced search query appended as-is (tweet_search_extractor)
    /// </summary>
    public string? AdvancedQuery
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("advancedQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("advancedQuery", value);
        }
    }

    /// <summary>
    /// Words or quoted phrases where any one can match. Separate with spaces, commas,
    /// or lines. (tweet_search_extractor)
    /// </summary>
    public string? AnyWords
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("anyWords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("anyWords", value);
        }
    }

    /// <summary>
    /// Geo bounding box, e.g. -74.1 40.6 -73.9 40.8 (tweet_search_extractor)
    /// </summary>
    public string? BoundingBox
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("boundingBox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("boundingBox", value);
        }
    }

    /// <summary>
    /// Cashtags separated by spaces, commas, or lines. (tweet_search_extractor)
    /// </summary>
    public string? Cashtags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cashtags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cashtags", value);
        }
    }

    /// <summary>
    /// Conversation ID filter (tweet_search_extractor)
    /// </summary>
    public string? ConversationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("conversationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("conversationId", value);
        }
    }

    /// <summary>
    /// Exact phrase to match (tweet_search_extractor)
    /// </summary>
    public string? ExactPhrase
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("exactPhrase");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("exactPhrase", value);
        }
    }

    /// <summary>
    /// Words or quoted phrases to exclude. Separate with spaces, commas, or lines. (tweet_search_extractor)
    /// </summary>
    public string? ExcludeWords
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("excludeWords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("excludeWords", value);
        }
    }

    /// <summary>
    /// Filter by author username (tweet_search_extractor)
    /// </summary>
    public string? FromUser
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("fromUser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("fromUser", value);
        }
    }

    /// <summary>
    /// Hashtags separated by spaces, commas, or lines. (tweet_search_extractor)
    /// </summary>
    public string? Hashtags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("hashtags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hashtags", value);
        }
    }

    /// <summary>
    /// Keep only the posts whose photos show this. Use charts, screenshots, product_photos,
    /// memes or people, or describe it in your own words. Each post with a safe photo is
    /// checked, &amp; each stored post costs 2 credits instead of its read price. Posts without
    /// a safe photo aren't checked, billed or stored, &amp; a post the filter drops costs
    /// nothing. resultsLimit caps the posts read. Works with tools that return posts. Send
    /// topic or imageShows, not both.
    /// </summary>
    public string? ImageShows
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("imageShows");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("imageShows", value);
        }
    }

    /// <summary>
    /// Only replies to this tweet ID (tweet_search_extractor)
    /// </summary>
    public string? InReplyToTweetID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("inReplyToTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("inReplyToTweetId", value);
        }
    }

    /// <summary>
    /// Language code filter (tweet_search_extractor)
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    /// <summary>
    /// Search within a list ID (tweet_search_extractor)
    /// </summary>
    public string? ListID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("listId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("listId", value);
        }
    }

    /// <summary>
    /// Media type filter (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsMediaType>? MediaType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionRunParamsMediaType>
            >("mediaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mediaType", value);
        }
    }

    /// <summary>
    /// Filter tweets mentioning a username (tweet_search_extractor)
    /// </summary>
    public string? Mentioning
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("mentioning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mentioning", value);
        }
    }

    /// <summary>
    /// Minimum likes threshold (tweet_search_extractor)
    /// </summary>
    public long? MinFaves
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minFaves");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minFaves", value);
        }
    }

    /// <summary>
    /// Minimum quote count threshold (tweet_search_extractor)
    /// </summary>
    public long? MinQuotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minQuotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minQuotes", value);
        }
    }

    /// <summary>
    /// Minimum replies threshold (tweet_search_extractor)
    /// </summary>
    public long? MinReplies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minReplies", value);
        }
    }

    /// <summary>
    /// Minimum retweets threshold (tweet_search_extractor)
    /// </summary>
    public long? MinRetweets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minRetweets", value);
        }
    }

    /// <summary>
    /// Search within a place ID (tweet_search_extractor)
    /// </summary>
    public string? Place
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("place");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("place", value);
        }
    }

    /// <summary>
    /// Search within a country code (tweet_search_extractor)
    /// </summary>
    public string? PlaceCountry
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("placeCountry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("placeCountry", value);
        }
    }

    /// <summary>
    /// Geo point radius, e.g. -73.99 40.73 25mi (tweet_search_extractor)
    /// </summary>
    public string? PointRadius
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("pointRadius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("pointRadius", value);
        }
    }

    /// <summary>
    /// Quote mode (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsQuotes>? Quotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExtractionRunParamsQuotes>>(
                "quotes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("quotes", value);
        }
    }

    /// <summary>
    /// Only quotes of this tweet ID (tweet_search_extractor)
    /// </summary>
    public string? QuotesOfTweetID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("quotesOfTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("quotesOfTweetId", value);
        }
    }

    /// <summary>
    /// Reply mode (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsReplies>? Replies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExtractionRunParamsReplies>>(
                "replies"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("replies", value);
        }
    }

    /// <summary>
    /// Maximum number of results to extract. When set, the extraction stops after
    /// reaching this limit.
    /// </summary>
    public long? ResultsLimit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("resultsLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("resultsLimit", value);
        }
    }

    /// <summary>
    /// Retweet mode (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsRetweets>? Retweets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExtractionRunParamsRetweets>>(
                "retweets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("retweets", value);
        }
    }

    /// <summary>
    /// Only retweets of this tweet ID (tweet_search_extractor)
    /// </summary>
    public string? RetweetsOfTweetID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("retweetsOfTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("retweetsOfTweetId", value);
        }
    }

    /// <summary>
    /// Required for tweet_search_extractor &amp; community_search.
    /// </summary>
    public string? SearchQuery
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("searchQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("searchQuery", value);
        }
    }

    /// <summary>
    /// Start date YYYY-MM-DD (tweet_search_extractor)
    /// </summary>
    public string? SinceDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sinceDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sinceDate", value);
        }
    }

    /// <summary>
    /// Required for community_post_extractor &amp; community_search.
    /// </summary>
    public string? TargetCommunityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetCommunityId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetCommunityId", value);
        }
    }

    /// <summary>
    /// Required for list_follower_explorer, list_member_extractor &amp; list_post_extractor.
    /// </summary>
    public string? TargetListID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetListId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetListId", value);
        }
    }

    /// <summary>
    /// Required for space_explorer.
    /// </summary>
    public string? TargetSpaceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetSpaceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetSpaceId", value);
        }
    }

    public string? TargetTweetID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetTweetId", value);
        }
    }

    public string? TargetUsername
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("targetUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("targetUsername", value);
        }
    }

    /// <summary>
    /// Keep only the posts about this topic, such as "the Rust programming language". Each post
    /// the job reads is checked, only matching posts are stored, &amp; each stored post costs 2
    /// credits instead of its read price. A post the filter drops costs nothing. resultsLimit
    /// caps the posts read &amp; checked. Works with tools that return posts. Send topic or
    /// imageShows, not both.
    /// </summary>
    public string? Topic
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("topic", value);
        }
    }

    /// <summary>
    /// Filter replies sent to a username (tweet_search_extractor)
    /// </summary>
    public string? ToUser
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("toUser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("toUser", value);
        }
    }

    /// <summary>
    /// End date YYYY-MM-DD (tweet_search_extractor)
    /// </summary>
    public string? UntilDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("untilDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("untilDate", value);
        }
    }

    /// <summary>
    /// URL substring or domain filter (tweet_search_extractor)
    /// </summary>
    public string? UrlValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("url", value);
        }
    }

    /// <summary>
    /// Only verified authors (tweet_search_extractor)
    /// </summary>
    public bool? VerifiedOnly
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("verifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("verifiedOnly", value);
        }
    }

    /// <summary>
    /// Tweet IDs processed as 1 collection job.
    /// </summary>
    public IReadOnlyList<string>? TargetTweetIDs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("targetTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "targetTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Usernames processed concurrently in 1 job. With tweet_search_extractor, each username collects posts. Post &amp; media jobs skip a protected profile &amp; end with partial_failure.
    /// </summary>
    public IReadOnlyList<string>? TargetUsernames
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("targetUsernames");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "targetUsernames",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Community IDs processed as 1 collection job.
    /// </summary>
    public IReadOnlyList<string>? TargetCommunityIDs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "targetCommunityIds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "targetCommunityIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List IDs processed as 1 collection job.
    /// </summary>
    public IReadOnlyList<string>? TargetListIDs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("targetListIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "targetListIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Search queries processed as 1 collection job. Each follows the rules of searchQuery, its structured fields &amp; 512-character limit included.
    /// </summary>
    public IReadOnlyList<string>? SearchQueries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("searchQueries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "searchQueries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Mixed targets auto-routed within 1 job. Use tweet, replies, quotes, thread, or profile_media kinds to collect attached media. The job skips protected profiles &amp; ends with partial_failure.
    /// </summary>
    public IReadOnlyList<JsonElement>? Targets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<JsonElement>>("targets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<JsonElement>?>(
                "targets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Profile relations processed within 1 job. The job skips protected profiles &amp; ends with partial_failure.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.ExtractionRelationTarget>? RelationTargets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.ExtractionRelationTarget>
            >("relationTargets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<global::XTwitterScraper.Models.ExtractionRelationTarget>?>(
                "relationTargets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Use Top for engagement. The relevance alias maps to Top.
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsQueryType>? QueryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionRunParamsQueryType>
            >("queryType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("queryType", value);
        }
    }

    /// <summary>
    /// Maximum results collected for each target.
    /// </summary>
    public long? MaxItemsPerTarget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxItemsPerTarget");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxItemsPerTarget", value);
        }
    }

    /// <summary>
    /// Reply pages collected for each target.
    /// </summary>
    public long? MaxPagesPerTarget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxPagesPerTarget");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxPagesPerTarget", value);
        }
    }

    /// <summary>
    /// Resume 1 reply target from this cursor.
    /// </summary>
    public string? StartCursor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("startCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startCursor", value);
        }
    }

    /// <summary>
    /// Merge duplicate results across collection targets.
    /// </summary>
    public bool? DedupeAcrossTargets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("dedupeAcrossTargets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dedupeAcrossTargets", value);
        }
    }

    /// <summary>
    /// Keep target duplicates, first rows, or merged overlap.
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsDedupeMode>? DedupeMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionRunParamsDedupeMode>
            >("dedupeMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dedupeMode", value);
        }
    }

    /// <summary>
    /// Shortcut for dedupeMode=merge.
    /// </summary>
    public bool? OverlapMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overlapMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overlapMode", value);
        }
    }

    /// <summary>
    /// Add matching search terms to collection metadata.
    /// </summary>
    public bool? IncludeSearchTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeSearchTerms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeSearchTerms", value);
        }
    }

    /// <summary>
    /// Add source target metadata to each result.
    /// </summary>
    public bool? IncludeTargetMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeTargetMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeTargetMetadata", value);
        }
    }

    /// <summary>
    /// Add each user's full profile to follower_explorer, following_explorer, verified_follower_explorer, people_search &amp; repost_extractor rows. Jobs take longer.
    /// </summary>
    public bool? EnrichProfiles
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enrichProfiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enrichProfiles", value);
        }
    }

    /// <summary>
    /// Reply collection strategy.
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsCollectionStrategy>? CollectionStrategy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionRunParamsCollectionStrategy>
            >("collectionStrategy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("collectionStrategy", value);
        }
    }

    /// <summary>
    /// Reply depth scope.
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsScope>? Scope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExtractionRunParamsScope>>(
                "scope"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scope", value);
        }
    }

    /// <summary>
    /// Maximum nested reply depth.
    /// </summary>
    public long? MaxDepth
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxDepth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxDepth", value);
        }
    }

    /// <summary>
    /// Reply result order.
    /// </summary>
    public ApiEnum<string, ExtractionRunParamsSort>? Sort
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ExtractionRunParamsSort>>(
                "sort"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sort", value);
        }
    }

    /// <summary>
    /// Exclude replies from the source author.
    /// </summary>
    public bool? ExcludeOriginalAuthor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("excludeOriginalAuthor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("excludeOriginalAuthor", value);
        }
    }

    /// <summary>
    /// Include the source post in reply results.
    /// </summary>
    public bool? IncludeOriginalPost
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeOriginalPost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeOriginalPost", value);
        }
    }

    /// <summary>
    /// Return only replies with media.
    /// </summary>
    public bool? HasMediaOnly
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasMediaOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasMediaOnly", value);
        }
    }

    /// <summary>
    /// Reply start time as ISO 8601 or Unix seconds.
    /// </summary>
    public JsonElement? SinceTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("sinceTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sinceTime", value);
        }
    }

    /// <summary>
    /// Reply end time as ISO 8601 or Unix seconds.
    /// </summary>
    public JsonElement? UntilTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("untilTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("untilTime", value);
        }
    }

    /// <summary>
    /// Tweet or Community search minimum views.
    /// </summary>
    public long? MinViews
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minViews");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minViews", value);
        }
    }

    /// <summary>
    /// Minimum Tweet bookmark count.
    /// </summary>
    public long? MinBookmarks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minBookmarks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minBookmarks", value);
        }
    }

    /// <summary>
    /// Maximum Tweet like count.
    /// </summary>
    public long? MaxLikes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxLikes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxLikes", value);
        }
    }

    /// <summary>
    /// Maximum Tweet repost count.
    /// </summary>
    public long? MaxRetweets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxRetweets", value);
        }
    }

    /// <summary>
    /// Maximum Tweet reply count.
    /// </summary>
    public long? MaxReplies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxReplies", value);
        }
    }

    /// <summary>
    /// Maximum Tweet quote count.
    /// </summary>
    public long? MaxQuotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxQuotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxQuotes", value);
        }
    }

    /// <summary>
    /// Collects a post only when 1 of these words or quoted phrases is in its text, a link, its card or a quoted post. The author's name and username don't count.
    /// </summary>
    public string? TextOnlyTerms
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("textOnlyTerms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("textOnlyTerms", value);
        }
    }

    /// <summary>
    /// Return only Blue-verified Tweet authors. On a tool that returns users, return only profiles X marks as blue verified.
    /// </summary>
    public bool? BlueVerifiedOnly
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("blueVerifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("blueVerifiedOnly", value);
        }
    }

    /// <summary>
    /// Require Tweet cards whose name matches this value.
    /// </summary>
    public string? CardName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cardName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cardName", value);
        }
    }

    /// <summary>
    /// `source` isn't supported. An extraction with it answers 424 `search_unavailable` &amp; charges nothing.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("source", value);
        }
    }

    /// <summary>
    /// It has no effect, so an extraction with it returns unfiltered rows. Its answers carry `Deprecation` &amp; `Sunset` headers. From 2027-01-15 an extraction with it answers 424 `search_unavailable` &amp; charges nothing.
    /// </summary>
    public string? ExcludeSource
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("excludeSource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("excludeSource", value);
        }
    }

    /// <summary>
    /// `geocode` isn't supported. An extraction with it answers 424 `search_unavailable` &amp; charges nothing.
    /// </summary>
    public string? Geocode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("geocode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("geocode", value);
        }
    }

    /// <summary>
    /// Require Tweet IDs above this ID.
    /// </summary>
    public string? SinceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sinceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sinceId", value);
        }
    }

    /// <summary>
    /// Require Tweet IDs at or below this ID.
    /// </summary>
    public string? MaxID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("maxId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxId", value);
        }
    }

    /// <summary>
    /// Restrict Tweet search to this place name, such as a city or a country. Matching Tweets are tagged in or about that place.
    /// </summary>
    public string? Near
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("near");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("near", value);
        }
    }

    /// <summary>
    /// Not supported. An extraction with it answers 424 `search_unavailable` &amp; charges nothing. Use near alone.
    /// </summary>
    public string? Within
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("within", value);
        }
    }

    /// <summary>
    /// Restrict Tweets to this recent time window.
    /// </summary>
    public string? WithinTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("withinTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("withinTime", value);
        }
    }

    /// <summary>
    /// Tweet or Community search native reposts.
    /// </summary>
    public bool? NativeRetweets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("nativeRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("nativeRetweets", value);
        }
    }

    /// <summary>
    /// Apply safe-search filtering to Tweet results.
    /// </summary>
    public bool? Safe
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("safe");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("safe", value);
        }
    }

    /// <summary>
    /// `news` isn't supported. An extraction with news true answers 424 `search_unavailable` &amp; charges nothing.
    /// </summary>
    public bool? News
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("news");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("news", value);
        }
    }

    /// <summary>
    /// Minimum follower count for profile results.
    /// </summary>
    public long? MinFollowers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minFollowers", value);
        }
    }

    /// <summary>
    /// Maximum follower count for profile results.
    /// </summary>
    public long? MaxFollowers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxFollowers", value);
        }
    }

    /// <summary>
    /// Minimum following count for profile results.
    /// </summary>
    public long? MinFollowing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minFollowing", value);
        }
    }

    /// <summary>
    /// Maximum following count for profile results.
    /// </summary>
    public long? MaxFollowing
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxFollowing", value);
        }
    }

    /// <summary>
    /// Minimum post count for profile results.
    /// </summary>
    public long? MinPosts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minPosts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minPosts", value);
        }
    }

    /// <summary>
    /// Maximum post count for profile results.
    /// </summary>
    public long? MaxPosts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxPosts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxPosts", value);
        }
    }

    /// <summary>
    /// Minimum profile age in days.
    /// </summary>
    public long? MinAccountAgeDays
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("minAccountAgeDays");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("minAccountAgeDays", value);
        }
    }

    /// <summary>
    /// Exact profile verification type.
    /// </summary>
    public string? VerifiedType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Require a profile website.
    /// </summary>
    public bool? HasWebsite
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasWebsite");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasWebsite", value);
        }
    }

    /// <summary>
    /// Require a profile location.
    /// </summary>
    public bool? HasLocation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasLocation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasLocation", value);
        }
    }

    /// <summary>
    /// Require an email the profile publishes.
    /// </summary>
    public bool? HasEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasEmail", value);
        }
    }

    /// <summary>
    /// Require an email the profile publishes outside free webmail, such as Gmail.
    /// </summary>
    public bool? BusinessEmailOnly
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("businessEmailOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("businessEmailOnly", value);
        }
    }

    /// <summary>
    /// Require an email at one of these domains. Separate domains with commas. Subdomains match.
    /// </summary>
    public string? EmailDomains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("emailDomains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailDomains", value);
        }
    }

    /// <summary>
    /// Match any bio term, ignoring case. Separate terms with commas or lines.
    /// </summary>
    public string? BioContains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("bioContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("bioContains", value);
        }
    }

    /// <summary>
    /// Required profile location text.
    /// </summary>
    public string? LocationContains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("locationContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("locationContains", value);
        }
    }

    /// <summary>
    /// Required username text.
    /// </summary>
    public string? UsernameContains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("usernameContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("usernameContains", value);
        }
    }

    /// <summary>
    /// Estimate cost without creating an extraction.
    /// </summary>
    public bool? DryRun
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("dry_run");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("dry_run", value);
        }
    }

    public ExtractionRunParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRunParams(ExtractionRunParams extractionRunParams)
        : base(extractionRunParams)
    {
        this._rawBodyData = new(extractionRunParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExtractionRunParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionRunParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExtractionRunParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExtractionRunParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/extractions")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
/// Identifier for the extraction tool used to run a job.
/// </summary>
[JsonConverter(typeof(ExtractionRunParamsToolTypeConverter))]
public enum ExtractionRunParamsToolType
{
    ArticleExtractor,
    CommunityExtractor,
    CommunityModeratorExplorer,
    CommunityPostExtractor,
    CommunitySearch,
    Favoriters,
    FollowerExplorer,
    FollowingExplorer,
    ListFollowerExplorer,
    ListMemberExtractor,
    ListPostExtractor,
    MentionExtractor,
    PeopleSearch,
    PostExtractor,
    QuoteExtractor,
    ReplyExtractor,
    RepostExtractor,
    SpaceExplorer,
    ThreadExtractor,
    TweetSearchExtractor,
    UserAffiliates,
    UserLikes,
    UserMedia,
    VerifiedFollowerExplorer,
}

sealed class ExtractionRunParamsToolTypeConverter : JsonConverter<ExtractionRunParamsToolType>
{
    public override ExtractionRunParamsToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ExtractionRunParamsToolType.ArticleExtractor,
            "community_extractor" => ExtractionRunParamsToolType.CommunityExtractor,
            "community_moderator_explorer" =>
                ExtractionRunParamsToolType.CommunityModeratorExplorer,
            "community_post_extractor" => ExtractionRunParamsToolType.CommunityPostExtractor,
            "community_search" => ExtractionRunParamsToolType.CommunitySearch,
            "favoriters" => ExtractionRunParamsToolType.Favoriters,
            "follower_explorer" => ExtractionRunParamsToolType.FollowerExplorer,
            "following_explorer" => ExtractionRunParamsToolType.FollowingExplorer,
            "list_follower_explorer" => ExtractionRunParamsToolType.ListFollowerExplorer,
            "list_member_extractor" => ExtractionRunParamsToolType.ListMemberExtractor,
            "list_post_extractor" => ExtractionRunParamsToolType.ListPostExtractor,
            "mention_extractor" => ExtractionRunParamsToolType.MentionExtractor,
            "people_search" => ExtractionRunParamsToolType.PeopleSearch,
            "post_extractor" => ExtractionRunParamsToolType.PostExtractor,
            "quote_extractor" => ExtractionRunParamsToolType.QuoteExtractor,
            "reply_extractor" => ExtractionRunParamsToolType.ReplyExtractor,
            "repost_extractor" => ExtractionRunParamsToolType.RepostExtractor,
            "space_explorer" => ExtractionRunParamsToolType.SpaceExplorer,
            "thread_extractor" => ExtractionRunParamsToolType.ThreadExtractor,
            "tweet_search_extractor" => ExtractionRunParamsToolType.TweetSearchExtractor,
            "user_affiliates" => ExtractionRunParamsToolType.UserAffiliates,
            "user_likes" => ExtractionRunParamsToolType.UserLikes,
            "user_media" => ExtractionRunParamsToolType.UserMedia,
            "verified_follower_explorer" => ExtractionRunParamsToolType.VerifiedFollowerExplorer,
            _ => (ExtractionRunParamsToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsToolType.ArticleExtractor => "article_extractor",
                ExtractionRunParamsToolType.CommunityExtractor => "community_extractor",
                ExtractionRunParamsToolType.CommunityModeratorExplorer =>
                    "community_moderator_explorer",
                ExtractionRunParamsToolType.CommunityPostExtractor => "community_post_extractor",
                ExtractionRunParamsToolType.CommunitySearch => "community_search",
                ExtractionRunParamsToolType.Favoriters => "favoriters",
                ExtractionRunParamsToolType.FollowerExplorer => "follower_explorer",
                ExtractionRunParamsToolType.FollowingExplorer => "following_explorer",
                ExtractionRunParamsToolType.ListFollowerExplorer => "list_follower_explorer",
                ExtractionRunParamsToolType.ListMemberExtractor => "list_member_extractor",
                ExtractionRunParamsToolType.ListPostExtractor => "list_post_extractor",
                ExtractionRunParamsToolType.MentionExtractor => "mention_extractor",
                ExtractionRunParamsToolType.PeopleSearch => "people_search",
                ExtractionRunParamsToolType.PostExtractor => "post_extractor",
                ExtractionRunParamsToolType.QuoteExtractor => "quote_extractor",
                ExtractionRunParamsToolType.ReplyExtractor => "reply_extractor",
                ExtractionRunParamsToolType.RepostExtractor => "repost_extractor",
                ExtractionRunParamsToolType.SpaceExplorer => "space_explorer",
                ExtractionRunParamsToolType.ThreadExtractor => "thread_extractor",
                ExtractionRunParamsToolType.TweetSearchExtractor => "tweet_search_extractor",
                ExtractionRunParamsToolType.UserAffiliates => "user_affiliates",
                ExtractionRunParamsToolType.UserLikes => "user_likes",
                ExtractionRunParamsToolType.UserMedia => "user_media",
                ExtractionRunParamsToolType.VerifiedFollowerExplorer =>
                    "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Media type filter (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(ExtractionRunParamsMediaTypeConverter))]
public enum ExtractionRunParamsMediaType
{
    Images,
    Videos,
    Gifs,
    Media,
    Links,
    None,
}

sealed class ExtractionRunParamsMediaTypeConverter : JsonConverter<ExtractionRunParamsMediaType>
{
    public override ExtractionRunParamsMediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "images" => ExtractionRunParamsMediaType.Images,
            "videos" => ExtractionRunParamsMediaType.Videos,
            "gifs" => ExtractionRunParamsMediaType.Gifs,
            "media" => ExtractionRunParamsMediaType.Media,
            "links" => ExtractionRunParamsMediaType.Links,
            "none" => ExtractionRunParamsMediaType.None,
            _ => (ExtractionRunParamsMediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsMediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsMediaType.Images => "images",
                ExtractionRunParamsMediaType.Videos => "videos",
                ExtractionRunParamsMediaType.Gifs => "gifs",
                ExtractionRunParamsMediaType.Media => "media",
                ExtractionRunParamsMediaType.Links => "links",
                ExtractionRunParamsMediaType.None => "none",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Quote mode (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(ExtractionRunParamsQuotesConverter))]
public enum ExtractionRunParamsQuotes
{
    Include,
    Exclude,
    Only,
}

sealed class ExtractionRunParamsQuotesConverter : JsonConverter<ExtractionRunParamsQuotes>
{
    public override ExtractionRunParamsQuotes Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => ExtractionRunParamsQuotes.Include,
            "exclude" => ExtractionRunParamsQuotes.Exclude,
            "only" => ExtractionRunParamsQuotes.Only,
            _ => (ExtractionRunParamsQuotes)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsQuotes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsQuotes.Include => "include",
                ExtractionRunParamsQuotes.Exclude => "exclude",
                ExtractionRunParamsQuotes.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reply mode (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(ExtractionRunParamsRepliesConverter))]
public enum ExtractionRunParamsReplies
{
    Include,
    Exclude,
    Only,
}

sealed class ExtractionRunParamsRepliesConverter : JsonConverter<ExtractionRunParamsReplies>
{
    public override ExtractionRunParamsReplies Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => ExtractionRunParamsReplies.Include,
            "exclude" => ExtractionRunParamsReplies.Exclude,
            "only" => ExtractionRunParamsReplies.Only,
            _ => (ExtractionRunParamsReplies)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsReplies value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsReplies.Include => "include",
                ExtractionRunParamsReplies.Exclude => "exclude",
                ExtractionRunParamsReplies.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Retweet mode (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(ExtractionRunParamsRetweetsConverter))]
public enum ExtractionRunParamsRetweets
{
    Include,
    Exclude,
    Only,
}

sealed class ExtractionRunParamsRetweetsConverter : JsonConverter<ExtractionRunParamsRetweets>
{
    public override ExtractionRunParamsRetweets Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => ExtractionRunParamsRetweets.Include,
            "exclude" => ExtractionRunParamsRetweets.Exclude,
            "only" => ExtractionRunParamsRetweets.Only,
            _ => (ExtractionRunParamsRetweets)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsRetweets value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsRetweets.Include => "include",
                ExtractionRunParamsRetweets.Exclude => "exclude",
                ExtractionRunParamsRetweets.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRunParamsQueryTypeConverter))]
public enum ExtractionRunParamsQueryType
{
    Latest,
    Top,
    Both,
    Relevance,
}

sealed class ExtractionRunParamsQueryTypeConverter : JsonConverter<ExtractionRunParamsQueryType>
{
    public override ExtractionRunParamsQueryType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => ExtractionRunParamsQueryType.Latest,
            "Top" => ExtractionRunParamsQueryType.Top,
            "Both" => ExtractionRunParamsQueryType.Both,
            "relevance" => ExtractionRunParamsQueryType.Relevance,
            _ => (ExtractionRunParamsQueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsQueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsQueryType.Latest => "Latest",
                ExtractionRunParamsQueryType.Top => "Top",
                ExtractionRunParamsQueryType.Both => "Both",
                ExtractionRunParamsQueryType.Relevance => "relevance",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRunParamsDedupeModeConverter))]
public enum ExtractionRunParamsDedupeMode
{
    None,
    First,
    Merge,
}

sealed class ExtractionRunParamsDedupeModeConverter : JsonConverter<ExtractionRunParamsDedupeMode>
{
    public override ExtractionRunParamsDedupeMode Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => ExtractionRunParamsDedupeMode.None,
            "first" => ExtractionRunParamsDedupeMode.First,
            "merge" => ExtractionRunParamsDedupeMode.Merge,
            _ => (ExtractionRunParamsDedupeMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsDedupeMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsDedupeMode.None => "none",
                ExtractionRunParamsDedupeMode.First => "first",
                ExtractionRunParamsDedupeMode.Merge => "merge",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRunParamsCollectionStrategyConverter))]
public enum ExtractionRunParamsCollectionStrategy
{
    Auto,
    Complete,
    Direct,
    Search,
    Thread,
}

sealed class ExtractionRunParamsCollectionStrategyConverter
    : JsonConverter<ExtractionRunParamsCollectionStrategy>
{
    public override ExtractionRunParamsCollectionStrategy Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ExtractionRunParamsCollectionStrategy.Auto,
            "complete" => ExtractionRunParamsCollectionStrategy.Complete,
            "direct" => ExtractionRunParamsCollectionStrategy.Direct,
            "search" => ExtractionRunParamsCollectionStrategy.Search,
            "thread" => ExtractionRunParamsCollectionStrategy.Thread,
            _ => (ExtractionRunParamsCollectionStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsCollectionStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsCollectionStrategy.Auto => "auto",
                ExtractionRunParamsCollectionStrategy.Complete => "complete",
                ExtractionRunParamsCollectionStrategy.Direct => "direct",
                ExtractionRunParamsCollectionStrategy.Search => "search",
                ExtractionRunParamsCollectionStrategy.Thread => "thread",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRunParamsScopeConverter))]
public enum ExtractionRunParamsScope
{
    All,
    Direct,
    Nested,
}

sealed class ExtractionRunParamsScopeConverter : JsonConverter<ExtractionRunParamsScope>
{
    public override ExtractionRunParamsScope Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => ExtractionRunParamsScope.All,
            "direct" => ExtractionRunParamsScope.Direct,
            "nested" => ExtractionRunParamsScope.Nested,
            _ => (ExtractionRunParamsScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsScope.All => "all",
                ExtractionRunParamsScope.Direct => "direct",
                ExtractionRunParamsScope.Nested => "nested",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRunParamsSortConverter))]
public enum ExtractionRunParamsSort
{
    Relevance,
    Latest,
    Oldest,
    Likes,
}

sealed class ExtractionRunParamsSortConverter : JsonConverter<ExtractionRunParamsSort>
{
    public override ExtractionRunParamsSort Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "relevance" => ExtractionRunParamsSort.Relevance,
            "latest" => ExtractionRunParamsSort.Latest,
            "oldest" => ExtractionRunParamsSort.Oldest,
            "likes" => ExtractionRunParamsSort.Likes,
            _ => (ExtractionRunParamsSort)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunParamsSort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunParamsSort.Relevance => "relevance",
                ExtractionRunParamsSort.Latest => "latest",
                ExtractionRunParamsSort.Oldest => "oldest",
                ExtractionRunParamsSort.Likes => "likes",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
