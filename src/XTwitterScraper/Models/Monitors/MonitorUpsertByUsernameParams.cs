// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Monitors;

/// <summary>
/// Creates the monitor if it does not exist, or updates it if it does. Send the same call twice &amp; you still have 1 monitor. A new monitor answers 201 &amp; an update answers 200. Both carry `created`, so you know which one ran. Creating needs the credits of the first hour, then costs 30 credits an hour. A stopped monitor turns back on &amp; counts as created. Updating is free &amp; replaces the event types. It changes the name only when you send one.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class MonitorUpsertByUsernameParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? Username { get; init; }

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, global::XTwitterScraper.Models.EventType>
    > EventTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, global::XTwitterScraper.Models.EventType>>
            >("eventTypes");
        }
        init
        {
            this._rawBodyData.Set<
                ImmutableArray<ApiEnum<string, global::XTwitterScraper.Models.EventType>>
            >("eventTypes", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Your label for the monitor. Its events carry it as monitorName. Leave it out to keep the current label, or send null to remove it.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public MonitorUpsertByUsernameParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorUpsertByUsernameParams(
        MonitorUpsertByUsernameParams monitorUpsertByUsernameParams
    )
        : base(monitorUpsertByUsernameParams)
    {
        this.Username = monitorUpsertByUsernameParams.Username;
        this._rawBodyData = new(monitorUpsertByUsernameParams._rawBodyData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorUpsertByUsernameParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorUpsertByUsernameParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string username
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Username = username;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MonitorUpsertByUsernameParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string username
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            username
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Username"] = JsonSerializer.SerializeToElement(this.Username),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MonitorUpsertByUsernameParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Username?.Equals(other.Username) ?? other.Username == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/monitors/username/{0}", this.Username)
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
