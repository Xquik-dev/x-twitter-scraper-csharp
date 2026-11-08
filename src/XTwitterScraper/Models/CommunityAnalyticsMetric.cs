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

[JsonConverter(
    typeof(JsonModelConverter<CommunityAnalyticsMetric, CommunityAnalyticsMetricFromRaw>)
)]
public sealed record class CommunityAnalyticsMetric : JsonModel
{
    /// <summary>
    /// Total for this metric during X's latest period.
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

    /// <summary>
    /// Change in percent from the same figure 1 day earlier. Values stay unrounded.
    /// </summary>
    public required double ChangePercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("changePercent");
        }
        init { this._rawData.Set("changePercent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.ChangePercent;
    }

    public CommunityAnalyticsMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalyticsMetric(CommunityAnalyticsMetric communityAnalyticsMetric)
        : base(communityAnalyticsMetric) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityAnalyticsMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityAnalyticsMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityAnalyticsMetricFromRaw.FromRawUnchecked"/>
    public static CommunityAnalyticsMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityAnalyticsMetricFromRaw : IFromRawJson<CommunityAnalyticsMetric>
{
    /// <inheritdoc/>
    public CommunityAnalyticsMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityAnalyticsMetric.FromRawUnchecked(rawData);
}
