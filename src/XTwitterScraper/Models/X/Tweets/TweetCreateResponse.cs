using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetCreateResponse, TweetCreateResponseFromRaw>))]
public sealed record class TweetCreateResponse : JsonModel
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

    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.TweetID;
    }

    public TweetCreateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCreateResponse(TweetCreateResponse tweetCreateResponse)
        : base(tweetCreateResponse) { }
#pragma warning restore CS8618

    public TweetCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCreateResponseFromRaw.FromRawUnchecked"/>
    public static TweetCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TweetCreateResponse(string tweetID)
        : this()
    {
        this.TweetID = tweetID;
    }
}

class TweetCreateResponseFromRaw : IFromRawJson<TweetCreateResponse>
{
    /// <inheritdoc/>
    public TweetCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetCreateResponse.FromRawUnchecked(rawData);
}
