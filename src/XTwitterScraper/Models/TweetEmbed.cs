// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<TweetEmbed, TweetEmbedFromRaw>))]
public sealed record class TweetEmbed : JsonModel
{
    /// <summary>
    /// ID of the embedded tweet.
    /// </summary>
    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    /// <summary>
    /// Link to the tweet with its author's username.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Display name of the tweet's author.
    /// </summary>
    public required string AuthorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorName");
        }
        init { this._rawData.Set("authorName", value); }
    }

    /// <summary>
    /// Link to the author's profile.
    /// </summary>
    public required string AuthorUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorUrl");
        }
        init { this._rawData.Set("authorUrl", value); }
    }

    /// <summary>
    /// Markup to place on a page. It loads X's widget script unless `omitScript` is `true`.
    /// </summary>
    public required string Html
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("html");
        }
        init { this._rawData.Set("html", value); }
    }

    /// <summary>
    /// Width of the embed in pixels.
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <summary>
    /// Height in pixels, when X fixes it.
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetID;
        _ = this.UrlValue;
        _ = this.AuthorName;
        _ = this.AuthorUrl;
        _ = this.Html;
        _ = this.Width;
        _ = this.Height;
    }

    public TweetEmbed() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEmbed(TweetEmbed tweetEmbed)
        : base(tweetEmbed) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEmbed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetEmbed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetEmbedFromRaw.FromRawUnchecked"/>
    public static TweetEmbed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetEmbedFromRaw : IFromRawJson<TweetEmbed>
{
    /// <inheritdoc/>
    public TweetEmbed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetEmbed.FromRawUnchecked(rawData);
}
