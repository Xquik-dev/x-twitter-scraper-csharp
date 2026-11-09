// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        WebhookCreateTelegramLinkResponse,
        WebhookCreateTelegramLinkResponseFromRaw
    >)
)]
public sealed record class WebhookCreateTelegramLinkResponse : JsonModel
{
    /// <summary>
    /// Opens @XquikBot with the link's code.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// When the link stops working, 15 minutes after creation.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.ExpiresAt;
    }

    public WebhookCreateTelegramLinkResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateTelegramLinkResponse(
        WebhookCreateTelegramLinkResponse webhookCreateTelegramLinkResponse
    )
        : base(webhookCreateTelegramLinkResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateTelegramLinkResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookCreateTelegramLinkResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookCreateTelegramLinkResponseFromRaw.FromRawUnchecked"/>
    public static WebhookCreateTelegramLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookCreateTelegramLinkResponseFromRaw : IFromRawJson<WebhookCreateTelegramLinkResponse>
{
    /// <inheritdoc/>
    public WebhookCreateTelegramLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookCreateTelegramLinkResponse.FromRawUnchecked(rawData);
}
