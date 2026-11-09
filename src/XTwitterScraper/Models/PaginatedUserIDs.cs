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

[JsonConverter(typeof(JsonModelConverter<PaginatedUserIDs, PaginatedUserIDsFromRaw>))]
public sealed record class PaginatedUserIDs : JsonModel
{
    /// <summary>
    /// X user IDs, newest relationship first.
    /// </summary>
    public required IReadOnlyList<string> IDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Cursor for the next page. Send it unchanged. Each next page arrives fast.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IDs;
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public PaginatedUserIDs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedUserIDs(PaginatedUserIDs paginatedUserIDs)
        : base(paginatedUserIDs) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedUserIDs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedUserIDs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedUserIDsFromRaw.FromRawUnchecked"/>
    public static PaginatedUserIDs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedUserIDsFromRaw : IFromRawJson<PaginatedUserIDs>
{
    /// <inheritdoc/>
    public PaginatedUserIDs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedUserIDs.FromRawUnchecked(rawData);
}
