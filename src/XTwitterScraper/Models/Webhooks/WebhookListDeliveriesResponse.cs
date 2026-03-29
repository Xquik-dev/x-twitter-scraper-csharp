using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<WebhookListDeliveriesResponse, WebhookListDeliveriesResponseFromRaw>)
)]
public sealed record class WebhookListDeliveriesResponse : JsonModel
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

    public WebhookListDeliveriesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListDeliveriesResponse(
        WebhookListDeliveriesResponse webhookListDeliveriesResponse
    )
        : base(webhookListDeliveriesResponse) { }
#pragma warning restore CS8618

    public WebhookListDeliveriesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListDeliveriesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListDeliveriesResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListDeliveriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookListDeliveriesResponse(IReadOnlyList<Delivery> deliveries)
        : this()
    {
        this.Deliveries = deliveries;
    }
}

class WebhookListDeliveriesResponseFromRaw : IFromRawJson<WebhookListDeliveriesResponse>
{
    /// <inheritdoc/>
    public WebhookListDeliveriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListDeliveriesResponse.FromRawUnchecked(rawData);
}

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

    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string StreamEventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("streamEventId");
        }
        init { this._rawData.Set("streamEventId", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Attempts;
        _ = this.CreatedAt;
        _ = this.Status;
        _ = this.StreamEventID;
        _ = this.DeliveredAt;
        _ = this.LastError;
        _ = this.LastStatusCode;
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
