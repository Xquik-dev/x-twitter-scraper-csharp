using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Media;

[JsonConverter(typeof(JsonModelConverter<MediaUploadResponse, MediaUploadResponseFromRaw>))]
public sealed record class MediaUploadResponse : JsonModel
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

    public MediaUploadResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaUploadResponse(MediaUploadResponse mediaUploadResponse)
        : base(mediaUploadResponse) { }
#pragma warning restore CS8618

    public MediaUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaUploadResponseFromRaw.FromRawUnchecked"/>
    public static MediaUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MediaUploadResponse(string mediaID)
        : this()
    {
        this.MediaID = mediaID;
    }
}

class MediaUploadResponseFromRaw : IFromRawJson<MediaUploadResponse>
{
    /// <inheritdoc/>
    public MediaUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MediaUploadResponse.FromRawUnchecked(rawData);
}
