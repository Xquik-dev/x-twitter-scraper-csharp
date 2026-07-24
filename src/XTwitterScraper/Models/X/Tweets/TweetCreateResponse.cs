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
[JsonConverter(typeof(JsonModelConverter<TweetCreateResponse, TweetCreateResponseFromRaw>))]
public sealed record class TweetCreateResponse : JsonModel
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
    public required TweetCreateResponseAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetCreateResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled
    /// credit ledger. Pending or failed writes are not charged.
    /// </summary>
    public required Billing Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Billing>("billing");
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
    public required NextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NextAction>("nextAction");
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
    public required Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Request>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required Result? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Result>("result");
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

    public required ApiEnum<string, TweetCreateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetCreateResponseStatus>>(
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
    public required Target? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Target>("target");
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

    public TweetCreateResponse()
    {
        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCreateResponse(TweetCreateResponse tweetCreateResponse)
        : base(tweetCreateResponse) { }
#pragma warning restore CS8618

    public TweetCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Object = JsonSerializer.SerializeToElement("x_write_action");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCreateResponseFromRaw.FromRawUnchecked"/>
    public static TweetCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCreateResponseFromRaw : IFromRawJson<TweetCreateResponse>
{
    /// <inheritdoc/>
    public TweetCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Connected account selected for the write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TweetCreateResponseAccount, TweetCreateResponseAccountFromRaw>)
)]
public sealed record class TweetCreateResponseAccount : JsonModel
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

    public TweetCreateResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCreateResponseAccount(TweetCreateResponseAccount tweetCreateResponseAccount)
        : base(tweetCreateResponseAccount) { }
#pragma warning restore CS8618

    public TweetCreateResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCreateResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCreateResponseAccountFromRaw.FromRawUnchecked"/>
    public static TweetCreateResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCreateResponseAccountFromRaw : IFromRawJson<TweetCreateResponseAccount>
{
    /// <inheritdoc/>
    public TweetCreateResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetCreateResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActionConverter))]
public enum Action
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

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => Action.CreateTweet,
            "delete_tweet" => Action.DeleteTweet,
            "like" => Action.Like,
            "unlike" => Action.Unlike,
            "retweet" => Action.Retweet,
            "unretweet" => Action.Unretweet,
            "follow" => Action.Follow,
            "unfollow" => Action.Unfollow,
            "remove_follower" => Action.RemoveFollower,
            "send_dm" => Action.SendDm,
            "upload_media" => Action.UploadMedia,
            "update_profile" => Action.UpdateProfile,
            "update_avatar" => Action.UpdateAvatar,
            "update_banner" => Action.UpdateBanner,
            "create_community" => Action.CreateCommunity,
            "delete_community" => Action.DeleteCommunity,
            "join_community" => Action.JoinCommunity,
            "leave_community" => Action.LeaveCommunity,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.CreateTweet => "create_tweet",
                Action.DeleteTweet => "delete_tweet",
                Action.Like => "like",
                Action.Unlike => "unlike",
                Action.Retweet => "retweet",
                Action.Unretweet => "unretweet",
                Action.Follow => "follow",
                Action.Unfollow => "unfollow",
                Action.RemoveFollower => "remove_follower",
                Action.SendDm => "send_dm",
                Action.UploadMedia => "upload_media",
                Action.UpdateProfile => "update_profile",
                Action.UpdateAvatar => "update_avatar",
                Action.UpdateBanner => "update_banner",
                Action.CreateCommunity => "create_community",
                Action.DeleteCommunity => "delete_community",
                Action.JoinCommunity => "join_community",
                Action.LeaveCommunity => "leave_community",
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
[JsonConverter(typeof(JsonModelConverter<Billing, BillingFromRaw>))]
public sealed record class Billing : JsonModel
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public Billing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Billing(Billing billing)
        : base(billing) { }
#pragma warning restore CS8618

    public Billing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Billing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingFromRaw.FromRawUnchecked"/>
    public static Billing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingFromRaw : IFromRawJson<Billing>
{
    /// <inheritdoc/>
    public Billing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Billing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
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
            "not_charged" => Status.NotCharged,
            "pending" => Status.Pending,
            "charged" => Status.Charged,
            "charge_failed" => Status.ChargeFailed,
            "refunded" => Status.Refunded,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.NotCharged => "not_charged",
                Status.Pending => "pending",
                Status.Charged => "charged",
                Status.ChargeFailed => "charge_failed",
                Status.Refunded => "refunded",
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
[JsonConverter(typeof(JsonModelConverter<NextAction, NextActionFromRaw>))]
public sealed record class NextAction : JsonModel
{
    public required ApiEnum<string, global::XTwitterScraper.Models.X.Tweets.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.X.Tweets.Type>
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

    public NextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NextAction(NextAction nextAction)
        : base(nextAction) { }
#pragma warning restore CS8618

    public NextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NextActionFromRaw.FromRawUnchecked"/>
    public static NextAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NextAction(ApiEnum<string, global::XTwitterScraper.Models.X.Tweets.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class NextActionFromRaw : IFromRawJson<NextAction>
{
    /// <inheritdoc/>
    public NextAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NextAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class TypeConverter : JsonConverter<global::XTwitterScraper.Models.X.Tweets.Type>
{
    public override global::XTwitterScraper.Models.X.Tweets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => global::XTwitterScraper.Models.X.Tweets.Type.Poll,
            "retry" => global::XTwitterScraper.Models.X.Tweets.Type.Retry,
            "verify_result" => global::XTwitterScraper.Models.X.Tweets.Type.VerifyResult,
            "fix_request" => global::XTwitterScraper.Models.X.Tweets.Type.FixRequest,
            _ => (global::XTwitterScraper.Models.X.Tweets.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::XTwitterScraper.Models.X.Tweets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::XTwitterScraper.Models.X.Tweets.Type.Poll => "poll",
                global::XTwitterScraper.Models.X.Tweets.Type.Retry => "retry",
                global::XTwitterScraper.Models.X.Tweets.Type.VerifyResult => "verify_result",
                global::XTwitterScraper.Models.X.Tweets.Type.FixRequest => "fix_request",
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
[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
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

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Request(Request request)
        : base(request) { }
#pragma warning restore CS8618

    public Request(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestFromRaw.FromRawUnchecked"/>
    public static Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestFromRaw : IFromRawJson<Request>
{
    /// <inheritdoc/>
    public Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Request.FromRawUnchecked(rawData);
}

/// <summary>
/// Confirmed result produced by the write, when available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
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

    public ApiEnum<string, ResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResultType>>("type");
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

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ResultTypeConverter))]
public enum ResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class ResultTypeConverter : JsonConverter<ResultType>
{
    public override ResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => ResultType.Tweet,
            "direct_message" => ResultType.DirectMessage,
            "media" => ResultType.Media,
            "community" => ResultType.Community,
            "state_change" => ResultType.StateChange,
            _ => (ResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResultType.Tweet => "tweet",
                ResultType.DirectMessage => "direct_message",
                ResultType.Media => "media",
                ResultType.Community => "community",
                ResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetCreateResponseStatusConverter))]
public enum TweetCreateResponseStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class TweetCreateResponseStatusConverter : JsonConverter<TweetCreateResponseStatus>
{
    public override TweetCreateResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => TweetCreateResponseStatus.Accepted,
            "dispatching" => TweetCreateResponseStatus.Dispatching,
            "pending_confirmation" => TweetCreateResponseStatus.PendingConfirmation,
            "success" => TweetCreateResponseStatus.Success,
            "failed" => TweetCreateResponseStatus.Failed,
            "expired" => TweetCreateResponseStatus.Expired,
            _ => (TweetCreateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetCreateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetCreateResponseStatus.Accepted => "accepted",
                TweetCreateResponseStatus.Dispatching => "dispatching",
                TweetCreateResponseStatus.PendingConfirmation => "pending_confirmation",
                TweetCreateResponseStatus.Success => "success",
                TweetCreateResponseStatus.Failed => "failed",
                TweetCreateResponseStatus.Expired => "expired",
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
[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
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

    public required ApiEnum<string, TargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TargetType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public Target() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Target(Target target)
        : base(target) { }
#pragma warning restore CS8618

    public Target(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Target(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetFromRaw.FromRawUnchecked"/>
    public static Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetFromRaw : IFromRawJson<Target>
{
    /// <inheritdoc/>
    public Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Target.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TargetTypeConverter))]
public enum TargetType
{
    Tweet,
    User,
    Community,
}

sealed class TargetTypeConverter : JsonConverter<TargetType>
{
    public override TargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => TargetType.Tweet,
            "user" => TargetType.User,
            "community" => TargetType.Community,
            _ => (TargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TargetType.Tweet => "tweet",
                TargetType.User => "user",
                TargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
