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
            Cursor = "cursor",
            Limit = 200,
            QueryType = QueryType.Latest,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        string expectedQ = "q";
        string expectedCursor = "cursor";
        long expectedLimit = 200;
        ApiEnum<string, QueryType> expectedQueryType = QueryType.Latest;
        string expectedSinceTime = "sinceTime";
        string expectedUntilTime = "untilTime";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedQueryType, parameters.QueryType);
        Assert.Equal(expectedSinceTime, parameters.SinceTime);
        Assert.Equal(expectedUntilTime, parameters.UntilTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetSearchParams { Q = "q" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetSearchParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            QueryType = null,
            SinceTime = null,
            UntilTime = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetSearchParams parameters = new()
        {
            Q = "q",
            Cursor = "cursor",
            Limit = 200,
            QueryType = QueryType.Latest,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/tweets/search?q=q&cursor=cursor&limit=200&queryType=Latest&sinceTime=sinceTime&untilTime=untilTime"
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
            Cursor = "cursor",
            Limit = 200,
            QueryType = QueryType.Latest,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        TweetSearchParams copied = new(parameters);

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
