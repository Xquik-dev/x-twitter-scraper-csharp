// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Monitors;

[JsonConverter(
    typeof(JsonModelConverter<
        MonitorUpsertByUsernameResponse,
        MonitorUpsertByUsernameResponseFromRaw
    >)
)]
public sealed record class MonitorUpsertByUsernameResponse : JsonModel
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

    public required string XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUserId");
        }
        init { this._rawData.Set("xUserId", value); }
    }

    /// <summary>
    /// Customer-set label of the account monitor, when set.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, MonitorUpsertByUsernameResponseEventTypes>
    > EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, MonitorUpsertByUsernameResponseEventTypes>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, MonitorUpsertByUsernameResponseEventTypes>>
            >("eventTypes", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Next hourly credit charge time for this account monitor.
    /// </summary>
    public required DateTimeOffset NextBillingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("nextBillingAt");
        }
        init { this._rawData.Set("nextBillingAt", value); }
    }

    /// <summary>
    /// Why Xquik paused this account monitor. `insufficient_credits` means the balance could not pay an hour, so add credits &amp; resume. The other 2 mean X stopped showing the account. Absent when the monitor is active or you paused it yourself.
    /// </summary>
    public ApiEnum<string, MonitorUpsertByUsernameResponsePausedReason>? PausedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, MonitorUpsertByUsernameResponsePausedReason>
            >("pausedReason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedReason", value);
        }
    }

    /// <summary>
    /// When Xquik paused this account monitor.
    /// </summary>
    public DateTimeOffset? PausedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("pausedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedAt", value);
        }
    }

    /// <summary>
    /// False, since this call updated a running monitor.
    /// </summary>
    public required bool Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.XUserID;
        _ = this.Name;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.IsActive;
        _ = this.CreatedAt;
        _ = this.NextBillingAt;
        this.PausedReason?.Validate();
        _ = this.PausedAt;
        _ = this.Created;
    }

    public MonitorUpsertByUsernameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorUpsertByUsernameResponse(
        MonitorUpsertByUsernameResponse monitorUpsertByUsernameResponse
    )
        : base(monitorUpsertByUsernameResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorUpsertByUsernameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorUpsertByUsernameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorUpsertByUsernameResponseFromRaw.FromRawUnchecked"/>
    public static MonitorUpsertByUsernameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorUpsertByUsernameResponseFromRaw : IFromRawJson<MonitorUpsertByUsernameResponse>
{
    /// <inheritdoc/>
    public MonitorUpsertByUsernameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorUpsertByUsernameResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorUpsertByUsernameResponseEventTypesConverter))]
public enum MonitorUpsertByUsernameResponseEventTypes
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    TweetMedia,
    TweetLink,
    TweetPoll,
    TweetMention,
    TweetHashtag,
    TweetLongform,
    ProfileAvatarChanged,
    ProfileBannerChanged,
    ProfileNameChanged,
    ProfileUsernameChanged,
    ProfileBioChanged,
    ProfileLocationChanged,
    ProfileUrlChanged,
    ProfileVerifiedChanged,
    ProfileProtectedChanged,
    ProfilePinnedTweetChanged,
    ProfileUnavailableChanged,
    TweetDeleted,
    BroadcastStarted,
    SpaceStarted,
    FollowingAdded,
    FollowingRemoved,
    FollowerAdded,
    FollowerRemoved,
    ProfileFollowersChanged,
    ProfileFollowingChanged,
}

sealed class MonitorUpsertByUsernameResponseEventTypesConverter
    : JsonConverter<MonitorUpsertByUsernameResponseEventTypes>
{
    public override MonitorUpsertByUsernameResponseEventTypes Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => MonitorUpsertByUsernameResponseEventTypes.TweetNew,
            "tweet.reply" => MonitorUpsertByUsernameResponseEventTypes.TweetReply,
            "tweet.retweet" => MonitorUpsertByUsernameResponseEventTypes.TweetRetweet,
            "tweet.quote" => MonitorUpsertByUsernameResponseEventTypes.TweetQuote,
            "tweet.media" => MonitorUpsertByUsernameResponseEventTypes.TweetMedia,
            "tweet.link" => MonitorUpsertByUsernameResponseEventTypes.TweetLink,
            "tweet.poll" => MonitorUpsertByUsernameResponseEventTypes.TweetPoll,
            "tweet.mention" => MonitorUpsertByUsernameResponseEventTypes.TweetMention,
            "tweet.hashtag" => MonitorUpsertByUsernameResponseEventTypes.TweetHashtag,
            "tweet.longform" => MonitorUpsertByUsernameResponseEventTypes.TweetLongform,
            "profile.avatar.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileAvatarChanged,
            "profile.banner.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileBannerChanged,
            "profile.name.changed" => MonitorUpsertByUsernameResponseEventTypes.ProfileNameChanged,
            "profile.username.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileUsernameChanged,
            "profile.bio.changed" => MonitorUpsertByUsernameResponseEventTypes.ProfileBioChanged,
            "profile.location.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileLocationChanged,
            "profile.url.changed" => MonitorUpsertByUsernameResponseEventTypes.ProfileUrlChanged,
            "profile.verified.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileVerifiedChanged,
            "profile.protected.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileProtectedChanged,
            "profile.pinned_tweet.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfilePinnedTweetChanged,
            "profile.unavailable.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileUnavailableChanged,
            "tweet.deleted" => MonitorUpsertByUsernameResponseEventTypes.TweetDeleted,
            "broadcast.started" => MonitorUpsertByUsernameResponseEventTypes.BroadcastStarted,
            "space.started" => MonitorUpsertByUsernameResponseEventTypes.SpaceStarted,
            "following.added" => MonitorUpsertByUsernameResponseEventTypes.FollowingAdded,
            "following.removed" => MonitorUpsertByUsernameResponseEventTypes.FollowingRemoved,
            "follower.added" => MonitorUpsertByUsernameResponseEventTypes.FollowerAdded,
            "follower.removed" => MonitorUpsertByUsernameResponseEventTypes.FollowerRemoved,
            "profile.followers.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileFollowersChanged,
            "profile.following.changed" =>
                MonitorUpsertByUsernameResponseEventTypes.ProfileFollowingChanged,
            _ => (MonitorUpsertByUsernameResponseEventTypes)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorUpsertByUsernameResponseEventTypes value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorUpsertByUsernameResponseEventTypes.TweetNew => "tweet.new",
                MonitorUpsertByUsernameResponseEventTypes.TweetReply => "tweet.reply",
                MonitorUpsertByUsernameResponseEventTypes.TweetRetweet => "tweet.retweet",
                MonitorUpsertByUsernameResponseEventTypes.TweetQuote => "tweet.quote",
                MonitorUpsertByUsernameResponseEventTypes.TweetMedia => "tweet.media",
                MonitorUpsertByUsernameResponseEventTypes.TweetLink => "tweet.link",
                MonitorUpsertByUsernameResponseEventTypes.TweetPoll => "tweet.poll",
                MonitorUpsertByUsernameResponseEventTypes.TweetMention => "tweet.mention",
                MonitorUpsertByUsernameResponseEventTypes.TweetHashtag => "tweet.hashtag",
                MonitorUpsertByUsernameResponseEventTypes.TweetLongform => "tweet.longform",
                MonitorUpsertByUsernameResponseEventTypes.ProfileAvatarChanged =>
                    "profile.avatar.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileBannerChanged =>
                    "profile.banner.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileNameChanged =>
                    "profile.name.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileUsernameChanged =>
                    "profile.username.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileBioChanged =>
                    "profile.bio.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileLocationChanged =>
                    "profile.location.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileUrlChanged =>
                    "profile.url.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileVerifiedChanged =>
                    "profile.verified.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileProtectedChanged =>
                    "profile.protected.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfilePinnedTweetChanged =>
                    "profile.pinned_tweet.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileUnavailableChanged =>
                    "profile.unavailable.changed",
                MonitorUpsertByUsernameResponseEventTypes.TweetDeleted => "tweet.deleted",
                MonitorUpsertByUsernameResponseEventTypes.BroadcastStarted => "broadcast.started",
                MonitorUpsertByUsernameResponseEventTypes.SpaceStarted => "space.started",
                MonitorUpsertByUsernameResponseEventTypes.FollowingAdded => "following.added",
                MonitorUpsertByUsernameResponseEventTypes.FollowingRemoved => "following.removed",
                MonitorUpsertByUsernameResponseEventTypes.FollowerAdded => "follower.added",
                MonitorUpsertByUsernameResponseEventTypes.FollowerRemoved => "follower.removed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileFollowersChanged =>
                    "profile.followers.changed",
                MonitorUpsertByUsernameResponseEventTypes.ProfileFollowingChanged =>
                    "profile.following.changed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MonitorUpsertByUsernameResponsePausedReasonConverter))]
public enum MonitorUpsertByUsernameResponsePausedReason
{
    InsufficientCredits,
    XAccountProtected,
    XUserNotFound,
}

sealed class MonitorUpsertByUsernameResponsePausedReasonConverter
    : JsonConverter<MonitorUpsertByUsernameResponsePausedReason>
{
    public override MonitorUpsertByUsernameResponsePausedReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_credits" =>
                MonitorUpsertByUsernameResponsePausedReason.InsufficientCredits,
            "x_account_protected" => MonitorUpsertByUsernameResponsePausedReason.XAccountProtected,
            "x_user_not_found" => MonitorUpsertByUsernameResponsePausedReason.XUserNotFound,
            _ => (MonitorUpsertByUsernameResponsePausedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorUpsertByUsernameResponsePausedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorUpsertByUsernameResponsePausedReason.InsufficientCredits =>
                    "insufficient_credits",
                MonitorUpsertByUsernameResponsePausedReason.XAccountProtected =>
                    "x_account_protected",
                MonitorUpsertByUsernameResponsePausedReason.XUserNotFound => "x_user_not_found",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
