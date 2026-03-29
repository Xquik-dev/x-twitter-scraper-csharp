using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheHit;
        _ = this.GalleryUrl;
        _ = this.TotalMedia;
        _ = this.TotalTweets;
        _ = this.TweetID;
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
