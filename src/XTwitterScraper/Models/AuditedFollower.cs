// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<AuditedFollower, AuditedFollowerFromRaw>))]
public sealed record class AuditedFollower : JsonModel
{
    /// <summary>
    /// What 1 follower looks like from its public profile.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.FollowerClass> Class
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.FollowerClass>
            >("class");
        }
        init { this._rawData.Set("class", value); }
    }

    public required long Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("followers");
        }
        init { this._rawData.Set("followers", value); }
    }

    public required long Following
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("following");
        }
        init { this._rawData.Set("following", value); }
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

    public long? JoinedAtMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("joinedAtMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("joinedAtMs", value);
        }
    }

    public required long Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("likes");
        }
        init { this._rawData.Set("likes", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Account that runs an automated follower, when X names it.
    /// </summary>
    public string? Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("owner");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("owner", value);
        }
    }

    public string? PictureUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pictureUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pictureUrl", value);
        }
    }

    public required long Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("position");
        }
        init { this._rawData.Set("position", value); }
    }

    public required long Posts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("posts");
        }
        init { this._rawData.Set("posts", value); }
    }

    public required long Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    public required IReadOnlyList<string> Signals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("signals");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "signals",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string UserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userName");
        }
        init { this._rawData.Set("userName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Class.Validate();
        _ = this.Followers;
        _ = this.Following;
        _ = this.ID;
        _ = this.JoinedAtMs;
        _ = this.Likes;
        _ = this.Name;
        _ = this.Owner;
        _ = this.PictureUrl;
        _ = this.Position;
        _ = this.Posts;
        _ = this.Score;
        _ = this.Signals;
        _ = this.UserName;
    }

    public AuditedFollower() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuditedFollower(AuditedFollower auditedFollower)
        : base(auditedFollower) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuditedFollower(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditedFollower(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuditedFollowerFromRaw.FromRawUnchecked"/>
    public static AuditedFollower FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditedFollowerFromRaw : IFromRawJson<AuditedFollower>
{
    /// <inheritdoc/>
    public AuditedFollower FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuditedFollower.FromRawUnchecked(rawData);
}
