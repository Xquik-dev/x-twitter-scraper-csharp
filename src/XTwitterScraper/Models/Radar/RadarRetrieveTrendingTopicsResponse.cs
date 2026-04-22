using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Radar;

[JsonConverter(
    typeof(JsonModelConverter<
        RadarRetrieveTrendingTopicsResponse,
        RadarRetrieveTrendingTopicsResponseFromRaw
    >)
)]
public sealed record class RadarRetrieveTrendingTopicsResponse : JsonModel
{
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public required IReadOnlyList<RadarItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RadarItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RadarItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page (present only when hasMore is true).
    /// </summary>
    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public RadarRetrieveTrendingTopicsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RadarRetrieveTrendingTopicsResponse(
        RadarRetrieveTrendingTopicsResponse radarRetrieveTrendingTopicsResponse
    )
        : base(radarRetrieveTrendingTopicsResponse) { }
#pragma warning restore CS8618

    public RadarRetrieveTrendingTopicsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RadarRetrieveTrendingTopicsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RadarRetrieveTrendingTopicsResponseFromRaw.FromRawUnchecked"/>
    public static RadarRetrieveTrendingTopicsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RadarRetrieveTrendingTopicsResponseFromRaw : IFromRawJson<RadarRetrieveTrendingTopicsResponse>
{
    /// <inheritdoc/>
    public RadarRetrieveTrendingTopicsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RadarRetrieveTrendingTopicsResponse.FromRawUnchecked(rawData);
}
