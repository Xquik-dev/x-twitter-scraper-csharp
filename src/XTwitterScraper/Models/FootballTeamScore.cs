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

[JsonConverter(typeof(JsonModelConverter<FootballTeamScore, FootballTeamScoreFromRaw>))]
public sealed record class FootballTeamScore : JsonModel
{
    /// <summary>
    /// The team, a key of teams.
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
    /// The team's points so far.
    /// </summary>
    public required long? Points
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("points");
        }
        init { this._rawData.Set("points", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.Points;
    }

    public FootballTeamScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamScore(FootballTeamScore footballTeamScore)
        : base(footballTeamScore) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballTeamScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballTeamScoreFromRaw.FromRawUnchecked"/>
    public static FootballTeamScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballTeamScoreFromRaw : IFromRawJson<FootballTeamScore>
{
    /// <inheritdoc/>
    public FootballTeamScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballTeamScore.FromRawUnchecked(rawData);
}
