using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(
    typeof(JsonModelConverter<
        ExtractionEstimateCostResponse,
        ExtractionEstimateCostResponseFromRaw
    >)
)]
public sealed record class ExtractionEstimateCostResponse : JsonModel
{
    public required bool Allowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allowed");
        }
        init { this._rawData.Set("allowed", value); }
    }

    public required long EstimatedResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("estimatedResults");
        }
        init { this._rawData.Set("estimatedResults", value); }
    }

    public required double ProjectedPercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("projectedPercent");
        }
        init { this._rawData.Set("projectedPercent", value); }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required double UsagePercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usagePercent");
        }
        init { this._rawData.Set("usagePercent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Allowed;
        _ = this.EstimatedResults;
        _ = this.ProjectedPercent;
        _ = this.Source;
        _ = this.UsagePercent;
    }

    public ExtractionEstimateCostResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionEstimateCostResponse(
        ExtractionEstimateCostResponse extractionEstimateCostResponse
    )
        : base(extractionEstimateCostResponse) { }
#pragma warning restore CS8618

    public ExtractionEstimateCostResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionEstimateCostResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionEstimateCostResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionEstimateCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionEstimateCostResponseFromRaw : IFromRawJson<ExtractionEstimateCostResponse>
{
    /// <inheritdoc/>
    public ExtractionEstimateCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionEstimateCostResponse.FromRawUnchecked(rawData);
}
