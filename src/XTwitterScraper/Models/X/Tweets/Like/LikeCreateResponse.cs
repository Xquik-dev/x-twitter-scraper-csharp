using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Tweets.Like;

[JsonConverter(typeof(JsonModelConverter<LikeCreateResponse, LikeCreateResponseFromRaw>))]
public sealed record class LikeCreateResponse : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public LikeCreateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LikeCreateResponse(LikeCreateResponse likeCreateResponse)
        : base(likeCreateResponse) { }
#pragma warning restore CS8618

    public LikeCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LikeCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LikeCreateResponseFromRaw.FromRawUnchecked"/>
    public static LikeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LikeCreateResponseFromRaw : IFromRawJson<LikeCreateResponse>
{
    /// <inheritdoc/>
    public LikeCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LikeCreateResponse.FromRawUnchecked(rawData);
}
