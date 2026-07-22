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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MediaUrl;
        this.Type.Validate();
        _ = this.Url;
        foreach (var item in this.VideoVariants ?? [])
        {
            item.Validate();
        }
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
