using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleCompareResponse, StyleCompareResponseFromRaw>))]
public sealed record class StyleCompareResponse : JsonModel
{
    public required Style1 Style1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Style1>("style1");
        }
        init { this._rawData.Set("style1", value); }
    }

    public required Style2 Style2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Style2>("style2");
        }
        init { this._rawData.Set("style2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Style1.Validate();
        this.Style2.Validate();
    }

    public StyleCompareResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleCompareResponse(StyleCompareResponse styleCompareResponse)
        : base(styleCompareResponse) { }
#pragma warning restore CS8618

    public StyleCompareResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleCompareResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleCompareResponseFromRaw.FromRawUnchecked"/>
    public static StyleCompareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleCompareResponseFromRaw : IFromRawJson<StyleCompareResponse>
{
    /// <inheritdoc/>
    public StyleCompareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StyleCompareResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Style1, Style1FromRaw>))]
public sealed record class Style1 : JsonModel
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

    public required IReadOnlyList<Style1Tweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Style1Tweet>>("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Style1Tweet>>(
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

    public Style1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Style1(Style1 style1)
        : base(style1) { }
#pragma warning restore CS8618

    public Style1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Style1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Style1FromRaw.FromRawUnchecked"/>
    public static Style1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Style1FromRaw : IFromRawJson<Style1>
{
    /// <inheritdoc/>
    public Style1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Style1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Style1Tweet, Style1TweetFromRaw>))]
public sealed record class Style1Tweet : JsonModel
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

    public Style1Tweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Style1Tweet(Style1Tweet style1Tweet)
        : base(style1Tweet) { }
#pragma warning restore CS8618

    public Style1Tweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Style1Tweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Style1TweetFromRaw.FromRawUnchecked"/>
    public static Style1Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Style1TweetFromRaw : IFromRawJson<Style1Tweet>
{
    /// <inheritdoc/>
    public Style1Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Style1Tweet.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Style2, Style2FromRaw>))]
public sealed record class Style2 : JsonModel
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

    public required IReadOnlyList<Style2Tweet> Tweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Style2Tweet>>("tweets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Style2Tweet>>(
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

    public Style2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Style2(Style2 style2)
        : base(style2) { }
#pragma warning restore CS8618

    public Style2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Style2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Style2FromRaw.FromRawUnchecked"/>
    public static Style2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Style2FromRaw : IFromRawJson<Style2>
{
    /// <inheritdoc/>
    public Style2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Style2.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Style2Tweet, Style2TweetFromRaw>))]
public sealed record class Style2Tweet : JsonModel
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

    public Style2Tweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Style2Tweet(Style2Tweet style2Tweet)
        : base(style2Tweet) { }
#pragma warning restore CS8618

    public Style2Tweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Style2Tweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Style2TweetFromRaw.FromRawUnchecked"/>
    public static Style2Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Style2TweetFromRaw : IFromRawJson<Style2Tweet>
{
    /// <inheritdoc/>
    public Style2Tweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Style2Tweet.FromRawUnchecked(rawData);
}
