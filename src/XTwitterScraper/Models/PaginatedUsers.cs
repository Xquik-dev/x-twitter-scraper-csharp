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

/// <summary>
/// Paginated user profiles. The item count can be lower than pageSize when the source
/// returns fewer profiles or remaining credits cover fewer results. Follow next_cursor
/// while has_next_page is true. A relationship can naturally contain fewer profiles
/// than requested. Zero affordable results returns 402 insufficient_credits.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginatedUsers, PaginatedUsersFromRaw>))]
public sealed record class PaginatedUsers : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    public required IReadOnlyList<UserProfile> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserProfile>>("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserProfile>>(
                "users",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? FilteredCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("filtered_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtered_count", value);
        }
    }

    /// <summary>
    /// Present on the last page of a filtered automatic read that sent no maxScan, once the list scanned 100,000 profiles across its pages. That page is the list's last.
    /// </summary>
    public global::XTwitterScraper.Models.UserListScanLimit? ScanLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserListScanLimit>(
                "scanLimit"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scanLimit", value);
        }
    }

    /// <summary>
    /// How completely the list came back, with its counts.
    /// </summary>
    public global::XTwitterScraper.Models.UserListCoverageDiagnostic? Diagnostic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserListCoverageDiagnostic>(
                "diagnostic"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("diagnostic", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        foreach (var item in this.Users)
        {
            item.Validate();
        }
        _ = this.FilteredCount;
        this.ScanLimit?.Validate();
        this.Diagnostic?.Validate();
    }

    public PaginatedUsers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedUsers(PaginatedUsers paginatedUsers)
        : base(paginatedUsers) { }
#pragma warning restore CS8618

    public PaginatedUsers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedUsers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedUsersFromRaw.FromRawUnchecked"/>
    public static PaginatedUsers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedUsersFromRaw : IFromRawJson<PaginatedUsers>
{
    /// <inheritdoc/>
    public PaginatedUsers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedUsers.FromRawUnchecked(rawData);
}
