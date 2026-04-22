using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveSearchParams { Q = "q", Cursor = "cursor" };

        string expectedQ = "q";
        string expectedCursor = "cursor";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveSearchParams { Q = "q" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveSearchParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveSearchParams parameters = new() { Q = "q", Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/x/users/search?q=q&cursor=cursor"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveSearchParams { Q = "q", Cursor = "cursor" };

        UserRetrieveSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
