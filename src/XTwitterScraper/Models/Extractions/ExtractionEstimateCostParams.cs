using System.Collections.Frozen;
using System.Collections.Generic;
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
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
