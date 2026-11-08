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

[JsonConverter(typeof(FootballScheduleLeagueConverter))]
public enum FootballScheduleLeague
{
    Nfl,
    Ncaafb,
}

sealed class FootballScheduleLeagueConverter : JsonConverter<FootballScheduleLeague>
{
    public override FootballScheduleLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballScheduleLeague.Nfl,
            "ncaafb" => FootballScheduleLeague.Ncaafb,
            _ => (FootballScheduleLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballScheduleLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballScheduleLeague.Nfl => "nfl",
                FootballScheduleLeague.Ncaafb => "ncaafb",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FootballSchedule, FootballScheduleFromRaw>))]
public sealed record class FootballSchedule : JsonModel
{
    /// <summary>
    /// The league whose games this list holds.
    /// </summary>
    public required ApiEnum<string, FootballScheduleLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballScheduleLeague>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// The games, earliest first.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballScheduleGame> Games
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballScheduleGame>
            >("games");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballScheduleGame>>(
                "games",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The teams the games name, by team ID.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.League.Validate();
        foreach (var item in this.Games)
        {
            item.Validate();
        }
        _ = this.Teams;
    }

    public FootballSchedule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballSchedule(FootballSchedule footballSchedule)
        : base(footballSchedule) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballSchedule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballSchedule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballScheduleFromRaw.FromRawUnchecked"/>
    public static FootballSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballScheduleFromRaw : IFromRawJson<FootballSchedule>
{
    /// <inheritdoc/>
    public FootballSchedule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballSchedule.FromRawUnchecked(rawData);
}
