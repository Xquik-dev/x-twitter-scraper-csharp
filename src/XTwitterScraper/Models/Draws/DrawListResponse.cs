using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Draws;

[JsonConverter(typeof(JsonModelConverter<DrawListResponse, DrawListResponseFromRaw>))]
public sealed record class DrawListResponse : JsonModel
{
    public required IReadOnlyList<DrawListResponseDraw> Draws
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DrawListResponseDraw>>("draws");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DrawListResponseDraw>>(
                "draws",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Draws)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public DrawListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawListResponse(DrawListResponse drawListResponse)
        : base(drawListResponse) { }
#pragma warning restore CS8618

    public DrawListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawListResponseFromRaw.FromRawUnchecked"/>
    public static DrawListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawListResponseFromRaw : IFromRawJson<DrawListResponse>
{
    /// <inheritdoc/>
    public DrawListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DrawListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Giveaway draw summary with entry counts and status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DrawListResponseDraw, DrawListResponseDrawFromRaw>))]
public sealed record class DrawListResponseDraw : JsonModel
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
        _ = this.TweetUrl;
        _ = this.ValidEntries;
        _ = this.DrawnAt;
    }

    public DrawListResponseDraw() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DrawListResponseDraw(DrawListResponseDraw drawListResponseDraw)
        : base(drawListResponseDraw) { }
#pragma warning restore CS8618

    public DrawListResponseDraw(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DrawListResponseDraw(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DrawListResponseDrawFromRaw.FromRawUnchecked"/>
    public static DrawListResponseDraw FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DrawListResponseDrawFromRaw : IFromRawJson<DrawListResponseDraw>
{
    /// <inheritdoc/>
    public DrawListResponseDraw FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DrawListResponseDraw.FromRawUnchecked(rawData);
}
