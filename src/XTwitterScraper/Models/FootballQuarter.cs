// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<FootballQuarter, FootballQuarterFromRaw>))]
public sealed record class FootballQuarter : JsonModel
{
    /// <summary>
    /// X's ID for the quarter within the game.
    /// </summary>
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The quarter's number.
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
    /// The quarter's place in the game, from 1.
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
    /// The quarter's drives, in order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballDrive> Drives
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballDrive>
            >("drives");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballDrive>>(
                "drives",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Number;
        _ = this.Sequence;
        foreach (var item in this.Drives)
        {
            item.Validate();
        }
    }

    public FootballQuarter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballQuarter(FootballQuarter footballQuarter)
        : base(footballQuarter) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballQuarter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballQuarter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballQuarterFromRaw.FromRawUnchecked"/>
    public static FootballQuarter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballQuarterFromRaw : IFromRawJson<FootballQuarter>
{
    /// <inheritdoc/>
    public FootballQuarter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballQuarter.FromRawUnchecked(rawData);
}
