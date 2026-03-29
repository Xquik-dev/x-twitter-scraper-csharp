using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(
    typeof(JsonModelConverter<CommunityRetrieveInfoResponse, CommunityRetrieveInfoResponseFromRaw>)
)]
public sealed record class CommunityRetrieveInfoResponse : JsonModel
{
    /// <summary>
    /// Community info object
    /// </summary>
    public required JsonElement Community
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("community");
        }
        init { this._rawData.Set("community", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Community;
    }

    public CommunityRetrieveInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(
        CommunityRetrieveInfoResponse communityRetrieveInfoResponse
    )
        : base(communityRetrieveInfoResponse) { }
#pragma warning restore CS8618

    public CommunityRetrieveInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityRetrieveInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityRetrieveInfoResponseFromRaw.FromRawUnchecked"/>
    public static CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(JsonElement community)
        : this()
    {
        this.Community = community;
    }
}

class CommunityRetrieveInfoResponseFromRaw : IFromRawJson<CommunityRetrieveInfoResponse>
{
    /// <inheritdoc/>
    public CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityRetrieveInfoResponse.FromRawUnchecked(rawData);
}
