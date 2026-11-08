using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models;

/// <summary>
/// An empty page can still have has_next_page true after filtering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginatedTweets, PaginatedTweetsFromRaw>))]
public record class PaginatedTweets : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    public required IReadOnlyList<SearchTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SearchTweet>>("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SearchTweet>>(
                "tweets",
                ImmutableArray.ToImmutableArray(value)
            );
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
    /// Whole number from 0.
    /// </summary>
    public long? FilteredCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("filtered_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtered_count", value);
        }
    }

    /// <summary>
    /// The UTC time this filtered search has reached.
    /// </summary>
    public System::DateTimeOffset? ReadBackTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("readBackTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("readBackTo", value);
        }
    }

    /// <summary>
    /// Present on a last page whose sources all read past its start time.
    /// </summary>
    public bool? WindowComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("windowComplete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("windowComplete", value);
        }
    }

    /// <summary>
    /// The query that ran, when it differs from your q.
    /// </summary>
    public string? SearchedQuery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("searchedQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchedQuery", value);
        }
    }

    /// <summary>
    /// What X shows beside a search's posts, the same for everyone. Present on a search for a cashtag X has a card for, such as $BTC. Cashtag searches add X's ticker card in `searchContext`.
    /// </summary>
    public PaginatedTweetsSearchContext? SearchContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginatedTweetsSearchContext>("searchContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchContext", value);
        }
    }

    /// <summary>
    /// Each `ids` entry that names no post, with why. Absent when every entry names a post.
    /// </summary>
    public IReadOnlyList<PaginatedTweetsSkipped>? Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PaginatedTweetsSkipped>>(
                "skipped"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PaginatedTweetsSkipped>?>(
                "skipped",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        foreach (var item in this.Tweets)
        {
            item.Validate();
        }
        this.ImageFilter?.Validate();
        this.TopicFilter?.Validate();
        _ = this.FilteredCount;
        _ = this.ReadBackTo;
        _ = this.WindowComplete;
        _ = this.SearchedQuery;
        this.SearchContext?.Validate();
        foreach (var item in this.Skipped ?? [])
        {
            item.Validate();
        }
    }

    public PaginatedTweets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweets(PaginatedTweets paginatedTweets)
        : base(paginatedTweets) { }
#pragma warning restore CS8618

    public PaginatedTweets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweetsFromRaw.FromRawUnchecked"/>
    public static PaginatedTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweetsFromRaw : IFromRawJson<PaginatedTweets>
{
    /// <inheritdoc/>
    public PaginatedTweets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedTweets.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Diagnostic, DiagnosticFromRaw>))]
public sealed record class Diagnostic : JsonModel
{
    public required bool Complete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("complete");
        }
        init { this._rawData.Set("complete", value); }
    }

    public required double CoveragePercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("coveragePercentage");
        }
        init { this._rawData.Set("coveragePercentage", value); }
    }

    public required long CursorFailures
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cursorFailures");
        }
        init { this._rawData.Set("cursorFailures", value); }
    }

    public required long DuplicateCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duplicateCount");
        }
        init { this._rawData.Set("duplicateCount", value); }
    }

    public required long EmptyFalseProgressPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("emptyFalseProgressPages");
        }
        init { this._rawData.Set("emptyFalseProgressPages", value); }
    }

    public required long MalformedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("malformedCount");
        }
        init { this._rawData.Set("malformedCount", value); }
    }

    public required IReadOnlyList<string> MissingResponseModulesOrFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "missingResponseModulesOrFields"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "missingResponseModulesOrFields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long NestedReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("nestedReplyCount");
        }
        init { this._rawData.Set("nestedReplyCount", value); }
    }

    public required long PagesAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pagesAttempted");
        }
        init { this._rawData.Set("pagesAttempted", value); }
    }

    public required string RecommendedFallback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recommendedFallback");
        }
        init { this._rawData.Set("recommendedFallback", value); }
    }

    public required long RepeatedCursorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("repeatedCursorCount");
        }
        init { this._rawData.Set("repeatedCursorCount", value); }
    }

    public required long ReportedReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("reportedReplyCount");
        }
        init { this._rawData.Set("reportedReplyCount", value); }
    }

    public required bool ResponseTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("responseTruncated");
        }
        init { this._rawData.Set("responseTruncated", value); }
    }

    public required Richness Richness
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Richness>("richness");
        }
        init { this._rawData.Set("richness", value); }
    }

    public required IReadOnlyList<StrategiesAttempted> StrategiesAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StrategiesAttempted>>(
                "strategiesAttempted"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StrategiesAttempted>>(
                "strategiesAttempted",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long TargetDirectReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("targetDirectReplies");
        }
        init { this._rawData.Set("targetDirectReplies", value); }
    }

    public required long UniqueDirectReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("uniqueDirectReplies");
        }
        init { this._rawData.Set("uniqueDirectReplies", value); }
    }

    public required long UnrelatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("unrelatedCount");
        }
        init { this._rawData.Set("unrelatedCount", value); }
    }

    /// <summary>
    /// All child counts are known &amp; match collected replies.
    /// </summary>
    public bool? ReplyTreeComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("replyTreeComplete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyTreeComplete", value);
        }
    }

    /// <summary>
    /// Replies are accounted for through the requested scope &amp; depth. Source errors remain separate.
    /// </summary>
    public bool? ReplyScopeComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("replyScopeComplete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyScopeComplete", value);
        }
    }

    /// <summary>
    /// True when no more replies can be found. A retry returns the same rows.
    /// </summary>
    public bool? SourcesEnded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sourcesEnded");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourcesEnded", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Complete;
        _ = this.CoveragePercentage;
        _ = this.CursorFailures;
        _ = this.DuplicateCount;
        _ = this.EmptyFalseProgressPages;
        _ = this.MalformedCount;
        _ = this.MissingResponseModulesOrFields;
        _ = this.NestedReplyCount;
        _ = this.PagesAttempted;
        _ = this.RecommendedFallback;
        _ = this.RepeatedCursorCount;
        _ = this.ReportedReplyCount;
        _ = this.ResponseTruncated;
        this.Richness.Validate();
        foreach (var item in this.StrategiesAttempted)
        {
            item.Validate();
        }
        _ = this.TargetDirectReplies;
        _ = this.UniqueDirectReplies;
        _ = this.UnrelatedCount;
        _ = this.ReplyTreeComplete;
        _ = this.ReplyScopeComplete;
        _ = this.SourcesEnded;
    }

    public Diagnostic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Diagnostic(Diagnostic diagnostic)
        : base(diagnostic) { }
#pragma warning restore CS8618

    public Diagnostic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Diagnostic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiagnosticFromRaw.FromRawUnchecked"/>
    public static Diagnostic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiagnosticFromRaw : IFromRawJson<Diagnostic>
{
    /// <inheritdoc/>
    public Diagnostic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Diagnostic.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Richness, RichnessFromRaw>))]
public sealed record class Richness : JsonModel
{
    public required long Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("article");
        }
        init { this._rawData.Set("article", value); }
    }

    public required long Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("author");
        }
        init { this._rawData.Set("author", value); }
    }

    public required long Card
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("card");
        }
        init { this._rawData.Set("card", value); }
    }

    public required long CommunityNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("communityNote");
        }
        init { this._rawData.Set("communityNote", value); }
    }

    public required long CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required long EngagementCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("engagementCounts");
        }
        init { this._rawData.Set("engagementCounts", value); }
    }

    public required long Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("entities");
        }
        init { this._rawData.Set("entities", value); }
    }

    public required long Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    public required long Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("media");
        }
        init { this._rawData.Set("media", value); }
    }

    public required long QuotedOrRepostedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quotedOrRepostedTweet");
        }
        init { this._rawData.Set("quotedOrRepostedTweet", value); }
    }

    public required long Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public required long TotalReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalReplies");
        }
        init { this._rawData.Set("totalReplies", value); }
    }

    public required long Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Article;
        _ = this.Author;
        _ = this.Card;
        _ = this.CommunityNote;
        _ = this.CreatedAt;
        _ = this.EngagementCounts;
        _ = this.Entities;
        _ = this.Language;
        _ = this.Media;
        _ = this.QuotedOrRepostedTweet;
        _ = this.Text;
        _ = this.TotalReplies;
        _ = this.Url;
    }

    public Richness() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Richness(Richness richness)
        : base(richness) { }
#pragma warning restore CS8618

    public Richness(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Richness(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RichnessFromRaw.FromRawUnchecked"/>
    public static Richness FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RichnessFromRaw : IFromRawJson<Richness>
{
    /// <inheritdoc/>
    public Richness FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Richness.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StrategiesAttempted, StrategiesAttemptedFromRaw>))]
public sealed record class StrategiesAttempted : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required long NewDirectReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("newDirectReplies");
        }
        init { this._rawData.Set("newDirectReplies", value); }
    }

    public required long NewNestedReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("newNestedReplies");
        }
        init { this._rawData.Set("newNestedReplies", value); }
    }

    public required long PagesAttempted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pagesAttempted");
        }
        init { this._rawData.Set("pagesAttempted", value); }
    }

    public required ApiEnum<string, StopReason> StopReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, StopReason>>("stopReason");
        }
        init { this._rawData.Set("stopReason", value); }
    }

    /// <summary>
    /// The page, from 1, where each new direct reply appeared.
    /// </summary>
    public IReadOnlyList<long>? NewDirectReplyPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("newDirectReplyPages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "newDirectReplyPages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.NewDirectReplies;
        _ = this.NewNestedReplies;
        _ = this.PagesAttempted;
        this.StopReason.Validate();
        _ = this.NewDirectReplyPages;
    }

    public StrategiesAttempted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StrategiesAttempted(StrategiesAttempted strategiesAttempted)
        : base(strategiesAttempted) { }
#pragma warning restore CS8618

    public StrategiesAttempted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StrategiesAttempted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StrategiesAttemptedFromRaw.FromRawUnchecked"/>
    public static StrategiesAttempted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StrategiesAttemptedFromRaw : IFromRawJson<StrategiesAttempted>
{
    /// <inheritdoc/>
    public StrategiesAttempted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StrategiesAttempted.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StopReasonConverter))]
public enum StopReason
{
    Deadline,
    EmptyPages,
    Error,
    MissingCursor,
    NoNextPage,
    PageCap,
    RepeatedCursor,
}

sealed class StopReasonConverter : JsonConverter<StopReason>
{
    public override StopReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deadline" => StopReason.Deadline,
            "empty_pages" => StopReason.EmptyPages,
            "error" => StopReason.Error,
            "missing_cursor" => StopReason.MissingCursor,
            "no_next_page" => StopReason.NoNextPage,
            "page_cap" => StopReason.PageCap,
            "repeated_cursor" => StopReason.RepeatedCursor,
            _ => (StopReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StopReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StopReason.Deadline => "deadline",
                StopReason.EmptyPages => "empty_pages",
                StopReason.Error => "error",
                StopReason.MissingCursor => "missing_cursor",
                StopReason.NoNextPage => "no_next_page",
                StopReason.PageCap => "page_cap",
                StopReason.RepeatedCursor => "repeated_cursor",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PaginatedTweetsSearchContextSmartTag,
        PaginatedTweetsSearchContextSmartTagFromRaw
    >)
)]
public sealed record class PaginatedTweetsSearchContextSmartTag : JsonModel
{
    /// <summary>
    /// The ticker X matched.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Whether X lists the ticker as active.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// Whether X charts the ticker with open, high, low &amp; close prices.
    /// </summary>
    public bool? SupportsOhlc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supportsOhlc");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supportsOhlc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        _ = this.SupportsOhlc;
    }

    public PaginatedTweetsSearchContextSmartTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSearchContextSmartTag(
        PaginatedTweetsSearchContextSmartTag paginatedTweetsSearchContextSmartTag
    )
        : base(paginatedTweetsSearchContextSmartTag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSearchContextSmartTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweetsSearchContextSmartTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweetsSearchContextSmartTagFromRaw.FromRawUnchecked"/>
    public static PaginatedTweetsSearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweetsSearchContextSmartTagFromRaw
    : IFromRawJson<PaginatedTweetsSearchContextSmartTag>
{
    /// <inheritdoc/>
    public PaginatedTweetsSearchContextSmartTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedTweetsSearchContextSmartTag.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PaginatedTweetsSearchContext, PaginatedTweetsSearchContextFromRaw>)
)]
public sealed record class PaginatedTweetsSearchContext : JsonModel
{
    /// <summary>
    /// X's card for the cashtag the search names.
    /// </summary>
    public required PaginatedTweetsSearchContextSmartTag SmartTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginatedTweetsSearchContextSmartTag>("smartTag");
        }
        init { this._rawData.Set("smartTag", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SmartTag.Validate();
    }

    public PaginatedTweetsSearchContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSearchContext(PaginatedTweetsSearchContext paginatedTweetsSearchContext)
        : base(paginatedTweetsSearchContext) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSearchContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweetsSearchContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweetsSearchContextFromRaw.FromRawUnchecked"/>
    public static PaginatedTweetsSearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweetsSearchContextFromRaw : IFromRawJson<PaginatedTweetsSearchContext>
{
    /// <inheritdoc/>
    public PaginatedTweetsSearchContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedTweetsSearchContext.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PaginatedTweetsSkipped, PaginatedTweetsSkippedFromRaw>))]
public sealed record class PaginatedTweetsSkipped : JsonModel
{
    /// <summary>
    /// The entry as sent.
    /// </summary>
    public required string Entry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entry");
        }
        init { this._rawData.Set("entry", value); }
    }

    /// <summary>
    /// Why the entry names no post.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Entry;
        _ = this.Reason;
    }

    public PaginatedTweetsSkipped() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSkipped(PaginatedTweetsSkipped paginatedTweetsSkipped)
        : base(paginatedTweetsSkipped) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTweetsSkipped(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTweetsSkipped(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTweetsSkippedFromRaw.FromRawUnchecked"/>
    public static PaginatedTweetsSkipped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedTweetsSkippedFromRaw : IFromRawJson<PaginatedTweetsSkipped>
{
    /// <inheritdoc/>
    public PaginatedTweetsSkipped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedTweetsSkipped.FromRawUnchecked(rawData);
}
