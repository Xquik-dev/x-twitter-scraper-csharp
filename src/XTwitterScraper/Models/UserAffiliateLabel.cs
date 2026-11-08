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

[JsonConverter(typeof(JsonModelConverter<UserAffiliateLabel, UserAffiliateLabelFromRaw>))]
public sealed record class UserAffiliateLabel : JsonModel
{
    /// <summary>
    /// More labels X shows beside the affiliation, such as an automated account's owner.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.UserAuxiliaryLabel>? AuxiliaryLabels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.UserAuxiliaryLabel>
            >("auxiliaryLabels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.UserAuxiliaryLabel>?>(
                "auxiliaryLabels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    /// <summary>
    /// Public text, ranges, references, and mention data.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LongDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "longDescription"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "longDescription",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlType", value);
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
        foreach (var item in this.AuxiliaryLabels ?? [])
        {
            item.Validate();
        }
        _ = this.BadgeUrl;
        _ = this.Description;
        _ = this.LongDescription;
        _ = this.UrlValue;
        _ = this.UrlType;
        _ = this.UserLabelDisplayType;
        _ = this.UserLabelType;
    }

    public UserAffiliateLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAffiliateLabel(UserAffiliateLabel userAffiliateLabel)
        : base(userAffiliateLabel) { }
#pragma warning restore CS8618

    public UserAffiliateLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAffiliateLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserAffiliateLabelFromRaw.FromRawUnchecked"/>
    public static UserAffiliateLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserAffiliateLabelFromRaw : IFromRawJson<UserAffiliateLabel>
{
    /// <inheritdoc/>
    public UserAffiliateLabel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserAffiliateLabel.FromRawUnchecked(rawData);
}
