// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Returns the tweets X ranks highest by 1 metric over the last day, week or month. Covers all of X unless you pick a country or a language. Pages hold up to 20 tweets, and the list ends at 100. Each tweet costs 1 credit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class TweetListTopParams : ParamsBase
{
    /// <summary>
    /// What to rank tweets by. Defaults to likes. Singular names work too, such as like.
    /// </summary>
    public ApiEnum<string, TweetListTopParamsMetric>? Metric
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TweetListTopParamsMetric>>(
                "metric"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("metric", value);
        }
    }

    /// <summary>
    /// How far back to look. Defaults to day. Also takes 24h, 7d, 30d, daily, weekly and monthly.
    /// </summary>
    public ApiEnum<string, TweetListTopParamsWindow>? Window
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TweetListTopParamsWindow>>(
                "window"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("window", value);
        }
    }

    /// <summary>
    /// Only tweets from 1 country, as a 2- or 3-letter ISO 3166 code, such as US or USA. Send country or language, not both.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("country", value);
        }
    }

    /// <summary>
    /// Only tweets in 1 language, as a 2-letter code, such as en. Send country or language, not both.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("language", value);
        }
    }

    /// <summary>
    /// Pagination cursor for collection results. Also read as next_cursor, next_token, pagination_token or continuation_token.
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
    /// Items per page (1-100, default 20). Source, filters or credits can return fewer. Follow next_cursor for more pages. Its aliases are limit, count, max_results, maxItems, max_items &amp; per_page.
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("pageSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("pageSize", value);
        }
    }

    /// <summary>
    /// Fields to keep in each row, comma-separated. Use dots for nested fields, such as author.username. A list keeps the field in each item. Case &amp; underscores do not matter. A row that lacks a field leaves it out. Cursors, counts &amp; diagnostics always stay. An unknown name answers 400 unknown_field with the valid names, before any read. The price stays the same. SDK row types then hold only the named fields. A longer URL fails at the edge before Xquik reads it. Pick only the fields you need with `fields` &amp; `omit`.
    /// </summary>
    public string? Fields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fields", value);
        }
    }

    /// <summary>
    /// Fields to drop from each row, comma-separated. It takes the same names as fields. With fields, it drops from the kept fields. A longer URL fails at the edge before Xquik reads it.
    /// </summary>
    public string? Omit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("omit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("omit", value);
        }
    }

    public TweetListTopParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetListTopParams(TweetListTopParams tweetListTopParams)
        : base(tweetListTopParams) { }
#pragma warning restore CS8618

    public TweetListTopParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetListTopParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TweetListTopParams FromRawUnchecked(
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

    public virtual bool Equals(TweetListTopParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/tweets/top")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
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

[JsonConverter(typeof(TweetListTopParamsMetricConverter))]
public enum TweetListTopParamsMetric
{
    Likes,
    Replies,
    Quotes,
    Bookmarks,
    Shares,
    Views,
}

sealed class TweetListTopParamsMetricConverter : JsonConverter<TweetListTopParamsMetric>
{
    public override TweetListTopParamsMetric Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "likes" => TweetListTopParamsMetric.Likes,
            "replies" => TweetListTopParamsMetric.Replies,
            "quotes" => TweetListTopParamsMetric.Quotes,
            "bookmarks" => TweetListTopParamsMetric.Bookmarks,
            "shares" => TweetListTopParamsMetric.Shares,
            "views" => TweetListTopParamsMetric.Views,
            _ => (TweetListTopParamsMetric)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetListTopParamsMetric value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetListTopParamsMetric.Likes => "likes",
                TweetListTopParamsMetric.Replies => "replies",
                TweetListTopParamsMetric.Quotes => "quotes",
                TweetListTopParamsMetric.Bookmarks => "bookmarks",
                TweetListTopParamsMetric.Shares => "shares",
                TweetListTopParamsMetric.Views => "views",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetListTopParamsWindowConverter))]
public enum TweetListTopParamsWindow
{
    Day,
    Week,
    Month,
}

sealed class TweetListTopParamsWindowConverter : JsonConverter<TweetListTopParamsWindow>
{
    public override TweetListTopParamsWindow Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => TweetListTopParamsWindow.Day,
            "week" => TweetListTopParamsWindow.Week,
            "month" => TweetListTopParamsWindow.Month,
            _ => (TweetListTopParamsWindow)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetListTopParamsWindow value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetListTopParamsWindow.Day => "day",
                TweetListTopParamsWindow.Week => "week",
                TweetListTopParamsWindow.Month => "month",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
