using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Tweets.Like;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LikeDeleteResponse, LikeDeleteResponseFromRaw>))]
public sealed record class LikeDeleteResponse : JsonModel
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
    public required LikeDeleteResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LikeDeleteResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, LikeDeleteResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LikeDeleteResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required LikeDeleteResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LikeDeleteResponseBilling>("billing");
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
    public required LikeDeleteResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LikeDeleteResponseNextAction>("nextAction");
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
    public required LikeDeleteResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LikeDeleteResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required LikeDeleteResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LikeDeleteResponseResult>("result");
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

    public required ApiEnum<string, LikeDeleteResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LikeDeleteResponseStatus>>(
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
    public required LikeDeleteResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LikeDeleteResponseTarget>("target");
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

    public LikeDeleteResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponse(LikeDeleteResponse likeDeleteResponse)
        : base(likeDeleteResponse) { }
#pragma warning restore CS8618

    public LikeDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseFromRaw : IFromRawJson<LikeDeleteResponse>
{
    /// <inheritdoc/>
    public LikeDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LikeDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<LikeDeleteResponseAccount, LikeDeleteResponseAccountFromRaw>)
)]
public sealed record class LikeDeleteResponseAccount : JsonModel
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

    public LikeDeleteResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseAccount(LikeDeleteResponseAccount likeDeleteResponseAccount)
        : base(likeDeleteResponseAccount) { }
#pragma warning restore CS8618

    public LikeDeleteResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseAccountFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseAccountFromRaw : IFromRawJson<LikeDeleteResponseAccount>
{
    /// <inheritdoc/>
    public LikeDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LikeDeleteResponseActionConverter))]
public enum LikeDeleteResponseAction
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

sealed class LikeDeleteResponseActionConverter : JsonConverter<LikeDeleteResponseAction>
{
    public override LikeDeleteResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => LikeDeleteResponseAction.CreateTweet,
            "delete_tweet" => LikeDeleteResponseAction.DeleteTweet,
            "like" => LikeDeleteResponseAction.Like,
            "unlike" => LikeDeleteResponseAction.Unlike,
            "retweet" => LikeDeleteResponseAction.Retweet,
            "unretweet" => LikeDeleteResponseAction.Unretweet,
            "follow" => LikeDeleteResponseAction.Follow,
            "unfollow" => LikeDeleteResponseAction.Unfollow,
            "remove_follower" => LikeDeleteResponseAction.RemoveFollower,
            "send_dm" => LikeDeleteResponseAction.SendDm,
            "upload_media" => LikeDeleteResponseAction.UploadMedia,
            "update_profile" => LikeDeleteResponseAction.UpdateProfile,
            "update_avatar" => LikeDeleteResponseAction.UpdateAvatar,
            "update_banner" => LikeDeleteResponseAction.UpdateBanner,
            "create_community" => LikeDeleteResponseAction.CreateCommunity,
            "delete_community" => LikeDeleteResponseAction.DeleteCommunity,
            "join_community" => LikeDeleteResponseAction.JoinCommunity,
            "leave_community" => LikeDeleteResponseAction.LeaveCommunity,
            _ => (LikeDeleteResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseAction.CreateTweet => "create_tweet",
                LikeDeleteResponseAction.DeleteTweet => "delete_tweet",
                LikeDeleteResponseAction.Like => "like",
                LikeDeleteResponseAction.Unlike => "unlike",
                LikeDeleteResponseAction.Retweet => "retweet",
                LikeDeleteResponseAction.Unretweet => "unretweet",
                LikeDeleteResponseAction.Follow => "follow",
                LikeDeleteResponseAction.Unfollow => "unfollow",
                LikeDeleteResponseAction.RemoveFollower => "remove_follower",
                LikeDeleteResponseAction.SendDm => "send_dm",
                LikeDeleteResponseAction.UploadMedia => "upload_media",
                LikeDeleteResponseAction.UpdateProfile => "update_profile",
                LikeDeleteResponseAction.UpdateAvatar => "update_avatar",
                LikeDeleteResponseAction.UpdateBanner => "update_banner",
                LikeDeleteResponseAction.CreateCommunity => "create_community",
                LikeDeleteResponseAction.DeleteCommunity => "delete_community",
                LikeDeleteResponseAction.JoinCommunity => "join_community",
                LikeDeleteResponseAction.LeaveCommunity => "leave_community",
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
    typeof(JsonModelConverter<LikeDeleteResponseBilling, LikeDeleteResponseBillingFromRaw>)
)]
public sealed record class LikeDeleteResponseBilling : JsonModel
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

    public required ApiEnum<string, LikeDeleteResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LikeDeleteResponseBillingStatus>>(
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

    public LikeDeleteResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseBilling(LikeDeleteResponseBilling likeDeleteResponseBilling)
        : base(likeDeleteResponseBilling) { }
#pragma warning restore CS8618

    public LikeDeleteResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseBillingFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseBillingFromRaw : IFromRawJson<LikeDeleteResponseBilling>
{
    /// <inheritdoc/>
    public LikeDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LikeDeleteResponseBillingStatusConverter))]
public enum LikeDeleteResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class LikeDeleteResponseBillingStatusConverter
    : JsonConverter<LikeDeleteResponseBillingStatus>
{
    public override LikeDeleteResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => LikeDeleteResponseBillingStatus.NotCharged,
            "pending" => LikeDeleteResponseBillingStatus.Pending,
            "charged" => LikeDeleteResponseBillingStatus.Charged,
            "charge_failed" => LikeDeleteResponseBillingStatus.ChargeFailed,
            "refunded" => LikeDeleteResponseBillingStatus.Refunded,
            _ => (LikeDeleteResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseBillingStatus.NotCharged => "not_charged",
                LikeDeleteResponseBillingStatus.Pending => "pending",
                LikeDeleteResponseBillingStatus.Charged => "charged",
                LikeDeleteResponseBillingStatus.ChargeFailed => "charge_failed",
                LikeDeleteResponseBillingStatus.Refunded => "refunded",
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
    typeof(JsonModelConverter<LikeDeleteResponseNextAction, LikeDeleteResponseNextActionFromRaw>)
)]
public sealed record class LikeDeleteResponseNextAction : JsonModel
{
    public required ApiEnum<string, LikeDeleteResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LikeDeleteResponseNextActionType>>(
                "type"
            );
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

    public LikeDeleteResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseNextAction(LikeDeleteResponseNextAction likeDeleteResponseNextAction)
        : base(likeDeleteResponseNextAction) { }
#pragma warning restore CS8618

    public LikeDeleteResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseNextActionFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LikeDeleteResponseNextAction(ApiEnum<string, LikeDeleteResponseNextActionType> type)
        : this()
    {
        this.Type = type;
    }
}

class LikeDeleteResponseNextActionFromRaw : IFromRawJson<LikeDeleteResponseNextAction>
{
    /// <inheritdoc/>
    public LikeDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LikeDeleteResponseNextActionTypeConverter))]
public enum LikeDeleteResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class LikeDeleteResponseNextActionTypeConverter
    : JsonConverter<LikeDeleteResponseNextActionType>
{
    public override LikeDeleteResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => LikeDeleteResponseNextActionType.Poll,
            "retry" => LikeDeleteResponseNextActionType.Retry,
            "verify_result" => LikeDeleteResponseNextActionType.VerifyResult,
            "fix_request" => LikeDeleteResponseNextActionType.FixRequest,
            _ => (LikeDeleteResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseNextActionType.Poll => "poll",
                LikeDeleteResponseNextActionType.Retry => "retry",
                LikeDeleteResponseNextActionType.VerifyResult => "verify_result",
                LikeDeleteResponseNextActionType.FixRequest => "fix_request",
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
    typeof(JsonModelConverter<LikeDeleteResponseRequest, LikeDeleteResponseRequestFromRaw>)
)]
public sealed record class LikeDeleteResponseRequest : JsonModel
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

    public LikeDeleteResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseRequest(LikeDeleteResponseRequest likeDeleteResponseRequest)
        : base(likeDeleteResponseRequest) { }
#pragma warning restore CS8618

    public LikeDeleteResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseRequestFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseRequestFromRaw : IFromRawJson<LikeDeleteResponseRequest>
{
    /// <inheritdoc/>
    public LikeDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<LikeDeleteResponseResult, LikeDeleteResponseResultFromRaw>)
)]
public sealed record class LikeDeleteResponseResult : JsonModel
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

    public ApiEnum<string, LikeDeleteResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LikeDeleteResponseResultType>>(
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

    public LikeDeleteResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseResult(LikeDeleteResponseResult likeDeleteResponseResult)
        : base(likeDeleteResponseResult) { }
#pragma warning restore CS8618

    public LikeDeleteResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseResultFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseResultFromRaw : IFromRawJson<LikeDeleteResponseResult>
{
    /// <inheritdoc/>
    public LikeDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LikeDeleteResponseResultTypeConverter))]
public enum LikeDeleteResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class LikeDeleteResponseResultTypeConverter : JsonConverter<LikeDeleteResponseResultType>
{
    public override LikeDeleteResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => LikeDeleteResponseResultType.Tweet,
            "direct_message" => LikeDeleteResponseResultType.DirectMessage,
            "media" => LikeDeleteResponseResultType.Media,
            "community" => LikeDeleteResponseResultType.Community,
            "state_change" => LikeDeleteResponseResultType.StateChange,
            _ => (LikeDeleteResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseResultType.Tweet => "tweet",
                LikeDeleteResponseResultType.DirectMessage => "direct_message",
                LikeDeleteResponseResultType.Media => "media",
                LikeDeleteResponseResultType.Community => "community",
                LikeDeleteResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(LikeDeleteResponseStatusConverter))]
public enum LikeDeleteResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class LikeDeleteResponseStatusConverter : JsonConverter<LikeDeleteResponseStatus>
{
    public override LikeDeleteResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => LikeDeleteResponseStatus.Accepted,
            "dispatching" => LikeDeleteResponseStatus.Dispatching,
            "pending_confirmation" => LikeDeleteResponseStatus.PendingConfirmation,
            "success" => LikeDeleteResponseStatus.Success,
            "failed" => LikeDeleteResponseStatus.Failed,
            "expired" => LikeDeleteResponseStatus.Expired,
            _ => (LikeDeleteResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseStatus.Accepted => "accepted",
                LikeDeleteResponseStatus.Dispatching => "dispatching",
                LikeDeleteResponseStatus.PendingConfirmation => "pending_confirmation",
                LikeDeleteResponseStatus.Success => "success",
                LikeDeleteResponseStatus.Failed => "failed",
                LikeDeleteResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<LikeDeleteResponseTarget, LikeDeleteResponseTargetFromRaw>)
)]
public sealed record class LikeDeleteResponseTarget : JsonModel
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

    public required ApiEnum<string, LikeDeleteResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LikeDeleteResponseTargetType>>(
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

    public LikeDeleteResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeDeleteResponseTarget(LikeDeleteResponseTarget likeDeleteResponseTarget)
        : base(likeDeleteResponseTarget) { }
#pragma warning restore CS8618

    public LikeDeleteResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeDeleteResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeDeleteResponseTargetFromRaw.FromRawUnchecked"/>
    public static LikeDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeDeleteResponseTargetFromRaw : IFromRawJson<LikeDeleteResponseTarget>
{
    /// <inheritdoc/>
    public LikeDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LikeDeleteResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LikeDeleteResponseTargetTypeConverter))]
public enum LikeDeleteResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class LikeDeleteResponseTargetTypeConverter : JsonConverter<LikeDeleteResponseTargetType>
{
    public override LikeDeleteResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => LikeDeleteResponseTargetType.Tweet,
            "user" => LikeDeleteResponseTargetType.User,
            "community" => LikeDeleteResponseTargetType.Community,
            _ => (LikeDeleteResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LikeDeleteResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LikeDeleteResponseTargetType.Tweet => "tweet",
                LikeDeleteResponseTargetType.User => "user",
                LikeDeleteResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
