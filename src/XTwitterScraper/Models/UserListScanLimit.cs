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

[JsonConverter(typeof(JsonModelConverter<UserListScanLimit, UserListScanLimitFromRaw>))]
public sealed record class UserListScanLimit : JsonModel
{
    /// <summary>
    /// The profiles a filtered read scans of a list without maxScan.
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// Profiles the list read across its pages, kept or dropped by the filters. The last page may read past the limit.
    /// </summary>
    public required long RowsRead
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("rowsRead");
        }
        init { this._rawData.Set("rowsRead", value); }
    }

    /// <summary>
    /// What stopped the list &amp; how to read further.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Limit;
        _ = this.RowsRead;
        _ = this.Message;
    }

    public UserListScanLimit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListScanLimit(UserListScanLimit userListScanLimit)
        : base(userListScanLimit) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListScanLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListScanLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListScanLimitFromRaw.FromRawUnchecked"/>
    public static UserListScanLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListScanLimitFromRaw : IFromRawJson<UserListScanLimit>
{
    /// <inheritdoc/>
    public UserListScanLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserListScanLimit.FromRawUnchecked(rawData);
}
