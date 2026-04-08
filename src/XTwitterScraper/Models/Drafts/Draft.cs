using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Drafts;

/// <summary>
/// Saved tweet draft with optional topic and goal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Draft, DraftFromRaw>))]
public sealed record class Draft : JsonModel
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

    public Draft() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Draft(Draft draft)
        : base(draft) { }
#pragma warning restore CS8618

    public Draft(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Draft(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftFromRaw.FromRawUnchecked"/>
    public static Draft FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DraftFromRaw : IFromRawJson<Draft>
{
    /// <inheritdoc/>
    public Draft FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Draft.FromRawUnchecked(rawData);
}
