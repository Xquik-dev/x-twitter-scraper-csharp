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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
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
