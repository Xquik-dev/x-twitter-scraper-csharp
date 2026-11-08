// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(typeof(JsonModelConverter<TweetTranslateResponse, TweetTranslateResponseFromRaw>))]
public sealed record class TweetTranslateResponse : JsonModel
{
    /// <summary>
    /// Holds X's translation of 1 tweet into the requested language. `entities` holds the links, mentions, and tags with their offsets in the translated text, and is empty when the text has none.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetTranslation Translation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetTranslation>(
                "translation"
            );
        }
        init { this._rawData.Set("translation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Translation.Validate();
    }

    public TweetTranslateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTranslateResponse(TweetTranslateResponse tweetTranslateResponse)
        : base(tweetTranslateResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTranslateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTranslateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTranslateResponseFromRaw.FromRawUnchecked"/>
    public static TweetTranslateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTranslateResponseFromRaw : IFromRawJson<TweetTranslateResponse>
{
    /// <inheritdoc/>
    public TweetTranslateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetTranslateResponse.FromRawUnchecked(rawData);
}
