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

namespace XTwitterScraper.Models.X.AccountConnectionAttempts;

/// <summary>
/// The connection is still in progress.
/// </summary>
[JsonConverter(typeof(AccountConnectionAttemptRetrieveResponseConverter))]
public record class AccountConnectionAttemptRetrieveResponse : ModelBase
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
                pending: (x) => x.ID,
                success: (x) => x.ID,
                failed: (x) => x.ID,
                requiresEmailCode: (x) => x.ID
            );
        }
    }

    public JsonElement Object
    {
        get
        {
            return Match(
                pending: (x) => x.Object,
                success: (x) => x.Object,
                failed: (x) => x.Object,
                requiresEmailCode: (x) => x.Object
            );
        }
    }

    public JsonElement Status
    {
        get
        {
            return Match(
                pending: (x) => x.Status,
                success: (x) => x.Status,
                failed: (x) => x.Status,
                requiresEmailCode: (x) => x.Status
            );
        }
    }

    public AccountConnectionAttemptRetrieveResponse(Pending value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(Success value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(Failed value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(
        RequiresEmailCode value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Pending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPending(out var value)) {
    ///     // `value` is of type `Pending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPending([NotNullWhen(true)] out Pending? value)
    {
        value = this.Value as Pending;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Success"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuccess(out var value)) {
    ///     // `value` is of type `Success`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuccess([NotNullWhen(true)] out Success? value)
    {
        value = this.Value as Success;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Failed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailed(out var value)) {
    ///     // `value` is of type `Failed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailed([NotNullWhen(true)] out Failed? value)
    {
        value = this.Value as Failed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RequiresEmailCode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRequiresEmailCode(out var value)) {
    ///     // `value` is of type `RequiresEmailCode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRequiresEmailCode([NotNullWhen(true)] out RequiresEmailCode? value)
    {
        value = this.Value as RequiresEmailCode;
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
    ///     (Pending value) =&gt; {...},
    ///     (Success value) =&gt; {...},
    ///     (Failed value) =&gt; {...},
    ///     (RequiresEmailCode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Pending> pending,
        System::Action<Success> success,
        System::Action<Failed> failed,
        System::Action<RequiresEmailCode> requiresEmailCode
    )
    {
        switch (this.Value)
        {
            case Pending value:
                pending(value);
                break;
            case Success value:
                success(value);
                break;
            case Failed value:
                failed(value);
                break;
            case RequiresEmailCode value:
                requiresEmailCode(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of AccountConnectionAttemptRetrieveResponse"
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
    ///     (Pending value) =&gt; {...},
    ///     (Success value) =&gt; {...},
    ///     (Failed value) =&gt; {...},
    ///     (RequiresEmailCode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Pending, T> pending,
        System::Func<Success, T> success,
        System::Func<Failed, T> failed,
        System::Func<RequiresEmailCode, T> requiresEmailCode
    )
    {
        return this.Value switch
        {
            Pending value => pending(value),
            Success value => success(value),
            Failed value => failed(value),
            RequiresEmailCode value => requiresEmailCode(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of AccountConnectionAttemptRetrieveResponse"
            ),
        };
    }

    public static implicit operator AccountConnectionAttemptRetrieveResponse(Pending value) =>
        new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(Success value) =>
        new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(Failed value) =>
        new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(
        RequiresEmailCode value
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
                "Data did not match any variant of AccountConnectionAttemptRetrieveResponse"
            );
        }
        this.Switch(
            (pending) => pending.Validate(),
            (success) => success.Validate(),
            (failed) => failed.Validate(),
            (requiresEmailCode) => requiresEmailCode.Validate()
        );
    }

    public virtual bool Equals(AccountConnectionAttemptRetrieveResponse? other) =>
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
            Pending _ => 0,
            Success _ => 1,
            Failed _ => 2,
            RequiresEmailCode _ => 3,
            _ => -1,
        };
    }
}

sealed class AccountConnectionAttemptRetrieveResponseConverter
    : JsonConverter<AccountConnectionAttemptRetrieveResponse>
{
    public override AccountConnectionAttemptRetrieveResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? status;
        try
        {
            status = element.GetProperty("status").GetString();
        }
        catch
        {
            status = null;
        }

        switch (status)
        {
            case "pending":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Pending>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "success":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Success>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "failed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Failed>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "requires_email_code":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RequiresEmailCode>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new AccountConnectionAttemptRetrieveResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountConnectionAttemptRetrieveResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The connection is still in progress.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pending, PendingFromRaw>))]
public sealed record class Pending : JsonModel
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

    public Pending()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pending(Pending pending)
        : base(pending) { }
#pragma warning restore CS8618

    public Pending(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PendingFromRaw.FromRawUnchecked"/>
    public static Pending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PendingFromRaw : IFromRawJson<Pending>
{
    /// <inheritdoc/>
    public Pending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pending.FromRawUnchecked(rawData);
}

/// <summary>
/// The account connected successfully.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Success, SuccessFromRaw>))]
public sealed record class Success : JsonModel
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
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("success")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public Success()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Success(Success success)
        : base(success) { }
#pragma warning restore CS8618

    public Success(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Success(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SuccessFromRaw.FromRawUnchecked"/>
    public static Success FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Success(string id)
        : this()
    {
        this.ID = id;
    }
}

class SuccessFromRaw : IFromRawJson<Success>
{
    /// <inheritdoc/>
    public Success FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Success.FromRawUnchecked(rawData);
}

/// <summary>
/// The connection reached a final failure.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Failed, FailedFromRaw>))]
public sealed record class Failed : JsonModel
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

    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
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

    public required bool Retryable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("retryable");
        }
        init { this._rawData.Set("retryable", value); }
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

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Error;
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("x_account_connection_attempt")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.Retryable;
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("failed")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.Reason;
    }

    public Failed()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Failed(Failed failed)
        : base(failed) { }
#pragma warning restore CS8618

    public Failed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Failed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailedFromRaw.FromRawUnchecked"/>
    public static Failed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailedFromRaw : IFromRawJson<Failed>
{
    /// <inheritdoc/>
    public Failed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Failed.FromRawUnchecked(rawData);
}

/// <summary>
/// Resumable account connection challenge. Submit the email code to finish the same
/// connection attempt.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequiresEmailCode, RequiresEmailCodeFromRaw>))]
public sealed record class RequiresEmailCode : JsonModel
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

    public RequiresEmailCode()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_challenge");
        this.Status = JsonSerializer.SerializeToElement("requires_email_code");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequiresEmailCode(RequiresEmailCode requiresEmailCode)
        : base(requiresEmailCode) { }
#pragma warning restore CS8618

    public RequiresEmailCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_challenge");
        this.Status = JsonSerializer.SerializeToElement("requires_email_code");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequiresEmailCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequiresEmailCodeFromRaw.FromRawUnchecked"/>
    public static RequiresEmailCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequiresEmailCodeFromRaw : IFromRawJson<RequiresEmailCode>
{
    /// <inheritdoc/>
    public RequiresEmailCode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RequiresEmailCode.FromRawUnchecked(rawData);
}
