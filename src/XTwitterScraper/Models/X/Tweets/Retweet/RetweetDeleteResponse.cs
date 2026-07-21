using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Tweets.Retweet;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RetweetDeleteResponse, RetweetDeleteResponseFromRaw>))]
public sealed record class RetweetDeleteResponse : JsonModel
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
    public required RetweetDeleteResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetweetDeleteResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, RetweetDeleteResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RetweetDeleteResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required RetweetDeleteResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RetweetDeleteResponseBilling>("billing");
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
    public required RetweetDeleteResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetweetDeleteResponseNextAction>("nextAction");
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
    public required RetweetDeleteResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RetweetDeleteResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required RetweetDeleteResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetweetDeleteResponseResult>("result");
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

    public required ApiEnum<string, RetweetDeleteResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RetweetDeleteResponseStatus>>(
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
    public required RetweetDeleteResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetweetDeleteResponseTarget>("target");
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

    public RetweetDeleteResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponse(RetweetDeleteResponse retweetDeleteResponse)
        : base(retweetDeleteResponse) { }
#pragma warning restore CS8618

    public RetweetDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseFromRaw : IFromRawJson<RetweetDeleteResponse>
{
    /// <inheritdoc/>
    public RetweetDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RetweetDeleteResponseAccount, RetweetDeleteResponseAccountFromRaw>)
)]
public sealed record class RetweetDeleteResponseAccount : JsonModel
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

    public RetweetDeleteResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseAccount(RetweetDeleteResponseAccount retweetDeleteResponseAccount)
        : base(retweetDeleteResponseAccount) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseAccountFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseAccountFromRaw : IFromRawJson<RetweetDeleteResponseAccount>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetweetDeleteResponseActionConverter))]
public enum RetweetDeleteResponseAction
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

sealed class RetweetDeleteResponseActionConverter : JsonConverter<RetweetDeleteResponseAction>
{
    public override RetweetDeleteResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => RetweetDeleteResponseAction.CreateTweet,
            "delete_tweet" => RetweetDeleteResponseAction.DeleteTweet,
            "like" => RetweetDeleteResponseAction.Like,
            "unlike" => RetweetDeleteResponseAction.Unlike,
            "retweet" => RetweetDeleteResponseAction.Retweet,
            "unretweet" => RetweetDeleteResponseAction.Unretweet,
            "follow" => RetweetDeleteResponseAction.Follow,
            "unfollow" => RetweetDeleteResponseAction.Unfollow,
            "remove_follower" => RetweetDeleteResponseAction.RemoveFollower,
            "send_dm" => RetweetDeleteResponseAction.SendDm,
            "upload_media" => RetweetDeleteResponseAction.UploadMedia,
            "update_profile" => RetweetDeleteResponseAction.UpdateProfile,
            "update_avatar" => RetweetDeleteResponseAction.UpdateAvatar,
            "update_banner" => RetweetDeleteResponseAction.UpdateBanner,
            "create_community" => RetweetDeleteResponseAction.CreateCommunity,
            "delete_community" => RetweetDeleteResponseAction.DeleteCommunity,
            "join_community" => RetweetDeleteResponseAction.JoinCommunity,
            "leave_community" => RetweetDeleteResponseAction.LeaveCommunity,
            _ => (RetweetDeleteResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseAction.CreateTweet => "create_tweet",
                RetweetDeleteResponseAction.DeleteTweet => "delete_tweet",
                RetweetDeleteResponseAction.Like => "like",
                RetweetDeleteResponseAction.Unlike => "unlike",
                RetweetDeleteResponseAction.Retweet => "retweet",
                RetweetDeleteResponseAction.Unretweet => "unretweet",
                RetweetDeleteResponseAction.Follow => "follow",
                RetweetDeleteResponseAction.Unfollow => "unfollow",
                RetweetDeleteResponseAction.RemoveFollower => "remove_follower",
                RetweetDeleteResponseAction.SendDm => "send_dm",
                RetweetDeleteResponseAction.UploadMedia => "upload_media",
                RetweetDeleteResponseAction.UpdateProfile => "update_profile",
                RetweetDeleteResponseAction.UpdateAvatar => "update_avatar",
                RetweetDeleteResponseAction.UpdateBanner => "update_banner",
                RetweetDeleteResponseAction.CreateCommunity => "create_community",
                RetweetDeleteResponseAction.DeleteCommunity => "delete_community",
                RetweetDeleteResponseAction.JoinCommunity => "join_community",
                RetweetDeleteResponseAction.LeaveCommunity => "leave_community",
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
    typeof(JsonModelConverter<RetweetDeleteResponseBilling, RetweetDeleteResponseBillingFromRaw>)
)]
public sealed record class RetweetDeleteResponseBilling : JsonModel
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

    public required ApiEnum<string, RetweetDeleteResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RetweetDeleteResponseBillingStatus>
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

    public RetweetDeleteResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseBilling(RetweetDeleteResponseBilling retweetDeleteResponseBilling)
        : base(retweetDeleteResponseBilling) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseBillingFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseBillingFromRaw : IFromRawJson<RetweetDeleteResponseBilling>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetweetDeleteResponseBillingStatusConverter))]
public enum RetweetDeleteResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class RetweetDeleteResponseBillingStatusConverter
    : JsonConverter<RetweetDeleteResponseBillingStatus>
{
    public override RetweetDeleteResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => RetweetDeleteResponseBillingStatus.NotCharged,
            "pending" => RetweetDeleteResponseBillingStatus.Pending,
            "charged" => RetweetDeleteResponseBillingStatus.Charged,
            "charge_failed" => RetweetDeleteResponseBillingStatus.ChargeFailed,
            "refunded" => RetweetDeleteResponseBillingStatus.Refunded,
            _ => (RetweetDeleteResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseBillingStatus.NotCharged => "not_charged",
                RetweetDeleteResponseBillingStatus.Pending => "pending",
                RetweetDeleteResponseBillingStatus.Charged => "charged",
                RetweetDeleteResponseBillingStatus.ChargeFailed => "charge_failed",
                RetweetDeleteResponseBillingStatus.Refunded => "refunded",
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
        RetweetDeleteResponseNextAction,
        RetweetDeleteResponseNextActionFromRaw
    >)
)]
public sealed record class RetweetDeleteResponseNextAction : JsonModel
{
    public required ApiEnum<string, RetweetDeleteResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RetweetDeleteResponseNextActionType>
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

    public RetweetDeleteResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseNextAction(
        RetweetDeleteResponseNextAction retweetDeleteResponseNextAction
    )
        : base(retweetDeleteResponseNextAction) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseNextActionFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetweetDeleteResponseNextAction(
        ApiEnum<string, RetweetDeleteResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class RetweetDeleteResponseNextActionFromRaw : IFromRawJson<RetweetDeleteResponseNextAction>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetweetDeleteResponseNextActionTypeConverter))]
public enum RetweetDeleteResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class RetweetDeleteResponseNextActionTypeConverter
    : JsonConverter<RetweetDeleteResponseNextActionType>
{
    public override RetweetDeleteResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => RetweetDeleteResponseNextActionType.Poll,
            "retry" => RetweetDeleteResponseNextActionType.Retry,
            "verify_result" => RetweetDeleteResponseNextActionType.VerifyResult,
            "fix_request" => RetweetDeleteResponseNextActionType.FixRequest,
            _ => (RetweetDeleteResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseNextActionType.Poll => "poll",
                RetweetDeleteResponseNextActionType.Retry => "retry",
                RetweetDeleteResponseNextActionType.VerifyResult => "verify_result",
                RetweetDeleteResponseNextActionType.FixRequest => "fix_request",
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
    typeof(JsonModelConverter<RetweetDeleteResponseRequest, RetweetDeleteResponseRequestFromRaw>)
)]
public sealed record class RetweetDeleteResponseRequest : JsonModel
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

    public RetweetDeleteResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseRequest(RetweetDeleteResponseRequest retweetDeleteResponseRequest)
        : base(retweetDeleteResponseRequest) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseRequestFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseRequestFromRaw : IFromRawJson<RetweetDeleteResponseRequest>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RetweetDeleteResponseResult, RetweetDeleteResponseResultFromRaw>)
)]
public sealed record class RetweetDeleteResponseResult : JsonModel
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

    public ApiEnum<string, RetweetDeleteResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RetweetDeleteResponseResultType>>(
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

    public RetweetDeleteResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseResult(RetweetDeleteResponseResult retweetDeleteResponseResult)
        : base(retweetDeleteResponseResult) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseResultFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseResultFromRaw : IFromRawJson<RetweetDeleteResponseResult>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetweetDeleteResponseResultTypeConverter))]
public enum RetweetDeleteResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class RetweetDeleteResponseResultTypeConverter
    : JsonConverter<RetweetDeleteResponseResultType>
{
    public override RetweetDeleteResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => RetweetDeleteResponseResultType.Tweet,
            "direct_message" => RetweetDeleteResponseResultType.DirectMessage,
            "media" => RetweetDeleteResponseResultType.Media,
            "community" => RetweetDeleteResponseResultType.Community,
            "state_change" => RetweetDeleteResponseResultType.StateChange,
            _ => (RetweetDeleteResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseResultType.Tweet => "tweet",
                RetweetDeleteResponseResultType.DirectMessage => "direct_message",
                RetweetDeleteResponseResultType.Media => "media",
                RetweetDeleteResponseResultType.Community => "community",
                RetweetDeleteResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RetweetDeleteResponseStatusConverter))]
public enum RetweetDeleteResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class RetweetDeleteResponseStatusConverter : JsonConverter<RetweetDeleteResponseStatus>
{
    public override RetweetDeleteResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => RetweetDeleteResponseStatus.Accepted,
            "dispatching" => RetweetDeleteResponseStatus.Dispatching,
            "pending_confirmation" => RetweetDeleteResponseStatus.PendingConfirmation,
            "success" => RetweetDeleteResponseStatus.Success,
            "failed" => RetweetDeleteResponseStatus.Failed,
            "expired" => RetweetDeleteResponseStatus.Expired,
            _ => (RetweetDeleteResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseStatus.Accepted => "accepted",
                RetweetDeleteResponseStatus.Dispatching => "dispatching",
                RetweetDeleteResponseStatus.PendingConfirmation => "pending_confirmation",
                RetweetDeleteResponseStatus.Success => "success",
                RetweetDeleteResponseStatus.Failed => "failed",
                RetweetDeleteResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<RetweetDeleteResponseTarget, RetweetDeleteResponseTargetFromRaw>)
)]
public sealed record class RetweetDeleteResponseTarget : JsonModel
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

    public required ApiEnum<string, RetweetDeleteResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RetweetDeleteResponseTargetType>>(
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

    public RetweetDeleteResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetweetDeleteResponseTarget(RetweetDeleteResponseTarget retweetDeleteResponseTarget)
        : base(retweetDeleteResponseTarget) { }
#pragma warning restore CS8618

    public RetweetDeleteResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetweetDeleteResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetweetDeleteResponseTargetFromRaw.FromRawUnchecked"/>
    public static RetweetDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetweetDeleteResponseTargetFromRaw : IFromRawJson<RetweetDeleteResponseTarget>
{
    /// <inheritdoc/>
    public RetweetDeleteResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetweetDeleteResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetweetDeleteResponseTargetTypeConverter))]
public enum RetweetDeleteResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class RetweetDeleteResponseTargetTypeConverter
    : JsonConverter<RetweetDeleteResponseTargetType>
{
    public override RetweetDeleteResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => RetweetDeleteResponseTargetType.Tweet,
            "user" => RetweetDeleteResponseTargetType.User,
            "community" => RetweetDeleteResponseTargetType.Community,
            _ => (RetweetDeleteResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetweetDeleteResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetweetDeleteResponseTargetType.Tweet => "tweet",
                RetweetDeleteResponseTargetType.User => "user",
                RetweetDeleteResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
