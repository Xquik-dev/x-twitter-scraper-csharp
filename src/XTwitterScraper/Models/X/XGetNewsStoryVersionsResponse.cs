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

namespace XTwitterScraper.Models.X;

[JsonConverter(
    typeof(JsonModelConverter<XGetNewsStoryVersionsResponse, XGetNewsStoryVersionsResponseFromRaw>)
)]
public sealed record class XGetNewsStoryVersionsResponse : JsonModel
{
    /// <summary>
    /// The story's ID, as the request named it.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Versions returned.
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

    public required IReadOnlyList<global::XTwitterScraper.Models.NewsVersion> Versions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.NewsVersion>
            >("versions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.NewsVersion>>(
                "versions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Count;
        foreach (var item in this.Versions)
        {
            item.Validate();
        }
    }

    public XGetNewsStoryVersionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetNewsStoryVersionsResponse(
        XGetNewsStoryVersionsResponse xGetNewsStoryVersionsResponse
    )
        : base(xGetNewsStoryVersionsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetNewsStoryVersionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetNewsStoryVersionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetNewsStoryVersionsResponseFromRaw.FromRawUnchecked"/>
    public static XGetNewsStoryVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetNewsStoryVersionsResponseFromRaw : IFromRawJson<XGetNewsStoryVersionsResponse>
{
    /// <inheritdoc/>
    public XGetNewsStoryVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetNewsStoryVersionsResponse.FromRawUnchecked(rawData);
}
