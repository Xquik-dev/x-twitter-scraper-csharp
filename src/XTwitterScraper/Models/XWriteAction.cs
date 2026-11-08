// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(XWriteActionObjectConverter))]
public enum XWriteActionObject
{
    XWriteAction,
}

sealed class XWriteActionObjectConverter : JsonConverter<XWriteActionObject>
{
    public override XWriteActionObject Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x_write_action" => XWriteActionObject.XWriteAction,
            _ => (XWriteActionObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionObject.XWriteAction => "x_write_action",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(XWriteActionActionConverter))]
public enum XWriteActionAction
{
    CreateTweet,
    DeleteTweet,
    Like,
    Unlike,
    Retweet,
    Unretweet,
    Bookmark,
    Unbookmark,
    Follow,
    Unfollow,
    Block,
    Unblock,
    Mute,
    Unmute,
    RemoveFollower,
    SendDm,
    DeleteDm,
    UploadMedia,
    UpdateProfile,
    UpdateAvatar,
    UpdateBanner,
    CreateCommunity,
    DeleteCommunity,
    JoinCommunity,
    LeaveCommunity,
}

sealed class XWriteActionActionConverter : JsonConverter<XWriteActionAction>
{
    public override XWriteActionAction Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_tweet" => XWriteActionAction.CreateTweet,
            "delete_tweet" => XWriteActionAction.DeleteTweet,
            "like" => XWriteActionAction.Like,
            "unlike" => XWriteActionAction.Unlike,
            "retweet" => XWriteActionAction.Retweet,
            "unretweet" => XWriteActionAction.Unretweet,
            "bookmark" => XWriteActionAction.Bookmark,
            "unbookmark" => XWriteActionAction.Unbookmark,
            "follow" => XWriteActionAction.Follow,
            "unfollow" => XWriteActionAction.Unfollow,
            "block" => XWriteActionAction.Block,
            "unblock" => XWriteActionAction.Unblock,
            "mute" => XWriteActionAction.Mute,
            "unmute" => XWriteActionAction.Unmute,
            "remove_follower" => XWriteActionAction.RemoveFollower,
            "send_dm" => XWriteActionAction.SendDm,
            "delete_dm" => XWriteActionAction.DeleteDm,
            "upload_media" => XWriteActionAction.UploadMedia,
            "update_profile" => XWriteActionAction.UpdateProfile,
            "update_avatar" => XWriteActionAction.UpdateAvatar,
            "update_banner" => XWriteActionAction.UpdateBanner,
            "create_community" => XWriteActionAction.CreateCommunity,
            "delete_community" => XWriteActionAction.DeleteCommunity,
            "join_community" => XWriteActionAction.JoinCommunity,
            "leave_community" => XWriteActionAction.LeaveCommunity,
            _ => (XWriteActionAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionAction.CreateTweet => "create_tweet",
                XWriteActionAction.DeleteTweet => "delete_tweet",
                XWriteActionAction.Like => "like",
                XWriteActionAction.Unlike => "unlike",
                XWriteActionAction.Retweet => "retweet",
                XWriteActionAction.Unretweet => "unretweet",
                XWriteActionAction.Bookmark => "bookmark",
                XWriteActionAction.Unbookmark => "unbookmark",
                XWriteActionAction.Follow => "follow",
                XWriteActionAction.Unfollow => "unfollow",
                XWriteActionAction.Block => "block",
                XWriteActionAction.Unblock => "unblock",
                XWriteActionAction.Mute => "mute",
                XWriteActionAction.Unmute => "unmute",
                XWriteActionAction.RemoveFollower => "remove_follower",
                XWriteActionAction.SendDm => "send_dm",
                XWriteActionAction.DeleteDm => "delete_dm",
                XWriteActionAction.UploadMedia => "upload_media",
                XWriteActionAction.UpdateProfile => "update_profile",
                XWriteActionAction.UpdateAvatar => "update_avatar",
                XWriteActionAction.UpdateBanner => "update_banner",
                XWriteActionAction.CreateCommunity => "create_community",
                XWriteActionAction.DeleteCommunity => "delete_community",
                XWriteActionAction.JoinCommunity => "join_community",
                XWriteActionAction.LeaveCommunity => "leave_community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(XWriteActionStatusConverter))]
public enum XWriteActionStatus
{
    Accepted,
    Dispatching,
    PendingConfirmation,
    Success,
    Failed,
    Expired,
}

sealed class XWriteActionStatusConverter : JsonConverter<XWriteActionStatus>
{
    public override XWriteActionStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => XWriteActionStatus.Accepted,
            "dispatching" => XWriteActionStatus.Dispatching,
            "pending_confirmation" => XWriteActionStatus.PendingConfirmation,
            "success" => XWriteActionStatus.Success,
            "failed" => XWriteActionStatus.Failed,
            "expired" => XWriteActionStatus.Expired,
            _ => (XWriteActionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionStatus.Accepted => "accepted",
                XWriteActionStatus.Dispatching => "dispatching",
                XWriteActionStatus.PendingConfirmation => "pending_confirmation",
                XWriteActionStatus.Success => "success",
                XWriteActionStatus.Failed => "failed",
                XWriteActionStatus.Expired => "expired",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XWriteAction, XWriteActionFromRaw>))]
public sealed record class XWriteAction : JsonModel
{
    public required ApiEnum<string, XWriteActionObject> Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionObject>>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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

    public required ApiEnum<string, XWriteActionAction> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionAction>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public required ApiEnum<string, XWriteActionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
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

    /// <summary>
    /// True only when a new attempt is likely to succeed.
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
    /// True only when X did not get the write and a new idempotency key may be used.
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

    public required string StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statusUrl");
        }
        init { this._rawData.Set("statusUrl", value); }
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
    /// plannedCredits is the approved maximum. chargedCredits comes from the settled credit ledger. Xquik charges nothing for pending or failed writes.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionBilling Billing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.XWriteActionBilling>(
                "billing"
            );
        }
        init { this._rawData.Set("billing", value); }
    }

    /// <summary>
    /// Stable fingerprint and sanitized payload for replay checks.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.XWriteActionRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Connected account selected for the write.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XWriteActionAccount>(
                "account"
            );
        }
        init { this._rawData.Set("account", value); }
    }

    /// <summary>
    /// Existing X resource targeted by the write, when applicable.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionTarget? Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XWriteActionTarget>(
                "target"
            );
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

    /// <summary>
    /// Confirmed result produced by the write, when available.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XWriteActionResult>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Exact follow-up an API client or agent should perform.
    /// </summary>
    public required global::XTwitterScraper.Models.XWriteActionNextAction? NextAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XWriteActionNextAction>(
                "nextAction"
            );
        }
        init { this._rawData.Set("nextAction", value); }
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
    /// True when this answers a retry of an earlier request with the same Idempotency-Key.
    /// </summary>
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

    public required bool SendDispatched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("sendDispatched");
        }
        init { this._rawData.Set("sendDispatched", value); }
    }

    /// <summary>
    /// Dispatch timestamp when the write reached execution.
    /// </summary>
    public DateTimeOffset? SendDispatchedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("sendDispatchedAt");
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

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
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

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
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

    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
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

    /// <summary>
    /// Deadline for resolving a non-terminal write. This is not the Idempotency-Key retention deadline.
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expiresAt");
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

    public DateTimeOffset? ConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("confirmedAt");
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

    public DateTimeOffset? ConfirmationCheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("confirmationCheckedAt");
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

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Object.Validate();
        _ = this.ID;
        _ = this.WriteActionID;
        this.Action.Validate();
        this.Status.Validate();
        _ = this.Terminal;
        _ = this.Retryable;
        _ = this.SafeToRetry;
        _ = this.StatusUrl;
        _ = this.PollAfterMs;
        _ = this.Charged;
        _ = this.ChargedCredits;
        this.Billing.Validate();
        this.Request.Validate();
        this.Account?.Validate();
        this.Target?.Validate();
        _ = this.TargetID;
        this.Result?.Validate();
        this.NextAction?.Validate();
        _ = this.RequestHash;
        _ = this.RequestID;
        _ = this.Idempotent;
        _ = this.Error;
        _ = this.Message;
        _ = this.SendDispatched;
        _ = this.SendDispatchedAt;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        _ = this.CompletedAt;
        _ = this.ExpiresAt;
        _ = this.ConfirmedAt;
        _ = this.ConfirmationCheckedAt;
        _ = this.ConfirmationAttempts;
        _ = this.TweetID;
        _ = this.MessageID;
        _ = this.MediaID;
        _ = this.MediaUrl;
        _ = this.CommunityID;
        _ = this.CommunityName;
        _ = this.ResultID;
        _ = this.Media;
        _ = this.Details;
        _ = this.Success;
    }

    public XWriteAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteAction(XWriteAction xWriteAction)
        : base(xWriteAction) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionFromRaw.FromRawUnchecked"/>
    public static XWriteAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionFromRaw : IFromRawJson<XWriteAction>
{
    /// <inheritdoc/>
    public XWriteAction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XWriteAction.FromRawUnchecked(rawData);
}
