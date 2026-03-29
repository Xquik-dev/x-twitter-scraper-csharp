using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X;

[JsonConverter(
    typeof(JsonModelConverter<XGetNotificationsResponse, XGetNotificationsResponseFromRaw>)
)]
public sealed record class XGetNotificationsResponse : JsonModel
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

    public required IReadOnlyList<Notification> Notifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Notification>>("notifications");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Notification>>(
                "notifications",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        foreach (var item in this.Notifications)
        {
            item.Validate();
        }
    }

    public XGetNotificationsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetNotificationsResponse(XGetNotificationsResponse xGetNotificationsResponse)
        : base(xGetNotificationsResponse) { }
#pragma warning restore CS8618

    public XGetNotificationsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetNotificationsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetNotificationsResponseFromRaw.FromRawUnchecked"/>
    public static XGetNotificationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetNotificationsResponseFromRaw : IFromRawJson<XGetNotificationsResponse>
{
    /// <inheritdoc/>
    public XGetNotificationsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetNotificationsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Notification, NotificationFromRaw>))]
public sealed record class Notification : JsonModel
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

    public string? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Message;
        _ = this.Timestamp;
        _ = this.Type;
    }

    public Notification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Notification(Notification notification)
        : base(notification) { }
#pragma warning restore CS8618

    public Notification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Notification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationFromRaw.FromRawUnchecked"/>
    public static Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Notification(string id)
        : this()
    {
        this.ID = id;
    }
}

class NotificationFromRaw : IFromRawJson<Notification>
{
    /// <inheritdoc/>
    public Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Notification.FromRawUnchecked(rawData);
}
