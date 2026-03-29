using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Extractions;

[JsonConverter(
    typeof(JsonModelConverter<ExtractionRetrieveResponse, ExtractionRetrieveResponseFromRaw>)
)]
public sealed record class ExtractionRetrieveResponse : JsonModel
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

    public required IReadOnlyDictionary<string, JsonElement> Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("job");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "job",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "results",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
                )
            );
        }
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
        _ = this.HasMore;
        _ = this.Job;
        _ = this.Results;
        _ = this.NextCursor;
    }

    public ExtractionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRetrieveResponse(ExtractionRetrieveResponse extractionRetrieveResponse)
        : base(extractionRetrieveResponse) { }
#pragma warning restore CS8618

    public ExtractionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ExtractionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionRetrieveResponseFromRaw : IFromRawJson<ExtractionRetrieveResponse>
{
    /// <inheritdoc/>
    public ExtractionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionRetrieveResponse.FromRawUnchecked(rawData);
}
