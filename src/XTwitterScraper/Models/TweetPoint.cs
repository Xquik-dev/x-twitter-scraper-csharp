// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(TweetPointTypeConverter))]
public enum TweetPointType
{
    Point,
}

sealed class TweetPointTypeConverter : JsonConverter<TweetPointType>
{
    public override TweetPointType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Point" => TweetPointType.Point,
            _ => (TweetPointType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetPointType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetPointType.Point => "Point",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TweetPoint, TweetPointFromRaw>))]
public sealed record class TweetPoint : JsonModel
{
    public required IReadOnlyList<double> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<double>>("coordinates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>>(
                "coordinates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, TweetPointType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetPointType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public TweetPoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetPoint(TweetPoint tweetPoint)
        : base(tweetPoint) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetPoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetPoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetPointFromRaw.FromRawUnchecked"/>
    public static TweetPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetPointFromRaw : IFromRawJson<TweetPoint>
{
    /// <inheritdoc/>
    public TweetPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetPoint.FromRawUnchecked(rawData);
}
