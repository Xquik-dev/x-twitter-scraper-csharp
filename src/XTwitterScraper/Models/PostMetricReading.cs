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

[JsonConverter(typeof(JsonModelConverter<PostMetricReading, PostMetricReadingFromRaw>))]
public sealed record class PostMetricReading : JsonModel
{
    public required long? Current
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("current");
        }
        init { this._rawData.Set("current", value); }
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
        _ = this.Current;
        _ = this.Gain;
    }

    public PostMetricReading() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetricReading(PostMetricReading postMetricReading)
        : base(postMetricReading) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMetricReading(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMetricReading(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMetricReadingFromRaw.FromRawUnchecked"/>
    public static PostMetricReading FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMetricReadingFromRaw : IFromRawJson<PostMetricReading>
{
    /// <inheritdoc/>
    public PostMetricReading FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMetricReading.FromRawUnchecked(rawData);
}
