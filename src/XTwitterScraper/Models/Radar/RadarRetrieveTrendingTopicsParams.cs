using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Radar;

/// <summary>
/// Get trending topics from curated sources
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RadarRetrieveTrendingTopicsParams : ParamsBase
{
    /// <summary>
    /// Cursor for pagination (from prior response nextCursor).
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
    /// Filter by category.
    /// </summary>
    public ApiEnum<string, Category>? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Category>>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
        }
    }

    /// <summary>
    /// Lookback window in hours (1-168, default 24).
    /// </summary>
    public long? Hours
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("hours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hours", value);
        }
    }

    /// <summary>
    /// Number of items to return (1-100, default 50).
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
    /// Region filter (us, global, etc.)
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    /// <summary>
    /// Source filter. One of: github, google_trends, hacker_news, polymarket, reddit,
    /// trustmrr, wikipedia
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("source", value);
        }
    }

    public RadarRetrieveTrendingTopicsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RadarRetrieveTrendingTopicsParams(
        RadarRetrieveTrendingTopicsParams radarRetrieveTrendingTopicsParams
    )
        : base(radarRetrieveTrendingTopicsParams) { }
#pragma warning restore CS8618

    public RadarRetrieveTrendingTopicsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RadarRetrieveTrendingTopicsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RadarRetrieveTrendingTopicsParams FromRawUnchecked(
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

    public virtual bool Equals(RadarRetrieveTrendingTopicsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/radar")
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
/// Filter by category.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
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

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "general" => Category.General,
            "tech" => Category.Tech,
            "dev" => Category.Dev,
            "science" => Category.Science,
            "culture" => Category.Culture,
            "politics" => Category.Politics,
            "business" => Category.Business,
            "entertainment" => Category.Entertainment,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.General => "general",
                Category.Tech => "tech",
                Category.Dev => "dev",
                Category.Science => "science",
                Category.Culture => "culture",
                Category.Politics => "politics",
                Category.Business => "business",
                Category.Entertainment => "entertainment",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Source filter. One of: github, google_trends, hacker_news, polymarket, reddit,
/// trustmrr, wikipedia
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    GitHub,
    GoogleTrends,
    HackerNews,
    Polymarket,
    Reddit,
    Trustmrr,
    Wikipedia,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github" => Source.GitHub,
            "google_trends" => Source.GoogleTrends,
            "hacker_news" => Source.HackerNews,
            "polymarket" => Source.Polymarket,
            "reddit" => Source.Reddit,
            "trustmrr" => Source.Trustmrr,
            "wikipedia" => Source.Wikipedia,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.GitHub => "github",
                Source.GoogleTrends => "google_trends",
                Source.HackerNews => "hacker_news",
                Source.Polymarket => "polymarket",
                Source.Reddit => "reddit",
                Source.Trustmrr => "trustmrr",
                Source.Wikipedia => "wikipedia",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
