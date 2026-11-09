// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Events;

/// <summary>
/// Streams the account's monitor events as server-sent events, each named by its event type and numbered by its event ID. A reconnect that sends Last-Event-ID first gets every event after that one from the last 30 days, then each new event. Set lookBack to also get events saved late. A connection lasts up to 30 minutes and sends a comment every 15 seconds while idle. Keep up to 200 streams open per account. Events and streams cost no credits. Add include=post_metrics to also get post.metrics frames. The first poll sends 1 for each post monitor with a check or a pause. After that, a frame comes when a monitor's saved numbers or status change. These frames carry no ID, so Last-Event-ID never moves.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class EventStreamParams : ParamsBase
{
    /// <summary>
    /// Set to post_metrics to also get each post monitor's saved numbers. Any other value is refused.
    /// </summary>
    public ApiEnum<string, EventStreamParamsInclude>? Include
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, EventStreamParamsInclude>>(
                "include"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include", value);
        }
    }

    /// <summary>
    /// Set to true to resume 30 seconds before Last-Event-ID. Events saved late then still arrive. Events you have can arrive again, so skip IDs you've seen. An ID the stream can't find starts 5 minutes back, not 30 days.
    /// </summary>
    public bool? LookBack
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("lookBack");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("lookBack", value);
        }
    }

    public EventStreamParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventStreamParams(EventStreamParams eventStreamParams)
        : base(eventStreamParams) { }
#pragma warning restore CS8618

    public EventStreamParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventStreamParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EventStreamParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EventStreamParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/events/stream")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
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

[JsonConverter(typeof(EventStreamParamsIncludeConverter))]
public enum EventStreamParamsInclude
{
    PostMetrics,
}

sealed class EventStreamParamsIncludeConverter : JsonConverter<EventStreamParamsInclude>
{
    public override EventStreamParamsInclude Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "post_metrics" => EventStreamParamsInclude.PostMetrics,
            _ => (EventStreamParamsInclude)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventStreamParamsInclude value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventStreamParamsInclude.PostMetrics => "post_metrics",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
