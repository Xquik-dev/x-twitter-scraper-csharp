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
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(FootballScoreboardLeagueConverter))]
public enum FootballScoreboardLeague
{
    Nfl,
    Ncaafb,
}

sealed class FootballScoreboardLeagueConverter : JsonConverter<FootballScoreboardLeague>
{
    public override FootballScoreboardLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballScoreboardLeague.Nfl,
            "ncaafb" => FootballScoreboardLeague.Ncaafb,
            _ => (FootballScoreboardLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballScoreboardLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballScoreboardLeague.Nfl => "nfl",
                FootballScoreboardLeague.Ncaafb => "ncaafb",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<FootballScoreboardSituation, FootballScoreboardSituationFromRaw>)
)]
public sealed record class FootballScoreboardSituation : JsonModel
{
    /// <summary>
    /// The current down, from 1 to 4.
    /// </summary>
    public required long? Down
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("down");
        }
        init { this._rawData.Set("down", value); }
    }

    /// <summary>
    /// The yards the offense needs now for a first down.
    /// </summary>
    public required long? YardsToGo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yardsToGo");
        }
        init { this._rawData.Set("yardsToGo", value); }
    }

    /// <summary>
    /// The ball's current yard line.
    /// </summary>
    public required long? Yardline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yardline");
        }
        init { this._rawData.Set("yardline", value); }
    }

    /// <summary>
    /// The team whose half the ball is in, a key of teams.
    /// </summary>
    public required string? YardlineTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("yardlineTeamId");
        }
        init { this._rawData.Set("yardlineTeamId", value); }
    }

    /// <summary>
    /// The team with the ball, a key of teams.
    /// </summary>
    public required string? PossessionTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("possessionTeamId");
        }
        init { this._rawData.Set("possessionTeamId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Down;
        _ = this.YardsToGo;
        _ = this.Yardline;
        _ = this.YardlineTeamID;
        _ = this.PossessionTeamID;
    }

    public FootballScoreboardSituation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScoreboardSituation(FootballScoreboardSituation footballScoreboardSituation)
        : base(footballScoreboardSituation) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScoreboardSituation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballScoreboardSituation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballScoreboardSituationFromRaw.FromRawUnchecked"/>
    public static FootballScoreboardSituation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballScoreboardSituationFromRaw : IFromRawJson<FootballScoreboardSituation>
{
    /// <inheritdoc/>
    public FootballScoreboardSituation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballScoreboardSituation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballScoreboard, FootballScoreboardFromRaw>))]
public sealed record class FootballScoreboard : JsonModel
{
    /// <summary>
    /// The game ID from your request.
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
    /// The league from your request.
    /// </summary>
    public required ApiEnum<string, FootballScoreboardLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballScoreboardLeague>>(
                "league"
            );
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// X's ID for the season. NFL games have one.
    /// </summary>
    public required string? SeasonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("seasonId");
        }
        init { this._rawData.Set("seasonId", value); }
    }

    /// <summary>
    /// The part of the season, such as RegularSeason. X stopped sending it with a game on 2026-10-24, so it is null.
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
    /// The week of the season. X stopped sending it with a game on 2026-10-24, so it is null. The games list still has each week.
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
    /// The kickoff time in UTC, or null when X sends none Xquik can read.
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
    /// The stadium.
    /// </summary>
    public required string? Venue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("venue");
        }
        init { this._rawData.Set("venue", value); }
    }

    /// <summary>
    /// X's game status, such as Scheduled, InProgress or Closed.
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
    /// The game clock, as X writes it.
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
    /// The current or last quarter.
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
    /// Down &amp; distance now, or null before kickoff.
    /// </summary>
    public required FootballScoreboardSituation? Situation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballScoreboardSituation>("situation");
        }
        init { this._rawData.Set("situation", value); }
    }

    /// <summary>
    /// A team's side of a scoreboard.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballSide Home
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballSide>(
                "home"
            );
        }
        init { this._rawData.Set("home", value); }
    }

    /// <summary>
    /// A team's side of a scoreboard.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballSide Away
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballSide>(
                "away"
            );
        }
        init { this._rawData.Set("away", value); }
    }

    /// <summary>
    /// Points by period, in order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPeriod> Periods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPeriod>
            >("periods");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPeriod>>(
                "periods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The latest play, or null before kickoff. Its steps can list no players for a short while.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballPlay? LastPlay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballPlay>(
                "lastPlay"
            );
        }
        init { this._rawData.Set("lastPlay", value); }
    }

    /// <summary>
    /// The teams this answer names, by team ID.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Teams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("teams");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "teams",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The players this answer names, by player ID.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Players
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("players");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "players",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.League.Validate();
        _ = this.SeasonID;
        _ = this.SeasonType;
        _ = this.Week;
        _ = this.StartsAt;
        _ = this.Venue;
        _ = this.Status;
        _ = this.Clock;
        _ = this.Quarter;
        this.Situation?.Validate();
        this.Home.Validate();
        this.Away.Validate();
        foreach (var item in this.Periods)
        {
            item.Validate();
        }
        this.LastPlay?.Validate();
        _ = this.Teams;
        _ = this.Players;
    }

    public FootballScoreboard() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScoreboard(FootballScoreboard footballScoreboard)
        : base(footballScoreboard) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballScoreboard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballScoreboard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballScoreboardFromRaw.FromRawUnchecked"/>
    public static FootballScoreboard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballScoreboardFromRaw : IFromRawJson<FootballScoreboard>
{
    /// <inheritdoc/>
    public FootballScoreboard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballScoreboard.FromRawUnchecked(rawData);
}
