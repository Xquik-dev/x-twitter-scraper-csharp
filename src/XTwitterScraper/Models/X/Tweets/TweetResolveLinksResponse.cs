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

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(
    typeof(JsonModelConverter<TweetResolveLinksResponse, TweetResolveLinksResponseFromRaw>)
)]
public sealed record class TweetResolveLinksResponse : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.ResolvedLink> Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.ResolvedLink>
            >("links");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.ResolvedLink>>(
                "links",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Links not read, in the order sent. X did not answer for them in time, or available credits ran out. Send them again.
    /// </summary>
    public required IReadOnlyList<string> UnprocessedUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("unprocessedUrls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "unprocessedUrls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Links)
        {
            item.Validate();
        }
        _ = this.UnprocessedUrls;
    }

    public TweetResolveLinksResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetResolveLinksResponse(TweetResolveLinksResponse tweetResolveLinksResponse)
        : base(tweetResolveLinksResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetResolveLinksResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetResolveLinksResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetResolveLinksResponseFromRaw.FromRawUnchecked"/>
    public static TweetResolveLinksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetResolveLinksResponseFromRaw : IFromRawJson<TweetResolveLinksResponse>
{
    /// <inheritdoc/>
    public TweetResolveLinksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetResolveLinksResponse.FromRawUnchecked(rawData);
}
