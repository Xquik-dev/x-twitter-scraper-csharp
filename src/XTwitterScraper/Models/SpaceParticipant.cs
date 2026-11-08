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

[JsonConverter(typeof(JsonModelConverter<SpaceParticipant, SpaceParticipantFromRaw>))]
public sealed record class SpaceParticipant : JsonModel
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

    /// <summary>
    /// Name the account shows in the Space
    /// </summary>
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
    /// Profile picture URL
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
    /// The participant's profile picture at full size
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

    /// <summary>
    /// Whether X shows a verified badge in the Space
    /// </summary>
    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    /// <summary>
    /// Whether the account has X Premium verification
    /// </summary>
    public bool? IsBlueVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBlueVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBlueVerified", value);
        }
    }

    /// <summary>
    /// Business or Government badge type
    /// </summary>
    public string? VerifiedType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Organization affiliation label shown on an X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserAffiliateLabel? AffiliatesHighlightedLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserAffiliateLabel>(
                "affiliatesHighlightedLabel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("affiliatesHighlightedLabel", value);
        }
    }

    /// <summary>
    /// When the account joined the Space
    /// </summary>
    public DateTimeOffset? JoinedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("joinedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("joinedAt", value);
        }
    }

    /// <summary>
    /// Whether a host muted the account
    /// </summary>
    public bool? IsMutedByAdmin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isMutedByAdmin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isMutedByAdmin", value);
        }
    }

    /// <summary>
    /// Whether the account muted itself
    /// </summary>
    public bool? IsMutedByGuest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isMutedByGuest");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isMutedByGuest", value);
        }
    }

    /// <summary>
    /// The account's ID in X's broadcast service
    /// </summary>
    public string? PeriscopeUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("periscopeUserId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("periscopeUserId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.Name;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
        _ = this.IsVerified;
        _ = this.IsBlueVerified;
        _ = this.VerifiedType;
        this.AffiliatesHighlightedLabel?.Validate();
        _ = this.JoinedAt;
        _ = this.IsMutedByAdmin;
        _ = this.IsMutedByGuest;
        _ = this.PeriscopeUserID;
    }

    public SpaceParticipant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceParticipant(SpaceParticipant spaceParticipant)
        : base(spaceParticipant) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceParticipant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceParticipant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceParticipantFromRaw.FromRawUnchecked"/>
    public static SpaceParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceParticipantFromRaw : IFromRawJson<SpaceParticipant>
{
    /// <inheritdoc/>
    public SpaceParticipant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpaceParticipant.FromRawUnchecked(rawData);
}
