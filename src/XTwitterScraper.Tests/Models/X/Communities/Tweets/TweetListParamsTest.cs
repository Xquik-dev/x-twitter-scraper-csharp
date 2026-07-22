using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Communities.Tweets;

namespace XTwitterScraper.Tests.Models.X.Communities.Tweets;

public class TweetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetListParams
        {
            CommunityID = "321669910225",
            Q = "q",
            Cursor = "cursor",
            PageSize = 1,
            QueryType = QueryType.Latest,
        };

        string expectedCommunityID = "321669910225";
        string expectedQ = "q";
        string expectedCursor = "cursor";
        long expectedPageSize = 1;
        ApiEnum<string, QueryType> expectedQueryType = QueryType.Latest;

        Assert.Equal(expectedCommunityID, parameters.CommunityID);
        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedQueryType, parameters.QueryType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetListParams { CommunityID = "321669910225", Q = "q" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetListParams
        {
            CommunityID = "321669910225",
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            PageSize = null,
            QueryType = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetListParams parameters = new()
        {
            CommunityID = "321669910225",
            Q = "q",
            Cursor = "cursor",
            PageSize = 1,
            QueryType = QueryType.Latest,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/communities/tweets?communityId=321669910225&q=q&cursor=cursor&pageSize=1&queryType=Latest"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetListParams
        {
            CommunityID = "321669910225",
            Q = "q",
            Cursor = "cursor",
            PageSize = 1,
            QueryType = QueryType.Latest,
        };

        TweetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
