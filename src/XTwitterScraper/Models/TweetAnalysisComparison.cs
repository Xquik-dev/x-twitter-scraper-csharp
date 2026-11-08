// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(TweetAnalysisComparisonStatusConverter))]
public enum TweetAnalysisComparisonStatus
{
    FirstRun,
    NewToBaseline,
    Unchanged,
    Changed,
    NotComparable,
    AnalysisUnavailable,
}

sealed class TweetAnalysisComparisonStatusConverter : JsonConverter<TweetAnalysisComparisonStatus>
{
    public override TweetAnalysisComparisonStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "first_run" => TweetAnalysisComparisonStatus.FirstRun,
            "new_to_baseline" => TweetAnalysisComparisonStatus.NewToBaseline,
            "unchanged" => TweetAnalysisComparisonStatus.Unchanged,
            "changed" => TweetAnalysisComparisonStatus.Changed,
            "not_comparable" => TweetAnalysisComparisonStatus.NotComparable,
            "analysis_unavailable" => TweetAnalysisComparisonStatus.AnalysisUnavailable,
            _ => (TweetAnalysisComparisonStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisComparisonStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisComparisonStatus.FirstRun => "first_run",
                TweetAnalysisComparisonStatus.NewToBaseline => "new_to_baseline",
                TweetAnalysisComparisonStatus.Unchanged => "unchanged",
                TweetAnalysisComparisonStatus.Changed => "changed",
                TweetAnalysisComparisonStatus.NotComparable => "not_comparable",
                TweetAnalysisComparisonStatus.AnalysisUnavailable => "analysis_unavailable",
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
        TweetAnalysisComparisonChanges,
        TweetAnalysisComparisonChangesFromRaw
    >)
)]
public sealed record class TweetAnalysisComparisonChanges : JsonModel
{
    public required string QuestionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("questionId");
        }
        init { this._rawData.Set("questionId", value); }
    }

    public required string Previous
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("previous");
        }
        init { this._rawData.Set("previous", value); }
    }

    public required string Current
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("current");
        }
        init { this._rawData.Set("current", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.QuestionID;
        _ = this.Previous;
        _ = this.Current;
    }

    public TweetAnalysisComparisonChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisComparisonChanges(
        TweetAnalysisComparisonChanges tweetAnalysisComparisonChanges
    )
        : base(tweetAnalysisComparisonChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisComparisonChanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisComparisonChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisComparisonChangesFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisComparisonChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisComparisonChangesFromRaw : IFromRawJson<TweetAnalysisComparisonChanges>
{
    /// <inheritdoc/>
    public TweetAnalysisComparisonChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisComparisonChanges.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisComparison, TweetAnalysisComparisonFromRaw>))]
public sealed record class TweetAnalysisComparison : JsonModel
{
    /// <summary>
    /// Hash of the questions, targets &amp; context. Rows with another hash are not_comparable.
    /// </summary>
    public required string ConfigurationFingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("configurationFingerprint");
        }
        init { this._rawData.Set("configurationFingerprint", value); }
    }

    /// <summary>
    /// Always null. The baseline is the rows you sent.
    /// </summary>
    public required JsonElement? BaselineDatasetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("baselineDatasetId");
        }
        init { this._rawData.Set("baselineDatasetId", value); }
    }

    /// <summary>
    /// first_run without baseline. new_to_baseline for a post baseline lacks. changed when an answer clearly left its earlier decision. not_comparable when other settings made the earlier row or it answers none of these questions.
    /// </summary>
    public required ApiEnum<string, TweetAnalysisComparisonStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetAnalysisComparisonStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// IDs of the questions whose decision changed.
    /// </summary>
    public required IReadOnlyList<string> ChangedQuestionIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("changedQuestionIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "changedQuestionIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each changed decision, earlier &amp; now.
    /// </summary>
    public required IReadOnlyList<TweetAnalysisComparisonChanges> Changes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TweetAnalysisComparisonChanges>>(
                "changes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisComparisonChanges>>(
                "changes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConfigurationFingerprint;
        _ = this.BaselineDatasetID;
        this.Status.Validate();
        _ = this.ChangedQuestionIDs;
        foreach (var item in this.Changes)
        {
            item.Validate();
        }
    }

    public TweetAnalysisComparison() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisComparison(TweetAnalysisComparison tweetAnalysisComparison)
        : base(tweetAnalysisComparison) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisComparison(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisComparison(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisComparisonFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisComparison FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisComparisonFromRaw : IFromRawJson<TweetAnalysisComparison>
{
    /// <inheritdoc/>
    public TweetAnalysisComparison FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisComparison.FromRawUnchecked(rawData);
}
