// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(FollowerClassConverter))]
public enum FollowerClass
{
    Automated,
    Inactive,
    LikelyFake,
    LikelyReal,
    TooNew,
}

sealed class FollowerClassConverter : JsonConverter<FollowerClass>
{
    public override FollowerClass Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "automated" => FollowerClass.Automated,
            "inactive" => FollowerClass.Inactive,
            "likelyFake" => FollowerClass.LikelyFake,
            "likelyReal" => FollowerClass.LikelyReal,
            "tooNew" => FollowerClass.TooNew,
            _ => (FollowerClass)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowerClass value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowerClass.Automated => "automated",
                FollowerClass.Inactive => "inactive",
                FollowerClass.LikelyFake => "likelyFake",
                FollowerClass.LikelyReal => "likelyReal",
                FollowerClass.TooNew => "tooNew",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
