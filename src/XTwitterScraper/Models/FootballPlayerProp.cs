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

[JsonConverter(typeof(JsonModelConverter<FootballPlayerProp, FootballPlayerPropFromRaw>))]
public sealed record class FootballPlayerProp : JsonModel
{
    /// <summary>
    /// The player the line is for, a key of players.
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
    /// The line's place in its category, from 1.
    /// </summary>
    public required double? Rank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rank");
        }
        init { this._rawData.Set("rank", value); }
    }

    /// <summary>
    /// The line the odds price, such as 248.5 yards. Null when the prop has no line, such as the first touchdown scorer.
    /// </summary>
    public required double? Line
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("line");
        }
        init { this._rawData.Set("line", value); }
    }

    /// <summary>
    /// The American odds X shows first, such as -115 or 240.
    /// </summary>
    public required double? Odds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("odds");
        }
        init { this._rawData.Set("odds", value); }
    }

    /// <summary>
    /// The American odds X shows second. Null for a prop with 1 price.
    /// </summary>
    public required double? AlternateOdds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("alternateOdds");
        }
        init { this._rawData.Set("alternateOdds", value); }
    }

    /// <summary>
    /// Whether the sportsbook takes bets on the line.
    /// </summary>
    public required bool? OpenForBetting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("openForBetting");
        }
        init { this._rawData.Set("openForBetting", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PlayerID;
        _ = this.Rank;
        _ = this.Line;
        _ = this.Odds;
        _ = this.AlternateOdds;
        _ = this.OpenForBetting;
    }

    public FootballPlayerProp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerProp(FootballPlayerProp footballPlayerProp)
        : base(footballPlayerProp) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerProp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerProp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerPropFromRaw.FromRawUnchecked"/>
    public static FootballPlayerProp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerPropFromRaw : IFromRawJson<FootballPlayerProp>
{
    /// <inheritdoc/>
    public FootballPlayerProp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayerProp.FromRawUnchecked(rawData);
}
