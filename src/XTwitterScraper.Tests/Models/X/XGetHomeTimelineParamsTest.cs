using System;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetHomeTimelineParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new XGetHomeTimelineParams
        {
            Cursor = "cursor",
            SeenTweetIds = "seenTweetIds",
        };

        string expectedCursor = "cursor";
        string expectedSeenTweetIds = "seenTweetIds";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedSeenTweetIds, parameters.SeenTweetIds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new XGetHomeTimelineParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.SeenTweetIds);
        Assert.False(parameters.RawQueryData.ContainsKey("seenTweetIds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new XGetHomeTimelineParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            SeenTweetIds = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.SeenTweetIds);
        Assert.False(parameters.RawQueryData.ContainsKey("seenTweetIds"));
    }

    [Fact]
    public void Url_Works()
    {
        XGetHomeTimelineParams parameters = new()
        {
            Cursor = "cursor",
            SeenTweetIds = "seenTweetIds",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://xquik.com/api/v1/x/timeline?cursor=cursor&seenTweetIds=seenTweetIds"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new XGetHomeTimelineParams
        {
            Cursor = "cursor",
            SeenTweetIds = "seenTweetIds",
        };

        XGetHomeTimelineParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
