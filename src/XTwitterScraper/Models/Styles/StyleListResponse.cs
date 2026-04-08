using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Styles;

[JsonConverter(typeof(JsonModelConverter<StyleListResponse, StyleListResponseFromRaw>))]
public sealed record class StyleListResponse : JsonModel
{
    public required IReadOnlyList<Style> Styles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Style>>("styles");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Style>>(
                "styles",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Styles)
        {
            item.Validate();
        }
    }

    public StyleListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StyleListResponse(StyleListResponse styleListResponse)
        : base(styleListResponse) { }
#pragma warning restore CS8618

    public StyleListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StyleListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleListResponseFromRaw.FromRawUnchecked"/>
    public static StyleListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StyleListResponse(IReadOnlyList<Style> styles)
        : this()
    {
        this.Styles = styles;
    }
}

class StyleListResponseFromRaw : IFromRawJson<StyleListResponse>
{
    /// <inheritdoc/>
    public StyleListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StyleListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Style profile summary with tweet count and ownership flag.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Style, StyleFromRaw>))]
public sealed record class Style : JsonModel
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
        _ = this.XUsername;
    }

    public Style() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Style(Style style)
        : base(style) { }
#pragma warning restore CS8618

    public Style(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Style(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StyleFromRaw.FromRawUnchecked"/>
    public static Style FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StyleFromRaw : IFromRawJson<Style>
{
    /// <inheritdoc/>
    public Style FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Style.FromRawUnchecked(rawData);
}
