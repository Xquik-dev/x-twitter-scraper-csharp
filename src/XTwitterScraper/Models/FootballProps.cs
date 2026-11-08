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

[JsonConverter(typeof(FootballPropsLeagueConverter))]
public enum FootballPropsLeague
{
    Nfl,
}

sealed class FootballPropsLeagueConverter : JsonConverter<FootballPropsLeague>
{
    public override FootballPropsLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => FootballPropsLeague.Nfl,
            _ => (FootballPropsLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FootballPropsLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FootballPropsLeague.Nfl => "nfl",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FootballProps, FootballPropsFromRaw>))]
public sealed record class FootballProps : JsonModel
{
    /// <summary>
    /// The ID of the game these props cover.
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
    /// The league of the game these props cover.
    /// </summary>
    public required ApiEnum<string, FootballPropsLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FootballPropsLeague>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// The sportsbook page X links for these props.
    /// </summary>
    public required string? SportsbookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sportsbookUrl");
        }
        init { this._rawData.Set("sportsbookUrl", value); }
    }

    /// <summary>
    /// Each kind of prop, such as passing yards, in X's order. A game without props has none.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPropCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPropCategory>
            >("categories");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPropCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The players these props name, by player ID. X sends only each player's name, jersey &amp; team, so other fields are null.
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
        _ = this.SportsbookUrl;
        foreach (var item in this.Categories)
        {
            item.Validate();
        }
        _ = this.Players;
    }

    public FootballProps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballProps(FootballProps footballProps)
        : base(footballProps) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballProps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballProps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPropsFromRaw.FromRawUnchecked"/>
    public static FootballProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPropsFromRaw : IFromRawJson<FootballProps>
{
    /// <inheritdoc/>
    public FootballProps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballProps.FromRawUnchecked(rawData);
}
