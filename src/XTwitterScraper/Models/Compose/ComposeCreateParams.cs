using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Compose;

/// <summary>
/// Run one step of Xquik's three-step writing workflow. Compose returns questions
/// and editorial rules. Refine returns goal-specific guidance. Score applies deterministic
/// text checks. It does not predict reach or expose X ranking weights.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ComposeCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required Body Body
    {
        get { return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData"); }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public ComposeCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeCreateParams(ComposeCreateParams composeCreateParams)
        : base(composeCreateParams)
    {
        this.RawBodyData = composeCreateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public ComposeCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ComposeCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ComposeCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/compose")
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

[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
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

    public JsonElement Step
    {
        get
        {
            return Match(
                composePrepareRequest: (x) => x.Step,
                composeRefineRequest: (x) => x.Step,
                composeScoreRequest: (x) => x.Step
            );
        }
    }

    public string? Topic
    {
        get
        {
            return Match<string?>(
                composePrepareRequest: (x) => x.Topic,
                composeRefineRequest: (x) => x.Topic,
                composeScoreRequest: (_) => null
            );
        }
    }

    public Body(ComposePrepareRequest value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(ComposeRefineRequest value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(ComposeScoreRequest value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposePrepareRequest"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComposePrepareRequest(out var value)) {
    ///     // `value` is of type `ComposePrepareRequest`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComposePrepareRequest([NotNullWhen(true)] out ComposePrepareRequest? value)
    {
        value = this.Value as ComposePrepareRequest;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposeRefineRequest"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComposeRefineRequest(out var value)) {
    ///     // `value` is of type `ComposeRefineRequest`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComposeRefineRequest([NotNullWhen(true)] out ComposeRefineRequest? value)
    {
        value = this.Value as ComposeRefineRequest;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComposeScoreRequest"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComposeScoreRequest(out var value)) {
    ///     // `value` is of type `ComposeScoreRequest`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComposeScoreRequest([NotNullWhen(true)] out ComposeScoreRequest? value)
    {
        value = this.Value as ComposeScoreRequest;
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
    ///     (ComposePrepareRequest value) =&gt; {...},
    ///     (ComposeRefineRequest value) =&gt; {...},
    ///     (ComposeScoreRequest value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ComposePrepareRequest> composePrepareRequest,
        System::Action<ComposeRefineRequest> composeRefineRequest,
        System::Action<ComposeScoreRequest> composeScoreRequest
    )
    {
        switch (this.Value)
        {
            case ComposePrepareRequest value:
                composePrepareRequest(value);
                break;
            case ComposeRefineRequest value:
                composeRefineRequest(value);
                break;
            case ComposeScoreRequest value:
                composeScoreRequest(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of Body"
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
    ///     (ComposePrepareRequest value) =&gt; {...},
    ///     (ComposeRefineRequest value) =&gt; {...},
    ///     (ComposeScoreRequest value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ComposePrepareRequest, T> composePrepareRequest,
        System::Func<ComposeRefineRequest, T> composeRefineRequest,
        System::Func<ComposeScoreRequest, T> composeScoreRequest
    )
    {
        return this.Value switch
        {
            ComposePrepareRequest value => composePrepareRequest(value),
            ComposeRefineRequest value => composeRefineRequest(value),
            ComposeScoreRequest value => composeScoreRequest(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of Body"
            ),
        };
    }

    public static implicit operator Body(ComposePrepareRequest value) => new(value);

    public static implicit operator Body(ComposeRefineRequest value) => new(value);

    public static implicit operator Body(ComposeScoreRequest value) => new(value);

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
            throw new XTwitterScraperInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch(
            (composePrepareRequest) => composePrepareRequest.Validate(),
            (composeRefineRequest) => composeRefineRequest.Validate(),
            (composeScoreRequest) => composeScoreRequest.Validate()
        );
    }

    public virtual bool Equals(Body? other) =>
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
            ComposePrepareRequest _ => 0,
            ComposeRefineRequest _ => 1,
            ComposeScoreRequest _ => 2,
            _ => -1,
        };
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ComposePrepareRequest>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ComposeRefineRequest>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ComposeScoreRequest>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ComposePrepareRequest, ComposePrepareRequestFromRaw>))]
public sealed record class ComposePrepareRequest : JsonModel
{
    public JsonElement Step
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("step");
        }
        init { this._rawData.Set("step", value); }
    }

    /// <summary>
    /// Subject for the post.
    /// </summary>
    public required string Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic");
        }
        init { this._rawData.Set("topic", value); }
    }

    /// <summary>
    /// Editorial goal used to order the rules and questions.
    /// </summary>
    public ApiEnum<string, Goal>? Goal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Goal>>("goal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("goal", value);
        }
    }

    /// <summary>
    /// Username from a style analysis saved to this account.
    /// </summary>
    public string? StyleUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("styleUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("styleUsername", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Step, JsonSerializer.SerializeToElement("compose")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.Topic;
        this.Goal?.Validate();
        _ = this.StyleUsername;
    }

    public ComposePrepareRequest()
    {
        this.Step = JsonSerializer.SerializeToElement("compose");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposePrepareRequest(ComposePrepareRequest composePrepareRequest)
        : base(composePrepareRequest) { }
#pragma warning restore CS8618

    public ComposePrepareRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Step = JsonSerializer.SerializeToElement("compose");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposePrepareRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposePrepareRequestFromRaw.FromRawUnchecked"/>
    public static ComposePrepareRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComposePrepareRequest(string topic)
        : this()
    {
        this.Topic = topic;
    }
}

class ComposePrepareRequestFromRaw : IFromRawJson<ComposePrepareRequest>
{
    /// <inheritdoc/>
    public ComposePrepareRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComposePrepareRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Editorial goal used to order the rules and questions.
/// </summary>
[JsonConverter(typeof(GoalConverter))]
public enum Goal
{
    Engagement,
    Followers,
    Authority,
    Conversation,
}

sealed class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "engagement" => Goal.Engagement,
            "followers" => Goal.Followers,
            "authority" => Goal.Authority,
            "conversation" => Goal.Conversation,
            _ => (Goal)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Goal.Engagement => "engagement",
                Goal.Followers => "followers",
                Goal.Authority => "authority",
                Goal.Conversation => "conversation",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ComposeRefineRequest, ComposeRefineRequestFromRaw>))]
public sealed record class ComposeRefineRequest : JsonModel
{
    /// <summary>
    /// Editorial goal for the guidance.
    /// </summary>
    public required ApiEnum<string, ComposeRefineRequestGoal> Goal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ComposeRefineRequestGoal>>("goal");
        }
        init { this._rawData.Set("goal", value); }
    }

    public JsonElement Step
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("step");
        }
        init { this._rawData.Set("step", value); }
    }

    /// <summary>
    /// Requested writing tone.
    /// </summary>
    public required string Tone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tone");
        }
        init { this._rawData.Set("tone", value); }
    }

    /// <summary>
    /// Subject for the post.
    /// </summary>
    public required string Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic");
        }
        init { this._rawData.Set("topic", value); }
    }

    /// <summary>
    /// Audience, constraints, sources, or other writing context.
    /// </summary>
    public string? AdditionalContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("additionalContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("additionalContext", value);
        }
    }

    /// <summary>
    /// Specific action the draft should request.
    /// </summary>
    public string? CallToAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callToAction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callToAction", value);
        }
    }

    /// <summary>
    /// Planned media type.
    /// </summary>
    public ApiEnum<string, MediaType>? MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MediaType>>("mediaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Goal.Validate();
        if (!JsonElement.DeepEquals(this.Step, JsonSerializer.SerializeToElement("refine")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.Tone;
        _ = this.Topic;
        _ = this.AdditionalContext;
        _ = this.CallToAction;
        this.MediaType?.Validate();
    }

    public ComposeRefineRequest()
    {
        this.Step = JsonSerializer.SerializeToElement("refine");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeRefineRequest(ComposeRefineRequest composeRefineRequest)
        : base(composeRefineRequest) { }
#pragma warning restore CS8618

    public ComposeRefineRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Step = JsonSerializer.SerializeToElement("refine");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeRefineRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposeRefineRequestFromRaw.FromRawUnchecked"/>
    public static ComposeRefineRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComposeRefineRequestFromRaw : IFromRawJson<ComposeRefineRequest>
{
    /// <inheritdoc/>
    public ComposeRefineRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComposeRefineRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Editorial goal for the guidance.
/// </summary>
[JsonConverter(typeof(ComposeRefineRequestGoalConverter))]
public enum ComposeRefineRequestGoal
{
    Engagement,
    Followers,
    Authority,
    Conversation,
}

sealed class ComposeRefineRequestGoalConverter : JsonConverter<ComposeRefineRequestGoal>
{
    public override ComposeRefineRequestGoal Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "engagement" => ComposeRefineRequestGoal.Engagement,
            "followers" => ComposeRefineRequestGoal.Followers,
            "authority" => ComposeRefineRequestGoal.Authority,
            "conversation" => ComposeRefineRequestGoal.Conversation,
            _ => (ComposeRefineRequestGoal)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComposeRefineRequestGoal value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ComposeRefineRequestGoal.Engagement => "engagement",
                ComposeRefineRequestGoal.Followers => "followers",
                ComposeRefineRequestGoal.Authority => "authority",
                ComposeRefineRequestGoal.Conversation => "conversation",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Planned media type.
/// </summary>
[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    Photo,
    Video,
    None,
}

sealed class MediaTypeConverter : JsonConverter<MediaType>
{
    public override MediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "photo" => MediaType.Photo,
            "video" => MediaType.Video,
            "none" => MediaType.None,
            _ => (MediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaType.Photo => "photo",
                MediaType.Video => "video",
                MediaType.None => "none",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ComposeScoreRequest, ComposeScoreRequestFromRaw>))]
public sealed record class ComposeScoreRequest : JsonModel
{
    /// <summary>
    /// Full post text for deterministic editorial checks.
    /// </summary>
    public required string Draft
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("draft");
        }
        init { this._rawData.Set("draft", value); }
    }

    public JsonElement Step
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("step");
        }
        init { this._rawData.Set("step", value); }
    }

    /// <summary>
    /// True when a separate link card is attached.
    /// </summary>
    public bool? HasLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasLink");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasLink", value);
        }
    }

    /// <summary>
    /// Accepted for backward compatibility. Text checks ignore this field.
    /// </summary>
    [System::Obsolete("Ignored. Remove this field. Use hasLink for a separate link card.")]
    public bool? HasMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasMedia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasMedia", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Draft;
        if (!JsonElement.DeepEquals(this.Step, JsonSerializer.SerializeToElement("score")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.HasLink;
        _ = this.HasMedia;
    }

    public ComposeScoreRequest()
    {
        this.Step = JsonSerializer.SerializeToElement("score");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeScoreRequest(ComposeScoreRequest composeScoreRequest)
        : base(composeScoreRequest) { }
#pragma warning restore CS8618

    public ComposeScoreRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Step = JsonSerializer.SerializeToElement("score");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeScoreRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposeScoreRequestFromRaw.FromRawUnchecked"/>
    public static ComposeScoreRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComposeScoreRequest(string draft)
        : this()
    {
        this.Draft = draft;
    }
}

class ComposeScoreRequestFromRaw : IFromRawJson<ComposeScoreRequest>
{
    /// <inheritdoc/>
    public ComposeScoreRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComposeScoreRequest.FromRawUnchecked(rawData);
}
