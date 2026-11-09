// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<FootballScheduleGameOdds, FootballScheduleGameOddsFromRaw>)
)]
public sealed record class FootballScheduleGameOdds : JsonModel
{
    /// <summary>
    /// Betting odds titles for 1 team, as X shows them.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballOdds Home
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballOdds>(
                "home"
            );
        }
        init { this._rawData.Set("home", value); }
    }

    /// <summary>
    /// Betting odds titles for 1 team, as X shows them.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballOdds Away
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballOdds>(
                "away"
            );
        }
        init { this._rawData.Set("away", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Home.Validate();
        this.Away.Validate();
    }

    public FootballScheduleGameOdds() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScheduleGameOdds(FootballScheduleGameOdds footballScheduleGameOdds)
        : base(footballScheduleGameOdds) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScheduleGameOdds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballScheduleGameOdds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballScheduleGameOddsFromRaw.FromRawUnchecked"/>
    public static FootballScheduleGameOdds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballScheduleGameOddsFromRaw : IFromRawJson<FootballScheduleGameOdds>
{
    /// <inheritdoc/>
    public FootballScheduleGameOdds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballScheduleGameOdds.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballScheduleGame, FootballScheduleGameFromRaw>))]
public sealed record class FootballScheduleGame : JsonModel
{
    /// <summary>
    /// The game ID the other sports routes take.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// This game's part of the season, such as RegularSeason.
    /// </summary>
    public required string? SeasonType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("seasonType");
        }
        init { this._rawData.Set("seasonType", value); }
    }

    /// <summary>
    /// This game's week of the season.
    /// </summary>
    public required long? Week
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("week");
        }
        init { this._rawData.Set("week", value); }
    }

    /// <summary>
    /// This game's kickoff time in UTC, or null when Xquik cannot read it.
    /// </summary>
    public required DateTimeOffset? StartsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startsAt");
        }
        init { this._rawData.Set("startsAt", value); }
    }

    /// <summary>
    /// This game's status from X, such as Scheduled, InProgress or Closed.
    /// </summary>
    public required string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// This game's clock, as X writes it.
    /// </summary>
    public required string? Clock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clock");
        }
        init { this._rawData.Set("clock", value); }
    }

    /// <summary>
    /// This game's current or last quarter.
    /// </summary>
    public required long? Quarter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quarter");
        }
        init { this._rawData.Set("quarter", value); }
    }

    /// <summary>
    /// A team's side of a game &amp; its points.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballTeamScore Home
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballTeamScore>(
                "home"
            );
        }
        init { this._rawData.Set("home", value); }
    }

    /// <summary>
    /// A team's side of a game &amp; its points.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballTeamScore Away
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballTeamScore>(
                "away"
            );
        }
        init { this._rawData.Set("away", value); }
    }

    /// <summary>
    /// The game's teams, keys of teams.
    /// </summary>
    public required IReadOnlyList<string> TeamIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("teamIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "teamIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The periods played so far.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballSchedulePeriod> Periods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballSchedulePeriod>
            >("periods");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.FootballSchedulePeriod>
            >("periods", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Betting odds for each team, or null when X has none.
    /// </summary>
    public required FootballScheduleGameOdds? Odds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballScheduleGameOdds>("odds");
        }
        init { this._rawData.Set("odds", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SeasonType;
        _ = this.Week;
        _ = this.StartsAt;
        _ = this.Status;
        _ = this.Clock;
        _ = this.Quarter;
        this.Home.Validate();
        this.Away.Validate();
        _ = this.TeamIDs;
        foreach (var item in this.Periods)
        {
            item.Validate();
        }
        this.Odds?.Validate();
    }

    public FootballScheduleGame() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScheduleGame(FootballScheduleGame footballScheduleGame)
        : base(footballScheduleGame) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScheduleGame(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballScheduleGame(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballScheduleGameFromRaw.FromRawUnchecked"/>
    public static FootballScheduleGame FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballScheduleGameFromRaw : IFromRawJson<FootballScheduleGame>
{
    /// <inheritdoc/>
    public FootballScheduleGame FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballScheduleGame.FromRawUnchecked(rawData);
}
