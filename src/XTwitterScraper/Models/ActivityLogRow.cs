// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<ActivityLogRow, ActivityLogRowFromRaw>))]
public sealed record class ActivityLogRow : JsonModel
{
    /// <summary>
    /// ISO 8601 time in UTC to the millisecond. Empty on the notice row.
    /// </summary>
    public required string Time
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("time");
        }
        init { this._rawData.Set("time", value); }
    }

    public required string Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Activity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("activity");
        }
        init { this._rawData.Set("activity", value); }
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

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    public required JsonElement Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("results");
        }
        init { this._rawData.Set("results", value); }
    }

    public required JsonElement Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    public required string Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("details");
        }
        init { this._rawData.Set("details", value); }
    }

    /// <summary>
    /// Activity ID. GET /activity/{id} returns its full record.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Link
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("link");
        }
        init { this._rawData.Set("link", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Time;
        _ = this.Category;
        _ = this.Type;
        _ = this.Activity;
        _ = this.Status;
        _ = this.Source;
        _ = this.Target;
        _ = this.Results;
        _ = this.Credits;
        _ = this.Details;
        _ = this.ID;
        _ = this.Link;
    }

    public ActivityLogRow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityLogRow(ActivityLogRow activityLogRow)
        : base(activityLogRow) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityLogRow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityLogRow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityLogRowFromRaw.FromRawUnchecked"/>
    public static ActivityLogRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityLogRowFromRaw : IFromRawJson<ActivityLogRow>
{
    /// <inheritdoc/>
    public ActivityLogRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ActivityLogRow.FromRawUnchecked(rawData);
}
