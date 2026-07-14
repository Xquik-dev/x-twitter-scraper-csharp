using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetSearchParams
        {
            Q = "q",
            AdvancedQuery = "advancedQuery",
            AnyWords = "anyWords",
            BoundingBox = "boundingBox",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            Limit = 200,
            ListID = "listId",
            MediaType = TweetSearchParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            Place = "place",
            PlaceCountry = "placeCountry",
            PointRadius = "pointRadius",
            QueryType = QueryType.Latest,
            Quotes = TweetSearchParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = TweetSearchParamsReplies.Include,
            Retweets = TweetSearchParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            SinceTime = "sinceTime",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UntilTime = "untilTime",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        string expectedQ = "q";
        string expectedAdvancedQuery = "advancedQuery";
        string expectedAnyWords = "anyWords";
        string expectedBoundingBox = "boundingBox";
        string expectedCashtags = "cashtags";
        string expectedConversationID = "conversationId";
        string expectedCursor = "cursor";
        string expectedExactPhrase = "exactPhrase";
        string expectedExcludeWords = "excludeWords";
        string expectedFromUser = "fromUser";
        string expectedHashtags = "hashtags";
        string expectedInReplyToTweetID = "inReplyToTweetId";
        string expectedLanguage = "language";
        long expectedLimit = 200;
        string expectedListID = "listId";
        ApiEnum<string, TweetSearchParamsMediaType> expectedMediaType =
            TweetSearchParamsMediaType.Images;
        string expectedMentioning = "mentioning";
        long expectedMinFaves = 0;
        long expectedMinQuotes = 0;
        long expectedMinReplies = 0;
        long expectedMinRetweets = 0;
        string expectedPlace = "place";
        string expectedPlaceCountry = "placeCountry";
        string expectedPointRadius = "pointRadius";
        ApiEnum<string, QueryType> expectedQueryType = QueryType.Latest;
        ApiEnum<string, TweetSearchParamsQuotes> expectedQuotes = TweetSearchParamsQuotes.Include;
        string expectedQuotesOfTweetID = "quotesOfTweetId";
        ApiEnum<string, TweetSearchParamsReplies> expectedReplies =
            TweetSearchParamsReplies.Include;
        ApiEnum<string, TweetSearchParamsRetweets> expectedRetweets =
            TweetSearchParamsRetweets.Include;
        string expectedRetweetsOfTweetID = "retweetsOfTweetId";
        string expectedSinceDate = "2019-12-27";
        string expectedSinceTime = "sinceTime";
        string expectedToUser = "toUser";
        string expectedUntilDate = "2019-12-27";
        string expectedUntilTime = "untilTime";
        string expectedUrlValue = "url";
        bool expectedVerifiedOnly = true;

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedAdvancedQuery, parameters.AdvancedQuery);
        Assert.Equal(expectedAnyWords, parameters.AnyWords);
        Assert.Equal(expectedBoundingBox, parameters.BoundingBox);
        Assert.Equal(expectedCashtags, parameters.Cashtags);
        Assert.Equal(expectedConversationID, parameters.ConversationID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExactPhrase, parameters.ExactPhrase);
        Assert.Equal(expectedExcludeWords, parameters.ExcludeWords);
        Assert.Equal(expectedFromUser, parameters.FromUser);
        Assert.Equal(expectedHashtags, parameters.Hashtags);
        Assert.Equal(expectedInReplyToTweetID, parameters.InReplyToTweetID);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedLimit, parameters.Limit);
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
        Assert.Equal(expectedQueryType, parameters.QueryType);
        Assert.Equal(expectedQuotes, parameters.Quotes);
        Assert.Equal(expectedQuotesOfTweetID, parameters.QuotesOfTweetID);
        Assert.Equal(expectedReplies, parameters.Replies);
        Assert.Equal(expectedRetweets, parameters.Retweets);
        Assert.Equal(expectedRetweetsOfTweetID, parameters.RetweetsOfTweetID);
        Assert.Equal(expectedSinceDate, parameters.SinceDate);
        Assert.Equal(expectedSinceTime, parameters.SinceTime);
        Assert.Equal(expectedToUser, parameters.ToUser);
        Assert.Equal(expectedUntilDate, parameters.UntilDate);
        Assert.Equal(expectedUntilTime, parameters.UntilTime);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedVerifiedOnly, parameters.VerifiedOnly);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetSearchParams { Q = "q" };

        Assert.Null(parameters.AdvancedQuery);
        Assert.False(parameters.RawQueryData.ContainsKey("advancedQuery"));
        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawQueryData.ContainsKey("anyWords"));
        Assert.Null(parameters.BoundingBox);
        Assert.False(parameters.RawQueryData.ContainsKey("boundingBox"));
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
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ListID);
        Assert.False(parameters.RawQueryData.ContainsKey("listId"));
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
        Assert.Null(parameters.Place);
        Assert.False(parameters.RawQueryData.ContainsKey("place"));
        Assert.Null(parameters.PlaceCountry);
        Assert.False(parameters.RawQueryData.ContainsKey("placeCountry"));
        Assert.Null(parameters.PointRadius);
        Assert.False(parameters.RawQueryData.ContainsKey("pointRadius"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
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
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawQueryData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawQueryData.ContainsKey("untilDate"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawQueryData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetSearchParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            AdvancedQuery = null,
            AnyWords = null,
            BoundingBox = null,
            Cashtags = null,
            ConversationID = null,
            Cursor = null,
            ExactPhrase = null,
            ExcludeWords = null,
            FromUser = null,
            Hashtags = null,
            InReplyToTweetID = null,
            Language = null,
            Limit = null,
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
            QueryType = null,
            Quotes = null,
            QuotesOfTweetID = null,
            Replies = null,
            Retweets = null,
            RetweetsOfTweetID = null,
            SinceDate = null,
            SinceTime = null,
            ToUser = null,
            UntilDate = null,
            UntilTime = null,
            UrlValue = null,
            VerifiedOnly = null,
        };

        Assert.Null(parameters.AdvancedQuery);
        Assert.False(parameters.RawQueryData.ContainsKey("advancedQuery"));
        Assert.Null(parameters.AnyWords);
        Assert.False(parameters.RawQueryData.ContainsKey("anyWords"));
        Assert.Null(parameters.BoundingBox);
        Assert.False(parameters.RawQueryData.ContainsKey("boundingBox"));
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
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ListID);
        Assert.False(parameters.RawQueryData.ContainsKey("listId"));
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
        Assert.Null(parameters.Place);
        Assert.False(parameters.RawQueryData.ContainsKey("place"));
        Assert.Null(parameters.PlaceCountry);
        Assert.False(parameters.RawQueryData.ContainsKey("placeCountry"));
        Assert.Null(parameters.PointRadius);
        Assert.False(parameters.RawQueryData.ContainsKey("pointRadius"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
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
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.ToUser);
        Assert.False(parameters.RawQueryData.ContainsKey("toUser"));
        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawQueryData.ContainsKey("untilDate"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawQueryData.ContainsKey("url"));
        Assert.Null(parameters.VerifiedOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("verifiedOnly"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetSearchParams parameters = new()
        {
            Q = "q",
            AdvancedQuery = "advancedQuery",
            AnyWords = "anyWords",
            BoundingBox = "boundingBox",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            Limit = 200,
            ListID = "listId",
            MediaType = TweetSearchParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            Place = "place",
            PlaceCountry = "placeCountry",
            PointRadius = "pointRadius",
            QueryType = QueryType.Latest,
            Quotes = TweetSearchParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = TweetSearchParamsReplies.Include,
            Retweets = TweetSearchParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            SinceTime = "sinceTime",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UntilTime = "untilTime",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/tweets/search?q=q&advancedQuery=advancedQuery&anyWords=anyWords&boundingBox=boundingBox&cashtags=cashtags&conversationId=conversationId&cursor=cursor&exactPhrase=exactPhrase&excludeWords=excludeWords&fromUser=fromUser&hashtags=hashtags&inReplyToTweetId=inReplyToTweetId&language=language&limit=200&listId=listId&mediaType=images&mentioning=mentioning&minFaves=0&minQuotes=0&minReplies=0&minRetweets=0&place=place&placeCountry=placeCountry&pointRadius=pointRadius&queryType=Latest&quotes=include&quotesOfTweetId=quotesOfTweetId&replies=include&retweets=include&retweetsOfTweetId=retweetsOfTweetId&sinceDate=2019-12-27&sinceTime=sinceTime&toUser=toUser&untilDate=2019-12-27&untilTime=untilTime&url=url&verifiedOnly=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetSearchParams
        {
            Q = "q",
            AdvancedQuery = "advancedQuery",
            AnyWords = "anyWords",
            BoundingBox = "boundingBox",
            Cashtags = "cashtags",
            ConversationID = "conversationId",
            Cursor = "cursor",
            ExactPhrase = "exactPhrase",
            ExcludeWords = "excludeWords",
            FromUser = "fromUser",
            Hashtags = "hashtags",
            InReplyToTweetID = "inReplyToTweetId",
            Language = "language",
            Limit = 200,
            ListID = "listId",
            MediaType = TweetSearchParamsMediaType.Images,
            Mentioning = "mentioning",
            MinFaves = 0,
            MinQuotes = 0,
            MinReplies = 0,
            MinRetweets = 0,
            Place = "place",
            PlaceCountry = "placeCountry",
            PointRadius = "pointRadius",
            QueryType = QueryType.Latest,
            Quotes = TweetSearchParamsQuotes.Include,
            QuotesOfTweetID = "quotesOfTweetId",
            Replies = TweetSearchParamsReplies.Include,
            Retweets = TweetSearchParamsRetweets.Include,
            RetweetsOfTweetID = "retweetsOfTweetId",
            SinceDate = "2019-12-27",
            SinceTime = "sinceTime",
            ToUser = "toUser",
            UntilDate = "2019-12-27",
            UntilTime = "untilTime",
            UrlValue = "url",
            VerifiedOnly = true,
        };

        TweetSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TweetSearchParamsMediaTypeTest : TestBase
{
    [Theory]
    [InlineData(TweetSearchParamsMediaType.Images)]
    [InlineData(TweetSearchParamsMediaType.Videos)]
    [InlineData(TweetSearchParamsMediaType.Gifs)]
    [InlineData(TweetSearchParamsMediaType.Media)]
    [InlineData(TweetSearchParamsMediaType.Links)]
    [InlineData(TweetSearchParamsMediaType.None)]
    public void Validation_Works(TweetSearchParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsMediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TweetSearchParamsMediaType.Images)]
    [InlineData(TweetSearchParamsMediaType.Videos)]
    [InlineData(TweetSearchParamsMediaType.Gifs)]
    [InlineData(TweetSearchParamsMediaType.Media)]
    [InlineData(TweetSearchParamsMediaType.Links)]
    [InlineData(TweetSearchParamsMediaType.None)]
    public void SerializationRoundtrip_Works(TweetSearchParamsMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsMediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsMediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsMediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class QueryTypeTest : TestBase
{
    [Theory]
    [InlineData(QueryType.Latest)]
    [InlineData(QueryType.Top)]
    public void Validation_Works(QueryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QueryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QueryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(QueryType.Latest)]
    [InlineData(QueryType.Top)]
    public void SerializationRoundtrip_Works(QueryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QueryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QueryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QueryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QueryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TweetSearchParamsQuotesTest : TestBase
{
    [Theory]
    [InlineData(TweetSearchParamsQuotes.Include)]
    [InlineData(TweetSearchParamsQuotes.Exclude)]
    [InlineData(TweetSearchParamsQuotes.Only)]
    public void Validation_Works(TweetSearchParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsQuotes> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TweetSearchParamsQuotes.Include)]
    [InlineData(TweetSearchParamsQuotes.Exclude)]
    [InlineData(TweetSearchParamsQuotes.Only)]
    public void SerializationRoundtrip_Works(TweetSearchParamsQuotes rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsQuotes> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsQuotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsQuotes>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsQuotes>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TweetSearchParamsRepliesTest : TestBase
{
    [Theory]
    [InlineData(TweetSearchParamsReplies.Include)]
    [InlineData(TweetSearchParamsReplies.Exclude)]
    [InlineData(TweetSearchParamsReplies.Only)]
    public void Validation_Works(TweetSearchParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsReplies> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TweetSearchParamsReplies.Include)]
    [InlineData(TweetSearchParamsReplies.Exclude)]
    [InlineData(TweetSearchParamsReplies.Only)]
    public void SerializationRoundtrip_Works(TweetSearchParamsReplies rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsReplies> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsReplies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsReplies>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsReplies>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TweetSearchParamsRetweetsTest : TestBase
{
    [Theory]
    [InlineData(TweetSearchParamsRetweets.Include)]
    [InlineData(TweetSearchParamsRetweets.Exclude)]
    [InlineData(TweetSearchParamsRetweets.Only)]
    public void Validation_Works(TweetSearchParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsRetweets> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TweetSearchParamsRetweets.Include)]
    [InlineData(TweetSearchParamsRetweets.Exclude)]
    [InlineData(TweetSearchParamsRetweets.Only)]
    public void SerializationRoundtrip_Works(TweetSearchParamsRetweets rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetSearchParamsRetweets> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsRetweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsRetweets>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetSearchParamsRetweets>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
