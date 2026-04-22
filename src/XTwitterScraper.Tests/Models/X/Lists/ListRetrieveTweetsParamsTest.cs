using System;
using XTwitterScraper.Models.X.Lists;

namespace XTwitterScraper.Tests.Models.X.Lists;

public class ListRetrieveTweetsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListRetrieveTweetsParams
        {
            ID = "id",
            Cursor = "cursor",
            IncludeReplies = true,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        string expectedID = "id";
        string expectedCursor = "cursor";
        bool expectedIncludeReplies = true;
        string expectedSinceTime = "sinceTime";
        string expectedUntilTime = "untilTime";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIncludeReplies, parameters.IncludeReplies);
        Assert.Equal(expectedSinceTime, parameters.SinceTime);
        Assert.Equal(expectedUntilTime, parameters.UntilTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ListRetrieveTweetsParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IncludeReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("includeReplies"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ListRetrieveTweetsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IncludeReplies = null,
            SinceTime = null,
            UntilTime = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IncludeReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("includeReplies"));
        Assert.Null(parameters.SinceTime);
        Assert.False(parameters.RawQueryData.ContainsKey("sinceTime"));
        Assert.Null(parameters.UntilTime);
        Assert.False(parameters.RawQueryData.ContainsKey("untilTime"));
    }

    [Fact]
    public void Url_Works()
    {
        ListRetrieveTweetsParams parameters = new()
        {
            ID = "id",
            Cursor = "cursor",
            IncludeReplies = true,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/lists/id/tweets?cursor=cursor&includeReplies=true&sinceTime=sinceTime&untilTime=untilTime"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ListRetrieveTweetsParams
        {
            ID = "id",
            Cursor = "cursor",
            IncludeReplies = true,
            SinceTime = "sinceTime",
            UntilTime = "untilTime",
        };

        ListRetrieveTweetsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
