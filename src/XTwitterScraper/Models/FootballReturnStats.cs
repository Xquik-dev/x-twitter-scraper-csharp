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

[JsonConverter(typeof(JsonModelConverter<FootballReturnStats, FootballReturnStatsFromRaw>))]
public sealed record class FootballReturnStats : JsonModel
{
    /// <summary>
    /// Yards per return.
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
    /// The longest return, in yards.
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
    /// Returns.
    /// </summary>
    public required long? Returns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("returns");
        }
        init { this._rawData.Set("returns", value); }
    }

    /// <summary>
    /// Return touchdowns.
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
    /// Return yards.
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
        _ = this.Returns;
        _ = this.Touchdowns;
        _ = this.Yards;
    }

    public FootballReturnStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballReturnStats(FootballReturnStats footballReturnStats)
        : base(footballReturnStats) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballReturnStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballReturnStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballReturnStatsFromRaw.FromRawUnchecked"/>
    public static FootballReturnStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballReturnStatsFromRaw : IFromRawJson<FootballReturnStats>
{
    /// <inheritdoc/>
    public FootballReturnStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballReturnStats.FromRawUnchecked(rawData);
}
