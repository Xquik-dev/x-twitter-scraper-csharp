// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Accounts;

/// <summary>
/// Sanitized X account summary returned by connect and reauth.
/// </summary>
[JsonConverter(typeof(AccountCreateResponseConverter))]
public record class AccountCreateResponse : ModelBase
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
            return Match(
                sanitizedXAccount: (x) => x.ID,
                xAccountConnectionAttemptPending: (x) => x.ID,
                xAccountConnectionChallenge: (x) => x.ID
            );
        }
    }

    public JsonElement Status
    {
        get
        {
            return Match(
                sanitizedXAccount: (x) => x.Status,
                xAccountConnectionAttemptPending: (x) => x.Status,
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
                xAccountConnectionAttemptPending: (x) => x.Object,
                xAccountConnectionChallenge: (x) => x.Object
            );
        }
    }

    public AccountCreateResponse(SanitizedXAccount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AccountCreateResponse(
        XAccountConnectionAttemptPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountCreateResponse(XAccountConnectionChallenge value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AccountCreateResponse(JsonElement element)
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
    /// type <see cref="XAccountConnectionAttemptPending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickXAccountConnectionAttemptPending(out var value)) {
    ///     // `value` is of type `XAccountConnectionAttemptPending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickXAccountConnectionAttemptPending(
        [NotNullWhen(true)] out XAccountConnectionAttemptPending? value
    )
    {
        value = this.Value as XAccountConnectionAttemptPending;
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
    ///     (XAccountConnectionAttemptPending value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SanitizedXAccount> sanitizedXAccount,
        System::Action<XAccountConnectionAttemptPending> xAccountConnectionAttemptPending,
        System::Action<XAccountConnectionChallenge> xAccountConnectionChallenge
    )
    {
        switch (this.Value)
        {
            case SanitizedXAccount value:
                sanitizedXAccount(value);
                break;
            case XAccountConnectionAttemptPending value:
                xAccountConnectionAttemptPending(value);
                break;
            case XAccountConnectionChallenge value:
                xAccountConnectionChallenge(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of AccountCreateResponse"
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
    ///     (XAccountConnectionAttemptPending value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SanitizedXAccount, T> sanitizedXAccount,
        System::Func<XAccountConnectionAttemptPending, T> xAccountConnectionAttemptPending,
        System::Func<XAccountConnectionChallenge, T> xAccountConnectionChallenge
    )
    {
        return this.Value switch
        {
            SanitizedXAccount value => sanitizedXAccount(value),
            XAccountConnectionAttemptPending value => xAccountConnectionAttemptPending(value),
            XAccountConnectionChallenge value => xAccountConnectionChallenge(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of AccountCreateResponse"
            ),
        };
    }

    public static implicit operator AccountCreateResponse(SanitizedXAccount value) => new(value);

    public static implicit operator AccountCreateResponse(XAccountConnectionAttemptPending value) =>
        new(value);

    public static implicit operator AccountCreateResponse(XAccountConnectionChallenge value) =>
        new(value);

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
                "Data did not match any variant of AccountCreateResponse"
            );
        }
        this.Switch(
            (sanitizedXAccount) => sanitizedXAccount.Validate(),
            (xAccountConnectionAttemptPending) => xAccountConnectionAttemptPending.Validate(),
            (xAccountConnectionChallenge) => xAccountConnectionChallenge.Validate()
        );
    }

    public virtual bool Equals(AccountCreateResponse? other) =>
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
            XAccountConnectionAttemptPending _ => 1,
            XAccountConnectionChallenge _ => 2,
            _ => -1,
        };
    }
}

sealed class AccountCreateResponseConverter : JsonConverter<AccountCreateResponse>
{
    public override AccountCreateResponse? Read(
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
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

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
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<XAccountConnectionAttemptPending>(
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
            when (e is JsonException || e is XTwitterScraperInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountCreateResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Sanitized X account summary returned by connect and reauth.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SanitizedXAccount, SanitizedXAccountFromRaw>))]
public sealed record class SanitizedXAccount : JsonModel
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

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required ApiEnum<string, SanitizedXAccountHealth> Health
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SanitizedXAccountHealth>>(
                "health"
            );
        }
        init { this._rawData.Set("health", value); }
    }

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUserId");
        }
        init { this._rawData.Set("xUserId", value); }
    }

    public required string XUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUsername");
        }
        init { this._rawData.Set("xUsername", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Health.Validate();
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("active")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.XUserID;
        _ = this.XUsername;
    }

    public SanitizedXAccount()
    {
        this.Status = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SanitizedXAccount(SanitizedXAccount sanitizedXAccount)
        : base(sanitizedXAccount) { }
#pragma warning restore CS8618

    public SanitizedXAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Status = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SanitizedXAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SanitizedXAccountFromRaw.FromRawUnchecked"/>
    public static SanitizedXAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SanitizedXAccountFromRaw : IFromRawJson<SanitizedXAccount>
{
    /// <inheritdoc/>
    public SanitizedXAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SanitizedXAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SanitizedXAccountHealthConverter))]
public enum SanitizedXAccountHealth
{
    Healthy,
    Locked,
    NeedsReauth,
    Recovering,
    Suspended,
    TemporaryIssue,
}

sealed class SanitizedXAccountHealthConverter : JsonConverter<SanitizedXAccountHealth>
{
    public override SanitizedXAccountHealth Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "healthy" => SanitizedXAccountHealth.Healthy,
            "locked" => SanitizedXAccountHealth.Locked,
            "needsReauth" => SanitizedXAccountHealth.NeedsReauth,
            "recovering" => SanitizedXAccountHealth.Recovering,
            "suspended" => SanitizedXAccountHealth.Suspended,
            "temporaryIssue" => SanitizedXAccountHealth.TemporaryIssue,
            _ => (SanitizedXAccountHealth)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SanitizedXAccountHealth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SanitizedXAccountHealth.Healthy => "healthy",
                SanitizedXAccountHealth.Locked => "locked",
                SanitizedXAccountHealth.NeedsReauth => "needsReauth",
                SanitizedXAccountHealth.Recovering => "recovering",
                SanitizedXAccountHealth.Suspended => "suspended",
                SanitizedXAccountHealth.TemporaryIssue => "temporaryIssue",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The connection is still in progress.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        XAccountConnectionAttemptPending,
        XAccountConnectionAttemptPendingFromRaw
    >)
)]
public sealed record class XAccountConnectionAttemptPending : JsonModel
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

    public JsonElement Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("object");
        }
        init { this._rawData.Set("object", value); }
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

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("x_account_connection_attempt")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.PollAfterMs;
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("pending")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public XAccountConnectionAttemptPending()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionAttemptPending(
        XAccountConnectionAttemptPending xAccountConnectionAttemptPending
    )
        : base(xAccountConnectionAttemptPending) { }
#pragma warning restore CS8618

    public XAccountConnectionAttemptPending(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountConnectionAttemptPending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountConnectionAttemptPendingFromRaw.FromRawUnchecked"/>
    public static XAccountConnectionAttemptPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountConnectionAttemptPendingFromRaw : IFromRawJson<XAccountConnectionAttemptPending>
{
    /// <inheritdoc/>
    public XAccountConnectionAttemptPending FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XAccountConnectionAttemptPending.FromRawUnchecked(rawData);
}

/// <summary>
/// Resumable account connection challenge. Submit the email code to finish the same
/// connection attempt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<XAccountConnectionChallenge, XAccountConnectionChallengeFromRaw>)
)]
public sealed record class XAccountConnectionChallenge : JsonModel
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

    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public JsonElement Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.ID;
        _ = this.ExpiresAt;
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("x_account_connection_challenge")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Status,
                JsonSerializer.SerializeToElement("requires_email_code")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.Username;
    }

    public XAccountConnectionChallenge()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_challenge");
        this.Status = JsonSerializer.SerializeToElement("requires_email_code");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionChallenge(XAccountConnectionChallenge xAccountConnectionChallenge)
        : base(xAccountConnectionChallenge) { }
#pragma warning restore CS8618

    public XAccountConnectionChallenge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_challenge");
        this.Status = JsonSerializer.SerializeToElement("requires_email_code");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountConnectionChallenge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountConnectionChallengeFromRaw.FromRawUnchecked"/>
    public static XAccountConnectionChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountConnectionChallengeFromRaw : IFromRawJson<XAccountConnectionChallenge>
{
    /// <inheritdoc/>
    public XAccountConnectionChallenge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XAccountConnectionChallenge.FromRawUnchecked(rawData);
}
