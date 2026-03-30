using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Dm;

[JsonConverter(typeof(JsonModelConverter<DmSendResponse, DmSendResponseFromRaw>))]
public sealed record class DmSendResponse : JsonModel
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

    public DmSendResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DmSendResponse(DmSendResponse dmSendResponse)
        : base(dmSendResponse) { }
#pragma warning restore CS8618

    public DmSendResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DmSendResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DmSendResponseFromRaw.FromRawUnchecked"/>
    public static DmSendResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DmSendResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}

class DmSendResponseFromRaw : IFromRawJson<DmSendResponse>
{
    /// <inheritdoc/>
    public DmSendResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DmSendResponse.FromRawUnchecked(rawData);
}
