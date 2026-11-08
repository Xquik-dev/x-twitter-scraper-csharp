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

[JsonConverter(typeof(JsonModelConverter<UserAuxiliaryLabel, UserAuxiliaryLabelFromRaw>))]
public sealed record class UserAuxiliaryLabel : JsonModel
{
    public string? BadgeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("badgeUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("badgeUrl", value);
        }
    }

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

    public string? UrlValue
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

    public string? UserLabelDisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userLabelDisplayType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userLabelDisplayType", value);
        }
    }

    public string? UserLabelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userLabelType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userLabelType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BadgeUrl;
        _ = this.Description;
        _ = this.UrlValue;
        _ = this.UserLabelDisplayType;
        _ = this.UserLabelType;
    }

    public UserAuxiliaryLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAuxiliaryLabel(UserAuxiliaryLabel userAuxiliaryLabel)
        : base(userAuxiliaryLabel) { }
#pragma warning restore CS8618

    public UserAuxiliaryLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAuxiliaryLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserAuxiliaryLabelFromRaw.FromRawUnchecked"/>
    public static UserAuxiliaryLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserAuxiliaryLabelFromRaw : IFromRawJson<UserAuxiliaryLabel>
{
    /// <inheritdoc/>
    public UserAuxiliaryLabel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserAuxiliaryLabel.FromRawUnchecked(rawData);
}
