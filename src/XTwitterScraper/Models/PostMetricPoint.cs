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

[JsonConverter(typeof(JsonModelConverter<PostMetricPoint, PostMetricPointFromRaw>))]
public sealed record class PostMetricPoint : JsonModel
{
    public required long? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    public required long? Gain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("gain");
        }
        init { this._rawData.Set("gain", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
        _ = this.Gain;
    }

    public PostMetricPoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetricPoint(PostMetricPoint postMetricPoint)
        : base(postMetricPoint) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetricPoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMetricPoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMetricPointFromRaw.FromRawUnchecked"/>
    public static PostMetricPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMetricPointFromRaw : IFromRawJson<PostMetricPoint>
{
    /// <inheritdoc/>
    public PostMetricPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMetricPoint.FromRawUnchecked(rawData);
}
