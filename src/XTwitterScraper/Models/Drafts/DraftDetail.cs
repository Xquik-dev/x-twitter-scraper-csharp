using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Drafts;

[JsonConverter(typeof(JsonModelConverter<DraftDetail, DraftDetailFromRaw>))]
public sealed record class DraftDetail : JsonModel
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

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
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
        _ = this.UpdatedAt;
        _ = this.Goal;
        _ = this.Topic;
    }

    public DraftDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftDetail(DraftDetail draftDetail)
        : base(draftDetail) { }
#pragma warning restore CS8618

    public DraftDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftDetailFromRaw.FromRawUnchecked"/>
    public static DraftDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DraftDetailFromRaw : IFromRawJson<DraftDetail>
{
    /// <inheritdoc/>
    public DraftDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DraftDetail.FromRawUnchecked(rawData);
}
