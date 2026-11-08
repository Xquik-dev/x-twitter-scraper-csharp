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
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(FootballPlaysLeagueConverter))]
public enum FootballPlaysLeague
{
    Nfl,
    Ncaafb,
}

sealed class FootballPlaysLeagueConverter : JsonConverter<FootballPlaysLeague>
{
    public override FootballPlaysLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballPlaysLeague.Nfl,
            "ncaafb" => FootballPlaysLeague.Ncaafb,
            _ => (FootballPlaysLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballPlaysLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballPlaysLeague.Nfl => "nfl",
                FootballPlaysLeague.Ncaafb => "ncaafb",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FootballPlays, FootballPlaysFromRaw>))]
public sealed record class FootballPlays : JsonModel
{
    /// <summary>
    /// The ID of the game these plays come from.
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
    /// The league of the game these plays come from.
    /// </summary>
    public required ApiEnum<string, FootballPlaysLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballPlaysLeague>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// The home team, a key of teams.
    /// </summary>
    public required string? HomeTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("homeTeamId");
        }
        init { this._rawData.Set("homeTeamId", value); }
    }

    /// <summary>
    /// The away team, a key of teams.
    /// </summary>
    public required string? AwayTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("awayTeamId");
        }
        init { this._rawData.Set("awayTeamId", value); }
    }

    /// <summary>
    /// The game's quarters, in order. Empty before kickoff.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballQuarter> Quarters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballQuarter>
            >("quarters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballQuarter>>(
                "quarters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The teams these plays name, by team ID.
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
    /// The players these plays name, by player ID.
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
        _ = this.HomeTeamID;
        _ = this.AwayTeamID;
        foreach (var item in this.Quarters)
        {
            item.Validate();
        }
        _ = this.Teams;
        _ = this.Players;
    }

    public FootballPlays() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlays(FootballPlays footballPlays)
        : base(footballPlays) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlays(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlays(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlaysFromRaw.FromRawUnchecked"/>
    public static FootballPlays FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlaysFromRaw : IFromRawJson<FootballPlays>
{
    /// <inheritdoc/>
    public FootballPlays FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlays.FromRawUnchecked(rawData);
}
