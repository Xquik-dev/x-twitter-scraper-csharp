using System;
using XTwitterScraper.Models.X.Users.Follow;

namespace XTwitterScraper.Tests.Models.X.Users.Follow;

public class FollowDeleteAllParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowDeleteAllParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        FollowDeleteAllParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/users/id/follow"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FollowDeleteAllParams { ID = "id", Account = "@elonmusk" };

        FollowDeleteAllParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
