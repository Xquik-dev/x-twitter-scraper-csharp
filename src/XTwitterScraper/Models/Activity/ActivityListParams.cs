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

namespace XTwitterScraper.Models.Activity;

/// <summary>
/// Returns the account's activity log, newest first, with the Activity page's filters. It covers write actions, extractions, monitor changes and events, webhooks, giveaways, media, support, API keys, X account connections and billing. Pick a file format to get the same rows as a CSV, Excel, Markdown, PDF or text file.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class ActivityListParams : ParamsBase
{
    /// <summary>
    /// Answer format. JSON by default.
    /// </summary>
    public ApiEnum<string, ActivityListParamsFormat>? Format
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ActivityListParamsFormat>>(
                "format"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("format", value);
        }
    }

    /// <summary>
    /// Most rows to return, with no upper limit. A PDF above 10,000 rows comes as a ZIP of PDF parts.
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
    /// Activity group, like the Activity page's tabs. `all` by default, or `actions`, `extractions`, `monitors`, `webhooks` or `billing`.
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("category");
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
    /// Comma-separated statuses.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Search text.
    /// </summary>
    public string? Q
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("q");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("q", value);
        }
    }

    /// <summary>
    /// Oldest time, ISO 8601.
    /// </summary>
    public DateTimeOffset? Since
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("since");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("since", value);
        }
    }

    /// <summary>
    /// Newest time, ISO 8601.
    /// </summary>
    public DateTimeOffset? Until
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("until");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("until", value);
        }
    }

    public ActivityListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityListParams(ActivityListParams activityListParams)
        : base(activityListParams) { }
#pragma warning restore CS8618

    public ActivityListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActivityListParams FromRawUnchecked(
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

    public virtual bool Equals(ActivityListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/activity")
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

[JsonConverter(typeof(ActivityListParamsFormatConverter))]
public enum ActivityListParamsFormat
{
    Json,
    Csv,
    Xlsx,
    Md,
    MdDocument,
    Pdf,
    Txt,
}

sealed class ActivityListParamsFormatConverter : JsonConverter<ActivityListParamsFormat>
{
    public override ActivityListParamsFormat Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => ActivityListParamsFormat.Json,
            "csv" => ActivityListParamsFormat.Csv,
            "xlsx" => ActivityListParamsFormat.Xlsx,
            "md" => ActivityListParamsFormat.Md,
            "md-document" => ActivityListParamsFormat.MdDocument,
            "pdf" => ActivityListParamsFormat.Pdf,
            "txt" => ActivityListParamsFormat.Txt,
            _ => (ActivityListParamsFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityListParamsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityListParamsFormat.Json => "json",
                ActivityListParamsFormat.Csv => "csv",
                ActivityListParamsFormat.Xlsx => "xlsx",
                ActivityListParamsFormat.Md => "md",
                ActivityListParamsFormat.MdDocument => "md-document",
                ActivityListParamsFormat.Pdf => "pdf",
                ActivityListParamsFormat.Txt => "txt",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
