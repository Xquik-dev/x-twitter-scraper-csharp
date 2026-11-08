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

[JsonConverter(typeof(JsonModelConverter<TweetAuthorUnavailable, TweetAuthorUnavailableFromRaw>))]
public sealed record class TweetAuthorUnavailable : JsonModel
{
    /// <summary>
    /// X's reason code.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// X's notice text for the reason.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        _ = this.Message;
    }

    public TweetAuthorUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorUnavailable(TweetAuthorUnavailable tweetAuthorUnavailable)
        : base(tweetAuthorUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorUnavailableFromRaw.FromRawUnchecked"/>
    public static TweetAuthorUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorUnavailableFromRaw : IFromRawJson<TweetAuthorUnavailable>
{
    /// <inheritdoc/>
    public TweetAuthorUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorUnavailable.FromRawUnchecked(rawData);
}
