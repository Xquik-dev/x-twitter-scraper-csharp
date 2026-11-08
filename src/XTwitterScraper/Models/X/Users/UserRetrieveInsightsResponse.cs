// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Users;

[JsonConverter(
    typeof(JsonModelConverter<UserRetrieveInsightsResponse, UserRetrieveInsightsResponseFromRaw>)
)]
public sealed record class UserRetrieveInsightsResponse : JsonModel
{
    /// <summary>
    /// Engagement insights of 1 profile. Engagements are likes, replies, reposts and quotes. A rate is null when nothing divides it, such as a profile without posts of its own.
    /// </summary>
    public required global::XTwitterScraper.Models.UserInsights Insights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.UserInsights>(
                "insights"
            );
        }
        init { this._rawData.Set("insights", value); }
    }

    /// <summary>
    /// Says why the report has counts only. Sent only when postsPrivate is true.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Insights.Validate();
        _ = this.Message;
    }

    public UserRetrieveInsightsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveInsightsResponse(UserRetrieveInsightsResponse userRetrieveInsightsResponse)
        : base(userRetrieveInsightsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveInsightsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveInsightsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveInsightsResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveInsightsResponseFromRaw : IFromRawJson<UserRetrieveInsightsResponse>
{
    /// <inheritdoc/>
    public UserRetrieveInsightsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveInsightsResponse.FromRawUnchecked(rawData);
}
