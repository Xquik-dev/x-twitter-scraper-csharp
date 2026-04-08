using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetRetrieveResponse, TweetRetrieveResponseFromRaw>))]
public sealed record class TweetRetrieveResponse : JsonModel
{
    /// <summary>
    /// Full tweet with text, engagement metrics, media, and metadata.
    /// </summary>
    public required TweetDetail Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetDetail>("tweet");
        }
        init { this._rawData.Set("tweet", value); }
    }

    /// <summary>
    /// Author of a tweet with follower count and verification status.
    /// </summary>
    public TweetAuthor? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAuthor>("author");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Tweet.Validate();
        this.Author?.Validate();
    }

    public TweetRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetRetrieveResponse(TweetRetrieveResponse tweetRetrieveResponse)
        : base(tweetRetrieveResponse) { }
#pragma warning restore CS8618

    public TweetRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TweetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TweetRetrieveResponse(TweetDetail tweet)
        : this()
    {
        this.Tweet = tweet;
    }
}

class TweetRetrieveResponseFromRaw : IFromRawJson<TweetRetrieveResponse>
{
    /// <inheritdoc/>
    public TweetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetRetrieveResponse.FromRawUnchecked(rawData);
}
