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

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayDetailPlayers, FootballPlayDetailPlayersFromRaw>)
)]
public sealed record class FootballPlayDetailPlayers : JsonModel
{
    /// <summary>
    /// The player, a key of players.
    /// </summary>
    public required string? PlayerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("playerId");
        }
        init { this._rawData.Set("playerId", value); }
    }

    /// <summary>
    /// The player's role, such as Pass, Receive or Tackle.
    /// </summary>
    public required string? PlayerRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("playerRole");
        }
        init { this._rawData.Set("playerRole", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PlayerID;
        _ = this.PlayerRole;
    }

    public FootballPlayDetailPlayers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetailPlayers(FootballPlayDetailPlayers footballPlayDetailPlayers)
        : base(footballPlayDetailPlayers) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetailPlayers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayDetailPlayers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayDetailPlayersFromRaw.FromRawUnchecked"/>
    public static FootballPlayDetailPlayers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayDetailPlayersFromRaw : IFromRawJson<FootballPlayDetailPlayers>
{
    /// <inheritdoc/>
    public FootballPlayDetailPlayers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayDetailPlayers.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayDetailPenalty, FootballPlayDetailPenaltyFromRaw>)
)]
public sealed record class FootballPlayDetailPenalty : JsonModel
{
    /// <summary>
    /// The penalty's name.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// What the penalty does to the down.
    /// </summary>
    public required string? NextDown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextDown");
        }
        init { this._rawData.Set("nextDown", value); }
    }

    /// <summary>
    /// Whether the penalty was accepted or declined.
    /// </summary>
    public required string? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// The penalized team, a key of teams.
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
    /// The penalty's yards.
    /// </summary>
    public required long? Yards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yards");
        }
        init { this._rawData.Set("yards", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.NextDown;
        _ = this.Result;
        _ = this.TeamID;
        _ = this.Yards;
    }

    public FootballPlayDetailPenalty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetailPenalty(FootballPlayDetailPenalty footballPlayDetailPenalty)
        : base(footballPlayDetailPenalty) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetailPenalty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayDetailPenalty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayDetailPenaltyFromRaw.FromRawUnchecked"/>
    public static FootballPlayDetailPenalty FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayDetailPenaltyFromRaw : IFromRawJson<FootballPlayDetailPenalty>
{
    /// <inheritdoc/>
    public FootballPlayDetailPenalty FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayDetailPenalty.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlayDetail, FootballPlayDetailFromRaw>))]
public sealed record class FootballPlayDetail : JsonModel
{
    /// <summary>
    /// The step's place in the play, from 1.
    /// </summary>
    public required long? Sequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sequence");
        }
        init { this._rawData.Set("sequence", value); }
    }

    /// <summary>
    /// X's kind of step, such as Pass, Tackle or Penalty.
    /// </summary>
    public required string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// What happened in the step.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The direction X gives for the step.
    /// </summary>
    public required string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// The yards the step gained or lost.
    /// </summary>
    public required long? Yards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yards");
        }
        init { this._rawData.Set("yards", value); }
    }

    /// <summary>
    /// The players in the step &amp; their roles.
    /// </summary>
    public required IReadOnlyList<FootballPlayDetailPlayers> Players
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FootballPlayDetailPlayers>>(
                "players"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FootballPlayDetailPlayers>>(
                "players",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The penalty this step called, or null.
    /// </summary>
    public required FootballPlayDetailPenalty? Penalty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayDetailPenalty>("penalty");
        }
        init { this._rawData.Set("penalty", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Sequence;
        _ = this.Category;
        _ = this.Description;
        _ = this.Direction;
        _ = this.Yards;
        foreach (var item in this.Players)
        {
            item.Validate();
        }
        this.Penalty?.Validate();
    }

    public FootballPlayDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetail(FootballPlayDetail footballPlayDetail)
        : base(footballPlayDetail) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayDetailFromRaw.FromRawUnchecked"/>
    public static FootballPlayDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayDetailFromRaw : IFromRawJson<FootballPlayDetail>
{
    /// <inheritdoc/>
    public FootballPlayDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayDetail.FromRawUnchecked(rawData);
}
