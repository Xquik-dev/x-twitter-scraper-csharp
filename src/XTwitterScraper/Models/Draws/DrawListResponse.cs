using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawListResponse, DrawListResponseFromRaw>))]
public sealed record class DrawListResponse : JsonModel
{
    public required IReadOnlyList<DrawListItem> Draws
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DrawListItem>>("draws");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DrawListItem>>(
                "draws",
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
        foreach (var item in this.Draws)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public DrawListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawListResponse(DrawListResponse drawListResponse)
        : base(drawListResponse) { }
#pragma warning restore CS8618

    public DrawListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawListResponseFromRaw.FromRawUnchecked"/>
    public static DrawListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawListResponseFromRaw : IFromRawJson<DrawListResponse>
{
    /// <inheritdoc/>
    public DrawListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DrawListResponse.FromRawUnchecked(rawData);
}
