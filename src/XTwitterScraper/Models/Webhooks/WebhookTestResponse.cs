using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookTestResponse, WebhookTestResponseFromRaw>))]
public sealed record class WebhookTestResponse : JsonModel
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

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StatusCode;
        _ = this.Success;
        _ = this.Error;
    }

    public WebhookTestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookTestResponse(WebhookTestResponse webhookTestResponse)
        : base(webhookTestResponse) { }
#pragma warning restore CS8618

    public WebhookTestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookTestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookTestResponseFromRaw.FromRawUnchecked"/>
    public static WebhookTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookTestResponseFromRaw : IFromRawJson<WebhookTestResponse>
{
    /// <inheritdoc/>
    public WebhookTestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookTestResponse.FromRawUnchecked(rawData);
}
