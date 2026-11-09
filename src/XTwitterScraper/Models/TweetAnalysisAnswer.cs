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

[JsonConverter(typeof(TweetAnalysisAnswerTypeConverter))]
public enum TweetAnalysisAnswerType
{
    Choice,
    Score,
    Probability,
}

sealed class TweetAnalysisAnswerTypeConverter : JsonConverter<TweetAnalysisAnswerType>
{
    public override TweetAnalysisAnswerType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "choice" => TweetAnalysisAnswerType.Choice,
            "score" => TweetAnalysisAnswerType.Score,
            "probability" => TweetAnalysisAnswerType.Probability,
            _ => (TweetAnalysisAnswerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisAnswerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisAnswerType.Choice => "choice",
                TweetAnalysisAnswerType.Score => "score",
                TweetAnalysisAnswerType.Probability => "probability",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisAnswer, TweetAnalysisAnswerFromRaw>))]
public sealed record class TweetAnalysisAnswer : JsonModel
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

    public required string QuestionVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("questionVersion");
        }
        init { this._rawData.Set("questionVersion", value); }
    }

    public required ApiEnum<string, TweetAnalysisAnswerType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetAnalysisAnswerType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The chosen category, or the level from 0, which can have decimals, such as 1.4 between levels 1 &amp; 2.
    /// </summary>
    public JsonElement? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Probability of each category, or of each level by index.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Probabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "probabilities"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "probabilities",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// For a score. The levels the question named, from 0.
    /// </summary>
    public IReadOnlyList<string>? Levels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("levels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "levels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// For a probability. The chance the answer is yes.
    /// </summary>
    public double? Probability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("probability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("probability", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.QuestionID;
        _ = this.QuestionVersion;
        this.Type.Validate();
        _ = this.Value;
        _ = this.Confidence;
        _ = this.Probabilities;
        _ = this.Levels;
        _ = this.Probability;
    }

    public TweetAnalysisAnswer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisAnswer(TweetAnalysisAnswer tweetAnalysisAnswer)
        : base(tweetAnalysisAnswer) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisAnswer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisAnswer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisAnswerFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisAnswer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisAnswerFromRaw : IFromRawJson<TweetAnalysisAnswer>
{
    /// <inheritdoc/>
    public TweetAnalysisAnswer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetAnalysisAnswer.FromRawUnchecked(rawData);
}
