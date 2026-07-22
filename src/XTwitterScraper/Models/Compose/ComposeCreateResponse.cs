using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Compose;

[JsonConverter(typeof(ComposeCreateResponseConverter))]
public record class ComposeCreateResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? IntentUrl
    {
        get
        {
            return Match<string?>(
                prepareResult: (x) => x.IntentUrl,
                refineResult: (x) => x.IntentUrl,
                scoreResult: (x) => x.IntentUrl
            );
        }
    }

    public string NextStep
    {
        get
        {
            return Match(
                prepareResult: (x) => x.NextStep,
                refineResult: (x) => x.NextStep,
                scoreResult: (x) => x.NextStep
            );
        }
    }

    public ComposeCreateResponse(ComposePrepareResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComposeCreateResponse(ComposeRefineResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComposeCreateResponse(ComposeScoreResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComposeCreateResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposePrepareResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPrepareResult(out var value)) {
    ///     // `value` is of type `ComposePrepareResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPrepareResult([NotNullWhen(true)] out ComposePrepareResult? value)
    {
        value = this.Value as ComposePrepareResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposeRefineResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRefineResult(out var value)) {
    ///     // `value` is of type `ComposeRefineResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRefineResult([NotNullWhen(true)] out ComposeRefineResult? value)
    {
        value = this.Value as ComposeRefineResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposeScoreResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScoreResult(out var value)) {
    ///     // `value` is of type `ComposeScoreResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScoreResult([NotNullWhen(true)] out ComposeScoreResult? value)
    {
        value = this.Value as ComposeScoreResult;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (ComposePrepareResult value) =&gt; {...},
    ///     (ComposeRefineResult value) =&gt; {...},
    ///     (ComposeScoreResult value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ComposePrepareResult> prepareResult,
        System::Action<ComposeRefineResult> refineResult,
        System::Action<ComposeScoreResult> scoreResult
    )
    {
        switch (this.Value)
        {
            case ComposePrepareResult value:
                prepareResult(value);
                break;
            case ComposeRefineResult value:
                refineResult(value);
                break;
            case ComposeScoreResult value:
                scoreResult(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of ComposeCreateResponse"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (ComposePrepareResult value) =&gt; {...},
    ///     (ComposeRefineResult value) =&gt; {...},
    ///     (ComposeScoreResult value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ComposePrepareResult, T> prepareResult,
        System::Func<ComposeRefineResult, T> refineResult,
        System::Func<ComposeScoreResult, T> scoreResult
    )
    {
        return this.Value switch
        {
            ComposePrepareResult value => prepareResult(value),
            ComposeRefineResult value => refineResult(value),
            ComposeScoreResult value => scoreResult(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of ComposeCreateResponse"
            ),
        };
    }

    public static implicit operator ComposeCreateResponse(ComposePrepareResult value) => new(value);

    public static implicit operator ComposeCreateResponse(ComposeRefineResult value) => new(value);

    public static implicit operator ComposeCreateResponse(ComposeScoreResult value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of ComposeCreateResponse"
            );
        }
        this.Switch(
            (prepareResult) => prepareResult.Validate(),
            (refineResult) => refineResult.Validate(),
            (scoreResult) => scoreResult.Validate()
        );
    }

    public virtual bool Equals(ComposeCreateResponse? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            ComposePrepareResult _ => 0,
            ComposeRefineResult _ => 1,
            ComposeScoreResult _ => 2,
            _ => -1,
        };
    }
}

sealed class ComposeCreateResponseConverter : JsonConverter<ComposeCreateResponse>
{
    public override ComposeCreateResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ComposePrepareResult>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ComposeRefineResult>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ComposeScoreResult>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComposeCreateResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ComposePrepareResult, ComposePrepareResultFromRaw>))]
public sealed record class ComposePrepareResult : JsonModel
{
    /// <summary>
    /// Xquik editorial heuristics, ordered for the goal.
    /// </summary>
    public required IReadOnlyList<ContentRule> ContentRules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ContentRule>>("contentRules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ContentRule>>(
                "contentRules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Published engagement signal names. Production multipliers are not published.
    /// </summary>
    public required IReadOnlyList<EngagementMultiplier> EngagementMultipliers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EngagementMultiplier>>(
                "engagementMultipliers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EngagementMultiplier>>(
                "engagementMultipliers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Publication limit for timing and decay claims.
    /// </summary>
    public required string EngagementVelocity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("engagementVelocity");
        }
        init { this._rawData.Set("engagementVelocity", value); }
    }

    public required IReadOnlyList<string> FollowUpQuestions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("followUpQuestions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "followUpQuestions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X post intent seeded with the topic.
    /// </summary>
    public required string IntentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("intentUrl");
        }
        init { this._rawData.Set("intentUrl", value); }
    }

    public required string NextStep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("nextStep");
        }
        init { this._rawData.Set("nextStep", value); }
    }

    /// <summary>
    /// Published signal names with unpublished weights as null.
    /// </summary>
    public required IReadOnlyList<ScorerWeight> ScorerWeights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ScorerWeight>>("scorerWeights");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ScorerWeight>>(
                "scorerWeights",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Signal source and evidence limits.
    /// </summary>
    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Negative engagement predictions in the public model.
    /// </summary>
    public required IReadOnlyList<string> TopPenalties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("topPenalties");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "topPenalties",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Style analyses saved to the account.
    /// </summary>
    public IReadOnlyList<SavedStyle>? SavedStyles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SavedStyle>>("savedStyles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SavedStyle>?>(
                "savedStyles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Next action when no cached style is available.
    /// </summary>
    public string? StyleNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("styleNote");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("styleNote", value);
        }
    }

    /// <summary>
    /// Cached examples for the requested style username.
    /// </summary>
    public IReadOnlyList<string>? StyleTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("styleTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "styleTweets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ContentRules)
        {
            item.Validate();
        }
        foreach (var item in this.EngagementMultipliers)
        {
            item.Validate();
        }
        _ = this.EngagementVelocity;
        _ = this.FollowUpQuestions;
        _ = this.IntentUrl;
        _ = this.NextStep;
        foreach (var item in this.ScorerWeights)
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.TopPenalties;
        foreach (var item in this.SavedStyles ?? [])
        {
            item.Validate();
        }
        _ = this.StyleNote;
        _ = this.StyleTweets;
    }

    public ComposePrepareResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposePrepareResult(ComposePrepareResult composePrepareResult)
        : base(composePrepareResult) { }
#pragma warning restore CS8618

    public ComposePrepareResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposePrepareResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposePrepareResultFromRaw.FromRawUnchecked"/>
    public static ComposePrepareResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComposePrepareResultFromRaw : IFromRawJson<ComposePrepareResult>
{
    /// <inheritdoc/>
    public ComposePrepareResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComposePrepareResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ContentRule, ContentRuleFromRaw>))]
public sealed record class ContentRule : JsonModel
{
    public required string Rule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rule");
        }
        init { this._rawData.Set("rule", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Rule;
    }

    public ContentRule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContentRule(ContentRule contentRule)
        : base(contentRule) { }
#pragma warning restore CS8618

    public ContentRule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentRule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentRuleFromRaw.FromRawUnchecked"/>
    public static ContentRule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContentRule(string rule)
        : this()
    {
        this.Rule = rule;
    }
}

class ContentRuleFromRaw : IFromRawJson<ContentRule>
{
    /// <inheritdoc/>
    public ContentRule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContentRule.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EngagementMultiplier, EngagementMultiplierFromRaw>))]
public sealed record class EngagementMultiplier : JsonModel
{
    /// <summary>
    /// Human-readable published signal name.
    /// </summary>
    public required string Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public JsonElement Multiplier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("multiplier");
        }
        init { this._rawData.Set("multiplier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        if (
            !JsonElement.DeepEquals(
                this.Multiplier,
                JsonSerializer.SerializeToElement("Production weight not published by X")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public EngagementMultiplier()
    {
        this.Multiplier = JsonSerializer.SerializeToElement("Production weight not published by X");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EngagementMultiplier(EngagementMultiplier engagementMultiplier)
        : base(engagementMultiplier) { }
#pragma warning restore CS8618

    public EngagementMultiplier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Multiplier = JsonSerializer.SerializeToElement("Production weight not published by X");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EngagementMultiplier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EngagementMultiplierFromRaw.FromRawUnchecked"/>
    public static EngagementMultiplier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EngagementMultiplier(string action)
        : this()
    {
        this.Action = action;
    }
}

class EngagementMultiplierFromRaw : IFromRawJson<EngagementMultiplier>
{
    /// <inheritdoc/>
    public EngagementMultiplier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EngagementMultiplier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ScorerWeight, ScorerWeightFromRaw>))]
public sealed record class ScorerWeight : JsonModel
{
    /// <summary>
    /// Signal direction and publication limit.
    /// </summary>
    public required string Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    /// <summary>
    /// Signal name from X's public ranking repository.
    /// </summary>
    public required string Signal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signal");
        }
        init { this._rawData.Set("signal", value); }
    }

    /// <summary>
    /// X does not publish the production weight.
    /// </summary>
    public required Null? Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Null>("weight");
        }
        init { this._rawData.Set("weight", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
        _ = this.Signal;
        _ = this.Weight;
    }

    public ScorerWeight() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScorerWeight(ScorerWeight scorerWeight)
        : base(scorerWeight) { }
#pragma warning restore CS8618

    public ScorerWeight(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScorerWeight(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScorerWeightFromRaw.FromRawUnchecked"/>
    public static ScorerWeight FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScorerWeightFromRaw : IFromRawJson<ScorerWeight>
{
    /// <inheritdoc/>
    public ScorerWeight FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ScorerWeight.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SavedStyle, SavedStyleFromRaw>))]
public sealed record class SavedStyle : JsonModel
{
    public required long TweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetCount");
        }
        init { this._rawData.Set("tweetCount", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetCount;
        _ = this.Username;
    }

    public SavedStyle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SavedStyle(SavedStyle savedStyle)
        : base(savedStyle) { }
#pragma warning restore CS8618

    public SavedStyle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SavedStyle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SavedStyleFromRaw.FromRawUnchecked"/>
    public static SavedStyle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SavedStyleFromRaw : IFromRawJson<SavedStyle>
{
    /// <inheritdoc/>
    public SavedStyle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SavedStyle.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ComposeRefineResult, ComposeRefineResultFromRaw>))]
public sealed record class ComposeRefineResult : JsonModel
{
    /// <summary>
    /// Goal, tone, media, and editorial guidance.
    /// </summary>
    public required IReadOnlyList<string> CompositionGuidance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("compositionGuidance");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "compositionGuidance",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<ExamplePattern> ExamplePatterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExamplePattern>>(
                "examplePatterns"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExamplePattern>>(
                "examplePatterns",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X post intent seeded with the topic.
    /// </summary>
    public required string IntentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("intentUrl");
        }
        init { this._rawData.Set("intentUrl", value); }
    }

    public required string NextStep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("nextStep");
        }
        init { this._rawData.Set("nextStep", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompositionGuidance;
        foreach (var item in this.ExamplePatterns)
        {
            item.Validate();
        }
        _ = this.IntentUrl;
        _ = this.NextStep;
    }

    public ComposeRefineResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeRefineResult(ComposeRefineResult composeRefineResult)
        : base(composeRefineResult) { }
#pragma warning restore CS8618

    public ComposeRefineResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeRefineResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposeRefineResultFromRaw.FromRawUnchecked"/>
    public static ComposeRefineResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComposeRefineResultFromRaw : IFromRawJson<ComposeRefineResult>
{
    /// <inheritdoc/>
    public ComposeRefineResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComposeRefineResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ExamplePattern, ExamplePatternFromRaw>))]
public sealed record class ExamplePattern : JsonModel
{
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required string Pattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pattern");
        }
        init { this._rawData.Set("pattern", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Pattern;
    }

    public ExamplePattern() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExamplePattern(ExamplePattern examplePattern)
        : base(examplePattern) { }
#pragma warning restore CS8618

    public ExamplePattern(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExamplePattern(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExamplePatternFromRaw.FromRawUnchecked"/>
    public static ExamplePattern FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExamplePatternFromRaw : IFromRawJson<ExamplePattern>
{
    /// <inheritdoc/>
    public ExamplePattern FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExamplePattern.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ComposeScoreResult, ComposeScoreResultFromRaw>))]
public sealed record class ComposeScoreResult : JsonModel
{
    /// <summary>
    /// Deterministic editorial checks. Not a reach prediction.
    /// </summary>
    public required IReadOnlyList<Checklist> Checklist
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Checklist>>("checklist");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Checklist>>(
                "checklist",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string NextStep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("nextStep");
        }
        init { this._rawData.Set("nextStep", value); }
    }

    public required bool Passed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("passed");
        }
        init { this._rawData.Set("passed", value); }
    }

    public required long PassedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("passedCount");
        }
        init { this._rawData.Set("passedCount", value); }
    }

    public required string TopSuggestion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topSuggestion");
        }
        init { this._rawData.Set("topSuggestion", value); }
    }

    public JsonElement TotalChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("totalChecks");
        }
        init { this._rawData.Set("totalChecks", value); }
    }

    /// <summary>
    /// Present only when every check passes.
    /// </summary>
    public string? IntentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("intentUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("intentUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Checklist)
        {
            item.Validate();
        }
        _ = this.NextStep;
        _ = this.Passed;
        _ = this.PassedCount;
        _ = this.TopSuggestion;
        if (!JsonElement.DeepEquals(this.TotalChecks, JsonSerializer.SerializeToElement(9)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.IntentUrl;
    }

    public ComposeScoreResult()
    {
        this.TotalChecks = JsonSerializer.SerializeToElement(9);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeScoreResult(ComposeScoreResult composeScoreResult)
        : base(composeScoreResult) { }
#pragma warning restore CS8618

    public ComposeScoreResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.TotalChecks = JsonSerializer.SerializeToElement(9);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeScoreResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposeScoreResultFromRaw.FromRawUnchecked"/>
    public static ComposeScoreResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComposeScoreResultFromRaw : IFromRawJson<ComposeScoreResult>
{
    /// <inheritdoc/>
    public ComposeScoreResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComposeScoreResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Checklist, ChecklistFromRaw>))]
public sealed record class Checklist : JsonModel
{
    public required string Factor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("factor");
        }
        init { this._rawData.Set("factor", value); }
    }

    public required bool Passed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("passed");
        }
        init { this._rawData.Set("passed", value); }
    }

    /// <summary>
    /// Present only when the check fails.
    /// </summary>
    public string? Suggestion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suggestion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suggestion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Factor;
        _ = this.Passed;
        _ = this.Suggestion;
    }

    public Checklist() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Checklist(Checklist checklist)
        : base(checklist) { }
#pragma warning restore CS8618

    public Checklist(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Checklist(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChecklistFromRaw.FromRawUnchecked"/>
    public static Checklist FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChecklistFromRaw : IFromRawJson<Checklist>
{
    /// <inheritdoc/>
    public Checklist FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Checklist.FromRawUnchecked(rawData);
}
