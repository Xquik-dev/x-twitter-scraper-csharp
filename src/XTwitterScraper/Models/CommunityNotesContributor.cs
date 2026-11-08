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
    typeof(JsonModelConverter<CommunityNotesContributor, CommunityNotesContributorFromRaw>)
)]
public sealed record class CommunityNotesContributor : JsonModel
{
    /// <summary>
    /// The alias X gives the contributor.
    /// </summary>
    public required string Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("alias");
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <summary>
    /// Whether X marks the contributor as a top writer.
    /// </summary>
    public bool? IsTopWriter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTopWriter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTopWriter", value);
        }
    }

    /// <summary>
    /// Whether the contributor writes notes through X's API.
    /// </summary>
    public bool? IsApiContributor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isApiContributor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isApiContributor", value);
        }
    }

    /// <summary>
    /// Notes the contributor deleted.
    /// </summary>
    public long? DeletedNotesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("deletedNotesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deletedNotesCount", value);
        }
    }

    /// <summary>
    /// How many notes a contributor wrote, by X's current rating.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityNotesNoteCounts? NotesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityNotesNoteCounts>(
                "notesCount"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("notesCount", value);
        }
    }

    /// <summary>
    /// How a contributor's ratings of other notes went.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityNotesRatingCounts? RatingsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityNotesRatingCounts>(
                "ratingsCount"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ratingsCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        _ = this.IsTopWriter;
        _ = this.IsApiContributor;
        _ = this.DeletedNotesCount;
        this.NotesCount?.Validate();
        this.RatingsCount?.Validate();
    }

    public CommunityNotesContributor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNotesContributor(CommunityNotesContributor communityNotesContributor)
        : base(communityNotesContributor) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNotesContributor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNotesContributor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNotesContributorFromRaw.FromRawUnchecked"/>
    public static CommunityNotesContributor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNotesContributorFromRaw : IFromRawJson<CommunityNotesContributor>
{
    /// <inheritdoc/>
    public CommunityNotesContributor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNotesContributor.FromRawUnchecked(rawData);
}
