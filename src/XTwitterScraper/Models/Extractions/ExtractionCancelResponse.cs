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

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(
    typeof(JsonModelConverter<ExtractionCancelResponse, ExtractionCancelResponseFromRaw>)
)]
public sealed record class ExtractionCancelResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, ExtractionCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionCancelResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
    }

    public ExtractionCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionCancelResponse(ExtractionCancelResponse extractionCancelResponse)
        : base(extractionCancelResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionCancelResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionCancelResponseFromRaw : IFromRawJson<ExtractionCancelResponse>
{
    /// <inheritdoc/>
    public ExtractionCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionCancelResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExtractionCancelResponseStatusConverter))]
public enum ExtractionCancelResponseStatus
{
    Canceled,
}

sealed class ExtractionCancelResponseStatusConverter : JsonConverter<ExtractionCancelResponseStatus>
{
    public override ExtractionCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "canceled" => ExtractionCancelResponseStatus.Canceled,
            _ => (ExtractionCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionCancelResponseStatus.Canceled => "canceled",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
