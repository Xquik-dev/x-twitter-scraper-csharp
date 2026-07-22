using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Users.Follow;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FollowDeleteAllResponse, FollowDeleteAllResponseFromRaw>))]
public sealed record class FollowDeleteAllResponse : JsonModel
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
    public required FollowDeleteAllResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FollowDeleteAllResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, FollowDeleteAllResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FollowDeleteAllResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required FollowDeleteAllResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FollowDeleteAllResponseBilling>("billing");
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
    public required FollowDeleteAllResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FollowDeleteAllResponseNextAction>("nextAction");
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
    public required FollowDeleteAllResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FollowDeleteAllResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required FollowDeleteAllResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FollowDeleteAllResponseResult>("result");
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

    public required ApiEnum<string, FollowDeleteAllResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FollowDeleteAllResponseStatus>>(
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
    public required FollowDeleteAllResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FollowDeleteAllResponseTarget>("target");
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

    public FollowDeleteAllResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponse(FollowDeleteAllResponse followDeleteAllResponse)
        : base(followDeleteAllResponse) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseFromRaw : IFromRawJson<FollowDeleteAllResponse>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FollowDeleteAllResponseAccount,
        FollowDeleteAllResponseAccountFromRaw
    >)
)]
public sealed record class FollowDeleteAllResponseAccount : JsonModel
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

    public FollowDeleteAllResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseAccount(
        FollowDeleteAllResponseAccount followDeleteAllResponseAccount
    )
        : base(followDeleteAllResponseAccount) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseAccountFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseAccountFromRaw : IFromRawJson<FollowDeleteAllResponseAccount>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowDeleteAllResponseActionConverter))]
public enum FollowDeleteAllResponseAction
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

sealed class FollowDeleteAllResponseActionConverter : JsonConverter<FollowDeleteAllResponseAction>
{
    public override FollowDeleteAllResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => FollowDeleteAllResponseAction.CreateTweet,
            "delete_tweet" => FollowDeleteAllResponseAction.DeleteTweet,
            "like" => FollowDeleteAllResponseAction.Like,
            "unlike" => FollowDeleteAllResponseAction.Unlike,
            "retweet" => FollowDeleteAllResponseAction.Retweet,
            "unretweet" => FollowDeleteAllResponseAction.Unretweet,
            "follow" => FollowDeleteAllResponseAction.Follow,
            "unfollow" => FollowDeleteAllResponseAction.Unfollow,
            "remove_follower" => FollowDeleteAllResponseAction.RemoveFollower,
            "send_dm" => FollowDeleteAllResponseAction.SendDm,
            "upload_media" => FollowDeleteAllResponseAction.UploadMedia,
            "update_profile" => FollowDeleteAllResponseAction.UpdateProfile,
            "update_avatar" => FollowDeleteAllResponseAction.UpdateAvatar,
            "update_banner" => FollowDeleteAllResponseAction.UpdateBanner,
            "create_community" => FollowDeleteAllResponseAction.CreateCommunity,
            "delete_community" => FollowDeleteAllResponseAction.DeleteCommunity,
            "join_community" => FollowDeleteAllResponseAction.JoinCommunity,
            "leave_community" => FollowDeleteAllResponseAction.LeaveCommunity,
            _ => (FollowDeleteAllResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseAction.CreateTweet => "create_tweet",
                FollowDeleteAllResponseAction.DeleteTweet => "delete_tweet",
                FollowDeleteAllResponseAction.Like => "like",
                FollowDeleteAllResponseAction.Unlike => "unlike",
                FollowDeleteAllResponseAction.Retweet => "retweet",
                FollowDeleteAllResponseAction.Unretweet => "unretweet",
                FollowDeleteAllResponseAction.Follow => "follow",
                FollowDeleteAllResponseAction.Unfollow => "unfollow",
                FollowDeleteAllResponseAction.RemoveFollower => "remove_follower",
                FollowDeleteAllResponseAction.SendDm => "send_dm",
                FollowDeleteAllResponseAction.UploadMedia => "upload_media",
                FollowDeleteAllResponseAction.UpdateProfile => "update_profile",
                FollowDeleteAllResponseAction.UpdateAvatar => "update_avatar",
                FollowDeleteAllResponseAction.UpdateBanner => "update_banner",
                FollowDeleteAllResponseAction.CreateCommunity => "create_community",
                FollowDeleteAllResponseAction.DeleteCommunity => "delete_community",
                FollowDeleteAllResponseAction.JoinCommunity => "join_community",
                FollowDeleteAllResponseAction.LeaveCommunity => "leave_community",
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
        FollowDeleteAllResponseBilling,
        FollowDeleteAllResponseBillingFromRaw
    >)
)]
public sealed record class FollowDeleteAllResponseBilling : JsonModel
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

    public required ApiEnum<string, FollowDeleteAllResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FollowDeleteAllResponseBillingStatus>
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

    public FollowDeleteAllResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseBilling(
        FollowDeleteAllResponseBilling followDeleteAllResponseBilling
    )
        : base(followDeleteAllResponseBilling) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseBillingFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseBillingFromRaw : IFromRawJson<FollowDeleteAllResponseBilling>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowDeleteAllResponseBillingStatusConverter))]
public enum FollowDeleteAllResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class FollowDeleteAllResponseBillingStatusConverter
    : JsonConverter<FollowDeleteAllResponseBillingStatus>
{
    public override FollowDeleteAllResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => FollowDeleteAllResponseBillingStatus.NotCharged,
            "pending" => FollowDeleteAllResponseBillingStatus.Pending,
            "charged" => FollowDeleteAllResponseBillingStatus.Charged,
            "charge_failed" => FollowDeleteAllResponseBillingStatus.ChargeFailed,
            "refunded" => FollowDeleteAllResponseBillingStatus.Refunded,
            _ => (FollowDeleteAllResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseBillingStatus.NotCharged => "not_charged",
                FollowDeleteAllResponseBillingStatus.Pending => "pending",
                FollowDeleteAllResponseBillingStatus.Charged => "charged",
                FollowDeleteAllResponseBillingStatus.ChargeFailed => "charge_failed",
                FollowDeleteAllResponseBillingStatus.Refunded => "refunded",
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
        FollowDeleteAllResponseNextAction,
        FollowDeleteAllResponseNextActionFromRaw
    >)
)]
public sealed record class FollowDeleteAllResponseNextAction : JsonModel
{
    public required ApiEnum<string, FollowDeleteAllResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FollowDeleteAllResponseNextActionType>
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

    public FollowDeleteAllResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseNextAction(
        FollowDeleteAllResponseNextAction followDeleteAllResponseNextAction
    )
        : base(followDeleteAllResponseNextAction) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseNextActionFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FollowDeleteAllResponseNextAction(
        ApiEnum<string, FollowDeleteAllResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class FollowDeleteAllResponseNextActionFromRaw : IFromRawJson<FollowDeleteAllResponseNextAction>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowDeleteAllResponseNextActionTypeConverter))]
public enum FollowDeleteAllResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class FollowDeleteAllResponseNextActionTypeConverter
    : JsonConverter<FollowDeleteAllResponseNextActionType>
{
    public override FollowDeleteAllResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => FollowDeleteAllResponseNextActionType.Poll,
            "retry" => FollowDeleteAllResponseNextActionType.Retry,
            "verify_result" => FollowDeleteAllResponseNextActionType.VerifyResult,
            "fix_request" => FollowDeleteAllResponseNextActionType.FixRequest,
            _ => (FollowDeleteAllResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseNextActionType.Poll => "poll",
                FollowDeleteAllResponseNextActionType.Retry => "retry",
                FollowDeleteAllResponseNextActionType.VerifyResult => "verify_result",
                FollowDeleteAllResponseNextActionType.FixRequest => "fix_request",
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
        FollowDeleteAllResponseRequest,
        FollowDeleteAllResponseRequestFromRaw
    >)
)]
public sealed record class FollowDeleteAllResponseRequest : JsonModel
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

    public FollowDeleteAllResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseRequest(
        FollowDeleteAllResponseRequest followDeleteAllResponseRequest
    )
        : base(followDeleteAllResponseRequest) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseRequestFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseRequestFromRaw : IFromRawJson<FollowDeleteAllResponseRequest>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FollowDeleteAllResponseResult, FollowDeleteAllResponseResultFromRaw>)
)]
public sealed record class FollowDeleteAllResponseResult : JsonModel
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

    public ApiEnum<string, FollowDeleteAllResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FollowDeleteAllResponseResultType>
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

    public FollowDeleteAllResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseResult(
        FollowDeleteAllResponseResult followDeleteAllResponseResult
    )
        : base(followDeleteAllResponseResult) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseResultFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseResultFromRaw : IFromRawJson<FollowDeleteAllResponseResult>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowDeleteAllResponseResultTypeConverter))]
public enum FollowDeleteAllResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class FollowDeleteAllResponseResultTypeConverter
    : JsonConverter<FollowDeleteAllResponseResultType>
{
    public override FollowDeleteAllResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => FollowDeleteAllResponseResultType.Tweet,
            "direct_message" => FollowDeleteAllResponseResultType.DirectMessage,
            "media" => FollowDeleteAllResponseResultType.Media,
            "community" => FollowDeleteAllResponseResultType.Community,
            "state_change" => FollowDeleteAllResponseResultType.StateChange,
            _ => (FollowDeleteAllResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseResultType.Tweet => "tweet",
                FollowDeleteAllResponseResultType.DirectMessage => "direct_message",
                FollowDeleteAllResponseResultType.Media => "media",
                FollowDeleteAllResponseResultType.Community => "community",
                FollowDeleteAllResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FollowDeleteAllResponseStatusConverter))]
public enum FollowDeleteAllResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class FollowDeleteAllResponseStatusConverter : JsonConverter<FollowDeleteAllResponseStatus>
{
    public override FollowDeleteAllResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => FollowDeleteAllResponseStatus.Accepted,
            "dispatching" => FollowDeleteAllResponseStatus.Dispatching,
            "pending_confirmation" => FollowDeleteAllResponseStatus.PendingConfirmation,
            "success" => FollowDeleteAllResponseStatus.Success,
            "failed" => FollowDeleteAllResponseStatus.Failed,
            "expired" => FollowDeleteAllResponseStatus.Expired,
            _ => (FollowDeleteAllResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseStatus.Accepted => "accepted",
                FollowDeleteAllResponseStatus.Dispatching => "dispatching",
                FollowDeleteAllResponseStatus.PendingConfirmation => "pending_confirmation",
                FollowDeleteAllResponseStatus.Success => "success",
                FollowDeleteAllResponseStatus.Failed => "failed",
                FollowDeleteAllResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<FollowDeleteAllResponseTarget, FollowDeleteAllResponseTargetFromRaw>)
)]
public sealed record class FollowDeleteAllResponseTarget : JsonModel
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

    public required ApiEnum<string, FollowDeleteAllResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FollowDeleteAllResponseTargetType>
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

    public FollowDeleteAllResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponseTarget(
        FollowDeleteAllResponseTarget followDeleteAllResponseTarget
    )
        : base(followDeleteAllResponseTarget) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseTargetFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseTargetFromRaw : IFromRawJson<FollowDeleteAllResponseTarget>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowDeleteAllResponseTargetTypeConverter))]
public enum FollowDeleteAllResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class FollowDeleteAllResponseTargetTypeConverter
    : JsonConverter<FollowDeleteAllResponseTargetType>
{
    public override FollowDeleteAllResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => FollowDeleteAllResponseTargetType.Tweet,
            "user" => FollowDeleteAllResponseTargetType.User,
            "community" => FollowDeleteAllResponseTargetType.Community,
            _ => (FollowDeleteAllResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowDeleteAllResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowDeleteAllResponseTargetType.Tweet => "tweet",
                FollowDeleteAllResponseTargetType.User => "user",
                FollowDeleteAllResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
