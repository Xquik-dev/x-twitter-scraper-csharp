using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<WebhookDeactivateResponse, WebhookDeactivateResponseFromRaw>)
)]
public sealed record class WebhookDeactivateResponse : JsonModel
{
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public WebhookDeactivateResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDeactivateResponse(WebhookDeactivateResponse webhookDeactivateResponse)
        : base(webhookDeactivateResponse) { }
#pragma warning restore CS8618

    public WebhookDeactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDeactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static WebhookDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookDeactivateResponseFromRaw : IFromRawJson<WebhookDeactivateResponse>
{
    /// <inheritdoc/>
    public WebhookDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookDeactivateResponse.FromRawUnchecked(rawData);
}
