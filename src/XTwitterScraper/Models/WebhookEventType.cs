// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models;

/// <summary>
/// An event a webhook delivers, either an account or keyword monitor <see cref="EventType"/>
/// or a post monitor <see cref="PostEventType"/>.
/// </summary>
[JsonConverter(typeof(WebhookEventTypeConverter))]
public record class WebhookEventType : ModelBase
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

    public WebhookEventType(ApiEnum<string, EventType> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEventType(ApiEnum<string, PostEventType> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookEventType(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of EventType.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventType(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, EventType&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventType([NotNullWhen(true)] out ApiEnum<string, EventType>? value)
    {
        value = this.Value as ApiEnum<string, EventType>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of PostEventType.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPostEventType(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, PostEventType&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPostEventType([NotNullWhen(true)] out ApiEnum<string, PostEventType>? value)
    {
        value = this.Value as ApiEnum<string, PostEventType>;
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
    ///     (ApiEnum&lt;string, EventType&gt; value) =&gt; {...},
    ///     (ApiEnum&lt;string, PostEventType&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiEnum<string, EventType>> eventType,
        System::Action<ApiEnum<string, PostEventType>> postEventType
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, EventType> value:
                eventType(value);
                break;
            case ApiEnum<string, PostEventType> value:
                postEventType(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of WebhookEventType"
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
    ///     (ApiEnum&lt;string, EventType&gt; value) =&gt; {...},
    ///     (ApiEnum&lt;string, PostEventType&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiEnum<string, EventType>, T> eventType,
        System::Func<ApiEnum<string, PostEventType>, T> postEventType
    )
    {
        return this.Value switch
        {
            ApiEnum<string, EventType> value => eventType(value),
            ApiEnum<string, PostEventType> value => postEventType(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of WebhookEventType"
            ),
        };
    }

    public static implicit operator WebhookEventType(ApiEnum<string, EventType> value) =>
        new(value);

    public static implicit operator WebhookEventType(EventType value) => new(value);

    public static implicit operator WebhookEventType(ApiEnum<string, PostEventType> value) =>
        new(value);

    public static implicit operator WebhookEventType(PostEventType value) => new(value);

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
                "Data did not match any variant of WebhookEventType"
            );
        }
        this.Switch(
            (eventType) => eventType.Validate(),
            (postEventType) => postEventType.Validate()
        );
    }

    public virtual bool Equals(WebhookEventType? other) =>
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
            ApiEnum<string, EventType> _ => 0,
            ApiEnum<string, PostEventType> _ => 1,
            _ => -1,
        };
    }
}

sealed class WebhookEventTypeConverter : JsonConverter<WebhookEventType>
{
    public override WebhookEventType? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is XTwitterScraperInvalidDataException) { }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PostEventType>>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is XTwitterScraperInvalidDataException) { }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
