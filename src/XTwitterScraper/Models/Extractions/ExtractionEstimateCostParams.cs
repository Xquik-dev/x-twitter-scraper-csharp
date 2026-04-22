using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

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
    /// Words excluded from estimated search results
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/extractions/estimate")
        {
            Query = this.QueryString(options),
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
        ParamsBase.AddDefaultHeaders(request, options);
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
    VerifiedFollowerExplorer,
}

sealed class ExtractionEstimateCostParamsToolTypeConverter
    : JsonConverter<ExtractionEstimateCostParamsToolType>
{
    public override ExtractionEstimateCostParamsToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
