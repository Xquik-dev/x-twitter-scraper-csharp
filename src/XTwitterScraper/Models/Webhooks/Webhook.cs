using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Webhooks;

/// <summary>
/// Webhook endpoint registered to receive event deliveries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : JsonModel
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

    /// <summary>
    /// Consecutive failed delivery attempts since the last success.
    /// </summary>
    public required long ConsecutiveFailures
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("consecutiveFailures");
        }
        init { this._rawData.Set("consecutiveFailures", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Endpoint delivery state. needs_attention means delivery stopped after repeated failures.
    /// </summary>
    public required ApiEnum<string, DeliveryStatus> DeliveryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeliveryStatus>>("deliveryStatus");
        }
        init { this._rawData.Set("deliveryStatus", value); }
    }

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, EventType>>>(
                "eventTypes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, EventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Consecutive delivery failures that pause the endpoint.
    /// </summary>
    public required long FailureHardCap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("failureHardCap");
        }
        init { this._rawData.Set("failureHardCap", value); }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ConsecutiveFailures;
        _ = this.CreatedAt;
        this.DeliveryStatus.Validate();
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.FailureHardCap;
        _ = this.IsActive;
        _ = this.Url;
    }

    public Webhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Webhook(Webhook webhook)
        : base(webhook) { }
#pragma warning restore CS8618

    public Webhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookFromRaw.FromRawUnchecked"/>
    public static Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookFromRaw : IFromRawJson<Webhook>
{
    /// <inheritdoc/>
    public Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Webhook.FromRawUnchecked(rawData);
}

/// <summary>
/// Endpoint delivery state. needs_attention means delivery stopped after repeated failures.
/// </summary>
[JsonConverter(typeof(DeliveryStatusConverter))]
public enum DeliveryStatus
{
    Active,
    Paused,
    NeedsAttention,
}

sealed class DeliveryStatusConverter : JsonConverter<DeliveryStatus>
{
    public override DeliveryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => DeliveryStatus.Active,
            "paused" => DeliveryStatus.Paused,
            "needs_attention" => DeliveryStatus.NeedsAttention,
            _ => (DeliveryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeliveryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeliveryStatus.Active => "active",
                DeliveryStatus.Paused => "paused",
                DeliveryStatus.NeedsAttention => "needs_attention",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
