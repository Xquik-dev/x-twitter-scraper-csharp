// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(CoverageStopReasonConverter))]
public enum CoverageStopReason
{
    CursorFailure,
    Deadline,
    Exhausted,
    Failed,
    PageLimit,
    ResultLimit,
    Stalled,
}

sealed class CoverageStopReasonConverter : JsonConverter<CoverageStopReason>
{
    public override CoverageStopReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cursor_failure" => CoverageStopReason.CursorFailure,
            "deadline" => CoverageStopReason.Deadline,
            "exhausted" => CoverageStopReason.Exhausted,
            "failed" => CoverageStopReason.Failed,
            "page_limit" => CoverageStopReason.PageLimit,
            "result_limit" => CoverageStopReason.ResultLimit,
            "stalled" => CoverageStopReason.Stalled,
            _ => (CoverageStopReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CoverageStopReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CoverageStopReason.CursorFailure => "cursor_failure",
                CoverageStopReason.Deadline => "deadline",
                CoverageStopReason.Exhausted => "exhausted",
                CoverageStopReason.Failed => "failed",
                CoverageStopReason.PageLimit => "page_limit",
                CoverageStopReason.ResultLimit => "result_limit",
                CoverageStopReason.Stalled => "stalled",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
