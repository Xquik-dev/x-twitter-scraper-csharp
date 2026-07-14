using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models;

/// <summary>
/// Type of monitor event fired when account activity occurs.
/// </summary>
[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    TweetMedia,
    TweetLink,
    TweetPoll,
    TweetMention,
    TweetHashtag,
    TweetLongform,
    ProfileAvatarChanged,
    ProfileBannerChanged,
    ProfileNameChanged,
    ProfileUsernameChanged,
    ProfileBioChanged,
    ProfileLocationChanged,
    ProfileUrlChanged,
    ProfileVerifiedChanged,
    ProfileProtectedChanged,
    ProfilePinnedTweetChanged,
    ProfileUnavailableChanged,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => EventType.TweetNew,
            "tweet.reply" => EventType.TweetReply,
            "tweet.retweet" => EventType.TweetRetweet,
            "tweet.quote" => EventType.TweetQuote,
            "tweet.media" => EventType.TweetMedia,
            "tweet.link" => EventType.TweetLink,
            "tweet.poll" => EventType.TweetPoll,
            "tweet.mention" => EventType.TweetMention,
            "tweet.hashtag" => EventType.TweetHashtag,
            "tweet.longform" => EventType.TweetLongform,
            "profile.avatar.changed" => EventType.ProfileAvatarChanged,
            "profile.banner.changed" => EventType.ProfileBannerChanged,
            "profile.name.changed" => EventType.ProfileNameChanged,
            "profile.username.changed" => EventType.ProfileUsernameChanged,
            "profile.bio.changed" => EventType.ProfileBioChanged,
            "profile.location.changed" => EventType.ProfileLocationChanged,
            "profile.url.changed" => EventType.ProfileUrlChanged,
            "profile.verified.changed" => EventType.ProfileVerifiedChanged,
            "profile.protected.changed" => EventType.ProfileProtectedChanged,
            "profile.pinned_tweet.changed" => EventType.ProfilePinnedTweetChanged,
            "profile.unavailable.changed" => EventType.ProfileUnavailableChanged,
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
                EventType.TweetMedia => "tweet.media",
                EventType.TweetLink => "tweet.link",
                EventType.TweetPoll => "tweet.poll",
                EventType.TweetMention => "tweet.mention",
                EventType.TweetHashtag => "tweet.hashtag",
                EventType.TweetLongform => "tweet.longform",
                EventType.ProfileAvatarChanged => "profile.avatar.changed",
                EventType.ProfileBannerChanged => "profile.banner.changed",
                EventType.ProfileNameChanged => "profile.name.changed",
                EventType.ProfileUsernameChanged => "profile.username.changed",
                EventType.ProfileBioChanged => "profile.bio.changed",
                EventType.ProfileLocationChanged => "profile.location.changed",
                EventType.ProfileUrlChanged => "profile.url.changed",
                EventType.ProfileVerifiedChanged => "profile.verified.changed",
                EventType.ProfileProtectedChanged => "profile.protected.changed",
                EventType.ProfilePinnedTweetChanged => "profile.pinned_tweet.changed",
                EventType.ProfileUnavailableChanged => "profile.unavailable.changed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
