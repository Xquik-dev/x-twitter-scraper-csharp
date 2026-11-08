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

[JsonConverter(typeof(JsonModelConverter<FootballPeriod, FootballPeriodFromRaw>))]
public sealed record class FootballPeriod : JsonModel
{
    /// <summary>
    /// X's name for the period, such as Quarter.
    /// </summary>
    public required string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The period's number, or null when X sends no digits.
    /// </summary>
    public required long? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// The period's place in the game, from 1.
    /// </summary>
    public required long? Sequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sequence");
        }
        init { this._rawData.Set("sequence", value); }
    }

    /// <summary>
    /// The home team's points in the period.
    /// </summary>
    public required long? HomePoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("homePoints");
        }
        init { this._rawData.Set("homePoints", value); }
    }

    /// <summary>
    /// The away team's points in the period.
    /// </summary>
    public required long? AwayPoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("awayPoints");
        }
        init { this._rawData.Set("awayPoints", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Number;
        _ = this.Sequence;
        _ = this.HomePoints;
        _ = this.AwayPoints;
    }

    public FootballPeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPeriod(FootballPeriod footballPeriod)
        : base(footballPeriod) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPeriodFromRaw.FromRawUnchecked"/>
    public static FootballPeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPeriodFromRaw : IFromRawJson<FootballPeriod>
{
    /// <inheritdoc/>
    public FootballPeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPeriod.FromRawUnchecked(rawData);
}
