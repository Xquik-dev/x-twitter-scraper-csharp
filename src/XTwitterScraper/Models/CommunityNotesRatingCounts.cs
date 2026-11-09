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
    typeof(JsonModelConverter<CommunityNotesRatingCounts, CommunityNotesRatingCountsFromRaw>)
)]
public sealed record class CommunityNotesRatingCounts : JsonModel
{
    /// <summary>
    /// Ratings on notes that need more ratings.
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
    /// Ratings made after X rated the note.
    /// </summary>
    public long? RatedAfterDecision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ratedAfterDecision");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ratedAfterDecision", value);
        }
    }

    /// <summary>
    /// Ratings that matched the rating X gave the note.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityNotesRatingOutcome? Successful
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityNotesRatingOutcome>(
                "successful"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("successful", value);
        }
    }

    /// <summary>
    /// Ratings that went against the rating X gave the note.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityNotesRatingOutcome? Unsuccessful
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityNotesRatingOutcome>(
                "unsuccessful"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unsuccessful", value);
        }
    }

    /// <summary>
    /// When X last counted the ratings.
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
        _ = this.RatedAfterDecision;
        this.Successful?.Validate();
        this.Unsuccessful?.Validate();
        _ = this.UpdatedAt;
    }

    public CommunityNotesRatingCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNotesRatingCounts(CommunityNotesRatingCounts communityNotesRatingCounts)
        : base(communityNotesRatingCounts) { }
#pragma warning restore CS8618

    public CommunityNotesRatingCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNotesRatingCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNotesRatingCountsFromRaw.FromRawUnchecked"/>
    public static CommunityNotesRatingCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNotesRatingCountsFromRaw : IFromRawJson<CommunityNotesRatingCounts>
{
    /// <inheritdoc/>
    public CommunityNotesRatingCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNotesRatingCounts.FromRawUnchecked(rawData);
}
