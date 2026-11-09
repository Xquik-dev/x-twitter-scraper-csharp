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

[JsonConverter(typeof(JsonModelConverter<JobLocations, JobLocationsFromRaw>))]
public sealed record class JobLocations : JsonModel
{
    /// <summary>
    /// Matching places, best match first.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.JobLocation> Locations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.JobLocation>
            >("locations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.JobLocation>>(
                "locations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Places returned, each charged 1 credit.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Locations)
        {
            item.Validate();
        }
        _ = this.Count;
    }

    public JobLocations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobLocations(JobLocations jobLocations)
        : base(jobLocations) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobLocations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobLocations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobLocationsFromRaw.FromRawUnchecked"/>
    public static JobLocations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobLocationsFromRaw : IFromRawJson<JobLocations>
{
    /// <inheritdoc/>
    public JobLocations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobLocations.FromRawUnchecked(rawData);
}
