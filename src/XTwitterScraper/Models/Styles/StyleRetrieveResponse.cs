using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleRetrieveResponse, StyleRetrieveResponseFromRaw>))]
public sealed record class StyleRetrieveResponse : JsonModel
{
    public required DateTimeOffset FetchedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("fetchedAt");
        }
        init { this._rawData.Set("fetchedAt", value); }
    }

    public required bool IsOwnAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isOwnAccount");
        }
        init { this._rawData.Set("isOwnAccount", value); }
    }

    public required long TweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetCount");
        }
        init { this._rawData.Set("tweetCount", value); }
    }

    public required IReadOnlyList<StyleRetrieveResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StyleRetrieveResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StyleRetrieveResponseTweet>>(
                "tweets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string XUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUsername");
        }
        init { this._rawData.Set("xUsername", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FetchedAt;
        _ = this.IsOwnAccount;
        _ = this.TweetCount;
        foreach (var item in this.Tweets)
        {
            item.Validate();
        }
        _ = this.XUsername;
    }

    public StyleRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleRetrieveResponse(StyleRetrieveResponse styleRetrieveResponse)
        : base(styleRetrieveResponse) { }
#pragma warning restore CS8618

    public StyleRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static StyleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleRetrieveResponseFromRaw : IFromRawJson<StyleRetrieveResponse>
{
    /// <inheritdoc/>
    public StyleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<StyleRetrieveResponseTweet, StyleRetrieveResponseTweetFromRaw>)
)]
public sealed record class StyleRetrieveResponseTweet : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public string? AuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorUsername", value);
        }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Text;
        _ = this.AuthorUsername;
        _ = this.CreatedAt;
    }

    public StyleRetrieveResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleRetrieveResponseTweet(StyleRetrieveResponseTweet styleRetrieveResponseTweet)
        : base(styleRetrieveResponseTweet) { }
#pragma warning restore CS8618

    public StyleRetrieveResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleRetrieveResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleRetrieveResponseTweetFromRaw.FromRawUnchecked"/>
    public static StyleRetrieveResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleRetrieveResponseTweetFromRaw : IFromRawJson<StyleRetrieveResponseTweet>
{
    /// <inheritdoc/>
    public StyleRetrieveResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleRetrieveResponseTweet.FromRawUnchecked(rawData);
}
