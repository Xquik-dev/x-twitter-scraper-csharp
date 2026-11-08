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
    typeof(JsonModelConverter<
        CommunityListSuggestedResponse,
        CommunityListSuggestedResponseFromRaw
    >)
)]
public sealed record class CommunityListSuggestedResponse : JsonModel
{
    /// <summary>
    /// Suggested communities in X's order
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.X.Communities.Community> Communities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.X.Communities.Community>
            >("communities");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.X.Communities.Community>
            >("communities", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Communities returned &amp; charged
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
    /// What to do next. Present only when X suggests none.
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
        foreach (var item in this.Communities)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Message;
    }

    public CommunityListSuggestedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityListSuggestedResponse(
        CommunityListSuggestedResponse communityListSuggestedResponse
    )
        : base(communityListSuggestedResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityListSuggestedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityListSuggestedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityListSuggestedResponseFromRaw.FromRawUnchecked"/>
    public static CommunityListSuggestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityListSuggestedResponseFromRaw : IFromRawJson<CommunityListSuggestedResponse>
{
    /// <inheritdoc/>
    public CommunityListSuggestedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityListSuggestedResponse.FromRawUnchecked(rawData);
}
