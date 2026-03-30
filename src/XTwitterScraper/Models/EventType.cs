using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => EventType.TweetNew,
            "tweet.reply" => EventType.TweetReply,
            "tweet.retweet" => EventType.TweetRetweet,
            "tweet.quote" => EventType.TweetQuote,
            "follower.gained" => EventType.FollowerGained,
            "follower.lost" => EventType.FollowerLost,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.TweetNew => "tweet.new",
                EventType.TweetReply => "tweet.reply",
                EventType.TweetRetweet => "tweet.retweet",
                EventType.TweetQuote => "tweet.quote",
                EventType.FollowerGained => "follower.gained",
                EventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
