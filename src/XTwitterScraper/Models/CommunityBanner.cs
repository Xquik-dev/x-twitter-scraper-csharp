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

[JsonConverter(typeof(JsonModelConverter<CommunityBannerColors, CommunityBannerColorsFromRaw>))]
public sealed record class CommunityBannerColors : JsonModel
{
    /// <summary>
    /// Share of the banner in this color
    /// </summary>
    public required double Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage");
        }
        init { this._rawData.Set("percentage", value); }
    }

    /// <summary>
    /// Red value of the color
    /// </summary>
    public required long Red
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("red");
        }
        init { this._rawData.Set("red", value); }
    }

    /// <summary>
    /// Green value of the color
    /// </summary>
    public required long Green
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("green");
        }
        init { this._rawData.Set("green", value); }
    }

    /// <summary>
    /// Blue value of the color
    /// </summary>
    public required long Blue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("blue");
        }
        init { this._rawData.Set("blue", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percentage;
        _ = this.Red;
        _ = this.Green;
        _ = this.Blue;
    }

    public CommunityBannerColors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityBannerColors(CommunityBannerColors communityBannerColors)
        : base(communityBannerColors) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityBannerColors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityBannerColors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityBannerColorsFromRaw.FromRawUnchecked"/>
    public static CommunityBannerColors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityBannerColorsFromRaw : IFromRawJson<CommunityBannerColors>
{
    /// <inheritdoc/>
    public CommunityBannerColors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityBannerColors.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityBannerFocus, CommunityBannerFocusFromRaw>))]
public sealed record class CommunityBannerFocus : JsonModel
{
    /// <summary>
    /// Distance from the left edge
    /// </summary>
    public long? Left
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("left");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("left", value);
        }
    }

    /// <summary>
    /// Distance from the top edge
    /// </summary>
    public long? Top
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top", value);
        }
    }

    /// <summary>
    /// Width of the area
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <summary>
    /// Height of the area
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Left;
        _ = this.Top;
        _ = this.Width;
        _ = this.Height;
    }

    public CommunityBannerFocus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityBannerFocus(CommunityBannerFocus communityBannerFocus)
        : base(communityBannerFocus) { }
#pragma warning restore CS8618

    public CommunityBannerFocus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityBannerFocus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityBannerFocusFromRaw.FromRawUnchecked"/>
    public static CommunityBannerFocus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityBannerFocusFromRaw : IFromRawJson<CommunityBannerFocus>
{
    /// <inheritdoc/>
    public CommunityBannerFocus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityBannerFocus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityBanner, CommunityBannerFromRaw>))]
public sealed record class CommunityBanner : JsonModel
{
    /// <summary>
    /// Banner image URL at its original size
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Banner width in pixels
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <summary>
    /// Banner height in pixels
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Main colors of the banner, largest share first
    /// </summary>
    public IReadOnlyList<CommunityBannerColors>? Colors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CommunityBannerColors>>("colors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CommunityBannerColors>?>(
                "colors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Area X keeps in view when it crops the banner, in pixels from the top left
    /// </summary>
    public CommunityBannerFocus? Focus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityBannerFocus>("focus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("focus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.Width;
        _ = this.Height;
        foreach (var item in this.Colors ?? [])
        {
            item.Validate();
        }
        this.Focus?.Validate();
    }

    public CommunityBanner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityBanner(CommunityBanner communityBanner)
        : base(communityBanner) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityBanner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityBanner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityBannerFromRaw.FromRawUnchecked"/>
    public static CommunityBanner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityBannerFromRaw : IFromRawJson<CommunityBanner>
{
    /// <inheritdoc/>
    public CommunityBanner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityBanner.FromRawUnchecked(rawData);
}
