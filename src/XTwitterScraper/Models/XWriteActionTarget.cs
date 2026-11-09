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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(XWriteActionTargetTypeConverter))]
public enum XWriteActionTargetType
{
    Tweet,
    User,
    Community,
}

sealed class XWriteActionTargetTypeConverter : JsonConverter<XWriteActionTargetType>
{
    public override XWriteActionTargetType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => XWriteActionTargetType.Tweet,
            "user" => XWriteActionTargetType.User,
            "community" => XWriteActionTargetType.Community,
            _ => (XWriteActionTargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionTargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionTargetType.Tweet => "tweet",
                XWriteActionTargetType.User => "user",
                XWriteActionTargetType.Community => "community",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XWriteActionTarget, XWriteActionTargetFromRaw>))]
public sealed record class XWriteActionTarget : JsonModel
{
    public required ApiEnum<string, XWriteActionTargetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionTargetType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ID;
    }

    public XWriteActionTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionTarget(XWriteActionTarget xWriteActionTarget)
        : base(xWriteActionTarget) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteActionTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionTargetFromRaw.FromRawUnchecked"/>
    public static XWriteActionTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionTargetFromRaw : IFromRawJson<XWriteActionTarget>
{
    /// <inheritdoc/>
    public XWriteActionTarget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XWriteActionTarget.FromRawUnchecked(rawData);
}
