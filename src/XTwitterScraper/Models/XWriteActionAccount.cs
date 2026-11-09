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

[JsonConverter(typeof(JsonModelConverter<XWriteActionAccount, XWriteActionAccountFromRaw>))]
public sealed record class XWriteActionAccount : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
    }

    public XWriteActionAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionAccount(XWriteActionAccount xWriteActionAccount)
        : base(xWriteActionAccount) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteActionAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionAccountFromRaw.FromRawUnchecked"/>
    public static XWriteActionAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionAccountFromRaw : IFromRawJson<XWriteActionAccount>
{
    /// <inheritdoc/>
    public XWriteActionAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XWriteActionAccount.FromRawUnchecked(rawData);
}
