using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(typeof(JsonModelConverter<ExtractionListResponse, ExtractionListResponseFromRaw>))]
public sealed record class ExtractionListResponse : JsonModel
{
    public required IReadOnlyList<ExtractionJob> Extractions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ExtractionJob>>("extractions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExtractionJob>>(
                "extractions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

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
        foreach (var item in this.Extractions)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public ExtractionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionListResponse(ExtractionListResponse extractionListResponse)
        : base(extractionListResponse) { }
#pragma warning restore CS8618

    public ExtractionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionListResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionListResponseFromRaw : IFromRawJson<ExtractionListResponse>
{
    /// <inheritdoc/>
    public ExtractionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionListResponse.FromRawUnchecked(rawData);
}
