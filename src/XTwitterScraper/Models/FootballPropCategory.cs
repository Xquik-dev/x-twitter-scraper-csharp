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

[JsonConverter(typeof(JsonModelConverter<FootballPropCategory, FootballPropCategoryFromRaw>))]
public sealed record class FootballPropCategory : JsonModel
{
    /// <summary>
    /// X's key for the prop, such as passing_yards.
    /// </summary>
    public required string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// The name X shows for the prop.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The category's place in X's order, from 1.
    /// </summary>
    public required double? Rank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rank");
        }
        init { this._rawData.Set("rank", value); }
    }

    /// <summary>
    /// Each player's line, in X's order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPlayerProp> Props
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPlayerProp>
            >("props");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPlayerProp>>(
                "props",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Name;
        _ = this.Rank;
        foreach (var item in this.Props)
        {
            item.Validate();
        }
    }

    public FootballPropCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPropCategory(FootballPropCategory footballPropCategory)
        : base(footballPropCategory) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPropCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPropCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPropCategoryFromRaw.FromRawUnchecked"/>
    public static FootballPropCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPropCategoryFromRaw : IFromRawJson<FootballPropCategory>
{
    /// <inheritdoc/>
    public FootballPropCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FootballPropCategory.FromRawUnchecked(rawData);
}
