using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

/// <summary>
/// Giveaway draw winner with position and backup flag.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Winner, WinnerFromRaw>))]
public sealed record class Winner : JsonModel
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

    public Winner() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Winner(Winner winner)
        : base(winner) { }
#pragma warning restore CS8618

    public Winner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Winner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WinnerFromRaw.FromRawUnchecked"/>
    public static Winner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WinnerFromRaw : IFromRawJson<Winner>
{
    /// <inheritdoc/>
    public Winner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Winner.FromRawUnchecked(rawData);
}
