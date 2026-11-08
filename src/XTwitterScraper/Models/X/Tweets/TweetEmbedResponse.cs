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

[JsonConverter(typeof(JsonModelConverter<TweetEmbedResponse, TweetEmbedResponseFromRaw>))]
public sealed record class TweetEmbedResponse : JsonModel
{
    /// <summary>
    /// Holds the HTML that embeds 1 tweet on a website.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetEmbed Embed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetEmbed>(
                "embed"
            );
        }
        init { this._rawData.Set("embed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Embed.Validate();
    }

    public TweetEmbedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEmbedResponse(TweetEmbedResponse tweetEmbedResponse)
        : base(tweetEmbedResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEmbedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetEmbedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetEmbedResponseFromRaw.FromRawUnchecked"/>
    public static TweetEmbedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetEmbedResponseFromRaw : IFromRawJson<TweetEmbedResponse>
{
    /// <inheritdoc/>
    public TweetEmbedResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetEmbedResponse.FromRawUnchecked(rawData);
}
