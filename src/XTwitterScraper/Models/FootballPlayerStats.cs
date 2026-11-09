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

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayerStatsReceiving, FootballPlayerStatsReceivingFromRaw>)
)]
public sealed record class FootballPlayerStatsReceiving : JsonModel
{
    /// <summary>
    /// Yards per catch.
    /// </summary>
    public required double? AvgYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("avgYards");
        }
        init { this._rawData.Set("avgYards", value); }
    }

    /// <summary>
    /// The longest catch, in yards.
    /// </summary>
    public required long? Longest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("longest");
        }
        init { this._rawData.Set("longest", value); }
    }

    /// <summary>
    /// Catches.
    /// </summary>
    public required long? Receptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("receptions");
        }
        init { this._rawData.Set("receptions", value); }
    }

    /// <summary>
    /// Passes thrown to the player.
    /// </summary>
    public required long? Targets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("targets");
        }
        init { this._rawData.Set("targets", value); }
    }

    /// <summary>
    /// Receiving touchdowns.
    /// </summary>
    public required long? Touchdowns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("touchdowns");
        }
        init { this._rawData.Set("touchdowns", value); }
    }

    /// <summary>
    /// Receiving yards.
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
        _ = this.AvgYards;
        _ = this.Longest;
        _ = this.Receptions;
        _ = this.Targets;
        _ = this.Touchdowns;
        _ = this.Yards;
    }

    public FootballPlayerStatsReceiving() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsReceiving(FootballPlayerStatsReceiving footballPlayerStatsReceiving)
        : base(footballPlayerStatsReceiving) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsReceiving(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsReceiving(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsReceivingFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsReceiving FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsReceivingFromRaw : IFromRawJson<FootballPlayerStatsReceiving>
{
    /// <inheritdoc/>
    public FootballPlayerStatsReceiving FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsReceiving.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayerStatsDefense, FootballPlayerStatsDefenseFromRaw>)
)]
public sealed record class FootballPlayerStatsDefense : JsonModel
{
    /// <summary>
    /// Solo &amp; assisted tackles together.
    /// </summary>
    public required double? Combined
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("combined");
        }
        init { this._rawData.Set("combined", value); }
    }

    /// <summary>
    /// Fumbles forced.
    /// </summary>
    public required long? ForcedFumbles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("forcedFumbles");
        }
        init { this._rawData.Set("forcedFumbles", value); }
    }

    /// <summary>
    /// Interceptions.
    /// </summary>
    public required long? Interceptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("interceptions");
        }
        init { this._rawData.Set("interceptions", value); }
    }

    /// <summary>
    /// Passes defended.
    /// </summary>
    public required long? PassesDefended
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("passesDefended");
        }
        init { this._rawData.Set("passesDefended", value); }
    }

    /// <summary>
    /// Sacks, with a shared sack as 0.5.
    /// </summary>
    public required double? Sacks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("sacks");
        }
        init { this._rawData.Set("sacks", value); }
    }

    /// <summary>
    /// Solo tackles.
    /// </summary>
    public required double? Tackles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tackles");
        }
        init { this._rawData.Set("tackles", value); }
    }

    /// <summary>
    /// Tackles for a loss.
    /// </summary>
    public required double? TacklesForLoss
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tacklesForLoss");
        }
        init { this._rawData.Set("tacklesForLoss", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Combined;
        _ = this.ForcedFumbles;
        _ = this.Interceptions;
        _ = this.PassesDefended;
        _ = this.Sacks;
        _ = this.Tackles;
        _ = this.TacklesForLoss;
    }

    public FootballPlayerStatsDefense() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsDefense(FootballPlayerStatsDefense footballPlayerStatsDefense)
        : base(footballPlayerStatsDefense) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsDefense(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsDefense(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsDefenseFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsDefense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsDefenseFromRaw : IFromRawJson<FootballPlayerStatsDefense>
{
    /// <inheritdoc/>
    public FootballPlayerStatsDefense FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsDefense.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayerStatsPunts, FootballPlayerStatsPuntsFromRaw>)
)]
public sealed record class FootballPlayerStatsPunts : JsonModel
{
    /// <summary>
    /// Punts.
    /// </summary>
    public required long? Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attempts");
        }
        init { this._rawData.Set("attempts", value); }
    }

    /// <summary>
    /// Net yards per punt, after returns.
    /// </summary>
    public required double? AvgNetYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("avgNetYards");
        }
        init { this._rawData.Set("avgNetYards", value); }
    }

    /// <summary>
    /// Yards per punt.
    /// </summary>
    public required double? AvgYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("avgYards");
        }
        init { this._rawData.Set("avgYards", value); }
    }

    /// <summary>
    /// Punts downed inside the 20.
    /// </summary>
    public required long? Inside20
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("inside20");
        }
        init { this._rawData.Set("inside20", value); }
    }

    /// <summary>
    /// The longest punt, in yards.
    /// </summary>
    public required long? Longest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("longest");
        }
        init { this._rawData.Set("longest", value); }
    }

    /// <summary>
    /// Punting yards.
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
        _ = this.Attempts;
        _ = this.AvgNetYards;
        _ = this.AvgYards;
        _ = this.Inside20;
        _ = this.Longest;
        _ = this.Yards;
    }

    public FootballPlayerStatsPunts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsPunts(FootballPlayerStatsPunts footballPlayerStatsPunts)
        : base(footballPlayerStatsPunts) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsPunts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsPunts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsPuntsFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsPunts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsPuntsFromRaw : IFromRawJson<FootballPlayerStatsPunts>
{
    /// <inheritdoc/>
    public FootballPlayerStatsPunts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsPunts.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FootballPlayerStatsFieldGoals, FootballPlayerStatsFieldGoalsFromRaw>)
)]
public sealed record class FootballPlayerStatsFieldGoals : JsonModel
{
    /// <summary>
    /// Field goals tried.
    /// </summary>
    public required long? Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attempts");
        }
        init { this._rawData.Set("attempts", value); }
    }

    /// <summary>
    /// The longest made field goal, in yards.
    /// </summary>
    public required long? Longest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("longest");
        }
        init { this._rawData.Set("longest", value); }
    }

    /// <summary>
    /// Field goals made.
    /// </summary>
    public required long? Made
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("made");
        }
        init { this._rawData.Set("made", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempts;
        _ = this.Longest;
        _ = this.Made;
    }

    public FootballPlayerStatsFieldGoals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsFieldGoals(
        FootballPlayerStatsFieldGoals footballPlayerStatsFieldGoals
    )
        : base(footballPlayerStatsFieldGoals) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsFieldGoals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsFieldGoals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsFieldGoalsFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsFieldGoals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsFieldGoalsFromRaw : IFromRawJson<FootballPlayerStatsFieldGoals>
{
    /// <inheritdoc/>
    public FootballPlayerStatsFieldGoals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsFieldGoals.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FootballPlayerStatsExtraPoints,
        FootballPlayerStatsExtraPointsFromRaw
    >)
)]
public sealed record class FootballPlayerStatsExtraPoints : JsonModel
{
    /// <summary>
    /// Extra points tried.
    /// </summary>
    public required long? Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attempts");
        }
        init { this._rawData.Set("attempts", value); }
    }

    /// <summary>
    /// Extra points made.
    /// </summary>
    public required long? Made
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("made");
        }
        init { this._rawData.Set("made", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempts;
        _ = this.Made;
    }

    public FootballPlayerStatsExtraPoints() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsExtraPoints(
        FootballPlayerStatsExtraPoints footballPlayerStatsExtraPoints
    )
        : base(footballPlayerStatsExtraPoints) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsExtraPoints(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsExtraPoints(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsExtraPointsFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsExtraPoints FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsExtraPointsFromRaw : IFromRawJson<FootballPlayerStatsExtraPoints>
{
    /// <inheritdoc/>
    public FootballPlayerStatsExtraPoints FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsExtraPoints.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FootballPlayerStatsConversions,
        FootballPlayerStatsConversionsFromRaw
    >)
)]
public sealed record class FootballPlayerStatsConversions : JsonModel
{
    /// <summary>
    /// Defensive 2-point returns.
    /// </summary>
    public required long? DefenseSuccesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("defenseSuccesses");
        }
        init { this._rawData.Set("defenseSuccesses", value); }
    }

    /// <summary>
    /// 2-point conversions by pass.
    /// </summary>
    public required long? PassSuccesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("passSuccesses");
        }
        init { this._rawData.Set("passSuccesses", value); }
    }

    /// <summary>
    /// 2-point conversions by rush.
    /// </summary>
    public required long? RushSuccesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rushSuccesses");
        }
        init { this._rawData.Set("rushSuccesses", value); }
    }

    /// <summary>
    /// 2-point conversions after a turnover.
    /// </summary>
    public required long? TurnoverSuccesses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turnoverSuccesses");
        }
        init { this._rawData.Set("turnoverSuccesses", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DefenseSuccesses;
        _ = this.PassSuccesses;
        _ = this.RushSuccesses;
        _ = this.TurnoverSuccesses;
    }

    public FootballPlayerStatsConversions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsConversions(
        FootballPlayerStatsConversions footballPlayerStatsConversions
    )
        : base(footballPlayerStatsConversions) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStatsConversions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStatsConversions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsConversionsFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStatsConversions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsConversionsFromRaw : IFromRawJson<FootballPlayerStatsConversions>
{
    /// <inheritdoc/>
    public FootballPlayerStatsConversions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPlayerStatsConversions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlayerStats, FootballPlayerStatsFromRaw>))]
public sealed record class FootballPlayerStats : JsonModel
{
    /// <summary>
    /// The player these stats belong to, a key of players.
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
    /// Passing stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballPassingStats? Passing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballPassingStats>(
                "passing"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passing", value);
        }
    }

    /// <summary>
    /// Rushing stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballRushingStats? Rushing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballRushingStats>(
                "rushing"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rushing", value);
        }
    }

    /// <summary>
    /// Receiving stats.
    /// </summary>
    public FootballPlayerStatsReceiving? Receiving
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsReceiving>("receiving");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("receiving", value);
        }
    }

    /// <summary>
    /// Defensive stats.
    /// </summary>
    public FootballPlayerStatsDefense? Defense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsDefense>("defense");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defense", value);
        }
    }

    /// <summary>
    /// Fumble stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballFumbleStats? Fumbles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballFumbleStats>(
                "fumbles"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fumbles", value);
        }
    }

    /// <summary>
    /// Kick, punt or interception return stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballReturnStats? KickReturns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballReturnStats>(
                "kickReturns"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("kickReturns", value);
        }
    }

    /// <summary>
    /// Kick, punt or interception return stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballReturnStats? PuntReturns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballReturnStats>(
                "puntReturns"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("puntReturns", value);
        }
    }

    /// <summary>
    /// Kick, punt or interception return stats.
    /// </summary>
    public global::XTwitterScraper.Models.FootballReturnStats? InterceptionReturns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballReturnStats>(
                "interceptionReturns"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("interceptionReturns", value);
        }
    }

    /// <summary>
    /// Punting stats.
    /// </summary>
    public FootballPlayerStatsPunts? Punts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsPunts>("punts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("punts", value);
        }
    }

    /// <summary>
    /// Field goal stats.
    /// </summary>
    public FootballPlayerStatsFieldGoals? FieldGoals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsFieldGoals>("fieldGoals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fieldGoals", value);
        }
    }

    /// <summary>
    /// Extra point kicks.
    /// </summary>
    public FootballPlayerStatsExtraPoints? ExtraPoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsExtraPoints>("extraPoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extraPoints", value);
        }
    }

    /// <summary>
    /// 2-point conversions.
    /// </summary>
    public FootballPlayerStatsConversions? Conversions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayerStatsConversions>("conversions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PlayerID;
        this.Passing?.Validate();
        this.Rushing?.Validate();
        this.Receiving?.Validate();
        this.Defense?.Validate();
        this.Fumbles?.Validate();
        this.KickReturns?.Validate();
        this.PuntReturns?.Validate();
        this.InterceptionReturns?.Validate();
        this.Punts?.Validate();
        this.FieldGoals?.Validate();
        this.ExtraPoints?.Validate();
        this.Conversions?.Validate();
    }

    public FootballPlayerStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStats(FootballPlayerStats footballPlayerStats)
        : base(footballPlayerStats) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayerStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayerStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayerStatsFromRaw.FromRawUnchecked"/>
    public static FootballPlayerStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayerStatsFromRaw : IFromRawJson<FootballPlayerStats>
{
    /// <inheritdoc/>
    public FootballPlayerStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayerStats.FromRawUnchecked(rawData);
}
