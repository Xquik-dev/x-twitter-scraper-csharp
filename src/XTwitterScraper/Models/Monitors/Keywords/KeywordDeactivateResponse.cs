// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Monitors.Keywords;

[JsonConverter(
    typeof(JsonModelConverter<KeywordDeactivateResponse, KeywordDeactivateResponseFromRaw>)
)]
public sealed record class KeywordDeactivateResponse : JsonModel
{
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public KeywordDeactivateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeywordDeactivateResponse(KeywordDeactivateResponse keywordDeactivateResponse)
        : base(keywordDeactivateResponse) { }
#pragma warning restore CS8618

    public KeywordDeactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KeywordDeactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeywordDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static KeywordDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeywordDeactivateResponseFromRaw : IFromRawJson<KeywordDeactivateResponse>
{
    /// <inheritdoc/>
    public KeywordDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KeywordDeactivateResponse.FromRawUnchecked(rawData);
}
