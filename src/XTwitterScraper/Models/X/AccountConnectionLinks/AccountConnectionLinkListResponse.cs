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

namespace XTwitterScraper.Models.X.AccountConnectionLinks;

[JsonConverter(
    typeof(JsonModelConverter<
        AccountConnectionLinkListResponse,
        AccountConnectionLinkListResponseFromRaw
    >)
)]
public sealed record class AccountConnectionLinkListResponse : JsonModel
{
    public required IReadOnlyList<XAccountConnectionLink> Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<XAccountConnectionLink>>("links");
        }
        init
        {
            this._rawData.Set<ImmutableArray<XAccountConnectionLink>>(
                "links",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Links)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public AccountConnectionLinkListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkListResponse(
        AccountConnectionLinkListResponse accountConnectionLinkListResponse
    )
        : base(accountConnectionLinkListResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConnectionLinkListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConnectionLinkListResponseFromRaw.FromRawUnchecked"/>
    public static AccountConnectionLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConnectionLinkListResponseFromRaw : IFromRawJson<AccountConnectionLinkListResponse>
{
    /// <inheritdoc/>
    public AccountConnectionLinkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConnectionLinkListResponse.FromRawUnchecked(rawData);
}
