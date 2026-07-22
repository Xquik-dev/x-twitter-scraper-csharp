using System;
using XTwitterScraper.Models.X.Communities.Tweets;

namespace XTwitterScraper.Tests.Models.X.Communities.Tweets;

public class TweetListByCommunityParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetListByCommunityParams
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 1,
        };

        string expectedID = "id";
        string expectedCursor = "cursor";
        long expectedPageSize = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetListByCommunityParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetListByCommunityParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            PageSize = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetListByCommunityParams parameters = new()
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/communities/id/tweets?cursor=cursor&pageSize=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetListByCommunityParams
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 1,
        };

        TweetListByCommunityParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
