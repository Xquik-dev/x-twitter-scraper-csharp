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

[JsonConverter(typeof(XWriteActionBillingStatusConverter))]
public enum XWriteActionBillingStatus
{
    NotCharged,
    Pending,
    Charged,
    ChargeFailed,
    Refunded,
}

sealed class XWriteActionBillingStatusConverter : JsonConverter<XWriteActionBillingStatus>
{
    public override XWriteActionBillingStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_charged" => XWriteActionBillingStatus.NotCharged,
            "pending" => XWriteActionBillingStatus.Pending,
            "charged" => XWriteActionBillingStatus.Charged,
            "charge_failed" => XWriteActionBillingStatus.ChargeFailed,
            "refunded" => XWriteActionBillingStatus.Refunded,
            _ => (XWriteActionBillingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XWriteActionBillingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XWriteActionBillingStatus.NotCharged => "not_charged",
                XWriteActionBillingStatus.Pending => "pending",
                XWriteActionBillingStatus.Charged => "charged",
                XWriteActionBillingStatus.ChargeFailed => "charge_failed",
                XWriteActionBillingStatus.Refunded => "refunded",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XWriteActionBilling, XWriteActionBillingFromRaw>))]
public sealed record class XWriteActionBilling : JsonModel
{
    public required ApiEnum<string, XWriteActionBillingStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XWriteActionBillingStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required bool Charged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("charged");
        }
        init { this._rawData.Set("charged", value); }
    }

    public required string PlannedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plannedCredits");
        }
        init { this._rawData.Set("plannedCredits", value); }
    }

    public required string ChargedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargedCredits");
        }
        init { this._rawData.Set("chargedCredits", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.Charged;
        _ = this.PlannedCredits;
        _ = this.ChargedCredits;
    }

    public XWriteActionBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionBilling(XWriteActionBilling xWriteActionBilling)
        : base(xWriteActionBilling) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XWriteActionBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XWriteActionBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XWriteActionBillingFromRaw.FromRawUnchecked"/>
    public static XWriteActionBilling FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XWriteActionBillingFromRaw : IFromRawJson<XWriteActionBilling>
{
    /// <inheritdoc/>
    public XWriteActionBilling FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XWriteActionBilling.FromRawUnchecked(rawData);
}
