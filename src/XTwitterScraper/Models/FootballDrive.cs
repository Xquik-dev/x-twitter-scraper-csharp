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

[JsonConverter(typeof(JsonModelConverter<FootballDrive, FootballDriveFromRaw>))]
public sealed record class FootballDrive : JsonModel
{
    /// <summary>
    /// X's ID for the drive within the game.
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
    /// The drive's place in the game, from 1.
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
    /// The team that drove. Home or Away in NFL games, the team's alternateId in college games.
    /// </summary>
    public required string? Offense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("offense");
        }
        init { this._rawData.Set("offense", value); }
    }

    /// <summary>
    /// The team on defense. X stopped sending it on 2026-10-24, so it is null.
    /// </summary>
    public required string? Defense
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("defense");
        }
        init { this._rawData.Set("defense", value); }
    }

    /// <summary>
    /// The game clock when the drive started, as HH:MM:SS.
    /// </summary>
    public required string? StartClock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("startClock");
        }
        init { this._rawData.Set("startClock", value); }
    }

    /// <summary>
    /// The game clock when the drive ended, as HH:MM:SS.
    /// </summary>
    public required string? EndClock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endClock");
        }
        init { this._rawData.Set("endClock", value); }
    }

    /// <summary>
    /// How the drive started, such as Kickoff or Punt. X stopped sending it on 2026-10-24, so it is null.
    /// </summary>
    public required string? StartReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("startReason");
        }
        init { this._rawData.Set("startReason", value); }
    }

    /// <summary>
    /// How the drive ended, such as Touchdown or Punt.
    /// </summary>
    public required string? EndReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endReason");
        }
        init { this._rawData.Set("endReason", value); }
    }

    /// <summary>
    /// The drive's plays.
    /// </summary>
    public required long? PlayCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("playCount");
        }
        init { this._rawData.Set("playCount", value); }
    }

    /// <summary>
    /// The first downs the drive gained. X stopped sending it on 2026-10-24, so it is null.
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
    /// The yards the drive gained.
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
    /// Whether the drive scored. X stopped sending it on 2026-10-24, so it is null. Each play still says whether it scored.
    /// </summary>
    public required bool? Scoring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("scoring");
        }
        init { this._rawData.Set("scoring", value); }
    }

    /// <summary>
    /// The drive's plays, in order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPlay> Plays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPlay>
            >("plays");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPlay>>(
                "plays",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Sequence;
        _ = this.Offense;
        _ = this.Defense;
        _ = this.StartClock;
        _ = this.EndClock;
        _ = this.StartReason;
        _ = this.EndReason;
        _ = this.PlayCount;
        _ = this.FirstDowns;
        _ = this.NetYards;
        _ = this.Scoring;
        foreach (var item in this.Plays)
        {
            item.Validate();
        }
    }

    public FootballDrive() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballDrive(FootballDrive footballDrive)
        : base(footballDrive) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballDrive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballDrive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballDriveFromRaw.FromRawUnchecked"/>
    public static FootballDrive FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballDriveFromRaw : IFromRawJson<FootballDrive>
{
    /// <inheritdoc/>
    public FootballDrive FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballDrive.FromRawUnchecked(rawData);
}
