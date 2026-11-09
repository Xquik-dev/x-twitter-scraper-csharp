// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.CommunityNotes;

[JsonConverter(
    typeof(JsonModelConverter<
        CommunityNoteRetrieveContributorResponse,
        CommunityNoteRetrieveContributorResponseFromRaw
    >)
)]
public sealed record class CommunityNoteRetrieveContributorResponse : JsonModel
{
    /// <summary>
    /// A Community Notes contributor. X names contributors by an alias, never by their X account. A field X leaves out is left out. Beside a note, X sends its writer with only some of the counts.
    /// </summary>
    public required global::XTwitterScraper.Models.CommunityNotesContributor Contributor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.CommunityNotesContributor>(
                "contributor"
            );
        }
        init { this._rawData.Set("contributor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Contributor.Validate();
    }

    public CommunityNoteRetrieveContributorResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNoteRetrieveContributorResponse(
        CommunityNoteRetrieveContributorResponse communityNoteRetrieveContributorResponse
    )
        : base(communityNoteRetrieveContributorResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNoteRetrieveContributorResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNoteRetrieveContributorResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNoteRetrieveContributorResponseFromRaw.FromRawUnchecked"/>
    public static CommunityNoteRetrieveContributorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNoteRetrieveContributorResponseFromRaw
    : IFromRawJson<CommunityNoteRetrieveContributorResponse>
{
    /// <inheritdoc/>
    public CommunityNoteRetrieveContributorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNoteRetrieveContributorResponse.FromRawUnchecked(rawData);
}
