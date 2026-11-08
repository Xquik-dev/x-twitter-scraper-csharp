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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<Space, SpaceFromRaw>))]
public sealed record class Space : JsonModel
{
    /// <summary>
    /// Space ID
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
    /// Space title
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
    /// NotStarted (scheduled), Running (live), Ended, Canceled (scheduled, never started) or TimedOut (closed by X, not by its host)
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
    /// When the Space was made
    /// </summary>
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

    /// <summary>
    /// When the Space was set to start
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
    /// When the Space went live
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
    /// When the Space ended
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
    /// When X last changed the Space
    /// </summary>
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

    /// <summary>
    /// Accounts that listened live
    /// </summary>
    public long? TotalLiveListeners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalLiveListeners");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalLiveListeners", value);
        }
    }

    /// <summary>
    /// Accounts that played the recording
    /// </summary>
    public long? TotalReplayWatched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalReplayWatched");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalReplayWatched", value);
        }
    }

    /// <summary>
    /// Accounts in the Space now, while it is live
    /// </summary>
    public long? ParticipantCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("participantCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("participantCount", value);
        }
    }

    /// <summary>
    /// Whether X offers a recording
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
    /// Whether listeners may clip the Space
    /// </summary>
    public bool? IsAvailableForClipping
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isAvailableForClipping");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isAvailableForClipping", value);
        }
    }

    /// <summary>
    /// Whether the host locked the Space
    /// </summary>
    public bool? IsLocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isLocked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isLocked", value);
        }
    }

    /// <summary>
    /// Whether only X employees may join
    /// </summary>
    public bool? IsEmployeeOnly
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isEmployeeOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isEmployeeOnly", value);
        }
    }

    /// <summary>
    /// Whether X lets no more accounts join
    /// </summary>
    public bool? DisallowJoin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disallowJoin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disallowJoin", value);
        }
    }

    /// <summary>
    /// Whether anonymous listening is off
    /// </summary>
    public bool? NoIncognito
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("noIncognito");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("noIncognito", value);
        }
    }

    /// <summary>
    /// Audio or video kind, as X names it
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contentType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentType", value);
        }
    }

    /// <summary>
    /// X's code for who may speak
    /// </summary>
    public long? ConversationControls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("conversationControls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationControls", value);
        }
    }

    /// <summary>
    /// Most hosts and co-hosts the Space allows
    /// </summary>
    public long? MaxAdminCapacity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxAdminCapacity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxAdminCapacity", value);
        }
    }

    /// <summary>
    /// X's media key for the Space's audio
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
    /// IDs of the accounts the host tagged
    /// </summary>
    public IReadOnlyList<string>? MentionedUserIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("mentionedUserIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "mentionedUserIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the post that announces the Space
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

    /// <summary>
    /// Hosts and co-hosts
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SpaceParticipant> Admins
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>
            >("admins");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>>(
                "admins",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Accounts X lists as speakers
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SpaceParticipant> Speakers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>
            >("speakers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>>(
                "speakers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Accounts X lists as listeners
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SpaceParticipant> Listeners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>
            >("listeners");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SpaceParticipant>>(
                "listeners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts the hosts and speakers shared in the Space, in X's order. Present only when X lists them.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.SpaceSharing>? Sharings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.SpaceSharing>
            >("sharings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SpaceSharing>?>(
                "sharings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
        _ = this.State;
        _ = this.CreatedAt;
        _ = this.ScheduledStart;
        _ = this.StartedAt;
        _ = this.EndedAt;
        _ = this.UpdatedAt;
        _ = this.TotalLiveListeners;
        _ = this.TotalReplayWatched;
        _ = this.ParticipantCount;
        _ = this.IsAvailableForReplay;
        _ = this.IsAvailableForClipping;
        _ = this.IsLocked;
        _ = this.IsEmployeeOnly;
        _ = this.DisallowJoin;
        _ = this.NoIncognito;
        _ = this.ContentType;
        _ = this.ConversationControls;
        _ = this.MaxAdminCapacity;
        _ = this.MediaKey;
        _ = this.MentionedUserIDs;
        _ = this.TweetID;
        this.Tweet?.Validate();
        this.Creator?.Validate();
        foreach (var item in this.Admins)
        {
            item.Validate();
        }
        foreach (var item in this.Speakers)
        {
            item.Validate();
        }
        foreach (var item in this.Listeners)
        {
            item.Validate();
        }
        foreach (var item in this.Sharings ?? [])
        {
            item.Validate();
        }
    }

    public Space() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Space(Space space)
        : base(space) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Space(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Space(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceFromRaw.FromRawUnchecked"/>
    public static Space FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceFromRaw : IFromRawJson<Space>
{
    /// <inheritdoc/>
    public Space FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Space.FromRawUnchecked(rawData);
}
