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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<BroadcastPeriscopeUser, BroadcastPeriscopeUserFromRaw>))]
public sealed record class BroadcastPeriscopeUser : JsonModel
{
    /// <summary>
    /// Live video account ID
    /// </summary>
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

    /// <summary>
    /// Live video username
    /// </summary>
    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <summary>
    /// Live video display name
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Live video avatar URL
    /// </summary>
    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <summary>
    /// The broadcaster's avatar at full size
    /// </summary>
    public string? ProfilePictureOriginal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePictureOriginal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePictureOriginal", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.DisplayName;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
    }

    public BroadcastPeriscopeUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastPeriscopeUser(BroadcastPeriscopeUser broadcastPeriscopeUser)
        : base(broadcastPeriscopeUser) { }
#pragma warning restore CS8618

    public BroadcastPeriscopeUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastPeriscopeUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastPeriscopeUserFromRaw.FromRawUnchecked"/>
    public static BroadcastPeriscopeUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastPeriscopeUserFromRaw : IFromRawJson<BroadcastPeriscopeUser>
{
    /// <inheritdoc/>
    public BroadcastPeriscopeUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastPeriscopeUser.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Broadcast, BroadcastFromRaw>))]
public sealed record class Broadcast : JsonModel
{
    /// <summary>
    /// Broadcast ID
    /// </summary>
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
    /// Broadcast title
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <summary>
    /// Whether the broadcaster edited the title of the replay
    /// </summary>
    public bool? IsTitleEdited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTitleEdited");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTitleEdited", value);
        }
    }

    /// <summary>
    /// State, such as NotStarted, Running or Ended, as X names it
    /// </summary>
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

    /// <summary>
    /// When the broadcast was set to start
    /// </summary>
    public DateTimeOffset? ScheduledStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("scheduledStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduledStart", value);
        }
    }

    /// <summary>
    /// When the broadcast went live
    /// </summary>
    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startedAt", value);
        }
    }

    /// <summary>
    /// When the broadcast ended
    /// </summary>
    public DateTimeOffset? EndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("endedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endedAt", value);
        }
    }

    /// <summary>
    /// When the video stream last reached X
    /// </summary>
    public DateTimeOffset? LastPingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastPingAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastPingAt", value);
        }
    }

    /// <summary>
    /// Accounts that watched, live or after
    /// </summary>
    public long? TotalWatched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalWatched");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalWatched", value);
        }
    }

    /// <summary>
    /// Accounts watching, as X counts them
    /// </summary>
    public long? TotalWatching
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalWatching");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalWatching", value);
        }
    }

    /// <summary>
    /// Whether X offers a recording of the broadcast
    /// </summary>
    public bool? IsAvailableForReplay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isAvailableForReplay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isAvailableForReplay", value);
        }
    }

    /// <summary>
    /// Video width in pixels
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <summary>
    /// Video height in pixels
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Camera rotation in degrees
    /// </summary>
    public long? CameraRotation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cameraRotation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cameraRotation", value);
        }
    }

    /// <summary>
    /// Whether the video stream runs in high-latency mode
    /// </summary>
    public bool? IsHighLatency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isHighLatency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isHighLatency", value);
        }
    }

    /// <summary>
    /// X's code for who may chat
    /// </summary>
    public long? ChatOption
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chatOption");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chatOption", value);
        }
    }

    /// <summary>
    /// Whether X marks the chat private
    /// </summary>
    public bool? IsPrivateChat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPrivateChat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPrivateChat", value);
        }
    }

    /// <summary>
    /// What produced the video stream, as X names it
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// X's media key for the video
    /// </summary>
    public string? MediaKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaKey", value);
        }
    }

    /// <summary>
    /// Image X shows before the broadcast starts
    /// </summary>
    public string? PreLiveSlateUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preLiveSlateUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preLiveSlateUrl", value);
        }
    }

    /// <summary>
    /// X's revision number of the broadcast
    /// </summary>
    public long? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <summary>
    /// ID of the post that announces the broadcast
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
    /// Search tweet with author. Zero metrics may mean X omitted counts.
    /// </summary>
    public global::XTwitterScraper.Models.SearchTweet2? Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.SearchTweet2>(
                "tweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tweet", value);
        }
    }

    /// <summary>
    /// Broadcaster, as X's live video service names the account
    /// </summary>
    public BroadcastPeriscopeUser? PeriscopeUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BroadcastPeriscopeUser>("periscopeUser");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("periscopeUser", value);
        }
    }

    /// <summary>
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "creator"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
        _ = this.IsTitleEdited;
        _ = this.State;
        _ = this.ScheduledStart;
        _ = this.StartedAt;
        _ = this.EndedAt;
        _ = this.LastPingAt;
        _ = this.TotalWatched;
        _ = this.TotalWatching;
        _ = this.IsAvailableForReplay;
        _ = this.Width;
        _ = this.Height;
        _ = this.CameraRotation;
        _ = this.IsHighLatency;
        _ = this.ChatOption;
        _ = this.IsPrivateChat;
        _ = this.Source;
        _ = this.MediaKey;
        _ = this.PreLiveSlateUrl;
        _ = this.Version;
        _ = this.TweetID;
        this.Tweet?.Validate();
        this.PeriscopeUser?.Validate();
        this.Creator?.Validate();
    }

    public Broadcast() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Broadcast(Broadcast broadcast)
        : base(broadcast) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Broadcast(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Broadcast(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastFromRaw.FromRawUnchecked"/>
    public static Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastFromRaw : IFromRawJson<Broadcast>
{
    /// <inheritdoc/>
    public Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Broadcast.FromRawUnchecked(rawData);
}
