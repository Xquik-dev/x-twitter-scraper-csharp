using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Author of a tweet with follower count and verification status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetAuthor, TweetAuthorFromRaw>))]
public sealed record class TweetAuthor : JsonModel
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

    public required long Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("followers");
        }
        init { this._rawData.Set("followers", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Followers;
        _ = this.Username;
        _ = this.Verified;
        _ = this.ProfilePicture;
    }

    public TweetAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthor(TweetAuthor tweetAuthor)
        : base(tweetAuthor) { }
#pragma warning restore CS8618

    public TweetAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorFromRaw.FromRawUnchecked"/>
    public static TweetAuthor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorFromRaw : IFromRawJson<TweetAuthor>
{
    /// <inheritdoc/>
    public TweetAuthor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetAuthor.FromRawUnchecked(rawData);
}
