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
