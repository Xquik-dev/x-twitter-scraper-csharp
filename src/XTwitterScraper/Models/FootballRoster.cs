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

[JsonConverter(typeof(FootballRosterLeagueConverter))]
public enum FootballRosterLeague
{
    Nfl,
}

sealed class FootballRosterLeagueConverter : JsonConverter<FootballRosterLeague>
{
    public override FootballRosterLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballRosterLeague.Nfl,
            _ => (FootballRosterLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballRosterLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballRosterLeague.Nfl => "nfl",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FootballRoster, FootballRosterFromRaw>))]
public sealed record class FootballRoster : JsonModel
{
    /// <summary>
    /// The ID of the game these rosters cover.
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
    /// The league of the game these rosters cover.
    /// </summary>
    public required ApiEnum<string, FootballRosterLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballRosterLeague>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// Each team's roster, in X's order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballRosterTeam> Rosters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballRosterTeam>
            >("rosters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballRosterTeam>>(
                "rosters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The 2 teams, by team ID.
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
    /// Every rostered player, by player ID. Rosters carry no college or birth details &amp; only a medium headshot, so the rest are null.
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
        foreach (var item in this.Rosters)
        {
            item.Validate();
        }
        _ = this.Teams;
        _ = this.Players;
    }

    public FootballRoster() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRoster(FootballRoster footballRoster)
        : base(footballRoster) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRoster(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballRoster(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballRosterFromRaw.FromRawUnchecked"/>
    public static FootballRoster FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballRosterFromRaw : IFromRawJson<FootballRoster>
{
    /// <inheritdoc/>
    public FootballRoster FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballRoster.FromRawUnchecked(rawData);
}
