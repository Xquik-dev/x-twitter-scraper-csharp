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

[JsonConverter(typeof(JsonModelConverter<FootballSchedulePeriod, FootballSchedulePeriodFromRaw>))]
public sealed record class FootballSchedulePeriod : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
    }

    public FootballSchedulePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballSchedulePeriod(FootballSchedulePeriod footballSchedulePeriod)
        : base(footballSchedulePeriod) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballSchedulePeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballSchedulePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballSchedulePeriodFromRaw.FromRawUnchecked"/>
    public static FootballSchedulePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballSchedulePeriodFromRaw : IFromRawJson<FootballSchedulePeriod>
{
    /// <inheritdoc/>
    public FootballSchedulePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballSchedulePeriod.FromRawUnchecked(rawData);
}
