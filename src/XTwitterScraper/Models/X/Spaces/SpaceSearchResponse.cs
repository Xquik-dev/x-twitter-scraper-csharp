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

namespace XTwitterScraper.Models.X.Spaces;

[JsonConverter(typeof(JsonModelConverter<SpaceSearchResponse, SpaceSearchResponseFromRaw>))]
public sealed record class SpaceSearchResponse : JsonModel
{
    /// <summary>
    /// Public Spaces, each once. Latest &amp; Top list them in the order the posts share them. Live &amp; Upcoming keep X's order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.Space> Spaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.Space>
            >("spaces");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.Space>>(
                "spaces",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Cursor for the next page. Send it unchanged. Each next page arrives fast.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Spaces)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public SpaceSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceSearchResponse(SpaceSearchResponse spaceSearchResponse)
        : base(spaceSearchResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceSearchResponseFromRaw.FromRawUnchecked"/>
    public static SpaceSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceSearchResponseFromRaw : IFromRawJson<SpaceSearchResponse>
{
    /// <inheritdoc/>
    public SpaceSearchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpaceSearchResponse.FromRawUnchecked(rawData);
}
