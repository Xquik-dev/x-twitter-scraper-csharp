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

[JsonConverter(
    typeof(JsonModelConverter<CommunityNotesRatingOutcome, CommunityNotesRatingOutcomeFromRaw>)
)]
public sealed record class CommunityNotesRatingOutcome : JsonModel
{
    /// <summary>
    /// Ratings that called a note helpful.
    /// </summary>
    public long? HelpfulCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("helpfulCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("helpfulCount", value);
        }
    }

    /// <summary>
    /// Ratings that called a note not helpful.
    /// </summary>
    public long? NotHelpfulCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("notHelpfulCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("notHelpfulCount", value);
        }
    }

    /// <summary>
    /// All ratings in the group, when X sends the sum.
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HelpfulCount;
        _ = this.NotHelpfulCount;
        _ = this.Total;
    }

    public CommunityNotesRatingOutcome() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNotesRatingOutcome(CommunityNotesRatingOutcome communityNotesRatingOutcome)
        : base(communityNotesRatingOutcome) { }
#pragma warning restore CS8618

    public CommunityNotesRatingOutcome(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNotesRatingOutcome(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNotesRatingOutcomeFromRaw.FromRawUnchecked"/>
    public static CommunityNotesRatingOutcome FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNotesRatingOutcomeFromRaw : IFromRawJson<CommunityNotesRatingOutcome>
{
    /// <inheritdoc/>
    public CommunityNotesRatingOutcome FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNotesRatingOutcome.FromRawUnchecked(rawData);
}
