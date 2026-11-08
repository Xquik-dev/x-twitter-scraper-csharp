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

[JsonConverter(typeof(JsonModelConverter<PaginatedCommunityNotes, PaginatedCommunityNotesFromRaw>))]
public sealed record class PaginatedCommunityNotes : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.CommunityNote2> Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.CommunityNote2>
            >("notes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.CommunityNote2>>(
                "notes",
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
        foreach (var item in this.Notes)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public PaginatedCommunityNotes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedCommunityNotes(PaginatedCommunityNotes paginatedCommunityNotes)
        : base(paginatedCommunityNotes) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedCommunityNotes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedCommunityNotes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedCommunityNotesFromRaw.FromRawUnchecked"/>
    public static PaginatedCommunityNotes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedCommunityNotesFromRaw : IFromRawJson<PaginatedCommunityNotes>
{
    /// <inheritdoc/>
    public PaginatedCommunityNotes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaginatedCommunityNotes.FromRawUnchecked(rawData);
}
