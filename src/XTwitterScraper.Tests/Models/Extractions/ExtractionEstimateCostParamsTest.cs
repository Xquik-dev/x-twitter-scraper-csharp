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
            ExactPhrase = "artificial intelligence",
            ExcludeWords = "spam",
            SearchQuery = "AI trends 2025",
            TargetCommunityID = "1500000000000000000",
            TargetListID = "1234567890",
            TargetSpaceID = "1vOGwMdBqpwGB",
            TargetTweetID = "1234567890",
            TargetUsername = "elonmusk",
        };

        ApiEnum<string, ExtractionEstimateCostParamsToolType> expectedToolType =
            ExtractionEstimateCostParamsToolType.FollowerExplorer;
        string expectedAdvancedQuery = "min_faves:100";
        string expectedExactPhrase = "artificial intelligence";
        string expectedExcludeWords = "spam";
        string expectedSearchQuery = "AI trends 2025";
        string expectedTargetCommunityID = "1500000000000000000";
        string expectedTargetListID = "1234567890";
        string expectedTargetSpaceID = "1vOGwMdBqpwGB";
        string expectedTargetTweetID = "1234567890";
        string expectedTargetUsername = "elonmusk";

        Assert.Equal(expectedToolType, parameters.ToolType);
        Assert.Equal(expectedAdvancedQuery, parameters.AdvancedQuery);
        Assert.Equal(expectedExactPhrase, parameters.ExactPhrase);
        Assert.Equal(expectedExcludeWords, parameters.ExcludeWords);
        Assert.Equal(expectedSearchQuery, parameters.SearchQuery);
        Assert.Equal(expectedTargetCommunityID, parameters.TargetCommunityID);
        Assert.Equal(expectedTargetListID, parameters.TargetListID);
        Assert.Equal(expectedTargetSpaceID, parameters.TargetSpaceID);
        Assert.Equal(expectedTargetTweetID, parameters.TargetTweetID);
        Assert.Equal(expectedTargetUsername, parameters.TargetUsername);
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
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawBodyData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeWords"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("searchQuery"));
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
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,

            // Null should be interpreted as omitted for these properties
            AdvancedQuery = null,
            ExactPhrase = null,
            ExcludeWords = null,
            SearchQuery = null,
            TargetCommunityID = null,
            TargetListID = null,
            TargetSpaceID = null,
            TargetTweetID = null,
            TargetUsername = null,
        };

        Assert.Null(parameters.AdvancedQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("advancedQuery"));
        Assert.Null(parameters.ExactPhrase);
        Assert.False(parameters.RawBodyData.ContainsKey("exactPhrase"));
        Assert.Null(parameters.ExcludeWords);
        Assert.False(parameters.RawBodyData.ContainsKey("excludeWords"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawBodyData.ContainsKey("searchQuery"));
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
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionEstimateCostParams parameters = new()
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/extractions/estimate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionEstimateCostParams
        {
            ToolType = ExtractionEstimateCostParamsToolType.FollowerExplorer,
            AdvancedQuery = "min_faves:100",
            ExactPhrase = "artificial intelligence",
            ExcludeWords = "spam",
            SearchQuery = "AI trends 2025",
            TargetCommunityID = "1500000000000000000",
            TargetListID = "1234567890",
            TargetSpaceID = "1vOGwMdBqpwGB",
            TargetTweetID = "1234567890",
            TargetUsername = "elonmusk",
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
