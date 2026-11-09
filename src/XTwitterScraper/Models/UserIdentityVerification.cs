// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<UserIdentityVerification, UserIdentityVerificationFromRaw>)
)]
public sealed record class UserIdentityVerification : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Whether the owner verified their ID with X.
    /// </summary>
    public bool? IsIdentityVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isIdentityVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isIdentityVerified", value);
        }
    }

    /// <summary>
    /// The year X shows as the start of verification, in place of verifiedSinceMsec.
    /// </summary>
    public long? OverrideVerifiedYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("overrideVerifiedYear");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overrideVerifiedYear", value);
        }
    }

    /// <summary>
    /// When X verified the account, in milliseconds since 1970, as text.
    /// </summary>
    public string? VerifiedSinceMsec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedSinceMsec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedSinceMsec", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.IsIdentityVerified;
        _ = this.OverrideVerifiedYear;
        _ = this.VerifiedSinceMsec;
    }

    public UserIdentityVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserIdentityVerification(UserIdentityVerification userIdentityVerification)
        : base(userIdentityVerification) { }
#pragma warning restore CS8618

    public UserIdentityVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserIdentityVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserIdentityVerificationFromRaw.FromRawUnchecked"/>
    public static UserIdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserIdentityVerificationFromRaw : IFromRawJson<UserIdentityVerification>
{
    /// <inheritdoc/>
    public UserIdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserIdentityVerification.FromRawUnchecked(rawData);
}
