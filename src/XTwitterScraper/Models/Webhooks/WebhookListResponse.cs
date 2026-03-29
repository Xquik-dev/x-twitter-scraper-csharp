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

[JsonConverter(typeof(JsonModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, WebhookEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, WebhookEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookEventType>>>(
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

    public Webhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Webhook(Webhook webhook)
        : base(webhook) { }
#pragma warning restore CS8618

    public Webhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookFromRaw.FromRawUnchecked"/>
    public static Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookFromRaw : IFromRawJson<Webhook>
{
    /// <inheritdoc/>
    public Webhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Webhook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookEventTypeConverter))]
public enum WebhookEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class WebhookEventTypeConverter : JsonConverter<WebhookEventType>
{
    public override WebhookEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => WebhookEventType.TweetNew,
            "tweet.reply" => WebhookEventType.TweetReply,
            "tweet.retweet" => WebhookEventType.TweetRetweet,
            "tweet.quote" => WebhookEventType.TweetQuote,
            "follower.gained" => WebhookEventType.FollowerGained,
            "follower.lost" => WebhookEventType.FollowerLost,
            _ => (WebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEventType.TweetNew => "tweet.new",
                WebhookEventType.TweetReply => "tweet.reply",
                WebhookEventType.TweetRetweet => "tweet.retweet",
                WebhookEventType.TweetQuote => "tweet.quote",
                WebhookEventType.FollowerGained => "follower.gained",
                WebhookEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
