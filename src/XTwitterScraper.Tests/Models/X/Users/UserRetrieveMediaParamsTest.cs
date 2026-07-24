// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveMediaParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveMediaParams
        {
            ID = "id",
            AnyWords = "anyWords",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            MediaType = UserRetrieveMediaParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            PageSize = 1,
            Quotes = UserRetrieveMediaParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = UserRetrieveMediaParamsReplies.Include,
            Retweets = UserRetrieveMediaParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        string expectedID = "id";
        string expectedAnyWords = "anyWords";
        string expectedCashtags = "cashtags";
        string expectedConversationID = "conversationId";
        string expectedCursor = "cursor";
        string expectedExactPhrase = "exactPhrase";
        string expectedExcludeWords = "excludeWords";
        string expectedFromUser = "fromUser";
        string expectedHashtags = "hashtags";
        string expectedInReplyToTweetID = "inReplyToTweetId";
        string expectedLanguage = "language";
        ApiEnum<string, UserRetrieveMediaParamsMediaType> expectedMediaType =
            UserRetrieveMediaParamsMediaType.Images;
        string expectedMentioning = "mentioning";
        long expectedMinFaves = 0;
        long expectedMinQuotes = 0;
        long expectedMinReplies = 0;
        long expectedMinRetweets = 0;
        long expectedPageSize = 1;
        ApiEnum<string, UserRetrieveMediaParamsQuotes> expectedQuotes =
            UserRetrieveMediaParamsQuotes.Include;
        string expectedQuotesOfTweetID = "quotesOfTweetId";
        ApiEnum<string, UserRetrieveMediaParamsReplies> expectedReplies =
            UserRetrieveMediaParamsReplies.Include;
        ApiEnum<string, UserRetrieveMediaParamsRetweets> expectedRetweets =
            UserRetrieveMediaParamsRetweets.Include;
        string expectedRetweetsOfTweetID = "retweetsOfTweetId";
        string expectedSinceDate = "2019-12-27";
        string expectedToUser = "toUser";
        string expectedUntilDate = "2019-12-27";
        string expectedUrlValue = "url";
        bool expectedVerifiedOnly = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAnyWords, parameters.AnyWords);
        Assert.Equal(expectedCashtags, parameters.Cashtags);
        Assert.Equal(expectedConversationID, parameters.ConversationID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExactPhrase, parameters.ExactPhrase);
        Assert.Equal(expectedExcludeWords, parameters.ExcludeWords);
        Assert.Equal(expectedFromUser, parameters.FromUser);
        Assert.Equal(expectedHashtags, parameters.Hashtags);
        Assert.Equal(expectedInReplyToTweetID, parameters.InReplyToTweetID);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedMediaType, parameters.MediaType);
        Assert.Equal(expectedMentioning, parameters.Mentioning);
        Assert.Equal(expectedMinFaves, parameters.MinFaves);
        Assert.Equal(expectedMinQuotes, parameters.MinQuotes);
        Assert.Equal(expectedMinReplies, parameters.MinReplies);
        Assert.Equal(expectedMinRetweets, parameters.MinRetweets);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedQuotes, parameters.Quotes);
        Assert.Equal(expectedQuotesOfTweetID, parameters.QuotesOfTweetID);
        Assert.Equal(expectedReplies, parameters.Replies);
        Assert.Equal(expectedRetweets, parameters.Retweets);
        Assert.Equal(expectedRetweetsOfTweetID, parameters.RetweetsOfTweetID);
        Assert.Equal(expectedSinceDate, parameters.SinceDate);
        Assert.Equal(expectedToUser, parameters.ToUser);
        Assert.Equal(expectedUntilDate, parameters.UntilDate);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedVerifiedOnly, parameters.VerifiedOnly);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveMediaParams { ID = "id" };

        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawQueryData.ContainsKey("anyWords"));
        Assert.Null(parameters.Cashtags);
        Assert.False(parameters.RawQueryData.ContainsKey("cashtags"));
        Assert.Null(parameters.ConversationID);
        Assert.False(parameters.RawQueryData.ContainsKey("conversationId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawQueryData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawQueryData.ContainsKey("excludeWords"));
        Assert.Null(parameters.FromUser);
        Assert.False(parameters.RawQueryData.ContainsKey("fromUser"));
        Assert.Null(parameters.Hashtags);
        Assert.False(parameters.RawQueryData.ContainsKey("hashtags"));
        Assert.Null(parameters.InReplyToTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("inReplyToTweetId"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawQueryData.ContainsKey("language"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawQueryData.ContainsKey("mediaType"));
        Assert.Null(parameters.Mentioning);
        Assert.False(parameters.RawQueryData.ContainsKey("mentioning"));
        Assert.Null(parameters.MinFaves);
        Assert.False(parameters.RawQueryData.ContainsKey("minFaves"));
        Assert.Null(parameters.MinQuotes);
        Assert.False(parameters.RawQueryData.ContainsKey("minQuotes"));
        Assert.Null(parameters.MinReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("minReplies"));
        Assert.Null(parameters.MinRetweets);
        Assert.False(parameters.RawQueryData.ContainsKey("minRetweets"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
        Assert.Null(parameters.Quotes);
        Assert.False(parameters.RawQueryData.ContainsKey("quotes"));
        Assert.Null(parameters.QuotesOfTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("quotesOfTweetId"));
        Assert.Null(parameters.Replies);
        Assert.False(parameters.RawQueryData.ContainsKey("replies"));
        Assert.Null(parameters.Retweets);
        Assert.False(parameters.RawQueryData.ContainsKey("retweets"));
        Assert.Null(parameters.RetweetsOfTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("retweetsOfTweetId"));
        Assert.Null(parameters.SinceDate);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceDate"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawQueryData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawQueryData.ContainsKey("untilDate"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawQueryData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveMediaParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            AnyWords = null,
            Cashtags = null,
            ConversationID = null,
            Cursor = null,
            ExactPhrase = null,
            ExcludeWords = null,
            FromUser = null,
            Hashtags = null,
            InReplyToTweetID = null,
            Language = null,
            MediaType = null,
            Mentioning = null,
            MinFaves = null,
            MinQuotes = null,
            MinReplies = null,
            MinRetweets = null,
            PageSize = null,
            Quotes = null,
            QuotesOfTweetID = null,
            Replies = null,
            Retweets = null,
            RetweetsOfTweetID = null,
            SinceDate = null,
            ToUser = null,
            UntilDate = null,
            UrlValue = null,
            VerifiedOnly = null,
        };

        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawQueryData.ContainsKey("anyWords"));
        Assert.Null(parameters.Cashtags);
        Assert.False(parameters.RawQueryData.ContainsKey("cashtags"));
        Assert.Null(parameters.ConversationID);
        Assert.False(parameters.RawQueryData.ContainsKey("conversationId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawQueryData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawQueryData.ContainsKey("excludeWords"));
        Assert.Null(parameters.FromUser);
        Assert.False(parameters.RawQueryData.ContainsKey("fromUser"));
        Assert.Null(parameters.Hashtags);
        Assert.False(parameters.RawQueryData.ContainsKey("hashtags"));
        Assert.Null(parameters.InReplyToTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("inReplyToTweetId"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawQueryData.ContainsKey("language"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawQueryData.ContainsKey("mediaType"));
        Assert.Null(parameters.Mentioning);
        Assert.False(parameters.RawQueryData.ContainsKey("mentioning"));
        Assert.Null(parameters.MinFaves);
        Assert.False(parameters.RawQueryData.ContainsKey("minFaves"));
        Assert.Null(parameters.MinQuotes);
        Assert.False(parameters.RawQueryData.ContainsKey("minQuotes"));
        Assert.Null(parameters.MinReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("minReplies"));
        Assert.Null(parameters.MinRetweets);
        Assert.False(parameters.RawQueryData.ContainsKey("minRetweets"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
        Assert.Null(parameters.Quotes);
        Assert.False(parameters.RawQueryData.ContainsKey("quotes"));
        Assert.Null(parameters.QuotesOfTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("quotesOfTweetId"));
        Assert.Null(parameters.Replies);
        Assert.False(parameters.RawQueryData.ContainsKey("replies"));
        Assert.Null(parameters.Retweets);
        Assert.False(parameters.RawQueryData.ContainsKey("retweets"));
        Assert.Null(parameters.RetweetsOfTweetID);
        Assert.False(parameters.RawQueryData.ContainsKey("retweetsOfTweetId"));
        Assert.Null(parameters.SinceDate);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceDate"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawQueryData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawQueryData.ContainsKey("untilDate"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawQueryData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveMediaParams parameters = new()
        {
            ID = "id",
            AnyWords = "anyWords",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            MediaType = UserRetrieveMediaParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            PageSize = 1,
            Quotes = UserRetrieveMediaParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = UserRetrieveMediaParamsReplies.Include,
            Retweets = UserRetrieveMediaParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/users/id/media?anyWords=anyWords&cashtags=cashtags&conversationId=conversationId&cursor=cursor&exactPhrase=exactPhrase&excludeWords=excludeWords&fromUser=fromUser&hashtags=hashtags&inReplyToTweetId=inReplyToTweetId&language=language&mediaType=images&mentioning=mentioning&minFaves=0&minQuotes=0&minReplies=0&minRetweets=0&pageSize=1&quotes=include&quotesOfTweetId=quotesOfTweetId&replies=include&retweets=include&retweetsOfTweetId=retweetsOfTweetId&sinceDate=2019-12-27&toUser=toUser&untilDate=2019-12-27&url=url&verifiedOnly=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveMediaParams
        {
            ID = "id",
            AnyWords = "anyWords",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            MediaType = UserRetrieveMediaParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            PageSize = 1,
            Quotes = UserRetrieveMediaParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = UserRetrieveMediaParamsReplies.Include,
            Retweets = UserRetrieveMediaParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        UserRetrieveMediaParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UserRetrieveMediaParamsMediaTypeTest : TestBase
{
    [Theory]
    [InlineData(UserRetrieveMediaParamsMediaType.Images)]
    [InlineData(UserRetrieveMediaParamsMediaType.Videos)]
    [InlineData(UserRetrieveMediaParamsMediaType.Gifs)]
    [InlineData(UserRetrieveMediaParamsMediaType.Media)]
    [InlineData(UserRetrieveMediaParamsMediaType.Links)]
    [InlineData(UserRetrieveMediaParamsMediaType.None)]
    public void Validation_Works(UserRetrieveMediaParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsMediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserRetrieveMediaParamsMediaType.Images)]
    [InlineData(UserRetrieveMediaParamsMediaType.Videos)]
    [InlineData(UserRetrieveMediaParamsMediaType.Gifs)]
    [InlineData(UserRetrieveMediaParamsMediaType.Media)]
    [InlineData(UserRetrieveMediaParamsMediaType.Links)]
    [InlineData(UserRetrieveMediaParamsMediaType.None)]
    public void SerializationRoundtrip_Works(UserRetrieveMediaParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsMediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsMediaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsMediaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserRetrieveMediaParamsQuotesTest : TestBase
{
    [Theory]
    [InlineData(UserRetrieveMediaParamsQuotes.Include)]
    [InlineData(UserRetrieveMediaParamsQuotes.Exclude)]
    [InlineData(UserRetrieveMediaParamsQuotes.Only)]
    public void Validation_Works(UserRetrieveMediaParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsQuotes> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserRetrieveMediaParamsQuotes.Include)]
    [InlineData(UserRetrieveMediaParamsQuotes.Exclude)]
    [InlineData(UserRetrieveMediaParamsQuotes.Only)]
    public void SerializationRoundtrip_Works(UserRetrieveMediaParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsQuotes> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsQuotes>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsQuotes>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserRetrieveMediaParamsRepliesTest : TestBase
{
    [Theory]
    [InlineData(UserRetrieveMediaParamsReplies.Include)]
    [InlineData(UserRetrieveMediaParamsReplies.Exclude)]
    [InlineData(UserRetrieveMediaParamsReplies.Only)]
    public void Validation_Works(UserRetrieveMediaParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsReplies> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserRetrieveMediaParamsReplies.Include)]
    [InlineData(UserRetrieveMediaParamsReplies.Exclude)]
    [InlineData(UserRetrieveMediaParamsReplies.Only)]
    public void SerializationRoundtrip_Works(UserRetrieveMediaParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsReplies> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsReplies>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsReplies>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserRetrieveMediaParamsRetweetsTest : TestBase
{
    [Theory]
    [InlineData(UserRetrieveMediaParamsRetweets.Include)]
    [InlineData(UserRetrieveMediaParamsRetweets.Exclude)]
    [InlineData(UserRetrieveMediaParamsRetweets.Only)]
    public void Validation_Works(UserRetrieveMediaParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsRetweets> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserRetrieveMediaParamsRetweets.Include)]
    [InlineData(UserRetrieveMediaParamsRetweets.Exclude)]
    [InlineData(UserRetrieveMediaParamsRetweets.Only)]
    public void SerializationRoundtrip_Works(UserRetrieveMediaParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRetrieveMediaParamsRetweets> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsRetweets>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRetrieveMediaParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UserRetrieveMediaParamsRetweets>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
