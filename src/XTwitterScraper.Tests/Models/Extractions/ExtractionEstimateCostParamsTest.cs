using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionEstimateCostParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
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
            MediaType = MediaType.Images,
            Mentioning = "example_user",
            MinFaves = 10,
            MinQuotes = 2,
            MinReplies = 3,
            MinRetweets = 5,
            Place = "96683cc9126741d1",
            PlaceCountry = "US",
            PointRadius = "-73.99 40.73 25mi",
            Quotes = Quotes.Include,
            QuotesOfTweetID = "1234567890",
            Replies = Replies.Include,
            ResultsLimit = 1000,
            Retweets = Retweets.Exclude,
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

        ApiEnum<string, ExtractionEstimateCostParamsToolType> expectedToolType =
            ExtractionEstimateCostParamsToolType.FollowerExplorer;
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
        ApiEnum<string, MediaType> expectedMediaType = MediaType.Images;
        string expectedMentioning = "example_user";
        long expectedMinFaves = 10;
        long expectedMinQuotes = 2;
        long expectedMinReplies = 3;
        long expectedMinRetweets = 5;
        string expectedPlace = "96683cc9126741d1";
        string expectedPlaceCountry = "US";
        string expectedPointRadius = "-73.99 40.73 25mi";
        ApiEnum<string, Quotes> expectedQuotes = Quotes.Include;
        string expectedQuotesOfTweetID = "1234567890";
        ApiEnum<string, Replies> expectedReplies = Replies.Include;
        long expectedResultsLimit = 1000;
        ApiEnum<string, Retweets> expectedRetweets = Retweets.Exclude;
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
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
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
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,

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
        ExtractionEstimateCostParams parameters = new()
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/extractions/estimate"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
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
            MediaType = MediaType.Images,
            Mentioning = "example_user",
            MinFaves = 10,
            MinQuotes = 2,
            MinReplies = 3,
            MinRetweets = 5,
            Place = "96683cc9126741d1",
            PlaceCountry = "US",
            PointRadius = "-73.99 40.73 25mi",
            Quotes = Quotes.Include,
            QuotesOfTweetID = "1234567890",
            Replies = Replies.Include,
            ResultsLimit = 1000,
            Retweets = Retweets.Exclude,
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

        ExtractionEstimateCostParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExtractionEstimateCostParamsToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionEstimateCostParamsToolType.ArticleExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityPostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunitySearch)]
    [InlineData(ExtractionEstimateCostParamsToolType.Favoriters)]
    [InlineData(ExtractionEstimateCostParamsToolType.FollowerExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.FollowingExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListFollowerExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListMemberExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListPostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.MentionExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.PeopleSearch)]
    [InlineData(ExtractionEstimateCostParamsToolType.PostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.QuoteExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.ReplyExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.RepostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.SpaceExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ThreadExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.TweetSearchExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.UserLikes)]
    [InlineData(ExtractionEstimateCostParamsToolType.UserMedia)]
    [InlineData(ExtractionEstimateCostParamsToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ExtractionEstimateCostParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionEstimateCostParamsToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionEstimateCostParamsToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionEstimateCostParamsToolType.ArticleExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunityPostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.CommunitySearch)]
    [InlineData(ExtractionEstimateCostParamsToolType.Favoriters)]
    [InlineData(ExtractionEstimateCostParamsToolType.FollowerExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.FollowingExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListFollowerExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListMemberExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.ListPostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.MentionExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.PeopleSearch)]
    [InlineData(ExtractionEstimateCostParamsToolType.PostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.QuoteExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.ReplyExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.RepostExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.SpaceExplorer)]
    [InlineData(ExtractionEstimateCostParamsToolType.ThreadExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.TweetSearchExtractor)]
    [InlineData(ExtractionEstimateCostParamsToolType.UserLikes)]
    [InlineData(ExtractionEstimateCostParamsToolType.UserMedia)]
    [InlineData(ExtractionEstimateCostParamsToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ExtractionEstimateCostParamsToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionEstimateCostParamsToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionEstimateCostParamsToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionEstimateCostParamsToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionEstimateCostParamsToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MediaTypeTest : TestBase
{
    [Theory]
    [InlineData(MediaType.Images)]
    [InlineData(MediaType.Videos)]
    [InlineData(MediaType.Gifs)]
    [InlineData(MediaType.Media)]
    [InlineData(MediaType.Links)]
    [InlineData(MediaType.None)]
    public void Validation_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MediaType.Images)]
    [InlineData(MediaType.Videos)]
    [InlineData(MediaType.Gifs)]
    [InlineData(MediaType.Media)]
    [InlineData(MediaType.Links)]
    [InlineData(MediaType.None)]
    public void SerializationRoundtrip_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class QuotesTest : TestBase
{
    [Theory]
    [InlineData(Quotes.Include)]
    [InlineData(Quotes.Exclude)]
    [InlineData(Quotes.Only)]
    public void Validation_Works(Quotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Quotes> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Quotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Quotes.Include)]
    [InlineData(Quotes.Exclude)]
    [InlineData(Quotes.Only)]
    public void SerializationRoundtrip_Works(Quotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Quotes> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Quotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Quotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Quotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RepliesTest : TestBase
{
    [Theory]
    [InlineData(Replies.Include)]
    [InlineData(Replies.Exclude)]
    [InlineData(Replies.Only)]
    public void Validation_Works(Replies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Replies> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Replies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Replies.Include)]
    [InlineData(Replies.Exclude)]
    [InlineData(Replies.Only)]
    public void SerializationRoundtrip_Works(Replies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Replies> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Replies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Replies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Replies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RetweetsTest : TestBase
{
    [Theory]
    [InlineData(Retweets.Include)]
    [InlineData(Retweets.Exclude)]
    [InlineData(Retweets.Only)]
    public void Validation_Works(Retweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Retweets> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Retweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Retweets.Include)]
    [InlineData(Retweets.Exclude)]
    [InlineData(Retweets.Only)]
    public void SerializationRoundtrip_Works(Retweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Retweets> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Retweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Retweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Retweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
