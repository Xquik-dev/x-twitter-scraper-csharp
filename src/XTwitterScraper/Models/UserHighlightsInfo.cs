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

[JsonConverter(typeof(JsonModelConverter<UserHighlightsInfo, UserHighlightsInfoFromRaw>))]
public sealed record class UserHighlightsInfo : JsonModel
{
    public bool? CanHighlightTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("canHighlightTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canHighlightTweets", value);
        }
    }

    public string? HighlightedTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("highlightedTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highlightedTweets", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanHighlightTweets;
        _ = this.HighlightedTweets;
    }

    public UserHighlightsInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserHighlightsInfo(UserHighlightsInfo userHighlightsInfo)
        : base(userHighlightsInfo) { }
#pragma warning restore CS8618

    public UserHighlightsInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserHighlightsInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserHighlightsInfoFromRaw.FromRawUnchecked"/>
    public static UserHighlightsInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserHighlightsInfoFromRaw : IFromRawJson<UserHighlightsInfo>
{
    /// <inheritdoc/>
    public UserHighlightsInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserHighlightsInfo.FromRawUnchecked(rawData);
}
