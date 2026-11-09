// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Lists;

[JsonConverter(typeof(JsonModelConverter<ListRetrieveResponse, ListRetrieveResponseFromRaw>))]
public sealed record class ListRetrieveResponse : JsonModel
{
    /// <summary>
    /// Public X List with its owner's public profile. It holds public fields only.
    /// </summary>
    public required global::XTwitterScraper.Models.XList List
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.XList>("list");
        }
        init { this._rawData.Set("list", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.List.Validate();
    }

    public ListRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveResponse(ListRetrieveResponse listRetrieveResponse)
        : base(listRetrieveResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ListRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListRetrieveResponseFromRaw : IFromRawJson<ListRetrieveResponse>
{
    /// <inheritdoc/>
    public ListRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListRetrieveResponse.FromRawUnchecked(rawData);
}
