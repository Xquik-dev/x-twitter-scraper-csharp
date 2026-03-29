using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(
    typeof(JsonModelConverter<TweetGetFavoritersResponse, TweetGetFavoritersResponseFromRaw>)
)]
public sealed record class TweetGetFavoritersResponse : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    public required IReadOnlyList<JsonElement> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JsonElement>>("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JsonElement>>(
                "users",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        _ = this.Users;
    }

    public TweetGetFavoritersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetFavoritersResponse(TweetGetFavoritersResponse tweetGetFavoritersResponse)
        : base(tweetGetFavoritersResponse) { }
#pragma warning restore CS8618

    public TweetGetFavoritersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetFavoritersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetFavoritersResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetFavoritersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetFavoritersResponseFromRaw : IFromRawJson<TweetGetFavoritersResponse>
{
    /// <inheritdoc/>
    public TweetGetFavoritersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetFavoritersResponse.FromRawUnchecked(rawData);
}
