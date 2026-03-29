using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetDeleteResponse, TweetDeleteResponseFromRaw>))]
public sealed record class TweetDeleteResponse : JsonModel
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

    public TweetDeleteResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetDeleteResponse(TweetDeleteResponse tweetDeleteResponse)
        : base(tweetDeleteResponse) { }
#pragma warning restore CS8618

    public TweetDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetDeleteResponseFromRaw.FromRawUnchecked"/>
    public static TweetDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetDeleteResponseFromRaw : IFromRawJson<TweetDeleteResponse>
{
    /// <inheritdoc/>
    public TweetDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetDeleteResponse.FromRawUnchecked(rawData);
}
