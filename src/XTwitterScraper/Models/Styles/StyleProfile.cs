using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

/// <summary>
/// Full style profile with sampled tweets used for tone analysis.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StyleProfile, StyleProfileFromRaw>))]
public sealed record class StyleProfile : JsonModel
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

    public required IReadOnlyList<Tweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Tweet>>("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Tweet>>(
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

    public StyleProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleProfile(StyleProfile styleProfile)
        : base(styleProfile) { }
#pragma warning restore CS8618

    public StyleProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleProfileFromRaw.FromRawUnchecked"/>
    public static StyleProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleProfileFromRaw : IFromRawJson<StyleProfile>
{
    /// <inheritdoc/>
    public StyleProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StyleProfile.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Tweet, TweetFromRaw>))]
public sealed record class Tweet : JsonModel
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

    public Tweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tweet(Tweet tweet)
        : base(tweet) { }
#pragma warning restore CS8618

    public Tweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetFromRaw.FromRawUnchecked"/>
    public static Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetFromRaw : IFromRawJson<Tweet>
{
    /// <inheritdoc/>
    public Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tweet.FromRawUnchecked(rawData);
}
