using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionRunParams
        {
            ToolType = ExtractionRunParamsToolType.FollowerExplorer,
            AdvancedQuery = "min_faves:100",
            AnyWords = "ChatGPT AI model",
            BoundingBox = "-74.1 40.6 -73.9 40.8",
            Cashtags = "$TSLA $NVDA",
            ConversationID = "1234567890",
            ExactPhrase = "artificial intelligence",
            ExcludeWords = "spam",
            FromUser = "nasa",
            Hashtags = "#AI startups",
            InReplyToTweetID = "1234567890",
            Language = "en",
            ListID = "1234567890",
            MediaType = ExtractionRunParamsMediaType.Images,
            Mentioning = "example_user",
            MinFaves = 10,
            MinQuotes = 2,
            MinReplies = 3,
            MinRetweets = 5,
            Place = "96683cc9126741d1",
            PlaceCountry = "US",
            PointRadius = "-73.99 40.73 25mi",
            Quotes = ExtractionRunParamsQuotes.Include,
            QuotesOfTweetID = "1234567890",
            Replies = ExtractionRunParamsReplies.Include,
            ResultsLimit = 1000,
            Retweets = ExtractionRunParamsRetweets.Exclude,
            RetweetsOfTweetID = "1234567890",
            SearchQuery = "AI trends 2025",
            SinceDate = "2025-01-01",
            TargetCommunityID = "1500000000000000000",
            TargetListID = "1234567890",
            TargetSpaceID = "1vOGwMdBqpwGB",
            TargetTweetID = "1234567890",
            TargetUsername = "elonmusk",
            ToUser = "openai",
            UntilDate = "2025-12-31",
            UrlValue = "example.com",
            VerifiedOnly = false,
        };

        ApiEnum<string, ExtractionRunParamsToolType> expectedToolType =
            ExtractionRunParamsToolType.FollowerExplorer;
        string expectedAdvancedQuery = "min_faves:100";
        string expectedAnyWords = "ChatGPT AI model";
        string expectedBoundingBox = "-74.1 40.6 -73.9 40.8";
        string expectedCashtags = "$TSLA $NVDA";
        string expectedConversationID = "1234567890";
        string expectedExactPhrase = "artificial intelligence";
        string expectedExcludeWords = "spam";
        string expectedFromUser = "nasa";
        string expectedHashtags = "#AI startups";
        string expectedInReplyToTweetID = "1234567890";
        string expectedLanguage = "en";
        string expectedListID = "1234567890";
        ApiEnum<string, ExtractionRunParamsMediaType> expectedMediaType =
            ExtractionRunParamsMediaType.Images;
        string expectedMentioning = "example_user";
        long expectedMinFaves = 10;
        long expectedMinQuotes = 2;
        long expectedMinReplies = 3;
        long expectedMinRetweets = 5;
        string expectedPlace = "96683cc9126741d1";
        string expectedPlaceCountry = "US";
        string expectedPointRadius = "-73.99 40.73 25mi";
        ApiEnum<string, ExtractionRunParamsQuotes> expectedQuotes =
            ExtractionRunParamsQuotes.Include;
        string expectedQuotesOfTweetID = "1234567890";
        ApiEnum<string, ExtractionRunParamsReplies> expectedReplies =
            ExtractionRunParamsReplies.Include;
        long expectedResultsLimit = 1000;
        ApiEnum<string, ExtractionRunParamsRetweets> expectedRetweets =
            ExtractionRunParamsRetweets.Exclude;
        string expectedRetweetsOfTweetID = "1234567890";
        string expectedSearchQuery = "AI trends 2025";
        string expectedSinceDate = "2025-01-01";
        string expectedTargetCommunityID = "1500000000000000000";
        string expectedTargetListID = "1234567890";
        string expectedTargetSpaceID = "1vOGwMdBqpwGB";
        string expectedTargetTweetID = "1234567890";
        string expectedTargetUsername = "elonmusk";
        string expectedToUser = "openai";
        string expectedUntilDate = "2025-12-31";
        string expectedUrlValue = "example.com";
        bool expectedVerifiedOnly = false;

        Assert.Equal(expectedToolType, parameters.ToolType);
        Assert.Equal(expectedAdvancedQuery, parameters.AdvancedQuery);
        Assert.Equal(expectedAnyWords, parameters.AnyWords);
        Assert.Equal(expectedBoundingBox, parameters.BoundingBox);
        Assert.Equal(expectedCashtags, parameters.Cashtags);
        Assert.Equal(expectedConversationID, parameters.ConversationID);
        Assert.Equal(expectedExactPhrase, parameters.ExactPhrase);
        Assert.Equal(expectedExcludeWords, parameters.ExcludeWords);
        Assert.Equal(expectedFromUser, parameters.FromUser);
        Assert.Equal(expectedHashtags, parameters.Hashtags);
        Assert.Equal(expectedInReplyToTweetID, parameters.InReplyToTweetID);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedMediaType, parameters.MediaType);
        Assert.Equal(expectedMentioning, parameters.Mentioning);
        Assert.Equal(expectedMinFaves, parameters.MinFaves);
        Assert.Equal(expectedMinQuotes, parameters.MinQuotes);
        Assert.Equal(expectedMinReplies, parameters.MinReplies);
        Assert.Equal(expectedMinRetweets, parameters.MinRetweets);
        Assert.Equal(expectedPlace, parameters.Place);
        Assert.Equal(expectedPlaceCountry, parameters.PlaceCountry);
        Assert.Equal(expectedPointRadius, parameters.PointRadius);
        Assert.Equal(expectedQuotes, parameters.Quotes);
        Assert.Equal(expectedQuotesOfTweetID, parameters.QuotesOfTweetID);
        Assert.Equal(expectedReplies, parameters.Replies);
        Assert.Equal(expectedResultsLimit, parameters.ResultsLimit);
        Assert.Equal(expectedRetweets, parameters.Retweets);
        Assert.Equal(expectedRetweetsOfTweetID, parameters.RetweetsOfTweetID);
        Assert.Equal(expectedSearchQuery, parameters.SearchQuery);
        Assert.Equal(expectedSinceDate, parameters.SinceDate);
        Assert.Equal(expectedTargetCommunityID, parameters.TargetCommunityID);
        Assert.Equal(expectedTargetListID, parameters.TargetListID);
        Assert.Equal(expectedTargetSpaceID, parameters.TargetSpaceID);
        Assert.Equal(expectedTargetTweetID, parameters.TargetTweetID);
        Assert.Equal(expectedTargetUsername, parameters.TargetUsername);
        Assert.Equal(expectedToUser, parameters.ToUser);
        Assert.Equal(expectedUntilDate, parameters.UntilDate);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedVerifiedOnly, parameters.VerifiedOnly);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionRunParams
        {
            ToolType = ExtractionRunParamsToolType.FollowerExplorer,
        };

        Assert.Null(parameters.AdvancedQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("advancedQuery"));
        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawBodyData.ContainsKey("anyWords"));
        Assert.Null(parameters.BoundingBox);
        Assert.False(parameters.RawBodyData.ContainsKey("boundingBox"));
        Assert.Null(parameters.Cashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("cashtags"));
        Assert.Null(parameters.ConversationID);
        Assert.False(parameters.RawBodyData.ContainsKey("conversationId"));
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawBodyData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeWords"));
        Assert.Null(parameters.FromUser);
        Assert.False(parameters.RawBodyData.ContainsKey("fromUser"));
        Assert.Null(parameters.Hashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("hashtags"));
        Assert.Null(parameters.InReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("inReplyToTweetId"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.ListID);
        Assert.False(parameters.RawBodyData.ContainsKey("listId"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawBodyData.ContainsKey("mediaType"));
        Assert.Null(parameters.Mentioning);
        Assert.False(parameters.RawBodyData.ContainsKey("mentioning"));
        Assert.Null(parameters.MinFaves);
        Assert.False(parameters.RawBodyData.ContainsKey("minFaves"));
        Assert.Null(parameters.MinQuotes);
        Assert.False(parameters.RawBodyData.ContainsKey("minQuotes"));
        Assert.Null(parameters.MinReplies);
        Assert.False(parameters.RawBodyData.ContainsKey("minReplies"));
        Assert.Null(parameters.MinRetweets);
        Assert.False(parameters.RawBodyData.ContainsKey("minRetweets"));
        Assert.Null(parameters.Place);
        Assert.False(parameters.RawBodyData.ContainsKey("place"));
        Assert.Null(parameters.PlaceCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("placeCountry"));
        Assert.Null(parameters.PointRadius);
        Assert.False(parameters.RawBodyData.ContainsKey("pointRadius"));
        Assert.Null(parameters.Quotes);
        Assert.False(parameters.RawBodyData.ContainsKey("quotes"));
        Assert.Null(parameters.QuotesOfTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("quotesOfTweetId"));
        Assert.Null(parameters.Replies);
        Assert.False(parameters.RawBodyData.ContainsKey("replies"));
        Assert.Null(parameters.ResultsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("resultsLimit"));
        Assert.Null(parameters.Retweets);
        Assert.False(parameters.RawBodyData.ContainsKey("retweets"));
        Assert.Null(parameters.RetweetsOfTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("retweetsOfTweetId"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("searchQuery"));
        Assert.Null(parameters.SinceDate);
        Assert.False(parameters.RawBodyData.ContainsKey("sinceDate"));
        Assert.Null(parameters.TargetCommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetCommunityId"));
        Assert.Null(parameters.TargetListID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetListId"));
        Assert.Null(parameters.TargetSpaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetSpaceId"));
        Assert.Null(parameters.TargetTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetTweetId"));
        Assert.Null(parameters.TargetUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("targetUsername"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawBodyData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("untilDate"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionRunParams
        {
            ToolType = ExtractionRunParamsToolType.FollowerExplorer,

            // Null should be interpreted as omitted for these properties
            AdvancedQuery = null,
            AnyWords = null,
            BoundingBox = null,
            Cashtags = null,
            ConversationID = null,
            ExactPhrase = null,
            ExcludeWords = null,
            FromUser = null,
            Hashtags = null,
            InReplyToTweetID = null,
            Language = null,
            ListID = null,
            MediaType = null,
            Mentioning = null,
            MinFaves = null,
            MinQuotes = null,
            MinReplies = null,
            MinRetweets = null,
            Place = null,
            PlaceCountry = null,
            PointRadius = null,
            Quotes = null,
            QuotesOfTweetID = null,
            Replies = null,
            ResultsLimit = null,
            Retweets = null,
            RetweetsOfTweetID = null,
            SearchQuery = null,
            SinceDate = null,
            TargetCommunityID = null,
            TargetListID = null,
            TargetSpaceID = null,
            TargetTweetID = null,
            TargetUsername = null,
            ToUser = null,
            UntilDate = null,
            UrlValue = null,
            VerifiedOnly = null,
        };

        Assert.Null(parameters.AdvancedQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("advancedQuery"));
        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawBodyData.ContainsKey("anyWords"));
        Assert.Null(parameters.BoundingBox);
        Assert.False(parameters.RawBodyData.ContainsKey("boundingBox"));
        Assert.Null(parameters.Cashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("cashtags"));
        Assert.Null(parameters.ConversationID);
        Assert.False(parameters.RawBodyData.ContainsKey("conversationId"));
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawBodyData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeWords"));
        Assert.Null(parameters.FromUser);
        Assert.False(parameters.RawBodyData.ContainsKey("fromUser"));
        Assert.Null(parameters.Hashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("hashtags"));
        Assert.Null(parameters.InReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("inReplyToTweetId"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.ListID);
        Assert.False(parameters.RawBodyData.ContainsKey("listId"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawBodyData.ContainsKey("mediaType"));
        Assert.Null(parameters.Mentioning);
        Assert.False(parameters.RawBodyData.ContainsKey("mentioning"));
        Assert.Null(parameters.MinFaves);
        Assert.False(parameters.RawBodyData.ContainsKey("minFaves"));
        Assert.Null(parameters.MinQuotes);
        Assert.False(parameters.RawBodyData.ContainsKey("minQuotes"));
        Assert.Null(parameters.MinReplies);
        Assert.False(parameters.RawBodyData.ContainsKey("minReplies"));
        Assert.Null(parameters.MinRetweets);
        Assert.False(parameters.RawBodyData.ContainsKey("minRetweets"));
        Assert.Null(parameters.Place);
        Assert.False(parameters.RawBodyData.ContainsKey("place"));
        Assert.Null(parameters.PlaceCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("placeCountry"));
        Assert.Null(parameters.PointRadius);
        Assert.False(parameters.RawBodyData.ContainsKey("pointRadius"));
        Assert.Null(parameters.Quotes);
        Assert.False(parameters.RawBodyData.ContainsKey("quotes"));
        Assert.Null(parameters.QuotesOfTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("quotesOfTweetId"));
        Assert.Null(parameters.Replies);
        Assert.False(parameters.RawBodyData.ContainsKey("replies"));
        Assert.Null(parameters.ResultsLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("resultsLimit"));
        Assert.Null(parameters.Retweets);
        Assert.False(parameters.RawBodyData.ContainsKey("retweets"));
        Assert.Null(parameters.RetweetsOfTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("retweetsOfTweetId"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("searchQuery"));
        Assert.Null(parameters.SinceDate);
        Assert.False(parameters.RawBodyData.ContainsKey("sinceDate"));
        Assert.Null(parameters.TargetCommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetCommunityId"));
        Assert.Null(parameters.TargetListID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetListId"));
        Assert.Null(parameters.TargetSpaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetSpaceId"));
        Assert.Null(parameters.TargetTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("targetTweetId"));
        Assert.Null(parameters.TargetUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("targetUsername"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawBodyData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("untilDate"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionRunParams parameters = new()
        {
            ToolType = ExtractionRunParamsToolType.FollowerExplorer,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/extractions"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionRunParams
        {
            ToolType = ExtractionRunParamsToolType.FollowerExplorer,
            AdvancedQuery = "min_faves:100",
            AnyWords = "ChatGPT AI model",
            BoundingBox = "-74.1 40.6 -73.9 40.8",
            Cashtags = "$TSLA $NVDA",
            ConversationID = "1234567890",
            ExactPhrase = "artificial intelligence",
            ExcludeWords = "spam",
            FromUser = "nasa",
            Hashtags = "#AI startups",
            InReplyToTweetID = "1234567890",
            Language = "en",
            ListID = "1234567890",
            MediaType = ExtractionRunParamsMediaType.Images,
            Mentioning = "example_user",
            MinFaves = 10,
            MinQuotes = 2,
            MinReplies = 3,
            MinRetweets = 5,
            Place = "96683cc9126741d1",
            PlaceCountry = "US",
            PointRadius = "-73.99 40.73 25mi",
            Quotes = ExtractionRunParamsQuotes.Include,
            QuotesOfTweetID = "1234567890",
            Replies = ExtractionRunParamsReplies.Include,
            ResultsLimit = 1000,
            Retweets = ExtractionRunParamsRetweets.Exclude,
            RetweetsOfTweetID = "1234567890",
            SearchQuery = "AI trends 2025",
            SinceDate = "2025-01-01",
            TargetCommunityID = "1500000000000000000",
            TargetListID = "1234567890",
            TargetSpaceID = "1vOGwMdBqpwGB",
            TargetTweetID = "1234567890",
            TargetUsername = "elonmusk",
            ToUser = "openai",
            UntilDate = "2025-12-31",
            UrlValue = "example.com",
            VerifiedOnly = false,
        };

        ExtractionRunParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExtractionRunParamsToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunParamsToolType.ArticleExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunityExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionRunParamsToolType.CommunityPostExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunitySearch)]
    [InlineData(ExtractionRunParamsToolType.Favoriters)]
    [InlineData(ExtractionRunParamsToolType.FollowerExplorer)]
    [InlineData(ExtractionRunParamsToolType.FollowingExplorer)]
    [InlineData(ExtractionRunParamsToolType.ListFollowerExplorer)]
    [InlineData(ExtractionRunParamsToolType.ListMemberExtractor)]
    [InlineData(ExtractionRunParamsToolType.ListPostExtractor)]
    [InlineData(ExtractionRunParamsToolType.MentionExtractor)]
    [InlineData(ExtractionRunParamsToolType.PeopleSearch)]
    [InlineData(ExtractionRunParamsToolType.PostExtractor)]
    [InlineData(ExtractionRunParamsToolType.QuoteExtractor)]
    [InlineData(ExtractionRunParamsToolType.ReplyExtractor)]
    [InlineData(ExtractionRunParamsToolType.RepostExtractor)]
    [InlineData(ExtractionRunParamsToolType.SpaceExplorer)]
    [InlineData(ExtractionRunParamsToolType.ThreadExtractor)]
    [InlineData(ExtractionRunParamsToolType.TweetSearchExtractor)]
    [InlineData(ExtractionRunParamsToolType.UserLikes)]
    [InlineData(ExtractionRunParamsToolType.UserMedia)]
    [InlineData(ExtractionRunParamsToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ExtractionRunParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunParamsToolType.ArticleExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunityExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionRunParamsToolType.CommunityPostExtractor)]
    [InlineData(ExtractionRunParamsToolType.CommunitySearch)]
    [InlineData(ExtractionRunParamsToolType.Favoriters)]
    [InlineData(ExtractionRunParamsToolType.FollowerExplorer)]
    [InlineData(ExtractionRunParamsToolType.FollowingExplorer)]
    [InlineData(ExtractionRunParamsToolType.ListFollowerExplorer)]
    [InlineData(ExtractionRunParamsToolType.ListMemberExtractor)]
    [InlineData(ExtractionRunParamsToolType.ListPostExtractor)]
    [InlineData(ExtractionRunParamsToolType.MentionExtractor)]
    [InlineData(ExtractionRunParamsToolType.PeopleSearch)]
    [InlineData(ExtractionRunParamsToolType.PostExtractor)]
    [InlineData(ExtractionRunParamsToolType.QuoteExtractor)]
    [InlineData(ExtractionRunParamsToolType.ReplyExtractor)]
    [InlineData(ExtractionRunParamsToolType.RepostExtractor)]
    [InlineData(ExtractionRunParamsToolType.SpaceExplorer)]
    [InlineData(ExtractionRunParamsToolType.ThreadExtractor)]
    [InlineData(ExtractionRunParamsToolType.TweetSearchExtractor)]
    [InlineData(ExtractionRunParamsToolType.UserLikes)]
    [InlineData(ExtractionRunParamsToolType.UserMedia)]
    [InlineData(ExtractionRunParamsToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ExtractionRunParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionRunParamsMediaTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunParamsMediaType.Images)]
    [InlineData(ExtractionRunParamsMediaType.Videos)]
    [InlineData(ExtractionRunParamsMediaType.Gifs)]
    [InlineData(ExtractionRunParamsMediaType.Media)]
    [InlineData(ExtractionRunParamsMediaType.Links)]
    [InlineData(ExtractionRunParamsMediaType.None)]
    public void Validation_Works(ExtractionRunParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsMediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunParamsMediaType.Images)]
    [InlineData(ExtractionRunParamsMediaType.Videos)]
    [InlineData(ExtractionRunParamsMediaType.Gifs)]
    [InlineData(ExtractionRunParamsMediaType.Media)]
    [InlineData(ExtractionRunParamsMediaType.Links)]
    [InlineData(ExtractionRunParamsMediaType.None)]
    public void SerializationRoundtrip_Works(ExtractionRunParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsMediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionRunParamsMediaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionRunParamsMediaType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionRunParamsQuotesTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunParamsQuotes.Include)]
    [InlineData(ExtractionRunParamsQuotes.Exclude)]
    [InlineData(ExtractionRunParamsQuotes.Only)]
    public void Validation_Works(ExtractionRunParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsQuotes> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunParamsQuotes.Include)]
    [InlineData(ExtractionRunParamsQuotes.Exclude)]
    [InlineData(ExtractionRunParamsQuotes.Only)]
    public void SerializationRoundtrip_Works(ExtractionRunParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsQuotes> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsQuotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsQuotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionRunParamsRepliesTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunParamsReplies.Include)]
    [InlineData(ExtractionRunParamsReplies.Exclude)]
    [InlineData(ExtractionRunParamsReplies.Only)]
    public void Validation_Works(ExtractionRunParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsReplies> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunParamsReplies.Include)]
    [InlineData(ExtractionRunParamsReplies.Exclude)]
    [InlineData(ExtractionRunParamsReplies.Only)]
    public void SerializationRoundtrip_Works(ExtractionRunParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsReplies> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsReplies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsReplies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionRunParamsRetweetsTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunParamsRetweets.Include)]
    [InlineData(ExtractionRunParamsRetweets.Exclude)]
    [InlineData(ExtractionRunParamsRetweets.Only)]
    public void Validation_Works(ExtractionRunParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsRetweets> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunParamsRetweets.Include)]
    [InlineData(ExtractionRunParamsRetweets.Exclude)]
    [InlineData(ExtractionRunParamsRetweets.Only)]
    public void SerializationRoundtrip_Works(ExtractionRunParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunParamsRetweets> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsRetweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunParamsRetweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
