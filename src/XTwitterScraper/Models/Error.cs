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

namespace XTwitterScraper.Models;

/// <summary>
/// Error response. Default v1 returns a legacy string error code. Send `xquik-api-contract:
/// 2026-04-29` to receive the structured best-practice error object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    public required ErrorError ErrorValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ErrorError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Human-readable error guidance.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Machine-readable reason for a login cooldown.
    /// </summary>
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

    /// <summary>
    /// Seconds until the next permitted request.
    /// </summary>
    public long? RetryAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retryAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retryAfter", value);
        }
    }

    /// <summary>
    /// Required wait in milliseconds.
    /// </summary>
    public long? RetryAfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retryAfterMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retryAfterMs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorValue.Validate();
        _ = this.Message;
        _ = this.Reason;
        _ = this.RetryAfter;
        _ = this.RetryAfterMs;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Error(ErrorError errorValue)
        : this()
    {
        this.ErrorValue = errorValue;
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ErrorErrorConverter))]
public record class ErrorError : ModelBase
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

    public ErrorError(ApiEnum<string, LegacyErrorCode> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorError(StructuredError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorError(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of LegacyErrorCode>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLegacyErrorCode(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, LegacyErrorCode&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLegacyErrorCode(
        [NotNullWhen(true)] out ApiEnum<string, LegacyErrorCode>? value
    )
    {
        value = this.Value as ApiEnum<string, LegacyErrorCode>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StructuredError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStructured(out var value)) {
    ///     // `value` is of type `StructuredError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStructured([NotNullWhen(true)] out StructuredError? value)
    {
        value = this.Value as StructuredError;
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
    ///     (ApiEnum&lt;string, LegacyErrorCode&gt; value) =&gt; {...},
    ///     (StructuredError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiEnum<string, LegacyErrorCode>> legacyErrorCode,
        System::Action<StructuredError> structured
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, LegacyErrorCode> value:
                legacyErrorCode(value);
                break;
            case StructuredError value:
                structured(value);
                break;
            default:
                throw new XTwitterScraperInvalidDataException(
                    "Data did not match any variant of ErrorError"
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
    ///     (ApiEnum&lt;string, LegacyErrorCode&gt; value) =&gt; {...},
    ///     (StructuredError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiEnum<string, LegacyErrorCode>, T> legacyErrorCode,
        System::Func<StructuredError, T> structured
    )
    {
        return this.Value switch
        {
            ApiEnum<string, LegacyErrorCode> value => legacyErrorCode(value),
            StructuredError value => structured(value),
            _ => throw new XTwitterScraperInvalidDataException(
                "Data did not match any variant of ErrorError"
            ),
        };
    }

    public static implicit operator ErrorError(ApiEnum<string, LegacyErrorCode> value) =>
        new(value);

    public static implicit operator ErrorError(LegacyErrorCode value) => new(value);

    public static implicit operator ErrorError(StructuredError value) => new(value);

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
                "Data did not match any variant of ErrorError"
            );
        }
        this.Switch(
            (legacyErrorCode) => legacyErrorCode.Validate(),
            (structured) => structured.Validate()
        );
    }

    public virtual bool Equals(ErrorError? other) =>
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
            ApiEnum<string, LegacyErrorCode> _ => 0,
            StructuredError _ => 1,
            _ => -1,
        };
    }
}

sealed class ErrorErrorConverter : JsonConverter<ErrorError>
{
    public override ErrorError? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LegacyErrorCode>>(
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
            var deserialized = JsonSerializer.Deserialize<StructuredError>(element, options);
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
        ErrorError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(LegacyErrorCodeConverter))]
public enum LegacyErrorCode
{
    InternalError,
    AccountAlreadyConnected,
    AccountNeedsReauth,
    AccountNotFound,
    AccountRequired,
    AccountRestricted,
    ApiKeyLimitReached,
    ArticleNotFound,
    DmNotPermitted,
    InvalidFormat,
    InvalidID,
    InvalidInput,
    InvalidParams,
    InvalidToolType,
    InvalidTweetID,
    InvalidTweetUrl,
    InvalidUserID,
    InvalidUserIds,
    InvalidUsername,
    InvalidJson,
    InsufficientCredits,
    LoginCooldown,
    LoginFailed,
    MediaDownloadFailed,
    MissingParams,
    MissingQuery,
    MonitorAlreadyExists,
    NoMedia,
    NoCredits,
    NoSubscription,
    NotFound,
    PaymentFailed,
    RateLimitExceeded,
    ServiceUnavailable,
    StyleNotFound,
    SubscriptionInactive,
    TweetNotFound,
    Unauthenticated,
    UnsupportedField,
    UserNotFound,
    BodyTooLarge,
    CheckoutUnavailable,
    ConnectionChallengeExpired,
    ConnectionChallengeInactive,
    DraftNotFound,
    FavoritersUnavailable,
    Forbidden,
    GuestWalletUnavailable,
    GuestWalletsDisabled,
    GuestWalletsUnavailable,
    IdempotencyConflict,
    IdempotencyKeyConflict,
    InvalidCommunityID,
    InvalidIdempotencyKey,
    InvalidListID,
    InvalidPaymentAmount,
    InvalidRange,
    LoginRateLimited,
    MissingIdempotencyKey,
    MissingIds,
    NoCachedStyle,
    PasskeyRequired,
    RateLimited,
    ReadRequestTimeout,
    RepliesIncomplete,
    SupportMediaRateLimit,
    SupportRequestRateLimit,
    TooManyIds,
    UnknownField,
    UnsupportedMediaType,
    WebhookInactive,
    WriteTrackingUnavailable,
    XWriteUnconfirmed,
    XAccountFeatureRequired,
    XAccountProtected,
    XAccountSuspended,
    XApiRateLimited,
    XApiUnavailable,
    XApiUnauthorized,
    XAuthFailure,
    XContentTooLong,
    XDailyLimit,
    XDmNotAllowed,
    XDuplicateAction,
    XLoginAuthFailed,
    XLoginChallenge,
    XLoginDenied,
    XLoginFailed,
    XLoginProxyError,
    XLoginRateLimited,
    XLoginServiceUnavailable,
    XLoginSuspended,
    XRateLimited,
    XRejected,
    XTargetNotFound,
    XTransientError,
    XUserLookupFailed,
    XWriteAmbiguous,
    XWriteFailed,
}

sealed class LegacyErrorCodeConverter : JsonConverter<LegacyErrorCode>
{
    public override LegacyErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal_error" => LegacyErrorCode.InternalError,
            "account_already_connected" => LegacyErrorCode.AccountAlreadyConnected,
            "account_needs_reauth" => LegacyErrorCode.AccountNeedsReauth,
            "account_not_found" => LegacyErrorCode.AccountNotFound,
            "account_required" => LegacyErrorCode.AccountRequired,
            "account_restricted" => LegacyErrorCode.AccountRestricted,
            "api_key_limit_reached" => LegacyErrorCode.ApiKeyLimitReached,
            "article_not_found" => LegacyErrorCode.ArticleNotFound,
            "dm_not_permitted" => LegacyErrorCode.DmNotPermitted,
            "invalid_format" => LegacyErrorCode.InvalidFormat,
            "invalid_id" => LegacyErrorCode.InvalidID,
            "invalid_input" => LegacyErrorCode.InvalidInput,
            "invalid_params" => LegacyErrorCode.InvalidParams,
            "invalid_tool_type" => LegacyErrorCode.InvalidToolType,
            "invalid_tweet_id" => LegacyErrorCode.InvalidTweetID,
            "invalid_tweet_url" => LegacyErrorCode.InvalidTweetUrl,
            "invalid_user_id" => LegacyErrorCode.InvalidUserID,
            "invalid_user_ids" => LegacyErrorCode.InvalidUserIds,
            "invalid_username" => LegacyErrorCode.InvalidUsername,
            "invalid_json" => LegacyErrorCode.InvalidJson,
            "insufficient_credits" => LegacyErrorCode.InsufficientCredits,
            "login_cooldown" => LegacyErrorCode.LoginCooldown,
            "login_failed" => LegacyErrorCode.LoginFailed,
            "media_download_failed" => LegacyErrorCode.MediaDownloadFailed,
            "missing_params" => LegacyErrorCode.MissingParams,
            "missing_query" => LegacyErrorCode.MissingQuery,
            "monitor_already_exists" => LegacyErrorCode.MonitorAlreadyExists,
            "no_media" => LegacyErrorCode.NoMedia,
            "no_credits" => LegacyErrorCode.NoCredits,
            "no_subscription" => LegacyErrorCode.NoSubscription,
            "not_found" => LegacyErrorCode.NotFound,
            "payment_failed" => LegacyErrorCode.PaymentFailed,
            "rate_limit_exceeded" => LegacyErrorCode.RateLimitExceeded,
            "service_unavailable" => LegacyErrorCode.ServiceUnavailable,
            "style_not_found" => LegacyErrorCode.StyleNotFound,
            "subscription_inactive" => LegacyErrorCode.SubscriptionInactive,
            "tweet_not_found" => LegacyErrorCode.TweetNotFound,
            "unauthenticated" => LegacyErrorCode.Unauthenticated,
            "unsupported_field" => LegacyErrorCode.UnsupportedField,
            "user_not_found" => LegacyErrorCode.UserNotFound,
            "body_too_large" => LegacyErrorCode.BodyTooLarge,
            "checkout_unavailable" => LegacyErrorCode.CheckoutUnavailable,
            "connection_challenge_expired" => LegacyErrorCode.ConnectionChallengeExpired,
            "connection_challenge_inactive" => LegacyErrorCode.ConnectionChallengeInactive,
            "draft_not_found" => LegacyErrorCode.DraftNotFound,
            "favoriters_unavailable" => LegacyErrorCode.FavoritersUnavailable,
            "forbidden" => LegacyErrorCode.Forbidden,
            "guest_wallet_unavailable" => LegacyErrorCode.GuestWalletUnavailable,
            "guest_wallets_disabled" => LegacyErrorCode.GuestWalletsDisabled,
            "guest_wallets_unavailable" => LegacyErrorCode.GuestWalletsUnavailable,
            "idempotency_conflict" => LegacyErrorCode.IdempotencyConflict,
            "idempotency_key_conflict" => LegacyErrorCode.IdempotencyKeyConflict,
            "invalid_community_id" => LegacyErrorCode.InvalidCommunityID,
            "invalid_idempotency_key" => LegacyErrorCode.InvalidIdempotencyKey,
            "invalid_list_id" => LegacyErrorCode.InvalidListID,
            "invalid_payment_amount" => LegacyErrorCode.InvalidPaymentAmount,
            "invalid_range" => LegacyErrorCode.InvalidRange,
            "login_rate_limited" => LegacyErrorCode.LoginRateLimited,
            "missing_idempotency_key" => LegacyErrorCode.MissingIdempotencyKey,
            "missing_ids" => LegacyErrorCode.MissingIds,
            "no_cached_style" => LegacyErrorCode.NoCachedStyle,
            "passkey_required" => LegacyErrorCode.PasskeyRequired,
            "rate_limited" => LegacyErrorCode.RateLimited,
            "read_request_timeout" => LegacyErrorCode.ReadRequestTimeout,
            "replies_incomplete" => LegacyErrorCode.RepliesIncomplete,
            "support_media_rate_limit" => LegacyErrorCode.SupportMediaRateLimit,
            "support_request_rate_limit" => LegacyErrorCode.SupportRequestRateLimit,
            "too_many_ids" => LegacyErrorCode.TooManyIds,
            "unknown_field" => LegacyErrorCode.UnknownField,
            "unsupported_media_type" => LegacyErrorCode.UnsupportedMediaType,
            "webhook_inactive" => LegacyErrorCode.WebhookInactive,
            "write_tracking_unavailable" => LegacyErrorCode.WriteTrackingUnavailable,
            "x_write_unconfirmed" => LegacyErrorCode.XWriteUnconfirmed,
            "x_account_feature_required" => LegacyErrorCode.XAccountFeatureRequired,
            "x_account_protected" => LegacyErrorCode.XAccountProtected,
            "x_account_suspended" => LegacyErrorCode.XAccountSuspended,
            "x_api_rate_limited" => LegacyErrorCode.XApiRateLimited,
            "x_api_unavailable" => LegacyErrorCode.XApiUnavailable,
            "x_api_unauthorized" => LegacyErrorCode.XApiUnauthorized,
            "x_auth_failure" => LegacyErrorCode.XAuthFailure,
            "x_content_too_long" => LegacyErrorCode.XContentTooLong,
            "x_daily_limit" => LegacyErrorCode.XDailyLimit,
            "x_dm_not_allowed" => LegacyErrorCode.XDmNotAllowed,
            "x_duplicate_action" => LegacyErrorCode.XDuplicateAction,
            "x_login_auth_failed" => LegacyErrorCode.XLoginAuthFailed,
            "x_login_challenge" => LegacyErrorCode.XLoginChallenge,
            "x_login_denied" => LegacyErrorCode.XLoginDenied,
            "x_login_failed" => LegacyErrorCode.XLoginFailed,
            "x_login_proxy_error" => LegacyErrorCode.XLoginProxyError,
            "x_login_rate_limited" => LegacyErrorCode.XLoginRateLimited,
            "x_login_service_unavailable" => LegacyErrorCode.XLoginServiceUnavailable,
            "x_login_suspended" => LegacyErrorCode.XLoginSuspended,
            "x_rate_limited" => LegacyErrorCode.XRateLimited,
            "x_rejected" => LegacyErrorCode.XRejected,
            "x_target_not_found" => LegacyErrorCode.XTargetNotFound,
            "x_transient_error" => LegacyErrorCode.XTransientError,
            "x_user_lookup_failed" => LegacyErrorCode.XUserLookupFailed,
            "x_write_ambiguous" => LegacyErrorCode.XWriteAmbiguous,
            "x_write_failed" => LegacyErrorCode.XWriteFailed,
            _ => (LegacyErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LegacyErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LegacyErrorCode.InternalError => "internal_error",
                LegacyErrorCode.AccountAlreadyConnected => "account_already_connected",
                LegacyErrorCode.AccountNeedsReauth => "account_needs_reauth",
                LegacyErrorCode.AccountNotFound => "account_not_found",
                LegacyErrorCode.AccountRequired => "account_required",
                LegacyErrorCode.AccountRestricted => "account_restricted",
                LegacyErrorCode.ApiKeyLimitReached => "api_key_limit_reached",
                LegacyErrorCode.ArticleNotFound => "article_not_found",
                LegacyErrorCode.DmNotPermitted => "dm_not_permitted",
                LegacyErrorCode.InvalidFormat => "invalid_format",
                LegacyErrorCode.InvalidID => "invalid_id",
                LegacyErrorCode.InvalidInput => "invalid_input",
                LegacyErrorCode.InvalidParams => "invalid_params",
                LegacyErrorCode.InvalidToolType => "invalid_tool_type",
                LegacyErrorCode.InvalidTweetID => "invalid_tweet_id",
                LegacyErrorCode.InvalidTweetUrl => "invalid_tweet_url",
                LegacyErrorCode.InvalidUserID => "invalid_user_id",
                LegacyErrorCode.InvalidUserIds => "invalid_user_ids",
                LegacyErrorCode.InvalidUsername => "invalid_username",
                LegacyErrorCode.InvalidJson => "invalid_json",
                LegacyErrorCode.InsufficientCredits => "insufficient_credits",
                LegacyErrorCode.LoginCooldown => "login_cooldown",
                LegacyErrorCode.LoginFailed => "login_failed",
                LegacyErrorCode.MediaDownloadFailed => "media_download_failed",
                LegacyErrorCode.MissingParams => "missing_params",
                LegacyErrorCode.MissingQuery => "missing_query",
                LegacyErrorCode.MonitorAlreadyExists => "monitor_already_exists",
                LegacyErrorCode.NoMedia => "no_media",
                LegacyErrorCode.NoCredits => "no_credits",
                LegacyErrorCode.NoSubscription => "no_subscription",
                LegacyErrorCode.NotFound => "not_found",
                LegacyErrorCode.PaymentFailed => "payment_failed",
                LegacyErrorCode.RateLimitExceeded => "rate_limit_exceeded",
                LegacyErrorCode.ServiceUnavailable => "service_unavailable",
                LegacyErrorCode.StyleNotFound => "style_not_found",
                LegacyErrorCode.SubscriptionInactive => "subscription_inactive",
                LegacyErrorCode.TweetNotFound => "tweet_not_found",
                LegacyErrorCode.Unauthenticated => "unauthenticated",
                LegacyErrorCode.UnsupportedField => "unsupported_field",
                LegacyErrorCode.UserNotFound => "user_not_found",
                LegacyErrorCode.BodyTooLarge => "body_too_large",
                LegacyErrorCode.CheckoutUnavailable => "checkout_unavailable",
                LegacyErrorCode.ConnectionChallengeExpired => "connection_challenge_expired",
                LegacyErrorCode.ConnectionChallengeInactive => "connection_challenge_inactive",
                LegacyErrorCode.DraftNotFound => "draft_not_found",
                LegacyErrorCode.FavoritersUnavailable => "favoriters_unavailable",
                LegacyErrorCode.Forbidden => "forbidden",
                LegacyErrorCode.GuestWalletUnavailable => "guest_wallet_unavailable",
                LegacyErrorCode.GuestWalletsDisabled => "guest_wallets_disabled",
                LegacyErrorCode.GuestWalletsUnavailable => "guest_wallets_unavailable",
                LegacyErrorCode.IdempotencyConflict => "idempotency_conflict",
                LegacyErrorCode.IdempotencyKeyConflict => "idempotency_key_conflict",
                LegacyErrorCode.InvalidCommunityID => "invalid_community_id",
                LegacyErrorCode.InvalidIdempotencyKey => "invalid_idempotency_key",
                LegacyErrorCode.InvalidListID => "invalid_list_id",
                LegacyErrorCode.InvalidPaymentAmount => "invalid_payment_amount",
                LegacyErrorCode.InvalidRange => "invalid_range",
                LegacyErrorCode.LoginRateLimited => "login_rate_limited",
                LegacyErrorCode.MissingIdempotencyKey => "missing_idempotency_key",
                LegacyErrorCode.MissingIds => "missing_ids",
                LegacyErrorCode.NoCachedStyle => "no_cached_style",
                LegacyErrorCode.PasskeyRequired => "passkey_required",
                LegacyErrorCode.RateLimited => "rate_limited",
                LegacyErrorCode.ReadRequestTimeout => "read_request_timeout",
                LegacyErrorCode.RepliesIncomplete => "replies_incomplete",
                LegacyErrorCode.SupportMediaRateLimit => "support_media_rate_limit",
                LegacyErrorCode.SupportRequestRateLimit => "support_request_rate_limit",
                LegacyErrorCode.TooManyIds => "too_many_ids",
                LegacyErrorCode.UnknownField => "unknown_field",
                LegacyErrorCode.UnsupportedMediaType => "unsupported_media_type",
                LegacyErrorCode.WebhookInactive => "webhook_inactive",
                LegacyErrorCode.WriteTrackingUnavailable => "write_tracking_unavailable",
                LegacyErrorCode.XWriteUnconfirmed => "x_write_unconfirmed",
                LegacyErrorCode.XAccountFeatureRequired => "x_account_feature_required",
                LegacyErrorCode.XAccountProtected => "x_account_protected",
                LegacyErrorCode.XAccountSuspended => "x_account_suspended",
                LegacyErrorCode.XApiRateLimited => "x_api_rate_limited",
                LegacyErrorCode.XApiUnavailable => "x_api_unavailable",
                LegacyErrorCode.XApiUnauthorized => "x_api_unauthorized",
                LegacyErrorCode.XAuthFailure => "x_auth_failure",
                LegacyErrorCode.XContentTooLong => "x_content_too_long",
                LegacyErrorCode.XDailyLimit => "x_daily_limit",
                LegacyErrorCode.XDmNotAllowed => "x_dm_not_allowed",
                LegacyErrorCode.XDuplicateAction => "x_duplicate_action",
                LegacyErrorCode.XLoginAuthFailed => "x_login_auth_failed",
                LegacyErrorCode.XLoginChallenge => "x_login_challenge",
                LegacyErrorCode.XLoginDenied => "x_login_denied",
                LegacyErrorCode.XLoginFailed => "x_login_failed",
                LegacyErrorCode.XLoginProxyError => "x_login_proxy_error",
                LegacyErrorCode.XLoginRateLimited => "x_login_rate_limited",
                LegacyErrorCode.XLoginServiceUnavailable => "x_login_service_unavailable",
                LegacyErrorCode.XLoginSuspended => "x_login_suspended",
                LegacyErrorCode.XRateLimited => "x_rate_limited",
                LegacyErrorCode.XRejected => "x_rejected",
                LegacyErrorCode.XTargetNotFound => "x_target_not_found",
                LegacyErrorCode.XTransientError => "x_transient_error",
                LegacyErrorCode.XUserLookupFailed => "x_user_lookup_failed",
                LegacyErrorCode.XWriteAmbiguous => "x_write_ambiguous",
                LegacyErrorCode.XWriteFailed => "x_write_failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<StructuredError, StructuredErrorFromRaw>))]
public sealed record class StructuredError : JsonModel
{
    public required ApiEnum<string, Code> Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Code>>("code");
        }
        init { this._rawData.Set("code", value); }
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

    public required ApiEnum<string, global::XTwitterScraper.Models.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code.Validate();
        _ = this.Message;
        this.Type.Validate();
    }

    public StructuredError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StructuredError(StructuredError structuredError)
        : base(structuredError) { }
#pragma warning restore CS8618

    public StructuredError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StructuredError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StructuredErrorFromRaw.FromRawUnchecked"/>
    public static StructuredError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StructuredErrorFromRaw : IFromRawJson<StructuredError>
{
    /// <inheritdoc/>
    public StructuredError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StructuredError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CodeConverter))]
public enum Code
{
    InternalError,
    AccountAlreadyConnected,
    AccountNeedsReauth,
    AccountNotFound,
    AccountRequired,
    AccountRestricted,
    ApiKeyLimitReached,
    ArticleNotFound,
    DmNotPermitted,
    InvalidFormat,
    InvalidID,
    InvalidInput,
    InvalidParams,
    InvalidToolType,
    InvalidTweetID,
    InvalidTweetUrl,
    InvalidUserID,
    InvalidUserIds,
    InvalidUsername,
    InvalidJson,
    InsufficientCredits,
    LoginCooldown,
    LoginFailed,
    MediaDownloadFailed,
    MissingParams,
    MissingQuery,
    MonitorAlreadyExists,
    NoMedia,
    NoCredits,
    NoSubscription,
    NotFound,
    PaymentFailed,
    RateLimitExceeded,
    ServiceUnavailable,
    StyleNotFound,
    SubscriptionInactive,
    TweetNotFound,
    Unauthenticated,
    UnsupportedField,
    UserNotFound,
    BodyTooLarge,
    CheckoutUnavailable,
    ConnectionChallengeExpired,
    ConnectionChallengeInactive,
    DraftNotFound,
    FavoritersUnavailable,
    Forbidden,
    GuestWalletUnavailable,
    GuestWalletsDisabled,
    GuestWalletsUnavailable,
    IdempotencyConflict,
    IdempotencyKeyConflict,
    InvalidCommunityID,
    InvalidIdempotencyKey,
    InvalidListID,
    InvalidPaymentAmount,
    InvalidRange,
    LoginRateLimited,
    MissingIdempotencyKey,
    MissingIds,
    NoCachedStyle,
    PasskeyRequired,
    RateLimited,
    ReadRequestTimeout,
    RepliesIncomplete,
    SupportMediaRateLimit,
    SupportRequestRateLimit,
    TooManyIds,
    UnknownField,
    UnsupportedMediaType,
    WebhookInactive,
    WriteTrackingUnavailable,
    XWriteUnconfirmed,
    XAccountFeatureRequired,
    XAccountProtected,
    XAccountSuspended,
    XApiRateLimited,
    XApiUnavailable,
    XApiUnauthorized,
    XAuthFailure,
    XContentTooLong,
    XDailyLimit,
    XDmNotAllowed,
    XDuplicateAction,
    XLoginAuthFailed,
    XLoginChallenge,
    XLoginDenied,
    XLoginFailed,
    XLoginProxyError,
    XLoginRateLimited,
    XLoginServiceUnavailable,
    XLoginSuspended,
    XRateLimited,
    XRejected,
    XTargetNotFound,
    XTransientError,
    XUserLookupFailed,
    XWriteAmbiguous,
    XWriteFailed,
}

sealed class CodeConverter : JsonConverter<Code>
{
    public override Code Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal_error" => Code.InternalError,
            "account_already_connected" => Code.AccountAlreadyConnected,
            "account_needs_reauth" => Code.AccountNeedsReauth,
            "account_not_found" => Code.AccountNotFound,
            "account_required" => Code.AccountRequired,
            "account_restricted" => Code.AccountRestricted,
            "api_key_limit_reached" => Code.ApiKeyLimitReached,
            "article_not_found" => Code.ArticleNotFound,
            "dm_not_permitted" => Code.DmNotPermitted,
            "invalid_format" => Code.InvalidFormat,
            "invalid_id" => Code.InvalidID,
            "invalid_input" => Code.InvalidInput,
            "invalid_params" => Code.InvalidParams,
            "invalid_tool_type" => Code.InvalidToolType,
            "invalid_tweet_id" => Code.InvalidTweetID,
            "invalid_tweet_url" => Code.InvalidTweetUrl,
            "invalid_user_id" => Code.InvalidUserID,
            "invalid_user_ids" => Code.InvalidUserIds,
            "invalid_username" => Code.InvalidUsername,
            "invalid_json" => Code.InvalidJson,
            "insufficient_credits" => Code.InsufficientCredits,
            "login_cooldown" => Code.LoginCooldown,
            "login_failed" => Code.LoginFailed,
            "media_download_failed" => Code.MediaDownloadFailed,
            "missing_params" => Code.MissingParams,
            "missing_query" => Code.MissingQuery,
            "monitor_already_exists" => Code.MonitorAlreadyExists,
            "no_media" => Code.NoMedia,
            "no_credits" => Code.NoCredits,
            "no_subscription" => Code.NoSubscription,
            "not_found" => Code.NotFound,
            "payment_failed" => Code.PaymentFailed,
            "rate_limit_exceeded" => Code.RateLimitExceeded,
            "service_unavailable" => Code.ServiceUnavailable,
            "style_not_found" => Code.StyleNotFound,
            "subscription_inactive" => Code.SubscriptionInactive,
            "tweet_not_found" => Code.TweetNotFound,
            "unauthenticated" => Code.Unauthenticated,
            "unsupported_field" => Code.UnsupportedField,
            "user_not_found" => Code.UserNotFound,
            "body_too_large" => Code.BodyTooLarge,
            "checkout_unavailable" => Code.CheckoutUnavailable,
            "connection_challenge_expired" => Code.ConnectionChallengeExpired,
            "connection_challenge_inactive" => Code.ConnectionChallengeInactive,
            "draft_not_found" => Code.DraftNotFound,
            "favoriters_unavailable" => Code.FavoritersUnavailable,
            "forbidden" => Code.Forbidden,
            "guest_wallet_unavailable" => Code.GuestWalletUnavailable,
            "guest_wallets_disabled" => Code.GuestWalletsDisabled,
            "guest_wallets_unavailable" => Code.GuestWalletsUnavailable,
            "idempotency_conflict" => Code.IdempotencyConflict,
            "idempotency_key_conflict" => Code.IdempotencyKeyConflict,
            "invalid_community_id" => Code.InvalidCommunityID,
            "invalid_idempotency_key" => Code.InvalidIdempotencyKey,
            "invalid_list_id" => Code.InvalidListID,
            "invalid_payment_amount" => Code.InvalidPaymentAmount,
            "invalid_range" => Code.InvalidRange,
            "login_rate_limited" => Code.LoginRateLimited,
            "missing_idempotency_key" => Code.MissingIdempotencyKey,
            "missing_ids" => Code.MissingIds,
            "no_cached_style" => Code.NoCachedStyle,
            "passkey_required" => Code.PasskeyRequired,
            "rate_limited" => Code.RateLimited,
            "read_request_timeout" => Code.ReadRequestTimeout,
            "replies_incomplete" => Code.RepliesIncomplete,
            "support_media_rate_limit" => Code.SupportMediaRateLimit,
            "support_request_rate_limit" => Code.SupportRequestRateLimit,
            "too_many_ids" => Code.TooManyIds,
            "unknown_field" => Code.UnknownField,
            "unsupported_media_type" => Code.UnsupportedMediaType,
            "webhook_inactive" => Code.WebhookInactive,
            "write_tracking_unavailable" => Code.WriteTrackingUnavailable,
            "x_write_unconfirmed" => Code.XWriteUnconfirmed,
            "x_account_feature_required" => Code.XAccountFeatureRequired,
            "x_account_protected" => Code.XAccountProtected,
            "x_account_suspended" => Code.XAccountSuspended,
            "x_api_rate_limited" => Code.XApiRateLimited,
            "x_api_unavailable" => Code.XApiUnavailable,
            "x_api_unauthorized" => Code.XApiUnauthorized,
            "x_auth_failure" => Code.XAuthFailure,
            "x_content_too_long" => Code.XContentTooLong,
            "x_daily_limit" => Code.XDailyLimit,
            "x_dm_not_allowed" => Code.XDmNotAllowed,
            "x_duplicate_action" => Code.XDuplicateAction,
            "x_login_auth_failed" => Code.XLoginAuthFailed,
            "x_login_challenge" => Code.XLoginChallenge,
            "x_login_denied" => Code.XLoginDenied,
            "x_login_failed" => Code.XLoginFailed,
            "x_login_proxy_error" => Code.XLoginProxyError,
            "x_login_rate_limited" => Code.XLoginRateLimited,
            "x_login_service_unavailable" => Code.XLoginServiceUnavailable,
            "x_login_suspended" => Code.XLoginSuspended,
            "x_rate_limited" => Code.XRateLimited,
            "x_rejected" => Code.XRejected,
            "x_target_not_found" => Code.XTargetNotFound,
            "x_transient_error" => Code.XTransientError,
            "x_user_lookup_failed" => Code.XUserLookupFailed,
            "x_write_ambiguous" => Code.XWriteAmbiguous,
            "x_write_failed" => Code.XWriteFailed,
            _ => (Code)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Code value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Code.InternalError => "internal_error",
                Code.AccountAlreadyConnected => "account_already_connected",
                Code.AccountNeedsReauth => "account_needs_reauth",
                Code.AccountNotFound => "account_not_found",
                Code.AccountRequired => "account_required",
                Code.AccountRestricted => "account_restricted",
                Code.ApiKeyLimitReached => "api_key_limit_reached",
                Code.ArticleNotFound => "article_not_found",
                Code.DmNotPermitted => "dm_not_permitted",
                Code.InvalidFormat => "invalid_format",
                Code.InvalidID => "invalid_id",
                Code.InvalidInput => "invalid_input",
                Code.InvalidParams => "invalid_params",
                Code.InvalidToolType => "invalid_tool_type",
                Code.InvalidTweetID => "invalid_tweet_id",
                Code.InvalidTweetUrl => "invalid_tweet_url",
                Code.InvalidUserID => "invalid_user_id",
                Code.InvalidUserIds => "invalid_user_ids",
                Code.InvalidUsername => "invalid_username",
                Code.InvalidJson => "invalid_json",
                Code.InsufficientCredits => "insufficient_credits",
                Code.LoginCooldown => "login_cooldown",
                Code.LoginFailed => "login_failed",
                Code.MediaDownloadFailed => "media_download_failed",
                Code.MissingParams => "missing_params",
                Code.MissingQuery => "missing_query",
                Code.MonitorAlreadyExists => "monitor_already_exists",
                Code.NoMedia => "no_media",
                Code.NoCredits => "no_credits",
                Code.NoSubscription => "no_subscription",
                Code.NotFound => "not_found",
                Code.PaymentFailed => "payment_failed",
                Code.RateLimitExceeded => "rate_limit_exceeded",
                Code.ServiceUnavailable => "service_unavailable",
                Code.StyleNotFound => "style_not_found",
                Code.SubscriptionInactive => "subscription_inactive",
                Code.TweetNotFound => "tweet_not_found",
                Code.Unauthenticated => "unauthenticated",
                Code.UnsupportedField => "unsupported_field",
                Code.UserNotFound => "user_not_found",
                Code.BodyTooLarge => "body_too_large",
                Code.CheckoutUnavailable => "checkout_unavailable",
                Code.ConnectionChallengeExpired => "connection_challenge_expired",
                Code.ConnectionChallengeInactive => "connection_challenge_inactive",
                Code.DraftNotFound => "draft_not_found",
                Code.FavoritersUnavailable => "favoriters_unavailable",
                Code.Forbidden => "forbidden",
                Code.GuestWalletUnavailable => "guest_wallet_unavailable",
                Code.GuestWalletsDisabled => "guest_wallets_disabled",
                Code.GuestWalletsUnavailable => "guest_wallets_unavailable",
                Code.IdempotencyConflict => "idempotency_conflict",
                Code.IdempotencyKeyConflict => "idempotency_key_conflict",
                Code.InvalidCommunityID => "invalid_community_id",
                Code.InvalidIdempotencyKey => "invalid_idempotency_key",
                Code.InvalidListID => "invalid_list_id",
                Code.InvalidPaymentAmount => "invalid_payment_amount",
                Code.InvalidRange => "invalid_range",
                Code.LoginRateLimited => "login_rate_limited",
                Code.MissingIdempotencyKey => "missing_idempotency_key",
                Code.MissingIds => "missing_ids",
                Code.NoCachedStyle => "no_cached_style",
                Code.PasskeyRequired => "passkey_required",
                Code.RateLimited => "rate_limited",
                Code.ReadRequestTimeout => "read_request_timeout",
                Code.RepliesIncomplete => "replies_incomplete",
                Code.SupportMediaRateLimit => "support_media_rate_limit",
                Code.SupportRequestRateLimit => "support_request_rate_limit",
                Code.TooManyIds => "too_many_ids",
                Code.UnknownField => "unknown_field",
                Code.UnsupportedMediaType => "unsupported_media_type",
                Code.WebhookInactive => "webhook_inactive",
                Code.WriteTrackingUnavailable => "write_tracking_unavailable",
                Code.XWriteUnconfirmed => "x_write_unconfirmed",
                Code.XAccountFeatureRequired => "x_account_feature_required",
                Code.XAccountProtected => "x_account_protected",
                Code.XAccountSuspended => "x_account_suspended",
                Code.XApiRateLimited => "x_api_rate_limited",
                Code.XApiUnavailable => "x_api_unavailable",
                Code.XApiUnauthorized => "x_api_unauthorized",
                Code.XAuthFailure => "x_auth_failure",
                Code.XContentTooLong => "x_content_too_long",
                Code.XDailyLimit => "x_daily_limit",
                Code.XDmNotAllowed => "x_dm_not_allowed",
                Code.XDuplicateAction => "x_duplicate_action",
                Code.XLoginAuthFailed => "x_login_auth_failed",
                Code.XLoginChallenge => "x_login_challenge",
                Code.XLoginDenied => "x_login_denied",
                Code.XLoginFailed => "x_login_failed",
                Code.XLoginProxyError => "x_login_proxy_error",
                Code.XLoginRateLimited => "x_login_rate_limited",
                Code.XLoginServiceUnavailable => "x_login_service_unavailable",
                Code.XLoginSuspended => "x_login_suspended",
                Code.XRateLimited => "x_rate_limited",
                Code.XRejected => "x_rejected",
                Code.XTargetNotFound => "x_target_not_found",
                Code.XTransientError => "x_transient_error",
                Code.XUserLookupFailed => "x_user_lookup_failed",
                Code.XWriteAmbiguous => "x_write_ambiguous",
                Code.XWriteFailed => "x_write_failed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ApiError,
    AuthenticationError,
    BillingError,
    DependencyError,
    InvalidRequestError,
    PermissionError,
    RateLimitError,
}

sealed class TypeConverter : JsonConverter<global::XTwitterScraper.Models.Type>
{
    public override global::XTwitterScraper.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_error" => global::XTwitterScraper.Models.Type.ApiError,
            "authentication_error" => global::XTwitterScraper.Models.Type.AuthenticationError,
            "billing_error" => global::XTwitterScraper.Models.Type.BillingError,
            "dependency_error" => global::XTwitterScraper.Models.Type.DependencyError,
            "invalid_request_error" => global::XTwitterScraper.Models.Type.InvalidRequestError,
            "permission_error" => global::XTwitterScraper.Models.Type.PermissionError,
            "rate_limit_error" => global::XTwitterScraper.Models.Type.RateLimitError,
            _ => (global::XTwitterScraper.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::XTwitterScraper.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::XTwitterScraper.Models.Type.ApiError => "api_error",
                global::XTwitterScraper.Models.Type.AuthenticationError => "authentication_error",
                global::XTwitterScraper.Models.Type.BillingError => "billing_error",
                global::XTwitterScraper.Models.Type.DependencyError => "dependency_error",
                global::XTwitterScraper.Models.Type.InvalidRequestError => "invalid_request_error",
                global::XTwitterScraper.Models.Type.PermissionError => "permission_error",
                global::XTwitterScraper.Models.Type.RateLimitError => "rate_limit_error",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
