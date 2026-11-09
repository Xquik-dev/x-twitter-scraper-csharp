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

[JsonConverter(typeof(JsonModelConverter<FollowerValueCount, FollowerValueCountFromRaw>))]
public sealed record class FollowerValueCount : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Percent;
        _ = this.Value;
    }

    public FollowerValueCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerValueCount(FollowerValueCount followerValueCount)
        : base(followerValueCount) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerValueCount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerValueCount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerValueCountFromRaw.FromRawUnchecked"/>
    public static FollowerValueCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerValueCountFromRaw : IFromRawJson<FollowerValueCount>
{
    /// <inheritdoc/>
    public FollowerValueCount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FollowerValueCount.FromRawUnchecked(rawData);
}
