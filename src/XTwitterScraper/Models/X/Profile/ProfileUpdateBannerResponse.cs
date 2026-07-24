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

namespace XTwitterScraper.Models.X.Profile;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateBannerResponse, ProfileUpdateBannerResponseFromRaw>)
)]
public sealed record class ProfileUpdateBannerResponse : JsonModel
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
    public required ProfileUpdateBannerResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateBannerResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, ProfileUpdateBannerResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateBannerResponseAction>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required ProfileUpdateBannerResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateBannerResponseBilling>("billing");
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
    public required ProfileUpdateBannerResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateBannerResponseNextAction>(
                "nextAction"
            );
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
    public required ProfileUpdateBannerResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateBannerResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required ProfileUpdateBannerResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateBannerResponseResult>("result");
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

    public required ApiEnum<string, ProfileUpdateBannerResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateBannerResponseStatus>
            >("status");
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
    public required ProfileUpdateBannerResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateBannerResponseTarget>("target");
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

    public ProfileUpdateBannerResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponse(ProfileUpdateBannerResponse profileUpdateBannerResponse)
        : base(profileUpdateBannerResponse) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseFromRaw : IFromRawJson<ProfileUpdateBannerResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateBannerResponseAccount,
        ProfileUpdateBannerResponseAccountFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseAccount : JsonModel
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

    public ProfileUpdateBannerResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseAccount(
        ProfileUpdateBannerResponseAccount profileUpdateBannerResponseAccount
    )
        : base(profileUpdateBannerResponseAccount) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseAccountFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseAccountFromRaw : IFromRawJson<ProfileUpdateBannerResponseAccount>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateBannerResponseActionConverter))]
public enum ProfileUpdateBannerResponseAction
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

sealed class ProfileUpdateBannerResponseActionConverter
    : JsonConverter<ProfileUpdateBannerResponseAction>
{
    public override ProfileUpdateBannerResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => ProfileUpdateBannerResponseAction.CreateTweet,
            "delete_tweet" => ProfileUpdateBannerResponseAction.DeleteTweet,
            "like" => ProfileUpdateBannerResponseAction.Like,
            "unlike" => ProfileUpdateBannerResponseAction.Unlike,
            "retweet" => ProfileUpdateBannerResponseAction.Retweet,
            "unretweet" => ProfileUpdateBannerResponseAction.Unretweet,
            "follow" => ProfileUpdateBannerResponseAction.Follow,
            "unfollow" => ProfileUpdateBannerResponseAction.Unfollow,
            "remove_follower" => ProfileUpdateBannerResponseAction.RemoveFollower,
            "send_dm" => ProfileUpdateBannerResponseAction.SendDm,
            "upload_media" => ProfileUpdateBannerResponseAction.UploadMedia,
            "update_profile" => ProfileUpdateBannerResponseAction.UpdateProfile,
            "update_avatar" => ProfileUpdateBannerResponseAction.UpdateAvatar,
            "update_banner" => ProfileUpdateBannerResponseAction.UpdateBanner,
            "create_community" => ProfileUpdateBannerResponseAction.CreateCommunity,
            "delete_community" => ProfileUpdateBannerResponseAction.DeleteCommunity,
            "join_community" => ProfileUpdateBannerResponseAction.JoinCommunity,
            "leave_community" => ProfileUpdateBannerResponseAction.LeaveCommunity,
            _ => (ProfileUpdateBannerResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseAction.CreateTweet => "create_tweet",
                ProfileUpdateBannerResponseAction.DeleteTweet => "delete_tweet",
                ProfileUpdateBannerResponseAction.Like => "like",
                ProfileUpdateBannerResponseAction.Unlike => "unlike",
                ProfileUpdateBannerResponseAction.Retweet => "retweet",
                ProfileUpdateBannerResponseAction.Unretweet => "unretweet",
                ProfileUpdateBannerResponseAction.Follow => "follow",
                ProfileUpdateBannerResponseAction.Unfollow => "unfollow",
                ProfileUpdateBannerResponseAction.RemoveFollower => "remove_follower",
                ProfileUpdateBannerResponseAction.SendDm => "send_dm",
                ProfileUpdateBannerResponseAction.UploadMedia => "upload_media",
                ProfileUpdateBannerResponseAction.UpdateProfile => "update_profile",
                ProfileUpdateBannerResponseAction.UpdateAvatar => "update_avatar",
                ProfileUpdateBannerResponseAction.UpdateBanner => "update_banner",
                ProfileUpdateBannerResponseAction.CreateCommunity => "create_community",
                ProfileUpdateBannerResponseAction.DeleteCommunity => "delete_community",
                ProfileUpdateBannerResponseAction.JoinCommunity => "join_community",
                ProfileUpdateBannerResponseAction.LeaveCommunity => "leave_community",
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
        ProfileUpdateBannerResponseBilling,
        ProfileUpdateBannerResponseBillingFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseBilling : JsonModel
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

    public required ApiEnum<string, ProfileUpdateBannerResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateBannerResponseBillingStatus>
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

    public ProfileUpdateBannerResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseBilling(
        ProfileUpdateBannerResponseBilling profileUpdateBannerResponseBilling
    )
        : base(profileUpdateBannerResponseBilling) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseBillingFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseBillingFromRaw : IFromRawJson<ProfileUpdateBannerResponseBilling>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateBannerResponseBillingStatusConverter))]
public enum ProfileUpdateBannerResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class ProfileUpdateBannerResponseBillingStatusConverter
    : JsonConverter<ProfileUpdateBannerResponseBillingStatus>
{
    public override ProfileUpdateBannerResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => ProfileUpdateBannerResponseBillingStatus.NotCharged,
            "pending" => ProfileUpdateBannerResponseBillingStatus.Pending,
            "charged" => ProfileUpdateBannerResponseBillingStatus.Charged,
            "charge_failed" => ProfileUpdateBannerResponseBillingStatus.ChargeFailed,
            "refunded" => ProfileUpdateBannerResponseBillingStatus.Refunded,
            _ => (ProfileUpdateBannerResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseBillingStatus.NotCharged => "not_charged",
                ProfileUpdateBannerResponseBillingStatus.Pending => "pending",
                ProfileUpdateBannerResponseBillingStatus.Charged => "charged",
                ProfileUpdateBannerResponseBillingStatus.ChargeFailed => "charge_failed",
                ProfileUpdateBannerResponseBillingStatus.Refunded => "refunded",
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
        ProfileUpdateBannerResponseNextAction,
        ProfileUpdateBannerResponseNextActionFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseNextAction : JsonModel
{
    public required ApiEnum<string, ProfileUpdateBannerResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateBannerResponseNextActionType>
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

    public ProfileUpdateBannerResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseNextAction(
        ProfileUpdateBannerResponseNextAction profileUpdateBannerResponseNextAction
    )
        : base(profileUpdateBannerResponseNextAction) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseNextActionFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseNextAction(
        ApiEnum<string, ProfileUpdateBannerResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class ProfileUpdateBannerResponseNextActionFromRaw
    : IFromRawJson<ProfileUpdateBannerResponseNextAction>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateBannerResponseNextActionTypeConverter))]
public enum ProfileUpdateBannerResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class ProfileUpdateBannerResponseNextActionTypeConverter
    : JsonConverter<ProfileUpdateBannerResponseNextActionType>
{
    public override ProfileUpdateBannerResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => ProfileUpdateBannerResponseNextActionType.Poll,
            "retry" => ProfileUpdateBannerResponseNextActionType.Retry,
            "verify_result" => ProfileUpdateBannerResponseNextActionType.VerifyResult,
            "fix_request" => ProfileUpdateBannerResponseNextActionType.FixRequest,
            _ => (ProfileUpdateBannerResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseNextActionType.Poll => "poll",
                ProfileUpdateBannerResponseNextActionType.Retry => "retry",
                ProfileUpdateBannerResponseNextActionType.VerifyResult => "verify_result",
                ProfileUpdateBannerResponseNextActionType.FixRequest => "fix_request",
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
        ProfileUpdateBannerResponseRequest,
        ProfileUpdateBannerResponseRequestFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseRequest : JsonModel
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

    public ProfileUpdateBannerResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseRequest(
        ProfileUpdateBannerResponseRequest profileUpdateBannerResponseRequest
    )
        : base(profileUpdateBannerResponseRequest) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseRequestFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseRequestFromRaw : IFromRawJson<ProfileUpdateBannerResponseRequest>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateBannerResponseResult,
        ProfileUpdateBannerResponseResultFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseResult : JsonModel
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

    public ApiEnum<string, ProfileUpdateBannerResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateBannerResponseResultType>
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

    public ProfileUpdateBannerResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseResult(
        ProfileUpdateBannerResponseResult profileUpdateBannerResponseResult
    )
        : base(profileUpdateBannerResponseResult) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseResultFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseResultFromRaw : IFromRawJson<ProfileUpdateBannerResponseResult>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateBannerResponseResultTypeConverter))]
public enum ProfileUpdateBannerResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class ProfileUpdateBannerResponseResultTypeConverter
    : JsonConverter<ProfileUpdateBannerResponseResultType>
{
    public override ProfileUpdateBannerResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => ProfileUpdateBannerResponseResultType.Tweet,
            "direct_message" => ProfileUpdateBannerResponseResultType.DirectMessage,
            "media" => ProfileUpdateBannerResponseResultType.Media,
            "community" => ProfileUpdateBannerResponseResultType.Community,
            "state_change" => ProfileUpdateBannerResponseResultType.StateChange,
            _ => (ProfileUpdateBannerResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseResultType.Tweet => "tweet",
                ProfileUpdateBannerResponseResultType.DirectMessage => "direct_message",
                ProfileUpdateBannerResponseResultType.Media => "media",
                ProfileUpdateBannerResponseResultType.Community => "community",
                ProfileUpdateBannerResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileUpdateBannerResponseStatusConverter))]
public enum ProfileUpdateBannerResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class ProfileUpdateBannerResponseStatusConverter
    : JsonConverter<ProfileUpdateBannerResponseStatus>
{
    public override ProfileUpdateBannerResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => ProfileUpdateBannerResponseStatus.Accepted,
            "dispatching" => ProfileUpdateBannerResponseStatus.Dispatching,
            "pending_confirmation" => ProfileUpdateBannerResponseStatus.PendingConfirmation,
            "success" => ProfileUpdateBannerResponseStatus.Success,
            "failed" => ProfileUpdateBannerResponseStatus.Failed,
            "expired" => ProfileUpdateBannerResponseStatus.Expired,
            _ => (ProfileUpdateBannerResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseStatus.Accepted => "accepted",
                ProfileUpdateBannerResponseStatus.Dispatching => "dispatching",
                ProfileUpdateBannerResponseStatus.PendingConfirmation => "pending_confirmation",
                ProfileUpdateBannerResponseStatus.Success => "success",
                ProfileUpdateBannerResponseStatus.Failed => "failed",
                ProfileUpdateBannerResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<
        ProfileUpdateBannerResponseTarget,
        ProfileUpdateBannerResponseTargetFromRaw
    >)
)]
public sealed record class ProfileUpdateBannerResponseTarget : JsonModel
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

    public required ApiEnum<string, ProfileUpdateBannerResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateBannerResponseTargetType>
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

    public ProfileUpdateBannerResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponseTarget(
        ProfileUpdateBannerResponseTarget profileUpdateBannerResponseTarget
    )
        : base(profileUpdateBannerResponseTarget) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseTargetFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseTargetFromRaw : IFromRawJson<ProfileUpdateBannerResponseTarget>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateBannerResponseTargetTypeConverter))]
public enum ProfileUpdateBannerResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class ProfileUpdateBannerResponseTargetTypeConverter
    : JsonConverter<ProfileUpdateBannerResponseTargetType>
{
    public override ProfileUpdateBannerResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => ProfileUpdateBannerResponseTargetType.Tweet,
            "user" => ProfileUpdateBannerResponseTargetType.User,
            "community" => ProfileUpdateBannerResponseTargetType.Community,
            _ => (ProfileUpdateBannerResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateBannerResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateBannerResponseTargetType.Tweet => "tweet",
                ProfileUpdateBannerResponseTargetType.User => "user",
                ProfileUpdateBannerResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
