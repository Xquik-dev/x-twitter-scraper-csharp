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

[JsonConverter(typeof(XWriteActionNextActionTypeConverter))]
public enum XWriteActionNextActionType
{
    Poll,
    Retry,
    VerifyResult,
    FixRequest,
}

sealed class XWriteActionNextActionTypeConverter : JsonConverter<XWriteActionNextActionType>
{
    public override XWriteActionNextActionType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "poll" => XWriteActionNextActionType.Poll,
            "retry" => XWriteActionNextActionType.Retry,
            "verify_result" => XWriteActionNextActionType.VerifyResult,
            "fix_request" => XWriteActionNextActionType.FixRequest,
            _ => (XWriteActionNextActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionNextActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionNextActionType.Poll => "poll",
                XWriteActionNextActionType.Retry => "retry",
                XWriteActionNextActionType.VerifyResult => "verify_result",
                XWriteActionNextActionType.FixRequest => "fix_request",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XWriteActionNextAction, XWriteActionNextActionFromRaw>))]
public sealed record class XWriteActionNextAction : JsonModel
{
    public required ApiEnum<string, XWriteActionNextActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionNextActionType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <summary>
    /// Milliseconds to wait before you poll or retry.
    /// </summary>
    public long? AfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("afterMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("afterMs", value);
        }
    }

    public bool? RequiresNewIdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("requiresNewIdempotencyKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requiresNewIdempotencyKey", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.UrlValue;
        _ = this.AfterMs;
        _ = this.RequiresNewIdempotencyKey;
    }

    public XWriteActionNextAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionNextAction(XWriteActionNextAction xWriteActionNextAction)
        : base(xWriteActionNextAction) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionNextAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteActionNextAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionNextActionFromRaw.FromRawUnchecked"/>
    public static XWriteActionNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionNextActionFromRaw : IFromRawJson<XWriteActionNextAction>
{
    /// <inheritdoc/>
    public XWriteActionNextAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XWriteActionNextAction.FromRawUnchecked(rawData);
}
