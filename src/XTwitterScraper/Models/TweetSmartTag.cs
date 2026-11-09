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

[JsonConverter(typeof(JsonModelConverter<TweetSmartTagInfoInfo, TweetSmartTagInfoInfoFromRaw>))]
public sealed record class TweetSmartTagInfoInfo : JsonModel
{
    /// <summary>
    /// Whether X marks the SmartTag active.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? Ticker
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticker");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ticker", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.Name;
        _ = this.Ticker;
    }

    public TweetSmartTagInfoInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSmartTagInfoInfo(TweetSmartTagInfoInfo tweetSmartTagInfoInfo)
        : base(tweetSmartTagInfoInfo) { }
#pragma warning restore CS8618

    public TweetSmartTagInfoInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSmartTagInfoInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSmartTagInfoInfoFromRaw.FromRawUnchecked"/>
    public static TweetSmartTagInfoInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSmartTagInfoInfoFromRaw : IFromRawJson<TweetSmartTagInfoInfo>
{
    /// <inheritdoc/>
    public TweetSmartTagInfoInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetSmartTagInfoInfo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetSmartTagInfo, TweetSmartTagInfoFromRaw>))]
public sealed record class TweetSmartTagInfo : JsonModel
{
    public TweetSmartTagInfoInfo? Info
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetSmartTagInfoInfo>("info");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("info", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Info?.Validate();
    }

    public TweetSmartTagInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSmartTagInfo(TweetSmartTagInfo tweetSmartTagInfo)
        : base(tweetSmartTagInfo) { }
#pragma warning restore CS8618

    public TweetSmartTagInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSmartTagInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSmartTagInfoFromRaw.FromRawUnchecked"/>
    public static TweetSmartTagInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSmartTagInfoFromRaw : IFromRawJson<TweetSmartTagInfo>
{
    /// <inheritdoc/>
    public TweetSmartTagInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetSmartTagInfo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetSmartTag, TweetSmartTagFromRaw>))]
public sealed record class TweetSmartTag : JsonModel
{
    /// <summary>
    /// X's ID for the SmartTag.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public TweetSmartTagInfo? Info
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetSmartTagInfo>("info");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("info", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Info?.Validate();
    }

    public TweetSmartTag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetSmartTag(TweetSmartTag tweetSmartTag)
        : base(tweetSmartTag) { }
#pragma warning restore CS8618

    public TweetSmartTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetSmartTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetSmartTagFromRaw.FromRawUnchecked"/>
    public static TweetSmartTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetSmartTagFromRaw : IFromRawJson<TweetSmartTag>
{
    /// <inheritdoc/>
    public TweetSmartTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetSmartTag.FromRawUnchecked(rawData);
}
