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
    public required bool Charged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("charged");
        }
        init { this._rawData.Set("charged", value); }
    }

    /// <summary>
    /// Credits charged for this tweet. Text-only tweets and replies cost 30 credits;
    /// attached media adds 2 credits per started MB.
    /// </summary>
    public required string ChargedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargedCredits");
        }
        init { this._rawData.Set("chargedCredits", value); }
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

    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    public string? WriteActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("writeActionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("writeActionId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Charged;
        _ = this.ChargedCredits;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.TweetID;
        _ = this.WriteActionID;
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
}

class TweetCreateResponseFromRaw : IFromRawJson<TweetCreateResponse>
{
    /// <inheritdoc/>
    public TweetCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetCreateResponse.FromRawUnchecked(rawData);
}
