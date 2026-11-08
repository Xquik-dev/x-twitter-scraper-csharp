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

[JsonConverter(typeof(JsonModelConverter<FootballPassingStats, FootballPassingStatsFromRaw>))]
public sealed record class FootballPassingStats : JsonModel
{
    /// <summary>
    /// Passes thrown.
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
    /// Yards per pass.
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
    /// Passes caught.
    /// </summary>
    public required long? Completions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("completions");
        }
        init { this._rawData.Set("completions", value); }
    }

    /// <summary>
    /// Passes intercepted.
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
    /// Passing yards minus sack yards.
    /// </summary>
    public required long? NetYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("netYards");
        }
        init { this._rawData.Set("netYards", value); }
    }

    /// <summary>
    /// The passer rating.
    /// </summary>
    public required double? Rating
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rating");
        }
        init { this._rawData.Set("rating", value); }
    }

    /// <summary>
    /// Yards lost to sacks.
    /// </summary>
    public required long? SackYards
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sackYards");
        }
        init { this._rawData.Set("sackYards", value); }
    }

    /// <summary>
    /// Times sacked.
    /// </summary>
    public required long? Sacks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sacks");
        }
        init { this._rawData.Set("sacks", value); }
    }

    /// <summary>
    /// Passing touchdowns.
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
    /// Passing yards.
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
        _ = this.AvgYards;
        _ = this.Completions;
        _ = this.Interceptions;
        _ = this.NetYards;
        _ = this.Rating;
        _ = this.SackYards;
        _ = this.Sacks;
        _ = this.Touchdowns;
        _ = this.Yards;
    }

    public FootballPassingStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPassingStats(FootballPassingStats footballPassingStats)
        : base(footballPassingStats) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPassingStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPassingStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPassingStatsFromRaw.FromRawUnchecked"/>
    public static FootballPassingStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPassingStatsFromRaw : IFromRawJson<FootballPassingStats>
{
    /// <inheritdoc/>
    public FootballPassingStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPassingStats.FromRawUnchecked(rawData);
}
