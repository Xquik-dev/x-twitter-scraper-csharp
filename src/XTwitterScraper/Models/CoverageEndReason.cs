// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

/// <summary>
/// Present on a last page that X cut short. `stalled` means X returned no new results 2
/// times in a row, 30 s apart. The list may hold more. Read it again later without cursor.
/// </summary>
[JsonConverter(typeof(CoverageEndReasonConverter))]
public enum CoverageEndReason
{
    Stalled,
}

sealed class CoverageEndReasonConverter : JsonConverter<CoverageEndReason>
{
    public override CoverageEndReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stalled" => CoverageEndReason.Stalled,
            _ => (CoverageEndReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CoverageEndReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CoverageEndReason.Stalled => "stalled",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
