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

[JsonConverter(typeof(JsonModelConverter<FootballTeamBox, FootballTeamBoxFromRaw>))]
public sealed record class FootballTeamBox : JsonModel
{
    /// <summary>
    /// The team these totals belong to, a key of teams.
    /// </summary>
    public required string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("teamId");
        }
        init { this._rawData.Set("teamId", value); }
    }

    /// <summary>
    /// The team's totals, or null before kickoff.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballTeamTotals? Totals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballTeamTotals>(
                "totals"
            );
        }
        init { this._rawData.Set("totals", value); }
    }

    /// <summary>
    /// Each player with stats, 1 entry per player.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPlayerStats> Players
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPlayerStats>
            >("players");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPlayerStats>>(
                "players",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        this.Totals?.Validate();
        foreach (var item in this.Players)
        {
            item.Validate();
        }
    }

    public FootballTeamBox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamBox(FootballTeamBox footballTeamBox)
        : base(footballTeamBox) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamBox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballTeamBox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballTeamBoxFromRaw.FromRawUnchecked"/>
    public static FootballTeamBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballTeamBoxFromRaw : IFromRawJson<FootballTeamBox>
{
    /// <inheritdoc/>
    public FootballTeamBox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballTeamBox.FromRawUnchecked(rawData);
}
