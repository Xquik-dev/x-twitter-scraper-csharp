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

namespace XTwitterScraper.Models.X.Communities;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CommunityDeleteResponse, CommunityDeleteResponseFromRaw>))]
public sealed record class CommunityDeleteResponse : JsonModel
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
    public required CommunityDeleteResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityDeleteResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, CommunityDeleteResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CommunityDeleteResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required CommunityDeleteResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CommunityDeleteResponseBilling>("billing");
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
    public required CommunityDeleteResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityDeleteResponseNextAction>("nextAction");
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
    public required CommunityDeleteResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CommunityDeleteResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required CommunityDeleteResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityDeleteResponseResult>("result");
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

    public required ApiEnum<string, CommunityDeleteResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CommunityDeleteResponseStatus>>(
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
    public required CommunityDeleteResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityDeleteResponseTarget>("target");
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

    public CommunityDeleteResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponse(CommunityDeleteResponse communityDeleteResponse)
        : base(communityDeleteResponse) { }
#pragma warning restore CS8618

    public CommunityDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseFromRaw : IFromRawJson<CommunityDeleteResponse>
{
    /// <inheritdoc/>
    public CommunityDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CommunityDeleteResponseAccount,
        CommunityDeleteResponseAccountFromRaw
    >)
)]
public sealed record class CommunityDeleteResponseAccount : JsonModel
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

    public CommunityDeleteResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseAccount(
        CommunityDeleteResponseAccount communityDeleteResponseAccount
    )
        : base(communityDeleteResponseAccount) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseAccountFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseAccountFromRaw : IFromRawJson<CommunityDeleteResponseAccount>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommunityDeleteResponseActionConverter))]
public enum CommunityDeleteResponseAction
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

sealed class CommunityDeleteResponseActionConverter : JsonConverter<CommunityDeleteResponseAction>
{
    public override CommunityDeleteResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => CommunityDeleteResponseAction.CreateTweet,
            "delete_tweet" => CommunityDeleteResponseAction.DeleteTweet,
            "like" => CommunityDeleteResponseAction.Like,
            "unlike" => CommunityDeleteResponseAction.Unlike,
            "retweet" => CommunityDeleteResponseAction.Retweet,
            "unretweet" => CommunityDeleteResponseAction.Unretweet,
            "follow" => CommunityDeleteResponseAction.Follow,
            "unfollow" => CommunityDeleteResponseAction.Unfollow,
            "remove_follower" => CommunityDeleteResponseAction.RemoveFollower,
            "send_dm" => CommunityDeleteResponseAction.SendDm,
            "upload_media" => CommunityDeleteResponseAction.UploadMedia,
            "update_profile" => CommunityDeleteResponseAction.UpdateProfile,
            "update_avatar" => CommunityDeleteResponseAction.UpdateAvatar,
            "update_banner" => CommunityDeleteResponseAction.UpdateBanner,
            "create_community" => CommunityDeleteResponseAction.CreateCommunity,
            "delete_community" => CommunityDeleteResponseAction.DeleteCommunity,
            "join_community" => CommunityDeleteResponseAction.JoinCommunity,
            "leave_community" => CommunityDeleteResponseAction.LeaveCommunity,
            _ => (CommunityDeleteResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseAction.CreateTweet => "create_tweet",
                CommunityDeleteResponseAction.DeleteTweet => "delete_tweet",
                CommunityDeleteResponseAction.Like => "like",
                CommunityDeleteResponseAction.Unlike => "unlike",
                CommunityDeleteResponseAction.Retweet => "retweet",
                CommunityDeleteResponseAction.Unretweet => "unretweet",
                CommunityDeleteResponseAction.Follow => "follow",
                CommunityDeleteResponseAction.Unfollow => "unfollow",
                CommunityDeleteResponseAction.RemoveFollower => "remove_follower",
                CommunityDeleteResponseAction.SendDm => "send_dm",
                CommunityDeleteResponseAction.UploadMedia => "upload_media",
                CommunityDeleteResponseAction.UpdateProfile => "update_profile",
                CommunityDeleteResponseAction.UpdateAvatar => "update_avatar",
                CommunityDeleteResponseAction.UpdateBanner => "update_banner",
                CommunityDeleteResponseAction.CreateCommunity => "create_community",
                CommunityDeleteResponseAction.DeleteCommunity => "delete_community",
                CommunityDeleteResponseAction.JoinCommunity => "join_community",
                CommunityDeleteResponseAction.LeaveCommunity => "leave_community",
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
    typeof(JsonModelConverter<
        CommunityDeleteResponseBilling,
        CommunityDeleteResponseBillingFromRaw
    >)
)]
public sealed record class CommunityDeleteResponseBilling : JsonModel
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

    public required ApiEnum<string, CommunityDeleteResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CommunityDeleteResponseBillingStatus>
            >("status");
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

    public CommunityDeleteResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseBilling(
        CommunityDeleteResponseBilling communityDeleteResponseBilling
    )
        : base(communityDeleteResponseBilling) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseBillingFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseBillingFromRaw : IFromRawJson<CommunityDeleteResponseBilling>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommunityDeleteResponseBillingStatusConverter))]
public enum CommunityDeleteResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class CommunityDeleteResponseBillingStatusConverter
    : JsonConverter<CommunityDeleteResponseBillingStatus>
{
    public override CommunityDeleteResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => CommunityDeleteResponseBillingStatus.NotCharged,
            "pending" => CommunityDeleteResponseBillingStatus.Pending,
            "charged" => CommunityDeleteResponseBillingStatus.Charged,
            "charge_failed" => CommunityDeleteResponseBillingStatus.ChargeFailed,
            "refunded" => CommunityDeleteResponseBillingStatus.Refunded,
            _ => (CommunityDeleteResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseBillingStatus.NotCharged => "not_charged",
                CommunityDeleteResponseBillingStatus.Pending => "pending",
                CommunityDeleteResponseBillingStatus.Charged => "charged",
                CommunityDeleteResponseBillingStatus.ChargeFailed => "charge_failed",
                CommunityDeleteResponseBillingStatus.Refunded => "refunded",
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
    typeof(JsonModelConverter<
        CommunityDeleteResponseNextAction,
        CommunityDeleteResponseNextActionFromRaw
    >)
)]
public sealed record class CommunityDeleteResponseNextAction : JsonModel
{
    public required ApiEnum<string, CommunityDeleteResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CommunityDeleteResponseNextActionType>
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

    public CommunityDeleteResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseNextAction(
        CommunityDeleteResponseNextAction communityDeleteResponseNextAction
    )
        : base(communityDeleteResponseNextAction) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseNextActionFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CommunityDeleteResponseNextAction(
        ApiEnum<string, CommunityDeleteResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class CommunityDeleteResponseNextActionFromRaw : IFromRawJson<CommunityDeleteResponseNextAction>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommunityDeleteResponseNextActionTypeConverter))]
public enum CommunityDeleteResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class CommunityDeleteResponseNextActionTypeConverter
    : JsonConverter<CommunityDeleteResponseNextActionType>
{
    public override CommunityDeleteResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => CommunityDeleteResponseNextActionType.Poll,
            "retry" => CommunityDeleteResponseNextActionType.Retry,
            "verify_result" => CommunityDeleteResponseNextActionType.VerifyResult,
            "fix_request" => CommunityDeleteResponseNextActionType.FixRequest,
            _ => (CommunityDeleteResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseNextActionType.Poll => "poll",
                CommunityDeleteResponseNextActionType.Retry => "retry",
                CommunityDeleteResponseNextActionType.VerifyResult => "verify_result",
                CommunityDeleteResponseNextActionType.FixRequest => "fix_request",
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
    typeof(JsonModelConverter<
        CommunityDeleteResponseRequest,
        CommunityDeleteResponseRequestFromRaw
    >)
)]
public sealed record class CommunityDeleteResponseRequest : JsonModel
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

    public CommunityDeleteResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseRequest(
        CommunityDeleteResponseRequest communityDeleteResponseRequest
    )
        : base(communityDeleteResponseRequest) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseRequestFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseRequestFromRaw : IFromRawJson<CommunityDeleteResponseRequest>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CommunityDeleteResponseResult, CommunityDeleteResponseResultFromRaw>)
)]
public sealed record class CommunityDeleteResponseResult : JsonModel
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

    public ApiEnum<string, CommunityDeleteResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CommunityDeleteResponseResultType>
            >("type");
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

    public CommunityDeleteResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseResult(
        CommunityDeleteResponseResult communityDeleteResponseResult
    )
        : base(communityDeleteResponseResult) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseResultFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseResultFromRaw : IFromRawJson<CommunityDeleteResponseResult>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommunityDeleteResponseResultTypeConverter))]
public enum CommunityDeleteResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class CommunityDeleteResponseResultTypeConverter
    : JsonConverter<CommunityDeleteResponseResultType>
{
    public override CommunityDeleteResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => CommunityDeleteResponseResultType.Tweet,
            "direct_message" => CommunityDeleteResponseResultType.DirectMessage,
            "media" => CommunityDeleteResponseResultType.Media,
            "community" => CommunityDeleteResponseResultType.Community,
            "state_change" => CommunityDeleteResponseResultType.StateChange,
            _ => (CommunityDeleteResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseResultType.Tweet => "tweet",
                CommunityDeleteResponseResultType.DirectMessage => "direct_message",
                CommunityDeleteResponseResultType.Media => "media",
                CommunityDeleteResponseResultType.Community => "community",
                CommunityDeleteResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CommunityDeleteResponseStatusConverter))]
public enum CommunityDeleteResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class CommunityDeleteResponseStatusConverter : JsonConverter<CommunityDeleteResponseStatus>
{
    public override CommunityDeleteResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => CommunityDeleteResponseStatus.Accepted,
            "dispatching" => CommunityDeleteResponseStatus.Dispatching,
            "pending_confirmation" => CommunityDeleteResponseStatus.PendingConfirmation,
            "success" => CommunityDeleteResponseStatus.Success,
            "failed" => CommunityDeleteResponseStatus.Failed,
            "expired" => CommunityDeleteResponseStatus.Expired,
            _ => (CommunityDeleteResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseStatus.Accepted => "accepted",
                CommunityDeleteResponseStatus.Dispatching => "dispatching",
                CommunityDeleteResponseStatus.PendingConfirmation => "pending_confirmation",
                CommunityDeleteResponseStatus.Success => "success",
                CommunityDeleteResponseStatus.Failed => "failed",
                CommunityDeleteResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<CommunityDeleteResponseTarget, CommunityDeleteResponseTargetFromRaw>)
)]
public sealed record class CommunityDeleteResponseTarget : JsonModel
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

    public required ApiEnum<string, CommunityDeleteResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CommunityDeleteResponseTargetType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public CommunityDeleteResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityDeleteResponseTarget(
        CommunityDeleteResponseTarget communityDeleteResponseTarget
    )
        : base(communityDeleteResponseTarget) { }
#pragma warning restore CS8618

    public CommunityDeleteResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityDeleteResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityDeleteResponseTargetFromRaw.FromRawUnchecked"/>
    public static CommunityDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityDeleteResponseTargetFromRaw : IFromRawJson<CommunityDeleteResponseTarget>
{
    /// <inheritdoc/>
    public CommunityDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityDeleteResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommunityDeleteResponseTargetTypeConverter))]
public enum CommunityDeleteResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class CommunityDeleteResponseTargetTypeConverter
    : JsonConverter<CommunityDeleteResponseTargetType>
{
    public override CommunityDeleteResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => CommunityDeleteResponseTargetType.Tweet,
            "user" => CommunityDeleteResponseTargetType.User,
            "community" => CommunityDeleteResponseTargetType.Community,
            _ => (CommunityDeleteResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommunityDeleteResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CommunityDeleteResponseTargetType.Tweet => "tweet",
                CommunityDeleteResponseTargetType.User => "user",
                CommunityDeleteResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
