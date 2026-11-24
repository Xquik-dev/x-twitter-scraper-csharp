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

/// <summary>
/// A team's rank in X's college football poll.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FootballPollRanking, FootballPollRankingFromRaw>))]
public sealed record class FootballPollRanking : JsonModel
{
    /// <summary>
    /// The ranked team, a key of teams.
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
    /// The team's rank, where 1 is the top.
    /// </summary>
    public required long? Rank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rank");
        }
        init { this._rawData.Set("rank", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.Rank;
    }

    public FootballPollRanking() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPollRanking(FootballPollRanking footballPollRanking)
        : base(footballPollRanking) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPollRanking(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPollRanking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPollRankingFromRaw.FromRawUnchecked"/>
    public static FootballPollRanking FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPollRankingFromRaw : IFromRawJson<FootballPollRanking>
{
    /// <inheritdoc/>
    public FootballPollRanking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPollRanking.FromRawUnchecked(rawData);
}
