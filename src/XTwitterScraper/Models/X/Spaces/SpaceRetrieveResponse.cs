// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Spaces;

[JsonConverter(typeof(JsonModelConverter<SpaceRetrieveResponse, SpaceRetrieveResponseFromRaw>))]
public sealed record class SpaceRetrieveResponse : JsonModel
{
    /// <summary>
    /// X Space
    /// </summary>
    public required global::XTwitterScraper.Models.Space Space
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.Space>("space");
        }
        init { this._rawData.Set("space", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Space.Validate();
    }

    public SpaceRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveResponse(SpaceRetrieveResponse spaceRetrieveResponse)
        : base(spaceRetrieveResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SpaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceRetrieveResponseFromRaw : IFromRawJson<SpaceRetrieveResponse>
{
    /// <inheritdoc/>
    public SpaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpaceRetrieveResponse.FromRawUnchecked(rawData);
}
