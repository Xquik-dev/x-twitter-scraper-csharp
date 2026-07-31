using System.Collections.Generic;
using System.Collections.Immutable;
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
    public Diagnostic? Diagnostic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Diagnostic>("diagnostic");
        }
        init
        {
            if (value != null)
            {
                this._rawData.Set("diagnostic", value);
            }
        }
    }

    /// <summary>
    /// Nested replies. Excluded from direct coverage.
    /// </summary>
    public IReadOnlyList<SearchTweet>? NestedReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweet>>("nested_replies");
        }
        init
        {
            if (value != null)
            {
                this._rawData.Set("nested_replies", ImmutableArray.ToImmutableArray(value));
            }
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        base.Validate();
        this.Diagnostic?.Validate();
        foreach (var item in this.NestedReplies ?? [])
        {
            item.Validate();
        }
    }
}

sealed class TweetGetRepliesResponseFromRaw : IFromRawJson<TweetGetRepliesResponse>
{
    /// <inheritdoc/>
    public TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponse.FromRawUnchecked(rawData);
}
