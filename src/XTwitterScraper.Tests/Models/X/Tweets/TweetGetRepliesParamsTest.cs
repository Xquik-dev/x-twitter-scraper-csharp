using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetGetRepliesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetGetRepliesParams
        {
            ID = "id",
            Cursor = "cursor",
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        string expectedID = "id";
        string expectedCursor = "cursor";
        string expectedSinceTime = "sinceTime";
        string expectedUntilTime = "untilTime";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedSinceTime, parameters.SinceTime);
        Assert.Equal(expectedUntilTime, parameters.UntilTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetGetRepliesParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetGetRepliesParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            SinceTime = null,
            UntilTime = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetGetRepliesParams parameters = new()
        {
            ID = "id",
            Cursor = "cursor",
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/tweets/id/replies?cursor=cursor&sinceTime=sinceTime&untilTime=untilTime"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetGetRepliesParams
        {
            ID = "id",
            Cursor = "cursor",
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        TweetGetRepliesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
