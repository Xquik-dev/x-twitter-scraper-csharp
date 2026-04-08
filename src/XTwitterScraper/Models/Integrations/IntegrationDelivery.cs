using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Integrations;

/// <summary>
/// Integration delivery attempt record with status and retry count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IntegrationDelivery, IntegrationDeliveryFromRaw>))]
public sealed record class IntegrationDelivery : JsonModel
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

    public IntegrationDelivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationDelivery(IntegrationDelivery integrationDelivery)
        : base(integrationDelivery) { }
#pragma warning restore CS8618

    public IntegrationDelivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationDelivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationDeliveryFromRaw.FromRawUnchecked"/>
    public static IntegrationDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationDeliveryFromRaw : IFromRawJson<IntegrationDelivery>
{
    /// <inheritdoc/>
    public IntegrationDelivery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntegrationDelivery.FromRawUnchecked(rawData);
}
