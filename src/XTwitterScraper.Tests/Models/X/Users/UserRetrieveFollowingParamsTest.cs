using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveFollowingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveFollowingParams
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 0,
        };

        string expectedID = "id";
        string expectedCursor = "cursor";
        long expectedPageSize = 0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveFollowingParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveFollowingParams
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
        UserRetrieveFollowingParams parameters = new()
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/x/users/id/following?cursor=cursor&pageSize=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveFollowingParams
        {
            ID = "id",
            Cursor = "cursor",
            PageSize = 0,
        };

        UserRetrieveFollowingParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
