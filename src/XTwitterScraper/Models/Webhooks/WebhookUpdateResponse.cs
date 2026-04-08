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

/// <summary>
/// Webhook endpoint registered to receive event deliveries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookUpdateResponse, WebhookUpdateResponseFromRaw>))]
public sealed record class WebhookUpdateResponse : JsonModel
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

    /// <summary>
    /// Array of event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, WebhookUpdateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, WebhookUpdateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookUpdateResponseEventType>>>(
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

    public WebhookUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookUpdateResponse(WebhookUpdateResponse webhookUpdateResponse)
        : base(webhookUpdateResponse) { }
#pragma warning restore CS8618

    public WebhookUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WebhookUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookUpdateResponseFromRaw : IFromRawJson<WebhookUpdateResponse>
{
    /// <inheritdoc/>
    public WebhookUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of monitor event fired when account activity occurs.
/// </summary>
[JsonConverter(typeof(WebhookUpdateResponseEventTypeConverter))]
public enum WebhookUpdateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class WebhookUpdateResponseEventTypeConverter : JsonConverter<WebhookUpdateResponseEventType>
{
    public override WebhookUpdateResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => WebhookUpdateResponseEventType.TweetNew,
            "tweet.reply" => WebhookUpdateResponseEventType.TweetReply,
            "tweet.retweet" => WebhookUpdateResponseEventType.TweetRetweet,
            "tweet.quote" => WebhookUpdateResponseEventType.TweetQuote,
            "follower.gained" => WebhookUpdateResponseEventType.FollowerGained,
            "follower.lost" => WebhookUpdateResponseEventType.FollowerLost,
            _ => (WebhookUpdateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookUpdateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookUpdateResponseEventType.TweetNew => "tweet.new",
                WebhookUpdateResponseEventType.TweetReply => "tweet.reply",
                WebhookUpdateResponseEventType.TweetRetweet => "tweet.retweet",
                WebhookUpdateResponseEventType.TweetQuote => "tweet.quote",
                WebhookUpdateResponseEventType.FollowerGained => "follower.gained",
                WebhookUpdateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
