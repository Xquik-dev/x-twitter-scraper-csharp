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
/// Answers each post's format, such as reporting, commentary or speculation, its source attribution &amp; its relevance to your topic. Name the topic in analysis.targets. Each analyzed post costs 2 credits.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class AnalysisNewsParams : ParamsBase
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
    public ApiEnum<string, AnalysisNewsParamsQueryType>? QueryType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AnalysisNewsParamsQueryType>>(
                "queryType"
            );
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
    public IReadOnlyList<AnalysisNewsParamsBaseline>? Baseline
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AnalysisNewsParamsBaseline>>(
                "baseline"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AnalysisNewsParamsBaseline>?>(
                "baseline",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AnalysisNewsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParams(AnalysisNewsParams analysisNewsParams)
        : base(analysisNewsParams)
    {
        this._rawBodyData = new(analysisNewsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AnalysisNewsParams(
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
    AnalysisNewsParams(
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
    public static AnalysisNewsParams FromRawUnchecked(
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

    public virtual bool Equals(AnalysisNewsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/analysis/news")
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

[JsonConverter(typeof(AnalysisNewsParamsQueryTypeConverter))]
public enum AnalysisNewsParamsQueryType
{
    Latest,
    Top,
}

sealed class AnalysisNewsParamsQueryTypeConverter : JsonConverter<AnalysisNewsParamsQueryType>
{
    public override AnalysisNewsParamsQueryType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latest" => AnalysisNewsParamsQueryType.Latest,
            "Top" => AnalysisNewsParamsQueryType.Top,
            _ => (AnalysisNewsParamsQueryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalysisNewsParamsQueryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalysisNewsParamsQueryType.Latest => "Latest",
                AnalysisNewsParamsQueryType.Top => "Top",
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
        AnalysisNewsParamsBaselineTweet,
        AnalysisNewsParamsBaselineTweetFromRaw
    >)
)]
public sealed record class AnalysisNewsParamsBaselineTweet : JsonModel
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

    public AnalysisNewsParamsBaselineTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParamsBaselineTweet(
        AnalysisNewsParamsBaselineTweet analysisNewsParamsBaselineTweet
    )
        : base(analysisNewsParamsBaselineTweet) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParamsBaselineTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisNewsParamsBaselineTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisNewsParamsBaselineTweetFromRaw.FromRawUnchecked"/>
    public static AnalysisNewsParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisNewsParamsBaselineTweetFromRaw : IFromRawJson<AnalysisNewsParamsBaselineTweet>
{
    /// <inheritdoc/>
    public AnalysisNewsParamsBaselineTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisNewsParamsBaselineTweet.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AnalysisNewsParamsBaselineMonitor,
        AnalysisNewsParamsBaselineMonitorFromRaw
    >)
)]
public sealed record class AnalysisNewsParamsBaselineMonitor : JsonModel
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

    public AnalysisNewsParamsBaselineMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParamsBaselineMonitor(
        AnalysisNewsParamsBaselineMonitor analysisNewsParamsBaselineMonitor
    )
        : base(analysisNewsParamsBaselineMonitor) { }
#pragma warning restore CS8618

    public AnalysisNewsParamsBaselineMonitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisNewsParamsBaselineMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisNewsParamsBaselineMonitorFromRaw.FromRawUnchecked"/>
    public static AnalysisNewsParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisNewsParamsBaselineMonitorFromRaw : IFromRawJson<AnalysisNewsParamsBaselineMonitor>
{
    /// <inheritdoc/>
    public AnalysisNewsParamsBaselineMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisNewsParamsBaselineMonitor.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AnalysisNewsParamsBaseline, AnalysisNewsParamsBaselineFromRaw>)
)]
public sealed record class AnalysisNewsParamsBaseline : JsonModel
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

    public AnalysisNewsParamsBaselineTweet? Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisNewsParamsBaselineTweet>("tweet");
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
    public AnalysisNewsParamsBaselineMonitor? Monitor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalysisNewsParamsBaselineMonitor>("monitor");
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

    public AnalysisNewsParamsBaseline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParamsBaseline(AnalysisNewsParamsBaseline analysisNewsParamsBaseline)
        : base(analysisNewsParamsBaseline) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalysisNewsParamsBaseline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalysisNewsParamsBaseline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalysisNewsParamsBaselineFromRaw.FromRawUnchecked"/>
    public static AnalysisNewsParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalysisNewsParamsBaselineFromRaw : IFromRawJson<AnalysisNewsParamsBaseline>
{
    /// <inheritdoc/>
    public AnalysisNewsParamsBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalysisNewsParamsBaseline.FromRawUnchecked(rawData);
}
