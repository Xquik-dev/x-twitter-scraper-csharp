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
    public required IReadOnlyList<IntegrationDelivery> Deliveries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<IntegrationDelivery>>(
                "deliveries"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<IntegrationDelivery>>(
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
    public IntegrationListDeliveriesResponse(IReadOnlyList<IntegrationDelivery> deliveries)
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
