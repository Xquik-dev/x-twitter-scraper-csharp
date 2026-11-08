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

[JsonConverter(typeof(TweetAnalysisQuestionTypeConverter))]
public enum TweetAnalysisQuestionType
{
    Choice,
    Score,
    Probability,
}

sealed class TweetAnalysisQuestionTypeConverter : JsonConverter<TweetAnalysisQuestionType>
{
    public override TweetAnalysisQuestionType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "choice" => TweetAnalysisQuestionType.Choice,
            "score" => TweetAnalysisQuestionType.Score,
            "probability" => TweetAnalysisQuestionType.Probability,
            _ => (TweetAnalysisQuestionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisQuestionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisQuestionType.Choice => "choice",
                TweetAnalysisQuestionType.Score => "score",
                TweetAnalysisQuestionType.Probability => "probability",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisQuestionCriteria, TweetAnalysisQuestionCriteriaFromRaw>)
)]
public sealed record class TweetAnalysisQuestionCriteria : JsonModel
{
    public required string Yes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("yes");
        }
        init { this._rawData.Set("yes", value); }
    }

    public required string No
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("no");
        }
        init { this._rawData.Set("no", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Yes;
        _ = this.No;
    }

    public TweetAnalysisQuestionCriteria() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisQuestionCriteria(
        TweetAnalysisQuestionCriteria tweetAnalysisQuestionCriteria
    )
        : base(tweetAnalysisQuestionCriteria) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisQuestionCriteria(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisQuestionCriteria(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisQuestionCriteriaFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisQuestionCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisQuestionCriteriaFromRaw : IFromRawJson<TweetAnalysisQuestionCriteria>
{
    /// <inheritdoc/>
    public TweetAnalysisQuestionCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisQuestionCriteria.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisQuestion, TweetAnalysisQuestionFromRaw>))]
public sealed record class TweetAnalysisQuestion : JsonModel
{
    /// <summary>
    /// Name of the answer, such as request. A name the response renames or drops gets a 400, such as created_at, favorite_count, muting or blocking.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, TweetAnalysisQuestionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetAnalysisQuestionType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Your version of the question, such as 1.
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// The question, as the AI reads it.
    /// </summary>
    public required string Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// For a choice. Each category name with its description, or null.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "categories"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "categories",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// For a score. Each level's description, lowest first.
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
    /// For a probability. What counts as yes &amp; as no.
    /// </summary>
    public TweetAnalysisQuestionCriteria? Criteria
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAnalysisQuestionCriteria>("criteria");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("criteria", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.Version;
        _ = this.Instructions;
        _ = this.Categories;
        _ = this.Levels;
        this.Criteria?.Validate();
    }

    public TweetAnalysisQuestion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisQuestion(TweetAnalysisQuestion tweetAnalysisQuestion)
        : base(tweetAnalysisQuestion) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisQuestion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisQuestion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisQuestionFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisQuestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisQuestionFromRaw : IFromRawJson<TweetAnalysisQuestion>
{
    /// <inheritdoc/>
    public TweetAnalysisQuestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisQuestion.FromRawUnchecked(rawData);
}
