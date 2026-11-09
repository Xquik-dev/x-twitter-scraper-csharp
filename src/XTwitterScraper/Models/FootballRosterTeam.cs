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

[JsonConverter(typeof(JsonModelConverter<FootballRosterTeam, FootballRosterTeamFromRaw>))]
public sealed record class FootballRosterTeam : JsonModel
{
    /// <summary>
    /// The team this roster belongs to, a key of teams.
    /// </summary>
    public required string TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("teamId");
        }
        init { this._rawData.Set("teamId", value); }
    }

    /// <summary>
    /// The team's players in X's order, keys of players.
    /// </summary>
    public required IReadOnlyList<string> PlayerIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("playerIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "playerIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.PlayerIDs;
    }

    public FootballRosterTeam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRosterTeam(FootballRosterTeam footballRosterTeam)
        : base(footballRosterTeam) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRosterTeam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballRosterTeam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballRosterTeamFromRaw.FromRawUnchecked"/>
    public static FootballRosterTeam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballRosterTeamFromRaw : IFromRawJson<FootballRosterTeam>
{
    /// <inheritdoc/>
    public FootballRosterTeam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballRosterTeam.FromRawUnchecked(rawData);
}
