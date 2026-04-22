using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Radar;

/// <summary>
/// Trending topic with score, category, source, region, language, and source-specific metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RadarItem, RadarItemFromRaw>))]
public sealed record class RadarItem : JsonModel
{
    /// <summary>
    /// Internal numeric identifier (stringified bigint).
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

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
    /// Source-specific fields. Shape varies per source: - reddit: { subreddit: string,
    /// author: string } - github: { starsToday: number } - hacker_news: { points:
    /// number, numberComments: number } - google_trends: { approxTraffic: number
    /// } - polymarket: { volume24hr: number } - wikipedia: { views: number } - trustmrr:
    /// { mrr, growthPercent, last30Days, total, customers, activeSubscriptions, onSale,
    /// xHandle?, category?, askingPrice?, country?, growthMrrPercent?, multiple?,
    /// paymentProvider?, rank? }
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required DateTimeOffset PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("publishedAt");
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
        _ = this.Metadata;
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
        Type typeToConvert,
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
        Type typeToConvert,
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
