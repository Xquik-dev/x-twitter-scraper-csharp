using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WebhookListResponse, WebhookListResponseFromRaw>))]
public sealed record class WebhookListResponse : JsonModel
{
    public required IReadOnlyList<WebhookListResponseWebhook> Webhooks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebhookListResponseWebhook>>(
                "webhooks"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookListResponseWebhook>>(
                "webhooks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Webhooks)
        {
            item.Validate();
        }
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
    public WebhookListResponse(IReadOnlyList<WebhookListResponseWebhook> webhooks)
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

[JsonConverter(
    typeof(JsonModelConverter<WebhookListResponseWebhook, WebhookListResponseWebhookFromRaw>)
)]
public sealed record class WebhookListResponseWebhook : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required IReadOnlyList<ApiEnum<string, WebhookListResponseWebhookEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, WebhookListResponseWebhookEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookListResponseWebhookEventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.IsActive;
        _ = this.Url;
    }

    public WebhookListResponseWebhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListResponseWebhook(WebhookListResponseWebhook webhookListResponseWebhook)
        : base(webhookListResponseWebhook) { }
#pragma warning restore CS8618

    public WebhookListResponseWebhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListResponseWebhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListResponseWebhookFromRaw.FromRawUnchecked"/>
    public static WebhookListResponseWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListResponseWebhookFromRaw : IFromRawJson<WebhookListResponseWebhook>
{
    /// <inheritdoc/>
    public WebhookListResponseWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListResponseWebhook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookListResponseWebhookEventTypeConverter))]
public enum WebhookListResponseWebhookEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class WebhookListResponseWebhookEventTypeConverter
    : JsonConverter<WebhookListResponseWebhookEventType>
{
    public override WebhookListResponseWebhookEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => WebhookListResponseWebhookEventType.TweetNew,
            "tweet.reply" => WebhookListResponseWebhookEventType.TweetReply,
            "tweet.retweet" => WebhookListResponseWebhookEventType.TweetRetweet,
            "tweet.quote" => WebhookListResponseWebhookEventType.TweetQuote,
            "follower.gained" => WebhookListResponseWebhookEventType.FollowerGained,
            "follower.lost" => WebhookListResponseWebhookEventType.FollowerLost,
            _ => (WebhookListResponseWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookListResponseWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookListResponseWebhookEventType.TweetNew => "tweet.new",
                WebhookListResponseWebhookEventType.TweetReply => "tweet.reply",
                WebhookListResponseWebhookEventType.TweetRetweet => "tweet.retweet",
                WebhookListResponseWebhookEventType.TweetQuote => "tweet.quote",
                WebhookListResponseWebhookEventType.FollowerGained => "follower.gained",
                WebhookListResponseWebhookEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
