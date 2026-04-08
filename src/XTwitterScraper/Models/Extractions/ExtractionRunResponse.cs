using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(typeof(JsonModelConverter<ExtractionRunResponse, ExtractionRunResponseFromRaw>))]
public sealed record class ExtractionRunResponse : JsonModel
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

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionRunResponseToolType> ToolType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionRunResponseToolType>>(
                "toolType"
            );
        }
        init { this._rawData.Set("toolType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("running")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.ToolType.Validate();
    }

    public ExtractionRunResponse()
    {
        this.Status = JsonSerializer.SerializeToElement("running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRunResponse(ExtractionRunResponse extractionRunResponse)
        : base(extractionRunResponse) { }
#pragma warning restore CS8618

    public ExtractionRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Status = JsonSerializer.SerializeToElement("running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionRunResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionRunResponseFromRaw : IFromRawJson<ExtractionRunResponse>
{
    /// <inheritdoc/>
    public ExtractionRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionRunResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifier for the extraction tool used to run a job.
/// </summary>
[JsonConverter(typeof(ExtractionRunResponseToolTypeConverter))]
public enum ExtractionRunResponseToolType
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

sealed class ExtractionRunResponseToolTypeConverter : JsonConverter<ExtractionRunResponseToolType>
{
    public override ExtractionRunResponseToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "article_extractor" => ExtractionRunResponseToolType.ArticleExtractor,
            "community_extractor" => ExtractionRunResponseToolType.CommunityExtractor,
            "community_moderator_explorer" =>
                ExtractionRunResponseToolType.CommunityModeratorExplorer,
            "community_post_extractor" => ExtractionRunResponseToolType.CommunityPostExtractor,
            "community_search" => ExtractionRunResponseToolType.CommunitySearch,
            "follower_explorer" => ExtractionRunResponseToolType.FollowerExplorer,
            "following_explorer" => ExtractionRunResponseToolType.FollowingExplorer,
            "list_follower_explorer" => ExtractionRunResponseToolType.ListFollowerExplorer,
            "list_member_extractor" => ExtractionRunResponseToolType.ListMemberExtractor,
            "list_post_extractor" => ExtractionRunResponseToolType.ListPostExtractor,
            "mention_extractor" => ExtractionRunResponseToolType.MentionExtractor,
            "people_search" => ExtractionRunResponseToolType.PeopleSearch,
            "post_extractor" => ExtractionRunResponseToolType.PostExtractor,
            "quote_extractor" => ExtractionRunResponseToolType.QuoteExtractor,
            "reply_extractor" => ExtractionRunResponseToolType.ReplyExtractor,
            "repost_extractor" => ExtractionRunResponseToolType.RepostExtractor,
            "space_explorer" => ExtractionRunResponseToolType.SpaceExplorer,
            "thread_extractor" => ExtractionRunResponseToolType.ThreadExtractor,
            "tweet_search_extractor" => ExtractionRunResponseToolType.TweetSearchExtractor,
            "verified_follower_explorer" => ExtractionRunResponseToolType.VerifiedFollowerExplorer,
            _ => (ExtractionRunResponseToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRunResponseToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRunResponseToolType.ArticleExtractor => "article_extractor",
                ExtractionRunResponseToolType.CommunityExtractor => "community_extractor",
                ExtractionRunResponseToolType.CommunityModeratorExplorer =>
                    "community_moderator_explorer",
                ExtractionRunResponseToolType.CommunityPostExtractor => "community_post_extractor",
                ExtractionRunResponseToolType.CommunitySearch => "community_search",
                ExtractionRunResponseToolType.FollowerExplorer => "follower_explorer",
                ExtractionRunResponseToolType.FollowingExplorer => "following_explorer",
                ExtractionRunResponseToolType.ListFollowerExplorer => "list_follower_explorer",
                ExtractionRunResponseToolType.ListMemberExtractor => "list_member_extractor",
                ExtractionRunResponseToolType.ListPostExtractor => "list_post_extractor",
                ExtractionRunResponseToolType.MentionExtractor => "mention_extractor",
                ExtractionRunResponseToolType.PeopleSearch => "people_search",
                ExtractionRunResponseToolType.PostExtractor => "post_extractor",
                ExtractionRunResponseToolType.QuoteExtractor => "quote_extractor",
                ExtractionRunResponseToolType.ReplyExtractor => "reply_extractor",
                ExtractionRunResponseToolType.RepostExtractor => "repost_extractor",
                ExtractionRunResponseToolType.SpaceExplorer => "space_explorer",
                ExtractionRunResponseToolType.ThreadExtractor => "thread_extractor",
                ExtractionRunResponseToolType.TweetSearchExtractor => "tweet_search_extractor",
                ExtractionRunResponseToolType.VerifiedFollowerExplorer =>
                    "verified_follower_explorer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
