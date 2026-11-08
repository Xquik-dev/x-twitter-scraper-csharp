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

[JsonConverter(typeof(JsonModelConverter<JobAccount, JobAccountFromRaw>))]
public sealed record class JobAccount : JsonModel
{
    /// <summary>
    /// X user ID of the account.
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
    /// Handle without @.
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
    /// Display name of the account that posted the job.
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
    /// Whether X shows a verification badge on the account.
    /// </summary>
    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

    /// <summary>
    /// Badge type, such as Business or Government.
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
    /// Bio of the account. A job lookup returns it.
    /// </summary>
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
    /// Avatar URL of the account that posted the job.
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
    /// The job account's avatar at full size.
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
    /// Avatar shape, such as Circle or Square.
    /// </summary>
    public string? ProfileImageShape
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileImageShape");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileImageShape", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.Name;
        _ = this.Verified;
        _ = this.VerifiedType;
        _ = this.Description;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
        _ = this.ProfileImageShape;
    }

    public JobAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobAccount(JobAccount jobAccount)
        : base(jobAccount) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobAccountFromRaw.FromRawUnchecked"/>
    public static JobAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobAccountFromRaw : IFromRawJson<JobAccount>
{
    /// <inheritdoc/>
    public JobAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobAccount.FromRawUnchecked(rawData);
}
