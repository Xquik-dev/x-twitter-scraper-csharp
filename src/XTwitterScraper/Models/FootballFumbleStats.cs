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

[JsonConverter(typeof(JsonModelConverter<FootballFumbleStats, FootballFumbleStatsFromRaw>))]
public sealed record class FootballFumbleStats : JsonModel
{
    /// <summary>
    /// Fumbles the other team recovered.
    /// </summary>
    public required long? Lost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("lost");
        }
        init { this._rawData.Set("lost", value); }
    }

    /// <summary>
    /// Touchdowns scored after recovering the other team's fumble.
    /// </summary>
    public required long? OpponentRecoveryTouchdowns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("opponentRecoveryTouchdowns");
        }
        init { this._rawData.Set("opponentRecoveryTouchdowns", value); }
    }

    /// <summary>
    /// Touchdowns scored after recovering an own fumble.
    /// </summary>
    public required long? OwnRecoveryTouchdowns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ownRecoveryTouchdowns");
        }
        init { this._rawData.Set("ownRecoveryTouchdowns", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Lost;
        _ = this.OpponentRecoveryTouchdowns;
        _ = this.OwnRecoveryTouchdowns;
    }

    public FootballFumbleStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballFumbleStats(FootballFumbleStats footballFumbleStats)
        : base(footballFumbleStats) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballFumbleStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballFumbleStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballFumbleStatsFromRaw.FromRawUnchecked"/>
    public static FootballFumbleStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballFumbleStatsFromRaw : IFromRawJson<FootballFumbleStats>
{
    /// <inheritdoc/>
    public FootballFumbleStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballFumbleStats.FromRawUnchecked(rawData);
}
