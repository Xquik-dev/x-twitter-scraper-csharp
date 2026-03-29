using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawRunResponse, DrawRunResponseFromRaw>))]
public sealed record class DrawRunResponse : JsonModel
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

    public required long TotalEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalEntries");
        }
        init { this._rawData.Set("totalEntries", value); }
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

    public required long ValidEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("validEntries");
        }
        init { this._rawData.Set("validEntries", value); }
    }

    public required IReadOnlyList<DrawRunResponseWinner> Winners
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DrawRunResponseWinner>>("winners");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DrawRunResponseWinner>>(
                "winners",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.TotalEntries;
        _ = this.TweetID;
        _ = this.ValidEntries;
        foreach (var item in this.Winners)
        {
            item.Validate();
        }
    }

    public DrawRunResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawRunResponse(DrawRunResponse drawRunResponse)
        : base(drawRunResponse) { }
#pragma warning restore CS8618

    public DrawRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawRunResponseFromRaw.FromRawUnchecked"/>
    public static DrawRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawRunResponseFromRaw : IFromRawJson<DrawRunResponse>
{
    /// <inheritdoc/>
    public DrawRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DrawRunResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DrawRunResponseWinner, DrawRunResponseWinnerFromRaw>))]
public sealed record class DrawRunResponseWinner : JsonModel
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

    public DrawRunResponseWinner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawRunResponseWinner(DrawRunResponseWinner drawRunResponseWinner)
        : base(drawRunResponseWinner) { }
#pragma warning restore CS8618

    public DrawRunResponseWinner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawRunResponseWinner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawRunResponseWinnerFromRaw.FromRawUnchecked"/>
    public static DrawRunResponseWinner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawRunResponseWinnerFromRaw : IFromRawJson<DrawRunResponseWinner>
{
    /// <inheritdoc/>
    public DrawRunResponseWinner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DrawRunResponseWinner.FromRawUnchecked(rawData);
}
