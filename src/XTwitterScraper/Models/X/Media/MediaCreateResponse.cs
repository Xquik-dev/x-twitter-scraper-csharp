using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Media;

[JsonConverter(typeof(JsonModelConverter<MediaCreateResponse, MediaCreateResponseFromRaw>))]
public sealed record class MediaCreateResponse : JsonModel
{
    public required string MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mediaId");
        }
        init { this._rawData.Set("mediaId", value); }
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
        _ = this.MediaID;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public MediaCreateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaCreateResponse(MediaCreateResponse mediaCreateResponse)
        : base(mediaCreateResponse) { }
#pragma warning restore CS8618

    public MediaCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaCreateResponseFromRaw.FromRawUnchecked"/>
    public static MediaCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MediaCreateResponse(string mediaID)
        : this()
    {
        this.MediaID = mediaID;
    }
}

class MediaCreateResponseFromRaw : IFromRawJson<MediaCreateResponse>
{
    /// <inheritdoc/>
    public MediaCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MediaCreateResponse.FromRawUnchecked(rawData);
}
