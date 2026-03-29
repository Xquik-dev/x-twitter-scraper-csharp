using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Dm;

[JsonConverter(typeof(JsonModelConverter<DmUpdateResponse, DmUpdateResponseFromRaw>))]
public sealed record class DmUpdateResponse : JsonModel
{
    public required string MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("messageId");
        }
        init { this._rawData.Set("messageId", value); }
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
        _ = this.MessageID;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public DmUpdateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DmUpdateResponse(DmUpdateResponse dmUpdateResponse)
        : base(dmUpdateResponse) { }
#pragma warning restore CS8618

    public DmUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DmUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DmUpdateResponseFromRaw.FromRawUnchecked"/>
    public static DmUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DmUpdateResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}

class DmUpdateResponseFromRaw : IFromRawJson<DmUpdateResponse>
{
    /// <inheritdoc/>
    public DmUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DmUpdateResponse.FromRawUnchecked(rawData);
}
