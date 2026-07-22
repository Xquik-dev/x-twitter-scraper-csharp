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
    typeof(JsonModelConverter<ProfileUpdateAvatarResponse, ProfileUpdateAvatarResponseFromRaw>)
)]
public sealed record class ProfileUpdateAvatarResponse : JsonModel
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
    public required ProfileUpdateAvatarResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateAvatarResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, ProfileUpdateAvatarResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateAvatarResponseAction>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required ProfileUpdateAvatarResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateAvatarResponseBilling>("billing");
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
    public required ProfileUpdateAvatarResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateAvatarResponseNextAction>(
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
    public required ProfileUpdateAvatarResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileUpdateAvatarResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required ProfileUpdateAvatarResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateAvatarResponseResult>("result");
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

    public required ApiEnum<string, ProfileUpdateAvatarResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateAvatarResponseStatus>
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
    public required ProfileUpdateAvatarResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProfileUpdateAvatarResponseTarget>("target");
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

    public ProfileUpdateAvatarResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponse(ProfileUpdateAvatarResponse profileUpdateAvatarResponse)
        : base(profileUpdateAvatarResponse) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseFromRaw : IFromRawJson<ProfileUpdateAvatarResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateAvatarResponseAccount,
        ProfileUpdateAvatarResponseAccountFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseAccount : JsonModel
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

    public ProfileUpdateAvatarResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseAccount(
        ProfileUpdateAvatarResponseAccount profileUpdateAvatarResponseAccount
    )
        : base(profileUpdateAvatarResponseAccount) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseAccountFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseAccountFromRaw : IFromRawJson<ProfileUpdateAvatarResponseAccount>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseActionConverter))]
public enum ProfileUpdateAvatarResponseAction
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

sealed class ProfileUpdateAvatarResponseActionConverter
    : JsonConverter<ProfileUpdateAvatarResponseAction>
{
    public override ProfileUpdateAvatarResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => ProfileUpdateAvatarResponseAction.CreateTweet,
            "delete_tweet" => ProfileUpdateAvatarResponseAction.DeleteTweet,
            "like" => ProfileUpdateAvatarResponseAction.Like,
            "unlike" => ProfileUpdateAvatarResponseAction.Unlike,
            "retweet" => ProfileUpdateAvatarResponseAction.Retweet,
            "unretweet" => ProfileUpdateAvatarResponseAction.Unretweet,
            "follow" => ProfileUpdateAvatarResponseAction.Follow,
            "unfollow" => ProfileUpdateAvatarResponseAction.Unfollow,
            "remove_follower" => ProfileUpdateAvatarResponseAction.RemoveFollower,
            "send_dm" => ProfileUpdateAvatarResponseAction.SendDm,
            "upload_media" => ProfileUpdateAvatarResponseAction.UploadMedia,
            "update_profile" => ProfileUpdateAvatarResponseAction.UpdateProfile,
            "update_avatar" => ProfileUpdateAvatarResponseAction.UpdateAvatar,
            "update_banner" => ProfileUpdateAvatarResponseAction.UpdateBanner,
            "create_community" => ProfileUpdateAvatarResponseAction.CreateCommunity,
            "delete_community" => ProfileUpdateAvatarResponseAction.DeleteCommunity,
            "join_community" => ProfileUpdateAvatarResponseAction.JoinCommunity,
            "leave_community" => ProfileUpdateAvatarResponseAction.LeaveCommunity,
            _ => (ProfileUpdateAvatarResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseAction.CreateTweet => "create_tweet",
                ProfileUpdateAvatarResponseAction.DeleteTweet => "delete_tweet",
                ProfileUpdateAvatarResponseAction.Like => "like",
                ProfileUpdateAvatarResponseAction.Unlike => "unlike",
                ProfileUpdateAvatarResponseAction.Retweet => "retweet",
                ProfileUpdateAvatarResponseAction.Unretweet => "unretweet",
                ProfileUpdateAvatarResponseAction.Follow => "follow",
                ProfileUpdateAvatarResponseAction.Unfollow => "unfollow",
                ProfileUpdateAvatarResponseAction.RemoveFollower => "remove_follower",
                ProfileUpdateAvatarResponseAction.SendDm => "send_dm",
                ProfileUpdateAvatarResponseAction.UploadMedia => "upload_media",
                ProfileUpdateAvatarResponseAction.UpdateProfile => "update_profile",
                ProfileUpdateAvatarResponseAction.UpdateAvatar => "update_avatar",
                ProfileUpdateAvatarResponseAction.UpdateBanner => "update_banner",
                ProfileUpdateAvatarResponseAction.CreateCommunity => "create_community",
                ProfileUpdateAvatarResponseAction.DeleteCommunity => "delete_community",
                ProfileUpdateAvatarResponseAction.JoinCommunity => "join_community",
                ProfileUpdateAvatarResponseAction.LeaveCommunity => "leave_community",
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
        ProfileUpdateAvatarResponseBilling,
        ProfileUpdateAvatarResponseBillingFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseBilling : JsonModel
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

    public required ApiEnum<string, ProfileUpdateAvatarResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateAvatarResponseBillingStatus>
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

    public ProfileUpdateAvatarResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseBilling(
        ProfileUpdateAvatarResponseBilling profileUpdateAvatarResponseBilling
    )
        : base(profileUpdateAvatarResponseBilling) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseBillingFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseBillingFromRaw : IFromRawJson<ProfileUpdateAvatarResponseBilling>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseBillingStatusConverter))]
public enum ProfileUpdateAvatarResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class ProfileUpdateAvatarResponseBillingStatusConverter
    : JsonConverter<ProfileUpdateAvatarResponseBillingStatus>
{
    public override ProfileUpdateAvatarResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => ProfileUpdateAvatarResponseBillingStatus.NotCharged,
            "pending" => ProfileUpdateAvatarResponseBillingStatus.Pending,
            "charged" => ProfileUpdateAvatarResponseBillingStatus.Charged,
            "charge_failed" => ProfileUpdateAvatarResponseBillingStatus.ChargeFailed,
            "refunded" => ProfileUpdateAvatarResponseBillingStatus.Refunded,
            _ => (ProfileUpdateAvatarResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseBillingStatus.NotCharged => "not_charged",
                ProfileUpdateAvatarResponseBillingStatus.Pending => "pending",
                ProfileUpdateAvatarResponseBillingStatus.Charged => "charged",
                ProfileUpdateAvatarResponseBillingStatus.ChargeFailed => "charge_failed",
                ProfileUpdateAvatarResponseBillingStatus.Refunded => "refunded",
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
        ProfileUpdateAvatarResponseNextAction,
        ProfileUpdateAvatarResponseNextActionFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseNextAction : JsonModel
{
    public required ApiEnum<string, ProfileUpdateAvatarResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateAvatarResponseNextActionType>
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

    public ProfileUpdateAvatarResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseNextAction(
        ProfileUpdateAvatarResponseNextAction profileUpdateAvatarResponseNextAction
    )
        : base(profileUpdateAvatarResponseNextAction) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseNextActionFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseNextAction(
        ApiEnum<string, ProfileUpdateAvatarResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class ProfileUpdateAvatarResponseNextActionFromRaw
    : IFromRawJson<ProfileUpdateAvatarResponseNextAction>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseNextActionTypeConverter))]
public enum ProfileUpdateAvatarResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class ProfileUpdateAvatarResponseNextActionTypeConverter
    : JsonConverter<ProfileUpdateAvatarResponseNextActionType>
{
    public override ProfileUpdateAvatarResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => ProfileUpdateAvatarResponseNextActionType.Poll,
            "retry" => ProfileUpdateAvatarResponseNextActionType.Retry,
            "verify_result" => ProfileUpdateAvatarResponseNextActionType.VerifyResult,
            "fix_request" => ProfileUpdateAvatarResponseNextActionType.FixRequest,
            _ => (ProfileUpdateAvatarResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseNextActionType.Poll => "poll",
                ProfileUpdateAvatarResponseNextActionType.Retry => "retry",
                ProfileUpdateAvatarResponseNextActionType.VerifyResult => "verify_result",
                ProfileUpdateAvatarResponseNextActionType.FixRequest => "fix_request",
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
        ProfileUpdateAvatarResponseRequest,
        ProfileUpdateAvatarResponseRequestFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseRequest : JsonModel
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

    public ProfileUpdateAvatarResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseRequest(
        ProfileUpdateAvatarResponseRequest profileUpdateAvatarResponseRequest
    )
        : base(profileUpdateAvatarResponseRequest) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseRequestFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseRequestFromRaw : IFromRawJson<ProfileUpdateAvatarResponseRequest>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProfileUpdateAvatarResponseResult,
        ProfileUpdateAvatarResponseResultFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseResult : JsonModel
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

    public ApiEnum<string, ProfileUpdateAvatarResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ProfileUpdateAvatarResponseResultType>
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

    public ProfileUpdateAvatarResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseResult(
        ProfileUpdateAvatarResponseResult profileUpdateAvatarResponseResult
    )
        : base(profileUpdateAvatarResponseResult) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseResultFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseResultFromRaw : IFromRawJson<ProfileUpdateAvatarResponseResult>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseResultTypeConverter))]
public enum ProfileUpdateAvatarResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class ProfileUpdateAvatarResponseResultTypeConverter
    : JsonConverter<ProfileUpdateAvatarResponseResultType>
{
    public override ProfileUpdateAvatarResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => ProfileUpdateAvatarResponseResultType.Tweet,
            "direct_message" => ProfileUpdateAvatarResponseResultType.DirectMessage,
            "media" => ProfileUpdateAvatarResponseResultType.Media,
            "community" => ProfileUpdateAvatarResponseResultType.Community,
            "state_change" => ProfileUpdateAvatarResponseResultType.StateChange,
            _ => (ProfileUpdateAvatarResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseResultType.Tweet => "tweet",
                ProfileUpdateAvatarResponseResultType.DirectMessage => "direct_message",
                ProfileUpdateAvatarResponseResultType.Media => "media",
                ProfileUpdateAvatarResponseResultType.Community => "community",
                ProfileUpdateAvatarResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseStatusConverter))]
public enum ProfileUpdateAvatarResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class ProfileUpdateAvatarResponseStatusConverter
    : JsonConverter<ProfileUpdateAvatarResponseStatus>
{
    public override ProfileUpdateAvatarResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => ProfileUpdateAvatarResponseStatus.Accepted,
            "dispatching" => ProfileUpdateAvatarResponseStatus.Dispatching,
            "pending_confirmation" => ProfileUpdateAvatarResponseStatus.PendingConfirmation,
            "success" => ProfileUpdateAvatarResponseStatus.Success,
            "failed" => ProfileUpdateAvatarResponseStatus.Failed,
            "expired" => ProfileUpdateAvatarResponseStatus.Expired,
            _ => (ProfileUpdateAvatarResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseStatus.Accepted => "accepted",
                ProfileUpdateAvatarResponseStatus.Dispatching => "dispatching",
                ProfileUpdateAvatarResponseStatus.PendingConfirmation => "pending_confirmation",
                ProfileUpdateAvatarResponseStatus.Success => "success",
                ProfileUpdateAvatarResponseStatus.Failed => "failed",
                ProfileUpdateAvatarResponseStatus.Expired => "expired",
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
        ProfileUpdateAvatarResponseTarget,
        ProfileUpdateAvatarResponseTargetFromRaw
    >)
)]
public sealed record class ProfileUpdateAvatarResponseTarget : JsonModel
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

    public required ApiEnum<string, ProfileUpdateAvatarResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProfileUpdateAvatarResponseTargetType>
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

    public ProfileUpdateAvatarResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponseTarget(
        ProfileUpdateAvatarResponseTarget profileUpdateAvatarResponseTarget
    )
        : base(profileUpdateAvatarResponseTarget) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseTargetFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseTargetFromRaw : IFromRawJson<ProfileUpdateAvatarResponseTarget>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileUpdateAvatarResponseTargetTypeConverter))]
public enum ProfileUpdateAvatarResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class ProfileUpdateAvatarResponseTargetTypeConverter
    : JsonConverter<ProfileUpdateAvatarResponseTargetType>
{
    public override ProfileUpdateAvatarResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => ProfileUpdateAvatarResponseTargetType.Tweet,
            "user" => ProfileUpdateAvatarResponseTargetType.User,
            "community" => ProfileUpdateAvatarResponseTargetType.Community,
            _ => (ProfileUpdateAvatarResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileUpdateAvatarResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileUpdateAvatarResponseTargetType.Tweet => "tweet",
                ProfileUpdateAvatarResponseTargetType.User => "user",
                ProfileUpdateAvatarResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
