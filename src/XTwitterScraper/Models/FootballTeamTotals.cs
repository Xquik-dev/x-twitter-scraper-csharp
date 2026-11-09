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
    typeof(JsonModelConverter<FootballTeamTotalsThirdDowns, FootballTeamTotalsThirdDownsFromRaw>)
)]
public sealed record class FootballTeamTotalsThirdDowns : JsonModel
{
    /// <summary>
    /// Third downs tried.
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
    /// Third downs converted.
    /// </summary>
    public required long? Successes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("successes");
        }
        init { this._rawData.Set("successes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempts;
        _ = this.Successes;
    }

    public FootballTeamTotalsThirdDowns() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotalsThirdDowns(FootballTeamTotalsThirdDowns footballTeamTotalsThirdDowns)
        : base(footballTeamTotalsThirdDowns) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotalsThirdDowns(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballTeamTotalsThirdDowns(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballTeamTotalsThirdDownsFromRaw.FromRawUnchecked"/>
    public static FootballTeamTotalsThirdDowns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballTeamTotalsThirdDownsFromRaw : IFromRawJson<FootballTeamTotalsThirdDowns>
{
    /// <inheritdoc/>
    public FootballTeamTotalsThirdDowns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballTeamTotalsThirdDowns.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FootballTeamTotalsPenalties, FootballTeamTotalsPenaltiesFromRaw>)
)]
public sealed record class FootballTeamTotalsPenalties : JsonModel
{
    /// <summary>
    /// Penalties.
    /// </summary>
    public required long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Penalty yards.
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
        _ = this.Count;
        _ = this.Yards;
    }

    public FootballTeamTotalsPenalties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotalsPenalties(FootballTeamTotalsPenalties footballTeamTotalsPenalties)
        : base(footballTeamTotalsPenalties) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotalsPenalties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballTeamTotalsPenalties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballTeamTotalsPenaltiesFromRaw.FromRawUnchecked"/>
    public static FootballTeamTotalsPenalties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballTeamTotalsPenaltiesFromRaw : IFromRawJson<FootballTeamTotalsPenalties>
{
    /// <inheritdoc/>
    public FootballTeamTotalsPenalties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballTeamTotalsPenalties.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballTeamTotals, FootballTeamTotalsFromRaw>))]
public sealed record class FootballTeamTotals : JsonModel
{
    /// <summary>
    /// First downs.
    /// </summary>
    public required long? FirstDowns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("firstDowns");
        }
        init { this._rawData.Set("firstDowns", value); }
    }

    /// <summary>
    /// Third downs tried &amp; converted.
    /// </summary>
    public required FootballTeamTotalsThirdDowns? ThirdDowns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballTeamTotalsThirdDowns>("thirdDowns");
        }
        init { this._rawData.Set("thirdDowns", value); }
    }

    /// <summary>
    /// The team's fumbles, or null.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballFumbleStats? Fumbles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballFumbleStats>(
                "fumbles"
            );
        }
        init { this._rawData.Set("fumbles", value); }
    }

    /// <summary>
    /// The team's passing, or null.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballPassingStats? Passing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballPassingStats>(
                "passing"
            );
        }
        init { this._rawData.Set("passing", value); }
    }

    /// <summary>
    /// Penalties against the team.
    /// </summary>
    public required FootballTeamTotalsPenalties? Penalties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballTeamTotalsPenalties>("penalties");
        }
        init { this._rawData.Set("penalties", value); }
    }

    /// <summary>
    /// The team's rushing, or null.
    /// </summary>
    public required global::XTwitterScraper.Models.FootballRushingStats? Rushing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.FootballRushingStats>(
                "rushing"
            );
        }
        init { this._rawData.Set("rushing", value); }
    }

    /// <summary>
    /// Time with the ball, in seconds.
    /// </summary>
    public required long? TimeOfPossessionSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeOfPossessionSeconds");
        }
        init { this._rawData.Set("timeOfPossessionSeconds", value); }
    }

    /// <summary>
    /// Total yards.
    /// </summary>
    public required long? TotalYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalYards");
        }
        init { this._rawData.Set("totalYards", value); }
    }

    /// <summary>
    /// Turnovers.
    /// </summary>
    public required long? Turnovers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turnovers");
        }
        init { this._rawData.Set("turnovers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstDowns;
        this.ThirdDowns?.Validate();
        this.Fumbles?.Validate();
        this.Passing?.Validate();
        this.Penalties?.Validate();
        this.Rushing?.Validate();
        _ = this.TimeOfPossessionSeconds;
        _ = this.TotalYards;
        _ = this.Turnovers;
    }

    public FootballTeamTotals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotals(FootballTeamTotals footballTeamTotals)
        : base(footballTeamTotals) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballTeamTotals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballTeamTotals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballTeamTotalsFromRaw.FromRawUnchecked"/>
    public static FootballTeamTotals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballTeamTotalsFromRaw : IFromRawJson<FootballTeamTotals>
{
    /// <inheritdoc/>
    public FootballTeamTotals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballTeamTotals.FromRawUnchecked(rawData);
}
