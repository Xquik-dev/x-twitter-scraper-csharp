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

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(
    typeof(JsonModelConverter<CommunityListTopicsResponse, CommunityListTopicsResponseFromRaw>)
)]
public sealed record class CommunityListTopicsResponse : JsonModel
{
    /// <summary>
    /// Topics in X's order
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.CommunityTopic> Topics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.CommunityTopic>
            >("topics");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.CommunityTopic>>(
                "topics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top-level topics returned &amp; charged
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
    /// What to do next. Present only when X lists no topic.
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
        foreach (var item in this.Topics)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Message;
    }

    public CommunityListTopicsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityListTopicsResponse(CommunityListTopicsResponse communityListTopicsResponse)
        : base(communityListTopicsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityListTopicsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityListTopicsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityListTopicsResponseFromRaw.FromRawUnchecked"/>
    public static CommunityListTopicsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityListTopicsResponseFromRaw : IFromRawJson<CommunityListTopicsResponse>
{
    /// <inheritdoc/>
    public CommunityListTopicsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityListTopicsResponse.FromRawUnchecked(rawData);
}
