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

[JsonConverter(typeof(JsonModelConverter<FootballOdds, FootballOddsFromRaw>))]
public sealed record class FootballOdds : JsonModel
{
    /// <summary>
    /// The money line. X sends it for the away team only.
    /// </summary>
    public required string? MoneyLine
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("moneyLine");
        }
        init { this._rawData.Set("moneyLine", value); }
    }

    /// <summary>
    /// The point spread.
    /// </summary>
    public required string? Spread
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("spread");
        }
        init { this._rawData.Set("spread", value); }
    }

    /// <summary>
    /// The over or under total.
    /// </summary>
    public required string? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MoneyLine;
        _ = this.Spread;
        _ = this.Total;
    }

    public FootballOdds() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballOdds(FootballOdds footballOdds)
        : base(footballOdds) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballOdds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballOdds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballOddsFromRaw.FromRawUnchecked"/>
    public static FootballOdds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballOddsFromRaw : IFromRawJson<FootballOdds>
{
    /// <inheritdoc/>
    public FootballOdds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballOdds.FromRawUnchecked(rawData);
}
