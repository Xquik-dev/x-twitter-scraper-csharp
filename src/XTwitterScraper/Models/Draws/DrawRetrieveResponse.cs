using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawRetrieveResponse, DrawRetrieveResponseFromRaw>))]
public sealed record class DrawRetrieveResponse : JsonModel
{
    /// <summary>
    /// Full giveaway draw with tweet metrics, entries, and timing.
    /// </summary>
    public required Draw Draw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Draw>("draw");
        }
        init { this._rawData.Set("draw", value); }
    }

    public required IReadOnlyList<DrawRetrieveResponseWinner> Winners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DrawRetrieveResponseWinner>>(
                "winners"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DrawRetrieveResponseWinner>>(
                "winners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Draw.Validate();
        foreach (var item in this.Winners)
        {
            item.Validate();
        }
    }

    public DrawRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawRetrieveResponse(DrawRetrieveResponse drawRetrieveResponse)
        : base(drawRetrieveResponse) { }
#pragma warning restore CS8618

    public DrawRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static DrawRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawRetrieveResponseFromRaw : IFromRawJson<DrawRetrieveResponse>
{
    /// <inheritdoc/>
    public DrawRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DrawRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Full giveaway draw with tweet metrics, entries, and timing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Draw, DrawFromRaw>))]
public sealed record class Draw : JsonModel
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

    public Draw() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Draw(Draw draw)
        : base(draw) { }
#pragma warning restore CS8618

    public Draw(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Draw(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawFromRaw.FromRawUnchecked"/>
    public static Draw FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawFromRaw : IFromRawJson<Draw>
{
    /// <inheritdoc/>
    public Draw FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Draw.FromRawUnchecked(rawData);
}

/// <summary>
/// Giveaway draw winner with position and backup flag.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DrawRetrieveResponseWinner, DrawRetrieveResponseWinnerFromRaw>)
)]
public sealed record class DrawRetrieveResponseWinner : JsonModel
{
    public required string AuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorUsername");
        }
        init { this._rawData.Set("authorUsername", value); }
    }

    public required bool IsBackup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isBackup");
        }
        init { this._rawData.Set("isBackup", value); }
    }

    public required long Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("position");
        }
        init { this._rawData.Set("position", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorUsername;
        _ = this.IsBackup;
        _ = this.Position;
        _ = this.TweetID;
    }

    public DrawRetrieveResponseWinner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawRetrieveResponseWinner(DrawRetrieveResponseWinner drawRetrieveResponseWinner)
        : base(drawRetrieveResponseWinner) { }
#pragma warning restore CS8618

    public DrawRetrieveResponseWinner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawRetrieveResponseWinner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawRetrieveResponseWinnerFromRaw.FromRawUnchecked"/>
    public static DrawRetrieveResponseWinner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawRetrieveResponseWinnerFromRaw : IFromRawJson<DrawRetrieveResponseWinner>
{
    /// <inheritdoc/>
    public DrawRetrieveResponseWinner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DrawRetrieveResponseWinner.FromRawUnchecked(rawData);
}
