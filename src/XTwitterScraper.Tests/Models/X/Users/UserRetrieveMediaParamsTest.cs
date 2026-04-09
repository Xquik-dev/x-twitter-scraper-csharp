using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveMediaParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveMediaParams { ID = "id", Cursor = "cursor" };

        string expectedID = "id";
        string expectedCursor = "cursor";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveMediaParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveMediaParams
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
        UserRetrieveMediaParams parameters = new() { ID = "id", Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/users/id/media?cursor=cursor"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveMediaParams { ID = "id", Cursor = "cursor" };

        UserRetrieveMediaParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
