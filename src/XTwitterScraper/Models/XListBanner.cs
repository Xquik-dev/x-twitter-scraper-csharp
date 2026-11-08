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

[JsonConverter(typeof(JsonModelConverter<XListBannerSalientRect, XListBannerSalientRectFromRaw>))]
public sealed record class XListBannerSalientRect : JsonModel
{
    /// <summary>
    /// Pixels from the banner's left.
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
    /// Pixels from the banner's top.
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
    /// Width of the marked area.
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
    /// Height of the marked area.
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

    public XListBannerSalientRect() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XListBannerSalientRect(XListBannerSalientRect xListBannerSalientRect)
        : base(xListBannerSalientRect) { }
#pragma warning restore CS8618

    public XListBannerSalientRect(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XListBannerSalientRect(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XListBannerSalientRectFromRaw.FromRawUnchecked"/>
    public static XListBannerSalientRect FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XListBannerSalientRectFromRaw : IFromRawJson<XListBannerSalientRect>
{
    /// <inheritdoc/>
    public XListBannerSalientRect FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XListBannerSalientRect.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<XListBannerPaletteRgb, XListBannerPaletteRgbFromRaw>))]
public sealed record class XListBannerPaletteRgb : JsonModel
{
    public long? Red
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("red");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("red", value);
        }
    }

    public long? Green
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("green");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("green", value);
        }
    }

    public long? Blue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("blue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blue", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Red;
        _ = this.Green;
        _ = this.Blue;
    }

    public XListBannerPaletteRgb() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XListBannerPaletteRgb(XListBannerPaletteRgb xListBannerPaletteRgb)
        : base(xListBannerPaletteRgb) { }
#pragma warning restore CS8618

    public XListBannerPaletteRgb(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XListBannerPaletteRgb(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XListBannerPaletteRgbFromRaw.FromRawUnchecked"/>
    public static XListBannerPaletteRgb FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XListBannerPaletteRgbFromRaw : IFromRawJson<XListBannerPaletteRgb>
{
    /// <inheritdoc/>
    public XListBannerPaletteRgb FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XListBannerPaletteRgb.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<XListBannerPalette, XListBannerPaletteFromRaw>))]
public sealed record class XListBannerPalette : JsonModel
{
    /// <summary>
    /// Share of the banner, from 0 to 100.
    /// </summary>
    public double? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentage", value);
        }
    }

    /// <summary>
    /// The color's red, green and blue values.
    /// </summary>
    public XListBannerPaletteRgb? Rgb
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<XListBannerPaletteRgb>("rgb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rgb", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percentage;
        this.Rgb?.Validate();
    }

    public XListBannerPalette() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XListBannerPalette(XListBannerPalette xListBannerPalette)
        : base(xListBannerPalette) { }
#pragma warning restore CS8618

    public XListBannerPalette(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XListBannerPalette(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XListBannerPaletteFromRaw.FromRawUnchecked"/>
    public static XListBannerPalette FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XListBannerPaletteFromRaw : IFromRawJson<XListBannerPalette>
{
    /// <inheritdoc/>
    public XListBannerPalette FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XListBannerPalette.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<XListBanner, XListBannerFromRaw>))]
public sealed record class XListBanner : JsonModel
{
    /// <summary>
    /// Banner image URL.
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
    /// Banner width in pixels.
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
    /// Banner height in pixels.
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
    /// Area X marks as the subject of the banner, in pixels.
    /// </summary>
    public XListBannerSalientRect? SalientRect
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<XListBannerSalientRect>("salientRect");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("salientRect", value);
        }
    }

    /// <summary>
    /// Media ID of an uploaded banner.
    /// </summary>
    public string? MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaId", value);
        }
    }

    /// <summary>
    /// Stable media key of an uploaded banner.
    /// </summary>
    public string? MediaKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaKey", value);
        }
    }

    /// <summary>
    /// Dominant colors of an uploaded banner and their shares.
    /// </summary>
    public IReadOnlyList<XListBannerPalette>? Palette
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<XListBannerPalette>>("palette");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<XListBannerPalette>?>(
                "palette",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.Width;
        _ = this.Height;
        this.SalientRect?.Validate();
        _ = this.MediaID;
        _ = this.MediaKey;
        foreach (var item in this.Palette ?? [])
        {
            item.Validate();
        }
    }

    public XListBanner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XListBanner(XListBanner xListBanner)
        : base(xListBanner) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XListBanner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XListBanner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XListBannerFromRaw.FromRawUnchecked"/>
    public static XListBanner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XListBannerFromRaw : IFromRawJson<XListBanner>
{
    /// <inheritdoc/>
    public XListBanner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XListBanner.FromRawUnchecked(rawData);
}
