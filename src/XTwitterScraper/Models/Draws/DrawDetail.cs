using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawDetail, DrawDetailFromRaw>))]
public sealed record class DrawDetail : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required long TotalEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalEntries");
        }
        init { this._rawData.Set("totalEntries", value); }
    }

    public required string TweetAuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetAuthorUsername");
        }
        init { this._rawData.Set("tweetAuthorUsername", value); }
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

    public required long TweetLikeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetLikeCount");
        }
        init { this._rawData.Set("tweetLikeCount", value); }
    }

    public required long TweetQuoteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetQuoteCount");
        }
        init { this._rawData.Set("tweetQuoteCount", value); }
    }

    public required long TweetReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetReplyCount");
        }
        init { this._rawData.Set("tweetReplyCount", value); }
    }

    public required long TweetRetweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("tweetRetweetCount");
        }
        init { this._rawData.Set("tweetRetweetCount", value); }
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

    public required string TweetUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetUrl");
        }
        init { this._rawData.Set("tweetUrl", value); }
    }

    public required long ValidEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("validEntries");
        }
        init { this._rawData.Set("validEntries", value); }
    }

    public DateTimeOffset? DrawnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("drawnAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drawnAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Status;
        _ = this.TotalEntries;
        _ = this.TweetAuthorUsername;
        _ = this.TweetID;
        _ = this.TweetLikeCount;
        _ = this.TweetQuoteCount;
        _ = this.TweetReplyCount;
        _ = this.TweetRetweetCount;
        _ = this.TweetText;
        _ = this.TweetUrl;
        _ = this.ValidEntries;
        _ = this.DrawnAt;
    }

    public DrawDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawDetail(DrawDetail drawDetail)
        : base(drawDetail) { }
#pragma warning restore CS8618

    public DrawDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawDetailFromRaw.FromRawUnchecked"/>
    public static DrawDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawDetailFromRaw : IFromRawJson<DrawDetail>
{
    /// <inheritdoc/>
    public DrawDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DrawDetail.FromRawUnchecked(rawData);
}
