// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(ShadowbanVerdictConverter))]
public enum ShadowbanVerdict
{
    Pass,
    Fail,
    Unknown,
}

sealed class ShadowbanVerdictConverter : JsonConverter<ShadowbanVerdict>
{
    public override ShadowbanVerdict Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pass" => ShadowbanVerdict.Pass,
            "fail" => ShadowbanVerdict.Fail,
            "unknown" => ShadowbanVerdict.Unknown,
            _ => (ShadowbanVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanVerdict.Pass => "pass",
                ShadowbanVerdict.Fail => "fail",
                ShadowbanVerdict.Unknown => "unknown",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
