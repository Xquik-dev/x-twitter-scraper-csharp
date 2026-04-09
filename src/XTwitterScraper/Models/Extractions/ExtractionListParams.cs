using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// List extraction jobs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExtractionListParams : ParamsBase
{
    /// <summary>
    /// Cursor for keyset pagination
    /// </summary>
    public string? After
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("after", value);
        }
    }

    /// <summary>
    /// Maximum number of items to return (1-100, default 50)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by job status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Filter by extraction tool type
    /// </summary>
    public ApiEnum<string, ToolType>? ToolType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ToolType>>("toolType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("toolType", value);
        }
    }

    public ExtractionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionListParams(ExtractionListParams extractionListParams)
        : base(extractionListParams) { }
#pragma warning restore CS8618

    public ExtractionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExtractionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExtractionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/extractions")
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Filter by job status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Running,
    Completed,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => Status.Running,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Running => "running",
                Status.Completed => "completed",
                Status.Failed => "failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by extraction tool type
/// </summary>
[JsonConverter(typeof(ToolTypeConverter))]
public enum ToolType
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

sealed class ToolTypeConverter : JsonConverter<ToolType>
{
    public override ToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ToolType.ArticleExtractor,
            "community_extractor" => ToolType.CommunityExtractor,
            "community_moderator_explorer" => ToolType.CommunityModeratorExplorer,
            "community_post_extractor" => ToolType.CommunityPostExtractor,
            "community_search" => ToolType.CommunitySearch,
            "follower_explorer" => ToolType.FollowerExplorer,
            "following_explorer" => ToolType.FollowingExplorer,
            "list_follower_explorer" => ToolType.ListFollowerExplorer,
            "list_member_extractor" => ToolType.ListMemberExtractor,
            "list_post_extractor" => ToolType.ListPostExtractor,
            "mention_extractor" => ToolType.MentionExtractor,
            "people_search" => ToolType.PeopleSearch,
            "post_extractor" => ToolType.PostExtractor,
            "quote_extractor" => ToolType.QuoteExtractor,
            "reply_extractor" => ToolType.ReplyExtractor,
            "repost_extractor" => ToolType.RepostExtractor,
            "space_explorer" => ToolType.SpaceExplorer,
            "thread_extractor" => ToolType.ThreadExtractor,
            "tweet_search_extractor" => ToolType.TweetSearchExtractor,
            "verified_follower_explorer" => ToolType.VerifiedFollowerExplorer,
            _ => (ToolType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, ToolType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolType.ArticleExtractor => "article_extractor",
                ToolType.CommunityExtractor => "community_extractor",
                ToolType.CommunityModeratorExplorer => "community_moderator_explorer",
                ToolType.CommunityPostExtractor => "community_post_extractor",
                ToolType.CommunitySearch => "community_search",
                ToolType.FollowerExplorer => "follower_explorer",
                ToolType.FollowingExplorer => "following_explorer",
                ToolType.ListFollowerExplorer => "list_follower_explorer",
                ToolType.ListMemberExtractor => "list_member_extractor",
                ToolType.ListPostExtractor => "list_post_extractor",
                ToolType.MentionExtractor => "mention_extractor",
                ToolType.PeopleSearch => "people_search",
                ToolType.PostExtractor => "post_extractor",
                ToolType.QuoteExtractor => "quote_extractor",
                ToolType.ReplyExtractor => "reply_extractor",
                ToolType.RepostExtractor => "repost_extractor",
                ToolType.SpaceExplorer => "space_explorer",
                ToolType.ThreadExtractor => "thread_extractor",
                ToolType.TweetSearchExtractor => "tweet_search_extractor",
                ToolType.VerifiedFollowerExplorer => "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
