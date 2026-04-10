using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Search tweets with X query operators &amp; pagination
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TweetSearchParams : ParamsBase
{
    /// <summary>
    /// Search query (keywords,
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("q");
        }
        init { this._rawQueryData.Set("q", value); }
    }

    /// <summary>
    /// Pagination cursor from previous response
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Max tweets to return (server paginates internally). Omit for single page (~20).
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
    /// Sort order — Latest (chronological) or Top (engagement-ranked)
    /// </summary>
    public ApiEnum<string, QueryType>? QueryType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, QueryType>>("queryType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("queryType", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp — only return tweets after this time
    /// </summary>
    public string? SinceTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sinceTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sinceTime", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp — only return tweets before this time
    /// </summary>
    public string? UntilTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("untilTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("untilTime", value);
        }
    }

    public TweetSearchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSearchParams(TweetSearchParams tweetSearchParams)
        : base(tweetSearchParams) { }
#pragma warning restore CS8618

    public TweetSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TweetSearchParams FromRawUnchecked(
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

    public virtual bool Equals(TweetSearchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/tweets/search")
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
/// Sort order — Latest (chronological) or Top (engagement-ranked)
/// </summary>
[JsonConverter(typeof(QueryTypeConverter))]
public enum QueryType
{
    Latest,
    Top,
}

sealed class QueryTypeConverter : JsonConverter<QueryType>
{
    public override QueryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => QueryType.Latest,
            "Top" => QueryType.Top,
            _ => (QueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        QueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                QueryType.Latest => "Latest",
                QueryType.Top => "Top",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
