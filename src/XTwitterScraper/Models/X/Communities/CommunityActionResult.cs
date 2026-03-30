using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(typeof(JsonModelConverter<CommunityActionResult, CommunityActionResultFromRaw>))]
public sealed record class CommunityActionResult : JsonModel
{
    public required string CommunityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("communityId");
        }
        init { this._rawData.Set("communityId", value); }
    }

    public required string CommunityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("communityName");
        }
        init { this._rawData.Set("communityName", value); }
    }

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
        _ = this.CommunityID;
        _ = this.CommunityName;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public CommunityActionResult()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityActionResult(CommunityActionResult communityActionResult)
        : base(communityActionResult) { }
#pragma warning restore CS8618

    public CommunityActionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityActionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityActionResultFromRaw.FromRawUnchecked"/>
    public static CommunityActionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityActionResultFromRaw : IFromRawJson<CommunityActionResult>
{
    /// <inheritdoc/>
    public CommunityActionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityActionResult.FromRawUnchecked(rawData);
}
