// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests.Models;

public class WireSampleRoundtripTest
{
    static readonly Lazy<IReadOnlyDictionary<string, JsonElement>> Rows = new(LoadRows);

    static IReadOnlyDictionary<string, JsonElement> LoadRows()
    {
        using var stream =
            typeof(WireSampleRoundtripTest).Assembly.GetManifestResourceStream("WireSamples.json")
            ?? throw new InvalidOperationException("WireSamples.json is not embedded");
        using var document = JsonDocument.Parse(stream);
        return document
            .RootElement.GetProperty("samples")
            .EnumerateArray()
            .ToDictionary(row => row.GetProperty("name").GetString()!, row => row.Clone());
    }

    public static TheoryData<string> RowNames() => new(Rows.Value.Keys);

    [Fact]
    public void FixtureCoversEveryRow()
    {
        Assert.Equal(952, Rows.Value.Count);
    }

    [Theory]
    [MemberData(nameof(RowNames))]
    public void RowRoundTripsUnchanged(string name)
    {
        var row = Rows.Value[name];
        var type = typeof(ModelBase).Assembly.GetType(
            row.GetProperty("type").GetString()!,
            throwOnError: true
        )!;
        var target = row.GetProperty("list").GetBoolean()
            ? typeof(IReadOnlyList<>).MakeGenericType(type)
            : type;
        var json = row.GetProperty("json");

        var value = json.Deserialize(target, ModelBase.SerializerOptions);
        foreach (var model in Models(value))
        {
            model.Validate();
        }
        var again = JsonSerializer.SerializeToElement(value, target, ModelBase.SerializerOptions);

        Assert.True(
            JsonElement.DeepEquals(json, again),
            string.Format("{0}\nexpected {1}\nactual   {2}", name, json, again)
        );
    }

    static IEnumerable<ModelBase> Models(object? value) =>
        value switch
        {
            ModelBase model => [model],
            IEnumerable items and not string => items.OfType<ModelBase>(),
            _ => [],
        };
}
