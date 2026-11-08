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

[JsonConverter(
    typeof(JsonModelConverter<
        TweetInterstitialTextEntitiesRef,
        TweetInterstitialTextEntitiesRefFromRaw
    >)
)]
public sealed record class TweetInterstitialTextEntitiesRef : JsonModel
{
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlType", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public string? ScreenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("screenName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("screenName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.UrlValue;
        _ = this.UrlType;
        _ = this.Text;
        _ = this.ScreenName;
    }

    public TweetInterstitialTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInterstitialTextEntitiesRef(
        TweetInterstitialTextEntitiesRef tweetInterstitialTextEntitiesRef
    )
        : base(tweetInterstitialTextEntitiesRef) { }
#pragma warning restore CS8618

    public TweetInterstitialTextEntitiesRef(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetInterstitialTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetInterstitialTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static TweetInterstitialTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetInterstitialTextEntitiesRefFromRaw : IFromRawJson<TweetInterstitialTextEntitiesRef>
{
    /// <inheritdoc/>
    public TweetInterstitialTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetInterstitialTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetInterstitialTextEntities, TweetInterstitialTextEntitiesFromRaw>)
)]
public sealed record class TweetInterstitialTextEntities : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? FromIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fromIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fromIndex", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? ToIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("toIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toIndex", value);
        }
    }

    public TweetInterstitialTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetInterstitialTextEntitiesRef>("ref");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ref", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromIndex;
        _ = this.ToIndex;
        this.Ref?.Validate();
    }

    public TweetInterstitialTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInterstitialTextEntities(
        TweetInterstitialTextEntities tweetInterstitialTextEntities
    )
        : base(tweetInterstitialTextEntities) { }
#pragma warning restore CS8618

    public TweetInterstitialTextEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetInterstitialTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetInterstitialTextEntitiesFromRaw.FromRawUnchecked"/>
    public static TweetInterstitialTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetInterstitialTextEntitiesFromRaw : IFromRawJson<TweetInterstitialTextEntities>
{
    /// <inheritdoc/>
    public TweetInterstitialTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetInterstitialTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetInterstitialText, TweetInterstitialTextFromRaw>))]
public sealed record class TweetInterstitialText : JsonModel
{
    /// <summary>
    /// The notice's text.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Whether X writes it right to left.
    /// </summary>
    public bool? Rtl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("rtl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rtl", value);
        }
    }

    /// <summary>
    /// Links inside the notice, by character range.
    /// </summary>
    public IReadOnlyList<TweetInterstitialTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetInterstitialTextEntities>>(
                "entities"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetInterstitialTextEntities>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Rtl;
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
    }

    public TweetInterstitialText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInterstitialText(TweetInterstitialText tweetInterstitialText)
        : base(tweetInterstitialText) { }
#pragma warning restore CS8618

    public TweetInterstitialText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetInterstitialText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetInterstitialTextFromRaw.FromRawUnchecked"/>
    public static TweetInterstitialText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetInterstitialTextFromRaw : IFromRawJson<TweetInterstitialText>
{
    /// <inheritdoc/>
    public TweetInterstitialText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetInterstitialText.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetInterstitial, TweetInterstitialFromRaw>))]
public sealed record class TweetInterstitial : JsonModel
{
    /// <summary>
    /// How x.com shows the notice. `NonCompliant` marks a post that broke X's rules.
    /// </summary>
    public string? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayType", value);
        }
    }

    public TweetInterstitialText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetInterstitialText>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayType;
        this.Text?.Validate();
    }

    public TweetInterstitial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetInterstitial(TweetInterstitial tweetInterstitial)
        : base(tweetInterstitial) { }
#pragma warning restore CS8618

    public TweetInterstitial(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetInterstitial(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetInterstitialFromRaw.FromRawUnchecked"/>
    public static TweetInterstitial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetInterstitialFromRaw : IFromRawJson<TweetInterstitial>
{
    /// <inheritdoc/>
    public TweetInterstitial FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetInterstitial.FromRawUnchecked(rawData);
}
