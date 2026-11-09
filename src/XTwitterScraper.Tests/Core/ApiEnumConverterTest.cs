// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests.Core;

public class ApiEnumConverterTest
{
    public static TheoryData<Type> ApiEnumTypes() =>
        new(
            typeof(ModelBase)
                .Assembly.GetTypes()
                .Where(type => !type.ContainsGenericParameters)
                .SelectMany(type => type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                .SelectMany(property => ApiEnums(property.PropertyType))
                .Distinct()
                .OrderBy(type => type.FullName, StringComparer.Ordinal)
        );

    [Theory]
    [MemberData(nameof(ApiEnumTypes))]
    public void ApiEnumRoundTripsAnyRawValue(Type type)
    {
        var raw = type.GetGenericArguments()[0];
        using var document = JsonDocument.Parse(raw == typeof(string) ? "\"unlisted\"" : "1");
        var json = document.RootElement;

        var value = json.Deserialize(type, ModelBase.SerializerOptions);
        var again = JsonSerializer.SerializeToElement(value, type, ModelBase.SerializerOptions);

        Assert.True(JsonElement.DeepEquals(json, again), $"{type}\nactual {again}");
    }

    static IEnumerable<Type> ApiEnums(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApiEnum<,>) ? [type]
        : type.IsGenericType ? type.GetGenericArguments().SelectMany(ApiEnums)
        : [];
}
