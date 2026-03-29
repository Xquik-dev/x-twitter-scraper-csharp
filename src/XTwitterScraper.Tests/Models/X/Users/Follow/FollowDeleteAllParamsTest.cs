using System;
using XTwitterScraper.Models.X.Users.Follow;

namespace XTwitterScraper.Tests.Models.X.Users.Follow;

public class FollowDeleteAllParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowDeleteAllParams { UserID = "userId", Account = "account" };

        string expectedUserID = "userId";
        string expectedAccount = "account";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        FollowDeleteAllParams parameters = new() { UserID = "userId", Account = "account" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/users/userId/follow"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FollowDeleteAllParams { UserID = "userId", Account = "account" };

        FollowDeleteAllParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
