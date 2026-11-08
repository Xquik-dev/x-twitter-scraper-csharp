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

[JsonConverter(typeof(XWriteActionResultTypeConverter))]
public enum XWriteActionResultType
{
    Tweet,
    DirectMessage,
    Media,
    Community,
    StateChange,
}

sealed class XWriteActionResultTypeConverter : JsonConverter<XWriteActionResultType>
{
    public override XWriteActionResultType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet" => XWriteActionResultType.Tweet,
            "direct_message" => XWriteActionResultType.DirectMessage,
            "media" => XWriteActionResultType.Media,
            "community" => XWriteActionResultType.Community,
            "state_change" => XWriteActionResultType.StateChange,
            _ => (XWriteActionResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionResultType.Tweet => "tweet",
                XWriteActionResultType.DirectMessage => "direct_message",
                XWriteActionResultType.Media => "media",
                XWriteActionResultType.Community => "community",
                XWriteActionResultType.StateChange => "state_change",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XWriteActionResult, XWriteActionResultFromRaw>))]
public sealed record class XWriteActionResult : JsonModel
{
    public ApiEnum<string, XWriteActionResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, XWriteActionResultType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
        _ = this.ID;
        _ = this.State;
    }

    public XWriteActionResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionResult(XWriteActionResult xWriteActionResult)
        : base(xWriteActionResult) { }
#pragma warning restore CS8618

    public XWriteActionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteActionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionResultFromRaw.FromRawUnchecked"/>
    public static XWriteActionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionResultFromRaw : IFromRawJson<XWriteActionResult>
{
    /// <inheritdoc/>
    public XWriteActionResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XWriteActionResult.FromRawUnchecked(rawData);
}
