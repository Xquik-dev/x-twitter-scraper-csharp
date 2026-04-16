using System;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Tests.Models.X.Dm;

public class DmRetrieveHistoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DmRetrieveHistoryParams
        {
            UserID = "userId",
            Cursor = "cursor",
            MaxID = "maxId",
        };

        string expectedUserID = "userId";
        string expectedCursor = "cursor";
        string expectedMaxID = "maxId";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedMaxID, parameters.MaxID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DmRetrieveHistoryParams { UserID = "userId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.MaxID);
        Assert.False(parameters.RawQueryData.ContainsKey("maxId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DmRetrieveHistoryParams
        {
            UserID = "userId",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            MaxID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.MaxID);
        Assert.False(parameters.RawQueryData.ContainsKey("maxId"));
    }

    [Fact]
    public void Url_Works()
    {
        DmRetrieveHistoryParams parameters = new()
        {
            UserID = "userId",
            Cursor = "cursor",
            MaxID = "maxId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/x/dm/userId/history?cursor=cursor&maxId=maxId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DmRetrieveHistoryParams
        {
            UserID = "userId",
            Cursor = "cursor",
            MaxID = "maxId",
        };

        DmRetrieveHistoryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
