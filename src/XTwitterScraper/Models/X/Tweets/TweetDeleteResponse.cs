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

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetDeleteResponse, TweetDeleteResponseFromRaw>))]
public sealed record class TweetDeleteResponse : JsonModel
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

    /// <summary>
    /// Connected account selected for the write.
    /// </summary>
    public required TweetDeleteResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDeleteResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, TweetDeleteResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetDeleteResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required TweetDeleteResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetDeleteResponseBilling>("billing");
        }
        init { this._rawData.Set("billing", value); }
    }

    public required bool Charged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("charged");
        }
        init { this._rawData.Set("charged", value); }
    }

    public required string ChargedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargedCredits");
        }
        init { this._rawData.Set("chargedCredits", value); }
    }

    /// <summary>
    /// Exact follow-up an API client or agent should perform.
    /// </summary>
    public required TweetDeleteResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDeleteResponseNextAction>("nextAction");
        }
        init { this._rawData.Set("nextAction", value); }
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

    public required long? PollAfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pollAfterMs");
        }
        init { this._rawData.Set("pollAfterMs", value); }
    }

    /// <summary>
    /// Stable fingerprint and sanitized payload for replay checks.
    /// </summary>
    public required TweetDeleteResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetDeleteResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required TweetDeleteResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDeleteResponseResult>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// True only when a new attempt can reasonably succeed.
    /// </summary>
    public required bool Retryable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("retryable");
        }
        init { this._rawData.Set("retryable", value); }
    }

    /// <summary>
    /// True only when no write was dispatched and a new idempotency key may be used.
    /// </summary>
    public required bool SafeToRetry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("safeToRetry");
        }
        init { this._rawData.Set("safeToRetry", value); }
    }

    public required bool SendDispatched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("sendDispatched");
        }
        init { this._rawData.Set("sendDispatched", value); }
    }

    public required ApiEnum<string, TweetDeleteResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetDeleteResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statusUrl");
        }
        init { this._rawData.Set("statusUrl", value); }
    }

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Existing X resource targeted by the write, when applicable.
    /// </summary>
    public required TweetDeleteResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetDeleteResponseTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    public required string? TargetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("targetId");
        }
        init { this._rawData.Set("targetId", value); }
    }

    public required bool Terminal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("terminal");
        }
        init { this._rawData.Set("terminal", value); }
    }

    public required string WriteActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("writeActionId");
        }
        init { this._rawData.Set("writeActionId", value); }
    }

    /// <summary>
    /// Compatibility field for a confirmed community ID.
    /// </summary>
    public string? CommunityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityId", value);
        }
    }

    /// <summary>
    /// Confirmed community name when available.
    /// </summary>
    public string? CommunityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityName", value);
        }
    }

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completedAt", value);
        }
    }

    public long? ConfirmationAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("confirmationAttempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmationAttempts", value);
        }
    }

    public System::DateTimeOffset? ConfirmationCheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("confirmationCheckedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmationCheckedAt", value);
        }
    }

    public System::DateTimeOffset? ConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("confirmedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmedAt", value);
        }
    }

    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Structured recovery context for a failed write.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("details");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "details",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Deadline for resolving a non-terminal write. This is not the Idempotency-Key
    /// retention deadline.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiresAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresAt", value);
        }
    }

    public bool? Idempotent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("idempotent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("idempotent", value);
        }
    }

    /// <summary>
    /// Media count, kind, size, and billing details when used.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("media");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "media",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Compatibility field for a confirmed media upload ID.
    /// </summary>
    public string? MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaId", value);
        }
    }

    /// <summary>
    /// Public media URL when the upload creates one.
    /// </summary>
    public string? MediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaUrl", value);
        }
    }

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
    /// Compatibility field for a confirmed direct message ID.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messageId", value);
        }
    }

    public string? RequestHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("requestHash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requestHash", value);
        }
    }

    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("requestId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requestId", value);
        }
    }

    /// <summary>
    /// Compatibility result ID for other write actions.
    /// </summary>
    public string? ResultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resultId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resultId", value);
        }
    }

    /// <summary>
    /// Dispatch timestamp when the write reached execution.
    /// </summary>
    public System::DateTimeOffset? SendDispatchedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("sendDispatchedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sendDispatchedAt", value);
        }
    }

    /// <summary>
    /// Compatibility field for a confirmed tweet result ID.
    /// </summary>
    public string? TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tweetId", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Account?.Validate();
        this.Action.Validate();
        this.Billing.Validate();
        _ = this.Charged;
        _ = this.ChargedCredits;
        this.NextAction?.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Object,
                JsonSerializer.SerializeToElement("x_write_action")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.PollAfterMs;
        this.Request.Validate();
        this.Result?.Validate();
        _ = this.Retryable;
        _ = this.SafeToRetry;
        _ = this.SendDispatched;
        this.Status.Validate();
        _ = this.StatusUrl;
        _ = this.Success;
        this.Target?.Validate();
        _ = this.TargetID;
        _ = this.Terminal;
        _ = this.WriteActionID;
        _ = this.CommunityID;
        _ = this.CommunityName;
        _ = this.CompletedAt;
        _ = this.ConfirmationAttempts;
        _ = this.ConfirmationCheckedAt;
        _ = this.ConfirmedAt;
        _ = this.CreatedAt;
        _ = this.Details;
        _ = this.Error;
        _ = this.ExpiresAt;
        _ = this.Idempotent;
        _ = this.Media;
        _ = this.MediaID;
        _ = this.MediaUrl;
        _ = this.Message;
        _ = this.MessageID;
        _ = this.RequestHash;
        _ = this.RequestID;
        _ = this.ResultID;
        _ = this.SendDispatchedAt;
        _ = this.TweetID;
        _ = this.UpdatedAt;
    }

    public TweetDeleteResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponse(TweetDeleteResponse tweetDeleteResponse)
        : base(tweetDeleteResponse) { }
#pragma warning restore CS8618

    public TweetDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseFromRaw : IFromRawJson<TweetDeleteResponse>
{
    /// <inheritdoc/>
    public TweetDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseAccount, TweetDeleteResponseAccountFromRaw>)
)]
public sealed record class TweetDeleteResponseAccount : JsonModel
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
        _ = this.Username;
    }

    public TweetDeleteResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseAccount(TweetDeleteResponseAccount tweetDeleteResponseAccount)
        : base(tweetDeleteResponseAccount) { }
#pragma warning restore CS8618

    public TweetDeleteResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseAccountFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseAccountFromRaw : IFromRawJson<TweetDeleteResponseAccount>
{
    /// <inheritdoc/>
    public TweetDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDeleteResponseActionConverter))]
public enum TweetDeleteResponseAction
{
    CreateTweet,
    DeleteTweet,
    Like,
    Unlike,
    Retweet,
    Unretweet,
    Follow,
    Unfollow,
    RemoveFollower,
    SendDm,
    UploadMedia,
    UpdateProfile,
    UpdateAvatar,
    UpdateBanner,
    CreateCommunity,
    DeleteCommunity,
    JoinCommunity,
    LeaveCommunity,
}

sealed class TweetDeleteResponseActionConverter : JsonConverter<TweetDeleteResponseAction>
{
    public override TweetDeleteResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => TweetDeleteResponseAction.CreateTweet,
            "delete_tweet" => TweetDeleteResponseAction.DeleteTweet,
            "like" => TweetDeleteResponseAction.Like,
            "unlike" => TweetDeleteResponseAction.Unlike,
            "retweet" => TweetDeleteResponseAction.Retweet,
            "unretweet" => TweetDeleteResponseAction.Unretweet,
            "follow" => TweetDeleteResponseAction.Follow,
            "unfollow" => TweetDeleteResponseAction.Unfollow,
            "remove_follower" => TweetDeleteResponseAction.RemoveFollower,
            "send_dm" => TweetDeleteResponseAction.SendDm,
            "upload_media" => TweetDeleteResponseAction.UploadMedia,
            "update_profile" => TweetDeleteResponseAction.UpdateProfile,
            "update_avatar" => TweetDeleteResponseAction.UpdateAvatar,
            "update_banner" => TweetDeleteResponseAction.UpdateBanner,
            "create_community" => TweetDeleteResponseAction.CreateCommunity,
            "delete_community" => TweetDeleteResponseAction.DeleteCommunity,
            "join_community" => TweetDeleteResponseAction.JoinCommunity,
            "leave_community" => TweetDeleteResponseAction.LeaveCommunity,
            _ => (TweetDeleteResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseAction.CreateTweet => "create_tweet",
                TweetDeleteResponseAction.DeleteTweet => "delete_tweet",
                TweetDeleteResponseAction.Like => "like",
                TweetDeleteResponseAction.Unlike => "unlike",
                TweetDeleteResponseAction.Retweet => "retweet",
                TweetDeleteResponseAction.Unretweet => "unretweet",
                TweetDeleteResponseAction.Follow => "follow",
                TweetDeleteResponseAction.Unfollow => "unfollow",
                TweetDeleteResponseAction.RemoveFollower => "remove_follower",
                TweetDeleteResponseAction.SendDm => "send_dm",
                TweetDeleteResponseAction.UploadMedia => "upload_media",
                TweetDeleteResponseAction.UpdateProfile => "update_profile",
                TweetDeleteResponseAction.UpdateAvatar => "update_avatar",
                TweetDeleteResponseAction.UpdateBanner => "update_banner",
                TweetDeleteResponseAction.CreateCommunity => "create_community",
                TweetDeleteResponseAction.DeleteCommunity => "delete_community",
                TweetDeleteResponseAction.JoinCommunity => "join_community",
                TweetDeleteResponseAction.LeaveCommunity => "leave_community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// plannedCredits is the approved maximum. chargedCredits comes from the settled
/// credit ledger. Pending or failed writes are not charged.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseBilling, TweetDeleteResponseBillingFromRaw>)
)]
public sealed record class TweetDeleteResponseBilling : JsonModel
{
    public required bool Charged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("charged");
        }
        init { this._rawData.Set("charged", value); }
    }

    public required string ChargedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargedCredits");
        }
        init { this._rawData.Set("chargedCredits", value); }
    }

    public required string PlannedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plannedCredits");
        }
        init { this._rawData.Set("plannedCredits", value); }
    }

    public required ApiEnum<string, TweetDeleteResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetDeleteResponseBillingStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Charged;
        _ = this.ChargedCredits;
        _ = this.PlannedCredits;
        this.Status.Validate();
    }

    public TweetDeleteResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseBilling(TweetDeleteResponseBilling tweetDeleteResponseBilling)
        : base(tweetDeleteResponseBilling) { }
#pragma warning restore CS8618

    public TweetDeleteResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseBillingFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseBillingFromRaw : IFromRawJson<TweetDeleteResponseBilling>
{
    /// <inheritdoc/>
    public TweetDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDeleteResponseBillingStatusConverter))]
public enum TweetDeleteResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class TweetDeleteResponseBillingStatusConverter
    : JsonConverter<TweetDeleteResponseBillingStatus>
{
    public override TweetDeleteResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => TweetDeleteResponseBillingStatus.NotCharged,
            "pending" => TweetDeleteResponseBillingStatus.Pending,
            "charged" => TweetDeleteResponseBillingStatus.Charged,
            "charge_failed" => TweetDeleteResponseBillingStatus.ChargeFailed,
            "refunded" => TweetDeleteResponseBillingStatus.Refunded,
            _ => (TweetDeleteResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseBillingStatus.NotCharged => "not_charged",
                TweetDeleteResponseBillingStatus.Pending => "pending",
                TweetDeleteResponseBillingStatus.Charged => "charged",
                TweetDeleteResponseBillingStatus.ChargeFailed => "charge_failed",
                TweetDeleteResponseBillingStatus.Refunded => "refunded",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Exact follow-up an API client or agent should perform.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseNextAction, TweetDeleteResponseNextActionFromRaw>)
)]
public sealed record class TweetDeleteResponseNextAction : JsonModel
{
    public required ApiEnum<string, TweetDeleteResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetDeleteResponseNextActionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public long? AfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("afterMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("afterMs", value);
        }
    }

    public bool? RequiresNewIdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("requiresNewIdempotencyKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requiresNewIdempotencyKey", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.AfterMs;
        _ = this.RequiresNewIdempotencyKey;
        _ = this.Url;
    }

    public TweetDeleteResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseNextAction(
        TweetDeleteResponseNextAction tweetDeleteResponseNextAction
    )
        : base(tweetDeleteResponseNextAction) { }
#pragma warning restore CS8618

    public TweetDeleteResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseNextActionFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TweetDeleteResponseNextAction(ApiEnum<string, TweetDeleteResponseNextActionType> type)
        : this()
    {
        this.Type = type;
    }
}

class TweetDeleteResponseNextActionFromRaw : IFromRawJson<TweetDeleteResponseNextAction>
{
    /// <inheritdoc/>
    public TweetDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDeleteResponseNextActionTypeConverter))]
public enum TweetDeleteResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class TweetDeleteResponseNextActionTypeConverter
    : JsonConverter<TweetDeleteResponseNextActionType>
{
    public override TweetDeleteResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => TweetDeleteResponseNextActionType.Poll,
            "retry" => TweetDeleteResponseNextActionType.Retry,
            "verify_result" => TweetDeleteResponseNextActionType.VerifyResult,
            "fix_request" => TweetDeleteResponseNextActionType.FixRequest,
            _ => (TweetDeleteResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseNextActionType.Poll => "poll",
                TweetDeleteResponseNextActionType.Retry => "retry",
                TweetDeleteResponseNextActionType.VerifyResult => "verify_result",
                TweetDeleteResponseNextActionType.FixRequest => "fix_request",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Stable fingerprint and sanitized payload for replay checks.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseRequest, TweetDeleteResponseRequestFromRaw>)
)]
public sealed record class TweetDeleteResponseRequest : JsonModel
{
    /// <summary>
    /// Stable hash of account, action, target, and payload.
    /// </summary>
    public required string? Hash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash");
        }
        init { this._rawData.Set("hash", value); }
    }

    /// <summary>
    /// Exact sanitized payload dispatched for this action.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? Payload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("payload");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hash;
        _ = this.Payload;
    }

    public TweetDeleteResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseRequest(TweetDeleteResponseRequest tweetDeleteResponseRequest)
        : base(tweetDeleteResponseRequest) { }
#pragma warning restore CS8618

    public TweetDeleteResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseRequestFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseRequestFromRaw : IFromRawJson<TweetDeleteResponseRequest>
{
    /// <inheritdoc/>
    public TweetDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseResult, TweetDeleteResponseResultFromRaw>)
)]
public sealed record class TweetDeleteResponseResult : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    public ApiEnum<string, TweetDeleteResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TweetDeleteResponseResultType>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.State;
        this.Type?.Validate();
    }

    public TweetDeleteResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseResult(TweetDeleteResponseResult tweetDeleteResponseResult)
        : base(tweetDeleteResponseResult) { }
#pragma warning restore CS8618

    public TweetDeleteResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseResultFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseResultFromRaw : IFromRawJson<TweetDeleteResponseResult>
{
    /// <inheritdoc/>
    public TweetDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDeleteResponseResultTypeConverter))]
public enum TweetDeleteResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class TweetDeleteResponseResultTypeConverter : JsonConverter<TweetDeleteResponseResultType>
{
    public override TweetDeleteResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => TweetDeleteResponseResultType.Tweet,
            "direct_message" => TweetDeleteResponseResultType.DirectMessage,
            "media" => TweetDeleteResponseResultType.Media,
            "community" => TweetDeleteResponseResultType.Community,
            "state_change" => TweetDeleteResponseResultType.StateChange,
            _ => (TweetDeleteResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseResultType.Tweet => "tweet",
                TweetDeleteResponseResultType.DirectMessage => "direct_message",
                TweetDeleteResponseResultType.Media => "media",
                TweetDeleteResponseResultType.Community => "community",
                TweetDeleteResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetDeleteResponseStatusConverter))]
public enum TweetDeleteResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class TweetDeleteResponseStatusConverter : JsonConverter<TweetDeleteResponseStatus>
{
    public override TweetDeleteResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => TweetDeleteResponseStatus.Accepted,
            "dispatching" => TweetDeleteResponseStatus.Dispatching,
            "pending_confirmation" => TweetDeleteResponseStatus.PendingConfirmation,
            "success" => TweetDeleteResponseStatus.Success,
            "failed" => TweetDeleteResponseStatus.Failed,
            "expired" => TweetDeleteResponseStatus.Expired,
            _ => (TweetDeleteResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseStatus.Accepted => "accepted",
                TweetDeleteResponseStatus.Dispatching => "dispatching",
                TweetDeleteResponseStatus.PendingConfirmation => "pending_confirmation",
                TweetDeleteResponseStatus.Success => "success",
                TweetDeleteResponseStatus.Failed => "failed",
                TweetDeleteResponseStatus.Expired => "expired",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Existing X resource targeted by the write, when applicable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetDeleteResponseTarget, TweetDeleteResponseTargetFromRaw>)
)]
public sealed record class TweetDeleteResponseTarget : JsonModel
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

    public required ApiEnum<string, TweetDeleteResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetDeleteResponseTargetType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public TweetDeleteResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponseTarget(TweetDeleteResponseTarget tweetDeleteResponseTarget)
        : base(tweetDeleteResponseTarget) { }
#pragma warning restore CS8618

    public TweetDeleteResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseTargetFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseTargetFromRaw : IFromRawJson<TweetDeleteResponseTarget>
{
    /// <inheritdoc/>
    public TweetDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetDeleteResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetDeleteResponseTargetTypeConverter))]
public enum TweetDeleteResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class TweetDeleteResponseTargetTypeConverter : JsonConverter<TweetDeleteResponseTargetType>
{
    public override TweetDeleteResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => TweetDeleteResponseTargetType.Tweet,
            "user" => TweetDeleteResponseTargetType.User,
            "community" => TweetDeleteResponseTargetType.Community,
            _ => (TweetDeleteResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetDeleteResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetDeleteResponseTargetType.Tweet => "tweet",
                TweetDeleteResponseTargetType.User => "user",
                TweetDeleteResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
