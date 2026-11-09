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

[JsonConverter(typeof(JsonModelConverter<SpaceSharing, SpaceSharingFromRaw>))]
public sealed record class SpaceSharing : JsonModel
{
    /// <summary>
    /// X's ID of the sharing, not of the post
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
    /// When the post was shared
    /// </summary>
    public DateTimeOffset? SharedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("sharedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sharedAt", value);
        }
    }

    /// <summary>
    /// When X last changed the sharing
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
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? SharedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "sharedBy"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sharedBy", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SharedAt;
        _ = this.UpdatedAt;
        this.SharedBy?.Validate();
        this.Tweet?.Validate();
    }

    public SpaceSharing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceSharing(SpaceSharing spaceSharing)
        : base(spaceSharing) { }
#pragma warning restore CS8618

    public SpaceSharing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceSharing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceSharingFromRaw.FromRawUnchecked"/>
    public static SpaceSharing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceSharingFromRaw : IFromRawJson<SpaceSharing>
{
    /// <inheritdoc/>
    public SpaceSharing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpaceSharing.FromRawUnchecked(rawData);
}
