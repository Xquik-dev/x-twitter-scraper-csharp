// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookListResponse, WebhookListResponseFromRaw>))]
public sealed record class WebhookListResponse : JsonModel
{
    public required IReadOnlyList<Webhook> Webhooks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Webhook>>("webhooks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Webhook>>(
                "webhooks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasMore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasMore", value);
        }
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
        foreach (var item in this.Webhooks)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public WebhookListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListResponse(WebhookListResponse webhookListResponse)
        : base(webhookListResponse) { }
#pragma warning restore CS8618

    public WebhookListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookListResponse(IReadOnlyList<Webhook> webhooks)
        : this()
    {
        this.Webhooks = webhooks;
    }
}

class WebhookListResponseFromRaw : IFromRawJson<WebhookListResponse>
{
    /// <inheritdoc/>
    public WebhookListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookListResponse.FromRawUnchecked(rawData);
}
