using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetGetRetweetersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetGetRetweetersParams { ID = "id", Cursor = "cursor" };

        string expectedID = "id";
        string expectedCursor = "cursor";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetGetRetweetersParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetGetRetweetersParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetGetRetweetersParams parameters = new() { ID = "id", Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/id/retweeters?cursor=cursor"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetGetRetweetersParams { ID = "id", Cursor = "cursor" };

        TweetGetRetweetersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
