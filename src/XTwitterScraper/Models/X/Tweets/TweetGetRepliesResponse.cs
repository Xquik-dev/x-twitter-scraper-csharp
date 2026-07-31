using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Direct replies, separately reported nested replies, and completeness diagnostics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetGetRepliesResponse, TweetGetRepliesResponseFromRaw>))]
public sealed record class TweetGetRepliesResponse : PaginatedTweets
{
    public TweetGetRepliesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRepliesResponse(TweetGetRepliesResponse response)
        : base(response) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetGetRepliesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
        : base(rawData) { }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static new TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => new(rawData);
}

sealed class TweetGetRepliesResponseFromRaw : IFromRawJson<TweetGetRepliesResponse>
{
    /// <inheritdoc/>
    public TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponse.FromRawUnchecked(rawData);
}
