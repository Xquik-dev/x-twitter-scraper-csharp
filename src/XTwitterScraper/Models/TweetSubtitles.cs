// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<TweetSubtitles, TweetSubtitlesFromRaw>))]
public sealed record class TweetSubtitles : JsonModel
{
    /// <summary>
    /// ID of the tweet.
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
    /// Caption tracks, empty when no video has captions.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.SubtitleTrack> Tracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.SubtitleTrack>
            >("tracks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.SubtitleTrack>>(
                "tracks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetID;
        foreach (var item in this.Tracks)
        {
            item.Validate();
        }
    }

    public TweetSubtitles() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSubtitles(TweetSubtitles tweetSubtitles)
        : base(tweetSubtitles) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSubtitles(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSubtitles(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSubtitlesFromRaw.FromRawUnchecked"/>
    public static TweetSubtitles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSubtitlesFromRaw : IFromRawJson<TweetSubtitles>
{
    /// <inheritdoc/>
    public TweetSubtitles FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetSubtitles.FromRawUnchecked(rawData);
}
