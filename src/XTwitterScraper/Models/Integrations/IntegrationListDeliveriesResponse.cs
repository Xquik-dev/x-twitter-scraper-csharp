using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Integrations;

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationListDeliveriesResponse,
        IntegrationListDeliveriesResponseFromRaw
    >)
)]
public sealed record class IntegrationListDeliveriesResponse : JsonModel
{
    public required IReadOnlyList<Delivery> Deliveries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Delivery>>("deliveries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Delivery>>(
                "deliveries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Deliveries)
        {
            item.Validate();
        }
    }

    public IntegrationListDeliveriesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationListDeliveriesResponse(
        IntegrationListDeliveriesResponse integrationListDeliveriesResponse
    )
        : base(integrationListDeliveriesResponse) { }
#pragma warning restore CS8618

    public IntegrationListDeliveriesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationListDeliveriesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationListDeliveriesResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationListDeliveriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationListDeliveriesResponse(IReadOnlyList<Delivery> deliveries)
        : this()
    {
        this.Deliveries = deliveries;
    }
}

class IntegrationListDeliveriesResponseFromRaw : IFromRawJson<IntegrationListDeliveriesResponse>
{
    /// <inheritdoc/>
    public IntegrationListDeliveriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationListDeliveriesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Integration delivery attempt record with status and retry count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Delivery, DeliveryFromRaw>))]
public sealed record class Delivery : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required long Attempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("attempts");
        }
        init { this._rawData.Set("attempts", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventType");
        }
        init { this._rawData.Set("eventType", value); }
    }

    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("deliveredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deliveredAt", value);
        }
    }

    public string? LastError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastError");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastError", value);
        }
    }

    public long? LastStatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("lastStatusCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastStatusCode", value);
        }
    }

    public string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceId", value);
        }
    }

    public string? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Attempts;
        _ = this.CreatedAt;
        _ = this.EventType;
        _ = this.Status;
        _ = this.DeliveredAt;
        _ = this.LastError;
        _ = this.LastStatusCode;
        _ = this.SourceID;
        _ = this.SourceType;
    }

    public Delivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Delivery(Delivery delivery)
        : base(delivery) { }
#pragma warning restore CS8618

    public Delivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeliveryFromRaw.FromRawUnchecked"/>
    public static Delivery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeliveryFromRaw : IFromRawJson<Delivery>
{
    /// <inheritdoc/>
    public Delivery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delivery.FromRawUnchecked(rawData);
}
