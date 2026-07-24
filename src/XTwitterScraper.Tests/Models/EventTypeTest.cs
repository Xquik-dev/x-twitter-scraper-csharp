// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.TweetNew)]
    [InlineData(EventType.TweetReply)]
    [InlineData(EventType.TweetRetweet)]
    [InlineData(EventType.TweetQuote)]
    [InlineData(EventType.TweetMedia)]
    [InlineData(EventType.TweetLink)]
    [InlineData(EventType.TweetPoll)]
    [InlineData(EventType.TweetMention)]
    [InlineData(EventType.TweetHashtag)]
    [InlineData(EventType.TweetLongform)]
    [InlineData(EventType.ProfileAvatarChanged)]
    [InlineData(EventType.ProfileBannerChanged)]
    [InlineData(EventType.ProfileNameChanged)]
    [InlineData(EventType.ProfileUsernameChanged)]
    [InlineData(EventType.ProfileBioChanged)]
    [InlineData(EventType.ProfileLocationChanged)]
    [InlineData(EventType.ProfileUrlChanged)]
    [InlineData(EventType.ProfileVerifiedChanged)]
    [InlineData(EventType.ProfileProtectedChanged)]
    [InlineData(EventType.ProfilePinnedTweetChanged)]
    [InlineData(EventType.ProfileUnavailableChanged)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.TweetNew)]
    [InlineData(EventType.TweetReply)]
    [InlineData(EventType.TweetRetweet)]
    [InlineData(EventType.TweetQuote)]
    [InlineData(EventType.TweetMedia)]
    [InlineData(EventType.TweetLink)]
    [InlineData(EventType.TweetPoll)]
    [InlineData(EventType.TweetMention)]
    [InlineData(EventType.TweetHashtag)]
    [InlineData(EventType.TweetLongform)]
    [InlineData(EventType.ProfileAvatarChanged)]
    [InlineData(EventType.ProfileBannerChanged)]
    [InlineData(EventType.ProfileNameChanged)]
    [InlineData(EventType.ProfileUsernameChanged)]
    [InlineData(EventType.ProfileBioChanged)]
    [InlineData(EventType.ProfileLocationChanged)]
    [InlineData(EventType.ProfileUrlChanged)]
    [InlineData(EventType.ProfileVerifiedChanged)]
    [InlineData(EventType.ProfileProtectedChanged)]
    [InlineData(EventType.ProfilePinnedTweetChanged)]
    [InlineData(EventType.ProfileUnavailableChanged)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
