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

[JsonConverter(
    typeof(JsonModelConverter<TweetGetSubtitlesResponse, TweetGetSubtitlesResponseFromRaw>)
)]
public sealed record class TweetGetSubtitlesResponse : JsonModel
{
    /// <summary>
    /// Holds the caption tracks of 1 tweet's videos.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetSubtitles Subtitles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetSubtitles>(
                "subtitles"
            );
        }
        init { this._rawData.Set("subtitles", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Subtitles.Validate();
    }

    public TweetGetSubtitlesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetSubtitlesResponse(TweetGetSubtitlesResponse tweetGetSubtitlesResponse)
        : base(tweetGetSubtitlesResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetSubtitlesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetSubtitlesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetSubtitlesResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetSubtitlesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetSubtitlesResponseFromRaw : IFromRawJson<TweetGetSubtitlesResponse>
{
    /// <inheritdoc/>
    public TweetGetSubtitlesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetSubtitlesResponse.FromRawUnchecked(rawData);
}
