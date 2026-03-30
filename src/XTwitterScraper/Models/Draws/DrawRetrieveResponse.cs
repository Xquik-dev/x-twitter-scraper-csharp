using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawRetrieveResponse, DrawRetrieveResponseFromRaw>))]
public sealed record class DrawRetrieveResponse : JsonModel
{
    public required DrawDetail Draw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DrawDetail>("draw");
        }
        init { this._rawData.Set("draw", value); }
    }

    public required IReadOnlyList<Winner> Winners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Winner>>("winners");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Winner>>(
                "winners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Draw.Validate();
        foreach (var item in this.Winners)
        {
            item.Validate();
        }
    }

    public DrawRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawRetrieveResponse(DrawRetrieveResponse drawRetrieveResponse)
        : base(drawRetrieveResponse) { }
#pragma warning restore CS8618

    public DrawRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DrawRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawRetrieveResponseFromRaw : IFromRawJson<DrawRetrieveResponse>
{
    /// <inheritdoc/>
    public DrawRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DrawRetrieveResponse.FromRawUnchecked(rawData);
}
