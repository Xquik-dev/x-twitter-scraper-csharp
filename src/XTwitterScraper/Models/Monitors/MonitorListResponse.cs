using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Monitors;

[JsonConverter(typeof(JsonModelConverter<MonitorListResponse, MonitorListResponseFromRaw>))]
public sealed record class MonitorListResponse : JsonModel
{
    public required IReadOnlyList<Monitor> Monitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Monitor>>("monitors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Monitor>>(
                "monitors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Monitors)
        {
            item.Validate();
        }
        _ = this.Total;
    }

    public MonitorListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorListResponse(MonitorListResponse monitorListResponse)
        : base(monitorListResponse) { }
#pragma warning restore CS8618

    public MonitorListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorListResponseFromRaw.FromRawUnchecked"/>
    public static MonitorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorListResponseFromRaw : IFromRawJson<MonitorListResponse>
{
    /// <inheritdoc/>
    public MonitorListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MonitorListResponse.FromRawUnchecked(rawData);
}
