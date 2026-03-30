using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Integrations;

[JsonConverter(typeof(JsonModelConverter<IntegrationListResponse, IntegrationListResponseFromRaw>))]
public sealed record class IntegrationListResponse : JsonModel
{
    public required IReadOnlyList<Integration> Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Integration>>("integrations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Integration>>(
                "integrations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Integrations)
        {
            item.Validate();
        }
    }

    public IntegrationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationListResponse(IntegrationListResponse integrationListResponse)
        : base(integrationListResponse) { }
#pragma warning restore CS8618

    public IntegrationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationListResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationListResponse(IReadOnlyList<Integration> integrations)
        : this()
    {
        this.Integrations = integrations;
    }
}

class IntegrationListResponseFromRaw : IFromRawJson<IntegrationListResponse>
{
    /// <inheritdoc/>
    public IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationListResponse.FromRawUnchecked(rawData);
}
