// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Tests.Core;

public class EnumConverterTest
{
    public static TheoryData<Type> ConvertedEnums() =>
        new(
            typeof(ModelBase)
                .Assembly.GetTypes()
                .Where(type => type.IsEnum && type.IsDefined(typeof(JsonConverterAttribute), false))
                .OrderBy(type => type.FullName, StringComparer.Ordinal)
        );

    [Theory]
    [MemberData(nameof(ConvertedEnums))]
    public void ListedValuesRoundTrip(Type type)
    {
        foreach (var value in Enum.GetValues(type))
        {
            var json = JsonSerializer.SerializeToElement(value, type, ModelBase.SerializerOptions);

            Assert.Equal(value, json.Deserialize(type, ModelBase.SerializerOptions));
        }
    }

    [Theory]
    [MemberData(nameof(ConvertedEnums))]
    public void UnlistedValueReadsAsSentinelThatRefusesToWrite(Type type)
    {
        var listed = Enum.GetValues(type)
            .Cast<object>()
            .Select(value =>
                JsonSerializer.SerializeToElement(value, type, ModelBase.SerializerOptions)
            )
            .ToArray();
        var unlisted =
            listed[0].ValueKind == JsonValueKind.String
                ? JsonSerializer.SerializeToElement("unlisted")
                : JsonSerializer.SerializeToElement(listed.Max(json => json.GetInt64()) + 1);
        Assert.DoesNotContain(listed, json => JsonElement.DeepEquals(json, unlisted));

        var sentinel = unlisted.Deserialize(type, ModelBase.SerializerOptions);

        Assert.Equal(Enum.ToObject(type, -1), sentinel);
        Assert.Throws<XTwitterScraperInvalidDataException>(() =>
            JsonSerializer.Serialize(sentinel, type, ModelBase.SerializerOptions)
        );
    }
}
