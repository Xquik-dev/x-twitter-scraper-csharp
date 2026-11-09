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
/// Estimate extraction cost
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class ExtractionEstimateCostParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionEstimateCostParamsToolType> ToolType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, ExtractionEstimateCostParamsToolType>
            >("toolType");
        }
        init { this._rawBodyData.Set("toolType", value); }
    }

    /// <summary>
    /// Raw advanced query string appended to the estimate (tweet_search_extractor)
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
    /// Alternative words or quoted phrases for estimated results. Separate with
    /// spaces, commas, or lines.
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
    /// Geo bounding box used for estimation, e.g. -74.1 40.6 -73.9 40.8 (tweet_search_extractor)
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
    /// Cashtags applied to the estimate, separated by spaces, commas, or lines.
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
    /// Conversation ID filter used for estimation (tweet_search_extractor)
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
    /// Exact phrase filter for search estimation
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
    /// Words or quoted phrases excluded from estimated results. Separate with spaces,
    /// commas, or lines.
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
    /// Estimate only tweets from this author username (tweet_search_extractor)
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
    /// Hashtags applied to the estimate, separated by spaces, commas, or lines.
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
    /// Estimate only replies to this tweet ID (tweet_search_extractor)
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
    /// Language code used for estimate filtering (tweet_search_extractor)
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
    /// Estimate search results within this list ID (tweet_search_extractor)
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
    /// Media type used for estimate filtering (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, MediaType>? MediaType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MediaType>>("mediaType");
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
    /// Estimate tweets mentioning this username (tweet_search_extractor)
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
    /// Minimum likes threshold for estimated results (tweet_search_extractor)
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
    /// Minimum quote count threshold for estimated results (tweet_search_extractor)
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
    /// Minimum replies threshold for estimated results (tweet_search_extractor)
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
    /// Minimum retweets threshold for estimated results (tweet_search_extractor)
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
    /// Estimate search results within this place ID (tweet_search_extractor)
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
    /// Estimate search results within this country code (tweet_search_extractor)
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
    /// Geo point radius used for estimation, e.g. -73.99 40.73 25mi (tweet_search_extractor)
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
    /// Quote mode used for estimation (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, Quotes>? Quotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Quotes>>("quotes");
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
    /// Estimate only quotes of this tweet ID (tweet_search_extractor)
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
    /// Reply mode used for estimation (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, Replies>? Replies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Replies>>("replies");
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
    /// Maximum number of results to estimate. When set, the estimate caps projected
    /// results to this value.
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
    /// Retweet mode used for estimation (tweet_search_extractor)
    /// </summary>
    public ApiEnum<string, Retweets>? Retweets
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Retweets>>("retweets");
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
    /// Estimate only retweets of this tweet ID (tweet_search_extractor)
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
    /// Query used to price tweet_search_extractor or community_search.
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
    /// Estimate start date in YYYY-MM-DD format (tweet_search_extractor)
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
    /// Community ID used to price community_post_extractor or community_search.
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
    /// List ID used to price list_follower_explorer, list_member_extractor, or list_post_extractor.
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
    /// Space ID used to price space_explorer.
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
    /// Estimate replies sent to this username (tweet_search_extractor)
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
    /// Estimate end date in YYYY-MM-DD format (tweet_search_extractor)
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
    /// URL substring or domain filter used for estimation (tweet_search_extractor)
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
    /// Estimate only verified authors (tweet_search_extractor)
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
    public ApiEnum<string, ExtractionEstimateCostParamsQueryType>? QueryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionEstimateCostParamsQueryType>
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
    public ApiEnum<string, ExtractionEstimateCostParamsDedupeMode>? DedupeMode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionEstimateCostParamsDedupeMode>
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
    public ApiEnum<string, ExtractionEstimateCostParamsCollectionStrategy>? CollectionStrategy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionEstimateCostParamsCollectionStrategy>
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
    public ApiEnum<string, ExtractionEstimateCostParamsScope>? Scope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionEstimateCostParamsScope>
            >("scope");
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
    public ApiEnum<string, ExtractionEstimateCostParamsSort>? Sort
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ExtractionEstimateCostParamsSort>
            >("sort");
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

    public ExtractionEstimateCostParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionEstimateCostParams(ExtractionEstimateCostParams extractionEstimateCostParams)
        : base(extractionEstimateCostParams)
    {
        this._rawBodyData = new(extractionEstimateCostParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExtractionEstimateCostParams(
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
    ExtractionEstimateCostParams(
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
    public static ExtractionEstimateCostParams FromRawUnchecked(
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

    public virtual bool Equals(ExtractionEstimateCostParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/extractions/estimate"
        )
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
[JsonConverter(typeof(ExtractionEstimateCostParamsToolTypeConverter))]
public enum ExtractionEstimateCostParamsToolType
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

sealed class ExtractionEstimateCostParamsToolTypeConverter
    : JsonConverter<ExtractionEstimateCostParamsToolType>
{
    public override ExtractionEstimateCostParamsToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ExtractionEstimateCostParamsToolType.ArticleExtractor,
            "community_extractor" => ExtractionEstimateCostParamsToolType.CommunityExtractor,
            "community_moderator_explorer" =>
                ExtractionEstimateCostParamsToolType.CommunityModeratorExplorer,
            "community_post_extractor" =>
                ExtractionEstimateCostParamsToolType.CommunityPostExtractor,
            "community_search" => ExtractionEstimateCostParamsToolType.CommunitySearch,
            "favoriters" => ExtractionEstimateCostParamsToolType.Favoriters,
            "follower_explorer" => ExtractionEstimateCostParamsToolType.FollowerExplorer,
            "following_explorer" => ExtractionEstimateCostParamsToolType.FollowingExplorer,
            "list_follower_explorer" => ExtractionEstimateCostParamsToolType.ListFollowerExplorer,
            "list_member_extractor" => ExtractionEstimateCostParamsToolType.ListMemberExtractor,
            "list_post_extractor" => ExtractionEstimateCostParamsToolType.ListPostExtractor,
            "mention_extractor" => ExtractionEstimateCostParamsToolType.MentionExtractor,
            "people_search" => ExtractionEstimateCostParamsToolType.PeopleSearch,
            "post_extractor" => ExtractionEstimateCostParamsToolType.PostExtractor,
            "quote_extractor" => ExtractionEstimateCostParamsToolType.QuoteExtractor,
            "reply_extractor" => ExtractionEstimateCostParamsToolType.ReplyExtractor,
            "repost_extractor" => ExtractionEstimateCostParamsToolType.RepostExtractor,
            "space_explorer" => ExtractionEstimateCostParamsToolType.SpaceExplorer,
            "thread_extractor" => ExtractionEstimateCostParamsToolType.ThreadExtractor,
            "tweet_search_extractor" => ExtractionEstimateCostParamsToolType.TweetSearchExtractor,
            "user_affiliates" => ExtractionEstimateCostParamsToolType.UserAffiliates,
            "user_likes" => ExtractionEstimateCostParamsToolType.UserLikes,
            "user_media" => ExtractionEstimateCostParamsToolType.UserMedia,
            "verified_follower_explorer" =>
                ExtractionEstimateCostParamsToolType.VerifiedFollowerExplorer,
            _ => (ExtractionEstimateCostParamsToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsToolType.ArticleExtractor => "article_extractor",
                ExtractionEstimateCostParamsToolType.CommunityExtractor => "community_extractor",
                ExtractionEstimateCostParamsToolType.CommunityModeratorExplorer =>
                    "community_moderator_explorer",
                ExtractionEstimateCostParamsToolType.CommunityPostExtractor =>
                    "community_post_extractor",
                ExtractionEstimateCostParamsToolType.CommunitySearch => "community_search",
                ExtractionEstimateCostParamsToolType.Favoriters => "favoriters",
                ExtractionEstimateCostParamsToolType.FollowerExplorer => "follower_explorer",
                ExtractionEstimateCostParamsToolType.FollowingExplorer => "following_explorer",
                ExtractionEstimateCostParamsToolType.ListFollowerExplorer =>
                    "list_follower_explorer",
                ExtractionEstimateCostParamsToolType.ListMemberExtractor => "list_member_extractor",
                ExtractionEstimateCostParamsToolType.ListPostExtractor => "list_post_extractor",
                ExtractionEstimateCostParamsToolType.MentionExtractor => "mention_extractor",
                ExtractionEstimateCostParamsToolType.PeopleSearch => "people_search",
                ExtractionEstimateCostParamsToolType.PostExtractor => "post_extractor",
                ExtractionEstimateCostParamsToolType.QuoteExtractor => "quote_extractor",
                ExtractionEstimateCostParamsToolType.ReplyExtractor => "reply_extractor",
                ExtractionEstimateCostParamsToolType.RepostExtractor => "repost_extractor",
                ExtractionEstimateCostParamsToolType.SpaceExplorer => "space_explorer",
                ExtractionEstimateCostParamsToolType.ThreadExtractor => "thread_extractor",
                ExtractionEstimateCostParamsToolType.TweetSearchExtractor =>
                    "tweet_search_extractor",
                ExtractionEstimateCostParamsToolType.UserAffiliates => "user_affiliates",
                ExtractionEstimateCostParamsToolType.UserLikes => "user_likes",
                ExtractionEstimateCostParamsToolType.UserMedia => "user_media",
                ExtractionEstimateCostParamsToolType.VerifiedFollowerExplorer =>
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
/// Media type used for estimate filtering (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    Images,
    Videos,
    Gifs,
    Media,
    Links,
    None,
}

sealed class MediaTypeConverter : JsonConverter<MediaType>
{
    public override MediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "images" => MediaType.Images,
            "videos" => MediaType.Videos,
            "gifs" => MediaType.Gifs,
            "media" => MediaType.Media,
            "links" => MediaType.Links,
            "none" => MediaType.None,
            _ => (MediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaType.Images => "images",
                MediaType.Videos => "videos",
                MediaType.Gifs => "gifs",
                MediaType.Media => "media",
                MediaType.Links => "links",
                MediaType.None => "none",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Quote mode used for estimation (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(QuotesConverter))]
public enum Quotes
{
    Include,
    Exclude,
    Only,
}

sealed class QuotesConverter : JsonConverter<Quotes>
{
    public override Quotes Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => Quotes.Include,
            "exclude" => Quotes.Exclude,
            "only" => Quotes.Only,
            _ => (Quotes)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Quotes value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Quotes.Include => "include",
                Quotes.Exclude => "exclude",
                Quotes.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reply mode used for estimation (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(RepliesConverter))]
public enum Replies
{
    Include,
    Exclude,
    Only,
}

sealed class RepliesConverter : JsonConverter<Replies>
{
    public override Replies Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => Replies.Include,
            "exclude" => Replies.Exclude,
            "only" => Replies.Only,
            _ => (Replies)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Replies value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Replies.Include => "include",
                Replies.Exclude => "exclude",
                Replies.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Retweet mode used for estimation (tweet_search_extractor)
/// </summary>
[JsonConverter(typeof(RetweetsConverter))]
public enum Retweets
{
    Include,
    Exclude,
    Only,
}

sealed class RetweetsConverter : JsonConverter<Retweets>
{
    public override Retweets Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "include" => Retweets.Include,
            "exclude" => Retweets.Exclude,
            "only" => Retweets.Only,
            _ => (Retweets)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Retweets value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Retweets.Include => "include",
                Retweets.Exclude => "exclude",
                Retweets.Only => "only",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionEstimateCostParamsQueryTypeConverter))]
public enum ExtractionEstimateCostParamsQueryType
{
    Latest,
    Top,
    Both,
    Relevance,
}

sealed class ExtractionEstimateCostParamsQueryTypeConverter
    : JsonConverter<ExtractionEstimateCostParamsQueryType>
{
    public override ExtractionEstimateCostParamsQueryType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => ExtractionEstimateCostParamsQueryType.Latest,
            "Top" => ExtractionEstimateCostParamsQueryType.Top,
            "Both" => ExtractionEstimateCostParamsQueryType.Both,
            "relevance" => ExtractionEstimateCostParamsQueryType.Relevance,
            _ => (ExtractionEstimateCostParamsQueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsQueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsQueryType.Latest => "Latest",
                ExtractionEstimateCostParamsQueryType.Top => "Top",
                ExtractionEstimateCostParamsQueryType.Both => "Both",
                ExtractionEstimateCostParamsQueryType.Relevance => "relevance",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionEstimateCostParamsDedupeModeConverter))]
public enum ExtractionEstimateCostParamsDedupeMode
{
    None,
    First,
    Merge,
}

sealed class ExtractionEstimateCostParamsDedupeModeConverter
    : JsonConverter<ExtractionEstimateCostParamsDedupeMode>
{
    public override ExtractionEstimateCostParamsDedupeMode Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => ExtractionEstimateCostParamsDedupeMode.None,
            "first" => ExtractionEstimateCostParamsDedupeMode.First,
            "merge" => ExtractionEstimateCostParamsDedupeMode.Merge,
            _ => (ExtractionEstimateCostParamsDedupeMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsDedupeMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsDedupeMode.None => "none",
                ExtractionEstimateCostParamsDedupeMode.First => "first",
                ExtractionEstimateCostParamsDedupeMode.Merge => "merge",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionEstimateCostParamsCollectionStrategyConverter))]
public enum ExtractionEstimateCostParamsCollectionStrategy
{
    Auto,
    Complete,
    Direct,
    Search,
    Thread,
}

sealed class ExtractionEstimateCostParamsCollectionStrategyConverter
    : JsonConverter<ExtractionEstimateCostParamsCollectionStrategy>
{
    public override ExtractionEstimateCostParamsCollectionStrategy Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ExtractionEstimateCostParamsCollectionStrategy.Auto,
            "complete" => ExtractionEstimateCostParamsCollectionStrategy.Complete,
            "direct" => ExtractionEstimateCostParamsCollectionStrategy.Direct,
            "search" => ExtractionEstimateCostParamsCollectionStrategy.Search,
            "thread" => ExtractionEstimateCostParamsCollectionStrategy.Thread,
            _ => (ExtractionEstimateCostParamsCollectionStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsCollectionStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsCollectionStrategy.Auto => "auto",
                ExtractionEstimateCostParamsCollectionStrategy.Complete => "complete",
                ExtractionEstimateCostParamsCollectionStrategy.Direct => "direct",
                ExtractionEstimateCostParamsCollectionStrategy.Search => "search",
                ExtractionEstimateCostParamsCollectionStrategy.Thread => "thread",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionEstimateCostParamsScopeConverter))]
public enum ExtractionEstimateCostParamsScope
{
    All,
    Direct,
    Nested,
}

sealed class ExtractionEstimateCostParamsScopeConverter
    : JsonConverter<ExtractionEstimateCostParamsScope>
{
    public override ExtractionEstimateCostParamsScope Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => ExtractionEstimateCostParamsScope.All,
            "direct" => ExtractionEstimateCostParamsScope.Direct,
            "nested" => ExtractionEstimateCostParamsScope.Nested,
            _ => (ExtractionEstimateCostParamsScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsScope.All => "all",
                ExtractionEstimateCostParamsScope.Direct => "direct",
                ExtractionEstimateCostParamsScope.Nested => "nested",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionEstimateCostParamsSortConverter))]
public enum ExtractionEstimateCostParamsSort
{
    Relevance,
    Latest,
    Oldest,
    Likes,
}

sealed class ExtractionEstimateCostParamsSortConverter
    : JsonConverter<ExtractionEstimateCostParamsSort>
{
    public override ExtractionEstimateCostParamsSort Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "relevance" => ExtractionEstimateCostParamsSort.Relevance,
            "latest" => ExtractionEstimateCostParamsSort.Latest,
            "oldest" => ExtractionEstimateCostParamsSort.Oldest,
            "likes" => ExtractionEstimateCostParamsSort.Likes,
            _ => (ExtractionEstimateCostParamsSort)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionEstimateCostParamsSort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionEstimateCostParamsSort.Relevance => "relevance",
                ExtractionEstimateCostParamsSort.Latest => "latest",
                ExtractionEstimateCostParamsSort.Oldest => "oldest",
                ExtractionEstimateCostParamsSort.Likes => "likes",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
