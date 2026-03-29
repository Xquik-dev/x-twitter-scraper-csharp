using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(typeof(JsonModelConverter<CommunityCreateResponse, CommunityCreateResponseFromRaw>))]
public sealed record class CommunityCreateResponse : JsonModel
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

    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public string? CommunityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CommunityID;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.CommunityName;
    }

    public CommunityCreateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityCreateResponse(CommunityCreateResponse communityCreateResponse)
        : base(communityCreateResponse) { }
#pragma warning restore CS8618

    public CommunityCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityCreateResponseFromRaw.FromRawUnchecked"/>
    public static CommunityCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CommunityCreateResponse(string communityID)
        : this()
    {
        this.CommunityID = communityID;
    }
}

class CommunityCreateResponseFromRaw : IFromRawJson<CommunityCreateResponse>
{
    /// <inheritdoc/>
    public CommunityCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityCreateResponse.FromRawUnchecked(rawData);
}
