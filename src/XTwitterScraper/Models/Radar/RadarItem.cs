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

namespace XTwitterScraper.Models.Radar;

/// <summary>
/// Trending topic with score, category, source, region, language, and source-specific metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RadarItem, RadarItemFromRaw>))]
public sealed record class RadarItem : JsonModel
{
    /// <summary>
    /// Radar item identifier.
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

    public required ApiEnum<string, RadarItemCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RadarItemCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
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

    /// <summary>
    /// BCP-47 language code. und means the source did not identify a language.
    /// </summary>
    public required string Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Source-specific fields. Shape varies per source: - reddit: { author, authorId?,
    /// subreddit, subredditId?,   subredditSubscribers?, sourceFormat, score?, upvoteRatio?,
    ///   estimatedUpvotes?, estimatedDownvotes?, numberComments?,   numberCrossposts?,
    /// selftext?, contentUrl?, domain?, postHint?,   linkFlairText?, distinguished?,
    /// totalAwardsReceived?, viewCount?,   editedAt?, galleryImageUrls?, redditVideo?,
    /// archived?, contestMode?,   isCrosspostable?, isMeta?, isNsfw?, isOriginalContent?,
    ///   isRobotIndexable?, isSelf?, isSpoiler?, isVideo?, locked?,   stickied?
    /// }. `score` is Reddit's public net score. Exact public   upvote and downvote
    /// counts are not available. Estimated counts   derive from the public score
    /// and upvote ratio, which Reddit may   fuzz. Comment bodies are not included.
    /// Current items combine   public listing discovery with server-rendered post
    /// data and use   `sourceFormat: html`; `json` and `rss` remain for legacy rows.
    /// - github: { starsToday: number } - hacker_news: { points: number, numberComments:
    /// number } - google_trends: { approxTraffic: number } - polymarket: { volume24hr:
    /// number } - wikipedia: { views: number } - trustmrr: { mrr, growthPercent,
    /// last30Days, total, customers, activeSubscriptions, onSale, xHandle?, category?,
    /// askingPrice?, country?, foundedDate?, googleSearchImpressionsLast30Days?,
    /// growthMrrPercent?, multiple?, paymentProvider?, profitMarginLast30Days?,
    /// rank?, revenuePerVisitor?, targetAudience?, visitorsLast30Days? } For the
    /// startup growth source, xHandle is the founder's X username without @. The
    /// rank field is the source's revenue rank. Result order represents reported
    /// 30-day revenue-growth rank.
    /// </summary>
    public required Metadata Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Metadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    public required System::DateTimeOffset PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("publishedAt");
        }
        init { this._rawData.Set("publishedAt", value); }
    }

    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    public required ApiEnum<string, RadarItemSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RadarItemSource>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Source-specific identifier used for deduplication.
    /// </summary>
    public required string SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceId");
        }
        init { this._rawData.Set("sourceId", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Source image. Startup growth items return the logo here.
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageUrl", value);
        }
    }

    public string? Url
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Category.Validate();
        _ = this.CreatedAt;
        _ = this.Language;
        this.Metadata.Validate();
        _ = this.PublishedAt;
        _ = this.Region;
        _ = this.Score;
        this.Source.Validate();
        _ = this.SourceID;
        _ = this.Title;
        _ = this.Description;
        _ = this.ImageUrl;
        _ = this.Url;
    }

    public RadarItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RadarItem(RadarItem radarItem)
        : base(radarItem) { }
#pragma warning restore CS8618

    public RadarItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RadarItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RadarItemFromRaw.FromRawUnchecked"/>
    public static RadarItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RadarItemFromRaw : IFromRawJson<RadarItem>
{
    /// <inheritdoc/>
    public RadarItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RadarItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RadarItemCategoryConverter))]
public enum RadarItemCategory
{
    General,
    Tech,
    Dev,
    Science,
    Culture,
    Politics,
    Business,
    Entertainment,
}

sealed class RadarItemCategoryConverter : JsonConverter<RadarItemCategory>
{
    public override RadarItemCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "general" => RadarItemCategory.General,
            "tech" => RadarItemCategory.Tech,
            "dev" => RadarItemCategory.Dev,
            "science" => RadarItemCategory.Science,
            "culture" => RadarItemCategory.Culture,
            "politics" => RadarItemCategory.Politics,
            "business" => RadarItemCategory.Business,
            "entertainment" => RadarItemCategory.Entertainment,
            _ => (RadarItemCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RadarItemCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RadarItemCategory.General => "general",
                RadarItemCategory.Tech => "tech",
                RadarItemCategory.Dev => "dev",
                RadarItemCategory.Science => "science",
                RadarItemCategory.Culture => "culture",
                RadarItemCategory.Politics => "politics",
                RadarItemCategory.Business => "business",
                RadarItemCategory.Entertainment => "entertainment",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Source-specific fields. Shape varies per source: - reddit: { author, authorId?,
/// subreddit, subredditId?,   subredditSubscribers?, sourceFormat, score?, upvoteRatio?,
///   estimatedUpvotes?, estimatedDownvotes?, numberComments?,   numberCrossposts?,
/// selftext?, contentUrl?, domain?, postHint?,   linkFlairText?, distinguished?,
/// totalAwardsReceived?, viewCount?,   editedAt?, galleryImageUrls?, redditVideo?,
/// archived?, contestMode?,   isCrosspostable?, isMeta?, isNsfw?, isOriginalContent?,
///   isRobotIndexable?, isSelf?, isSpoiler?, isVideo?, locked?,   stickied? }. `score`
/// is Reddit's public net score. Exact public   upvote and downvote counts are not
/// available. Estimated counts   derive from the public score and upvote ratio,
/// which Reddit may   fuzz. Comment bodies are not included. Current items combine
///   public listing discovery with server-rendered post data and use   `sourceFormat:
/// html`; `json` and `rss` remain for legacy rows. - github: { starsToday: number
/// } - hacker_news: { points: number, numberComments: number } - google_trends:
/// { approxTraffic: number } - polymarket: { volume24hr: number } - wikipedia: {
/// views: number } - trustmrr: { mrr, growthPercent, last30Days, total, customers,
/// activeSubscriptions, onSale, xHandle?, category?, askingPrice?, country?, foundedDate?,
/// googleSearchImpressionsLast30Days?, growthMrrPercent?, multiple?, paymentProvider?,
/// profitMarginLast30Days?, rank?, revenuePerVisitor?, targetAudience?, visitorsLast30Days?
/// } For the startup growth source, xHandle is the founder's X username without @.
/// The rank field is the source's revenue rank. Result order represents reported
/// 30-day revenue-growth rank.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public string? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author", value);
        }
    }

    public string? ContentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contentUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentUrl", value);
        }
    }

    public long? EstimatedDownvotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("estimatedDownvotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("estimatedDownvotes", value);
        }
    }

    public long? EstimatedUpvotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("estimatedUpvotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("estimatedUpvotes", value);
        }
    }

    public long? NumberComments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("numberComments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("numberComments", value);
        }
    }

    public long? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    public string? Selftext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("selftext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("selftext", value);
        }
    }

    /// <summary>
    /// Current items use html. json and rss are retained for legacy rows.
    /// </summary>
    public ApiEnum<string, SourceFormat>? SourceFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SourceFormat>>("sourceFormat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceFormat", value);
        }
    }

    public string? Subreddit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subreddit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subreddit", value);
        }
    }

    public double? UpvoteRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upvoteRatio");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upvoteRatio", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Author;
        _ = this.ContentUrl;
        _ = this.EstimatedDownvotes;
        _ = this.EstimatedUpvotes;
        _ = this.NumberComments;
        _ = this.Score;
        _ = this.Selftext;
        this.SourceFormat?.Validate();
        _ = this.Subreddit;
        _ = this.UpvoteRatio;
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata(Metadata metadata)
        : base(metadata) { }
#pragma warning restore CS8618

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Current items use html. json and rss are retained for legacy rows.
/// </summary>
[JsonConverter(typeof(SourceFormatConverter))]
public enum SourceFormat
{
    Html,
    Json,
    Rss,
}

sealed class SourceFormatConverter : JsonConverter<SourceFormat>
{
    public override SourceFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "html" => SourceFormat.Html,
            "json" => SourceFormat.Json,
            "rss" => SourceFormat.Rss,
            _ => (SourceFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceFormat.Html => "html",
                SourceFormat.Json => "json",
                SourceFormat.Rss => "rss",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RadarItemSourceConverter))]
public enum RadarItemSource
{
    GitHub,
    GoogleTrends,
    HackerNews,
    Polymarket,
    Reddit,
    Trustmrr,
    Wikipedia,
}

sealed class RadarItemSourceConverter : JsonConverter<RadarItemSource>
{
    public override RadarItemSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github" => RadarItemSource.GitHub,
            "google_trends" => RadarItemSource.GoogleTrends,
            "hacker_news" => RadarItemSource.HackerNews,
            "polymarket" => RadarItemSource.Polymarket,
            "reddit" => RadarItemSource.Reddit,
            "trustmrr" => RadarItemSource.Trustmrr,
            "wikipedia" => RadarItemSource.Wikipedia,
            _ => (RadarItemSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RadarItemSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RadarItemSource.GitHub => "github",
                RadarItemSource.GoogleTrends => "google_trends",
                RadarItemSource.HackerNews => "hacker_news",
                RadarItemSource.Polymarket => "polymarket",
                RadarItemSource.Reddit => "reddit",
                RadarItemSource.Trustmrr => "trustmrr",
                RadarItemSource.Wikipedia => "wikipedia",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
