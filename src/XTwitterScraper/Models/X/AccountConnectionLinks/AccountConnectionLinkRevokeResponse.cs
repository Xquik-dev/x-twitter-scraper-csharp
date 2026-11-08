// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.AccountConnectionLinks;

[JsonConverter(
    typeof(JsonModelConverter<
        AccountConnectionLinkRevokeResponse,
        AccountConnectionLinkRevokeResponseFromRaw
    >)
)]
public sealed record class AccountConnectionLinkRevokeResponse : JsonModel
{
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
    }

    public AccountConnectionLinkRevokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkRevokeResponse(
        AccountConnectionLinkRevokeResponse accountConnectionLinkRevokeResponse
    )
        : base(accountConnectionLinkRevokeResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkRevokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConnectionLinkRevokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConnectionLinkRevokeResponseFromRaw.FromRawUnchecked"/>
    public static AccountConnectionLinkRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConnectionLinkRevokeResponseFromRaw : IFromRawJson<AccountConnectionLinkRevokeResponse>
{
    /// <inheritdoc/>
    public AccountConnectionLinkRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConnectionLinkRevokeResponse.FromRawUnchecked(rawData);
}
