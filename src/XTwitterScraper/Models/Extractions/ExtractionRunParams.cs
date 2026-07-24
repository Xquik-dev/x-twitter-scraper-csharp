// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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
/// Run extraction
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
