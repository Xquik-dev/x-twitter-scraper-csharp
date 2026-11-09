using System;
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

    /// <summary>
    /// Present when your limit cut a complete-mode answer. The post has more replies. Raise limit to get them all.
    /// </summary>
    public bool? LimitReached
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("limit_reached");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit_reached", value);
        }
    }

    /// <summary>
    /// Present with latest or oldest sort. The read stopped before it held every reply X shows. Rows stay sorted by date, but replies may be missing between them. Retry later for a gap-free order. Complete mode and automatic pages set it alike.
    /// </summary>
    public bool? OrderPartial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("orderPartial");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("orderPartial", value);
        }
    }

    /// <summary>
    /// Present on the last automatic page, and on a complete-mode answer without rows. X counts this many more replies but shows them to nobody. They may be hidden, protected or deleted. A retry returns the same replies.
    /// </summary>
    public long? HiddenReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("hiddenReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hiddenReplies", value);
        }
    }

    /// <summary>
    /// Present on an answer that lacks some replies posted before this time. A retry returns about the same replies.
    /// </summary>
    public DateTimeOffset? PartialBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("partialBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("partialBefore", value);
        }
    }

    /// <summary>
    /// Present on automatic pages without filters while X counts replies the read hasn't reached. If a reply that belongs in your rows is missing, it's among them. The count drops as you read more pages. On the last page, it counts the replies the read can't reach.
    /// </summary>
    public long? UnreachedReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("unreachedReplies");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unreachedReplies", value);
        }
    }

    /// <summary>
    /// Explains an answer cut by your limit.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        base.Validate();
        this.Diagnostic?.Validate();
        foreach (var item in this.NestedReplies ?? [])
        {
            item.Validate();
        }
        _ = this.LimitReached;
        _ = this.OrderPartial;
        _ = this.HiddenReplies;
        _ = this.PartialBefore;
        _ = this.UnreachedReplies;
        _ = this.Message;
    }
}

sealed class TweetGetRepliesResponseFromRaw : IFromRawJson<TweetGetRepliesResponse>
{
    public TweetGetRepliesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetGetRepliesResponse.FromRawUnchecked(rawData);
}
