// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Extractions;

/// <summary>
/// The free cost estimate of a dry run, or the job a real run starts.
/// </summary>
[JsonConverter(typeof(ExtractionRunResponseConverter))]
public record class ExtractionRunResponse : ModelBase
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

    public ExtractionRunResponse(ExtractionEstimateCostResponse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractionRunResponse(ExtractionStarted value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExtractionRunResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractionEstimateCostResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    /// </summary>
    public bool TryPickEstimate([NotNullWhen(true)] out ExtractionEstimateCostResponse? value)
    {
        value = this.Value as ExtractionEstimateCostResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractionStarted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    /// </summary>
    public bool TryPickStarted([NotNullWhen(true)] out ExtractionStarted? value)
    {
        value = this.Value as ExtractionStarted;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter for the variant the instance holds.
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    /// </summary>
    public void Switch(
        System::Action<ExtractionEstimateCostResponse> estimate,
        System::Action<ExtractionStarted> started
    )
    {
        switch (this.Value)
        {
            case ExtractionEstimateCostResponse value:
                estimate(value);
                break;
            case ExtractionStarted value:
                started(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of ExtractionRunResponse"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter for the variant the instance holds and returns its result.
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    /// </summary>
    public T Match<T>(
        System::Func<ExtractionEstimateCostResponse, T> estimate,
        System::Func<ExtractionStarted, T> started
    )
    {
        return this.Value switch
        {
            ExtractionEstimateCostResponse value => estimate(value),
            ExtractionStarted value => started(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of ExtractionRunResponse"
            ),
        };
    }

    public static implicit operator ExtractionRunResponse(ExtractionEstimateCostResponse value) =>
        new(value);

    public static implicit operator ExtractionRunResponse(ExtractionStarted value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
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
                "Data did not match any variant of ExtractionRunResponse"
            );
        }
        this.Switch((estimate) => estimate.Validate(), (started) => started.Validate());
    }

    public virtual bool Equals(ExtractionRunResponse? other) =>
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
            ExtractionEstimateCostResponse _ => 0,
            ExtractionStarted _ => 1,
            _ => -1,
        };
    }
}

sealed class ExtractionRunResponseConverter : JsonConverter<ExtractionRunResponse>
{
    public override ExtractionRunResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ExtractionEstimateCostResponse>(
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
            var deserialized = JsonSerializer.Deserialize<ExtractionStarted>(element, options);
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
        ExtractionRunResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
