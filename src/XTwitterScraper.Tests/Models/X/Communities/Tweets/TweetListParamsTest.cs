using System;
using XTwitterScraper.Models.X.Communities.Tweets;

namespace XTwitterScraper.Tests.Models.X.Communities.Tweets;

public class TweetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetListParams
        {
            Q = "q",
            Cursor = "cursor",
            QueryType = "queryType",
        };

        string expectedQ = "q";
        string expectedCursor = "cursor";
        string expectedQueryType = "queryType";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedQueryType, parameters.QueryType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetListParams { Q = "q" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetListParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            QueryType = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.QueryType);
        Assert.False(parameters.RawQueryData.ContainsKey("queryType"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetListParams parameters = new()
        {
            Q = "q",
            Cursor = "cursor",
            QueryType = "queryType",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/x/communities/tweets?q=q&cursor=cursor&queryType=queryType"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetListParams
        {
            Q = "q",
            Cursor = "cursor",
            QueryType = "queryType",
        };

        TweetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
