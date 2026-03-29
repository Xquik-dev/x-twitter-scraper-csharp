using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Integrations;

[JsonConverter(
    typeof(JsonModelConverter<IntegrationSendTestResponse, IntegrationSendTestResponseFromRaw>)
)]
public sealed record class IntegrationSendTestResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public IntegrationSendTestResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationSendTestResponse(IntegrationSendTestResponse integrationSendTestResponse)
        : base(integrationSendTestResponse) { }
#pragma warning restore CS8618

    public IntegrationSendTestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationSendTestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationSendTestResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationSendTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationSendTestResponseFromRaw : IFromRawJson<IntegrationSendTestResponse>
{
    /// <inheritdoc/>
    public IntegrationSendTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationSendTestResponse.FromRawUnchecked(rawData);
}
