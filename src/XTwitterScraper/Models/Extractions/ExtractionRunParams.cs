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
    /// Words to exclude from results (tweet_search_extractor)
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/extractions")
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

sealed class ExtractionRunParamsToolTypeConverter : JsonConverter<ExtractionRunParamsToolType>
{
    public override ExtractionRunParamsToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
