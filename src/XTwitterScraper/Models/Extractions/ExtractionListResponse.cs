using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(typeof(JsonModelConverter<ExtractionListResponse, ExtractionListResponseFromRaw>))]
public sealed record class ExtractionListResponse : JsonModel
{
    public required IReadOnlyList<Extraction> Extractions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Extraction>>("extractions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Extraction>>(
                "extractions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Extractions)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public ExtractionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionListResponse(ExtractionListResponse extractionListResponse)
        : base(extractionListResponse) { }
#pragma warning restore CS8618

    public ExtractionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionListResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionListResponseFromRaw : IFromRawJson<ExtractionListResponse>
{
    /// <inheritdoc/>
    public ExtractionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Extraction job tracking status, tool type, and result count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Extraction, ExtractionFromRaw>))]
public sealed record class Extraction : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required ApiEnum<string, ExtractionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionToolType> ToolType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionToolType>>("toolType");
        }
        init { this._rawData.Set("toolType", value); }
    }

    public required long TotalResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalResults");
        }
        init { this._rawData.Set("totalResults", value); }
    }

    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Status.Validate();
        this.ToolType.Validate();
        _ = this.TotalResults;
        _ = this.CompletedAt;
    }

    public Extraction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Extraction(Extraction extraction)
        : base(extraction) { }
#pragma warning restore CS8618

    public Extraction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Extraction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionFromRaw.FromRawUnchecked"/>
    public static Extraction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionFromRaw : IFromRawJson<Extraction>
{
    /// <inheritdoc/>
    public Extraction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Extraction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractionStatusConverter))]
public enum ExtractionStatus
{
    Running,
    Completed,
    Failed,
}

sealed class ExtractionStatusConverter : JsonConverter<ExtractionStatus>
{
    public override ExtractionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => ExtractionStatus.Running,
            "completed" => ExtractionStatus.Completed,
            "failed" => ExtractionStatus.Failed,
            _ => (ExtractionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionStatus.Running => "running",
                ExtractionStatus.Completed => "completed",
                ExtractionStatus.Failed => "failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Identifier for the extraction tool used to run a job.
/// </summary>
[JsonConverter(typeof(ExtractionToolTypeConverter))]
public enum ExtractionToolType
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

sealed class ExtractionToolTypeConverter : JsonConverter<ExtractionToolType>
{
    public override ExtractionToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ExtractionToolType.ArticleExtractor,
            "community_extractor" => ExtractionToolType.CommunityExtractor,
            "community_moderator_explorer" => ExtractionToolType.CommunityModeratorExplorer,
            "community_post_extractor" => ExtractionToolType.CommunityPostExtractor,
            "community_search" => ExtractionToolType.CommunitySearch,
            "follower_explorer" => ExtractionToolType.FollowerExplorer,
            "following_explorer" => ExtractionToolType.FollowingExplorer,
            "list_follower_explorer" => ExtractionToolType.ListFollowerExplorer,
            "list_member_extractor" => ExtractionToolType.ListMemberExtractor,
            "list_post_extractor" => ExtractionToolType.ListPostExtractor,
            "mention_extractor" => ExtractionToolType.MentionExtractor,
            "people_search" => ExtractionToolType.PeopleSearch,
            "post_extractor" => ExtractionToolType.PostExtractor,
            "quote_extractor" => ExtractionToolType.QuoteExtractor,
            "reply_extractor" => ExtractionToolType.ReplyExtractor,
            "repost_extractor" => ExtractionToolType.RepostExtractor,
            "space_explorer" => ExtractionToolType.SpaceExplorer,
            "thread_extractor" => ExtractionToolType.ThreadExtractor,
            "tweet_search_extractor" => ExtractionToolType.TweetSearchExtractor,
            "verified_follower_explorer" => ExtractionToolType.VerifiedFollowerExplorer,
            _ => (ExtractionToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionToolType.ArticleExtractor => "article_extractor",
                ExtractionToolType.CommunityExtractor => "community_extractor",
                ExtractionToolType.CommunityModeratorExplorer => "community_moderator_explorer",
                ExtractionToolType.CommunityPostExtractor => "community_post_extractor",
                ExtractionToolType.CommunitySearch => "community_search",
                ExtractionToolType.FollowerExplorer => "follower_explorer",
                ExtractionToolType.FollowingExplorer => "following_explorer",
                ExtractionToolType.ListFollowerExplorer => "list_follower_explorer",
                ExtractionToolType.ListMemberExtractor => "list_member_extractor",
                ExtractionToolType.ListPostExtractor => "list_post_extractor",
                ExtractionToolType.MentionExtractor => "mention_extractor",
                ExtractionToolType.PeopleSearch => "people_search",
                ExtractionToolType.PostExtractor => "post_extractor",
                ExtractionToolType.QuoteExtractor => "quote_extractor",
                ExtractionToolType.ReplyExtractor => "reply_extractor",
                ExtractionToolType.RepostExtractor => "repost_extractor",
                ExtractionToolType.SpaceExplorer => "space_explorer",
                ExtractionToolType.ThreadExtractor => "thread_extractor",
                ExtractionToolType.TweetSearchExtractor => "tweet_search_extractor",
                ExtractionToolType.VerifiedFollowerExplorer => "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
