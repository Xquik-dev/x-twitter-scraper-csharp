using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleAnalyzeResponse, StyleAnalyzeResponseFromRaw>))]
public sealed record class StyleAnalyzeResponse : JsonModel
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

    public required IReadOnlyList<StyleAnalyzeResponseTweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StyleAnalyzeResponseTweet>>(
                "tweets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StyleAnalyzeResponseTweet>>(
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

    public StyleAnalyzeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleAnalyzeResponse(StyleAnalyzeResponse styleAnalyzeResponse)
        : base(styleAnalyzeResponse) { }
#pragma warning restore CS8618

    public StyleAnalyzeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleAnalyzeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleAnalyzeResponseFromRaw.FromRawUnchecked"/>
    public static StyleAnalyzeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleAnalyzeResponseFromRaw : IFromRawJson<StyleAnalyzeResponse>
{
    /// <inheritdoc/>
    public StyleAnalyzeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleAnalyzeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<StyleAnalyzeResponseTweet, StyleAnalyzeResponseTweetFromRaw>)
)]
public sealed record class StyleAnalyzeResponseTweet : JsonModel
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

    public StyleAnalyzeResponseTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleAnalyzeResponseTweet(StyleAnalyzeResponseTweet styleAnalyzeResponseTweet)
        : base(styleAnalyzeResponseTweet) { }
#pragma warning restore CS8618

    public StyleAnalyzeResponseTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleAnalyzeResponseTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleAnalyzeResponseTweetFromRaw.FromRawUnchecked"/>
    public static StyleAnalyzeResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleAnalyzeResponseTweetFromRaw : IFromRawJson<StyleAnalyzeResponseTweet>
{
    /// <inheritdoc/>
    public StyleAnalyzeResponseTweet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleAnalyzeResponseTweet.FromRawUnchecked(rawData);
}
