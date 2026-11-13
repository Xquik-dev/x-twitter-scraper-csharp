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
/// Answers each post's stance on an asset, its content type, its conviction &amp; its relevance. The summary counts bullish &amp; bearish posts per cashtag. Name the asset in analysis.targets. Each analyzed post costs 2 credits.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class AnalysisMarketSignalsParams : ParamsBase
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
    public ApiEnum<string, AnalysisMarketSignalsParamsQueryType>? QueryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, AnalysisMarketSignalsParamsQueryType>
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
    /// Keep only posts about this topic, the same as the Actors' topic input. AI-powered analysis
    /// asks "Is this post about &lt;topic&gt;?" of each post &amp; keeps scores of 0.5 or more.
    /// Only kept posts are analyzed &amp; cost 2 credits each, &amp; a post the filter drops costs
    /// nothing. topicFilter states the cutoff &amp; counts. Send topic or imageShows, not both.
    /// </summary>
    public string? Topic
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("topic", value);
        }
    }

    /// <summary>
    /// Keep only posts whose photos show this, the same as the Actors' imageShows input. Send
    /// charts, screenshots, product_photos, memes or people, or describe it in words, such as a
    /// rocket. AI-powered analysis checks posts with photos X doesn't mark sensitive &amp; keeps
    /// scores of 0.5 or more. Only kept posts are analyzed &amp; cost 2 credits each. imageFilter
    /// states the cutoff &amp; counts. Send topic or imageShows, not both.
    /// </summary>
    public string? ImageShows
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("imageShows");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("imageShows", value);
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
    public IReadOnlyList<AnalysisMarketSignalsParamsBaseline>? Baseline
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<AnalysisMarketSignalsParamsBaseline>
            >("baseline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AnalysisMarketSignalsParamsBaseline>?>(
                "baseline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AnalysisMarketSignalsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParams(AnalysisMarketSignalsParams analysisMarketSignalsParams)
        : base(analysisMarketSignalsParams)
    {
        this._rawBodyData = new(analysisMarketSignalsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AnalysisMarketSignalsParams(
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
    AnalysisMarketSignalsParams(
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
    public static AnalysisMarketSignalsParams FromRawUnchecked(
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

    public virtual bool Equals(AnalysisMarketSignalsParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/x/analysis/market-signals"
        )
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

[JsonConverter(typeof(AnalysisMarketSignalsParamsQueryTypeConverter))]
public enum AnalysisMarketSignalsParamsQueryType
{
    Latest,
    Top,
}

sealed class AnalysisMarketSignalsParamsQueryTypeConverter
    : JsonConverter<AnalysisMarketSignalsParamsQueryType>
{
    public override AnalysisMarketSignalsParamsQueryType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => AnalysisMarketSignalsParamsQueryType.Latest,
            "Top" => AnalysisMarketSignalsParamsQueryType.Top,
            _ => (AnalysisMarketSignalsParamsQueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalysisMarketSignalsParamsQueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalysisMarketSignalsParamsQueryType.Latest => "Latest",
                AnalysisMarketSignalsParamsQueryType.Top => "Top",
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
        AnalysisMarketSignalsParamsBaselineTweet,
        AnalysisMarketSignalsParamsBaselineTweetFromRaw
    >)
)]
public sealed record class AnalysisMarketSignalsParamsBaselineTweet : JsonModel
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

    public AnalysisMarketSignalsParamsBaselineTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParamsBaselineTweet(
        AnalysisMarketSignalsParamsBaselineTweet analysisMarketSignalsParamsBaselineTweet
    )
        : base(analysisMarketSignalsParamsBaselineTweet) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParamsBaselineTweet(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisMarketSignalsParamsBaselineTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisMarketSignalsParamsBaselineTweetFromRaw.FromRawUnchecked"/>
    public static AnalysisMarketSignalsParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisMarketSignalsParamsBaselineTweetFromRaw
    : IFromRawJson<AnalysisMarketSignalsParamsBaselineTweet>
{
    /// <inheritdoc/>
    public AnalysisMarketSignalsParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisMarketSignalsParamsBaselineTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AnalysisMarketSignalsParamsBaselineMonitor,
        AnalysisMarketSignalsParamsBaselineMonitorFromRaw
    >)
)]
public sealed record class AnalysisMarketSignalsParamsBaselineMonitor : JsonModel
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

    public AnalysisMarketSignalsParamsBaselineMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParamsBaselineMonitor(
        AnalysisMarketSignalsParamsBaselineMonitor analysisMarketSignalsParamsBaselineMonitor
    )
        : base(analysisMarketSignalsParamsBaselineMonitor) { }
#pragma warning restore CS8618

    public AnalysisMarketSignalsParamsBaselineMonitor(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisMarketSignalsParamsBaselineMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisMarketSignalsParamsBaselineMonitorFromRaw.FromRawUnchecked"/>
    public static AnalysisMarketSignalsParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisMarketSignalsParamsBaselineMonitorFromRaw
    : IFromRawJson<AnalysisMarketSignalsParamsBaselineMonitor>
{
    /// <inheritdoc/>
    public AnalysisMarketSignalsParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisMarketSignalsParamsBaselineMonitor.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AnalysisMarketSignalsParamsBaseline,
        AnalysisMarketSignalsParamsBaselineFromRaw
    >)
)]
public sealed record class AnalysisMarketSignalsParamsBaseline : JsonModel
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

    public AnalysisMarketSignalsParamsBaselineTweet? Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisMarketSignalsParamsBaselineTweet>(
                "tweet"
            );
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
    public AnalysisMarketSignalsParamsBaselineMonitor? Monitor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisMarketSignalsParamsBaselineMonitor>(
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

    public AnalysisMarketSignalsParamsBaseline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParamsBaseline(
        AnalysisMarketSignalsParamsBaseline analysisMarketSignalsParamsBaseline
    )
        : base(analysisMarketSignalsParamsBaseline) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisMarketSignalsParamsBaseline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisMarketSignalsParamsBaseline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisMarketSignalsParamsBaselineFromRaw.FromRawUnchecked"/>
    public static AnalysisMarketSignalsParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisMarketSignalsParamsBaselineFromRaw : IFromRawJson<AnalysisMarketSignalsParamsBaseline>
{
    /// <inheritdoc/>
    public AnalysisMarketSignalsParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisMarketSignalsParamsBaseline.FromRawUnchecked(rawData);
}
