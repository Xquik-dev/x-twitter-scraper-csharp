using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Communities.Join;

/// <summary>
/// Durable write lifecycle record. Poll statusUrl until terminal is true. Reusing
/// the original Idempotency-Key returns this same record. Submit a new write only
/// when safeToRetry is true, using a new key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JoinDeleteAllResponse, JoinDeleteAllResponseFromRaw>))]
public sealed record class JoinDeleteAllResponse : JsonModel
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
    public required JoinDeleteAllResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JoinDeleteAllResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, JoinDeleteAllResponseAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JoinDeleteAllResponseAction>>(
                "action"
            );
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required JoinDeleteAllResponseBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JoinDeleteAllResponseBilling>("billing");
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
    public required JoinDeleteAllResponseNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JoinDeleteAllResponseNextAction>("nextAction");
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
    public required JoinDeleteAllResponseRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JoinDeleteAllResponseRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required JoinDeleteAllResponseResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JoinDeleteAllResponseResult>("result");
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

    public required ApiEnum<string, JoinDeleteAllResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JoinDeleteAllResponseStatus>>(
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
    public required JoinDeleteAllResponseTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JoinDeleteAllResponseTarget>("target");
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

    public JoinDeleteAllResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponse(JoinDeleteAllResponse joinDeleteAllResponse)
        : base(joinDeleteAllResponse) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseFromRaw : IFromRawJson<JoinDeleteAllResponse>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JoinDeleteAllResponseAccount, JoinDeleteAllResponseAccountFromRaw>)
)]
public sealed record class JoinDeleteAllResponseAccount : JsonModel
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

    public JoinDeleteAllResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseAccount(JoinDeleteAllResponseAccount joinDeleteAllResponseAccount)
        : base(joinDeleteAllResponseAccount) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseAccountFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseAccountFromRaw : IFromRawJson<JoinDeleteAllResponseAccount>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JoinDeleteAllResponseActionConverter))]
public enum JoinDeleteAllResponseAction
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

sealed class JoinDeleteAllResponseActionConverter : JsonConverter<JoinDeleteAllResponseAction>
{
    public override JoinDeleteAllResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => JoinDeleteAllResponseAction.CreateTweet,
            "delete_tweet" => JoinDeleteAllResponseAction.DeleteTweet,
            "like" => JoinDeleteAllResponseAction.Like,
            "unlike" => JoinDeleteAllResponseAction.Unlike,
            "retweet" => JoinDeleteAllResponseAction.Retweet,
            "unretweet" => JoinDeleteAllResponseAction.Unretweet,
            "follow" => JoinDeleteAllResponseAction.Follow,
            "unfollow" => JoinDeleteAllResponseAction.Unfollow,
            "remove_follower" => JoinDeleteAllResponseAction.RemoveFollower,
            "send_dm" => JoinDeleteAllResponseAction.SendDm,
            "upload_media" => JoinDeleteAllResponseAction.UploadMedia,
            "update_profile" => JoinDeleteAllResponseAction.UpdateProfile,
            "update_avatar" => JoinDeleteAllResponseAction.UpdateAvatar,
            "update_banner" => JoinDeleteAllResponseAction.UpdateBanner,
            "create_community" => JoinDeleteAllResponseAction.CreateCommunity,
            "delete_community" => JoinDeleteAllResponseAction.DeleteCommunity,
            "join_community" => JoinDeleteAllResponseAction.JoinCommunity,
            "leave_community" => JoinDeleteAllResponseAction.LeaveCommunity,
            _ => (JoinDeleteAllResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseAction.CreateTweet => "create_tweet",
                JoinDeleteAllResponseAction.DeleteTweet => "delete_tweet",
                JoinDeleteAllResponseAction.Like => "like",
                JoinDeleteAllResponseAction.Unlike => "unlike",
                JoinDeleteAllResponseAction.Retweet => "retweet",
                JoinDeleteAllResponseAction.Unretweet => "unretweet",
                JoinDeleteAllResponseAction.Follow => "follow",
                JoinDeleteAllResponseAction.Unfollow => "unfollow",
                JoinDeleteAllResponseAction.RemoveFollower => "remove_follower",
                JoinDeleteAllResponseAction.SendDm => "send_dm",
                JoinDeleteAllResponseAction.UploadMedia => "upload_media",
                JoinDeleteAllResponseAction.UpdateProfile => "update_profile",
                JoinDeleteAllResponseAction.UpdateAvatar => "update_avatar",
                JoinDeleteAllResponseAction.UpdateBanner => "update_banner",
                JoinDeleteAllResponseAction.CreateCommunity => "create_community",
                JoinDeleteAllResponseAction.DeleteCommunity => "delete_community",
                JoinDeleteAllResponseAction.JoinCommunity => "join_community",
                JoinDeleteAllResponseAction.LeaveCommunity => "leave_community",
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
    typeof(JsonModelConverter<JoinDeleteAllResponseBilling, JoinDeleteAllResponseBillingFromRaw>)
)]
public sealed record class JoinDeleteAllResponseBilling : JsonModel
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

    public required ApiEnum<string, JoinDeleteAllResponseBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JoinDeleteAllResponseBillingStatus>
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

    public JoinDeleteAllResponseBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseBilling(JoinDeleteAllResponseBilling joinDeleteAllResponseBilling)
        : base(joinDeleteAllResponseBilling) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseBillingFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseBillingFromRaw : IFromRawJson<JoinDeleteAllResponseBilling>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseBilling.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JoinDeleteAllResponseBillingStatusConverter))]
public enum JoinDeleteAllResponseBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class JoinDeleteAllResponseBillingStatusConverter
    : JsonConverter<JoinDeleteAllResponseBillingStatus>
{
    public override JoinDeleteAllResponseBillingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => JoinDeleteAllResponseBillingStatus.NotCharged,
            "pending" => JoinDeleteAllResponseBillingStatus.Pending,
            "charged" => JoinDeleteAllResponseBillingStatus.Charged,
            "charge_failed" => JoinDeleteAllResponseBillingStatus.ChargeFailed,
            "refunded" => JoinDeleteAllResponseBillingStatus.Refunded,
            _ => (JoinDeleteAllResponseBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseBillingStatus.NotCharged => "not_charged",
                JoinDeleteAllResponseBillingStatus.Pending => "pending",
                JoinDeleteAllResponseBillingStatus.Charged => "charged",
                JoinDeleteAllResponseBillingStatus.ChargeFailed => "charge_failed",
                JoinDeleteAllResponseBillingStatus.Refunded => "refunded",
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
        JoinDeleteAllResponseNextAction,
        JoinDeleteAllResponseNextActionFromRaw
    >)
)]
public sealed record class JoinDeleteAllResponseNextAction : JsonModel
{
    public required ApiEnum<string, JoinDeleteAllResponseNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JoinDeleteAllResponseNextActionType>
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

    public JoinDeleteAllResponseNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseNextAction(
        JoinDeleteAllResponseNextAction joinDeleteAllResponseNextAction
    )
        : base(joinDeleteAllResponseNextAction) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseNextActionFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JoinDeleteAllResponseNextAction(
        ApiEnum<string, JoinDeleteAllResponseNextActionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class JoinDeleteAllResponseNextActionFromRaw : IFromRawJson<JoinDeleteAllResponseNextAction>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseNextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JoinDeleteAllResponseNextActionTypeConverter))]
public enum JoinDeleteAllResponseNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class JoinDeleteAllResponseNextActionTypeConverter
    : JsonConverter<JoinDeleteAllResponseNextActionType>
{
    public override JoinDeleteAllResponseNextActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => JoinDeleteAllResponseNextActionType.Poll,
            "retry" => JoinDeleteAllResponseNextActionType.Retry,
            "verify_result" => JoinDeleteAllResponseNextActionType.VerifyResult,
            "fix_request" => JoinDeleteAllResponseNextActionType.FixRequest,
            _ => (JoinDeleteAllResponseNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseNextActionType.Poll => "poll",
                JoinDeleteAllResponseNextActionType.Retry => "retry",
                JoinDeleteAllResponseNextActionType.VerifyResult => "verify_result",
                JoinDeleteAllResponseNextActionType.FixRequest => "fix_request",
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
    typeof(JsonModelConverter<JoinDeleteAllResponseRequest, JoinDeleteAllResponseRequestFromRaw>)
)]
public sealed record class JoinDeleteAllResponseRequest : JsonModel
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

    public JoinDeleteAllResponseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseRequest(JoinDeleteAllResponseRequest joinDeleteAllResponseRequest)
        : base(joinDeleteAllResponseRequest) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseRequestFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseRequestFromRaw : IFromRawJson<JoinDeleteAllResponseRequest>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JoinDeleteAllResponseResult, JoinDeleteAllResponseResultFromRaw>)
)]
public sealed record class JoinDeleteAllResponseResult : JsonModel
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

    public ApiEnum<string, JoinDeleteAllResponseResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JoinDeleteAllResponseResultType>>(
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

    public JoinDeleteAllResponseResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseResult(JoinDeleteAllResponseResult joinDeleteAllResponseResult)
        : base(joinDeleteAllResponseResult) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseResultFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseResultFromRaw : IFromRawJson<JoinDeleteAllResponseResult>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JoinDeleteAllResponseResultTypeConverter))]
public enum JoinDeleteAllResponseResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class JoinDeleteAllResponseResultTypeConverter
    : JsonConverter<JoinDeleteAllResponseResultType>
{
    public override JoinDeleteAllResponseResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => JoinDeleteAllResponseResultType.Tweet,
            "direct_message" => JoinDeleteAllResponseResultType.DirectMessage,
            "media" => JoinDeleteAllResponseResultType.Media,
            "community" => JoinDeleteAllResponseResultType.Community,
            "state_change" => JoinDeleteAllResponseResultType.StateChange,
            _ => (JoinDeleteAllResponseResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseResultType.Tweet => "tweet",
                JoinDeleteAllResponseResultType.DirectMessage => "direct_message",
                JoinDeleteAllResponseResultType.Media => "media",
                JoinDeleteAllResponseResultType.Community => "community",
                JoinDeleteAllResponseResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JoinDeleteAllResponseStatusConverter))]
public enum JoinDeleteAllResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class JoinDeleteAllResponseStatusConverter : JsonConverter<JoinDeleteAllResponseStatus>
{
    public override JoinDeleteAllResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => JoinDeleteAllResponseStatus.Accepted,
            "dispatching" => JoinDeleteAllResponseStatus.Dispatching,
            "pending_confirmation" => JoinDeleteAllResponseStatus.PendingConfirmation,
            "success" => JoinDeleteAllResponseStatus.Success,
            "failed" => JoinDeleteAllResponseStatus.Failed,
            "expired" => JoinDeleteAllResponseStatus.Expired,
            _ => (JoinDeleteAllResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseStatus.Accepted => "accepted",
                JoinDeleteAllResponseStatus.Dispatching => "dispatching",
                JoinDeleteAllResponseStatus.PendingConfirmation => "pending_confirmation",
                JoinDeleteAllResponseStatus.Success => "success",
                JoinDeleteAllResponseStatus.Failed => "failed",
                JoinDeleteAllResponseStatus.Expired => "expired",
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
    typeof(JsonModelConverter<JoinDeleteAllResponseTarget, JoinDeleteAllResponseTargetFromRaw>)
)]
public sealed record class JoinDeleteAllResponseTarget : JsonModel
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

    public required ApiEnum<string, JoinDeleteAllResponseTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JoinDeleteAllResponseTargetType>>(
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

    public JoinDeleteAllResponseTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponseTarget(JoinDeleteAllResponseTarget joinDeleteAllResponseTarget)
        : base(joinDeleteAllResponseTarget) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponseTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponseTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseTargetFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseTargetFromRaw : IFromRawJson<JoinDeleteAllResponseTarget>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponseTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponseTarget.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JoinDeleteAllResponseTargetTypeConverter))]
public enum JoinDeleteAllResponseTargetType
{
    Tweet,
    User,
    Community,
}

sealed class JoinDeleteAllResponseTargetTypeConverter
    : JsonConverter<JoinDeleteAllResponseTargetType>
{
    public override JoinDeleteAllResponseTargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => JoinDeleteAllResponseTargetType.Tweet,
            "user" => JoinDeleteAllResponseTargetType.User,
            "community" => JoinDeleteAllResponseTargetType.Community,
            _ => (JoinDeleteAllResponseTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JoinDeleteAllResponseTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JoinDeleteAllResponseTargetType.Tweet => "tweet",
                JoinDeleteAllResponseTargetType.User => "user",
                JoinDeleteAllResponseTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
