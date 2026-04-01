using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Communities.Join;

[JsonConverter(typeof(JsonModelConverter<JoinDeleteAllResponse, JoinDeleteAllResponseFromRaw>))]
public sealed record class JoinDeleteAllResponse : JsonModel
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

    public JoinDeleteAllResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JoinDeleteAllResponse(JoinDeleteAllResponse joinDeleteAllResponse)
        : base(joinDeleteAllResponse) { }
#pragma warning restore CS8618

    public JoinDeleteAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JoinDeleteAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JoinDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static JoinDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JoinDeleteAllResponseFromRaw : IFromRawJson<JoinDeleteAllResponse>
{
    /// <inheritdoc/>
    public JoinDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JoinDeleteAllResponse.FromRawUnchecked(rawData);
}
