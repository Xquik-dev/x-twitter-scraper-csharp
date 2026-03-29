using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveParams { Username = "username" };

        string expectedUsername = "username";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveParams parameters = new() { Username = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/users/username"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveParams { Username = "username" };

        UserRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
