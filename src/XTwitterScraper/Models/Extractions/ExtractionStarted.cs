// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// The job an extraction run starts. Poll its status URL or wait URL for rows.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractionStarted, ExtractionStartedFromRaw>))]
public sealed record class ExtractionStarted : JsonModel
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

    /// <summary>
    /// Dashboard page of the job, where a signed-in user follows its progress and
    /// downloads every row as a file.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public required long PollAfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pollAfterMs");
        }
        init { this._rawData.Set("pollAfterMs", value); }
    }

    public required ApiEnum<string, ExtractionJobStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionJobStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statusUrl");
        }
        init { this._rawData.Set("statusUrl", value); }
    }

    /// <summary>
    /// Identifier for the extraction tool used to run a job.
    /// </summary>
    public required ApiEnum<string, ExtractionJobToolType> ToolType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionJobToolType>>(
                "toolType"
            );
        }
        init { this._rawData.Set("toolType", value); }
    }

    public required string WaitUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("waitUrl");
        }
        init { this._rawData.Set("waitUrl", value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.UrlValue;
        _ = this.PollAfterMs;
        this.Status.Validate();
        _ = this.StatusUrl;
        this.ToolType.Validate();
        _ = this.WaitUrl;
    }

    public ExtractionStarted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionStarted(ExtractionStarted extractionStarted)
        : base(extractionStarted) { }
#pragma warning restore CS8618

    public ExtractionStarted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionStarted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    public static ExtractionStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionStartedFromRaw : IFromRawJson<ExtractionStarted>
{
    public ExtractionStarted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractionStarted.FromRawUnchecked(rawData);
}
