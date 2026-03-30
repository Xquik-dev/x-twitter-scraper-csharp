using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleCompareResponse, StyleCompareResponseFromRaw>))]
public sealed record class StyleCompareResponse : JsonModel
{
    public required StyleProfile Style1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StyleProfile>("style1");
        }
        init { this._rawData.Set("style1", value); }
    }

    public required StyleProfile Style2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<StyleProfile>("style2");
        }
        init { this._rawData.Set("style2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Style1.Validate();
        this.Style2.Validate();
    }

    public StyleCompareResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleCompareResponse(StyleCompareResponse styleCompareResponse)
        : base(styleCompareResponse) { }
#pragma warning restore CS8618

    public StyleCompareResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleCompareResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleCompareResponseFromRaw.FromRawUnchecked"/>
    public static StyleCompareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleCompareResponseFromRaw : IFromRawJson<StyleCompareResponse>
{
    /// <inheritdoc/>
    public StyleCompareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleCompareResponse.FromRawUnchecked(rawData);
}
