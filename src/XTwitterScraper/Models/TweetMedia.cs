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
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models;

/// <summary>
/// Normalized media attached to a tweet.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetMedia, TweetMediaFromRaw>))]
public sealed record class TweetMedia : JsonModel
{
    /// <summary>
    /// Media preview URL
    /// </summary>
    public required string MediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mediaUrl");
        }
        init { this._rawData.Set("mediaUrl", value); }
    }

    public required ApiEnum<string, TweetMediaType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TweetMediaType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// X media link from the tweet
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// X media entity ID.
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

    /// <summary>
    /// Whether X permits direct media download.
    /// </summary>
    public bool? AllowDownload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allowDownload");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowDownload", value);
        }
    }

    /// <summary>
    /// Accessibility text supplied for the media.
    /// </summary>
    public string? AltText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("altText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("altText", value);
        }
    }

    /// <summary>
    /// Video aspect ratio as width and height.
    /// </summary>
    public IReadOnlyList<long>? AspectRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("aspectRatio");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "aspectRatio",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Media availability state reported by X.
    /// </summary>
    public string? AvailabilityStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("availabilityStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("availabilityStatus", value);
        }
    }

    /// <summary>
    /// Display-friendly media URL reported by X.
    /// </summary>
    public string? DisplayUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayUrl", value);
        }
    }

    /// <summary>
    /// Video duration in milliseconds.
    /// </summary>
    public long? DurationMillis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("durationMillis");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationMillis", value);
        }
    }

    /// <summary>
    /// Expanded X media URL.
    /// </summary>
    public string? ExpandedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expandedUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expandedUrl", value);
        }
    }

    /// <summary>
    /// Face-aware crop rectangles grouped by media size.
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<UnnamedSchemaWithArrayParent0>>? FaceRects
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<UnnamedSchemaWithArrayParent0>>
            >("faceRects");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<UnnamedSchemaWithArrayParent0>)entry.Value
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<
                string,
                ImmutableArray<UnnamedSchemaWithArrayParent0>
            >?>(
                "faceRects",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <summary>
    /// Suggested image crops reported by X.
    /// </summary>
    public IReadOnlyList<FocusRect>? FocusRects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FocusRect>>("focusRects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FocusRect>?>(
                "focusRects",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original media height.
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
    /// Media entity offsets in the tweet text.
    /// </summary>
    public IReadOnlyList<long>? Indices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("indices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "indices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Stable X media key.
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
    /// Whether X reports the media as monetizable.
    /// </summary>
    public bool? Monetizable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("monetizable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monetizable", value);
        }
    }

    /// <summary>
    /// Named media renditions and resize modes.
    /// </summary>
    public IReadOnlyDictionary<string, SizesItem>? Sizes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, SizesItem>>("sizes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, SizesItem>?>(
                "sizes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Available video encodings, ordered as returned
    /// </summary>
    public IReadOnlyList<VideoVariant>? VideoVariants
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VideoVariant>>("videoVariants");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<VideoVariant>?>(
                "videoVariants",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Original media width.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaUrl;
        this.Type.Validate();
        _ = this.Url;
        _ = this.ID;
        _ = this.AllowDownload;
        _ = this.AltText;
        _ = this.AspectRatio;
        _ = this.AvailabilityStatus;
        _ = this.DisplayUrl;
        _ = this.DurationMillis;
        _ = this.ExpandedUrl;
        if (this.FaceRects != null)
        {
            foreach (var item in this.FaceRects.Values)
            {
                foreach (var item1 in item)
                {
                    item1.Validate();
                }
            }
        }
        foreach (var item in this.FocusRects ?? [])
        {
            item.Validate();
        }
        _ = this.Height;
        _ = this.Indices;
        _ = this.MediaKey;
        _ = this.Monetizable;
        if (this.Sizes != null)
        {
            foreach (var item in this.Sizes.Values)
            {
                item.Validate();
            }
        }
        foreach (var item in this.VideoVariants ?? [])
        {
            item.Validate();
        }
        _ = this.Width;
    }

    public TweetMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetMedia(TweetMedia tweetMedia)
        : base(tweetMedia) { }
#pragma warning restore CS8618

    public TweetMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetMediaFromRaw.FromRawUnchecked"/>
    public static TweetMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetMediaFromRaw : IFromRawJson<TweetMedia>
{
    /// <inheritdoc/>
    public TweetMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetMedia.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetMediaTypeConverter))]
public enum TweetMediaType
{
    Photo,
    Video,
    AnimatedGif,
}

sealed class TweetMediaTypeConverter : JsonConverter<TweetMediaType>
{
    public override TweetMediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "photo" => TweetMediaType.Photo,
            "video" => TweetMediaType.Video,
            "animated_gif" => TweetMediaType.AnimatedGif,
            _ => (TweetMediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetMediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetMediaType.Photo => "photo",
                TweetMediaType.Video => "video",
                TweetMediaType.AnimatedGif => "animated_gif",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<UnnamedSchemaWithArrayParent0, UnnamedSchemaWithArrayParent0FromRaw>)
)]
public sealed record class UnnamedSchemaWithArrayParent0 : JsonModel
{
    public required long H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    public required long W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    public required long X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    public required long Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public UnnamedSchemaWithArrayParent0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0(
        UnnamedSchemaWithArrayParent0 unnamedSchemaWithArrayParent0
    )
        : base(unnamedSchemaWithArrayParent0) { }
#pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0FromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnnamedSchemaWithArrayParent0FromRaw : IFromRawJson<UnnamedSchemaWithArrayParent0>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnnamedSchemaWithArrayParent0.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FocusRect, FocusRectFromRaw>))]
public sealed record class FocusRect : JsonModel
{
    public required long H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    public required long W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    public required long X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    public required long Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public FocusRect() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FocusRect(FocusRect focusRect)
        : base(focusRect) { }
#pragma warning restore CS8618

    public FocusRect(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FocusRect(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FocusRectFromRaw.FromRawUnchecked"/>
    public static FocusRect FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FocusRectFromRaw : IFromRawJson<FocusRect>
{
    /// <inheritdoc/>
    public FocusRect FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FocusRect.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SizesItem, SizesItemFromRaw>))]
public sealed record class SizesItem : JsonModel
{
    public required long H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    public required string Resize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("resize");
        }
        init { this._rawData.Set("resize", value); }
    }

    public required long W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.Resize;
        _ = this.W;
    }

    public SizesItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SizesItem(SizesItem sizesItem)
        : base(sizesItem) { }
#pragma warning restore CS8618

    public SizesItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SizesItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SizesItemFromRaw.FromRawUnchecked"/>
    public static SizesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SizesItemFromRaw : IFromRawJson<SizesItem>
{
    /// <inheritdoc/>
    public SizesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SizesItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VideoVariant, VideoVariantFromRaw>))]
public sealed record class VideoVariant : JsonModel
{
    public required string ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contentType");
        }
        init { this._rawData.Set("contentType", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public long? Bitrate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bitrate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitrate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContentType;
        _ = this.Url;
        _ = this.Bitrate;
    }

    public VideoVariant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoVariant(VideoVariant videoVariant)
        : base(videoVariant) { }
#pragma warning restore CS8618

    public VideoVariant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoVariant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoVariantFromRaw.FromRawUnchecked"/>
    public static VideoVariant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoVariantFromRaw : IFromRawJson<VideoVariant>
{
    /// <inheritdoc/>
    public VideoVariant FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VideoVariant.FromRawUnchecked(rawData);
}
