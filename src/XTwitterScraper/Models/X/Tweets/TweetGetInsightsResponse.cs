// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(
    typeof(JsonModelConverter<TweetGetInsightsResponse, TweetGetInsightsResponseFromRaw>)
)]
public sealed record class TweetGetInsightsResponse : JsonModel
{
    /// <summary>
    /// Engagement insights of 1 tweet. Engagements are likes, replies, reposts and quotes. A rate is null when nothing divides it, such as a tweet without views.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetInsights Insights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetInsights>(
                "insights"
            );
        }
        init { this._rawData.Set("insights", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Insights.Validate();
    }

    public TweetGetInsightsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetInsightsResponse(TweetGetInsightsResponse tweetGetInsightsResponse)
        : base(tweetGetInsightsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetInsightsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetInsightsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetInsightsResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetInsightsResponseFromRaw : IFromRawJson<TweetGetInsightsResponse>
{
    /// <inheritdoc/>
    public TweetGetInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetInsightsResponse.FromRawUnchecked(rawData);
}
