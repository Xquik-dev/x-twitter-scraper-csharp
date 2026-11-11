// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Media;

[JsonConverter(typeof(JsonModelConverter<MediaDownloadResponse, MediaDownloadResponseFromRaw>))]
public sealed record class MediaDownloadResponse : JsonModel
{
    public bool? CacheHit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cacheHit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cacheHit", value);
        }
    }

    public string? GalleryUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("galleryUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("galleryUrl", value);
        }
    }

    /// <summary>
    /// What the image filter asked &amp; how many posts it kept. Present when you send
    /// imageShows.
    /// </summary>
    public ImageFilterSummary? ImageFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageFilterSummary>("imageFilter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageFilter", value);
        }
    }

    public long? TotalMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalMedia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalMedia", value);
        }
    }

    public long? TotalTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalTweets", value);
        }
    }

    public string? TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tweetId", value);
        }
    }

    /// <summary>
    /// The post's files saved to your gallery. Single downloads only. Empty when imageShows kept no photo.
    /// </summary>
    public IReadOnlyList<MediaDownloadResponseItems>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MediaDownloadResponseItems>>(
                "items"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<MediaDownloadResponseItems>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts Xquik had no time to read, at no charge. Send them again.
    /// </summary>
    public IReadOnlyList<string>? UnprocessedTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("unprocessedTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "unprocessedTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts Xquik couldn't read, at no charge. Send them again.
    /// </summary>
    public IReadOnlyList<string>? FailedTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("failedTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "failedTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts with no media to save, at no charge.
    /// </summary>
    public IReadOnlyList<string>? NoMediaTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("noMediaTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "noMediaTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheHit;
        _ = this.GalleryUrl;
        this.ImageFilter?.Validate();
        _ = this.TotalMedia;
        _ = this.TotalTweets;
        _ = this.TweetID;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.UnprocessedTweetIDs;
        _ = this.FailedTweetIDs;
        _ = this.NoMediaTweetIDs;
    }

    public MediaDownloadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaDownloadResponse(MediaDownloadResponse mediaDownloadResponse)
        : base(mediaDownloadResponse) { }
#pragma warning restore CS8618

    public MediaDownloadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaDownloadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaDownloadResponseFromRaw.FromRawUnchecked"/>
    public static MediaDownloadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediaDownloadResponseFromRaw : IFromRawJson<MediaDownloadResponse>
{
    /// <inheritdoc/>
    public MediaDownloadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MediaDownloadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MediaDownloadResponseItemsMediaTypeConverter))]
public enum MediaDownloadResponseItemsMediaType
{
    Photo,
    Video,
    AnimatedGif,
}

sealed class MediaDownloadResponseItemsMediaTypeConverter
    : JsonConverter<MediaDownloadResponseItemsMediaType>
{
    public override MediaDownloadResponseItemsMediaType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "photo" => MediaDownloadResponseItemsMediaType.Photo,
            "video" => MediaDownloadResponseItemsMediaType.Video,
            "animated_gif" => MediaDownloadResponseItemsMediaType.AnimatedGif,
            _ => (MediaDownloadResponseItemsMediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaDownloadResponseItemsMediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaDownloadResponseItemsMediaType.Photo => "photo",
                MediaDownloadResponseItemsMediaType.Video => "video",
                MediaDownloadResponseItemsMediaType.AnimatedGif => "animated_gif",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        MediaDownloadResponseItemsQualities,
        MediaDownloadResponseItemsQualitiesFromRaw
    >)
)]
public sealed record class MediaDownloadResponseItemsQualities : JsonModel
{
    public required long Bitrate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bitrate");
        }
        init { this._rawData.Set("bitrate", value); }
    }

    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bitrate;
        _ = this.Height;
        _ = this.UrlValue;
        _ = this.Width;
    }

    public MediaDownloadResponseItemsQualities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaDownloadResponseItemsQualities(
        MediaDownloadResponseItemsQualities mediaDownloadResponseItemsQualities
    )
        : base(mediaDownloadResponseItemsQualities) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaDownloadResponseItemsQualities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaDownloadResponseItemsQualities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaDownloadResponseItemsQualitiesFromRaw.FromRawUnchecked"/>
    public static MediaDownloadResponseItemsQualities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediaDownloadResponseItemsQualitiesFromRaw : IFromRawJson<MediaDownloadResponseItemsQualities>
{
    /// <inheritdoc/>
    public MediaDownloadResponseItemsQualities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MediaDownloadResponseItemsQualities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<MediaDownloadResponseItems, MediaDownloadResponseItemsFromRaw>)
)]
public sealed record class MediaDownloadResponseItems : JsonModel
{
    /// <summary>
    /// Gallery file ID
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    public required ApiEnum<string, MediaDownloadResponseItemsMediaType> MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MediaDownloadResponseItemsMediaType>
            >("mediaType");
        }
        init { this._rawData.Set("mediaType", value); }
    }

    /// <summary>
    /// Link to the file. It goes to X when X flagged the post or its media at save time, or sent no post flag. Xquik keeps no copy of those files.
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

    /// <summary>
    /// Cover image of a video or GIF. Null for photos &amp; files first saved to Xquik before 2026-11-03.
    /// </summary>
    public required string? PosterUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("posterUrl");
        }
        init { this._rawData.Set("posterUrl", value); }
    }

    /// <summary>
    /// The MP4 sizes X stores for a video, highest bitrate first. Empty for photos, GIFs &amp; files first saved to Xquik before 2026-11-03.
    /// </summary>
    public required IReadOnlyList<MediaDownloadResponseItemsQualities> Qualities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<MediaDownloadResponseItemsQualities>
            >("qualities");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MediaDownloadResponseItemsQualities>>(
                "qualities",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// File size in bytes, as a string
    /// </summary>
    public required string? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fileSize");
        }
        init { this._rawData.Set("fileSize", value); }
    }

    /// <summary>
    /// When the file joined your gallery
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string AuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorUsername");
        }
        init { this._rawData.Set("authorUsername", value); }
    }

    public required string AuthorDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorDisplayName");
        }
        init { this._rawData.Set("authorDisplayName", value); }
    }

    public required string? AuthorAvatar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorAvatar");
        }
        init { this._rawData.Set("authorAvatar", value); }
    }

    public required string TweetText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetText");
        }
        init { this._rawData.Set("tweetText", value); }
    }

    public required long? Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("likes");
        }
        init { this._rawData.Set("likes", value); }
    }

    public required long? Retweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retweets");
        }
        init { this._rawData.Set("retweets", value); }
    }

    public required long? Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("views");
        }
        init { this._rawData.Set("views", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.TweetID;
        this.MediaType.Validate();
        _ = this.MediaUrl;
        _ = this.PosterUrl;
        foreach (var item in this.Qualities)
        {
            item.Validate();
        }
        _ = this.FileSize;
        _ = this.CreatedAt;
        _ = this.AuthorUsername;
        _ = this.AuthorDisplayName;
        _ = this.AuthorAvatar;
        _ = this.TweetText;
        _ = this.Likes;
        _ = this.Retweets;
        _ = this.Views;
    }

    public MediaDownloadResponseItems() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaDownloadResponseItems(MediaDownloadResponseItems mediaDownloadResponseItems)
        : base(mediaDownloadResponseItems) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaDownloadResponseItems(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaDownloadResponseItems(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MediaDownloadResponseItemsFromRaw.FromRawUnchecked"/>
    public static MediaDownloadResponseItems FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MediaDownloadResponseItemsFromRaw : IFromRawJson<MediaDownloadResponseItems>
{
    /// <inheritdoc/>
    public MediaDownloadResponseItems FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MediaDownloadResponseItems.FromRawUnchecked(rawData);
}
