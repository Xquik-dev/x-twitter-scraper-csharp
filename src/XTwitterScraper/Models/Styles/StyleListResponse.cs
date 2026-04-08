using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleListResponse, StyleListResponseFromRaw>))]
public sealed record class StyleListResponse : JsonModel
{
    public required IReadOnlyList<StyleProfileSummary> Styles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StyleProfileSummary>>("styles");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StyleProfileSummary>>(
                "styles",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Styles)
        {
            item.Validate();
        }
    }

    public StyleListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleListResponse(StyleListResponse styleListResponse)
        : base(styleListResponse) { }
#pragma warning restore CS8618

    public StyleListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleListResponseFromRaw.FromRawUnchecked"/>
    public static StyleListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StyleListResponse(IReadOnlyList<StyleProfileSummary> styles)
        : this()
    {
        this.Styles = styles;
    }
}

class StyleListResponseFromRaw : IFromRawJson<StyleListResponse>
{
    /// <inheritdoc/>
    public StyleListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StyleListResponse.FromRawUnchecked(rawData);
}
