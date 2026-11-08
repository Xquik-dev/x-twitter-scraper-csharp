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

[JsonConverter(typeof(JsonModelConverter<TweetTranslation, TweetTranslationFromRaw>))]
public sealed record class TweetTranslation : JsonModel
{
    /// <summary>
    /// ID of the translated tweet.
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
    /// Language code of the translated text, in lower case.
    /// </summary>
    public required string Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Language code X detects in the tweet, when it names one.
    /// </summary>
    public string? SourceLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceLanguage", value);
        }
    }

    /// <summary>
    /// Translated tweet text.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Lists hashtags, symbols, links, and mentions from tweet text.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetEntities Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetEntities>(
                "entities"
            );
        }
        init { this._rawData.Set("entities", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetID;
        _ = this.Language;
        _ = this.SourceLanguage;
        _ = this.Text;
        this.Entities.Validate();
    }

    public TweetTranslation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTranslation(TweetTranslation tweetTranslation)
        : base(tweetTranslation) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTranslation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTranslation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTranslationFromRaw.FromRawUnchecked"/>
    public static TweetTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTranslationFromRaw : IFromRawJson<TweetTranslation>
{
    /// <inheritdoc/>
    public TweetTranslation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetTranslation.FromRawUnchecked(rawData);
}
