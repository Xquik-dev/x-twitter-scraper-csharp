using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleUpdateResponse, StyleUpdateResponseFromRaw>))]
public sealed record class StyleUpdateResponse : JsonModel
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

    public required IReadOnlyList<StyleUpdateResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StyleUpdateResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StyleUpdateResponseTweet>>(
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

    public StyleUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleUpdateResponse(StyleUpdateResponse styleUpdateResponse)
        : base(styleUpdateResponse) { }
#pragma warning restore CS8618

    public StyleUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleUpdateResponseFromRaw.FromRawUnchecked"/>
    public static StyleUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleUpdateResponseFromRaw : IFromRawJson<StyleUpdateResponse>
{
    /// <inheritdoc/>
    public StyleUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StyleUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<StyleUpdateResponseTweet, StyleUpdateResponseTweetFromRaw>)
)]
public sealed record class StyleUpdateResponseTweet : JsonModel
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

    public StyleUpdateResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleUpdateResponseTweet(StyleUpdateResponseTweet styleUpdateResponseTweet)
        : base(styleUpdateResponseTweet) { }
#pragma warning restore CS8618

    public StyleUpdateResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleUpdateResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleUpdateResponseTweetFromRaw.FromRawUnchecked"/>
    public static StyleUpdateResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleUpdateResponseTweetFromRaw : IFromRawJson<StyleUpdateResponseTweet>
{
    /// <inheritdoc/>
    public StyleUpdateResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleUpdateResponseTweet.FromRawUnchecked(rawData);
}
