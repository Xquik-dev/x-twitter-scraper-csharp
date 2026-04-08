using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Events;

/// <summary>
/// Full monitor event including payload data and optional X event ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventDetail, EventDetailFromRaw>))]
public sealed record class EventDetail : JsonModel
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

    /// <summary>
    /// Event payload — shape varies by event type (JSON)
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "data",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string MonitorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("monitorId");
        }
        init { this._rawData.Set("monitorId", value); }
    }

    public required DateTimeOffset OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("occurredAt");
        }
        init { this._rawData.Set("occurredAt", value); }
    }

    /// <summary>
    /// Type of monitor event fired when account activity occurs.
    /// </summary>
    public required ApiEnum<string, EventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public string? XEventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xEventId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("xEventId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Data;
        _ = this.MonitorID;
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.Username;
        _ = this.XEventID;
    }

    public EventDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventDetail(EventDetail eventDetail)
        : base(eventDetail) { }
#pragma warning restore CS8618

    public EventDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventDetailFromRaw.FromRawUnchecked"/>
    public static EventDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventDetailFromRaw : IFromRawJson<EventDetail>
{
    /// <inheritdoc/>
    public EventDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventDetail.FromRawUnchecked(rawData);
}
