using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Drafts;

[JsonConverter(typeof(JsonModelConverter<DraftListResponse, DraftListResponseFromRaw>))]
public sealed record class DraftListResponse : JsonModel
{
    public required IReadOnlyList<DraftListResponseDraft> Drafts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DraftListResponseDraft>>("drafts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DraftListResponseDraft>>(
                "drafts",
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
        foreach (var item in this.Drafts)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public DraftListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftListResponse(DraftListResponse draftListResponse)
        : base(draftListResponse) { }
#pragma warning restore CS8618

    public DraftListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftListResponseFromRaw.FromRawUnchecked"/>
    public static DraftListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DraftListResponseFromRaw : IFromRawJson<DraftListResponse>
{
    /// <inheritdoc/>
    public DraftListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DraftListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DraftListResponseDraft, DraftListResponseDraftFromRaw>))]
public sealed record class DraftListResponseDraft : JsonModel
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

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public string? Goal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("goal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("goal", value);
        }
    }

    public string? Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topic", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Text;
        _ = this.Goal;
        _ = this.Topic;
    }

    public DraftListResponseDraft() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftListResponseDraft(DraftListResponseDraft draftListResponseDraft)
        : base(draftListResponseDraft) { }
#pragma warning restore CS8618

    public DraftListResponseDraft(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftListResponseDraft(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftListResponseDraftFromRaw.FromRawUnchecked"/>
    public static DraftListResponseDraft FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DraftListResponseDraftFromRaw : IFromRawJson<DraftListResponseDraft>
{
    /// <inheritdoc/>
    public DraftListResponseDraft FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DraftListResponseDraft.FromRawUnchecked(rawData);
}
