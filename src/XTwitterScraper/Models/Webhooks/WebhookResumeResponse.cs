using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookResumeResponse, WebhookResumeResponseFromRaw>))]
public sealed record class WebhookResumeResponse : JsonModel
{
    public required long StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("statusCode");
        }
        init { this._rawData.Set("statusCode", value); }
    }

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Webhook endpoint registered to receive event deliveries.
    /// </summary>
    public required Webhook Webhook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Webhook>("webhook");
        }
        init { this._rawData.Set("webhook", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StatusCode;
        _ = this.Success;
        this.Webhook.Validate();
    }

    public WebhookResumeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookResumeResponse(WebhookResumeResponse webhookResumeResponse)
        : base(webhookResumeResponse) { }
#pragma warning restore CS8618

    public WebhookResumeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookResumeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookResumeResponseFromRaw.FromRawUnchecked"/>
    public static WebhookResumeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookResumeResponseFromRaw : IFromRawJson<WebhookResumeResponse>
{
    /// <inheritdoc/>
    public WebhookResumeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookResumeResponse.FromRawUnchecked(rawData);
}
