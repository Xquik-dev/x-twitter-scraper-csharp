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

[JsonConverter(typeof(JsonModelConverter<WebhookCreateResponse, WebhookCreateResponseFromRaw>))]
public sealed record class WebhookCreateResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, WebhookCreateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, WebhookCreateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookCreateResponseEventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
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
        _ = this.Secret;
        _ = this.Url;
    }

    public WebhookCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateResponse(WebhookCreateResponse webhookCreateResponse)
        : base(webhookCreateResponse) { }
#pragma warning restore CS8618

    public WebhookCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookCreateResponseFromRaw.FromRawUnchecked"/>
    public static WebhookCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookCreateResponseFromRaw : IFromRawJson<WebhookCreateResponse>
{
    /// <inheritdoc/>
    public WebhookCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookCreateResponseEventTypeConverter))]
public enum WebhookCreateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class WebhookCreateResponseEventTypeConverter : JsonConverter<WebhookCreateResponseEventType>
{
    public override WebhookCreateResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => WebhookCreateResponseEventType.TweetNew,
            "tweet.reply" => WebhookCreateResponseEventType.TweetReply,
            "tweet.retweet" => WebhookCreateResponseEventType.TweetRetweet,
            "tweet.quote" => WebhookCreateResponseEventType.TweetQuote,
            "follower.gained" => WebhookCreateResponseEventType.FollowerGained,
            "follower.lost" => WebhookCreateResponseEventType.FollowerLost,
            _ => (WebhookCreateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookCreateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookCreateResponseEventType.TweetNew => "tweet.new",
                WebhookCreateResponseEventType.TweetReply => "tweet.reply",
                WebhookCreateResponseEventType.TweetRetweet => "tweet.retweet",
                WebhookCreateResponseEventType.TweetQuote => "tweet.quote",
                WebhookCreateResponseEventType.FollowerGained => "follower.gained",
                WebhookCreateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
