using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

[JsonConverter(
    typeof(JsonModelConverter<TweetGetRetweetersResponse, TweetGetRetweetersResponseFromRaw>)
)]
public sealed record class TweetGetRetweetersResponse : JsonModel
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

    public TweetGetRetweetersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRetweetersResponse(TweetGetRetweetersResponse tweetGetRetweetersResponse)
        : base(tweetGetRetweetersResponse) { }
#pragma warning restore CS8618

    public TweetGetRetweetersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetGetRetweetersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetGetRetweetersResponseFromRaw.FromRawUnchecked"/>
    public static TweetGetRetweetersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetGetRetweetersResponseFromRaw : IFromRawJson<TweetGetRetweetersResponse>
{
    /// <inheritdoc/>
    public TweetGetRetweetersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRetweetersResponse.FromRawUnchecked(rawData);
}
