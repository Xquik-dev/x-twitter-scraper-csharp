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

[JsonConverter(typeof(JsonModelConverter<XList, XListFromRaw>))]
public sealed record class XList : JsonModel
{
    /// <summary>
    /// Numeric ID of the List.
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
    /// Name the owner gave the List.
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
    /// About text of the List. Empty when the owner wrote none.
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
    /// Accounts on the List.
    /// </summary>
    public long? MemberCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("memberCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memberCount", value);
        }
    }

    /// <summary>
    /// Accounts that follow the List, which X calls followers.
    /// </summary>
    public long? SubscriberCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("subscriberCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscriberCount", value);
        }
    }

    /// <summary>
    /// Public profile of the account that owns the List.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "owner"
            );
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

    /// <summary>
    /// List page on x.com.
    /// </summary>
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

    /// <summary>
    /// When the owner made the List.
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
    /// URL of the banner the owner uploaded. Absent when the owner uploaded none.
    /// </summary>
    public string? BannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bannerUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bannerUrl", value);
        }
    }

    /// <summary>
    /// Banner the owner uploaded.
    /// </summary>
    public global::XTwitterScraper.Models.XListBanner? CustomBanner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XListBanner>(
                "customBanner"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customBanner", value);
        }
    }

    /// <summary>
    /// Banner X shows when the owner uploaded none. It can differ between calls.
    /// </summary>
    public global::XTwitterScraper.Models.XListBanner? DefaultBanner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.XListBanner>(
                "defaultBanner"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultBanner", value);
        }
    }

    /// <summary>
    /// Avatar URLs of a few List members, which X may pick per request.
    /// </summary>
    public IReadOnlyList<string>? FacepileUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("facepileUrls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "facepileUrls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Member count as X words it, such as 35 members.
    /// </summary>
    public string? MembersContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("membersContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("membersContext", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Description;
        _ = this.MemberCount;
        _ = this.SubscriberCount;
        this.Owner?.Validate();
        _ = this.UrlValue;
        _ = this.CreatedAt;
        _ = this.BannerUrl;
        this.CustomBanner?.Validate();
        this.DefaultBanner?.Validate();
        _ = this.FacepileUrls;
        _ = this.MembersContext;
    }

    public XList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XList(XList xList)
        : base(xList) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XListFromRaw.FromRawUnchecked"/>
    public static XList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XListFromRaw : IFromRawJson<XList>
{
    /// <inheritdoc/>
    public XList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XList.FromRawUnchecked(rawData);
}
