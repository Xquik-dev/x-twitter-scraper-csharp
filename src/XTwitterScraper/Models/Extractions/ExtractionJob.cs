// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

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

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
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

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completedAt");
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

    /// <summary>
    /// What the image filter asked &amp; how many posts it kept. Present when you send
    /// imageShows.
    /// </summary>
    public ImageFilterSummary? ImageFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageFilterSummary>("imageFilter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageFilter", value);
        }
    }

    /// <summary>
    /// What the topic filter asked &amp; how many posts it kept. Present when you send topic.
    /// </summary>
    public TopicFilterSummary? TopicFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TopicFilterSummary>("topicFilter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topicFilter", value);
        }
    }

    /// <summary>
    /// Dashboard page where a signed-in user follows this job &amp; downloads its rows as CSV, XLSX, JSON, Markdown, PDF or text.
    /// </summary>
    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <summary>
    /// Requested result limit.
    /// </summary>
    public long? ResultsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("resultsLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resultsLimit", value);
        }
    }

    /// <summary>
    /// Result limit after affordability checks.
    /// </summary>
    public long? EffectiveResultsLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("effectiveResultsLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effectiveResultsLimit", value);
        }
    }

    /// <summary>
    /// Why a terminal job stopped. `requested_limit_reached` means the job returned the number of results you asked for. `source_exhausted` means the read reached its end before your limit. A search can reach its end with only part of its matches. Wide date windows return fewer posts than narrow ones over the same dates. For a fuller collection, run the same search in shorter windows. `pagination_safety_limit` means a paging safety rule ended the read early. The job keeps every result it found. `deadline_reached` means the job ran out of time. `partial_failure` means some reads failed, and the job keeps the results from the rest. `budget_limited` means your credits covered fewer results than the job found. `canceled` and `failed` match the job status.
    /// </summary>
    public ApiEnum<string, ExtractionJobCompletionReason>? CompletionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractionJobCompletionReason>>(
                "completionReason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completionReason", value);
        }
    }

    /// <summary>
    /// Safe error code for a failed job.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
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
        this.ImageFilter?.Validate();
        this.TopicFilter?.Validate();
        _ = this.UrlValue;
        _ = this.ResultsLimit;
        _ = this.EffectiveResultsLimit;
        this.CompletionReason?.Validate();
        _ = this.ErrorMessage;
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
    Completed,
    Running,
    Failed,
    Canceled,
}

sealed class ExtractionJobStatusConverter : JsonConverter<ExtractionJobStatus>
{
    public override ExtractionJobStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => ExtractionJobStatus.Completed,
            "running" => ExtractionJobStatus.Running,
            "failed" => ExtractionJobStatus.Failed,
            "canceled" => ExtractionJobStatus.Canceled,
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
                ExtractionJobStatus.Completed => "completed",
                ExtractionJobStatus.Running => "running",
                ExtractionJobStatus.Failed => "failed",
                ExtractionJobStatus.Canceled => "canceled",
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

sealed class ExtractionJobToolTypeConverter : JsonConverter<ExtractionJobToolType>
{
    public override ExtractionJobToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            "favoriters" => ExtractionJobToolType.Favoriters,
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
            "user_affiliates" => ExtractionJobToolType.UserAffiliates,
            "user_likes" => ExtractionJobToolType.UserLikes,
            "user_media" => ExtractionJobToolType.UserMedia,
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
                ExtractionJobToolType.Favoriters => "favoriters",
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
                ExtractionJobToolType.UserAffiliates => "user_affiliates",
                ExtractionJobToolType.UserLikes => "user_likes",
                ExtractionJobToolType.UserMedia => "user_media",
                ExtractionJobToolType.VerifiedFollowerExplorer => "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionJobCompletionReasonConverter))]
public enum ExtractionJobCompletionReason
{
    BudgetLimited,
    Canceled,
    DeadlineReached,
    Failed,
    PaginationSafetyLimit,
    PartialFailure,
    RequestedLimitReached,
    SourceExhausted,
}

sealed class ExtractionJobCompletionReasonConverter : JsonConverter<ExtractionJobCompletionReason>
{
    public override ExtractionJobCompletionReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "budget_limited" => ExtractionJobCompletionReason.BudgetLimited,
            "canceled" => ExtractionJobCompletionReason.Canceled,
            "deadline_reached" => ExtractionJobCompletionReason.DeadlineReached,
            "failed" => ExtractionJobCompletionReason.Failed,
            "pagination_safety_limit" => ExtractionJobCompletionReason.PaginationSafetyLimit,
            "partial_failure" => ExtractionJobCompletionReason.PartialFailure,
            "requested_limit_reached" => ExtractionJobCompletionReason.RequestedLimitReached,
            "source_exhausted" => ExtractionJobCompletionReason.SourceExhausted,
            _ => (ExtractionJobCompletionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionJobCompletionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionJobCompletionReason.BudgetLimited => "budget_limited",
                ExtractionJobCompletionReason.Canceled => "canceled",
                ExtractionJobCompletionReason.DeadlineReached => "deadline_reached",
                ExtractionJobCompletionReason.Failed => "failed",
                ExtractionJobCompletionReason.PaginationSafetyLimit => "pagination_safety_limit",
                ExtractionJobCompletionReason.PartialFailure => "partial_failure",
                ExtractionJobCompletionReason.RequestedLimitReached => "requested_limit_reached",
                ExtractionJobCompletionReason.SourceExhausted => "source_exhausted",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
