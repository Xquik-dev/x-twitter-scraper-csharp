// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;
using System = System;

namespace XTwitterScraper.Models.X.AccountConnectionChallenges;

/// <summary>
/// The connected account once X accepts the code, or the next challenge when X asks
/// for another one.
/// </summary>
[JsonConverter(typeof(AccountConnectionChallengeSubmitResponseConverter))]
public record class AccountConnectionChallengeSubmitResponse : ModelBase
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

    public string ID
    {
        get
        {
            return Match(sanitizedXAccount: (x) => x.ID, xAccountConnectionChallenge: (x) => x.ID);
        }
    }

    public JsonElement Status
    {
        get
        {
            return Match(
                sanitizedXAccount: (x) => x.Status,
                xAccountConnectionChallenge: (x) => x.Status
            );
        }
    }

    public JsonElement? Object
    {
        get
        {
            return Match<JsonElement?>(
                sanitizedXAccount: (_) => null,
                xAccountConnectionChallenge: (x) => x.Object
            );
        }
    }

    public AccountConnectionChallengeSubmitResponse(
        SanitizedXAccount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionChallengeSubmitResponse(
        XAccountConnectionChallenge value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionChallengeSubmitResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SanitizedXAccount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSanitizedXAccount(out var value)) {
    ///     // `value` is of type `SanitizedXAccount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSanitizedXAccount([NotNullWhen(true)] out SanitizedXAccount? value)
    {
        value = this.Value as SanitizedXAccount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="XAccountConnectionChallenge"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickXAccountConnectionChallenge(out var value)) {
    ///     // `value` is of type `XAccountConnectionChallenge`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickXAccountConnectionChallenge(
        [NotNullWhen(true)] out XAccountConnectionChallenge? value
    )
    {
        value = this.Value as XAccountConnectionChallenge;
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
    ///     (SanitizedXAccount value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SanitizedXAccount> sanitizedXAccount,
        System::Action<XAccountConnectionChallenge> xAccountConnectionChallenge
    )
    {
        switch (this.Value)
        {
            case SanitizedXAccount value:
                sanitizedXAccount(value);
                break;
            case XAccountConnectionChallenge value:
                xAccountConnectionChallenge(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of AccountConnectionChallengeSubmitResponse"
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
    ///     (SanitizedXAccount value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SanitizedXAccount, T> sanitizedXAccount,
        System::Func<XAccountConnectionChallenge, T> xAccountConnectionChallenge
    )
    {
        return this.Value switch
        {
            SanitizedXAccount value => sanitizedXAccount(value),
            XAccountConnectionChallenge value => xAccountConnectionChallenge(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of AccountConnectionChallengeSubmitResponse"
            ),
        };
    }

    public static implicit operator AccountConnectionChallengeSubmitResponse(
        SanitizedXAccount value
    ) => new(value);

    public static implicit operator AccountConnectionChallengeSubmitResponse(
        XAccountConnectionChallenge value
    ) => new(value);

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
                "Data did not match any variant of AccountConnectionChallengeSubmitResponse"
            );
        }
        this.Switch(
            (sanitizedXAccount) => sanitizedXAccount.Validate(),
            (xAccountConnectionChallenge) => xAccountConnectionChallenge.Validate()
        );
    }

    public virtual bool Equals(AccountConnectionChallengeSubmitResponse? other) =>
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
            SanitizedXAccount _ => 0,
            XAccountConnectionChallenge _ => 1,
            _ => -1,
        };
    }
}

sealed class AccountConnectionChallengeSubmitResponseConverter
    : JsonConverter<AccountConnectionChallengeSubmitResponse>
{
    public override AccountConnectionChallengeSubmitResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SanitizedXAccount>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<XAccountConnectionChallenge>(
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
        AccountConnectionChallengeSubmitResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
