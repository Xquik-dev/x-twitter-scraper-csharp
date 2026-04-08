using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// Extraction job tracking status, tool type, and result count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractionJob, ExtractionJobFromRaw>))]
public sealed record class ExtractionJob : JsonModel
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

    public required ApiEnum<string, ExtractionJobStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionJobStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionJobToolType> ToolType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionJobToolType>>(
                "toolType"
            );
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

    public ExtractionJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionJob(ExtractionJob extractionJob)
        : base(extractionJob) { }
#pragma warning restore CS8618

    public ExtractionJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionJobFromRaw.FromRawUnchecked"/>
    public static ExtractionJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionJobFromRaw : IFromRawJson<ExtractionJob>
{
    /// <inheritdoc/>
    public ExtractionJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractionJob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractionJobStatusConverter))]
public enum ExtractionJobStatus
{
    Running,
    Completed,
    Failed,
}

sealed class ExtractionJobStatusConverter : JsonConverter<ExtractionJobStatus>
{
    public override ExtractionJobStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => ExtractionJobStatus.Running,
            "completed" => ExtractionJobStatus.Completed,
            "failed" => ExtractionJobStatus.Failed,
            _ => (ExtractionJobStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionJobStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionJobStatus.Running => "running",
                ExtractionJobStatus.Completed => "completed",
                ExtractionJobStatus.Failed => "failed",
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
[JsonConverter(typeof(ExtractionJobToolTypeConverter))]
public enum ExtractionJobToolType
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

sealed class ExtractionJobToolTypeConverter : JsonConverter<ExtractionJobToolType>
{
    public override ExtractionJobToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ExtractionJobToolType.ArticleExtractor,
            "community_extractor" => ExtractionJobToolType.CommunityExtractor,
            "community_moderator_explorer" => ExtractionJobToolType.CommunityModeratorExplorer,
            "community_post_extractor" => ExtractionJobToolType.CommunityPostExtractor,
            "community_search" => ExtractionJobToolType.CommunitySearch,
            "follower_explorer" => ExtractionJobToolType.FollowerExplorer,
            "following_explorer" => ExtractionJobToolType.FollowingExplorer,
            "list_follower_explorer" => ExtractionJobToolType.ListFollowerExplorer,
            "list_member_extractor" => ExtractionJobToolType.ListMemberExtractor,
            "list_post_extractor" => ExtractionJobToolType.ListPostExtractor,
            "mention_extractor" => ExtractionJobToolType.MentionExtractor,
            "people_search" => ExtractionJobToolType.PeopleSearch,
            "post_extractor" => ExtractionJobToolType.PostExtractor,
            "quote_extractor" => ExtractionJobToolType.QuoteExtractor,
            "reply_extractor" => ExtractionJobToolType.ReplyExtractor,
            "repost_extractor" => ExtractionJobToolType.RepostExtractor,
            "space_explorer" => ExtractionJobToolType.SpaceExplorer,
            "thread_extractor" => ExtractionJobToolType.ThreadExtractor,
            "tweet_search_extractor" => ExtractionJobToolType.TweetSearchExtractor,
            "verified_follower_explorer" => ExtractionJobToolType.VerifiedFollowerExplorer,
            _ => (ExtractionJobToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionJobToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionJobToolType.ArticleExtractor => "article_extractor",
                ExtractionJobToolType.CommunityExtractor => "community_extractor",
                ExtractionJobToolType.CommunityModeratorExplorer => "community_moderator_explorer",
                ExtractionJobToolType.CommunityPostExtractor => "community_post_extractor",
                ExtractionJobToolType.CommunitySearch => "community_search",
                ExtractionJobToolType.FollowerExplorer => "follower_explorer",
                ExtractionJobToolType.FollowingExplorer => "following_explorer",
                ExtractionJobToolType.ListFollowerExplorer => "list_follower_explorer",
                ExtractionJobToolType.ListMemberExtractor => "list_member_extractor",
                ExtractionJobToolType.ListPostExtractor => "list_post_extractor",
                ExtractionJobToolType.MentionExtractor => "mention_extractor",
                ExtractionJobToolType.PeopleSearch => "people_search",
                ExtractionJobToolType.PostExtractor => "post_extractor",
                ExtractionJobToolType.QuoteExtractor => "quote_extractor",
                ExtractionJobToolType.ReplyExtractor => "reply_extractor",
                ExtractionJobToolType.RepostExtractor => "repost_extractor",
                ExtractionJobToolType.SpaceExplorer => "space_explorer",
                ExtractionJobToolType.ThreadExtractor => "thread_extractor",
                ExtractionJobToolType.TweetSearchExtractor => "tweet_search_extractor",
                ExtractionJobToolType.VerifiedFollowerExplorer => "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
