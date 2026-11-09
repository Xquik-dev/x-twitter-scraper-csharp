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

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// Get extraction results
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class ExtractionRetrieveParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Cursor for keyset pagination from prior response next_cursor
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
    /// Maximum number of results to return (1-1000, default 100)
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
    /// Wait up to this many seconds when the job is active.
    /// </summary>
    public long? Wait
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("wait");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("wait", value);
        }
    }

    /// <summary>
    /// Use compact for core fields and tweet counts, full for nested enrichment, or raw for a source copy.
    /// </summary>
    public ApiEnum<string, ExtractionRetrieveParamsOutputMode>? OutputMode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, ExtractionRetrieveParamsOutputMode>
            >("outputMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("outputMode", value);
        }
    }

    /// <summary>
    /// Keep enrichment nested or merge it into each result.
    /// </summary>
    public ApiEnum<string, ExtractionRetrieveParamsOutputPreset>? OutputPreset
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, ExtractionRetrieveParamsOutputPreset>
            >("outputPreset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("outputPreset", value);
        }
    }

    /// <summary>
    /// Preserve source keys or convert result field names.
    /// </summary>
    public ApiEnum<string, ExtractionRetrieveParamsFieldStyle>? FieldStyle
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, ExtractionRetrieveParamsFieldStyle>
            >("fieldStyle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fieldStyle", value);
        }
    }

    /// <summary>
    /// Use outputMode=raw instead.
    /// </summary>
    public bool? IncludeRaw
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeRaw");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeRaw", value);
        }
    }

    public ExtractionRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRetrieveParams(ExtractionRetrieveParams extractionRetrieveParams)
        : base(extractionRetrieveParams)
    {
        this.ID = extractionRetrieveParams.ID;
    }
#pragma warning restore CS8618

    public ExtractionRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExtractionRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(ExtractionRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/extractions/{0}", this.ID)
        )
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

[JsonConverter(typeof(ExtractionRetrieveParamsOutputModeConverter))]
public enum ExtractionRetrieveParamsOutputMode
{
    Compact,
    Full,
    Raw,
}

sealed class ExtractionRetrieveParamsOutputModeConverter
    : JsonConverter<ExtractionRetrieveParamsOutputMode>
{
    public override ExtractionRetrieveParamsOutputMode Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "compact" => ExtractionRetrieveParamsOutputMode.Compact,
            "full" => ExtractionRetrieveParamsOutputMode.Full,
            "raw" => ExtractionRetrieveParamsOutputMode.Raw,
            _ => (ExtractionRetrieveParamsOutputMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRetrieveParamsOutputMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRetrieveParamsOutputMode.Compact => "compact",
                ExtractionRetrieveParamsOutputMode.Full => "full",
                ExtractionRetrieveParamsOutputMode.Raw => "raw",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRetrieveParamsOutputPresetConverter))]
public enum ExtractionRetrieveParamsOutputPreset
{
    Nested,
    Flat,
}

sealed class ExtractionRetrieveParamsOutputPresetConverter
    : JsonConverter<ExtractionRetrieveParamsOutputPreset>
{
    public override ExtractionRetrieveParamsOutputPreset Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nested" => ExtractionRetrieveParamsOutputPreset.Nested,
            "flat" => ExtractionRetrieveParamsOutputPreset.Flat,
            _ => (ExtractionRetrieveParamsOutputPreset)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRetrieveParamsOutputPreset value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRetrieveParamsOutputPreset.Nested => "nested",
                ExtractionRetrieveParamsOutputPreset.Flat => "flat",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionRetrieveParamsFieldStyleConverter))]
public enum ExtractionRetrieveParamsFieldStyle
{
    Source,
    CamelCase,
    SnakeCase,
}

sealed class ExtractionRetrieveParamsFieldStyleConverter
    : JsonConverter<ExtractionRetrieveParamsFieldStyle>
{
    public override ExtractionRetrieveParamsFieldStyle Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "source" => ExtractionRetrieveParamsFieldStyle.Source,
            "camelCase" => ExtractionRetrieveParamsFieldStyle.CamelCase,
            "snake_case" => ExtractionRetrieveParamsFieldStyle.SnakeCase,
            _ => (ExtractionRetrieveParamsFieldStyle)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRetrieveParamsFieldStyle value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRetrieveParamsFieldStyle.Source => "source",
                ExtractionRetrieveParamsFieldStyle.CamelCase => "camelCase",
                ExtractionRetrieveParamsFieldStyle.SnakeCase => "snake_case",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
