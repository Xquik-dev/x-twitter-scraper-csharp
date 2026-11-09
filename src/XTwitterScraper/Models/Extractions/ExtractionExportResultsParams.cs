// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// Export extraction results
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class ExtractionExportResultsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Export file format
    /// </summary>
    public required ApiEnum<string, Format> Format
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, Format>>("format");
        }
        init { this._rawQueryData.Set("format", value); }
    }

    /// <summary>
    /// Minimum follower count.
    /// </summary>
    public long? MinFollowers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minFollowers", value);
        }
    }

    /// <summary>
    /// Maximum follower count.
    /// </summary>
    public long? MaxFollowers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxFollowers", value);
        }
    }

    /// <summary>
    /// Minimum following count.
    /// </summary>
    public long? MinFollowing
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minFollowing", value);
        }
    }

    /// <summary>
    /// Maximum following count.
    /// </summary>
    public long? MaxFollowing
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxFollowing", value);
        }
    }

    /// <summary>
    /// Minimum post count.
    /// </summary>
    public long? MinPosts
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minPosts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minPosts", value);
        }
    }

    /// <summary>
    /// Maximum post count.
    /// </summary>
    public long? MaxPosts
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxPosts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxPosts", value);
        }
    }

    /// <summary>
    /// Minimum like count.
    /// </summary>
    public long? MinLikes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minLikes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minLikes", value);
        }
    }

    /// <summary>
    /// Minimum reply count.
    /// </summary>
    public long? MinReplies
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minReplies", value);
        }
    }

    /// <summary>
    /// Minimum repost count.
    /// </summary>
    public long? MinRetweets
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minRetweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minRetweets", value);
        }
    }

    /// <summary>
    /// Minimum view count.
    /// </summary>
    public long? MinViews
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minViews");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minViews", value);
        }
    }

    /// <summary>
    /// Require a non-empty description.
    /// </summary>
    public bool? HasDescription
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasDescription", value);
        }
    }

    /// <summary>
    /// Require a non-empty location.
    /// </summary>
    public bool? HasLocation
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasLocation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasLocation", value);
        }
    }

    /// <summary>
    /// ID of another run of this tool. For an earlier whole run of the same account, the export holds only the rows that differ. For a run of another account, it holds only this run's rows that the other run also lists.
    /// </summary>
    public string? Compare
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("compare");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("compare", value);
        }
    }

    /// <summary>
    /// With compare, `added` keeps this run's new rows and `removed` keeps the earlier run's rows that this run lacks. The default is `added`. A run of another account ignores it.
    /// </summary>
    public ApiEnum<string, ExtractionExportResultsParamsChange>? Change
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, ExtractionExportResultsParamsChange>
            >("change");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("change", value);
        }
    }

    /// <summary>
    /// Require a website on the profile.
    /// </summary>
    public bool? HasWebsite
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasWebsite");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasWebsite", value);
        }
    }

    /// <summary>
    /// Keep accounts that joined X on this UTC day or later.
    /// </summary>
    public string? JoinedSince
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("joinedSince");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("joinedSince", value);
        }
    }

    /// <summary>
    /// Keep accounts that joined X before this UTC day.
    /// </summary>
    public string? JoinedUntil
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("joinedUntil");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("joinedUntil", value);
        }
    }

    /// <summary>
    /// Keep accounts whose location contains this text.
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("location", value);
        }
    }

    /// <summary>
    /// Drop accounts with under 1 post a month since joining that are at least 180 days old.
    /// </summary>
    public bool? HideInactive
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hideInactive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hideInactive", value);
        }
    }

    /// <summary>
    /// Drop accounts with at least 3 of these signs. No posts, a default picture, an empty bio, or following at least 100 accounts and 10 times their followers.
    /// </summary>
    public bool? HideFake
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hideFake");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hideFake", value);
        }
    }

    /// <summary>
    /// Require an email in the row's Email column.
    /// </summary>
    public bool? HasEmail
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasEmail", value);
        }
    }

    /// <summary>
    /// Require an email outside free webmail, such as Gmail, in the row's Email column.
    /// </summary>
    public bool? BusinessEmailOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("businessEmailOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("businessEmailOnly", value);
        }
    }

    /// <summary>
    /// Require the row's email at one of these domains. Separate domains with commas. Subdomains match.
    /// </summary>
    public string? EmailDomains
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("emailDomains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("emailDomains", value);
        }
    }

    /// <summary>
    /// Require media.
    /// </summary>
    public bool? HasMedia
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasMedia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasMedia", value);
        }
    }

    /// <summary>
    /// Filter by verified status.
    /// </summary>
    public bool? Verified
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("verified", value);
        }
    }

    /// <summary>
    /// Filter by language code.
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("lang");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("lang", value);
        }
    }

    /// <summary>
    /// Search exported result text.
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search", value);
        }
    }

    /// <summary>
    /// Include results on or after this date, from 00:00 UTC. An ISO 8601 time starts at that instant. The filter drops results without a post date. An empty value sets no filter.
    /// </summary>
    public string? SinceDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("sinceDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sinceDate", value);
        }
    }

    /// <summary>
    /// Include results on or before this date, inclusive, through 23:59:59 UTC. An ISO 8601 time ends at that instant. The filter drops results without a post date. An empty value sets no filter.
    /// </summary>
    public string? UntilDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("untilDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("untilDate", value);
        }
    }

    public ExtractionExportResultsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionExportResultsParams(
        ExtractionExportResultsParams extractionExportResultsParams
    )
        : base(extractionExportResultsParams)
    {
        this.ID = extractionExportResultsParams.ID;
    }
#pragma warning restore CS8618

    public ExtractionExportResultsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionExportResultsParams(
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
    public static ExtractionExportResultsParams FromRawUnchecked(
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

    public virtual bool Equals(ExtractionExportResultsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/extractions/{0}/export", this.ID)
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        request.Headers.Add("Accept", "application/octet-stream");
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
/// Export file format
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Csv,
    Json,
    Md,
    MdDocument,
    Pdf,
    Txt,
    Xlsx,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "csv" => Format.Csv,
            "json" => Format.Json,
            "md" => Format.Md,
            "md-document" => Format.MdDocument,
            "pdf" => Format.Pdf,
            "txt" => Format.Txt,
            "xlsx" => Format.Xlsx,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Csv => "csv",
                Format.Json => "json",
                Format.Md => "md",
                Format.MdDocument => "md-document",
                Format.Pdf => "pdf",
                Format.Txt => "txt",
                Format.Xlsx => "xlsx",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExtractionExportResultsParamsChangeConverter))]
public enum ExtractionExportResultsParamsChange
{
    Added,
    Removed,
}

sealed class ExtractionExportResultsParamsChangeConverter
    : JsonConverter<ExtractionExportResultsParamsChange>
{
    public override ExtractionExportResultsParamsChange Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "added" => ExtractionExportResultsParamsChange.Added,
            "removed" => ExtractionExportResultsParamsChange.Removed,
            _ => (ExtractionExportResultsParamsChange)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionExportResultsParamsChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionExportResultsParamsChange.Added => "added",
                ExtractionExportResultsParamsChange.Removed => "removed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
