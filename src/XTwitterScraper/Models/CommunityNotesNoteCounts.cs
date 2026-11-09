// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<CommunityNotesNoteCounts, CommunityNotesNoteCountsFromRaw>)
)]
public sealed record class CommunityNotesNoteCounts : JsonModel
{
    /// <summary>
    /// Notes that need more ratings.
    /// </summary>
    public long? AwaitingMoreRatings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("awaitingMoreRatings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("awaitingMoreRatings", value);
        }
    }

    /// <summary>
    /// Notes X rates helpful now.
    /// </summary>
    public long? CurrentlyRatedHelpful
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("currentlyRatedHelpful");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentlyRatedHelpful", value);
        }
    }

    /// <summary>
    /// Notes X rates not helpful now.
    /// </summary>
    public long? CurrentlyRatedNotHelpful
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("currentlyRatedNotHelpful");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentlyRatedNotHelpful", value);
        }
    }

    /// <summary>
    /// When X last counted the notes.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AwaitingMoreRatings;
        _ = this.CurrentlyRatedHelpful;
        _ = this.CurrentlyRatedNotHelpful;
        _ = this.UpdatedAt;
    }

    public CommunityNotesNoteCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNotesNoteCounts(CommunityNotesNoteCounts communityNotesNoteCounts)
        : base(communityNotesNoteCounts) { }
#pragma warning restore CS8618

    public CommunityNotesNoteCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNotesNoteCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNotesNoteCountsFromRaw.FromRawUnchecked"/>
    public static CommunityNotesNoteCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNotesNoteCountsFromRaw : IFromRawJson<CommunityNotesNoteCounts>
{
    /// <inheritdoc/>
    public CommunityNotesNoteCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNotesNoteCounts.FromRawUnchecked(rawData);
}
