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
                xAccountConnectionAttemptPending: (x) => x.ID,
                xAccountConnectionAttemptSuccess: (x) => x.ID,
                xAccountConnectionAttemptFailed: (x) => x.ID,
                xAccountConnectionChallenge: (x) => x.ID
            );
        }
    }

    public AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptSuccess value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionChallenge value,
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
    /// type <see cref="XAccountConnectionAttemptSuccess"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickXAccountConnectionAttemptSuccess(out var value)) {
    ///     // `value` is of type `XAccountConnectionAttemptSuccess`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickXAccountConnectionAttemptSuccess(
        [NotNullWhen(true)] out XAccountConnectionAttemptSuccess? value
    )
    {
        value = this.Value as XAccountConnectionAttemptSuccess;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="XAccountConnectionAttemptFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickXAccountConnectionAttemptFailed(out var value)) {
    ///     // `value` is of type `XAccountConnectionAttemptFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickXAccountConnectionAttemptFailed(
        [NotNullWhen(true)] out XAccountConnectionAttemptFailed? value
    )
    {
        value = this.Value as XAccountConnectionAttemptFailed;
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
    ///     (XAccountConnectionAttemptPending value) =&gt; {...},
    ///     (XAccountConnectionAttemptSuccess value) =&gt; {...},
    ///     (XAccountConnectionAttemptFailed value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<XAccountConnectionAttemptPending> xAccountConnectionAttemptPending,
        System::Action<XAccountConnectionAttemptSuccess> xAccountConnectionAttemptSuccess,
        System::Action<XAccountConnectionAttemptFailed> xAccountConnectionAttemptFailed,
        System::Action<XAccountConnectionChallenge> xAccountConnectionChallenge
    )
    {
        switch (this.Value)
        {
            case XAccountConnectionAttemptPending value:
                xAccountConnectionAttemptPending(value);
                break;
            case XAccountConnectionAttemptSuccess value:
                xAccountConnectionAttemptSuccess(value);
                break;
            case XAccountConnectionAttemptFailed value:
                xAccountConnectionAttemptFailed(value);
                break;
            case XAccountConnectionChallenge value:
                xAccountConnectionChallenge(value);
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
    ///     (XAccountConnectionAttemptPending value) =&gt; {...},
    ///     (XAccountConnectionAttemptSuccess value) =&gt; {...},
    ///     (XAccountConnectionAttemptFailed value) =&gt; {...},
    ///     (XAccountConnectionChallenge value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<XAccountConnectionAttemptPending, T> xAccountConnectionAttemptPending,
        System::Func<XAccountConnectionAttemptSuccess, T> xAccountConnectionAttemptSuccess,
        System::Func<XAccountConnectionAttemptFailed, T> xAccountConnectionAttemptFailed,
        System::Func<XAccountConnectionChallenge, T> xAccountConnectionChallenge
    )
    {
        return this.Value switch
        {
            XAccountConnectionAttemptPending value => xAccountConnectionAttemptPending(value),
            XAccountConnectionAttemptSuccess value => xAccountConnectionAttemptSuccess(value),
            XAccountConnectionAttemptFailed value => xAccountConnectionAttemptFailed(value),
            XAccountConnectionChallenge value => xAccountConnectionChallenge(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of AccountConnectionAttemptRetrieveResponse"
            ),
        };
    }

    public static implicit operator AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptPending value
    ) => new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptSuccess value
    ) => new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(
        XAccountConnectionAttemptFailed value
    ) => new(value);

    public static implicit operator AccountConnectionAttemptRetrieveResponse(
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
                "Data did not match any variant of AccountConnectionAttemptRetrieveResponse"
            );
        }
        this.Switch(
            (xAccountConnectionAttemptPending) => xAccountConnectionAttemptPending.Validate(),
            (xAccountConnectionAttemptSuccess) => xAccountConnectionAttemptSuccess.Validate(),
            (xAccountConnectionAttemptFailed) => xAccountConnectionAttemptFailed.Validate(),
            (xAccountConnectionChallenge) => xAccountConnectionChallenge.Validate()
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
            XAccountConnectionAttemptPending _ => 0,
            XAccountConnectionAttemptSuccess _ => 1,
            XAccountConnectionAttemptFailed _ => 2,
            XAccountConnectionChallenge _ => 3,
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
            var deserialized = JsonSerializer.Deserialize<XAccountConnectionAttemptFailed>(
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<XAccountConnectionAttemptSuccess>(
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
/// The account connected successfully.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        XAccountConnectionAttemptSuccess,
        XAccountConnectionAttemptSuccessFromRaw
    >)
)]
public sealed record class XAccountConnectionAttemptSuccess : JsonModel
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

    public XAccountConnectionAttemptSuccess()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionAttemptSuccess(
        XAccountConnectionAttemptSuccess xAccountConnectionAttemptSuccess
    )
        : base(xAccountConnectionAttemptSuccess) { }
#pragma warning restore CS8618

    public XAccountConnectionAttemptSuccess(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountConnectionAttemptSuccess(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountConnectionAttemptSuccessFromRaw.FromRawUnchecked"/>
    public static XAccountConnectionAttemptSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public XAccountConnectionAttemptSuccess(string id)
        : this()
    {
        this.ID = id;
    }
}

class XAccountConnectionAttemptSuccessFromRaw : IFromRawJson<XAccountConnectionAttemptSuccess>
{
    /// <inheritdoc/>
    public XAccountConnectionAttemptSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XAccountConnectionAttemptSuccess.FromRawUnchecked(rawData);
}

/// <summary>
/// The connection reached a final failure.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        XAccountConnectionAttemptFailed,
        XAccountConnectionAttemptFailedFromRaw
    >)
)]
public sealed record class XAccountConnectionAttemptFailed : JsonModel
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

    public XAccountConnectionAttemptFailed()
    {
        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionAttemptFailed(
        XAccountConnectionAttemptFailed xAccountConnectionAttemptFailed
    )
        : base(xAccountConnectionAttemptFailed) { }
#pragma warning restore CS8618

    public XAccountConnectionAttemptFailed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_account_connection_attempt");
        this.Status = JsonSerializer.SerializeToElement("failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountConnectionAttemptFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountConnectionAttemptFailedFromRaw.FromRawUnchecked"/>
    public static XAccountConnectionAttemptFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountConnectionAttemptFailedFromRaw : IFromRawJson<XAccountConnectionAttemptFailed>
{
    /// <inheritdoc/>
    public XAccountConnectionAttemptFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XAccountConnectionAttemptFailed.FromRawUnchecked(rawData);
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

    public required ApiEnum<string, Object> Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Object>>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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
        this.Object.Validate();
        this.Status.Validate();
        _ = this.Username;
    }

    public XAccountConnectionChallenge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionChallenge(XAccountConnectionChallenge xAccountConnectionChallenge)
        : base(xAccountConnectionChallenge) { }
#pragma warning restore CS8618

    public XAccountConnectionChallenge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    XAccountConnectionChallenge,
}

sealed class ObjectConverter : JsonConverter<Object>
{
    public override Object Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x_account_connection_challenge" => Object.XAccountConnectionChallenge,
            _ => (Object)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Object.XAccountConnectionChallenge => "x_account_connection_challenge",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    RequiresEmailCode,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requires_email_code" => Status.RequiresEmailCode,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.RequiresEmailCode => "requires_email_code",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
