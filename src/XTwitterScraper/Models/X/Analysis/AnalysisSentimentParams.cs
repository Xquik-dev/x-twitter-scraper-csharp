// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Analysis;

/// <summary>
/// Answers each post's attitude, its intensity &amp; its sarcasm probability. Sentiment analysis names each post's main emotion, such as joy or anger. Send post IDs, an X search, an account, a List, a post's replies or quotes, or your own texts. Each analyzed post costs 2 credits. A post without an analysis costs nothing.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class AnalysisSentimentParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Post IDs or post URLs to analyze, up to 100.
    /// </summary>
    public IReadOnlyList<string>? TweetIDs
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X search to analyze, with the operators of /x/tweets/search, such as from:nasa or lang:en. X searches up to 512 characters, counted with the other search fields, as /x/tweets/search counts q.
    /// </summary>
    public string? Query
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("query", value);
        }
    }

    /// <summary>
    /// Analyze 1 account's posts. Send a handle, with or without @, or a profile URL.
    /// </summary>
    public string? Username
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("username", value);
        }
    }

    /// <summary>
    /// Analyze a public List's posts. Send its ID or URL.
    /// </summary>
    public string? ListID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("listId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("listId", value);
        }
    }

    /// <summary>
    /// Analyze the quotes of 1 post. Send its ID or URL.
    /// </summary>
    public string? QuotesOf
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("quotesOf");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("quotesOf", value);
        }
    }

    /// <summary>
    /// Analyze the replies in 1 post's conversation. Send its ID or URL.
    /// </summary>
    public string? RepliesTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("repliesTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("repliesTo", value);
        }
    }

    /// <summary>
    /// Inclusive start of the search, such as 2026-09-25T00:00:00Z. Unix seconds also work. A time without an offset is UTC.
    /// </summary>
    public JsonElement? SinceTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("sinceTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sinceTime", value);
        }
    }

    /// <summary>
    /// Exclusive end of the search, such as 2026-09-26T00:00:00Z. Unix seconds also work. A time without an offset is UTC.
    /// </summary>
    public JsonElement? UntilTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("untilTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("untilTime", value);
        }
    }

    /// <summary>
    /// Search order. Default Latest.
    /// </summary>
    public ApiEnum<string, AnalysisSentimentParamsQueryType>? QueryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, AnalysisSentimentParamsQueryType>
            >("queryType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("queryType", value);
        }
    }

    /// <summary>
    /// Maximum posts to analyze from the search. A low credit balance can return fewer.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("limit", value);
        }
    }

    /// <summary>
    /// The next_cursor of the page before. Send the same search with it.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Your own texts to analyze, such as drafts. Reads nothing from X. Each text costs the same as 1 analyzed post.
    /// </summary>
    public IReadOnlyList<string>? Texts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("texts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "texts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Analysis settings, the same as the analysis input of Xquik's AI Actors, plus images. Leave it out for the route's own questions.
    /// </summary>
    public global::XTwitterScraper.Models.TweetAnalysisSettings? Analysis
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<global::XTwitterScraper.Models.TweetAnalysisSettings>(
                "analysis"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("analysis", value);
        }
    }

    /// <summary>
    /// Rows of an earlier answer to compare with, such as its results. Each needs the post's id, or tweet.id, &amp; its answers. Send monitor too, so other settings show as not_comparable. Each result's monitor says whether the post is new, changed or unchanged. The comparison costs nothing extra.
    /// </summary>
    public IReadOnlyList<AnalysisSentimentParamsBaseline>? Baseline
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<AnalysisSentimentParamsBaseline>
            >("baseline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AnalysisSentimentParamsBaseline>?>(
                "baseline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AnalysisSentimentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParams(AnalysisSentimentParams analysisSentimentParams)
        : base(analysisSentimentParams)
    {
        this._rawBodyData = new(analysisSentimentParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AnalysisSentimentParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisSentimentParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AnalysisSentimentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AnalysisSentimentParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/analysis/sentiment")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(AnalysisSentimentParamsQueryTypeConverter))]
public enum AnalysisSentimentParamsQueryType
{
    Latest,
    Top,
}

sealed class AnalysisSentimentParamsQueryTypeConverter
    : JsonConverter<AnalysisSentimentParamsQueryType>
{
    public override AnalysisSentimentParamsQueryType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => AnalysisSentimentParamsQueryType.Latest,
            "Top" => AnalysisSentimentParamsQueryType.Top,
            _ => (AnalysisSentimentParamsQueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalysisSentimentParamsQueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalysisSentimentParamsQueryType.Latest => "Latest",
                AnalysisSentimentParamsQueryType.Top => "Top",
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
        AnalysisSentimentParamsBaselineTweet,
        AnalysisSentimentParamsBaselineTweetFromRaw
    >)
)]
public sealed record class AnalysisSentimentParamsBaselineTweet : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public AnalysisSentimentParamsBaselineTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParamsBaselineTweet(
        AnalysisSentimentParamsBaselineTweet analysisSentimentParamsBaselineTweet
    )
        : base(analysisSentimentParamsBaselineTweet) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParamsBaselineTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisSentimentParamsBaselineTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisSentimentParamsBaselineTweetFromRaw.FromRawUnchecked"/>
    public static AnalysisSentimentParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisSentimentParamsBaselineTweetFromRaw
    : IFromRawJson<AnalysisSentimentParamsBaselineTweet>
{
    /// <inheritdoc/>
    public AnalysisSentimentParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisSentimentParamsBaselineTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AnalysisSentimentParamsBaselineMonitor,
        AnalysisSentimentParamsBaselineMonitorFromRaw
    >)
)]
public sealed record class AnalysisSentimentParamsBaselineMonitor : JsonModel
{
    public string? ConfigurationFingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("configurationFingerprint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configurationFingerprint", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConfigurationFingerprint;
    }

    public AnalysisSentimentParamsBaselineMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParamsBaselineMonitor(
        AnalysisSentimentParamsBaselineMonitor analysisSentimentParamsBaselineMonitor
    )
        : base(analysisSentimentParamsBaselineMonitor) { }
#pragma warning restore CS8618

    public AnalysisSentimentParamsBaselineMonitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisSentimentParamsBaselineMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisSentimentParamsBaselineMonitorFromRaw.FromRawUnchecked"/>
    public static AnalysisSentimentParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisSentimentParamsBaselineMonitorFromRaw
    : IFromRawJson<AnalysisSentimentParamsBaselineMonitor>
{
    /// <inheritdoc/>
    public AnalysisSentimentParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisSentimentParamsBaselineMonitor.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AnalysisSentimentParamsBaseline,
        AnalysisSentimentParamsBaselineFromRaw
    >)
)]
public sealed record class AnalysisSentimentParamsBaseline : JsonModel
{
    /// <summary>
    /// Post ID, or text:1 &amp; so on. Otherwise tweet.id counts.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public AnalysisSentimentParamsBaselineTweet? Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisSentimentParamsBaselineTweet>("tweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tweet", value);
        }
    }

    /// <summary>
    /// The earlier answers by question ID.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Answers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("answers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "answers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The earlier row's monitor, with its fingerprint.
    /// </summary>
    public AnalysisSentimentParamsBaselineMonitor? Monitor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisSentimentParamsBaselineMonitor>(
                "monitor"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monitor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Tweet?.Validate();
        _ = this.Answers;
        this.Monitor?.Validate();
    }

    public AnalysisSentimentParamsBaseline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParamsBaseline(
        AnalysisSentimentParamsBaseline analysisSentimentParamsBaseline
    )
        : base(analysisSentimentParamsBaseline) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisSentimentParamsBaseline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisSentimentParamsBaseline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisSentimentParamsBaselineFromRaw.FromRawUnchecked"/>
    public static AnalysisSentimentParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisSentimentParamsBaselineFromRaw : IFromRawJson<AnalysisSentimentParamsBaseline>
{
    /// <inheritdoc/>
    public AnalysisSentimentParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisSentimentParamsBaseline.FromRawUnchecked(rawData);
}
