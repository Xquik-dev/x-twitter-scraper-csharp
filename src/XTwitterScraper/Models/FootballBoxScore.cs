// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(FootballBoxScoreLeagueConverter))]
public enum FootballBoxScoreLeague
{
    Nfl,
    Ncaafb,
}

sealed class FootballBoxScoreLeagueConverter : JsonConverter<FootballBoxScoreLeague>
{
    public override FootballBoxScoreLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballBoxScoreLeague.Nfl,
            "ncaafb" => FootballBoxScoreLeague.Ncaafb,
            _ => (FootballBoxScoreLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballBoxScoreLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballBoxScoreLeague.Nfl => "nfl",
                FootballBoxScoreLeague.Ncaafb => "ncaafb",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FootballBoxScore, FootballBoxScoreFromRaw>))]
public sealed record class FootballBoxScore : JsonModel
{
    /// <summary>
    /// The ID of the game this box score covers.
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
    /// The league of the game this box score covers.
    /// </summary>
    public required ApiEnum<string, FootballBoxScoreLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballBoxScoreLeague>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// 1 team's totals &amp; player stats.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballTeamBox Home
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballTeamBox>(
                "home"
            );
        }
        init { this._rawData.Set("home", value); }
    }

    /// <summary>
    /// 1 team's totals &amp; player stats.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballTeamBox Away
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FootballTeamBox>(
                "away"
            );
        }
        init { this._rawData.Set("away", value); }
    }

    /// <summary>
    /// The teams this box score names, by team ID.
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
    /// The players this box score names, by player ID.
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
        this.Home.Validate();
        this.Away.Validate();
        _ = this.Teams;
        _ = this.Players;
    }

    public FootballBoxScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballBoxScore(FootballBoxScore footballBoxScore)
        : base(footballBoxScore) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballBoxScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballBoxScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballBoxScoreFromRaw.FromRawUnchecked"/>
    public static FootballBoxScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballBoxScoreFromRaw : IFromRawJson<FootballBoxScore>
{
    /// <inheritdoc/>
    public FootballBoxScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballBoxScore.FromRawUnchecked(rawData);
}
