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

[JsonConverter(typeof(JsonModelConverter<FootballRushingStats, FootballRushingStatsFromRaw>))]
public sealed record class FootballRushingStats : JsonModel
{
    /// <summary>
    /// Rushes.
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
    /// Yards per rush.
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
    /// The longest rush, in yards.
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
    /// Rushing touchdowns.
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
    /// Rushing yards.
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
        _ = this.Longest;
        _ = this.Touchdowns;
        _ = this.Yards;
    }

    public FootballRushingStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRushingStats(FootballRushingStats footballRushingStats)
        : base(footballRushingStats) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballRushingStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballRushingStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballRushingStatsFromRaw.FromRawUnchecked"/>
    public static FootballRushingStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballRushingStatsFromRaw : IFromRawJson<FootballRushingStats>
{
    /// <inheritdoc/>
    public FootballRushingStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballRushingStats.FromRawUnchecked(rawData);
}
