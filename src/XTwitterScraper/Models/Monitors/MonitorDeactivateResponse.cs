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

namespace XTwitterScraper.Models.Monitors;

[JsonConverter(
    typeof(JsonModelConverter<MonitorDeactivateResponse, MonitorDeactivateResponseFromRaw>)
)]
public sealed record class MonitorDeactivateResponse : JsonModel
{
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public ApiEnum<string, MonitorDeactivateResponseDeletionStatus>? DeletionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, MonitorDeactivateResponseDeletionStatus>
            >("deletionStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deletionStatus", value);
        }
    }

    /// <summary>
    /// Poll this monitor URL until it returns 404.
    /// </summary>
    public string? StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("statusUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.DeletionStatus?.Validate();
        _ = this.StatusUrl;
    }

    public MonitorDeactivateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorDeactivateResponse(MonitorDeactivateResponse monitorDeactivateResponse)
        : base(monitorDeactivateResponse) { }
#pragma warning restore CS8618

    public MonitorDeactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorDeactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static MonitorDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorDeactivateResponseFromRaw : IFromRawJson<MonitorDeactivateResponse>
{
    /// <inheritdoc/>
    public MonitorDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonitorDeactivateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MonitorDeactivateResponseDeletionStatusConverter))]
public enum MonitorDeactivateResponseDeletionStatus
{
    Deleting,
}

sealed class MonitorDeactivateResponseDeletionStatusConverter
    : JsonConverter<MonitorDeactivateResponseDeletionStatus>
{
    public override MonitorDeactivateResponseDeletionStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deleting" => MonitorDeactivateResponseDeletionStatus.Deleting,
            _ => (MonitorDeactivateResponseDeletionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonitorDeactivateResponseDeletionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonitorDeactivateResponseDeletionStatus.Deleting => "deleting",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
